Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmRegistrarPesoBajada
    Dim cn As New cnControlLoteDestete
    Dim cantAnimalesBajada As Integer = 0
    Public cantidadAnimales As Integer = 0
    Public idLote As Integer = 0
    Public idPlantelSalida As Integer = 0

    Private Sub FrmRegistrarPesoBajada_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            TxtPesoTotal.ReadOnly = True
            TxtPesoPromedio.ReadOnly = True
            LblNumAnimales.Text = cantidadAnimales.ToString
            ConsultarxIdLote()
            clsBasicas.Formato_Tablas_Grid(dtgListado)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ConsultarxIdLote()
        Try
            Dim obj As New coControlLoteDestete With {
                .IdLote = idLote,
                .TipoFiltro = "BAJADA",
                .TipoBajada = "BAJADA"
            }
            Dim dt As New DataTable
            dtgListado.DataSource = cn.Cn_ConsultarPesosBajada(obj).Copy
            dtgListado.DisplayLayout.Bands(0).Columns("idPesoBajada").Hidden = True
            dtgListado.DisplayLayout.Bands(0).Columns("btneliminar").Hidden = True
            CalcularPesoTotalPromedio()
            LblNumRegistros.Text = dtgListado.Rows.Count.ToString()
            cantAnimalesBajada = SumarCantidad()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub CalcularPesoTotalPromedio()
        Dim pesoTotal As Decimal = 0
        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListado.Rows
            If Not row.IsAddRow Then
                pesoTotal += CDec(row.Cells("Peso").Value)
            End If
        Next
        TxtPesoTotal.Text = pesoTotal.ToString("F2")

        If cantidadAnimales > 0 Then
            TxtPesoPromedio.Text = (pesoTotal / cantidadAnimales).ToString("F2")
        Else
            TxtPesoPromedio.Text = "0.00"
        End If
    End Sub

    Private Function SumarCantidad() As Integer
        Dim total As Integer = 0

        If dtgListado IsNot Nothing AndAlso dtgListado.Rows.Count > 0 Then
            For Each fila As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListado.Rows
                If Not fila.IsAddRow AndAlso Not IsDBNull(fila.Cells("cantidad").Value) Then
                    total += CInt(fila.Cells("cantidad").Value)
                End If
            Next
        End If

        Return total
    End Function

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            If (cantAnimalesBajada <> cantidadAnimales) Then
                msj_advert("La cantidad de animales bajados no coincide con la cantidad de animales con pesos registrados.")
                Return
            End If

            If (TxtPesoPromedio.Text = "") Then
                msj_advert("Ingrese el peso promedio")
                Return
            End If

            If (CDec(TxtPesoPromedio.Text) <= 0) Then
                msj_advert("El peso promedio debe ser mayor a 0")
                Return
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DEL PESO TOTAL Y PROMEDIO DE LA BAJADA?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coControlLoteDestete With {
                .IdLote = idLote,
                .PesoTotal = CDec(TxtPesoTotal.Text),
                .PesoPromedio = CDec(TxtPesoPromedio.Text),
                .IdPlantelSalida = idPlantelSalida
            }

            Dim MensajeBgWk As String = cn.Cn_RegistrarPesoBajada(obj)
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

    Private Sub dtgListado_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            If (dtgListado.Rows.Count = 0) Then
            Else
                e.Layout.Bands(0).Summaries.Clear()
                clsBasicas.SumarTotales_Formato(dtgListado, e, 0)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class