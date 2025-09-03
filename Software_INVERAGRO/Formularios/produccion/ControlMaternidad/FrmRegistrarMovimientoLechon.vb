Imports CapaNegocio
Imports CapaObjetos

Public Class FrmRegistrarMovimientoLechon
    Private cn As New cnControlAnimal
    Dim idCerda1 As Integer = 0
    Dim idCerda2 As Integer = 0
    Dim idLote1 As Integer = 0
    Dim idLote2 As Integer = 0
    Public idUbicacion As Integer = 0
    Public CriasDonadas As String = ""

    Private Sub FrmRegistrarMovimientoLechon_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            TxtCodArete1.ReadOnly = True
            TxtCodArete2.ReadOnly = True
            NumCriasDonar.ReadOnly = True
            CmbAccion.SelectedIndex = 0
            Inicializar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        RtnDejarVacia.Visible = False
        RtnSeguirLactando.Visible = False
        RtnDejarVacia.Checked = False
        RtnSeguirLactando.Checked = False
        NumCriasDonar.Text = "0"
        LblMensaje.Text = "-"
        idCerda1 = 0
        TxtCodArete1.Text = ""
        idCerda2 = 0
        TxtCodArete2.Text = ""
        LblTotalCrias1.Text = "0"
        LblTotalCrias2.Text = "0"
        ConsultarInicializarDiccionario()
    End Sub

    Private Sub ConsultarInicializarDiccionario()
        DtpFechaMovimiento.Value = VariablesGlobales.ParametrosMovimientoMaternidad("fMovimiento")
        DtpFechaMovimiento.Enabled = If(VariablesGlobales.ParametrosMovimientoMaternidad("fMovimientoBloqueo") = 1, False, True)
        If VariablesGlobales.ParametrosMovimientoMaternidad("cerda1Bloqueo") = 1 Then
            idCerda1 = VariablesGlobales.ParametrosMovimientoMaternidad("idCerda1")
            TxtCodArete1.Text = VariablesGlobales.ParametrosMovimientoMaternidad("txtArete1")
            LblTotalCrias1.Text = VariablesGlobales.ParametrosMovimientoMaternidad("totalCriasCerda1")
            idLote1 = VariablesGlobales.ParametrosMovimientoMaternidad("idLote1")
            BtnBuscarCerda1.Enabled = False
        Else
            VariablesGlobales.ParametrosParto("idCerda1") = idCerda1
            VariablesGlobales.ParametrosParto("txtArete1") = TxtCodArete1.Text
            VariablesGlobales.ParametrosParto("totalCriasCerda1") = LblTotalCrias1.Text
            VariablesGlobales.ParametrosParto("idLote1") = idLote1
            BtnBuscarCerda1.Enabled = True
        End If

        If VariablesGlobales.ParametrosMovimientoMaternidad("cerda2Bloqueo") = 1 Then
            idCerda2 = VariablesGlobales.ParametrosMovimientoMaternidad("idCerda2")
            TxtCodArete2.Text = VariablesGlobales.ParametrosMovimientoMaternidad("txtArete2")
            LblTotalCrias2.Text = VariablesGlobales.ParametrosMovimientoMaternidad("totalCriasCerda2")
            idLote2 = VariablesGlobales.ParametrosMovimientoMaternidad("idLote2")
            BtnBuscarCerda2.Enabled = False
        Else
            VariablesGlobales.ParametrosParto("idCerda2") = idCerda2
            VariablesGlobales.ParametrosParto("txtArete2") = TxtCodArete2.Text
            VariablesGlobales.ParametrosParto("totalCriasCerda2") = LblTotalCrias2.Text
            VariablesGlobales.ParametrosParto("idLote2") = idLote2
            BtnBuscarCerda2.Enabled = True
        End If
    End Sub

    Public Sub GuardarSeleccionCrias(selectedIdsCriasString As String, numeroTotalCrias As Integer)
        CriasDonadas = selectedIdsCriasString
        NumCriasDonar.Text = numeroTotalCrias
    End Sub

    Private Sub BtnBuscarCerda2_Click(sender As Object, e As EventArgs) Handles BtnBuscarCerda2.Click
        Try
            If idCerda1 = 0 Then
                msj_advert("Primero debe seleccionar la cerda donante o receptora")
                Return
            End If

            Dim frm As New FrmListarCerdaMovimiento2(Me) With {
                .idPlantel = idUbicacion,
                .codAreteCerda1 = TxtCodArete1.Text,
                .idLote = idLote1
            }
            frm.ShowDialog()

            If idCerda2 <> 0 Then
                InicializarCambioCerda2()
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub InicializarCambioCerda2()
        NumCriasDonar.Text = "0"
        LblMensaje.Text = TxtCodArete1.Text & If(CmbAccion.Text = "DONAR LECHONES", " ES LA CERDA DONANTE", " ES LA CERDA RECEPTORA")
        RtnDejarVacia.Visible = False
        RtnSeguirLactando.Visible = False
        RtnDejarVacia.Checked = False
        RtnSeguirLactando.Checked = False
        If VariablesGlobales.ParametrosMovimientoMaternidad("cerda1Bloqueo") = 0 Then
            BtnBuscarCerda1.Enabled = True
        Else
            BtnBuscarCerda1.Enabled = False
        End If
    End Sub

    Public Sub LlenarCamposCerda2(id As Integer, codigo As String, numCrias As Integer, idLoteAnimal As Integer)
        idCerda2 = id
        TxtCodArete2.Text = codigo
        LblTotalCrias2.Text = numCrias
        idLote2 = idLoteAnimal
    End Sub

    Private Sub BtnCriasCerda_Click(sender As Object, e As EventArgs) Handles BtnCriasCerda.Click
        Try
            If CmbAccion.SelectedIndex = 1 And CInt(LblTotalCrias2.Text) = 0 Then
                msj_advert("No puedo donar una cerda que no tiene crías")
                NumCriasDonar.Text = "0"
                Return
            End If

            Dim frm As New FrmListarCriasMovimiento(Me) With {
                .idCerda = If(CmbAccion.Text = "DONAR LECHONES", idCerda1, idCerda2)
            }
            frm.ShowDialog()

            If NumCriasDonar.Text.Length = 0 Then
                NumCriasDonar.Text = "0"
            End If

            If CInt(LblTotalCrias2.Text) = CInt(NumCriasDonar.Text) And CInt(NumCriasDonar.Text) <> 0 And CmbAccion.SelectedIndex = 1 Then
                RtnDejarVacia.Visible = True
                RtnSeguirLactando.Visible = True
            Else
                If CInt(LblTotalCrias1.Text) = CInt(NumCriasDonar.Text) And CInt(NumCriasDonar.Text) <> 0 And CmbAccion.SelectedIndex = 0 Then
                    RtnDejarVacia.Visible = True
                    RtnSeguirLactando.Visible = True
                Else
                    RtnDejarVacia.Visible = False
                    RtnSeguirLactando.Visible = False
                End If
            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            If DtpFechaMovimiento.Value > Now.Date Then
                msj_advert("La fecha de movimiento no puede ser mayor a la fecha actual")
                Return
            End If

            If idCerda1 = 0 Then
                msj_advert("Ingrese la cerda a donar o recibir")
                Return
            End If

            If idCerda2 = 0 Then
                msj_advert("Ingrese la cerda a donar o recibir")
                Return
            End If

            If NumCriasDonar.Text.Length = 0 Then
                msj_advert("Ingrese una cantidad de crías valida")
                Return
            End If

            If CInt(NumCriasDonar.Text) = 0 Then
                msj_advert("Ingrese una cantidad de crías valida")
                Return
            End If

            Dim obj As New coControlAnimal With {
                .DejarVaciaoLactando = If(RtnDejarVacia.Checked, "SI", "NO"),
                .Codigo = If(CmbAccion.Text = "DONAR LECHONES", idCerda2, idCerda1),
                .ListaCerdasDonantes = If(CmbAccion.Text = "DONAR LECHONES", idCerda1 & "+" & CInt(NumCriasDonar.Text), idCerda2 & "+" & CInt(NumCriasDonar.Text)),
                .ListaIdsCriasDonantes = CriasDonadas,
                .FechaControl = DtpFechaMovimiento.Value,
                .IdUsuario = VP_IdUser
            }

            If RtnDejarVacia.Visible AndAlso Not RtnDejarVacia.Checked AndAlso Not RtnSeguirLactando.Checked Then
                msj_advert("Debe seleccionar una opción para la cerda si se deja vacía o se sigue lactando.")
                Return
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE REGISTRAR EL " & CmbAccion.Text & "?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim _mensaje As String = cn.Cn_RegistrarMovimientoCriaMaternidad(obj)
            If (obj.Coderror = 0) Then
                If CmbAccion.Text = "DONAR LECHONES" Then
                    LblTotalCrias1.Text = CInt(LblTotalCrias1.Text) - CInt(NumCriasDonar.Text)
                    LblTotalCrias2.Text = CInt(LblTotalCrias2.Text) + CInt(NumCriasDonar.Text)
                Else
                    LblTotalCrias1.Text = CInt(LblTotalCrias1.Text) + CInt(NumCriasDonar.Text)
                    LblTotalCrias2.Text = CInt(LblTotalCrias2.Text) - CInt(NumCriasDonar.Text)
                End If
                VariablesGlobales.ParametrosMovimientoMaternidad("totalCriasCerda1") = LblTotalCrias1.Text
                VariablesGlobales.ParametrosMovimientoMaternidad("totalCriasCerda2") = LblTotalCrias2.Text

                If RtnDejarVacia.Checked Or RtnSeguirLactando.Checked Then
                    Dim idDonante As Integer = CInt(obj.ListaCerdasDonantes.Split("+")(0))
                    If idDonante = idCerda1 Then
                        VariablesGlobales.ParametrosMovimientoMaternidad("idCerda1") = 0
                        VariablesGlobales.ParametrosMovimientoMaternidad("txtArete1") = ""
                        VariablesGlobales.ParametrosMovimientoMaternidad("idLote1") = 0
                        VariablesGlobales.ParametrosMovimientoMaternidad("cerda1Bloqueo") = 0
                    Else
                        VariablesGlobales.ParametrosMovimientoMaternidad("idCerda2") = 0
                        VariablesGlobales.ParametrosMovimientoMaternidad("txtArete2") = ""
                        VariablesGlobales.ParametrosMovimientoMaternidad("idLote2") = 0
                        VariablesGlobales.ParametrosMovimientoMaternidad("cerda2Bloqueo") = 0
                    End If
                End If
                Inicializar()
                msj_ok(_mensaje)
            Else
                msj_advert(_mensaje)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub CmbAccion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbAccion.SelectedIndexChanged
        InicializarValoresGenerales()
    End Sub

    Private Sub InicializarValoresGenerales()
        idCerda2 = 0
        TxtCodArete2.Text = ""
        LblTotalCrias2.Text = "0"
        NumCriasDonar.Text = "0"
        If idCerda1 <> 0 Then
            LblMensaje.Text = TxtCodArete1.Text & If(CmbAccion.Text = "DONAR LECHONES", " ES LA CERDA DONANTE", " ES LA CERDA RECEPTORA")
        End If
        RtnDejarVacia.Visible = False
        RtnSeguirLactando.Visible = False
        RtnDejarVacia.Checked = False
        RtnSeguirLactando.Checked = False
    End Sub

    Private Sub BtnBuscarCerda1_Click(sender As Object, e As EventArgs) Handles BtnBuscarCerda1.Click
        Try
            Dim frm As New FrmListarCerdaMovimiento1(Me) With {
                .idPlantel = idUbicacion,
                .idCerda2 = idCerda2,
                .idLote = idLote2
            }
            frm.ShowDialog()

            If idCerda1 <> 0 Then
                InicializarCambioCerda1()
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub InicializarCambioCerda1()
        NumCriasDonar.Text = "0"
        LblMensaje.Text = TxtCodArete1.Text & If(CmbAccion.Text = "DONAR LECHONES", " ES LA CERDA DONANTE", " ES LA CERDA RECEPTORA")
        RtnDejarVacia.Visible = False
        RtnSeguirLactando.Visible = False
        RtnDejarVacia.Checked = False
        RtnSeguirLactando.Checked = False
        If VariablesGlobales.ParametrosMovimientoMaternidad("cerda2Bloqueo") = 0 Then
            BtnBuscarCerda2.Enabled = True
        Else
            BtnBuscarCerda2.Enabled = False
        End If
    End Sub

    Public Sub LlenarCamposCerda1(id As Integer, codigo As String, numCrias As Integer, idLoteAnimal As Integer)
        idCerda1 = id
        TxtCodArete1.Text = codigo
        LblTotalCrias1.Text = numCrias
        idLote1 = idLoteAnimal
    End Sub

    Private Sub BtnBloquearFechaMovimiento_Click(sender As Object, e As EventArgs) Handles BtnBloquearFechaMovimiento.Click
        If VariablesGlobales.ParametrosMovimientoMaternidad("fMovimientoBloqueo") = 1 Then
            DtpFechaMovimiento.Enabled = True
            VariablesGlobales.ParametrosMovimientoMaternidad("fMovimiento") = Now.Date
            VariablesGlobales.ParametrosMovimientoMaternidad("fMovimientoBloqueo") = 0
        Else
            DtpFechaMovimiento.Enabled = False
            VariablesGlobales.ParametrosMovimientoMaternidad("fMovimiento") = DtpFechaMovimiento.Value
            VariablesGlobales.ParametrosMovimientoMaternidad("fMovimientoBloqueo") = 1
        End If
    End Sub

    Private Sub BtnBloqueoCerda1_Click(sender As Object, e As EventArgs) Handles BtnBloqueoCerda1.Click
        If VariablesGlobales.ParametrosMovimientoMaternidad("cerda1Bloqueo") = 1 Then
            BtnBuscarCerda1.Enabled = True
            VariablesGlobales.ParametrosMovimientoMaternidad("cerda1Bloqueo") = 0
        Else
            BtnBuscarCerda1.Enabled = False
            VariablesGlobales.ParametrosMovimientoMaternidad("totalCriasCerda1") = LblTotalCrias1.Text
            VariablesGlobales.ParametrosMovimientoMaternidad("cerda1Bloqueo") = 1
        End If
        VariablesGlobales.ParametrosMovimientoMaternidad("idCerda1") = idCerda1
        VariablesGlobales.ParametrosMovimientoMaternidad("txtArete1") = TxtCodArete1.Text
        VariablesGlobales.ParametrosMovimientoMaternidad("idLote1") = idLote1
    End Sub

    Private Sub BtnBloqueoCerda2_Click(sender As Object, e As EventArgs) Handles BtnBloqueoCerda2.Click
        If VariablesGlobales.ParametrosMovimientoMaternidad("cerda2Bloqueo") = 1 Then
            BtnBuscarCerda2.Enabled = True
            VariablesGlobales.ParametrosMovimientoMaternidad("cerda2Bloqueo") = 0
        Else
            BtnBuscarCerda2.Enabled = False
            VariablesGlobales.ParametrosMovimientoMaternidad("totalCriasCerda2") = LblTotalCrias2.Text
            VariablesGlobales.ParametrosMovimientoMaternidad("cerda2Bloqueo") = 1
        End If
        VariablesGlobales.ParametrosMovimientoMaternidad("idCerda2") = idCerda2
        VariablesGlobales.ParametrosMovimientoMaternidad("txtArete2") = TxtCodArete2.Text
        VariablesGlobales.ParametrosMovimientoMaternidad("idLote2") = idLote2
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class