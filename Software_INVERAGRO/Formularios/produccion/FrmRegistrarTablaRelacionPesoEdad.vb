Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win.UltraWinGrid
Imports OfficeOpenXml
Imports System.IO

Public Class FrmRegistrarTablaRelacionPesoEdad
    Dim cn As New cnControlRelacionPesoEdad
    Private DtDetalle As New DataTable("TempDetRelacionPesoEdad")
    Dim contador As Integer = 0

    Private Sub FrmRegistrarTablaRelacionPesoEdad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i As Integer = DateTime.Now.Year - 10 To DateTime.Now.Year + 20
            CmbAnios.Items.Add(i.ToString())
        Next
        CmbAnios.DropDownStyle = ComboBoxStyle.DropDownList
        CmbAnios.Text = DateTime.Now.Year.ToString()
        TxtRutaArchivo.Enabled = False
        clsBasicas.Formato_Tablas_Grid(dtgListadoPesoEdad)
        CargarTablaDetalleRelacionPesoEdad()
        ColorearColumnas()
    End Sub

    Private Sub ColorearColumnas()
        Try
            Dim contador As Integer = 0
            For i As Integer = 0 To 6
                Dim columnIndex As Integer = contador
                If columnIndex < dtgListadoPesoEdad.DisplayLayout.Bands(0).Columns.Count Then
                    dtgListadoPesoEdad.DisplayLayout.Bands(0).Columns(columnIndex).CellAppearance.BackColor = Color.LightGray
                End If
                contador += 2
            Next
        Catch ex As Exception
            msj_advert(ex.Message)
        End Try
    End Sub

    Private Sub btnImportarExcel_Click(sender As Object, e As EventArgs) Handles btnImportarExcel.Click
        Dim openFileDialog As New OpenFileDialog
        openFileDialog.Filter = "Archivos de Excel (*.xlsx)|*.xlsx|Todos los archivos (*.*)|*.*"
        openFileDialog.Title = "Seleccione un archivo Excel"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Dim filePath As String = openFileDialog.FileName
            CargarExcelEnUltraGrid(filePath)
        End If
    End Sub

    Private Sub CargarExcelEnUltraGrid(filePath As String)
        Try
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial
            Dim dt As New DataTable()

            Using package As New ExcelPackage(New FileInfo(filePath))
                Dim worksheet As ExcelWorksheet = package.Workbook.Worksheets.First()
                TxtRutaArchivo.Text = filePath

                If worksheet.Dimension Is Nothing Then
                    msj_advert("FORMATO NO PERMITIDO. El archivo Excel no tiene datos o la estructura no es válida.")
                    Return
                End If

                For i As Integer = 0 To 6
                    dt.Columns.Add("DIAS" & (i + 1).ToString(), GetType(Integer))
                    dt.Columns.Add("KILOS" & (i + 1).ToString(), GetType(Double))
                Next

                Dim startRow As Integer = 5
                Dim startCol As Integer = 3
                Dim totalRows As Integer = worksheet.Dimension.End.Row

                For row As Integer = startRow To totalRows
                    Dim dataRow As DataRow = dt.NewRow()
                    Dim hasData As Boolean = False

                    For col As Integer = 0 To 6
                        Dim diasValue = worksheet.Cells(row, startCol + col * 2).Text
                        If Integer.TryParse(diasValue, Nothing) Then
                            dataRow("DIAS" & (col + 1).ToString()) = Convert.ToInt32(diasValue)
                            hasData = True
                        Else
                            dataRow("DIAS" & (col + 1).ToString()) = DBNull.Value
                        End If

                        Dim kilosValue = worksheet.Cells(row, startCol + col * 2 + 1).Text
                        If Double.TryParse(kilosValue, Nothing) Then
                            dataRow("KILOS" & (col + 1).ToString()) = Convert.ToDouble(kilosValue)
                            hasData = True
                        Else
                            dataRow("KILOS" & (col + 1).ToString()) = DBNull.Value
                        End If
                    Next

                    If hasData Then
                        dt.Rows.Add(dataRow)
                    End If
                Next

                Dim hasNullValue As Boolean = False

                If dt.Rows.Count = 0 Then
                    msj_advert("FORMATO NO PERMITIDO. El archivo Excel está vacío.")
                    dt.Clear()
                Else
                    For Each dataRow As DataRow In dt.Rows
                        For i As Integer = 0 To Math.Min(11, dt.Columns.Count - 1)
                            If dataRow.IsNull(dt.Columns(i)) Then
                                hasNullValue = True
                                Exit For
                            End If
                        Next
                        If hasNullValue Then
                            Exit For
                        End If
                    Next

                    If hasNullValue Then
                        msj_advert("FORMATO NO PERMITIDO. El archivo Excel tiene datos vacíos o no válidos.")
                        dt.Clear()
                    End If
                End If

                dtgListadoPesoEdad.DataSource = dt
                ColorearColumnas()
            End Using
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub CargarTablaDetalleRelacionPesoEdad()
        DtDetalle = New DataTable("TempDetProdEpp")
        DtDetalle.Columns.Add("dias", GetType(Integer))
        DtDetalle.Columns.Add("kilos", GetType(Decimal))
        DtDetalle.Columns.Add("dias1", GetType(String))
        DtDetalle.Columns.Add("kilos1", GetType(Decimal))
        DtDetalle.Columns.Add("dias2", GetType(Integer))
        DtDetalle.Columns.Add("kilos2", GetType(Decimal))
        DtDetalle.Columns.Add("dias3", GetType(String))
        DtDetalle.Columns.Add("kilos3", GetType(Decimal))
        DtDetalle.Columns.Add("dias4", GetType(Integer))
        DtDetalle.Columns.Add("kilos4", GetType(Decimal))
        DtDetalle.Columns.Add("dias5", GetType(String))
        DtDetalle.Columns.Add("kilos5", GetType(Decimal))
        DtDetalle.Columns.Add("dias6", GetType(String))
        DtDetalle.Columns.Add("kilos6", GetType(Decimal))
        dtgListadoPesoEdad.DataSource = DtDetalle
    End Sub

    Private Sub dtgListadoPesoEdad_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListadoPesoEdad.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(0).Header.Caption = "DIAS"
                .Columns(0).Width = 66
                .Columns(1).Header.Caption = "KILOS"
                .Columns(1).Width = 66
                .Columns(2).Header.Caption = "DIAS"
                .Columns(1).Width = 66
                .Columns(3).Header.Caption = "KILOS"
                .Columns(3).Width = 66
                .Columns(4).Header.Caption = "DIAS"
                .Columns(4).Width = 66
                .Columns(5).Header.Caption = "KILOS"
                .Columns(5).Width = 66
                .Columns(6).Header.Caption = "DIAS"
                .Columns(6).Width = 66
                .Columns(7).Header.Caption = "KILOS"
                .Columns(7).Width = 66
                .Columns(8).Header.Caption = "DIAS"
                .Columns(8).Width = 66
                .Columns(9).Header.Caption = "KILOS"
                .Columns(9).Width = 66
                .Columns(10).Header.Caption = "DIAS"
                .Columns(10).Width = 66
                .Columns(11).Header.Caption = "KILOS"
                .Columns(11).Width = 66
                .Columns(12).Header.Caption = "DIAS"
                .Columns(12).Width = 66
                .Columns(13).Header.Caption = "KILOS"
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            Dim _mensaje As String = ""
            Dim obj As New coControlRelacionPesoEdad With {
                .Anio = Convert.ToInt32(CmbAnios.Text),
                .Estado = "ACTIVO",
                .IdUsuario = VP_IdUser,
                .ListaDatos = GenerarListaRelacionPesoEdad()
            }

            If String.IsNullOrEmpty(obj.ListaDatos) Then
                msj_advert("NO SE HA CARGADO NINGÚN DATO DE LA TABLA DE RELACIÓN PESO-EDAD.")
                Return
            End If

            _mensaje = cn.Cn_RegistrarRelacionPesoEdad(obj)
            If (obj.Coderror = 0) Then
                msj_ok(_mensaje)
                Dispose()
            Else
                msj_advert(_mensaje)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Function GenerarListaRelacionPesoEdad() As String
        Dim listaDato As New List(Of String)()

        For Each row As UltraGridRow In dtgListadoPesoEdad.Rows
            For i As Integer = 0 To 6
                Dim diasColumnName As String = "DIAS" & (i + 1).ToString()
                Dim kilosColumnName As String = "KILOS" & (i + 1).ToString()

                Dim dias As Integer = 0
                Dim kilos As Double = 0.0

                If Integer.TryParse(row.Cells(diasColumnName).Text, dias) AndAlso Double.TryParse(row.Cells(kilosColumnName).Text, kilos) Then
                    listaDato.Add($"{kilos}+{dias}")
                End If
            Next
        Next

        Return String.Join(",", listaDato)
    End Function

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class