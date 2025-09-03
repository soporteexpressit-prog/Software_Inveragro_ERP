Imports CapaDatos
Imports CapaNegocio
Imports CapaObjetos

Public Class FrmMantenimientoParametroProduccion
    Dim cn As New cnConfiguracion
    Private idConfiguracion As Integer

    Sub Nuevo()
        Cambio()
        limpiar()
    End Sub

    Sub Limpiar()
        TxtValor.Text = ""
        TxtValor.Select()
        idConfiguracion = 0
    End Sub

    Sub Cambio()
        BtnCancelar.Visible = True
        TxtValor.ReadOnly = False
    End Sub
    Sub Cancelar()
        BtnCancelar.Visible = False
        TxtValor.Clear()
        TxtValor.ReadOnly = True
        TxtDescripcion.ReadOnly = True
    End Sub

    Private Sub FrmMantenimientoParametroProduccion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cancelar()
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        Consultar()
    End Sub

    Sub Mantenimiento()
        Try
            If TxtValor.Text.Length = 0 Then
                msj_advert("ingrese un valor")
                Return
            End If

            Dim obj As New coConfiguracion With {
                .IdConfiguracion = idConfiguracion,
                .Valor = TxtValor.Text
            }

            Dim _mensaje As String = cn.Cn_ActualizarParametroProduccion(obj)

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

    Sub Consultar()
        Try
            dtgListado.DataSource = cn.Cn_ListarParametroProduccion()
            dtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnEditar_Click(sender As Object, e As EventArgs) Handles btneditarproparametro.Click
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                Cambio()
                idConfiguracion = CInt(dtgListado.DisplayLayout.ActiveRow.Cells(0).Value.ToString)
                TxtDescripcion.Text = dtgListado.DisplayLayout.ActiveRow.Cells(1).Value.ToString
                TxtValor.Text = dtgListado.DisplayLayout.ActiveRow.Cells(2).Value.ToString
                TxtValor.Focus()
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Cancelar()
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardareditarproparametro.Click
        Mantenimiento()
    End Sub

    Private Sub TxtValor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtValor.KeyPress
        clsBasicas.ValidarNumeros(e)
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class