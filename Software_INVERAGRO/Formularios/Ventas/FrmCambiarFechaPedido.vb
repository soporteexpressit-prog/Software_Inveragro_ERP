Imports CapaNegocio
Imports CapaObjetos

Public Class FrmCambiarFechaPedido
    Public _codigo As Integer
    Private cn As New cnVentas()

    ' Permitir recibir la fecha desde el formulario llamador
    Public FechaPedido As Nullable(Of Date) = Nothing

    Private Sub FrmCambiarFechaPedido_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ' Si la fecha fue pasada por el formulario padre, usarla y evitar consulta
            If FechaPedido.HasValue Then
                dtpedido.Value = FechaPedido.Value
                Return
            End If

            ' Si no se pasó la fecha, intentar cargar desde la BD si se proporcionó el código
            If _codigo <= 0 Then
                dtpedido.Value = Now
                Return
            End If

            Dim obj As New coVentas
            obj.Codigo = _codigo
            Dim tb As DataTable = cn.Cn_ConsultarxCodigoventa(obj).Copy

            If tb.Rows.Count > 0 Then
                Dim row As DataRow = tb.Rows(0)
                Try
                    ' Intentar obtener por nombre de columna "F.pedido" primero
                    If tb.Columns.Contains("F.pedido") Then
                        dtpedido.Value = Convert.ToDateTime(row("F.pedido"))
                    ElseIf tb.Columns.Count > 0 Then
                        ' Si no existe la columna por nombre, usar la primera columna
                        dtpedido.Value = Convert.ToDateTime(row(0))
                    Else
                        dtpedido.Value = Now
                    End If
                Catch ex As Exception
                    ' Si ocurre error al convertir, dejar la fecha actual y reportar
                    dtpedido.Value = Now
                    clsBasicas.controlException(Name, ex)
                End Try
            Else
                dtpedido.Value = Now
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtpedido_ValueChanged(sender As Object, e As EventArgs) Handles dtpedido.ValueChanged
        ' Mostrar la fecha seleccionada en el título del formulario para confirmación visual
        Try
            Me.Text = $"CAMBIAR FECHA - {dtpedido.Value.ToString("dd/MM/yyyy HH:mm")}"
        Catch
            ' Ignorar cualquier error de formateo
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            Dim obj As New coVentas
            obj.Codigo = _codigo
            obj.Fpedido = dtpedido.Value
            Dim MensajeBgWk As String = ""
            MensajeBgWk = cn.Cn_RegPedidoVentaCerdoupdatefecha(obj)
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
End Class