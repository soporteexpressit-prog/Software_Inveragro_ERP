Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmRegistrarInseminacion
    Dim cn As New cnControlGestacion
    Dim operacion As Integer = 0
    Dim idMaterialGenetico As Integer = 0
    Dim idInseminador As Integer = 0
    Private DtDetalle As New DataTable("TempDetInseminacion")
    Public idPlantel As Integer = 0
    Public idCerda As Integer = 0
    Public idServicio As Integer = 0

    Private Sub FrmRegistrarInseminacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Inicializar()
        operacion = If(idServicio = 0, 0, 1)
        If idServicio = 0 Then
            ConsultarInicializarDiccionario()
        Else
            NoMostrarCandados()
            DtpFechaMonta.Value = VariablesGlobales.ParametrosInseminacion("fMonta")
            LblSeleccionarCerda.Visible = False
            BtnBuscarCerda.Visible = False
            ConsultarxIdServicio()
        End If
    End Sub

    Private Sub Inicializar()
        TxtVerraco.ReadOnly = True
        CmbViaAplicacion.SelectedIndex = 0
        TxtNombreEncargado.ReadOnly = True
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        CargarTablaDetalleServicio()
    End Sub

    Private Sub NoMostrarCandados()
        BtnBloquearFecha.Visible = False
        BtnBloquearCantExpulsada.Visible = False
        BtnBloquearVia.Visible = False
        BtnBloquearEncargado.Visible = False
        BtnBloquearMateGene.Visible = False
    End Sub

    Sub ConsultarxIdServicio()
        Try
            Dim obj As New coControlGestacion With {
                .IdControlFicha = idServicio
            }
            Dim ds As New DataSet
            ds = cn.Cn_ConsultarInseminacionxIdServicio(obj).Copy
            If (ds.Tables(0).Rows.Count > 0) Then
                idCerda = ds.Tables(0).Rows(0)("idAnimal").ToString
                LblCodArete.Text = ds.Tables(0).Rows(0)("codCerdo").ToString
                TxtCondCorporal.Text = ds.Tables(0).Rows(0)("condCorporal").ToString
            End If

            If (ds.Tables(1).Rows.Count > 0) Then
                For i = 0 To ds.Tables(1).Rows.Count - 1
                    Dim dr As DataRow = DtDetalle.NewRow
                    dr(0) = ds.Tables(1).Rows(i)("idMaterialGenetico")
                    dr(1) = ds.Tables(1).Rows(i)("idPersona")
                    dr(2) = ds.Tables(1).Rows(i)("codSemen")
                    dr(3) = Convert.ToDateTime(ds.Tables(1).Rows(i)("fMonta")).ToString("dd/MM/yyyy")
                    dr(4) = ds.Tables(1).Rows(i)("numDosis")
                    dr(5) = ds.Tables(1).Rows(i)("via")
                    dr(6) = ds.Tables(1).Rows(i)("cantExpulsada")
                    dr(7) = ds.Tables(1).Rows(i)("inseminador")
                    dr(8) = ""
                    dr(9) = ds.Tables(1).Rows(i)("eliminar")
                    DtDetalle.Rows.Add(dr)
                Next
                dtgListado.DataSource = DtDetalle
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ConsultarInicializarDiccionario()
        DtpFechaMonta.Value = VariablesGlobales.ParametrosInseminacion("fMonta")
        DtpFechaMonta.Enabled = If(VariablesGlobales.ParametrosInseminacion("fMontaBloqueo") = 1, False, True)
        TxtCantExpulsada.Text = VariablesGlobales.ParametrosInseminacion("cantExpulsada")
        TxtCantExpulsada.Enabled = If(VariablesGlobales.ParametrosInseminacion("cantExpulsadaBloqueo") = 1, False, True)
        CmbViaAplicacion.Text = VariablesGlobales.ParametrosInseminacion("via")
        CmbViaAplicacion.Enabled = If(VariablesGlobales.ParametrosInseminacion("viaBloqueo") = 1, False, True)

        If VariablesGlobales.ParametrosInseminacion("inseminadorBloqueo") = 1 Then
            idInseminador = VariablesGlobales.ParametrosInseminacion("idInseminador")
            TxtNombreEncargado.Text = VariablesGlobales.ParametrosInseminacion("valorNombre")
            BtnEncargado.Enabled = False
        End If
    End Sub

    Public Sub LlenarCamposMaterialGenetico(id As Integer, codVerraco As String, dosisDisponible As Integer)
        idMaterialGenetico = id
        TxtVerraco.Text = codVerraco
        LblDosisDisponibles.Text = CalcularDosisRestante(id, dosisDisponible)
    End Sub

    Private Function CalcularDosisRestante(idMaterial As Integer, dosisDisponible As Integer) As Integer
        Dim dosisUsadas As Integer = 0

        If DtDetalle IsNot Nothing AndAlso DtDetalle.Rows.Count > 0 Then
            dosisUsadas = DtDetalle.AsEnumerable().
        Where(Function(row) row.Field(Of Integer)("idMaterialGenetico") = idMaterial AndAlso
                           row.Field(Of Integer)("eliminar") = 1).
        Sum(Function(row) row.Field(Of Integer)("numDosis"))
        End If

        Dim dosisRestante As Integer = dosisDisponible - dosisUsadas
        If dosisRestante < 0 Then dosisRestante = 0

        Return dosisRestante
    End Function

    Sub CargarTablaDetalleServicio()
        DtDetalle = New DataTable("TempDetInseminacion")
        DtDetalle.Columns.Add("idMaterialGenetico", GetType(Integer))
        DtDetalle.Columns.Add("idInseminador", GetType(Integer))
        DtDetalle.Columns.Add("codSemen", GetType(String))
        DtDetalle.Columns.Add("fecha", GetType(String))
        DtDetalle.Columns.Add("numDosis", GetType(Integer))
        DtDetalle.Columns.Add("via", GetType(String))
        DtDetalle.Columns.Add("cantExpulsada", GetType(String))
        DtDetalle.Columns.Add("Inseminador", GetType(String))
        DtDetalle.Columns.Add("btneliminar", GetType(String))
        DtDetalle.Columns.Add("eliminar", GetType(Integer))
        dtgListado.DataSource = DtDetalle
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(0).Hidden = True
                .Columns(1).Hidden = True
                .Columns(2).Header.Caption = "Semen"
                .Columns(3).Header.Caption = "Fecha"
                .Columns(4).Header.Caption = "Cantidad"
                .Columns(5).Header.Caption = "Vía"
                .Columns(6).Header.Caption = "Cant. Expulsada"
                .Columns(7).Header.Caption = "Inseminador"
                .Columns(8).Header.Caption = "Eliminar"
                .Columns(8).Width = 60
                .Columns(8).Style = UltraWinGrid.ColumnStyle.Button
                .Columns(8).CellButtonAppearance.Image = My.Resources.ico_eliminar
                .Columns(8).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
                .Columns(9).Hidden = True
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnBuscarMG_Click(sender As Object, e As EventArgs) Handles BtnBuscarMG.Click
        Dim frm As New FrmListarMaterialGenetico(Me) With {
            .idPlantel = idPlantel
        }
        frm.ShowDialog()
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            If (TxtCantExpulsada.Text.Length = 0) Then
                msj_advert("Ingrese Cantidad Expulsada")
                Return
            ElseIf (CDec(TxtCantExpulsada.Text) <= 0) Then
                msj_advert("Ingrese Cantidad Expulsada mayor a 0")
                Return
            ElseIf (NumDosisInseminar.Value = 0) Then
                msj_advert("Ingrese Número dosis para inseminar")
                Return
            ElseIf (NumDosisInseminar.Value <= 0) Then
                msj_advert("Ingrese Número dosis para inseminar mayor a 0")
                Return
            ElseIf (idCerda = 0) Then
                msj_advert("Seleccione una Cerda")
                Return
            ElseIf (TxtCondCorporal.Text.Length = 0) Then
                msj_advert("Ingrese la condición corporal")
                Return
            ElseIf (CDec(TxtCondCorporal.Text) <= 0) Then
                msj_advert("la condición corporal debe ser mayor a cero")
                Return
            End If

            If (dtgListado.Rows.Count = 0) Then
                msj_advert("Debe agregar al menos un servicio de inseminación")
                Return
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE REGISTRAR INSEMINACIÓN?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coControlGestacion With {
                .Operacion = operacion,
                .IdControlFicha = idServicio,
                .IdUsuario = VP_IdUser,
                .IdCerda = idCerda,
                .CodCorporal = CDec(TxtCondCorporal.Text),
                .ListaServicios = CreacionStringServicio(),
                .Peso = If(TxtPeso.Text.Trim().Length = 0, 0, CDec(TxtPeso.Text.Trim()))
            }

            Dim mensaje As String = cn.Cn_RegistrarInseminacion(obj)

            If (obj.Coderror = 0) Then
                msj_ok(mensaje)
                If (idServicio = 0 Or operacion = 0) Then
                    LimpiarCampo()
                    ConsultarInicializarDiccionario()
                Else
                    Dispose()
                End If
            Else
                msj_advert(mensaje)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub LimpiarCampo()
        idCerda = 0
        LblCodArete.Text = "-"
        TxtCondCorporal.Text = ""
        If BtnBuscarMG.Enabled Then
            idMaterialGenetico = 0
            TxtVerraco.Text = ""
            LblDosisDisponibles.Text = "0"
        End If
        idInseminador = 0
        TxtNombreEncargado.Text = ""
        TxtPeso.Text = "0"
        If DtDetalle IsNot Nothing Then
            DtDetalle.Clear()
            dtgListado.DataSource = DtDetalle
        End If
    End Sub

    Function CreacionStringServicio() As String
        Dim array_valvulas As String = ""
        If (dtgListado.Rows.Count = 0) Then
            array_valvulas = ""
        Else
            For i = 0 To dtgListado.Rows.Count - 1
                If (dtgListado.Rows(i).Cells(0).Value.ToString.Trim.Length <> 0) Then
                    Dim incluirRegistro As Boolean = False

                    If operacion = 0 Then
                        If dtgListado.Rows(i).Cells("eliminar").Value IsNot Nothing AndAlso
                       Convert.ToInt32(dtgListado.Rows(i).Cells("eliminar").Value) = 1 Then
                            incluirRegistro = True
                        End If
                    ElseIf operacion = 1 Then
                        incluirRegistro = True
                    End If

                    If incluirRegistro Then
                        With dtgListado.Rows(i)
                            array_valvulas = array_valvulas & .Cells("idMaterialGenetico").Value.ToString.Trim & "+" &
                            .Cells("idInseminador").Value.ToString.Trim & "+" &
                            .Cells("fecha").Value.ToString.Trim & "+" &
                            .Cells("numDosis").Value.ToString.Trim & "+" &
                            .Cells("via").Value.ToString.Trim & "+" &
                            .Cells("cantExpulsada").Value.ToString.Trim & ","
                        End With
                    End If
                End If
            Next

            If array_valvulas.Length > 0 Then
                array_valvulas = array_valvulas.Substring(0, array_valvulas.Length - 1)
            End If
        End If
        Return array_valvulas
    End Function

    Private Sub TxtCantExpulsada_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCantExpulsada.KeyPress
        clsBasicas.ValidarNumeros(e)
    End Sub

    Private Sub NumDosisInseminar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles NumDosisInseminar.KeyPress
        clsBasicas.ValidarNumeros(e)
    End Sub

    Private Sub TxtCondCorporal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCondCorporal.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Public Sub LlenarCamposInseminador(codigo As Integer, numDocumento As String, datos As String)
        idInseminador = codigo
        TxtNombreEncargado.Text = datos
    End Sub

    Private Sub BtnEncargado_Click(sender As Object, e As EventArgs) Handles BtnEncargado.Click
        Try
            Dim frm As New FrmListarEncargadoInseminacion(Me)
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnBuscarCerda_Click(sender As Object, e As EventArgs) Handles BtnBuscarCerda.Click
        Try
            Dim frm As New FrmListarCerdasInseminar(Me) With {
                .idUbicacion = idPlantel
            }
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnAgregarServicio_Click(sender As Object, e As EventArgs) Handles BtnAgregarServicio.Click
        Try
            If DtpFechaMonta.Value > Now.Date Then
                msj_advert("La fecha de inseminación no puede ser mayor a la fecha actual.")
                Return
            End If

            If (DtDetalle.Rows.Count >= 3) Then
                msj_advert("No puede agregar más de 3 servicios")
                Return
            End If

            If (idMaterialGenetico = 0) Then
                msj_advert("Seleccione un Material Genético")
                Return
            ElseIf (TxtCantExpulsada.Text.Length = 0) Then
                msj_advert("Ingrese Cantidad Expulsada")
                Return
            ElseIf (CDec(TxtCantExpulsada.Text) <= 0) Then
                msj_advert("Ingrese Cantidad Expulsada mayor a 0")
                Return
            ElseIf (NumDosisInseminar.Value = 0) Then
                msj_advert("Ingrese Número dosis para inseminar")
                Return
            ElseIf (NumDosisInseminar.Value <= 0) Then
                msj_advert("Ingrese Número dosis para inseminar mayor a 0")
                Return
            ElseIf (idInseminador = 0) Then
                msj_advert("Seleccione un Inseminador")
                Return
            End If

            If (NumDosisInseminar.Value > CInt(LblDosisDisponibles.Text)) Then
                msj_advert("Número de dosis para inseminar no puede ser mayor a las dosis disponibles")
                Return
            End If

            LblDosisDisponibles.Text = CInt(LblDosisDisponibles.Text) - NumDosisInseminar.Value

            Dim dr As DataRow = DtDetalle.NewRow()
            dr(0) = idMaterialGenetico
            dr(1) = idInseminador
            dr(2) = TxtVerraco.Text.Trim()
            dr(3) = DtpFechaMonta.Value.ToString("dd/MM/yyyy")
            dr(4) = NumDosisInseminar.Value
            dr(5) = CmbViaAplicacion.Text.Trim()
            dr(6) = TxtCantExpulsada.Text.Trim()
            dr(7) = TxtNombreEncargado.Text.Trim()
            dr(8) = ""
            dr(9) = 1 ' Indica que este registro puede ser eliminado
            DtDetalle.Rows.Add(dr)
            dtgListado.DataSource = DtDetalle
            dtgListado.DataBind()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Public Sub LlenarCamposCerdaInseminar(codigo As Integer, datos As String, condCorporal As Decimal, idControlFicha As Integer)
        idCerda = codigo
        LblCodArete.Text = datos
        TxtCondCorporal.Text = condCorporal
        idServicio = idControlFicha

        CargarTablaDetalleServicio()

        If idServicio <> 0 Then
            ConsultarxIdServicio()
        End If
    End Sub

    Private Sub dtgListado_ClickCellButton(sender As Object, e As UltraWinGrid.CellEventArgs) Handles dtgListado.ClickCellButton
        If e.Cell.Column.Key = "btneliminar" Then
            Dim eliminar As Integer = CInt(e.Cell.Row.Cells("eliminar").Value)

            If eliminar = 0 And operacion = 0 Then
                msj_advert("Este registro no se puede eliminar, vaya al apartado de editar.")
                Return
            End If

            Dim result As DialogResult = MessageBox.Show("¿ESTÁ SEGURO DE ELIMINAR ESTE REGISTRO?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                Dim idMaterial As Integer = CInt(e.Cell.Row.Cells("idMaterialGenetico").Value)
                Dim rowIndex As Integer = e.Cell.Row.Index

                DtDetalle.Rows.RemoveAt(rowIndex)
                DtDetalle.AcceptChanges()
                dtgListado.DataSource = DtDetalle

                If idMaterialGenetico = idMaterial Then
                    LblDosisDisponibles.Text = CInt(LblDosisDisponibles.Text) + 1
                End If
            End If
        End If
    End Sub

    Private Sub BtnBloquearFecha_Click(sender As Object, e As EventArgs) Handles BtnBloquearFecha.Click
        If CInt(VariablesGlobales.ParametrosInseminacion("fMontaBloqueo")) = 1 Then
            DtpFechaMonta.Enabled = True
            VariablesGlobales.ParametrosInseminacion("fMonta") = Now.Date
            VariablesGlobales.ParametrosInseminacion("fMontaBloqueo") = 0
        Else
            DtpFechaMonta.Enabled = False
            VariablesGlobales.ParametrosInseminacion("fMonta") = DtpFechaMonta.Value
            VariablesGlobales.ParametrosInseminacion("fMontaBloqueo") = 1
        End If
    End Sub

    Private Sub BtnBloquearCantExpulsada_Click(sender As Object, e As EventArgs) Handles BtnBloquearCantExpulsada.Click
        If CInt(VariablesGlobales.ParametrosInseminacion("cantExpulsadaBloqueo")) = 1 Then
            TxtCantExpulsada.Enabled = True
            VariablesGlobales.ParametrosInseminacion("cantExpulsada") = 3
            VariablesGlobales.ParametrosInseminacion("cantExpulsadaBloqueo") = 0
        Else
            TxtCantExpulsada.Enabled = False
            VariablesGlobales.ParametrosInseminacion("cantExpulsada") = CInt(TxtCantExpulsada.Text)
            VariablesGlobales.ParametrosInseminacion("cantExpulsadaBloqueo") = 1
        End If
    End Sub

    Private Sub BtnBloquearVia_Click(sender As Object, e As EventArgs) Handles BtnBloquearVia.Click
        If CInt(VariablesGlobales.ParametrosInseminacion("viaBloqueo")) = 1 Then
            CmbViaAplicacion.Enabled = True
            VariablesGlobales.ParametrosInseminacion("via") = "CERVICAL"
            VariablesGlobales.ParametrosInseminacion("viaBloqueo") = 0
        Else
            CmbViaAplicacion.Enabled = False
            VariablesGlobales.ParametrosInseminacion("via") = CmbViaAplicacion.Text
            VariablesGlobales.ParametrosInseminacion("viaBloqueo") = 1
        End If
    End Sub

    Private Sub BtnBloquearEncargado_Click(sender As Object, e As EventArgs) Handles BtnBloquearEncargado.Click
        If CInt(VariablesGlobales.ParametrosInseminacion("inseminadorBloqueo")) = 1 Then
            BtnEncargado.Enabled = True
            VariablesGlobales.ParametrosInseminacion("inseminadorBloqueo") = 0
        Else
            BtnEncargado.Enabled = False
            VariablesGlobales.ParametrosInseminacion("inseminadorBloqueo") = 1
        End If
        VariablesGlobales.ParametrosInseminacion("idInseminador") = idInseminador
        VariablesGlobales.ParametrosInseminacion("valorNombre") = TxtNombreEncargado.Text
    End Sub

    Private Sub TxtPeso_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtPeso.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub BtnBloquearMateGene_Click(sender As Object, e As EventArgs) Handles BtnBloquearMateGene.Click
        If BtnBuscarMG.Enabled Then
            BtnBuscarMG.Enabled = False
        Else
            BtnBuscarMG.Enabled = True
        End If
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class