Imports System.IO
Imports CapaNegocio
Imports CapaObjetos

Public Class FrmMantHistoricoEnfermedades

    Dim cn As New cnControlMedico
    Dim codEnfermedad As Integer = 0
    Public operacion As Integer = 0
    Public codigo As Integer = 0
    Public idUbicacion As Integer = 0
    Public idArea As Integer = 0
    Public idEnfermedad As Integer = 0
    Public enfermedad As String = ""
    Public idProtocoloSanitario As Integer = 0
    Public costoPrograma As String = ""
    Public metodo As String = ""
    Public fecha As Date = Now.Date
    Public nombreComercialVacuna As String = ""

    Private Sub FrmMantHistoricoEnfermedades_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ListarPlanteles()
            ListarAreas()
            Inicializar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()

        TxtArchivo.ReadOnly = True
        TxtEnfermedad.ReadOnly = True

        If operacion = 0 Then
            DtpFechaHistorico.Value = Now.Date
            TxtCostoPrograma.Text = "0"
        ElseIf operacion = 1 Then
            DtpFechaHistorico.Value = Now.Date
            If costoPrograma = "PENDIENTE" Then
                TxtCostoPrograma.Text = "0"
            Else
                TxtCostoPrograma.Text = costoPrograma
            End If
            CmbUbicacion.Value = idUbicacion
            cmbArea.Value = idArea
            codEnfermedad = idEnfermedad
            TxtEnfermedad.Text = enfermedad
            TxtObservacion.Text = metodo
            DtpFechaHistorico.Value = fecha
            TxtNombreComercialVacuna.Text = nombreComercialVacuna
        End If
    End Sub

    Private Sub BtnBuscarEnfermedad_Click(sender As Object, e As EventArgs) Handles BtnBuscarEnfermedad.Click
        Try
            Dim f As New FrmListarEnfermedadesCerdoHE(Me)
            f.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnarchivoadjunto_Click(sender As Object, e As EventArgs) Handles btnarchivoadjunto.Click
        Dim openFileDialog As New OpenFileDialog()

        openFileDialog.Filter = "Archivos PDF (*.pdf)|*.pdf"
        openFileDialog.Title = "Seleccionar archivo PDF"
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Dim selectedFilePath As String = openFileDialog.FileName
            TxtArchivo.Text = selectedFilePath
        End If
    End Sub

    Sub ListarPlanteles()
        Dim cn As New cnUbicacion
        Dim tb As New DataTable
        tb = cn.Cn_ListarPlanteles().Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione un Plantel"
        With CmbUbicacion
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
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

    Public Sub LlenarCamposEnfermedad(codigo As Integer, descripcion As String)
        codEnfermedad = codigo
        TxtEnfermedad.Text = descripcion
    End Sub
    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Close()
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            If DtpFechaHistorico.Value > Now.Date Then
                msj_advert("La fecha de registro no puede ser mayor a la fecha actual.")
                DtpFechaHistorico.Value = Now.Date
                Return
            End If

            If codEnfermedad = 0 Then
                msj_advert("Debe seleccionar una enfermedad.")
                Return
            End If

            If String.IsNullOrEmpty(TxtObservacion.Text) Then
                msj_advert("Debe ingresar un método.")
                TxtObservacion.Focus()
                Return
            End If

            If TxtCostoPrograma.Text.Length = 0 Then
                msj_advert("El costo del programa no puede estar vacío.")
                TxtCostoPrograma.Focus()
                Return
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE REGISTRAR EL HISTORIAL DE GRANJA PARA ESTA ENFERMEDAD?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coControlMedico With {
                .IdUbicacion = CmbUbicacion.Value,
                .IdArea = cmbArea.Value,
                .IdEnfermedad = codEnfermedad,
                .FechaControl = DtpFechaHistorico.Value,
                .Observacion = TxtObservacion.Text.Trim(),
                .Operacion = operacion,
                .Codigo = codigo,
                .IdUsuario = VP_IdUser,
                .CostoPrograma = TxtCostoPrograma.Text,
                .NombreVacunaComercial = TxtNombreComercialVacuna.Text.Trim()
            }

            If Not String.IsNullOrEmpty(TxtArchivo.Text) Then
                Dim fileInfo As New FileInfo(TxtArchivo.Text)
                If fileInfo.Length > 400 * 1024 Then
                    msj_advert("El archivo excede el tamaño máximo permitido de 400 kB.")
                    Return
                End If
                Dim pdfData As Byte() = File.ReadAllBytes(TxtArchivo.Text)
                obj.SetArchivo(pdfData)
            End If

            Dim mensaje As String = cn.Cn_MantenimientoHistoricoEnfermedades(obj)
            If (obj.Coderror = 0) Then
                msj_ok(mensaje)
                Close()
            Else
                msj_advert(mensaje)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub TxtCostoPrograma_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCostoPrograma.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

End Class