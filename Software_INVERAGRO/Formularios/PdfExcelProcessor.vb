'Imports System.IO
'Imports System.Text.RegularExpressions
'Imports iText.Kernel.Pdf
'Imports iText.Kernel.Pdf.Canvas.Parser
'Imports OfficeOpenXml

'Public Class PdfExcelProcessor
'    Public Function ProcesarPdfBCP(pdfPath As String) As DataTable
'        Dim contenido As String = ""
'        Dim contadorContable As Integer = 0
'        Dim iniciarGuardar As Boolean = False
'        Dim contenidoFiltrado As New List(Of String)

'        Try
'            If Not System.IO.File.Exists(pdfPath) Then
'                Throw New System.IO.FileNotFoundException("The PDF file was not found.", pdfPath)
'            End If

'            Console.WriteLine($"Ruta del archivo PDF: {pdfPath}")

'            Using reader As New PdfReader(pdfPath)
'                Using pdfDoc As New PdfDocument(reader)
'                    ' Corrección: GetNumberOfPages() es una propiedad en iText7
'                    For i As Integer = 1 To pdfDoc.GetNumberOfPages()
'                        Try
'                            Dim text As String = PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(i))
'                            contenido &= text & Environment.NewLine
'                        Catch pageEx As Exception
'                            Console.WriteLine($"Error reading page {i}: {pageEx.Message}")
'                        End Try
'                    Next
'                End Using
'            End Using

'            Dim inicioPalabra As String = "CONTABLE"
'            Dim finPalabra As String = "ESTADO DE CUENTA CORRIENTE"
'            Dim posicionActual As Integer = 0
'            Dim posicionContable As Integer = 0

'            Do
'                posicionContable = contenido.IndexOf(inicioPalabra, posicionActual)
'                If posicionContable = -1 Then Exit Do
'                contadorContable += 1
'                posicionActual = posicionContable + inicioPalabra.Length

'                If contadorContable = 3 Then
'                    iniciarGuardar = True
'                    Exit Do
'                End If
'            Loop

'            If iniciarGuardar Then
'                Dim contenidoDesdeTercerContable As String = contenido.Substring(posicionContable)

'                Do
'                    Dim inicioIndex As Integer = contenidoDesdeTercerContable.IndexOf(inicioPalabra)
'                    Dim finIndex As Integer = contenidoDesdeTercerContable.IndexOf(finPalabra)

'                    If inicioIndex <> -1 AndAlso finIndex <> -1 AndAlso finIndex > inicioIndex Then
'                        Dim contenidoEntre As String = contenidoDesdeTercerContable.Substring(inicioIndex + inicioPalabra.Length, finIndex - (inicioIndex + inicioPalabra.Length))
'                        contenidoFiltrado.Add(contenidoEntre.Trim())
'                        contenidoDesdeTercerContable = contenidoDesdeTercerContable.Substring(finIndex + finPalabra.Length)
'                    Else
'                        Exit Do
'                    End If
'                Loop

'                Dim registros As New List(Of String)()
'                Dim pattern As String = "\b\d{2}-\d{2}\b"

'                For Each item In contenidoFiltrado
'                    Dim matches = Regex.Matches(item, pattern)

'                    If matches.Count > 0 Then
'                        Dim lastMatchIndex As Integer = 0

'                        For Each match In matches
'                            If lastMatchIndex < match.Index Then
'                                registros.Add(item.Substring(lastMatchIndex, match.Index - lastMatchIndex).Trim())
'                            End If
'                            lastMatchIndex = match.Index
'                        Next

'                        If lastMatchIndex < item.Length Then
'                            registros.Add(item.Substring(lastMatchIndex).Trim())
'                        End If
'                    End If
'                Next

'                For index As Integer = 0 To registros.Count - 1
'                    registros(index) = ApplyRecordFormattingBCP(registros(index))
'                Next

'                registros = registros.Where(Function(r) r.Count(Function(c) c = "|"c) = 12).ToList()

'                Dim tabla As New DataTable()
'                tabla.Columns.Add("N°", GetType(String))
'                tabla.Columns.Add("Fecha Proc.", GetType(String))
'                tabla.Columns.Add("Descripción", GetType(String))
'                tabla.Columns.Add("Med At*", GetType(String))
'                tabla.Columns.Add("Lugar", GetType(String))
'                tabla.Columns.Add("Suc-Age", GetType(String))
'                tabla.Columns.Add("Num Op", GetType(String))
'                tabla.Columns.Add("Hora", GetType(String))
'                tabla.Columns.Add("Origen", GetType(String))
'                tabla.Columns.Add("Tipo", GetType(String))
'                tabla.Columns.Add("Cargo/Abono", GetType(String))
'                tabla.Columns.Add("Saldo Contable", GetType(String))

'                For index As Integer = 0 To registros.Count - 1
'                    Dim partes As String() = registros(index).Split("|"c)
'                    ' Agregada validación para evitar errores de índice
'                    If partes.Length >= 12 Then
'                        tabla.Rows.Add((index + 1).ToString(), partes(1), partes(2), partes(3), partes(4), partes(5), partes(6), partes(7), partes(8), partes(9), partes(10), partes(11))
'                    End If
'                Next

'                Return tabla
'            Else
'                Return Nothing
'            End If

'        Catch ex As Exception
'            Throw New Exception("Error al procesar el PDF", ex)
'        End Try
'    End Function

'    Private Function ApplyRecordFormattingBCP(ByVal registro As String) As String
'        Dim resultado As String = "|"

'        Dim fechaPattern As String = "\b\d{2}-\d{2}\b"
'        Dim abreviaturas() As String = {"CAJ", "BPI", "VEN", "TLC", "INT"}
'        Dim lugarPattern As String = "AG\.[A-Z\s]+|SUC\s[A-Z\s]+"
'        Dim codigoPattern As String = "\d{3}-\d{3}|-"
'        Dim numeroPattern As String = "\d+"
'        Dim horaPattern As String = "\d{2}:\d{2}"
'        Dim combinacionPattern As String = "[A-Z0-9]+"
'        Dim valorPattern As String = "[\d,]+\.\d+-?|[\d,]+\.\d+"

'        Dim matchFecha As Match = Regex.Match(registro, fechaPattern)
'        If matchFecha.Success Then
'            resultado &= matchFecha.Value & "|"
'            registro = registro.Substring(matchFecha.Index + matchFecha.Length).Trim()
'        Else
'            resultado &= "|"
'        End If

'        Dim abreviaturaPosicion As Integer = -1
'        For Each abreviatura As String In abreviaturas
'            abreviaturaPosicion = registro.IndexOf(abreviatura)
'            If abreviaturaPosicion <> -1 Then
'                resultado &= registro.Substring(0, abreviaturaPosicion).Trim() & "|"
'                registro = registro.Substring(abreviaturaPosicion).Trim()
'                Exit For
'            End If
'        Next

'        For Each abreviatura As String In abreviaturas
'            If registro.StartsWith(abreviatura) Then
'                resultado &= abreviatura & "|"
'                registro = registro.Substring(abreviatura.Length).Trim()
'                Exit For
'            End If
'        Next

'        Dim matchLugar As Match = Regex.Match(registro, lugarPattern)
'        If matchLugar.Success Then
'            resultado &= matchLugar.Value & "|"
'            registro = registro.Substring(matchLugar.Index + matchLugar.Length).Trim()
'        Else
'            resultado &= "|"
'        End If

'        Dim matchCodigo As Match = Regex.Match(registro, codigoPattern)
'        If matchCodigo.Success Then
'            resultado &= matchCodigo.Value & "|"
'            registro = registro.Substring(matchCodigo.Index + matchCodigo.Length).Trim()
'        Else
'            resultado &= "|"
'        End If

'        Dim matchNumero As Match = Regex.Match(registro, numeroPattern)
'        If matchNumero.Success Then
'            resultado &= matchNumero.Value & "|"
'            registro = registro.Substring(matchNumero.Index + matchNumero.Length).Trim()
'        Else
'            resultado &= "|"
'        End If

'        Dim matchHora As Match = Regex.Match(registro, horaPattern)
'        If matchHora.Success Then
'            resultado &= matchHora.Value & "|"
'            registro = registro.Substring(matchHora.Index + matchHora.Length).Trim()
'        Else
'            resultado &= "|"
'        End If

'        Dim matchCombinacion As Match = Regex.Match(registro, combinacionPattern)
'        If matchCombinacion.Success Then
'            resultado &= matchCombinacion.Value & "|"
'            registro = registro.Substring(matchCombinacion.Index + matchCombinacion.Length).Trim()
'        Else
'            resultado &= "|"
'        End If

'        Dim matchUltimoNumero As Match = Regex.Match(registro, numeroPattern)
'        If matchUltimoNumero.Success Then
'            resultado &= matchUltimoNumero.Value & "|"
'            registro = registro.Substring(matchUltimoNumero.Index + matchUltimoNumero.Length).Trim()
'        Else
'            resultado &= "|"
'        End If

'        Dim matchValor As Match = Regex.Match(registro, valorPattern)
'        If matchValor.Success Then
'            resultado &= matchValor.Value & "|"
'            registro = registro.Substring(matchValor.Index + matchValor.Length).Trim()
'        Else
'            resultado &= "|"
'        End If

'        Dim matchUltimoDecimal As Match = Regex.Match(registro, valorPattern)
'        If matchUltimoDecimal.Success Then
'            resultado &= matchUltimoDecimal.Value & "|"
'        Else
'            resultado &= "|"
'        End If

'        ' Asegurar que siempre tengamos exactamente 12 separadores
'        Dim separadoresCount As Integer = resultado.Count(Function(c) c = "|"c)
'        While separadoresCount < 12
'            resultado &= "|"
'            separadoresCount += 1
'        End While

'        ' Si hay más de 12, recortar
'        If separadoresCount > 12 Then
'            Dim parts() As String = resultado.Split("|"c)
'            resultado = String.Join("|", parts.Take(13)) ' Tomar 13 elementos para 12 separadores
'        End If

'        Return resultado
'    End Function

'    Public Function ProcesarPdfBBVA(pdfPath As String) As DataTable
'        Dim fullContent As New System.Text.StringBuilder()

'        Try
'            Using reader As New PdfReader(pdfPath)
'                Using pdfDoc As New PdfDocument(reader)
'                    For i As Integer = 1 To pdfDoc.GetNumberOfPages()
'                        Dim text As String = PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(i))
'                        fullContent.AppendLine(text)
'                    Next
'                End Using
'            End Using

'            Dim fullText As String = fullContent.ToString()

'            Dim regex As New Regex("\d{2}-\d{2}\s{1,}\d{2}-\d{2}\s{1,}.*?(([-]?\d{1,3}(,\d{3})*\.\d{2})\s*){1,3}", RegexOptions.Singleline)
'            Dim matches As MatchCollection = regex.Matches(fullText)

'            If matches.Count > 0 Then
'                Dim tabla As DataTable = New DataTable()
'                tabla.Columns.Add("N°", GetType(Integer))
'                tabla.Columns.Add("Fecha Operación", GetType(String))
'                tabla.Columns.Add("Fecha Valor", GetType(String))
'                tabla.Columns.Add("Descripción - Oficina", GetType(String))
'                tabla.Columns.Add("CAN", GetType(String))
'                tabla.Columns.Add("N° Operación", GetType(String))
'                tabla.Columns.Add("CARGO/ABONO", GetType(String))
'                tabla.Columns.Add("ITF", GetType(String))
'                tabla.Columns.Add("Saldo Contable", GetType(String))

'                Dim index As Integer = 0

'                For Each match As Match In matches
'                    Dim record As String = match.Value.Trim()
'                    Dim formattedRecord As String = FormatearRegistroBBVA(record)

'                    Dim partes As String() = formattedRecord.Split("|"c)
'                    If partes.Length >= 9 Then ' Cambiado de = 10 a >= 9
'                        Dim fila As DataRow = tabla.NewRow()
'                        fila("N°") = index + 1
'                        fila("Fecha Operación") = If(partes.Length > 1, partes(1).Trim(), String.Empty)
'                        fila("Fecha Valor") = If(partes.Length > 2, partes(2).Trim(), String.Empty)
'                        fila("Descripción - Oficina") = If(partes.Length > 3, partes(3).Trim(), String.Empty)
'                        fila("CAN") = If(partes.Length > 4, partes(4).Trim(), String.Empty)
'                        fila("N° Operación") = If(partes.Length > 5, partes(5).Trim(), String.Empty)
'                        fila("Cargo/Abono") = If(partes.Length > 6, partes(6).Trim(), String.Empty)
'                        fila("ITF") = If(partes.Length > 7, partes(7).Trim(), String.Empty)
'                        fila("Saldo Contable") = If(partes.Length > 8, partes(8).Trim(), String.Empty)

'                        tabla.Rows.Add(fila)
'                        index += 1
'                    End If
'                Next

'                Return tabla
'            Else
'                Return Nothing
'            End If

'        Catch ex As Exception
'            Throw New Exception("Error al procesar el PDF", ex)
'        End Try
'    End Function

'    Private Function FormatearRegistroBBVA(record As String) As String
'        Dim sectionRegex As New Regex("(?<date1>\d{2}-\d{2})\s+(?<date2>\d{2}-\d{2})\s+(?<description>.*?)\s*(?<code>VEN|BIE|BIN|)?\s*(?<operation>\d{5}|\d{3})?\s+(?<value1>[-]?\d{1,3}(,\d{3})*\.\d{2}|\s*)\s+(?<value2>[-]?\d{1,3}(,\d{3})*\.\d{2}|\s*)\s+(?<value3>[-]?\d{1,3}(,\d{3})*\.\d{2}|\s*)")
'        Dim match As Match = sectionRegex.Match(record)

'        If match.Success Then
'            Dim parts As New List(Of String) From {
'                "",
'                match.Groups("date1").Value,
'                match.Groups("date2").Value,
'                match.Groups("description").Value.Trim(),
'                If(String.IsNullOrWhiteSpace(match.Groups("code").Value), "", match.Groups("code").Value),
'                If(String.IsNullOrWhiteSpace(match.Groups("operation").Value), "", match.Groups("operation").Value),
'                If(String.IsNullOrWhiteSpace(match.Groups("value1").Value), "", match.Groups("value1").Value),
'                If(String.IsNullOrWhiteSpace(match.Groups("value2").Value), "", match.Groups("value2").Value),
'                If(String.IsNullOrWhiteSpace(match.Groups("value3").Value), "", match.Groups("value3").Value)
'            }

'            Return String.Join("|", parts)
'        Else
'            Return "|" & record.Replace("|", "") & "||||||||"
'        End If
'    End Function

'    Public Function FormatearRegistroExcel(filePath As String) As DataTable
'        ExcelPackage.LicenseContext = LicenseContext.NonCommercial

'        Dim tabla As New DataTable()

'        tabla.Columns.Add("N°", GetType(Integer))
'        tabla.Columns.Add("Día", GetType(String))
'        tabla.Columns.Add("Concepto", GetType(String))
'        tabla.Columns.Add("Depositos", GetType(Double))
'        tabla.Columns.Add("ITF", GetType(Double))
'        tabla.Columns.Add("Retiros", GetType(Double))
'        tabla.Columns.Add("ITF_", GetType(Double))
'        tabla.Columns.Add("Orden", GetType(String))
'        tabla.Columns.Add("Saldo", GetType(Double))

'        Dim dataFound As Boolean = False

'        Using package As New ExcelPackage(New FileInfo(filePath))
'            Dim worksheet As ExcelWorksheet = package.Workbook.Worksheets.First()
'            Dim startRow As Integer = 17
'            Dim index As Integer = 1

'            For row As Integer = startRow To worksheet.Dimension.End.Row
'                Dim dia As String = worksheet.Cells(row, 1).Text
'                If String.IsNullOrWhiteSpace(dia) Then Exit For

'                Dim concepto As String = worksheet.Cells(row, 2).Text
'                Dim depositos As Double
'                Dim itf As Double
'                Dim retiros As Double
'                Dim itfRetiros As Double
'                Dim saldo As Double

'                Double.TryParse(worksheet.Cells(row, 3).Text, depositos)
'                Double.TryParse(worksheet.Cells(row, 4).Text, itf)
'                Double.TryParse(worksheet.Cells(row, 5).Text, retiros)
'                Double.TryParse(worksheet.Cells(row, 6).Text, itfRetiros)
'                Double.TryParse(worksheet.Cells(row, 8).Text, saldo)

'                Dim orden As String = worksheet.Cells(row, 7).Text

'                If Not String.IsNullOrWhiteSpace(dia) AndAlso Not String.IsNullOrWhiteSpace(concepto) AndAlso (depositos <> 0 Or retiros <> 0 Or saldo <> 0) Then
'                    tabla.Rows.Add(index, dia, concepto, depositos, itf, retiros, itfRetiros, orden, saldo)
'                    index += 1
'                    dataFound = True
'                End If
'            Next
'        End Using

'        If Not dataFound Then
'            Return Nothing
'        End If

'        Return tabla
'    End Function
'End Class