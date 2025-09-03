Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmDefinirGruposDestete
    Dim cn As New cnControlLoteDestete
    Public idPlantel As Integer = 0
    Private search As Boolean = False
    Dim ds As New DataSet
    Private DtDetalle As New DataTable("TempDetPresupuesto")

    Private Sub FrmDefinirGruposDestete_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            ListarLotes()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        Ptbx_Cargando.Visible = False
        clsBasicas.LlenarComboAnios(CmbAnios)
        clsBasicas.Formato_Tablas_Grid(DtgConsolidadEdad)
        CargarTablaDetalleGrupos()
    End Sub

    Sub CargarTablaDetalleGrupos()
        DtDetalle = New DataTable("TempDetPresupuesto")
        DtDetalle.Columns.Add("idGrupo", GetType(Integer))
        DtDetalle.Columns.Add("cantidadAnimales", GetType(Integer))
        DtDetalle.Columns.Add("btnEliminar", GetType(String))
        DtgConsolidadEdad.DataSource = DtDetalle
    End Sub

    Private Sub BloquearControladores()
        Ptbx_Cargando.Visible = True
        CmbAnios.Enabled = False
        CmbLotes.Enabled = False
        btnIngresarGrupo.Enabled = False
        ToolStrip1.Enabled = False
        GrupoTabla.Enabled = False
    End Sub

    Private Sub DesbloquearControladores()
        Ptbx_Cargando.Visible = False
        CmbAnios.Enabled = True
        CmbLotes.Enabled = True
        btnIngresarGrupo.Enabled = True
        ToolStrip1.Enabled = True
        GrupoTabla.Enabled = True
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
            BloquearControladores()

            Dim obj As New coControlLoteDestete With {
               .IdLote = CmbLotes.Value
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub CmbLotes_ValueChanged(sender As Object, e As EventArgs) Handles CmbLotes.ValueChanged
        Consultar()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlLoteDestete = CType(e.Argument, coControlLoteDestete)
            e.Result = cn.Cn_GruposLoteDestete(obj).Copy
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
            Exit Sub
        End If

        DesbloquearControladores()
        Dim ds As DataSet = CType(e.Result, DataSet)

        If ds.Tables.Count >= 2 AndAlso ds.Tables(0).Rows.Count > 0 Then
            DtDetalle.Clear()
            For Each fila As DataRow In ds.Tables(0).Rows
                Dim nuevaFila As DataRow = DtDetalle.NewRow
                nuevaFila(0) = fila("idGrupo")
                nuevaFila(1) = fila("Total Lechones")
                nuevaFila(2) = "" ' ¿Este campo es necesario? Considera nombrarlo.
                DtDetalle.Rows.Add(nuevaFila)
            Next

            DtgConsolidadEdad.DataSource = DtDetalle

            LblEdad.Text = ds.Tables(1).Rows(0).Item("EdadLote").ToString()
            LblTotalLechones.Text = ds.Tables(1).Rows(0).Item("TotalLechones").ToString()
        Else
            LblEdad.Text = "0"
            LblTotalLechones.Text = "0"
            DtgConsolidadEdad.DataSource = Nothing
        End If
    End Sub

    Private Sub DtgConsolidadEdad_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles DtgConsolidadEdad.InitializeLayout
        Try
            clsBasicas.Formato_Tablas_Grid(DtgConsolidadEdad)
            With e.Layout.Bands(0)
                .Columns(0).Hidden = True
                .Columns(1).Header.Caption = "Total Lechones"
                .Columns(2).Header.Caption = "Eliminar"
                .Columns(2).Width = 60
                .Columns(2).Style = UltraWinGrid.ColumnStyle.Button
                .Columns(2).CellButtonAppearance.Image = My.Resources.ico_eliminar
                .Columns(2).CellButtonAppearance.ImageHAlign = Infragistics.Win.HAlign.Center
                .Columns(2).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub DtgConsolidadEdad_ClickCellButton(sender As Object, e As UltraWinGrid.CellEventArgs) Handles DtgConsolidadEdad.ClickCellButton
        If e.Cell.Column.Key = "btnEliminar" Then
            Dim result As DialogResult = MessageBox.Show("¿ESTÁ SEGURO DE ELIMINAR ESTE REGISTRO?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                Dim rowIndex As Integer = e.Cell.Row.Index
                DtDetalle.Rows.RemoveAt(rowIndex)
                DtDetalle.AcceptChanges()
                DtgConsolidadEdad.DataSource = DtDetalle
            End If
        End If
    End Sub

    Private Sub btnIngresarGrupo_Click(sender As Object, e As EventArgs) Handles btnIngresarGrupo.Click
        Try
            Dim sumaLechones As Integer = ObtenerSumaLechones()
            If CInt(TxtCantidadAnimales.Text) = 0 Then
                msj_advert("Por Favor Ingrese una cantidad válida")
                TxtCantidadAnimales.Select()
                Return
            ElseIf CInt(TxtCantidadAnimales.Text) = 0 Then
                msj_advert("Por Favor Ingrese una cantidad diferente de cero")
                TxtCantidadAnimales.Select()
                Return
            ElseIf CInt(LblTotalLechones.Text) < (sumaLechones + CInt(TxtCantidadAnimales.Text)) Then
                msj_advert("la cantidad de animales por grupo no debe ser mayor al total de destetados")
                Return
            Else
                Dim dr As DataRow = DtDetalle.NewRow
                dr(0) = 0
                dr(1) = CInt(TxtCantidadAnimales.Text)
                DtDetalle.Rows.Add(dr)
                DtDetalle.AcceptChanges()
                DtgConsolidadEdad.DataSource = DtDetalle
                DtgConsolidadEdad.DataBind()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TxtCantidadAnimales_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCantidadAnimales.KeyPress
        clsBasicas.ValidarNumeros(e)
    End Sub

    Private Function ObtenerSumaLechones() As Integer
        Dim sumaLechones As Integer = 0
        For Each fila As DataRow In DtDetalle.Rows
            If Not IsDBNull(fila("cantidadAnimales")) Then
                sumaLechones += CInt(fila("cantidadAnimales"))
            End If
        Next
        Return sumaLechones
    End Function

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            Dim sumaLechones As Integer = ObtenerSumaLechones()

            If DtgConsolidadEdad.Rows.Count = 0 Then
                msj_advert("Debe ingresar al menos un registro")
                Return
            End If

            If sumaLechones > CInt(LblTotalLechones.Text) Then
                msj_advert("tiene que distribuir todos los animales en sus respectivos grupos")
                Return
            End If

            If sumaLechones <> CInt(LblTotalLechones.Text) Then
                msj_advert("Se debe distribuir todas las crías en sus grupos respectivos")
                Return
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE REGISTRAR ESTOS GRUPOS?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coControlLoteDestete With {
                .IdLote = CmbLotes.Value,
                .IdPlantel = idPlantel,
                .ListaItems = CreacionArrayGrupos()
            }

            Dim MensajeBgWk As String = cn.Cn_RegistrarGrupos(obj)
            If (obj.Coderror = 0) Then
                msj_ok(MensajeBgWk)
                LblTotalLechones.Text = "0"
                Consultar()
            Else
                msj_advert(MensajeBgWk)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Function CreacionArrayGrupos() As String
        Dim array_valvulas As String = ""
        If (DtgConsolidadEdad.Rows.Count = 0) Then
            array_valvulas = "0"
        Else
            For i = 0 To DtgConsolidadEdad.Rows.Count - 1
                If (DtgConsolidadEdad.Rows(i).Cells(0).Value.ToString.Trim.Length <> 0) Then
                    With DtgConsolidadEdad.Rows(i)
                        array_valvulas = array_valvulas & .Cells("idGrupo").Value.ToString.Trim & "+" &
                            .Cells("cantidadAnimales").Value.ToString.Trim & ","
                    End With
                End If
            Next
            array_valvulas = array_valvulas.Substring(0, array_valvulas.Length - 1)
        End If
        Return array_valvulas
    End Function

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class