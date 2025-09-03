Imports System.IO
Imports CapaNegocio
Imports CapaObjetos

Public Class FrmRegistrarTestGestacion
    Dim cnAnimal As New cnControlAnimal
    Dim cnInseminacion As New cnControlGestacion
    Dim imagefoto As Byte() = Nothing
    Dim idCerda As Integer = 0
    Dim loadNewImageFoto As Boolean = False
    Public idUbicacion As Integer = 0
    Public idControlFicha As Integer = 0

    Private Sub FrmTestGestacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        TxtObservacion.Text = "NINGUNA"
        CmbResultado.SelectedIndex = 0
        NumTotalMuertos.Visible = False
        LblMuertos.Visible = False
        GroupBox2.Visible = False
        Me.Size = New Size(580, 340)
        If idControlFicha = 0 Then
            ConsultarInicializarDiccionario()
            LblSeleccionarCerda.Visible = True
            BtnBuscarCerda.Visible = True
        Else
            NoMostrarCandados()
            BtnBloquearFecha.Visible = False
            BtnBloquearResultado.Visible = False
            LblSeleccionarCerda.Visible = False
            BtnBuscarCerda.Visible = False
            ChkEnviarCamal.Visible = False
            ConsultarxId()
        End If
    End Sub

    Private Sub NoMostrarCandados()
        BtnBloquearFecha.Visible = False
        BtnBloquearResultado.Visible = False
    End Sub

    Sub ConsultarxId()
        Try
            Dim obj As New coControlAnimal With {
                .Codigo = idControlFicha
            }
            Dim dt As New DataTable
            dt = cnAnimal.Cn_ConsultarPerdidaReproductiva(obj).Copy
            If (dt.Rows.Count > 0) Then
                idCerda = dt.Rows(0)("idAnimal")
                LblCodArete.Text = dt.Rows(0)("codCerdo")
                DtpFechaPerdida.Value = dt.Rows(0)("fControl")
                TxtObservacion.Text = dt.Rows(0)("observacion").ToString()
                CmbResultado.Text = dt.Rows(0)("tipoControl").ToString()
                NumTotalMuertos.Value = CInt(dt.Rows(0)("totalMuertos"))
                Dim archivoFoto() As Byte = If(dt.Rows(0)("archivoFoto") IsNot DBNull.Value, CType(dt.Rows(0)("archivoFoto"), Byte()), Nothing)

                If archivoFoto IsNot Nothing AndAlso archivoFoto.Length > 0 Then
                    Using ms As New MemoryStream(archivoFoto)
                        picFoto.Image = Image.FromStream(ms)
                    End Using
                End If
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ConsultarInicializarDiccionario()
        DtpFechaPerdida.Value = VariablesGlobales.ParametrosPerdidaReproductiva("fPerdidadReproductiva")
        DtpFechaPerdida.Enabled = If(VariablesGlobales.ParametrosPerdidaReproductiva("fPerdidadReproductivaBloqueo") = 1, False, True)
        CmbResultado.Text = VariablesGlobales.ParametrosPerdidaReproductiva("resultado")
        CmbResultado.Enabled = If(VariablesGlobales.ParametrosPerdidaReproductiva("resultadoBloqueo") = 1, False, True)
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            If (DtpFechaPerdida.Value > DateTime.Now) Then
                msj_advert("La fecha no puede ser mayor a la actual")
                DtpFechaPerdida.Focus()
                Exit Sub
            End If

            If (idCerda = 0) Then
                msj_advert("Debe seleccionar una cerda")
                Exit Sub
            End If

            If (CmbResultado.Text = "ABORTO") Then
                If loadNewImageFoto Then
                    If picFoto.Image IsNot Nothing Then
                        Dim optimizedImageBytes As Byte() = clsBasicas.OptimizeImageFromPictureBox(picFoto)
                        picFoto.Image = clsBasicas.ByteArrayToImage(optimizedImageBytes)
                        imagefoto = optimizedImageBytes
                    Else
                        msj_advert("Debe seleccionar una imagen")
                        Exit Sub
                    End If
                Else
                    msj_advert("Debe seleccionar una imagen")
                    Exit Sub
                End If
            Else
                imagefoto = Nothing
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE REGISTRAR LA PÉRDIDA REPRODUCTIVA?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coControlAnimal With {
                .IdControlFicha = idControlFicha,
                .Codigo = idCerda,
                .Resultado = CmbResultado.Text,
                .Observacion = TxtObservacion.Text,
                .IdUsuario = VP_IdUser,
                .ArchivoFotoCamal = If(loadNewImageFoto AndAlso imagefoto IsNot Nothing, imagefoto, Nothing),
                .FechaControl = DtpFechaPerdida.Value,
                .CantidadCrias = NumTotalMuertos.Value,
                .EnvioCamal = If(ChkEnviarCamal.Checked, "SI", "NO")
            }

            Dim MensajeBgWk As String = cnAnimal.Cn_RegistrarTestGestacion(obj)
            If (obj.Coderror = 0) Then
                msj_ok(MensajeBgWk)
                LimpiarCampos()
                If idControlFicha = 0 Then
                    ConsultarInicializarDiccionario()
                Else
                    Dispose()
                End If
            Else
                msj_advert(MensajeBgWk)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub LimpiarCampos()
        LblCodArete.Text = "-"
        idCerda = 0
        DtpFechaPerdida.Value = Now.Date
        picFoto.Image = Nothing
        imagefoto = Nothing
        picFoto.Image = My.Resources.sinimagen
        NumTotalMuertos.Value = 0
        ChkEnviarCamal.Checked = False
        TxtObservacion.Text = "NINGUNA"
        Inicializar()
    End Sub

    Private Sub CmbResultado_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbResultado.SelectedValueChanged
        If (CmbResultado.Text = "ABORTO") Then
            NumTotalMuertos.Visible = True
            LblMuertos.Visible = True
            GroupBox2.Visible = True
            Me.Size = New Size(580, 510)
        Else
            NumTotalMuertos.Visible = False
            LblMuertos.Visible = False
            GroupBox2.Visible = False
            Me.Size = New Size(580, 340)
            NumTotalMuertos.Value = 0
        End If
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

    Private Sub BtnBuscarCerda_Click(sender As Object, e As EventArgs) Handles BtnBuscarCerda.Click
        Try
            Dim frm As New FrmListarCerdasGestantes(Me) With {
                .idPlantel = idUbicacion
            }
            frm.ShowDialog()
            picFoto.Image = Nothing
            imagefoto = Nothing
            picFoto.Image = My.Resources.sinimagen
            NumTotalMuertos.Value = 0
            Inicializar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Public Sub LlenarCamposCerdaGestante(codigo As String, datos As String)
        idCerda = codigo
        LblCodArete.Text = datos
    End Sub

    Private Sub BtnBloquearFecha_Click(sender As Object, e As EventArgs) Handles BtnBloquearFecha.Click
        If CInt(VariablesGlobales.ParametrosPerdidaReproductiva("fPerdidadReproductivaBloqueo")) = 1 Then
            DtpFechaPerdida.Enabled = True
            VariablesGlobales.ParametrosPerdidaReproductiva("fPerdidadReproductiva") = Now.Date
            VariablesGlobales.ParametrosPerdidaReproductiva("fPerdidadReproductivaBloqueo") = 0
        Else
            DtpFechaPerdida.Enabled = False
            VariablesGlobales.ParametrosPerdidaReproductiva("fPerdidadReproductiva") = DtpFechaPerdida.Value
            VariablesGlobales.ParametrosPerdidaReproductiva("fPerdidadReproductivaBloqueo") = 1
        End If
    End Sub

    Private Sub BtnBloquearResultado_Click(sender As Object, e As EventArgs) Handles BtnBloquearResultado.Click
        If CInt(VariablesGlobales.ParametrosPerdidaReproductiva("resultadoBloqueo")) = 1 Then
            CmbResultado.Enabled = True
            CmbResultado.SelectedIndex = 0
            VariablesGlobales.ParametrosPerdidaReproductiva("resultado") = CmbResultado.Text
            VariablesGlobales.ParametrosPerdidaReproductiva("resultadoBloqueo") = 0
        Else
            CmbResultado.Enabled = False
            VariablesGlobales.ParametrosPerdidaReproductiva("resultado") = CmbResultado.Text
            VariablesGlobales.ParametrosPerdidaReproductiva("resultadoBloqueo") = 1
        End If
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class