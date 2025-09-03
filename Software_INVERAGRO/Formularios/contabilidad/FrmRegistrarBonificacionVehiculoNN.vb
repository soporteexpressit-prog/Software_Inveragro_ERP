Imports System.IO
Imports CapaNegocio
Imports CapaObjetos

Public Class FrmRegistrarBonificacionVehiculoNN
    Dim cn As New cnControlBonificacionVehiculoNN
    Dim _CodActivo As Integer

    Private Sub FrmRegistrarBonificacionVehiculoNN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtNumSerie.Enabled = False
        txtDescripcion.Enabled = False
        dtfechaResolucion.Value = Now.Date
        dtfechaInicio.Value = Now.Date
        dtfechaFin.Value = Now.Date
        dtfechaApertura.Value = Now.Date
        txtArchivoBonificacion.Enabled = False
        txtArchivoExpediente.Enabled = False
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dispose()
    End Sub

    Private Sub btnGuardarActivo_Click(sender As Object, e As EventArgs) Handles btnGuardarActivo.Click
        Mantenimiento()
    End Sub

    Private Sub btnBuscarActivo_Click(sender As Object, e As EventArgs) Handles btnBuscarActivo.Click
        Dim f As New FrmListarActivoBonificacion(Me)
        f.ShowDialog()
    End Sub
    Public Sub LlenarCamposActivo(codigo As Integer, numDocumento As String, datos As String)
        _CodActivo = codigo
        txtNumSerie.Text = numDocumento
        txtDescripcion.Text = datos
    End Sub

    Sub Mantenimiento()
        Try
            Dim _mensaje As String = ""
            If (txtNumPermiso.Text = "" OrElse txtNumPermiso.Text.Length = 0) Then
                msj_advert("Número de permiso no válido")
                Return
            ElseIf (txtNumResolucion.Text = "" OrElse txtNumResolucion.Text.Length = 0) Then
                msj_advert("Nro de resolución no Valida")
                Return
            ElseIf (txtNumExpediente.Text = "" OrElse txtNumExpediente.Text.Length = 0) Then
                msj_advert("Nro de expediente no Valida")
                Return
            ElseIf dtfechaApertura.Value < dtfechaResolucion.Value Then
                msj_advert("La fecha de apertura no puede ser menor a la fecha de resolución")
                Return
            ElseIf dtfechaFin.Value < dtfechaInicio.Value Then
                msj_advert("La fecha de fin no puede ser menor a la fecha de inicio")
                Return
            ElseIf (txtNumSerie.Text = "" OrElse txtNumSerie.Text.Length = 0) Then
                msj_advert("Ingrese el Activo que recibira la bonificación")
                Return
            End If

            Dim obj As New coControlBonificacionVehiculoNN
            obj.NumPermiso = txtNumPermiso.Text
            obj.NumResolucion = txtNumResolucion.Text
            obj.FechaResolucion = dtfechaResolucion.Value
            obj.FechaInicio = dtfechaInicio.Value
            obj.FechaFin = dtfechaFin.Value
            If Not String.IsNullOrEmpty(txtArchivoBonificacion.Text) Then
                Dim fileInfo As New FileInfo(txtArchivoBonificacion.Text)
                If fileInfo.Length > 400 * 1024 Then
                    msj_advert("El archivo excede el tamaño máximo permitido de 400 kB.")
                    Return
                End If
                Dim pdfData As Byte() = File.ReadAllBytes(txtArchivoBonificacion.Text)
                obj.SetArchivoResolucion(pdfData)
            End If
            obj.NumExpediente = txtNumExpediente.Text
            obj.FechaApertura = dtfechaApertura.Value
            If Not String.IsNullOrEmpty(txtArchivoExpediente.Text) Then
                Dim fileInfo As New FileInfo(txtArchivoExpediente.Text)
                If fileInfo.Length > 400 * 1024 Then
                    msj_advert("El archivo excede el tamaño máximo permitido de 400 kB.")
                    Return
                End If
                Dim pdfData As Byte() = File.ReadAllBytes(txtArchivoExpediente.Text)
                obj.SetArchivoExpediente(pdfData)
            End If
            obj.Iduser = VP_IdUser
            obj.IdActivo = _CodActivo

            Dim result As DialogResult = MessageBox.Show("¿Está seguro de que desea confirmar los datos ingresados? Esta acción es irreversible y no podrá deshacer los cambios.", "Confirmar Anulación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If result = DialogResult.Yes Then
                _mensaje = cn.Cn_Registrar(obj)
                If (obj.Coderror = 0) Then
                    msj_ok(_mensaje)
                    Dispose()
                Else
                    msj_advert(_mensaje)
                End If
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnSubirArchivoResolucion_Click(sender As Object, e As EventArgs) Handles btnSubirArchivoResolucion.Click
        Dim openFileDialog As New OpenFileDialog()

        openFileDialog.Filter = "Archivos PDF|*.pdf|Todos los archivos|*.*"
        openFileDialog.Title = "Selecciona un archivo PDF"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Dim selectedFilePath As String = openFileDialog.FileName
            txtArchivoBonificacion.Text = selectedFilePath
        End If
    End Sub

    Private Sub btnSubirArchivoExpediente_Click(sender As Object, e As EventArgs) Handles btnSubirArchivoExpediente.Click
        Dim openFileDialog As New OpenFileDialog()

        openFileDialog.Filter = "Archivos PDF|*.pdf|Todos los archivos|*.*"
        openFileDialog.Title = "Selecciona un archivo PDF"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Dim selectedFilePath As String = openFileDialog.FileName
            txtArchivoExpediente.Text = selectedFilePath
        End If
    End Sub
End Class