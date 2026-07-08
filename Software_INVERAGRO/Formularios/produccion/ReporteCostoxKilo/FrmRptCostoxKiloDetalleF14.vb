Imports System.ComponentModel
Imports CapaNegocio
Imports CapaObjetos

Public Class FrmRptCostoxKiloDetalleF14
    Dim cn As New cnControlAnimal
    Dim ds As New DataSet
    Public idDetalle As String
    Public idCampaña As Integer
    Public idRacion As Integer

    Private Sub FrmRptCostoxKiloDetalleF14_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BloquearControladores()
        Ptbx_Cargando.Visible = True
        BarraOpciones.Enabled = False
    End Sub

    Private Sub DesbloquearControladores()
        Ptbx_Cargando.Visible = False
        BarraOpciones.Enabled = True
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            BloquearControladores()

            Dim obj As New coControlAnimal With {
                .IdCampaña = idCampaña,
                .IdProducto = idRacion
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlAnimal = CType(e.Argument, coControlAnimal)
            ds = cn.Cn_CostoxKiloLechonRP20Detallado(obj).Copy
            e.Result = ds
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        DesbloquearControladores()
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            Dim dsResult As DataSet = CType(e.Result, DataSet)
            If dsResult Is Nothing OrElse dsResult.Tables.Count < 2 Then Return

            Dim dtResult As DataTable = dsResult.Tables(0)
            Dim dtResult1 As DataTable = dsResult.Tables(1)

            If dtResult1.Rows.Count > 0 Then
                LblRacion.Text = dtResult1.Rows(0)("Producto").ToString()
                LblTotalAlimento.Text = If(IsDBNull(dtResult1.Rows(0)("Total Alimento (kg)")), "0.00", Convert.ToDecimal(dtResult1.Rows(0)("Total Alimento (kg)")).ToString("N2"))
                LblPrecioKiloProm.Text = If(IsDBNull(dtResult1.Rows(0)("Precio x Kilo Promedio")), "0.0000", Convert.ToDecimal(dtResult1.Rows(0)("Precio x Kilo Promedio")).ToString("N4"))
                LblTotalVendidos.Text = If(IsDBNull(dtResult1.Rows(0)("Total Vendidos")), "0", dtResult1.Rows(0)("Total Vendidos").ToString())
                LblConsumoCabeza.Text = If(IsDBNull(dtResult1.Rows(0)("Consumo x Cabeza (kg)")), "0.0000", Convert.ToDecimal(dtResult1.Rows(0)("Consumo x Cabeza (kg)")).ToString("N4"))
                LblCostoxCabeza.Text = If(IsDBNull(dtResult1.Rows(0)("Costo x Cabeza (S/.)")), "0.0000", Convert.ToDecimal(dtResult1.Rows(0)("Costo x Cabeza (S/.)")).ToString("N4"))
            Else
                LblRacion.Text = "No data"
                LblTotalAlimento.Text = "0.00"
                LblPrecioKiloProm.Text = "0.00"
                LblTotalVendidos.Text = "0"
                LblConsumoCabeza.Text = "0.00"
                LblCostoxCabeza.Text = "0.00"
            End If
        End If
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class