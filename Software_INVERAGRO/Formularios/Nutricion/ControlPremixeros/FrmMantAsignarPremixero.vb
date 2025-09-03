Imports CapaNegocio
Imports CapaObjetos

Public Class FrmMantAsignarPremixero
    Dim cn As New cnControlPremixero
    Public _CodAsignacionPremixero As Integer
    Dim _Operacion As Integer = 0
    Dim _IdTrabajador As Integer
    Private Sub FrmMantAsignarPremixero_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Inicializar()
        ListarPremixeros()
    End Sub

    Sub Inicializar()
        txtCodAsignacion.Enabled = False
        txtDatos.Enabled = False
        txtNumDoc.Enabled = False
        cmbEstado.SelectedIndex = 0
        If (_CodAsignacionPremixero > 0) Then
            _Operacion = 1
            cmbEstado.Enabled = True
            Consultar()
        Else
            cmbEstado.Enabled = False
        End If
    End Sub

    Sub ListarPremixeros()
        Dim cn As New cnControlPremixero
        Dim tb As New DataTable
        tb = cn.Cn_ListarPremixeroActivos().Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione una Categoría"
        With cmbTipoPremixero
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Private Sub btnBuscarPremixero_Click(sender As Object, e As EventArgs) Handles btnBuscarPremixero.Click
        Dim f As New FrmListarTrabajadorPremixero(Me)
        f.ShowDialog()
    End Sub

    Public Sub LlenarCamposPremixero(codigo As Integer, nroDoc As String, datos As String)
        _IdTrabajador = codigo
        txtNumDoc.Text = nroDoc
        txtDatos.Text = datos
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Mantenimiento()
    End Sub

    Sub Mantenimiento()
        Try
            Dim _mensaje As String = ""
            If (_Operacion = 1 OrElse _Operacion = 2) AndAlso (txtDatos.Text = "" OrElse txtDatos.Text.Length = 0) Then
                msj_advert("Seleccione un Registro")
                Return
            End If
            Dim obj As New coControlPremixero
            obj.Operacion = _Operacion
            obj.IdAsignacionPremixero = _CodAsignacionPremixero
            obj.EstadoAsignacionPremixero = cmbEstado.Text
            obj.IdUsuario = VP_IdUser
            obj.IdPremixero = cmbTipoPremixero.Value
            obj.IdTrabajador = _IdTrabajador

            _mensaje = cn.Cn_MantenimientoAsignacionPremixero(obj)
            If (obj.Coderror = 0) Then
                msj_ok(_mensaje)
                Me.Close()
            Else
                msj_advert(_mensaje)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Consultar()
        Dim obj As New coControlPremixero
        obj.IdAsignacionPremixero = _CodAsignacionPremixero
        Dim tb As New DataTable
        tb = cn.Cn_ConsultarAsignacionxId(obj).Copy
        tb.TableName = "tmp"

        If tb.Rows.Count > 0 Then
            With tb.Rows(0)
                txtCodAsignacion.Text = .Item(0).ToString()
                cmbTipoPremixero.Text = .Item(1).ToString()
                _IdTrabajador = .Item(2).ToString()
                txtNumDoc.Text = .Item(3).ToString()
                txtDatos.Text = .Item(4).ToString()
                cmbEstado.Text = .Item(5).ToString()
            End With
        Else
            MessageBox.Show("No se encontró ningún registro con el código especificado.")
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class