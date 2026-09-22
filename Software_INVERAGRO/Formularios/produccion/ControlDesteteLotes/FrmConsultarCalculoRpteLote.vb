Public Class FrmConsultarCalculoRpteLote

    ' Valores que pueden ser pasados desde el formulario que invoca este dialog
    Public Consumo As Decimal = -1
    Public PesoVenta As Decimal = -1
    Public PesoBajada As Decimal = -1
    Public PesoPromedioVenta As Decimal = -1
    Public EdadPromedioLote As Decimal = -1
    Public TotalDisponibles As Integer = -1
    Public TotalLotes As Decimal = -1
    Public TotalMortalidad As Integer = -1
    Public TotalIngreso As Integer = -1
    Public TotalEmergencia As Integer = -1

    Private Sub FrmConsultarCalculoRpteLote_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim sb As New System.Text.StringBuilder()
            sb.AppendLine("Conversion Alimenticia (CF) = Consumo total / Ganancia de peso total")
            sb.AppendLine("  - Donde:")
            sb.AppendLine("    Consumo total = total de alimento consumido en la campaña (variable 'consumo')")
            sb.AppendLine("    Ganancia de peso total = Peso de venta (promedio por animal * n) - Peso inicial (peso de bajada)")
            sb.AppendLine()
            sb.AppendLine("Ejemplo (según implementacion en el reporte):")
            sb.AppendLine("  CF = consumo / (pesoVenta - pesoBajada)")
            sb.AppendLine()
            sb.AppendLine("Ganancia de peso diario (GPD) = Peso promedio de venta / Edad promedio de lote")
            sb.AppendLine("  - Peso promedio de venta = promedio de pesos de venta por animal (""Peso Promedio Venta (kg)"")")
            sb.AppendLine("  - Edad promedio de lote = edad promedio al momento de venta (""edadPromedioLote"")")
            sb.AppendLine()
            sb.AppendLine("Edad promedio de venta = (Sum(edad_i * numero_animales_i) ) / Total_animales")
            sb.AppendLine()
            sb.AppendLine("Aprox. venta por semana = Total disponibles para venta / totalLotes")
            sb.AppendLine()
            sb.AppendLine("Porcentaje Mortalidad Campaña = (Total Mortalidad / Total Ingresos) * 100")
            sb.AppendLine("  - Total Mortalidad = suma de los campos 'Mortalidad' y 'Regularizacion' en el reporte")
            sb.AppendLine()
            sb.AppendLine("Porcentaje Emergencia Campaña = (Total Emergencia / Total Ingresos) * 100")
            sb.AppendLine()
            sb.AppendLine("Sumas y Totales:")
            sb.AppendLine("  - Total Ingreso = Sum(Ingreso)")
            sb.AppendLine("  - Total Retorno = Sum(Retorno)")
            sb.AppendLine("  - Total Mortalidad = Sum(Mortalidad + Regularizacion)")
            sb.AppendLine("  - Total Vendidos = Sum(Vendidos)")
            sb.AppendLine()
            sb.AppendLine("Formato y notas:")
            sb.AppendLine("  - Valores Nulos: cuando no hay datos se muestran como '-' o 0 segun corresponda")
            sb.AppendLine("  - Formatos numericos usados en el reporte: 'N0' para enteros, 'F2' para decimales con 2 digitos")
            sb.AppendLine()
            sb.AppendLine("Variables usadas en calculos (nombres tal como aparecen en el DataTable):")
            sb.AppendLine("  consumo, peso, pesoConsumoDonacion, edadPromedioLote, pesoPromedioVentaLote, totalLotes, Ingreso, Retorno, Mortalidad, Regularizacion, Vendidos, Disponibles para Venta")

            ' Si se proporcionaron valores, agregamos ejemplos numéricos usando esos parámetros
            If PesoPromedioVenta >= 0 AndAlso EdadPromedioLote >= 0 Then
                sb.AppendLine()
                sb.AppendLine("Ejemplo con valores del reporte:")
                sb.AppendLine("  - Peso promedio de venta: " & PesoPromedioVenta.ToString("F2") & " kg")
                sb.AppendLine("  - Edad promedio de lote: " & EdadPromedioLote.ToString("F2") & " días")
                If EdadPromedioLote <> 0 Then
                    Dim gpd As Decimal = PesoPromedioVenta / EdadPromedioLote
                    sb.AppendLine("  - Ganancia de peso diario (GPD) = " & gpd.ToString("F3") & " kg/día")
                End If
            End If

            If Consumo >= 0 AndAlso PesoVenta >= 0 AndAlso PesoBajada >= 0 Then
                sb.AppendLine()
                sb.AppendLine("Ejemplo Conversion Alimenticia con valores del reporte:")
                sb.AppendLine("  - Consumo total: " & Consumo.ToString("F2") & " kg")
                sb.AppendLine("  - Peso venta (total o promedio segun contexto): " & PesoVenta.ToString("F2") & " kg")
                sb.AppendLine("  - Peso bajada (peso inicial): " & PesoBajada.ToString("F2") & " kg")
                Dim denom As Decimal = PesoVenta - PesoBajada
                If denom <> 0 Then
                    Dim cf As Decimal = Consumo / denom
                    sb.AppendLine("  - CF = " & Consumo.ToString("F2") & " / (" & PesoVenta.ToString("F2") & " - " & PesoBajada.ToString("F2") & ") = " & cf.ToString("F3"))
                Else
                    sb.AppendLine("  - CF: denominador cero (pesoVenta - pesoBajada = 0), no se puede calcular")
                End If
            End If

            If TotalDisponibles >= 0 AndAlso TotalLotes > 0 Then
                sb.AppendLine()
                sb.AppendLine("Aprox. venta por semana = Total disponibles para venta / totalLotes")
                sb.AppendLine("  - Total disponibles: " & TotalDisponibles.ToString())
                sb.AppendLine("  - Total lotes: " & TotalLotes.ToString("F2"))
                sb.AppendLine("  - Resultado ejemplo: " & (TotalDisponibles / TotalLotes).ToString("F2"))
            End If

            If TotalMortalidad >= 0 AndAlso TotalIngreso > 0 Then
                sb.AppendLine()
                sb.AppendLine("Porcentaje Mortalidad Campaña = (Total Mortalidad / Total Ingresos) * 100")
                sb.AppendLine("  - Total Mortalidad: " & TotalMortalidad.ToString())
                sb.AppendLine("  - Total Ingresos: " & TotalIngreso.ToString())
                sb.AppendLine("  - Porcentaje ejemplo: " & ((TotalMortalidad / TotalIngreso) * 100).ToString("F2") & "%")
            End If

            If TotalEmergencia >= 0 AndAlso TotalIngreso > 0 Then
                sb.AppendLine()
                sb.AppendLine("Porcentaje Emergencia Campaña = (Total Emergencia / Total Ingresos) * 100")
                sb.AppendLine("  - Total Emergencia: " & TotalEmergencia.ToString())
                sb.AppendLine("  - Porcentaje ejemplo: " & ((TotalEmergencia / TotalIngreso) * 100).ToString("F2") & "%")
            End If

            ' Asigna el texto al RichTextBox si existe en el formulario
            Dim controlesEncontrados() As Control = Me.Controls.Find("rtbFormulas", True)
            If controlesEncontrados.Length > 0 Then
                Dim rtb As RichTextBox = CType(controlesEncontrados(0), RichTextBox)
                rtb.Text = sb.ToString()
            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

End Class