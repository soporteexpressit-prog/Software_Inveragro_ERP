Imports CapaNegocio
Imports CapaObjetos

Public Class FrmAlimentarGrupoDestete
    Dim cn As New cnControlAlimento
    Public nombreGrupo As String = ""
    Public nombreAlimento As String = ""
    Public idLote As Integer = 0
    Public idUbicacion As Integer = 0
    Public idGrupo As Integer = 0
    Public idProducto As Integer = 0

    Private Sub FrmAlimentarGrupoDestete_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LblGrupo.Text = "ALIMENTAR " & nombreGrupo
            ListarDistribucion()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ListarDistribucion()
        Try
            Dim obj As New coControlAlimento With {
                .IdUbicacion = idUbicacion,
                .IdLote = idLote,
                .IdGrupo = idGrupo,
                .IdProducto = idProducto
            }
            Dim dt As DataTable = cn.Cn_ListarxUbicacionLoteGrupoProducto(obj)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Dim row As DataRow = dt.Rows(0)

                LblAlimento.Text = row("Ración").ToString()

                Dim stockDiferencia As Decimal = 0
                Dim stockConsumidoGrupo As Decimal = 0

                If Not IsDBNull(row("stockDiferencia")) Then
                    Decimal.TryParse(row("stockDiferencia").ToString(), stockDiferencia)
                End If

                If Not IsDBNull(row("stockConsumidoGrupo")) Then
                    Decimal.TryParse(row("stockConsumidoGrupo").ToString(), stockConsumidoGrupo)
                End If

                LblStockAlimento.Text = stockDiferencia.ToString("N2")
                LblConsumoAlimento.Text = stockConsumidoGrupo.ToString("N2")
            Else
                LblAlimento.Text = "-"
                LblStockAlimento.Text = "0.00"
                LblConsumoAlimento.Text = "0.00"
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            If DtpFecha.Value.Date > Date.Now.Date Then
                msj_advert("La fecha de bajada no puede ser mayor a la fecha actual")
                DtpFecha.Value = Date.Now.Date
                Return
            End If

            If String.IsNullOrWhiteSpace(TxtCantidadAlimento.Text) Then
                msj_advert("Por favor, ingrese una cantidad")
                TxtCantidadAlimento.Select()
                Return
            ElseIf CDec(TxtCantidadAlimento.Text) = 0 Then
                msj_advert("Por Favor Ingrese una cantidad")
                TxtCantidadAlimento.Select()
                Return
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE REGISTRAR ALIMENTO?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coControlAlimento With {
                .IdLote = idLote,
                .FechaControl = DtpFecha.Value,
                .IdUbicacion = idUbicacion,
                .Cantidad = CDec(TxtCantidadAlimento.Text),
                .IdGrupo = idGrupo,
                .IdProducto = idProducto
            }

            Dim MensajeBgWk As String = cn.Cn_RegistrarAlimentacionPresupuesto(obj)
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

    Private Sub TxtCantidadAlimento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCantidadAlimento.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class