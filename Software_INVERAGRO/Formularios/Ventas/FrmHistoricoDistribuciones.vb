Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win.UltraWinGrid
Imports iTextSharp.text.pdf.codec.wmf

Public Class FrmHistoricoDistribuciones
    Dim cn As New cnVentas
    Public codigo As Integer
    Dim ds As New DataSet

    Private Sub UltraGroupBox2_Click(sender As Object, e As EventArgs) Handles UltraGroupBox2.Click
        consultar()
    End Sub

    Sub consultar()
        Try
            Dim obj As New coVentas
            obj.Codigo = codigo
            ds = New DataSet
            ds = cn.Cn_Consultardistrbuciones(obj).Copy

            ' Asignar el DataSet al UltraGrid
            If ds IsNot Nothing AndAlso ds.Tables.Count > 0 Then
                dtgListado.DataSource = ds.Tables(0)
                dtgListado.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
            Else
                ' Limpiar el grid si no hay datos
                dtgListado.DataSource = Nothing
                MessageBox.Show("No se encontraron datos para mostrar.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Error al consultar datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            dtgListado.DataSource = Nothing
        End Try
    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        consultar()
    End Sub

    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Dispose()
    End Sub

    ' Opcional: Método para configurar el grid al cargar el formulario
    Private Sub FrmHistoricoDistribuciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        consultar()
        clsBasicas.Formato_Tablas_Grid_Sin_Ajustar(dtgListado)
    End Sub

    Private Sub btnexportarVmopevetransferenciaventas_Click(sender As Object, e As EventArgs) Handles btnexportarVmopevetransferenciaventas.Click
        clsBasicas.ExportarExcel("Lista de Pedidos de Ventas", dtgListado)
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            clsBasicas.Totales_Formato(dtgListado, e, 1)
            clsBasicas.SumarTotales_Formato(dtgListado, e, 3)
            e.Layout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
            e.Layout.Bands(0).PerformAutoResizeColumns(False, PerformAutoSizeType.AllRowsInBand)

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
End Class