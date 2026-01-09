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
    Public stockDisponible As Decimal = 0
    Public unidadMedida As String = ""
    Public idUnidadMedida As Integer = 0

    ' Propiedad para indicar si se guardó exitosamente
    Public Property GuardadoExitoso As Boolean = False

    Private Sub FrmAlimentarGrupoDestete_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LblGrupo.Text = "ALIMENTAR " & nombreGrupo
            CmbTipoAlimento.SelectedIndex = 0
            ListarDistribucion()
            ListarAreas()
            cmbArea.Value = 3 'Recria 
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
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

                'Dim stockDiferencia As Decimal = 0
                Dim stockConsumidoGrupo As Decimal = 0

                'If Not IsDBNull(row("stockDiferencia")) Then
                '    Decimal.TryParse(row("stockDiferencia").ToString(), stockDiferencia)
                'End If

                If Not IsDBNull(row("stockConsumidoGrupo")) Then
                    Decimal.TryParse(row("stockConsumidoGrupo").ToString(), stockConsumidoGrupo)
                End If

                'LblStockAlimento.Text = stockDiferencia.ToString("N2")
                CalcularKilogramos(idUnidadMedida)
                LblConsumoAlimento.Text = (stockConsumidoGrupo * 1000).ToString("N2") 'Convertimos a Kg
            Else
                LblAlimento.Text = "-"
                LblStockAlimento.Text = "0.00"
                LblConsumoAlimento.Text = "0.00"
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub CalcularKilogramos(idUnidadMedida As Integer)
        Try
            Dim idUnidadMedidaKg As Integer = 6
            Dim idUnidadMedidaTonelada As Integer = 3

            If idUnidadMedida = idUnidadMedidaKg Then
                LblStockAlimento.Text = stockDisponible.ToString("0.00")
                Return
            End If

            If Not String.IsNullOrEmpty(LblStockAlimento.Text) AndAlso IsNumeric(LblStockAlimento.Text) Then
                Dim cantidadKilogramos As Decimal = stockDisponible * 1000D ' 1 tonelada = 1000 kg
                LblStockAlimento.Text = cantidadKilogramos.ToString("0.00") ' Aquí podrías renombrar el control si ya no son sacos
            Else
                LblStockAlimento.Text = "0.00"
            End If
        Catch ex As Exception
            msj_advert("Error al calcular los kilogramos: " & ex.Message)
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

            If CDec(TxtCantidadAlimento.Text) > CDec(LblStockAlimento.Text) Then
                msj_advert("La cantidad ingresada supera el stock disponible")
                TxtCantidadAlimento.Select()
                Return
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE REGISTRAR ALIMENTO?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim cantidadEnKg As Decimal = ValidarDecimal(TxtCantidadAlimento.Text)
            Dim cantidadEnToneladas As Decimal = Math.Round(cantidadEnKg / 1000D, 5)

            Dim obj As New coControlAlimento With {
                .IdLote = idLote,
                .FechaControl = DtpFecha.Value,
                .IdUbicacion = idUbicacion,
                .Cantidad = cantidadEnToneladas,
                .IdGrupo = idGrupo,
                .IdProducto = idProducto,
                .IdArea = CInt(cmbArea.Value),
                .TipoAlimento = CmbTipoAlimento.Text,
                .IdUsuario = VP_IdUser
            }

            Dim MensajeBgWk As String = cn.Cn_RegistrarAlimentacionPresupuesto(obj)
            If (obj.Coderror = 0) Then
                GuardadoExitoso = True ' Marcar como guardado exitosamente
                msj_ok(MensajeBgWk)
                Dispose()
            Else
                GuardadoExitoso = False ' Marcar como no guardado
                msj_advert(MensajeBgWk)
            End If
        Catch ex As Exception
            GuardadoExitoso = False ' En caso de excepción, marcar como no guardado
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Function ValidarDecimal(valorTexto As String) As Decimal
        Dim textoLimpio As String = valorTexto.Trim()

        If textoLimpio.EndsWith(".") Then
            textoLimpio &= "0"
        End If

        Return CDec(textoLimpio)
    End Function

    Private Sub TxtCantidadAlimento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCantidadAlimento.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class