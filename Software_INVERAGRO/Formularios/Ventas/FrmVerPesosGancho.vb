Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmVerPesosGancho
    Public _codigo As Integer
    Sub Consultar()
        Dim obj As New coVentas
        Dim cn As New cnVentas
        obj.Codigo = _codigo
        Dim ds As New DataSet
        ds = cn.Cn_ConsultarPesosGancho(obj).Copy
        dtgListado.DataSource = ds




        Dim total As Decimal = 0
        Dim conteo As Decimal = 0

        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListado.Rows
            If Not row.Cells(2).Value Is Nothing AndAlso IsNumeric(row.Cells(2).Value) Then
                total += Convert.ToDecimal(row.Cells(2).Value)
                conteo += Convert.ToDecimal(row.Cells(3).Value)
            End If
        Next

        txttotalpesogancho.Text = total.ToString("F2")
        txtnumcerdos.Text = CInt(conteo).ToString()

        If dtgListado.Rows.Count > 0 Then
            txtpesopromedio.Text = (total / conteo).ToString("F2")
        Else
            txtpesopromedio.Text = "0.0000"
        End If

    End Sub
    Private Sub FrmVerPesosGancho_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Consultar()
        clsBasicas.Formato_Tablas_Grid(dtgListado)
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try

            With e.Layout.Bands(0)
                .Columns(1).Hidden = True
                .Columns(0).Hidden = True
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
End Class