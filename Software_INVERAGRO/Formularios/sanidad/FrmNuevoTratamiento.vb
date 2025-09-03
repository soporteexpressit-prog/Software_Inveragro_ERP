Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmNuevoTratamiento
    Dim cn As New cnEnfermedad
    Private DtDetalleTratamiento As New DataTable("TempDetTratamiento")
    Dim codEnfermedad As Integer = 0
    Dim codProducto As Integer = 0

    Private Sub FrmNuevoTratamiento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            CargarTablaDetalleTratamiento()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        ChkOmitirEdad.Checked = False
        TxtEnfermedad.ReadOnly = True
        TxtProducto.ReadOnly = True
        txtObservacion.Text = "NINGUNA"
    End Sub

    Sub CargarTablaDetalleTratamiento()
        DtDetalleTratamiento = New DataTable("TempDetTratamiento")
        DtDetalleTratamiento.Columns.Add("codenfermedad", GetType(Integer))
        DtDetalleTratamiento.Columns.Add("codprod", GetType(Integer))
        DtDetalleTratamiento.Columns.Add("producto", GetType(String))
        DtDetalleTratamiento.Columns.Add("enfermedad", GetType(String))
        DtDetalleTratamiento.Columns.Add("edadlote", GetType(String))
        DtDetalleTratamiento.Columns.Add("observacion", GetType(String))
        DtDetalleTratamiento.Columns.Add("btneliminar", GetType(String))
        DtgDetalleTratamiento.DataSource = DtDetalleTratamiento
    End Sub

    Public Sub LlenarCamposEnfermedad(codigo As Integer, descripcion As String)
        codEnfermedad = codigo
        TxtEnfermedad.Text = descripcion
    End Sub

    Public Sub LlenarCamposProducto(codigo As Integer, descripcion As String)
        codProducto = codigo
        TxtProducto.Text = descripcion
    End Sub

    Private Sub DtgDetalleTratamiento_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles DtgDetalleTratamiento.InitializeLayout
        Try
            clsBasicas.Formato_Tablas_Grid(DtgDetalleTratamiento)
            With e.Layout.Bands(0)
                .Columns(0).Hidden = True
                .Columns(1).Hidden = True
                .Columns(2).Header.Caption = "Producto"
                .Columns(3).Header.Caption = "Enfermedad"
                .Columns(4).Header.Caption = "Edad Lote"
                .Columns(5).Header.Caption = "Observación"
                .Columns(6).Header.Caption = "Eliminar"
                .Columns(6).Style = UltraWinGrid.ColumnStyle.Button
                .Columns(6).CellButtonAppearance.Image = My.Resources.ico_eliminar
                .Columns(6).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnBuscarEnfermedad_Click(sender As Object, e As EventArgs) Handles BtnBuscarEnfermedad.Click
        Try
            Dim f As New FrmListarEnfermedadesCerdo(Me)
            f.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnBuscarProducto_Click(sender As Object, e As EventArgs) Handles btnBuscarProducto.Click
        Try
            Dim f As New FrmListarProductos(Me)
            f.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub


    Private Sub DtgListado_ClickCellButton(sender As Object, e As UltraWinGrid.CellEventArgs) Handles DtgDetalleTratamiento.ClickCellButton
        If e.Cell.Column.Key = "btneliminar" Then
            Dim result As DialogResult = MessageBox.Show("¿Está seguro de que desea eliminar este registro?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                Dim rowIndex As Integer = e.Cell.Row.Index
                Dim codParticipante As Integer = CInt(DtgDetalleTratamiento.Rows(rowIndex).Cells(0).Value)

                DtDetalleTratamiento.Rows.RemoveAt(rowIndex)
                DtDetalleTratamiento.AcceptChanges()
                DtgDetalleTratamiento.DataSource = DtDetalleTratamiento
            End If
        End If
    End Sub

    Private Sub LimpiarCamposDetalleTratamiento()
        codProducto = 0
        codEnfermedad = 0
        TxtProducto.Text = ""
        TxtEnfermedad.Text = ""
        TxtEdadLote.Text = ""
        txtObservacion.Text = "NINGUNA"
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            If DtDetalleTratamiento.Rows.Count = 0 Then
                msj_advert("Debe agregar al menos un producto especifico para la enfermedad deseada")
                Return
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE REGISTRAR EL DETALLE DEL TRATAMIENTO RECOMENDADO?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coEnfermedad With {
                .Lista_Detalle_Tratamiento = CreacionStringDetalleTratamiento(),
                .Iduser = VP_IdUser
            }

            Dim _mensaje As String = cn.Cn_RegistrarDetalleTratamiento(obj)
            If (obj.Coderror = 0) Then
                msj_ok(_mensaje)
                Dispose()
            Else
                msj_advert(_mensaje)
            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try

    End Sub

    Function CreacionStringDetalleTratamiento() As String
        Dim array_valvulas As String = ""
        If (DtgDetalleTratamiento.Rows.Count = 0) Then
            array_valvulas = "0"
        Else
            For i = 0 To DtgDetalleTratamiento.Rows.Count - 1
                If (DtgDetalleTratamiento.Rows(i).Cells(0).Value.ToString.Trim.Length <> 0) Then
                    With DtgDetalleTratamiento.Rows(i)
                        Dim edadLoteValue As String = .Cells("edadlote").Value.ToString.Trim
                        If edadLoteValue = "-" Then
                            edadLoteValue = "0"
                        End If

                        array_valvulas = array_valvulas & .Cells("codenfermedad").Value.ToString.Trim & "+" &
                       .Cells("codprod").Value.ToString.Trim & "+" &
                       edadLoteValue & "+" &
                       .Cells("observacion").Value.ToString.Trim & ","
                    End With
                End If
            Next
        End If
        Return array_valvulas
    End Function

    Private Sub ChkOmitirEdad_CheckedChanged(sender As Object, e As EventArgs) Handles ChkOmitirEdad.CheckedChanged
        If ChkOmitirEdad.Checked Then
            TxtEdadLote.ReadOnly = True
            TxtEdadLote.Text = "-"
        Else
            TxtEdadLote.ReadOnly = False
            TxtEdadLote.Text = ""
        End If
    End Sub

    Private Sub btnAñadir_Click(sender As Object, e As EventArgs) Handles btnAñadir.Click
        Try
            If codEnfermedad = 0 Then
                msj_advert("Seleccione una Enfermedad")
                Return
            ElseIf codProducto = 0 Then
                msj_advert("Seleccione un Producto")
                Return
            ElseIf txtObservacion.Text.Length = 0 Then
                msj_advert("Ingrese una observación")
                txtObservacion.Select()
                Return
            Else
                If Not ChkOmitirEdad.Checked Then
                    If TxtEdadLote.Text.Length = 0 Then
                        msj_advert("Ingrese la edad del lote")
                        TxtEdadLote.Select()
                        Return
                    ElseIf TxtEdadLote.Text = "0" Then
                        msj_advert("La edad del lote no puede ser 0")
                        TxtEdadLote.Select()
                        Return
                    End If
                End If

                Dim dr As DataRow = DtDetalleTratamiento.NewRow
                dr(0) = codEnfermedad
                dr(1) = codProducto
                dr(2) = TxtProducto.Text
                dr(3) = TxtEnfermedad.Text
                dr(4) = TxtEdadLote.Text
                dr(5) = txtObservacion.Text
                DtDetalleTratamiento.Rows.Add(dr)
                DtDetalleTratamiento.AcceptChanges()
                DtgDetalleTratamiento.DataSource = DtDetalleTratamiento
                DtgDetalleTratamiento.DataBind()

                LimpiarCamposDetalleTratamiento()
                End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class