Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win.UltraWinGrid

Public Class FrmReporteProyeccionVenta
    Dim cn As New cnControlLoteDestete
    Dim tbtmp As New DataTable
    Dim search As Boolean = False
    Dim totalLotes As Decimal = 0
    Dim numAnimalesVendidos As Integer = 0

    Private Sub FrmReporteProyeccionVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            clsBasicas.LlenarComboAnios(CmbAnios)
            clsBasicas.Formato_Tablas_Grid_PrimeraColumnaEditable(dtgListado)
            Consultar()
            Me.Size = New Size(1220, 800)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BloquearControladores()
        CmbAnios.Enabled = False
        Ptbx_Cargando.Visible = True
    End Sub

    Private Sub DesbloquearControladores()
        CmbAnios.Enabled = True
        Ptbx_Cargando.Visible = False
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            BloquearControladores()

            Dim obj As New coControlLoteDestete With {
                .Anio = CInt(CmbAnios.Text)
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlLoteDestete = CType(e.Argument, coControlLoteDestete)
            tbtmp = cn.Cn_ConsultarReporteProyeccionVenta(obj).Copy
            tbtmp.TableName = "tmp"
            e.Result = tbtmp
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        DesbloquearControladores()
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            dtgListado.DataSource = CType(e.Result, DataTable)
            search = True
            CalcularParametros()
            PintarFilasVendido()
        End If
    End Sub

    Private Sub PintarFilasVendido()
        For Each fila As UltraGridRow In dtgListado.Rows
            Dim disponibleVenta As Integer = CInt(fila.Cells("Disponibles para Venta").Value?.ToString().ToUpper().Trim())

            If disponibleVenta = 0 Then
                fila.Appearance.BackColor = Color.FromArgb(236, 250, 229)
            End If
        Next
    End Sub

    Private Sub CmbAnios_TextChanged(sender As Object, e As EventArgs) Handles CmbAnios.TextChanged
        If search Then
            Consultar()
        End If
    End Sub

    Private Sub BtnExportar_Click(sender As Object, e As EventArgs) Handles BtnExportar.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("PROYECCIÓN DE VENTA", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Function SumarTotalAnimales() As Integer
        Dim suma As Integer = 0

        For Each row As UltraGridRow In dtgListado.Rows
            If Convert.ToBoolean(row.Cells("Selección").Value) AndAlso
          IsNumeric(row.Cells("Disponibles para Venta").Value) Then
                suma += CDec(row.Cells("Disponibles para Venta").Value)
            End If
        Next

        Return suma
    End Function

    Private Function SumarTotalAnimalesIngreso() As Integer
        Dim suma As Integer = 0

        For Each row As UltraGridRow In dtgListado.Rows
            If Convert.ToBoolean(row.Cells("Selección").Value) AndAlso
          IsNumeric(row.Cells("Ingreso").Value) Then
                suma += CDec(row.Cells("Ingreso").Value)
            End If
        Next

        Return suma
    End Function

    Private Function SumarTotalAnimalesRetorno() As Integer
        Dim suma As Integer = 0

        For Each row As UltraGridRow In dtgListado.Rows
            If Convert.ToBoolean(row.Cells("Selección").Value) AndAlso
          IsNumeric(row.Cells("Retorno").Value) Then
                suma += Convert.ToInt32(row.Cells("Retorno").Value)
            End If
        Next

        Return suma
    End Function

    Private Function SumarTotalAnimalesEmergencia() As Integer
        Dim suma As Integer = 0

        For Each row As UltraGridRow In dtgListado.Rows
            If Convert.ToBoolean(row.Cells("Selección").Value) AndAlso
          IsNumeric(row.Cells("Emergencia").Value) Then
                suma += Convert.ToInt32(row.Cells("Emergencia").Value)
            End If
        Next

        Return suma
    End Function

    Private Function SumarMortalidad() As Integer
        Dim suma As Integer = 0

        For Each row As UltraGridRow In dtgListado.Rows
            If Convert.ToBoolean(row.Cells("Selección").Value) AndAlso
          IsNumeric(row.Cells("Mortalidad").Value) Then
                suma += Convert.ToInt32(row.Cells("Mortalidad").Value)
            End If
        Next

        Return suma
    End Function

    Private Function SumarTotalAnimalesVendidos() As Integer
        Dim suma As Integer = 0

        For Each row As UltraGridRow In dtgListado.Rows
            If Convert.ToBoolean(row.Cells("Selección").Value) AndAlso
          IsNumeric(row.Cells("Vendidos").Value) Then
                suma += CDec(row.Cells("Vendidos").Value)
            End If
        Next

        Return suma
    End Function

    Private Function SumarTotalAnimalesConsumoDonacion() As Integer
        Dim suma As Integer = 0

        For Each row As UltraGridRow In dtgListado.Rows
            If Convert.ToBoolean(row.Cells("Selección").Value) AndAlso
          IsNumeric(row.Cells("Consumo / Donación").Value) Then
                suma += Convert.ToInt32(row.Cells("Consumo / Donación").Value)
            End If
        Next

        Return suma
    End Function

    Private Function PesoTotalVenta() As Decimal
        Dim totalPeso As Decimal = 0

        For Each row As UltraGridRow In dtgListado.Rows
            If Convert.ToBoolean(row.Cells("Selección").Value) AndAlso
          IsNumeric(row.Cells("Peso Total Venta (kg)").Value) Then
                totalPeso += Convert.ToDecimal(row.Cells("Peso Total Venta (kg)").Value)
            End If
        Next

        Return totalPeso
    End Function

    Private Function EdadPromedioVentaLote() As Decimal
        Dim totalEdad As Decimal = 0
        Dim totalLotes As Integer = 0

        For Each row As UltraGridRow In dtgListado.Rows
            If Convert.ToBoolean(row.Cells("Selección").Value) AndAlso
          IsNumeric(row.Cells("Edad Promedio Venta").Value) Then
                totalEdad += Convert.ToDecimal(row.Cells("Edad Promedio Venta").Value)
                totalLotes += 1
            End If
        Next

        If totalLotes > 0 Then
            Return totalEdad / totalLotes
        Else
            Return 0
        End If
    End Function

    Private Function SumaTotalLotes() As Decimal
        Dim totalLotes As Decimal = 0

        For Each row As UltraGridRow In dtgListado.Rows
            If Not IsDBNull(row.Cells("Selección").Value) AndAlso
           Convert.ToBoolean(row.Cells("Selección").Value) = True Then
                totalLotes += 1
            End If
        Next

        Return totalLotes
    End Function

    Private Sub dtgListado_CellChange(sender As Object, e As CellEventArgs) Handles dtgListado.CellChange
        If e.Cell.Column.Key = "Selección" Then
            dtgListado.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode)

            CalcularParametros()
        End If
    End Sub

    Private Sub ChkSeleccionarTodo_CheckedChanged(sender As Object, e As EventArgs) Handles ChkSeleccionarTodo.CheckedChanged
        For Each row As UltraGridRow In dtgListado.Rows
            If Not row.IsGroupByRow Then
                row.Cells("Selección").Value = ChkSeleccionarTodo.Checked
            End If
        Next

        CalcularParametros()
    End Sub

    Private Sub CalcularParametros()
        Dim allUnchecked As Boolean = True

        For Each row As UltraGridRow In dtgListado.Rows
            If Not row.IsGroupByRow AndAlso Convert.ToBoolean(row.Cells("Selección").Value) Then
                allUnchecked = False
                Exit For
            End If
        Next

        If dtgListado.Rows.Count = 0 Or allUnchecked Then
            LblIngreso.Text = "0"
            LblRetorno.Text = "0"
            LblTotalMortalidad.Text = "0"
            PorcentajeMortalidadCampana.Text = "0.00"
            LblEmergencia.Text = "0"
            PorcentajeEmergenciaCampaña.Text = "0.00"
            LblVendidos.Text = "0"
            LblTotalAnimales.Text = "0"
            LblAproxVentaSemana.Text = "0"
            LblPesoVenta.Text = "0.00"
            LblPromedioPesoVenta.Text = "0.00"
            LblEdadPromedioLote.Text = "0"
            Return
        Else
            LblIngreso.Text = SumarTotalAnimalesIngreso().ToString("N0")
            LblRetorno.Text = SumarTotalAnimalesRetorno().ToString("N0")
            LblTotalMortalidad.Text = SumarMortalidad()
            PorcentajeMortalidadCampana.Text = If(SumarTotalAnimalesIngreso() = 0, 0, ((SumarMortalidad() / SumarTotalAnimalesIngreso()) * 100).ToString("F2"))
            LblEmergencia.Text = SumarTotalAnimalesEmergencia()
            PorcentajeEmergenciaCampaña.Text = If(SumarTotalAnimalesIngreso() = 0, 0, ((SumarTotalAnimalesEmergencia() / SumarTotalAnimalesIngreso()) * 100).ToString("F2"))
            LblVendidos.Text = SumarTotalAnimalesVendidos().ToString("N0")
            numAnimalesVendidos = SumarTotalAnimalesVendidos() + SumarTotalAnimalesEmergencia() + SumarTotalAnimalesConsumoDonacion()
            totalLotes = SumaTotalLotes()
            LblTotalAnimales.Text = SumarTotalAnimales().ToString("N0")
            LblAproxVentaSemana.Text = (SumarTotalAnimales() / totalLotes).ToString("N0")
            LblPesoVenta.Text = PesoTotalVenta().ToString("N2")
            LblPromedioPesoVenta.Text = If(numAnimalesVendidos = 0, 0, (PesoTotalVenta() / numAnimalesVendidos).ToString("N2"))
            LblEdadPromedioLote.Text = EdadPromedioVentaLote().ToString("N0")
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dispose()
    End Sub
End Class