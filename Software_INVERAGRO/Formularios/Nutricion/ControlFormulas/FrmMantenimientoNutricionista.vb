Imports CapaDatos
Imports CapaNegocio
Imports CapaObjetos

Public Class FrmMantenimientoNutricionista
    Dim cn As New cnNucleo
    Private _CodNutricionista As Integer
    Dim _Operacion As Integer

    Sub Nuevo()
        _Operacion = 0
        Cambio()
        limpiar()
    End Sub

    Sub limpiar()
        TxtDescripcion.Text = ""
        TxtDescripcion.Select()
        _CodNutricionista = 0
    End Sub

    Sub Cambio()
        BtnNuevoNutricionista.Visible = False
        BtnEditarNutricionista.Visible = False
        BtnGuardarNutricionista.Visible = True
        BtnCancelarNutricionista.Visible = True
        TxtDescripcion.Enabled = True
    End Sub
    Sub Cancelar()
        BtnNuevoNutricionista.Visible = True
        BtnEditarNutricionista.Visible = True
        BtnGuardarNutricionista.Visible = False
        BtnCancelarNutricionista.Visible = False
        TxtDescripcion.Clear()
        txtDescripcion.Enabled = False
    End Sub

    Private Sub FrmMantenimientoNutricionista_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Cancelar()
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Consultar()
        dtgListado.DataSource = cn.Cn_ConsultarNutricionista()
        dtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True
    End Sub

    Sub Mantenimiento()
        Try
            Dim _mensaje As String = ""
            If (_Operacion = 1 OrElse _Operacion = 2) AndAlso (_CodNutricionista = 0) Then
                msj_advert("Seleccione un Registro")
                Return
            End If
            If (_Operacion = 0 OrElse _Operacion = 1) AndAlso (TxtDescripcion.Text = "" OrElse TxtDescripcion.Text.Length = 0) Then
                msj_advert("Descripción no Valida")
                Return
            End If

            Dim obj As New coNucleo With {
                .Operacion = _Operacion,
                .Codigo = _CodNutricionista,
                .Descripcion = TxtDescripcion.Text
            }

            _mensaje = cn.Cn_MantenimientoNutricionista(obj)
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

    Private Sub BtnNuevoNutricionista_Click(sender As Object, e As EventArgs) Handles BtnNuevoNutricionista.Click
        Nuevo()
    End Sub

    Private Sub BtnEditarNutricionista_Click(sender As Object, e As EventArgs) Handles BtnEditarNutricionista.Click
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                _Operacion = 1
                Cambio()
                _CodNutricionista = CInt(dtgListado.DisplayLayout.ActiveRow.Cells(0).Value.ToString)
                TxtDescripcion.Text = dtgListado.DisplayLayout.ActiveRow.Cells(1).Value.ToString
                TxtDescripcion.Focus()
            Else
                msj_advert("Seleccione un Registro")
            End If
        Else
            msj_advert("Seleccione un Registro")
        End If
    End Sub

    Private Sub BtnGuardarNutricionista_Click(sender As Object, e As EventArgs) Handles BtnGuardarNutricionista.Click
        Mantenimiento()
    End Sub

    Private Sub BtnCancelarNutricionista_Click(sender As Object, e As EventArgs) Handles BtnCancelarNutricionista.Click
        Cancelar()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class