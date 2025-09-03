Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports iText.Forms.Form.Element

Public Class FrmMantProgramaAlimentacion
    Dim cn As New cnControlFormulacion
    Private DtDetalleProgramaAlimentacion As New DataTable("TempDetProgAlimentacion")
    Dim idProducto As Integer
    Public idProgramaAlimentacion As Integer = 0

    Private Sub FrmMantProgramaAlimentacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            ListarAreas()
            CargarTablaProgAlimentacion()
            clsBasicas.Formato_Tablas_Grid(DtgDetalleProgramaAlimentacion)
            If idProgramaAlimentacion <> 0 Then
                ConsultarxId()
                LblDiasxFase.Visible = False
                NumDiasxFase.Visible = False
            Else
                CmbEstado.Enabled = False
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Inicializar()
        DtpFecha.Value = Now.Date
        CmbEstado.SelectedIndex = 0
        TxtRacion.ReadOnly = True
    End Sub

    Sub ConsultarxId()
        Try
            Dim obj As New coControlFormulacion With {
                .Codigo = idProgramaAlimentacion
            }
            Dim ds As New DataSet
            ds = cn.Cn_ConsultarProgramaAlimentacionxId(obj).Copy
            If (ds.Tables(0).Rows.Count > 0) Then
                TxtMotivo.Text = ds.Tables(0).Rows(0)("nota").ToString
                CmbEstado.Text = ds.Tables(0).Rows(0)("estado").ToString
                DtpFecha.Value = ds.Tables(0).Rows(0)("fecha")
            End If

            If (ds.Tables(1).Rows.Count > 0) Then
                For i = 0 To ds.Tables(1).Rows.Count - 1
                    Dim dr As DataRow = DtDetalleProgramaAlimentacion.NewRow
                    dr(0) = ds.Tables(1).Rows(i)("idProducto")
                    dr(1) = ds.Tables(1).Rows(i)("idArea")
                    dr(2) = ds.Tables(1).Rows(i)("Producto")
                    dr(3) = ds.Tables(1).Rows(i)("anti")
                    dr(4) = ds.Tables(1).Rows(i)("Area")
                    dr(5) = ds.Tables(1).Rows(i)("kgxCabeza")
                    dr(6) = ds.Tables(1).Rows(i)("diasxFase")
                    dr(7) = ds.Tables(1).Rows(i)("edadFinalFase")
                    dr(8) = ds.Tables(1).Rows(i)("pesoInicial")
                    dr(9) = ""
                    DtDetalleProgramaAlimentacion.Rows.Add(dr)
                Next
                DtgDetalleProgramaAlimentacion.DataSource = DtDetalleProgramaAlimentacion
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ListarAreas()
        Dim cn As New cnArea
        Dim tb As New DataTable
        tb = cn.Cn_Listar().Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione una Área"
        With CmbArea
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Private Sub TxtKgxCabeza_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtKgxCabeza.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Sub CargarTablaProgAlimentacion()
        DtDetalleProgramaAlimentacion = New DataTable("TempDetProgAlimentacion")
        DtDetalleProgramaAlimentacion.Columns.Add("idProducto", GetType(Integer))
        DtDetalleProgramaAlimentacion.Columns.Add("idArea", GetType(Integer))
        DtDetalleProgramaAlimentacion.Columns.Add("producto", GetType(String))
        DtDetalleProgramaAlimentacion.Columns.Add("anti", GetType(Integer))
        DtDetalleProgramaAlimentacion.Columns.Add("area", GetType(String))
        DtDetalleProgramaAlimentacion.Columns.Add("kgxCabeza", GetType(String))
        DtDetalleProgramaAlimentacion.Columns.Add("diasxFase", GetType(Integer))
        DtDetalleProgramaAlimentacion.Columns.Add("edadFinalFase", GetType(Integer))
        DtDetalleProgramaAlimentacion.Columns.Add("pesoInicial", GetType(String))
        DtDetalleProgramaAlimentacion.Columns.Add("btneliminar", GetType(String))
        DtgDetalleProgramaAlimentacion.DataSource = DtDetalleProgramaAlimentacion
    End Sub

    Private Sub DtgDetalleMedicacion_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles DtgDetalleProgramaAlimentacion.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(0).Hidden = True
                .Columns(1).Hidden = True
                .Columns(2).Header.Caption = "Alimento"
                .Columns(3).Hidden = True
                .Columns(4).Header.Caption = "Área"
                .Columns(5).Header.Caption = "KgxCabeza"
                .Columns(6).Header.Caption = "DíasxFase"
                .Columns(7).Header.Caption = "Edad Final Fase"
                .Columns(8).Header.Caption = "Peso Inicial"
                .Columns(9).Header.Caption = "Eliminar"
                .Columns(9).Style = UltraWinGrid.ColumnStyle.Button
                .Columns(9).CellButtonAppearance.Image = My.Resources.ico_eliminar
                .Columns(9).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnBuscarRacion_Click(sender As Object, e As EventArgs) Handles BtnBuscarRacion.Click
        Try
            Dim frm As New FrmListarRacionesCerdo(Me)
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Public Sub LlenarCamposRacion(codigo As Integer, descripcion As String)
        idProducto = codigo
        TxtRacion.Text = descripcion
    End Sub

    Private Sub BtnAgregar_Click(sender As Object, e As EventArgs) Handles BtnAgregar.Click
        Try
            If idProducto = 0 Then
                msj_advert("Seleccione una ración")
                Return
            ElseIf NumEdadFinalFase.Value = 0 Then
                msj_advert("Por Favor ingrese una edad final de fase válida")
                NumEdadFinalFase.Select()
                Return
            ElseIf String.IsNullOrWhiteSpace(TxtKgxCabeza.Text) Then
                msj_advert("Por Favor Ingrese la Cantidad")
                TxtKgxCabeza.Select()
                Return
            Else
                If DtDetalleProgramaAlimentacion.Rows.Count = 0 Then
                    If NumDiasxFase.Value = 0 Then
                        msj_advert("Por Favor ingrese una cantidad de días por fase válida")
                        NumDiasxFase.Select()
                        Return
                    End If
                Else
                    Dim minEdadFinalFase As Integer = Integer.MaxValue
                    For Each row As DataRow In DtDetalleProgramaAlimentacion.Rows
                        Dim edadFinalFase As Integer = Convert.ToInt32(row("edadFinalFase"))
                        If edadFinalFase < minEdadFinalFase Then
                            minEdadFinalFase = edadFinalFase
                        End If
                    Next

                    If DtDetalleProgramaAlimentacion.Rows.Count > 0 Then
                        If NumEdadFinalFase.Value <= minEdadFinalFase Then
                            msj_advert("La edad final de fase debe ser mayor a " & minEdadFinalFase.ToString())
                            NumEdadFinalFase.Select()
                            Return
                        End If
                    End If
                End If
                Dim dr As DataRow = DtDetalleProgramaAlimentacion.NewRow
                dr(0) = idProducto
                dr(1) = CmbArea.Value
                dr(2) = TxtRacion.Text.Trim & If(CbxAnti.Checked, " - ANTI", "")
                dr(3) = If(CbxAnti.Checked, 1, 0)
                dr(4) = CmbArea.Text.Trim
                dr(5) = CDbl(TxtKgxCabeza.Text.Trim).ToString(P_FormatoDecimales)
                If DtDetalleProgramaAlimentacion.Rows.Count = 0 Then
                    dr(6) = NumDiasxFase.Value
                Else
                    Dim ultimaEdadFinalFase As Integer = Convert.ToInt32(DtDetalleProgramaAlimentacion.Rows(DtDetalleProgramaAlimentacion.Rows.Count - 1)("edadFinalFase"))
                    Dim diasFase As Integer = NumEdadFinalFase.Value - ultimaEdadFinalFase
                    dr(6) = diasFase
                End If
                dr(7) = NumEdadFinalFase.Value
                dr(8) = TxtPesoInicial.Text.Trim
                DtDetalleProgramaAlimentacion.Rows.Add(dr)
                DtDetalleProgramaAlimentacion.AcceptChanges()

                DtDetalleProgramaAlimentacion.DefaultView.Sort = "edadFinalFase ASC"
                DtDetalleProgramaAlimentacion = DtDetalleProgramaAlimentacion.DefaultView.ToTable()

                ActualizarDiasPorFase()

                DtgDetalleProgramaAlimentacion.DataSource = DtDetalleProgramaAlimentacion
                DtgDetalleProgramaAlimentacion.DataBind()
                LimpiarCamposPrograma()
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ActualizarDiasPorFase()
        Dim edadAnterior As Integer = 0

        For i As Integer = 0 To DtDetalleProgramaAlimentacion.Rows.Count - 1
            Dim edadActual As Integer = Convert.ToInt32(DtDetalleProgramaAlimentacion.Rows(i)("edadFinalFase"))

            If i = 0 Then
                DtDetalleProgramaAlimentacion.Rows(i)("diasxFase") = edadActual
            Else
                DtDetalleProgramaAlimentacion.Rows(i)("diasxFase") = edadActual - edadAnterior
            End If

            edadAnterior = edadActual
        Next

        DtDetalleProgramaAlimentacion.AcceptChanges()
    End Sub

    Private Sub LimpiarCamposPrograma()
        idProducto = 0
        TxtRacion.Text = ""
        TxtKgxCabeza.Text = ""
        NumEdadFinalFase.Value = 0
        CbxAnti.Checked = False
        TxtPesoInicial.Text = ""
        VerificarVisibilidadDiasxFase()
    End Sub

    Private Sub VerificarVisibilidadDiasxFase()
        If DtDetalleProgramaAlimentacion.Rows.Count <> 0 Then
            LblDiasxFase.Visible = False
            NumDiasxFase.Visible = False
        Else
            LblDiasxFase.Visible = True
            NumDiasxFase.Visible = True
        End If
        NumDiasxFase.Value = 0
    End Sub

    Private Sub DtgDetalleProgramaAlimentacion_ClickCellButton(sender As Object, e As UltraWinGrid.CellEventArgs) Handles DtgDetalleProgramaAlimentacion.ClickCellButton
        If e.Cell.Column.Key = "btneliminar" Then
            Dim result As DialogResult = MessageBox.Show("¿ESTÁ SEGURO DE ELIMINAR ESTE REGISTRO?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                Dim rowIndex As Integer = e.Cell.Row.Index
                DtDetalleProgramaAlimentacion.Rows.RemoveAt(rowIndex)
                DtDetalleProgramaAlimentacion.AcceptChanges()
                DtgDetalleProgramaAlimentacion.DataSource = DtDetalleProgramaAlimentacion
                VerificarVisibilidadDiasxFase()
                actualizarDiasxFase()
            End If
        End If
    End Sub

    Private Sub actualizarDiasxFase()
        Try
            If DtDetalleProgramaAlimentacion.Rows.Count > 0 Then
                Dim edadAnterior As Integer = 0

                For i As Integer = 0 To DtDetalleProgramaAlimentacion.Rows.Count - 1
                    Dim fila As DataRow = DtDetalleProgramaAlimentacion.Rows(i)
                    Dim edadFinalActual As Integer = Convert.ToInt32(fila("edadFinalFase"))

                    If i <> 0 Then
                        Dim diasFase As Integer = edadFinalActual - edadAnterior
                        fila("diasxFase") = diasFase
                    End If

                    edadAnterior = edadFinalActual
                    DtDetalleProgramaAlimentacion.AcceptChanges()
                Next
            End If

            DtgDetalleProgramaAlimentacion.DataBind()
        Catch ex As Exception
            clsBasicas.controlException("VerificarVisibilidadDiasxFase", ex)
        End Try
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            If (String.IsNullOrWhiteSpace(TxtMotivo.Text)) Then
                msj_advert("Ingrese el motivo")
                TxtMotivo.Select()
                Return
            ElseIf (DtgDetalleProgramaAlimentacion.Rows.Count = 0) Then
                msj_advert("Ingrese al menos un registro en el programa de alimentación")
                Return
            Else
                Dim registroExiste = DtDetalleProgramaAlimentacion.Select("idProducto = " & idProducto & " AND idArea = " & CmbArea.Value & " AND anti = " & If(CbxAnti.Checked, 1, 0))
                If registroExiste.Length > 0 Then
                    msj_advert("El registro ya existe en la lista")
                    Return
                End If

                If (MessageBox.Show("¿ESTÁ SEGURO DE REGISTRAR ESTE PROGRAMA DE ALIMENTACIÓN?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                    Return
                End If

                Dim obj As New coControlFormulacion With {
                    .Operacion = If(idProgramaAlimentacion = 0, 0, 1),
                    .Codigo = idProgramaAlimentacion,
                    .FechaElaboracion = DtpFecha.Value,
                    .Descripcion = "PROGRAMA DE ALIMENTACIÓN" & " " & DtpFecha.Value.ToString("dd/MM/yyyy"),
                    .Motivo = TxtMotivo.Text,
                    .Iduser = VP_IdUser,
                    .ListaAsignacionRacion = CreacionArrayProgramaAlimentacion(),
                    .Estado = CmbEstado.Text
                }

                Dim MensajeBgWk As String = cn.Cn_MantenimientoProgramaAlimentacion(obj)
                If (obj.Coderror = 0) Then
                    msj_ok(MensajeBgWk)
                    Dispose()
                Else
                    msj_advert(MensajeBgWk)
                End If
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Function CreacionArrayProgramaAlimentacion() As String
        Dim array_valvulas As String = ""
        If (DtgDetalleProgramaAlimentacion.Rows.Count = 0) Then
            array_valvulas = "0"
        Else
            For i = 0 To DtgDetalleProgramaAlimentacion.Rows.Count - 1
                If (DtgDetalleProgramaAlimentacion.Rows(i).Cells(0).Value.ToString.Trim.Length <> 0) Then
                    With DtgDetalleProgramaAlimentacion.Rows(i)
                        array_valvulas = array_valvulas & .Cells("idProducto").Value.ToString.Trim & "+" &
                            .Cells("idArea").Value.ToString.Trim & "+" &
                            .Cells("kgxCabeza").Value.ToString.Trim & "+" &
                            .Cells("diasxFase").Value.ToString.Trim & "+" &
                            .Cells("edadFinalFase").Value.ToString.Trim & "+" &
                            .Cells("anti").Value.ToString.Trim & "+" &
                            .Cells("pesoInicial").Value.ToString.Trim & ","
                    End With
                End If
            Next
            array_valvulas = array_valvulas.Substring(0, array_valvulas.Length - 1)
        End If
        Return array_valvulas
    End Function

    Private Sub TxtPesoInicial_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtPesoInicial.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class