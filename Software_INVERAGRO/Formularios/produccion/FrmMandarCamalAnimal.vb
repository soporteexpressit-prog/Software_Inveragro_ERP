Imports CapaNegocio
Imports CapaObjetos

Public Class FrmMandarCamalAnimal
    Dim cnAnimal As New cnControlAnimal
    Dim idMotivoMortalidad As Integer = 0
    Dim tipoIncidente As String = ""
    Dim loadNewImageFoto As Boolean = False
    Dim imagefoto As Byte() = Nothing
    Public idAnimal As Integer = 0
    Public arete As String = ""
    Public clasificacion As String = ""

    Private Sub FrmMandarCamalAnimal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtMotivoMortalidad.ReadOnly = True
        LblPeso.Visible = False
        TxtPeso.Visible = False
        LblCodArete.Text = arete
        If clasificacion = "CHANCHILLA" Then
            CbxChanchillaEngorde.Visible = True
        Else
            CbxChanchillaEngorde.Visible = False
        End If
        ConsultarInicializarDiccionario()
    End Sub

    Private Sub ConsultarInicializarDiccionario()
        DtpFecha.Value = VariablesGlobales.ParametrosEnvioCamalAnimal("fEnvioCamal")
        DtpFecha.Enabled = If(VariablesGlobales.ParametrosEnvioCamalAnimal("fEnvioCamalBloqueo") = 1, False, True)
        idMotivoMortalidad = VariablesGlobales.ParametrosEnvioCamalAnimal("idMotivoCamal")
        TxtMotivoMortalidad.Text = VariablesGlobales.ParametrosEnvioCamalAnimal("valorMotivoCamal").ToString()
        BtnMotivoCamal.Enabled = If(VariablesGlobales.ParametrosEnvioCamalAnimal("motivoCamalBloqueo") = 1, False, True)
    End Sub

    Public Sub LlenarCampoMotivoMortalidad(id As String, motivo As String, tipo As String)
        idMotivoMortalidad = id
        TxtMotivoMortalidad.Text = motivo
        tipoIncidente = tipo
    End Sub

    Private Sub BtnMotivoMortalidad_Click(sender As Object, e As EventArgs) Handles BtnMotivoCamal.Click
        Try
            Dim frm As New FrmListarIncidenciaMandarCamal(Me)
            frm.ShowDialog()
            If idMotivoMortalidad = 87 Or idMotivoMortalidad = 88 Then
                LblPeso.Visible = True
                TxtPeso.Visible = True
                TxtPeso.Text = "0"
            Else
                LblPeso.Visible = False
                TxtPeso.Visible = False
                TxtPeso.Text = "0"
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnSeleccionarEvidencia_Click(sender As Object, e As EventArgs) Handles BtnSeleccionarEvidencia.Click
        Dim ofd As New OpenFileDialog With {
            .Title = "Seleccionar Imagen",
            .Filter = "Archivos de Imagen|*.jpg;*.jpeg;*.png;*.bmp",
            .InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
        }
        If ofd.ShowDialog() = DialogResult.OK Then
            picFoto.Image = Image.FromFile(ofd.FileName)
            loadNewImageFoto = True
        End If
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            If DtpFecha.Value > Now.Date Then
                msj_advert("La fecha no puede ser mayor a la actual")
                Exit Sub
            End If

            If tipoIncidente = "EMERGENCIA" And CbxChanchillaEngorde.Checked Then
                msj_advert("No se puede enviar a camal un cerdo en emergencia con chanchilla de engorde")
                Exit Sub
            End If

            If idMotivoMortalidad = 0 Then
                msj_advert("Debe seleccionar un motivo de envío a camal")
                Exit Sub
            ElseIf txtDescripcion.Text.Length = 0 Then
                msj_advert("Ingrese una descripción")
                Exit Sub
            Else
                If idMotivoMortalidad = 87 Or idMotivoMortalidad = 88 Then
                    If TxtPeso.Text = "" Then
                        msj_advert("Debe ingresar el peso del cerdo")
                        Exit Sub
                    ElseIf CDec(TxtPeso.Text) <= 0 Then
                        msj_advert("El peso del cerdo no debe ser cero")
                        Exit Sub
                    End If
                End If

                If picFoto.Image IsNot Nothing Then
                    If (loadNewImageFoto) Then
                        Dim optimizedImageBytes As Byte() = clsBasicas.OptimizeImageFromPictureBox(picFoto)
                        picFoto.Image = clsBasicas.ByteArrayToImage(optimizedImageBytes)
                        imagefoto = optimizedImageBytes
                    End If
                End If

                Dim obj As New coControlAnimal With {
                    .Codigo = idAnimal,
                    .IdMotivoMortalidadCamal = idMotivoMortalidad,
                    .ArchivoFotoCamal = If(loadNewImageFoto AndAlso imagefoto IsNot Nothing, imagefoto, Nothing),
                    .IdUsuario = VP_IdUser,
                    .Observacion = txtDescripcion.Text,
                    .FechaControl = DtpFecha.Value,
                    .Peso = If(TxtPeso.Text = "", 0, CDec(TxtPeso.Text)),
                    .ChanchillaEngorde = CbxChanchillaEngorde.Checked
                }

                If (MessageBox.Show("¿ESTÁ SEGURO DE ENVIAR A CAMAL A ESTE CERDO?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                    Return
                End If

                Dim MensajeBgWk As String = cnAnimal.Cn_RegistrarEnvioCamal(obj)
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

    Private Sub TxtPeso_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtPeso.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub BtnBloquearFecha_Click(sender As Object, e As EventArgs) Handles BtnBloquearFecha.Click
        If CInt(VariablesGlobales.ParametrosEnvioCamalAnimal("fEnvioCamalBloqueo")) = 1 Then
            DtpFecha.Enabled = True
            VariablesGlobales.ParametrosEnvioCamalAnimal("fEnvioCamal") = Now.Date
            VariablesGlobales.ParametrosEnvioCamalAnimal("fEnvioCamalBloqueo") = 0
        Else
            DtpFecha.Enabled = False
            VariablesGlobales.ParametrosEnvioCamalAnimal("fEnvioCamal") = DtpFecha.Value
            VariablesGlobales.ParametrosEnvioCamalAnimal("fEnvioCamalBloqueo") = 1
        End If
    End Sub

    Private Sub BtnMotivo_Click(sender As Object, e As EventArgs) Handles BtnMotivo.Click
        If CInt(VariablesGlobales.ParametrosEnvioCamalAnimal("motivoCamalBloqueo")) = 1 Then
            BtnMotivoCamal.Enabled = True
            VariablesGlobales.ParametrosEnvioCamalAnimal("idMotivoCamal") = 0
            VariablesGlobales.ParametrosEnvioCamalAnimal("valorMotivoCamal") = ""
            VariablesGlobales.ParametrosEnvioCamalAnimal("motivoCamalBloqueo") = 0
        Else
            BtnMotivoCamal.Enabled = False
            VariablesGlobales.ParametrosEnvioCamalAnimal("idMotivoCamal") = idMotivoMortalidad
            VariablesGlobales.ParametrosEnvioCamalAnimal("valorMotivoCamal") = TxtMotivoMortalidad.Text
            VariablesGlobales.ParametrosEnvioCamalAnimal("motivoCamalBloqueo") = 1
        End If
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class