Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win.UltraWinGrid

Public Class FrmListaCamadaxLote
    Dim cn As New cnControlLoteDestete
    Dim tabla As New DataTable
    Dim listaSeleccionados As New List(Of String)
    Dim listaIdControlFicha As New List(Of String)
    Public idLote As Integer = 0
    Public idPlantel As Integer = 0

    Private Sub FrmListaCamadaxLote_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            Consultar()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Inicializar()
        TxtCantidadCrias.ReadOnly = True
        clsBasicas.Formato_Tablas_Grid(dtgListado)
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True
            ToolStrip1.Enabled = False
            CbxEnvioTotal.Checked = False

            Dim obj As New coControlLoteDestete With {
                .idLote = idLote
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlLoteDestete = CType(e.Argument, coControlLoteDestete)
            tabla = cn.Cn_ConsultarCamadasDestetadasxLote(obj).Copy
            tabla.TableName = "tmp"
            e.Result = tabla
            tabla.Columns(0).ColumnMapping = MappingType.Hidden
            tabla.Columns(1).ColumnMapping = MappingType.Hidden
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Ptbx_Cargando.Visible = False
        ToolStrip1.Enabled = True
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            dtgListado.DataSource = CType(e.Result, DataTable)
        End If
    End Sub

    Private Function SumarColumnaSeleccionadas(ByVal columna As Integer) As Integer
        Dim suma As Integer = 0

        For Each fila As UltraGridRow In dtgListado.Rows
            Dim idControlFicha As String = fila.Cells(0).Value.ToString()
            Dim idCerda As String = fila.Cells(1).Value.ToString()
            Dim cadenaSeleccionada As String = idControlFicha + "+" + idCerda

            If listaSeleccionados.Contains(cadenaSeleccionada) Then
                If Not fila.Cells(columna).Value Is Nothing AndAlso IsNumeric(fila.Cells(columna).Value) Then
                    suma += Convert.ToInt32(fila.Cells(columna).Value)
                End If
            End If
        Next

        Return suma
    End Function

    Private Sub CbxEnvioTotal_CheckedChanged(sender As Object, e As EventArgs) Handles CbxEnvioTotal.CheckedChanged
        Dim seleccionarTodo As Boolean = CbxEnvioTotal.Checked

        For Each fila As UltraGridRow In dtgListado.Rows
            If fila.Activation = Activation.AllowEdit Then
                Dim idControlFicha As String = fila.Cells(0).Value.ToString()
                Dim idCerda As String = fila.Cells(1).Value.ToString()
                Dim cadenaSeleccionada As String = idControlFicha + "+" + idCerda

                If seleccionarTodo Then
                    If Not listaSeleccionados.Contains(cadenaSeleccionada) Then
                        listaSeleccionados.Add(cadenaSeleccionada)
                    End If

                    If Not listaIdControlFicha.Contains(idControlFicha) Then
                        listaIdControlFicha.Add(idControlFicha)
                    End If

                    fila.Appearance.BackColor = Color.LightSkyBlue
                Else
                    If listaSeleccionados.Contains(cadenaSeleccionada) Then
                        listaSeleccionados.Remove(cadenaSeleccionada)
                    End If

                    Dim existeEnOtraFila As Boolean = listaSeleccionados.Any(Function(item) item.StartsWith(idControlFicha + "+"))
                    If Not existeEnOtraFila Then
                        listaIdControlFicha.Remove(idControlFicha)
                    End If

                    fila.Appearance.BackColor = Color.White
                End If
            End If
        Next

        TxtCantidadCrias.Text = SumarColumnasSeleccionadas()
    End Sub

    Private Function SumarColumnasSeleccionadas() As Integer
        Dim sumaTotal As Integer = 0

        For Each fila As UltraGridRow In dtgListado.Rows
            If fila.Activation = Activation.AllowEdit Then
                Dim idControlFicha As String = fila.Cells(0).Value.ToString()
                Dim idCerda As String = fila.Cells(1).Value.ToString()
                Dim cadenaSeleccionada As String = idControlFicha + "+" + idCerda

                If listaSeleccionados.Contains(cadenaSeleccionada) Then
                    Dim totalMachos As Integer = Convert.ToInt32(fila.Cells(5).Value)
                    Dim totalHembras As Integer = Convert.ToInt32(fila.Cells(6).Value)
                    Dim totalMuertosPosParto As Integer = Convert.ToInt32(fila.Cells(12).Value)
                    sumaTotal += totalMachos + totalHembras - totalMuertosPosParto
                End If
            End If
        Next

        Return sumaTotal
    End Function

    Public Sub ReinicarCantidad()
        TxtCantidadCrias.Text = "0"
        listaSeleccionados.Clear()
        listaIdControlFicha.Clear()
    End Sub

    Private Sub BtnEstablecerUbicacion_Click(sender As Object, e As EventArgs) Handles BtnEstablecerUbicacion.Click
        Try
            If listaSeleccionados.Count = 0 Then
                msj_advert("Debe seleccionar al menos una camada")
                Return
            End If

            Dim Seleccionados As String = String.Join(", ", listaSeleccionados)
            Dim idControlParto As String = String.Join(", ", listaIdControlFicha)

            Dim frm As New FrmRegMovimientoUbicacionLote With {
                .cantidadCrias = TxtCantidadCrias.Text,
                .cantidadCriasOriginal = TxtCantidadCrias.Text,
                .idPlantel = idPlantel,
                .listaIdsControlPartoCerda = Seleccionados,
                .listaIdsControlParto = idControlParto,
                .idLote = idLote,
                .frmListarCamadaLote = Me
            }
            frm.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class