Imports System.IO
Imports CapaNegocio
Imports CapaObjetos

Public Class FrmHistoricoOrdenesAtendidas
    Dim cn As New cnIngreso
    Dim ds As New DataSet

    Private Sub FrmHistoricoRecepcion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Consultar()
        clsBasicas.Formato_Tablas_Grid(dtgListado)
    End Sub
    Private Sub Consultar()
        Dim obj As New coIngreso
        obj.Codigo = CInt(lblCodigo.Text)
        ds = cn.Cn_ConsultarAtencionesOrdenesCompra(obj).Copy

        ds.DataSetName = "tmp"

        dtgListado.DataSource = ds

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try



            With e.Layout.Bands(0)

                .Columns(6).Hidden = True
            End With
            e.Layout.Bands(0).Summaries.Clear()
            clsBasicas.Totales_Formato(dtgListado, e, 1)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
End Class