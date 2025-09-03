Imports CapaNegocio
Imports CapaObjetos

Public Class FrmMantPersonalProduccion
    Dim cn As New cnTrabajador
    Public idPersonaProduccion As Integer = 0
    Public operacion As Integer = 0
    Public dni As String = ""
    Public nombre As String = ""
    Public idCargo As Integer = 0
    Public estado As String = ""

    Private Sub FrmMantPersonalProduccion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ListarCargos()
            TxtDniEncargado.ReadOnly = True
            TxtNombreEncargado.ReadOnly = True
            CmbEstadoPersonal.SelectedIndex = 0
            CmbEstadoPersonal.Enabled = False

            If operacion = 1 Then
                TxtDniEncargado.Text = dni
                TxtNombreEncargado.Text = nombre
                CmbCargo.Value = idCargo
                CmbEstadoPersonal.Text = If(estado = "A", "ACTIVO", "INACTIVO")
                CmbEstadoPersonal.Enabled = True
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Public Sub LlenarCamposPersonalProduccion(codigo As Integer, numDocumento As String, datos As String)
        idPersonaProduccion = codigo
        TxtDniEncargado.Text = numDocumento
        TxtNombreEncargado.Text = datos
    End Sub

    Private Sub BtnPersonalProduccion_Click(sender As Object, e As EventArgs) Handles BtnPersonalProduccion.Click
        Try
            Dim frm As New FrmListarPersonalActivoProduccion(Me)
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ListarCargos()
        Dim tb As New DataTable
        tb = cn.Cn_ConsultarCargosProduccion().Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione un Cargo"
        With CmbCargo
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Private Sub btnGuardarPcorr_Click(sender As Object, e As EventArgs) Handles btnGuardarPcorr.Click
        Try
            If (idPersonaProduccion = 0) Then
                msj_advert("Seleccione un Solicitante")
                Return
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE LA ASIGNACIÓN?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coTrabajador With {
                .Operacion = operacion,
                .IdPersona = idPersonaProduccion,
                .IdCargo = CmbCargo.Value,
                .Estado = If(CmbEstadoPersonal.Text = "ACTIVO", "A", "I")
            }

            Dim MensajeBgWk As String = cn.Cn_MantPersonalProduccion(obj)
            If (obj.Coderror = 0) Then
                msj_ok(MensajeBgWk)
                Dispose()
            Else
                msj_advert(MensajeBgWk)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class