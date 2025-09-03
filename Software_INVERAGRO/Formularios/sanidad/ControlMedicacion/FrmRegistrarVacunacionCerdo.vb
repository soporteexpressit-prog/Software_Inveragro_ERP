Imports CapaNegocio
Imports CapaObjetos

Public Class FrmRegistrarVacunacionCerdo
    Dim cnUnidadMedida As New cnUnidadMedida
    Dim cn As New cnControlMedico
    Dim cnProducto As New cnProducto
    Public idPlantel As Integer = 0
    Dim unidadMinima As String = ""
    Dim idLote As Integer = 0
    Dim idEnfermedad As Integer = 0
    Dim idMedicamento As Integer = 0
    Dim idCerdo As Integer = 0

    Private Sub FrmRegistrarVacunacionCerdo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            ListarAreas()
            cmbArea.Value = 4
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        clsBasicas.LlenarComboAnios(CmbAnios)
        NumLote.Value = clsBasicas.ObtenerNumeroSemanaFecha(DateTime.Now)
        LblArete.Visible = False
        TxtArete.Visible = False
        BtnBuscarAnimal.Visible = False
        RtnLote.Checked = True
        TxtArete.ReadOnly = True
        DtpFechaVacunacion.Value = Now.Date
        TxtLote.ReadOnly = True
        TxtEnfermedad.ReadOnly = True
        TxtMedicamento.ReadOnly = True
        LblLote.Visible = True
        TxtLote.Visible = True
        BtnLotes.Visible = True
        CmbVia.SelectedIndex = 0
        CbxAplicacion.Checked = False
        LblNumAplicacion.Visible = False
        NumAplicacion.Visible = False
        CmbVia.Enabled = False
        CbxAplicacionParcial.Checked = False
        LblVacunados.Visible = False
        NumVacunados.Visible = False

        If idPlantel = 1 Or idPlantel = 2 Then
            cmbArea.Visible = True
            LblArea.Visible = True
        Else
            cmbArea.Visible = False
            LblArea.Visible = False
        End If
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

    Sub ListarUnidadesMedida(tipo As String)
        Dim cn As New cnArea
        Dim tb As New DataTable
        tb = cnUnidadMedida.Cn_ConsultarUnidadMedidaSanidad(tipo).Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione una Área"
        With cbUnidadMedida
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Private Sub BtnLotes_Click(sender As Object, e As EventArgs) Handles BtnLotes.Click
        Try
            Dim frm As New FrmListarLotesVacunacion(Me) With {
                .idUbicacion = idPlantel
            }
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Public Sub LlenarLoteVacunacion(codigo As Integer, descripcion As String)
        idLote = codigo
        TxtLote.Text = descripcion
    End Sub

    Private Sub BtnBuscarEnfermedad_Click(sender As Object, e As EventArgs) Handles BtnBuscarEnfermedad.Click
        Try
            Dim frm As New FrmListarEnfermedadVacunacion(Me)
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Public Sub LlenarCamposEnfermedad(codigo As Integer, descripcion As String)
        idEnfermedad = codigo
        TxtEnfermedad.Text = descripcion
    End Sub

    Private Sub btnMedicamendoRecomendado_Click(sender As Object, e As EventArgs) Handles btnMedicamendoRecomendado.Click
        Try
            If idEnfermedad = 0 Then
                msj_advert("Seleccione una Enfermedad")
                Return
            Else
                Dim f As New FrmListarMedicamentoRecomendadoV(Me) With {
                    .idEnfermedad = idEnfermedad,
                    .IdPlantel = idPlantel
                }
                f.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnAgregarMedicamento_Click(sender As Object, e As EventArgs) Handles BtnAgregarMedicamento.Click
        Try
            Dim frm As New FrmListarMedicacionVacunacion(Me) With {
                .idPlantel = idPlantel
            }
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Public Sub LlenarCamposMedicamento(codigo As Integer, descripcion As String, unidadMedidad As String)
        idMedicamento = codigo
        TxtMedicamento.Text = descripcion
        unidadMinima = unidadMedidad
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            Dim intervalo As (Date, Date) = clsBasicas.ObtenerIntervaloSemana(CInt(CmbAnios.Text), NumLote.Value)
            Dim fechaInicio As Date = intervalo.Item1
            Dim fechaFin As Date = intervalo.Item2

            If DtpFechaVacunacion.Value > Now.Date Then
                msj_advert("La fecha no puede ser mayor a la fecha actual")
                Return
            End If

            If (idLote = 0 And idCerdo = 0) And cmbArea.Value <> 2 Then
                msj_advert("Seleccione un lote / animal")
                Return
            End If

            If idEnfermedad = 0 Then
                msj_advert("Seleccione una enfermedad")
                Return
            End If

            If idMedicamento = 0 Then
                msj_advert("Seleccione un medicamento")
                Return
            End If

            If CbxAplicacion.Checked Then
                If NumAplicacion.Value = 0 Then
                    msj_advert("Número de aplicación no válido")
                    Return
                End If
            End If

            If TxtCodVacuna.Text.Trim.Length = 0 Then
                msj_advert("El código de la vacuna no puede estar vacío")
                Return
            End If

            If CbxAplicacionParcial.Checked Then
                If NumVacunados.Value = 0 Then
                    msj_advert("Número de vacunados no válido")
                    Return
                End If
            End If

            If cbUnidadMedida.Value Is Nothing OrElse cbUnidadMedida.Value = 0 Then
                msj_advert("Seleccione una unidad de medida")
                Return
            End If

            If txtCantidadOrigen.Text.Trim.Length = 0 Then
                msj_advert("La cantidad no puede estar vacía")
                Return
            End If

            If CInt(txtCantidadOrigen.Text.Trim()) <= 0 Then
                msj_advert("La cantidad debe ser mayor a cero")
                Return
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE REGISTRAR MEDICACIÓN O TRATAMIENTO?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coControlMedico With {
                .ModoAplicacion = If(RtnIndividual.Checked, "INDIVIDUAL", "LOTE"),
                .Codigo = If(RtnIndividual.Checked, idCerdo, idLote),
                .FechaControl = DtpFechaVacunacion.Value,
                .Observacion = TxtObservacion.Text,
                .Afectados = If(CbxAplicacionParcial.Checked, NumVacunados.Value, 0),
                .IdUsuario = VP_IdUser,
                .IdPlantel = idPlantel,
                .CodVacuna = TxtCodVacuna.Text,
                .FVencimientoVacuna = DtpFechaVencVacuna.Value,
                .NumAplicacion = If(CbxAplicacion.Checked, NumAplicacion.Value, 0),
                .IdEnfermedad = idEnfermedad,
                .IdMedicamento = idMedicamento,
                .Via = CmbVia.Text,
                .IdConversion = cbUnidadMedida.Value,
                .CantidadOrigen = CInt(txtCantidadOrigen.Text.Trim()),
                .IdArea = If(cmbArea.Visible, cmbArea.Value, 0),
                .NumSemana = If(cmbArea.Value = 2, NumLote.Value, 0),
                .FechaInicio = If(cmbArea.Value = 2, fechaInicio, DtpFechaVacunacion.Value),
                .FechaFin = If(cmbArea.Value = 2, fechaFin, DtpFechaVacunacion.Value)
            }

            Dim _mensaje As String = cn.Cn_RegistrarVacunacion(obj)
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

    Private Sub CbxAplicacion_CheckedChanged(sender As Object, e As EventArgs) Handles CbxAplicacion.CheckedChanged
        If CbxAplicacion.Checked Then
            LblNumAplicacion.Visible = True
            NumAplicacion.Visible = True
        Else
            LblNumAplicacion.Visible = False
            NumAplicacion.Visible = False
        End If
    End Sub

    Private Sub CbxAplicacionParcial_CheckedChanged(sender As Object, e As EventArgs) Handles CbxAplicacionParcial.CheckedChanged
        If CbxAplicacionParcial.Checked Then
            LblVacunados.Visible = True
            NumVacunados.Visible = True
        Else
            LblVacunados.Visible = False
            NumVacunados.Visible = False
        End If
    End Sub

    Private Sub txtCantidadOrigen_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidadOrigen.KeyPress
        clsBasicas.ValidarNumeros(e)
    End Sub

    Private Sub RtnLote_CheckedChanged(sender As Object, e As EventArgs) Handles RtnLote.CheckedChanged
        If RtnLote.Checked Then
            OcultarMostrarGrupoLote(True)
            OcultarMostrarGrupoIndividual(False)
            idLote = 0
            TxtLote.Text = ""
            idCerdo = 0
            TxtArete.Text = ""
        End If
    End Sub

    Private Sub RtnIndividual_CheckedChanged(sender As Object, e As EventArgs) Handles RtnIndividual.CheckedChanged
        If RtnIndividual.Checked Then
            OcultarMostrarGrupoLote(False)
            OcultarMostrarGrupoIndividual(True)
            idLote = 0
            TxtLote.Text = ""
            idCerdo = 0
            TxtArete.Text = ""
        End If
    End Sub

    Private Sub BtnBuscarAnimal_Click(sender As Object, e As EventArgs) Handles BtnBuscarAnimal.Click
        Try
            If RtnIndividual.Checked Then
                Dim f As New FrmListarCerdoVacunacion(Me) With {
                    .idPlantel = idPlantel,
                    .idArea = cmbArea.Value
                }
                f.ShowDialog()
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Public Sub LlenarCamposCerdo(codigo As Integer, descripcion As String)
        idCerdo = codigo
        TxtArete.Text = descripcion
    End Sub

    Private Sub cmbArea_TextChanged(sender As Object, e As EventArgs) Handles cmbArea.TextChanged
        If cmbArea.Value IsNot Nothing Then
            If cmbArea.Value = 2 Then
                OcultarMostrarGrupoAplicacion(False)
                OcultarMostrarGrupoLote(False)
                OcultarMostrarGrupoIndividual(False)
                OcultarMostrarGrupoPeriodo(True)
            Else
                OcultarMostrarGrupoAplicacion(True)
                OcultarMostrarGrupoLote(True)
                OcultarMostrarGrupoIndividual(False)
                OcultarMostrarGrupoPeriodo(False)
                RtnLote.Checked = True
            End If
        End If
    End Sub

    Private Sub OcultarMostrarGrupoAplicacion(flag As Boolean)
        If flag Then
            LblAplicacion.Visible = True
            GrupoAplicacion.Visible = True
        Else
            LblAplicacion.Visible = False
            GrupoAplicacion.Visible = False
        End If
    End Sub

    Private Sub OcultarMostrarGrupoLote(flag As Boolean)
        If flag Then
            LblLote.Visible = True
            TxtLote.Visible = True
            BtnLotes.Visible = True
        Else
            LblLote.Visible = False
            TxtLote.Visible = False
            BtnLotes.Visible = False
        End If
    End Sub

    Private Sub OcultarMostrarGrupoIndividual(flag As Boolean)
        If flag Then
            LblArete.Visible = True
            TxtArete.Visible = True
            BtnBuscarAnimal.Visible = True
            CbxAplicacionParcial.Visible = False
        Else
            LblArete.Visible = False
            TxtArete.Visible = False
            BtnBuscarAnimal.Visible = False
            CbxAplicacionParcial.Visible = True
        End If
        CbxAplicacionParcial.Checked = False
    End Sub

    Private Sub OcultarMostrarGrupoPeriodo(flag As Boolean)
        If flag Then
            LblAnio.Visible = True
            CmbAnios.Visible = True
            LblSemana.Visible = True
            NumLote.Visible = True
            LblLoteGestacion.Visible = True
            LblPeriodo.Visible = True
        Else
            LblAnio.Visible = False
            CmbAnios.Visible = False
            LblSemana.Visible = False
            NumLote.Visible = False
            LblLoteGestacion.Visible = False
            LblPeriodo.Visible = False
        End If
    End Sub

    Private Sub NumLote_ValueChanged(sender As Object, e As EventArgs) Handles NumLote.ValueChanged
        If CmbAnios.Text = "" Or NumLote.Value = 0 Then
            LblPeriodo.Text = ""
            Return
        End If

        Dim intervalo As (Date, Date) = clsBasicas.ObtenerIntervaloSemana(CmbAnios.Text, NumLote.Value)
        LblPeriodo.Text = clsBasicas.ObtenerPeriodoDeSemana(CmbAnios.Text, NumLote.Value)
        LblLoteGestacion.Text = "Lote " & (NumLote.Value + 17).ToString()
    End Sub

    Private Sub CmbVia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbVia.SelectedIndexChanged
        If String.IsNullOrWhiteSpace(CmbVia.Text) Then
            Return
        End If
        ListarUnidadesMedida(CmbVia.Text)
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class