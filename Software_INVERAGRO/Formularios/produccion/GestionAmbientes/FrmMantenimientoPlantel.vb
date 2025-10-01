Imports CapaDatos
Imports CapaNegocio
Imports CapaObjetos

Public Class FrmMantenimientoPlantel
    Dim cn As New cnUbicacion
    Public _IdUbicacion As Integer = 0
    Private _Operacion As Integer = 0

    Private Sub FrmMantenimientoPlantel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            If (_IdUbicacion <> 0) Then
                _Operacion = 1
                ConsultarxIdUbicacion()
            Else
                _Operacion = 0
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        TxtDescripcion.Clear()
        NumChanchillas.Value = 0
        TxtDensidad.Clear()
        CmbClasificacion.SelectedIndex = 0
        TxtDireccion.Clear()
    End Sub

    Sub ConsultarxIdUbicacion()
        Try
            Dim obj As New coUbicacion With {
                .Codigo = _IdUbicacion
            }
            Dim dt As New DataTable
            dt = cn.Cn_ConsultarxId(obj).Copy
            If (dt.Rows.Count > 0) Then
                TxtDescripcion.Text = dt.Rows(0)("descripcion").ToString()
                CmbClasificacion.Text = dt.Rows(0)("clasificacion").ToString()
                NumChanchillas.Value = CInt(dt.Rows(0)("numChachillas").ToString())
                TxtDensidad.Text = CDec(dt.Rows(0)("densidadxCorral").ToString()).ToString("F3")
                TxtDireccion.Text = dt.Rows(0)("direccion").ToString()
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnGuardarPcorr_Click(sender As Object, e As EventArgs) Handles btnGuardarPcorr.Click
        Mantenimiento()
    End Sub

    Sub Mantenimiento()
        Try
            If (_Operacion = 0 OrElse _Operacion = 1) AndAlso (TxtDescripcion.Text = "" OrElse TxtDescripcion.Text.Length = 0) Then
                msj_advert("Descripción no Valida")
                Return
            End If

            If NumChanchillas.Value <= 0 Then
                msj_advert("Número de Chanchillas no Valida")
                Return
            End If

            If (TxtDensidad.Text = "" OrElse TxtDensidad.Text.Length = 0) Then
                msj_advert("Densidad no Válida")
                Return
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE ESTA ACCIÓN?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coUbicacion With {
                .Operacion = _Operacion,
                .Codigo = _IdUbicacion,
                .Descripcion = TxtDescripcion.Text,
                .Densidad = CDec(TxtDensidad.Text),
                .NumChanchillas = NumChanchillas.Value,
                .Direccion = TxtDireccion.Text,
                .Clasificacion = CmbClasificacion.Text,
                .Iduser = VP_IdUser
            }

            Dim _mensaje As String = cn.Cn_MantenimientoPlanteles(obj)
            If (obj.Coderror = 0) Then
                msj_ok(_mensaje)
                Dispose()
            Else
                msj_advert(_mensaje)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class