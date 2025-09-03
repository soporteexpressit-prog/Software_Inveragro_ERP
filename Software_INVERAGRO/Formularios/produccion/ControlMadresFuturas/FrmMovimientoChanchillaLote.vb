Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmMovimientoChanchillaLote
    Dim cn As New cnControlLoteDestete
    Public valorLote As String = ""
    Public valorUbicacion As String = ""
    Public idLote As Integer = 0
    Public idPlantel As Integer = 0
    Private search As Boolean = False
    Dim tbtmp As New DataTable

    Private Sub FrmMovimientoChanchillaLote_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            ListarLotes()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        clsBasicas.LlenarComboAnios(CmbAnios)
        Ptbx_Cargando.Visible = True
        clsBasicas.Formato_Tablas_Grid_UltimaColumnaEditable(DtgListadoAnimales)
        LblNombreLote.Text = valorLote
        LblUbicacion.Text = valorUbicacion
    End Sub

    Sub ListarLotes()
        Dim cn As New cnControlLoteDestete
        Dim obj As New coControlLoteDestete With {
           .Anio = CmbAnios.Text,
           .IdPlantel = idPlantel
        }
        Dim tb As New DataTable
        tb = cn.Cn_ConsultarLotesAnioCombo(obj).Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione un Plantel"
        With CmbLotes
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
        search = True
    End Sub

    Private Sub CmbAnios_TextChanged(sender As Object, e As EventArgs) Handles CmbAnios.TextChanged
        If (search) Then
            ListarLotes()
        End If
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True

            Dim obj As New coControlLoteDestete With {
                .IdLote = idLote
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlLoteDestete = CType(e.Argument, coControlLoteDestete)
            tbtmp = cn.Cn_ObtenerChanchillasMeishan(obj).Copy
            tbtmp.TableName = "tmp"
            e.Result = tbtmp
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            DtgListadoAnimales.DataSource = CType(e.Result, DataTable)
            Ptbx_Cargando.Visible = False
            PintarColumnaPorIndice(2)
        End If
    End Sub

    Private Sub PintarColumnaPorIndice(indiceColumna As Integer)
        For Each fila As UltraGridRow In DtgListadoAnimales.Rows
            If fila.Cells.Count > indiceColumna Then
                With fila.Cells(indiceColumna).Appearance
                    .BackColor = Color.FromArgb(234, 239, 239)
                    .FontData.Bold = DefaultableBoolean.True
                End With
            End If
        Next
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            DtgListadoAnimales.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode)

            If DtgListadoAnimales.Rows.Count = 0 Then
                msj_advert("No hay datos disponibles para procesar")
                Return
            End If

            For Each fila As UltraGridRow In DtgListadoAnimales.Rows
                If fila.Cells.Count >= 3 Then
                    Dim cantidadDisponible As Object = fila.Cells(1).Value
                    Dim cantidadMover As Object = fila.Cells(2).Value
                    If IsNumeric(cantidadDisponible) AndAlso IsNumeric(cantidadMover) Then
                        If Convert.ToInt32(cantidadMover) > Convert.ToInt32(cantidadDisponible) Then
                            msj_advert("La cantidad a mover no puede ser mayor a la cantidad disponible")
                            Return
                        End If
                    End If
                End If
            Next

            Dim numPuras As Integer = 0
            Dim numCambor As Integer = 0
            Dim numCelador As Integer = 0
            Dim numMeishan As Integer = 0

            For Each fila As UltraGridRow In DtgListadoAnimales.Rows
                If fila.Cells.Count >= 3 Then
                    Dim tipoAnimal As String = fila.Cells(0).Value?.ToString().ToUpper().Trim()
                    Dim cantidadMover As Object = fila.Cells(2).Value

                    Dim cantidad As Integer = 0
                    If IsNumeric(cantidadMover) Then
                        cantidad = Convert.ToInt32(cantidadMover)
                    End If

                    Select Case tipoAnimal
                        Case "TOTAL PURAS"
                            numPuras = cantidad
                        Case "TOTAL CAMBOROUGH"
                            numCambor = cantidad
                        Case "TOTAL CELADORES"
                            numCelador = cantidad
                        Case "TOTAL M. MEISHAN"
                            numMeishan = cantidad
                    End Select
                End If
            Next

            If numPuras = 0 AndAlso numCambor = 0 AndAlso numCelador = 0 AndAlso numMeishan = 0 Then
                msj_advert("Debe ingresar al menos una cantidad mayor a 0 para mover")
                Return
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE REALIZAR ESTE MOVIMIENTO?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coControlLoteDestete With {
                .CantidadPuras = numPuras,
                .CantidadTatuadas = numCambor,
                .CantidadVenta = numCelador,
                .CantidadMeishan = numMeishan,
                .IdLote = CmbLotes.Value
            }

            Dim MensajeBgWk As String = cn.Cn_RegMovimientoChanchillaMeishan(obj)

            If (obj.Coderror = 0) Then
                msj_ok(MensajeBgWk)
                Dispose()
            Else
                msj_advert(MensajeBgWk)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class