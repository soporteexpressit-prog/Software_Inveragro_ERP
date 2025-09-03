Imports CapaNegocio
Imports CapaObjetos

Public Class FrmMantPremixero
    Dim cn As New cnControlPremixero
    Private _CodPremixero As Integer
    Dim _Operacion As Integer
    Sub Nuevo()
        _Operacion = 0
        Cambio()
        limpiar()
    End Sub

    Sub limpiar()
        txtCodigo.Text = ""
        txtDescripcion.Text = ""
        txtDescripcion.Select()
        _CodPremixero = 0
    End Sub

    Sub Cambio()
        btnNuevo.Visible = False
        btnEditar.Visible = False
        btnGuardar.Visible = True
        btnCancelar.Visible = True
        txtDescripcion.Enabled = True
        cmbEstado.Enabled = True
    End Sub

    Sub Cancelar()
        btnNuevo.Visible = True
        btnEditar.Visible = True
        btnGuardar.Visible = False
        btnCancelar.Visible = False
        txtCodigo.Clear()
        txtCodigo.Enabled = False
        txtDescripcion.Clear()
        txtDescripcion.Enabled = False
        cmbEstado.SelectedIndex = 0
        cmbEstado.Enabled = False
    End Sub

    Private Sub FrmMantPremixero_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cancelar()
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        Consultar()
    End Sub

    Sub Consultar()
        dtgListado.DataSource = cn.Cn_ListarPremixero()
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "INACTIVO", 3)
        clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ACTIVO", 3)
    End Sub

    Sub Mantenimiento()
        Try
            Dim _mensaje As String = ""
            If (_Operacion = 1 OrElse _Operacion = 2) AndAlso (txtCodigo.Text = "" OrElse txtCodigo.Text.Length = 0) Then
                msj_advert("Seleccione un Registro")
                Return
            End If
            If (_Operacion = 0 OrElse _Operacion = 1) AndAlso (txtDescripcion.Text = "" OrElse txtDescripcion.Text.Length = 0) Then
                msj_advert("Descripción no Valida")
                Return
            End If
            Dim obj As New coControlPremixero
            obj.Operacion = _Operacion
            obj.IdPremixero = _CodPremixero
            obj.Descripcion = txtDescripcion.Text
            obj.EstadoPremixero = cmbEstado.Text

            _mensaje = cn.Cn_MantenimientoPremixero(obj)
            If (obj.Coderror = 0) Then
                msj_ok(_mensaje)
                Cancelar()
                Consultar()
            Else
                msj_advert(_mensaje)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Nuevo()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                _Operacion = 1
                Cambio()
                _CodPremixero = CInt(dtgListado.DisplayLayout.ActiveRow.Cells(0).Value.ToString)
                txtCodigo.Text = _CodPremixero.ToString
                txtDescripcion.Text = dtgListado.DisplayLayout.ActiveRow.Cells(1).Value.ToString
                txtDescripcion.Focus()
                cmbEstado.Text = dtgListado.DisplayLayout.ActiveRow.Cells(3).Value.ToString
            Else
                msj_advert("Seleccione un Registro")
            End If
        Else
            msj_advert("Seleccione un Registro")
        End If
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Cancelar()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Mantenimiento()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class