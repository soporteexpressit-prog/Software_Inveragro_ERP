Imports CapaDatos
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmMantPlanSanitario
    Dim cn As New cnControlMedico
    Dim codMedicacion As Integer = 0
    Dim codEnfermedad As Integer = 0
    Public idProtocolo As Integer = 0
    Public estado As String = ""
    Private DtDetalleMedicacion As New DataTable("TempDetMedicamento")

    Private Sub FrmMantPlanSanitario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ListarAreas()
            CmbEstado.SelectedIndex = 0
            DtpFechaProtocolo.Value = Now.Date
            TxtEnfermedad.ReadOnly = True
            TxtMedicamento.ReadOnly = True
            CbxAplicacion.Checked = False
            LblNumAplicacion.Visible = False
            NumAplicacion.Visible = False
            CargarTablaDetalleMedicacion()
            clsBasicas.Formato_Tablas_Grid(DtgDetalleMedicacion)
            If idProtocolo <> 0 Then
                ConsultarxId()
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
        With cmbArea
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Sub ConsultarxId()
        Try
            Dim obj As New coControlMedico With {
                .Codigo = idProtocolo
            }
            Dim ds As New DataSet
            ds = cn.Cn_ConsultarProtocoloSanitarioxId(obj).Copy
            If (ds.Tables(0).Rows.Count > 0) Then
                TxtNotaGeneral.Text = ds.Tables(0).Rows(0)("nota").ToString
                CmbEstado.Text = ds.Tables(0).Rows(0)("estado").ToString
                cmbArea.Value = ds.Tables(0).Rows(0)("idArea")
                DtpFechaProtocolo.Value = ds.Tables(0).Rows(0)("fControl")
            End If

            If (ds.Tables(1).Rows.Count > 0) Then
                For i = 0 To ds.Tables(1).Rows.Count - 1
                    Dim dr As DataRow = DtDetalleMedicacion.NewRow
                    dr(0) = ds.Tables(1).Rows(i)("idEnfermedad")
                    dr(1) = ds.Tables(1).Rows(i)("idProducto")
                    dr(2) = ds.Tables(1).Rows(i)("enfermedad")
                    dr(3) = ds.Tables(1).Rows(i)("medicamento")
                    dr(4) = ds.Tables(1).Rows(i)("nota")
                    dr(5) = ds.Tables(1).Rows(i)("edadLote")
                    dr(6) = ds.Tables(1).Rows(i)("numAplicacion")
                    dr(7) = ""
                    DtDetalleMedicacion.Rows.Add(dr)
                Next
                DtgDetalleMedicacion.DataSource = DtDetalleMedicacion
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub CargarTablaDetalleMedicacion()
        DtDetalleMedicacion = New DataTable("TempDetMedicamento")
        DtDetalleMedicacion.Columns.Add("idEnfermedad", GetType(Integer))
        DtDetalleMedicacion.Columns.Add("idProducto", GetType(Integer))
        DtDetalleMedicacion.Columns.Add("enfermedad", GetType(String))
        DtDetalleMedicacion.Columns.Add("producto", GetType(String))
        DtDetalleMedicacion.Columns.Add("nota", GetType(String))
        DtDetalleMedicacion.Columns.Add("edadLote", GetType(Integer))
        DtDetalleMedicacion.Columns.Add("numAplicacion", GetType(String))
        DtDetalleMedicacion.Columns.Add("btneliminar", GetType(String))
        DtgDetalleMedicacion.DataSource = DtDetalleMedicacion
    End Sub

    Private Sub BtnBuscarEnfermedad_Click(sender As Object, e As EventArgs) Handles BtnBuscarEnfermedad.Click
        Try
            Dim f As New FrmListarEnfermedadCerdoPs(Me)
            f.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Public Sub LlenarCamposEnfermedad(codigo As Integer, descripcion As String)
        codEnfermedad = codigo
        TxtEnfermedad.Text = descripcion
    End Sub

    Private Sub BtnAgregarMedicamento_Click(sender As Object, e As EventArgs) Handles BtnAgregarMedicamento.Click
        Try
            Dim f As New FrmListarMedicamentoCerdoPs(Me) With {
                .idPlantel = 6
            }
            f.ShowDialog()

            If codMedicacion <> 0 Then
                ConsultarxIdMedicamento()
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Public Sub LlenarCamposMedicamentoRacion(codigo As Integer, descripcion As String)
        codMedicacion = codigo
        TxtMedicamento.Text = descripcion
    End Sub

    Sub ConsultarxIdMedicamento()
        Try
            Dim ultimoProveedor As String = ""
            Dim costo As Decimal = 0
            Dim unidad As String = ""
            Dim texto As String = ""

            Dim obj As New coControlMedico With {
                .IdMedicamento = codMedicacion
            }

            Dim dt As New DataTable
            dt = cn.Cn_ConsultarMedicamentoxId(obj).Copy
            If (dt.Rows.Count > 0) Then
                ultimoProveedor = If(IsDBNull(dt.Rows(0)("Último Proveedor")), "", dt.Rows(0)("Último Proveedor").ToString())
                costo = If(IsDBNull(dt.Rows(0)("Último Precio Compra")), 0, dt.Rows(0)("Último Precio Compra").ToString())
                unidad = If(IsDBNull(dt.Rows(0)("Unidad Medida")), "", dt.Rows(0)("Unidad Medida").ToString())
            End If

            'armamos el texto
            texto = "El último proveedor es " & ultimoProveedor & " el precio de compra es " & costo.ToString("C2") & " por " & unidad.ToString

            TxtObservacion.Text = texto
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            If DtpFechaProtocolo.Value > Now.Date Then
                msj_advert("La fecha del protocolo sanitario no puede ser mayor a la fecha actual")
                DtpFechaProtocolo.Focus()
                Exit Sub
            End If

            If DtgDetalleMedicacion.Rows.Count = 0 Then
                msj_advert("No se ha agregado ningún registro sanitario")
                Return
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE REGISTRAR PROTOCOLO SANITARIO?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coControlMedico With {
                .Operacion = If(idProtocolo = 0, 0, 1),
                .Codigo = idProtocolo,
                .Observacion = TxtNotaGeneral.Text,
                .Estado = CmbEstado.Text,
                .IdArea = cmbArea.Value,
                .IdUsuario = VP_IdUser,
                .ListaMedicamentoEnfermedad = CreacionArrayProductoMedicamento(),
                .FechaControl = DtpFechaProtocolo.Value
            }

            Dim _mensaje As String = cn.Cn_RegistrarProtocoloSanidad(obj)
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

    Function CreacionArrayProductoMedicamento() As String
        Dim array_valvulas As String = ""
        Dim numAplicacion As String = ""

        If (DtgDetalleMedicacion.Rows.Count = 0) Then
            array_valvulas = "0"
        Else
            For i = 0 To DtgDetalleMedicacion.Rows.Count - 1
                If (DtgDetalleMedicacion.Rows(i).Cells("numAplicacion").Value.ToString.Trim = "-") Then
                    numAplicacion = 0
                Else
                    numAplicacion = DtgDetalleMedicacion.Rows(i).Cells("numAplicacion").Value.ToString.Trim
                End If

                If (DtgDetalleMedicacion.Rows(i).Cells(0).Value.ToString.Trim.Length <> 0) Then
                    With DtgDetalleMedicacion.Rows(i)
                        array_valvulas = array_valvulas & .Cells("idEnfermedad").Value.ToString.Trim & "+" &
                            .Cells("idProducto").Value.ToString.Trim & "+" &
                            .Cells("nota").Value.ToString.Trim & "+" &
                            .Cells("edadLote").Value.ToString.Trim & "+" &
                            numAplicacion & ","
                    End With
                End If
            Next
            array_valvulas = array_valvulas.Substring(0, array_valvulas.Length - 1)
        End If
        Return array_valvulas
    End Function

    Private Sub DtgConsolidadEdad_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles DtgDetalleMedicacion.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(0).Hidden = True
                .Columns(1).Hidden = True
                .Columns(2).Header.Caption = "Enfermedad"
                .Columns(3).Header.Caption = "Medicación"
                .Columns(4).Header.Caption = "Nota"
                .Columns(5).Header.Caption = "Edad Lote"
                .Columns(6).Header.Caption = "# Aplicación"
                .Columns(7).Header.Caption = "Eliminar"
                .Columns(7).Width = 60
                .Columns(7).Style = UltraWinGrid.ColumnStyle.Button
                .Columns(7).CellButtonAppearance.Image = My.Resources.ico_eliminar
                .Columns(7).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnAgregar_Click(sender As Object, e As EventArgs) Handles BtnAgregar.Click
        Try
            If codEnfermedad = 0 Then
                msj_advert("Seleccione una Enfermedad")
                Return
            ElseIf codMedicacion = 0 Then
                msj_advert("Seleccione una Medicación")
                Return
            ElseIf String.IsNullOrWhiteSpace(TxtObservacion.Text) Then
                msj_advert("Por Favor Ingrese la Cantidad")
                Return
            ElseIf NumEdadLote.Value = 0 Then
                msj_advert("Ingrese la edad del lote")
                Return
            Else
                If CbxAplicacion.Checked Then
                    If NumAplicacion.Value = 0 Then
                        msj_advert("Ingrese el número de aplicación")
                        Return
                    End If

                    Dim existeProducto = DtDetalleMedicacion.Select("idEnfermedad= " & codEnfermedad & " AND idProducto=" & codMedicacion & " AND numAplicacion=" & NumAplicacion.Value)
                    If existeProducto.Length > 0 Then
                        msj_advert("La aplicación de este medicamento ya existe")
                        Return
                    End If

                End If

                Dim dr As DataRow = DtDetalleMedicacion.NewRow
                dr(0) = codEnfermedad
                dr(1) = codMedicacion
                dr(2) = TxtEnfermedad.Text
                dr(3) = TxtMedicamento.Text
                dr(4) = TxtObservacion.Text
                dr(5) = NumEdadLote.Value
                dr(6) = If(CbxAplicacion.Checked, NumAplicacion.Value, "-")
                DtDetalleMedicacion.Rows.Add(dr)
                DtDetalleMedicacion.AcceptChanges()
                DtgDetalleMedicacion.DataSource = DtDetalleMedicacion
                DtgDetalleMedicacion.DataBind()
                DtDetalleMedicacion.DefaultView.Sort = "edadLote ASC"

                LimpiarCampos()
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub LimpiarCampos()
        codMedicacion = 0
        codEnfermedad = 0
        TxtEnfermedad.Text = ""
        TxtMedicamento.Text = ""
        TxtObservacion.Text = ""
        NumAplicacion.Value = 0
        NumEdadLote.Value = 0
        CbxAplicacion.Checked = False
        LblNumAplicacion.Visible = False
        NumAplicacion.Visible = False
    End Sub

    Private Sub DtgDetalleMedicacion_ClickCellButton(sender As Object, e As UltraWinGrid.CellEventArgs) Handles DtgDetalleMedicacion.ClickCellButton
        If e.Cell.Column.Key = "btneliminar" Then
            Dim result As DialogResult = MessageBox.Show("¿ESTÁ SEGURO DE ELIMINAR ESTE REGISTRO?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                Dim rowIndex As Integer = e.Cell.Row.Index
                DtDetalleMedicacion.Rows.RemoveAt(rowIndex)
                DtDetalleMedicacion.AcceptChanges()
                DtgDetalleMedicacion.DataSource = DtDetalleMedicacion
            End If
        End If
    End Sub

    Private Sub TxtObservacion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtObservacion.KeyPress
        If e.KeyChar = "+"c Or e.KeyChar = ","c Then
            e.Handled = True
        End If
    End Sub

    Private Sub CbxAplicacion_CheckedChanged(sender As Object, e As EventArgs) Handles CbxAplicacion.CheckedChanged
        If CbxAplicacion.Checked Then
            LblNumAplicacion.Visible = True
            NumAplicacion.Visible = True
        Else
            LblNumAplicacion.Visible = False
            NumAplicacion.Visible = False
        End If
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class