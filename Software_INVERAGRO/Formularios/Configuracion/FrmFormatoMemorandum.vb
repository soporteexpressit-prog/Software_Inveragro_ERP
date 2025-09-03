Imports System.IO
Imports CapaNegocio

Public Class FrmFormatoMemorandum1
    Dim cn As New cnConfiguracion
    Private Async Sub FrmFormatoMemorandum1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            lblNombreAnio.Text = "Cargando..."
            lblParrafo01.Text = "Cargando..."
            lblParrafo02.Text = "Cargando..."


            Await CargarContenidosAsync()
        Catch ex As Exception
            clsBasicas.controlException("ERROR AL CARGAR LOS DATOS", ex)
        End Try
    End Sub

    Private Async Function CargarContenidosAsync() As Task
        Try
            Dim nombreAnio As String = Await Task.Run(Function() cn.Cn_ObtenerContenido(ID_NOMBRE_ANIO))
            Dim parrafo01 As String = Await Task.Run(Function() cn.Cn_ObtenerContenido(ID_MEMORANDUM_P1))
            Dim parrafo02 As String = Await Task.Run(Function() cn.Cn_ObtenerContenido(ID_MEMORANDUM_P2))

            lblNombreAnio.Text = nombreAnio
            lblParrafo01.Text = parrafo01
            lblParrafo02.Text = parrafo02

            EstablecerTamañoLabel(lblNombreAnio, 500)
            EstablecerTamañoLabel(lblParrafo01, 700)
            EstablecerTamañoLabel(lblParrafo02, 700)
            lblNombreAnio.TextAlign = ContentAlignment.MiddleCenter

            Await CargarLogoAsync()
        Catch ex As Exception
            clsBasicas.controlException("ERROR AL CARGAR LOS DATOS ASÍNCRONAMENTE", ex)
        End Try
    End Function

    Private Async Function CargarLogoAsync() As Task
        Try
            Dim logoBytes As Byte() = Await Task.Run(Function() cn.Cn_ObtenerLogo(ID_LOGO_MEMORANDUM))

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

    Private Sub btnNombreAnio_Click(sender As Object, e As EventArgs) Handles btnNombreAnio.Click
        Dim f As New FrmMantenimientoContenido
        f.idConfiguracion = ID_NOMBRE_ANIO
        f.lblEtiqueta.Text = "INGRESE NOMBRE DEL AÑO"
        f.frmPadre = Me
        f.contenido = lblNombreAnio.Text
        f.ShowDialog()
    End Sub

    Private Sub btnParrafo01_Click(sender As Object, e As EventArgs) Handles btnParrafo01.Click
        Dim f As New FrmMantenimientoContenido
        f.idConfiguracion = ID_MEMORANDUM_P1
        f.lblEtiqueta.Text = "INGRESE PÁRRAFO 01"
        f.frmPadre = Me
        f.contenido = lblParrafo01.Text
        f.ShowDialog()
    End Sub

    Private Sub btnParrafo02_Click(sender As Object, e As EventArgs) Handles btnParrafo02.Click
        Dim f As New FrmMantenimientoContenido
        f.idConfiguracion = ID_MEMORANDUM_P2
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
                Case ID_NOMBRE_ANIO
                    lblNombreAnio.Text = cn.Cn_ObtenerContenido(ID_NOMBRE_ANIO)
                Case ID_MEMORANDUM_P1
                    lblParrafo01.Text = cn.Cn_ObtenerContenido(ID_MEMORANDUM_P1)
                Case ID_MEMORANDUM_P2
                    lblParrafo02.Text = cn.Cn_ObtenerContenido(ID_MEMORANDUM_P2)
                Case ID_LOGO_MEMORANDUM
                    Await CargarLogoAsync()
            End Select
        Catch ex As Exception
            clsBasicas.controlException("ERROR AL CARGAR LOS DATOS", ex)
        End Try
    End Sub

    Private Sub btnEditarLogo_Click(sender As Object, e As EventArgs) Handles btnEditarLogo.Click
        Dim f As New FrmMantenimientoLogo()
        f.configuracionId = ID_LOGO_MEMORANDUM
        f.frmPadre = Me
        f.ShowDialog()
    End Sub
End Class