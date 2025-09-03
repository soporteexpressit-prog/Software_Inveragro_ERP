Public Class FrmFormatoTicketActivo
    Public _Codigo As String
    Public _NumSerie As String
    Public _Descripcion As String
    Private Sub FrmFormatoTicketActivo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rbtnFormato01.Checked = True
    End Sub
    Private Sub ImprimirCodigosQR(cantidad As Integer, formato As Integer)
        Try
            Dim tabla As DataTable = New DataTable()
            tabla.Columns.Add("Codigo", GetType(String))
            tabla.Columns.Add("descripcion", GetType(String))
            tabla.Columns.Add("Fecha", GetType(String))
            tabla.Columns.Add("Num", GetType(Integer))

            Dim row As DataRow
            Dim currentCantidad As Integer = 0
            For x = 1 To cantidad
                row = tabla.NewRow()
                currentCantidad += 1
                row("Codigo") = _Codigo & _NumSerie
                row("descripcion") = _Descripcion
                row("Fecha") = Now().Date.ToShortDateString
                row("Num") = currentCantidad
                tabla.Rows.Add(row)
            Next

            Dim StiReport1 As New Stimulsoft.Report.StiReport()
            If formato = 1 Then
                StiReport1.Load(clsBasicas.Ruta_Reporte("Rpt_Barras_Activo_F1.mrt"))
            ElseIf formato = 2 Then
                StiReport1.Load(clsBasicas.Ruta_Reporte("Rpt_Barras_Activo_F2.mrt"))
            ElseIf formato = 3 Then
                StiReport1.Load(clsBasicas.Ruta_Reporte("Rpt_Barras_Activo_F3.mrt"))
            End If
            StiReport1.Dictionary.Clear()
            tabla.TableName = "tmp"
            StiReport1.RegData(tabla)
            StiReport1.Dictionary.Synchronize()
            StiReport1.Render()

            StiReport1.Show()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnImprimir_Click(sender As Object, e As EventArgs) Handles btnImprimir.Click
        Try
            Dim _mensaje As String = ""

            If numeroTickets.Value <= 0 Then
                msj_advert("El valor de Vida Útil debe ser mayor a 0")
                Return
            End If

            If rbtnFormato01.Checked Then
                ImprimirCodigosQR(numeroTickets.Value, 1)
            ElseIf rbtnFormato02.Checked Then
                ImprimirCodigosQR(numeroTickets.Value, 2)
            ElseIf rbtnFormato03.Checked Then
                ImprimirCodigosQR(numeroTickets.Value, 3)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class