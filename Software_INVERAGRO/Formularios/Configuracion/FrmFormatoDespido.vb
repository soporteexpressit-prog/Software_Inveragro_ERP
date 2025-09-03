Imports System.IO
Imports CapaNegocio
Imports CapaObjetos

Public Class FrmFormatoDespido
    Dim cn As New cnConfiguracion
    Private Async Sub FrmFormatoDespido_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            lblParrafo01.Text = "Cargando..."
            lblParrafo02.Text = "Cargando..."

            Await CargarContenidosAsync()
        Catch ex As Exception
            clsBasicas.controlException("ERROR AL CARGAR LOS DATOS", ex)
        End Try
    End Sub

    Private Async Function CargarContenidosAsync() As Task
        Try
            Dim parrafo1 As String = Await Task.Run(Function() cn.Cn_ObtenerContenido(ID_CARTA_DESPIDO_P1))
            Dim parrafo2 As String = Await Task.Run(Function() cn.Cn_ObtenerContenido(ID_CARTA_DESPIDO_P2))

            lblParrafo01.Text = parrafo1
            lblParrafo02.Text = parrafo2

            EstablecerTamañoLabel(lblParrafo01, 700)
            EstablecerTamañoLabel(lblParrafo02, 700)
            Await CargarLogoAsync()
        Catch ex As Exception
            clsBasicas.controlException("ERROR AL CARGAR LOS DATOS ASÍNCRONAMENTE", ex)
        End Try
    End Function

    Private Async Function CargarLogoAsync() As Task
        Try
            Dim logoBytes As Byte() = Await Task.Run(Function() cn.Cn_ObtenerLogo(ID_LOGO_CARTA_DESPIDO))

            If logoBytes IsNot Nothing AndAlso logoBytes.Length > 0 Then
                Using ms As New MemoryStream(logoBytes)
                    PictureBoxLogoDespido.Image = Image.FromStream(ms)
                End Using
            Else
                PictureBoxLogoDespido.Image = Formularios.My.Resources.Resources.sinimagen
            End If
        Catch ex As Exception
            clsBasicas.controlException("ERROR AL CARGAR EL LOGO", ex)
        End Try
    End Function

    Private Sub btnParrafo01_Click(sender As Object, e As EventArgs) Handles btnParrafo01.Click
        Dim f As New FrmMantenimientoContenido
        f.idConfiguracion = ID_CARTA_DESPIDO_P1
        f.lblEtiqueta.Text = "INGRESE PÁRRAFO 01"
        f.frmPadre = Me
        f.contenido = lblParrafo01.Text
        f.ShowDialog()
    End Sub

    Private Sub btnParrafo02_Click(sender As Object, e As EventArgs) Handles btnParrafo02.Click
        Dim f As New FrmMantenimientoContenido
        f.idConfiguracion = ID_CARTA_DESPIDO_P2
        f.lblEtiqueta.Text = "INGRESE PÁRRAFO 02"
        f.frmPadre = Me
        f.contenido = lblParrafo02.Text
        f.ShowDialog()
    End Sub
    Private Sub EstablecerTamañoLabel(lbl As Label, maxAncho As Integer)
        lbl.AutoSize = False
        lbl.MaximumSize = New Size(maxAncho, 0)
        lbl.Size = New Size(maxAncho, lbl.GetPreferredSize(New Size(maxAncho, 0)).Height)
    End Sub

    Public Async Sub ActualizarContenido(idConfiguracion As Integer)
        Try
            Select Case idConfiguracion
                Case ID_CARTA_DESPIDO_P1
                    lblParrafo01.Text = cn.Cn_ObtenerContenido(ID_CARTA_DESPIDO_P1)
                Case ID_CARTA_DESPIDO_P2
                    lblParrafo02.Text = cn.Cn_ObtenerContenido(ID_CARTA_DESPIDO_P2)
                Case ID_LOGO_CARTA_DESPIDO
                    Await CargarLogoAsync()
            End Select
        Catch ex As Exception
            clsBasicas.controlException("ERROR AL CARGAR LOS DATOS", ex)
        End Try
    End Sub

    Private Sub btnEditarLogo_Click(sender As Object, e As EventArgs) Handles btnEditarLogo.Click
        Dim f As New FrmMantenimientoLogo()
        f.configuracionId = ID_LOGO_CARTA_DESPIDO
        f.frmPadre = Me
        f.ShowDialog()
    End Sub
End Class