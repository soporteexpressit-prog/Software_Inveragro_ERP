Imports System.Drawing.Imaging
Imports System.Globalization
Imports System.IO
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinEditors
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.ExcelExport



Public Class clsBasicas
    Dim loginNegocio As New cnLogin()
    Public loginFormInstance As FrmLogin

    Public Shared Sub ListarAlmacenesAsignados(cbxalmacen As ComboBox)
        Dim obj As New coProductos
        Dim cn As New cnProducto
        obj.IdUsuario = VP_IdUser
        Dim tbtmp As New DataTable
        tbtmp = cn.Cn_ListarAlmacenes(obj).Copy
        tbtmp.TableName = "tmp"
        With cbxalmacen
            .DataSource = tbtmp
            .DisplayMember = tbtmp.Columns(1).ColumnName
            .ValueMember = tbtmp.Columns(0).ColumnName
        End With
    End Sub
    Public Shared Sub ListarDistribuidoresAsignados(cbxalmacen As ComboBox)
        Dim obj As New coProductos
        Dim cn As New cnProducto
        obj.IdUsuario = VP_IdUser
        Dim tbtmp As New DataTable
        tbtmp = cn.Cn_ListardistribuidoresAlmacenes(obj).Copy
        tbtmp.TableName = "tmp"
        With cbxalmacen
            .DataSource = tbtmp
            .DisplayMember = tbtmp.Columns(1).ColumnName
            .ValueMember = tbtmp.Columns(0).ColumnName
        End With
    End Sub
    Public Shared Sub ListarVendedores(cbxalmacen As ComboBox)
        Dim obj As New coProductos
        Dim cn As New cnVentas
        obj.IdUsuario = GlobalReferences.ActiveSessionId
        Dim tbtmp As New DataTable
        tbtmp = cn.Cn_ListarVendedores(obj).Copy
        tbtmp.TableName = "tmp"
        With cbxalmacen
            .DataSource = tbtmp
            .DisplayMember = tbtmp.Columns(1).ColumnName
            .ValueMember = tbtmp.Columns(0).ColumnName
        End With
    End Sub

    Public Shared Sub ListartodosVendedores(cbxalmacen As ComboBox)
        Dim obj As New coProductos
        Dim cn As New cnVentas
        obj.IdUsuario = GlobalReferences.ActiveSessionId
        Dim tbtmp As New DataTable
        tbtmp = cn.Cn_ListartodosVendedores(obj).Copy
        tbtmp.TableName = "tmp"
        With cbxalmacen
            .DataSource = tbtmp
            .DisplayMember = tbtmp.Columns(1).ColumnName
            .ValueMember = tbtmp.Columns(0).ColumnName
        End With
    End Sub

    Public Shared Sub ListarPlantelesAsignados(cbxalmacen As ComboBox)
        Dim obj As New coProductos
        Dim cn As New cnProducto
        obj.IdUsuario = VP_IdUser
        Dim tbtmp As New DataTable
        tbtmp = cn.Cn_ListarAlmacenes(obj).Copy
        tbtmp.TableName = "tmp"

        Dim filteredRows As DataRow() = tbtmp.Select("descripcion LIKE 'PLANTEL%'")
        Dim filteredTable As New DataTable
        filteredTable = tbtmp.Clone()

        For Each row As DataRow In filteredRows
            filteredTable.ImportRow(row)
        Next

        With cbxalmacen
            .DataSource = filteredTable
            .DisplayMember = filteredTable.Columns(1).ColumnName
            .ValueMember = filteredTable.Columns(0).ColumnName
        End With
    End Sub

    Public Shared Function ObtenerSaldoCaja(txt As TextBox)

        Dim cn_areas As New cnCaja
        Dim tb As New DataTable
        tb = cn_areas.Cn_ConsultarSaldoCaja()
        If (tb.Rows.Count = 0) Then
            txt.Text = "0"
        Else
            'VP_CodCm = tb.Rows(0)(0)
            txt.Text = FormatearComoDecimal(tb.Rows(0)(1))
        End If
        Return 0
    End Function

    Public Shared Function ObtenerStockxPlantel(txt As TextBox, txt2 As TextBox, idplantel As Integer, idMotivoTransaccion As Integer) As Integer

        Dim cn_areas As New cnCaja
        Dim tb As New DataTable
        tb = cn_areas.Cn_ConsultarStockCerdosPlantel(idplantel, idMotivoTransaccion)

        If tb.Rows.Count = 0 Then
            txt.Text = "0"
            txt2.Text = "0"
        Else
            txt.Text = FormatearComoDecimal(tb.Rows(0)("StockCount"))
            txt2.Text = FormatearComoDecimal(tb.Rows(0)("stockalimento"))
        End If

        Return 0
    End Function

    Public Shared Function ObtenerCentroCostos(idalcance3 As Integer, txtnivel1 As TextBox, txtnivel2 As TextBox, txtnivel3 As TextBox)

        Dim cn_areas As New cnCaja
        Dim obj As New coCaja
        obj.Idalcance3 = idalcance3
        Dim tb As New DataTable
        tb = cn_areas.Cn_ConsultarCentroCostos(obj)
        If (tb.Rows.Count = 0) Then
            txtnivel1.Text = ""
            txtnivel2.Text = ""
            txtnivel3.Text = ""
        Else
            txtnivel1.Text = tb.Rows(0)(1)
            txtnivel2.Text = tb.Rows(0)(3)
            txtnivel3.Text = tb.Rows(0)(5)
        End If
        Return 0
    End Function

    Public Shared Function ObtenerSaldoAnteriorCaja() As Decimal
        Dim cn_areas As New cnCaja
        Return cn_areas.Cn_ObtenerSaldoCajaAnterior()
    End Function

    Public Shared Function ObtenerMomentoDelDia() As Integer
        Dim horaActual As Integer = DateTime.Now.Hour
        If horaActual >= 6 AndAlso horaActual < 12 Then
            ' Es día (6:00 AM - 11:59 AM)
            Return 1
        ElseIf horaActual >= 12 AndAlso horaActual < 18 Then
            ' Es tarde (12:00 PM - 5:59 PM)
            Return 2
        Else
            ' Es noche (6:00 PM - 5:59 AM)
            Return 3
        End If
    End Function

    Public Shared Function OptimizeImageFromPictureBox(picBox As PictureBox) As Byte()
        If picBox.Image Is Nothing Then
            Return Nothing
        End If

        Dim originalImage As New Bitmap(picBox.Image)

        Dim jpgEncoder As ImageCodecInfo = GetEncoder(ImageFormat.Jpeg)
        If jpgEncoder Is Nothing Then
            Throw New Exception("No se encontró un codificador de JPEG.")
        End If

        Dim myEncoder As System.Drawing.Imaging.Encoder = System.Drawing.Imaging.Encoder.Quality
        Dim myEncoderParameters As New EncoderParameters(1)

        Dim myEncoderParameter As New EncoderParameter(myEncoder, 50L)
        myEncoderParameters.Param(0) = myEncoderParameter

        Using ms As New MemoryStream()
            Try
                originalImage.Save(ms, jpgEncoder, myEncoderParameters)
            Catch ex As Exception
                Throw New Exception("Error al optimizar la imagen: " & ex.Message)
            End Try

            Return ms.ToArray()
        End Using
    End Function

    Public Shared Function GetEncoder(format As ImageFormat) As ImageCodecInfo
        Dim codecs As ImageCodecInfo() = ImageCodecInfo.GetImageDecoders()
        For Each codec As ImageCodecInfo In codecs
            If codec.FormatID = format.Guid Then
                Return codec
            End If
        Next
        Return Nothing
    End Function

    Public Shared Function ByteArrayToImage(byteArray As Byte()) As Image
        Using ms As New MemoryStream(byteArray)
            Return Image.FromStream(ms)
        End Using
    End Function

    ' Convierte la imagen en el PictureBox a un arreglo de bytes (VarBinary)
    Public Shared Function ConvertPictureBoxToVarBinary(ByVal pictureBox As PictureBox) As Byte()
        If pictureBox.Image Is Nothing Then
            Return Nothing
        End If

        ' Crear un MemoryStream para guardar la imagen
        Using ms As New System.IO.MemoryStream()
            ' Guardar la imagen en el MemoryStream en formato PNG (u otro formato si lo prefieres)
            pictureBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
            ' Convertir el MemoryStream a un arreglo de bytes
            Return ms.ToArray()
        End Using

    End Function
    ' Convierte un arreglo de bytes (VarBinary) a una imagen y la muestra en un PictureBox
    Public Shared Sub ConvertVarBinaryToPictureBox(ByVal imageData As Byte(), ByVal pictureBox As PictureBox)
        If imageData Is Nothing OrElse imageData.Length = 0 Then
            pictureBox.Image = Nothing
            Return
        End If

        ' Crear un MemoryStream a partir de los datos binarios
        Using ms As New System.IO.MemoryStream(imageData)
            ' Convertir el MemoryStream a una imagen
            pictureBox.Image = Image.FromStream(ms)
        End Using
    End Sub
    Public Shared Function FormatearComoDecimal(valor As String) As String
        Return String.Format(CultureInfo.InvariantCulture, "{0:F2}", Decimal.Parse(valor))
    End Function
    Public Shared Sub ValidarNumeros(e As KeyPressEventArgs)
        'Validamos para ingresar solo numeros
        If InStr("0123456789" & Chr(8), e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Public Shared Sub ValidarNumDocumentos(e As KeyPressEventArgs)
        'Validamos para ingresar solo numeros
        If InStr("0123456789-" & Chr(8), e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Public Shared Function ValidarSeleccionFila(ByRef filaSeleccionada As Infragistics.Win.UltraWinGrid.UltraGridRow, ByRef dtgListado As UltraGrid) As Boolean
        ' Verificar si hay filas en el UltraGrid y si hay una fila activa
        If dtgListado.Rows.Count = 0 OrElse dtgListado.ActiveRow Is Nothing Then
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            Return False
        End If

        filaSeleccionada = dtgListado.ActiveRow

        ' Verificar si la primera celda tiene valor
        If filaSeleccionada.Cells(0).Value.ToString.Length = 0 Then
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            Return False
        End If

        ' Verificar que la fila pertenece a la banda principal (no es una fila hija)
        If filaSeleccionada.Band.Index <> 0 Then
            msj_advert(MensajesSistema.mensajesGenerales("SELECCION_FILA_CONTENEDOR"))
            Return False
        End If

        Return True
    End Function

    Public Shared Sub ValidarNumerosTarjetas(e As KeyPressEventArgs)
        'Validamos para ingresar solo numeros
        If InStr("0123456789-" & Chr(8), e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Public Shared Sub ValidarLetras(e As KeyPressEventArgs)
        'Validamos para ingresar solo letras
        If InStr("qwertyuiopñlkjhgfdsazxcvbnmQWERTYUIOPÑLKJHGFDSAZXCVBNM,.áó-_ " & Chr(8), e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Public Shared Sub ValidarLetrasCasoSql(e As KeyPressEventArgs)
        'Validamos para ingresar solo letras
        If InStr("1234567890qwertyuiopasdfghjklñzxcvbnm -QWERTYUIOPÑLKJHGFDSAZXCVBNM" & Chr(8), e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Public Shared Sub ValidarLetras_sincoma(e As KeyPressEventArgs)
        'Validamos para ingresar solo letras
        If InStr("qwertyuiopñlkjhgfdsazxcvbnmQWERTYU1234567890IOPÑLKJHGFDSAZXCVBNM.áó_ " & Chr(8), e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Public Shared Sub ValidarLetrasyNumeros(e As KeyPressEventArgs)
        'Validamos para ingresar solo letras y numeros
        If InStr("qwertyuiopñlkjhgfdsazxcvbnmQWERTYUIOPÑLKJHGFDSAZXCVBNM,.áó-_ 0123456789" & Chr(8), e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Public Shared Sub ValidarNumerosDecimales(e As KeyPressEventArgs)
        'Validamos para ingresar solo los numeros decimales
        If InStr("0123456789.," & Chr(8), e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub
    Public Shared Sub ValidarNumerosDecimalessin_coma(e As KeyPressEventArgs)
        'Validamos para ingresar solo los numeros decimales
        If InStr("0123456789." & Chr(8), e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    ' Método para validar si solo se ingresan números o un punto decimal
    Public Shared Sub ValidarDecimalEstricto(sender As Object, e As KeyPressEventArgs)
        Dim txt As Object = sender
        If TypeOf txt Is UltraTextEditor Then
            txt = TryCast(txt, UltraTextEditor)
        ElseIf TypeOf txt Is TextBox Then
            txt = TryCast(txt, TextBox)
        Else
            Return
        End If
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "."c AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
        If e.KeyChar = "."c AndAlso txt.Text.Contains(".") Then
            e.Handled = True
        End If
        If e.KeyChar = "."c AndAlso txt.SelectionStart = 0 Then
            e.Handled = True
        End If
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = True
        End If
        If txt.Text.Contains(".") Then
            Dim decimals As String = txt.Text.Substring(txt.Text.IndexOf("."c) + 1)
            If decimals.Length >= 4 AndAlso Char.IsDigit(e.KeyChar) Then 'esto ayuda para decimales, solo va a permitir ingresar 2 decimales
                e.Handled = True
            End If
        End If
    End Sub

    Public Shared Function ExportarExcel(nombre As String, dtg As UltraGrid) As String
        Dim folder As New FolderBrowserDialog
        If (dtg.Rows.Count = 0) Then
            msj_advert("No existen Registros vuelva a Buscar por Favor")
            Return ""
        Else
            If folder.ShowDialog() = 1 Then
                Dim ridToToExcel = New UltraGridExcelExporter()
                Dim ruta As String = folder.SelectedPath & "\" & nombre.Replace("*", "") & "" & Now.Date.ToShortDateString.Replace("/", "_") & "_" & "" & Now.Hour.ToString & "" & Now.Minute.ToString & "" & Now.Second.ToString & ".xlsx"
                ridToToExcel.Export(dtg, ruta)
                msj_ok("Documento Exportado Correctamente")
                System.Diagnostics.Process.Start(ruta)
            End If
        End If
        Return ""
    End Function

    Public Shared Sub controlException(modulo As [String], ex As Exception)
        Dim mensaje As String = "Excepción: " & ex.Message & vbCr & "Módulo: " & modulo & vbCr & "Método: " & ex.TargetSite.Name & vbCr & "Por favor notifique al Área de Sistemas" & vbCr & "Por favor indique en su mensaje la información mostrada en éste formulario " & vbCr & "así como una explicación de que acciones previas provocaron ésta exceptión"
        mensaje = mensaje.ToUpper
        Dim titulo As String = "Excepción inesperada en el Sistema"
        titulo = titulo.ToUpper
        MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    Public Shared Function Ruta_Reporte(nombres As String) As String
        Dim s As String = Application.StartupPath & "\Reportes\" & nombres
        Return s
    End Function

    Public Shared Function Agrupar_Tabla(tabla As UltraGrid, agrupar As Boolean) As Integer
        If (agrupar) Then
            tabla.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
            tabla.DisplayLayout.GroupByBox.Hidden = False
        Else
            tabla.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
            tabla.DisplayLayout.GroupByBox.Hidden = True
        End If
        Return 0
    End Function

    Public Shared Function Filtrar_Tabla(tabla As UltraGrid, filtrar As Boolean) As Integer
        'Configuracion para realizar un filtro estandar para todas las grillas que invoquemos
        If (filtrar) Then
            tabla.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
            'tabla.DisplayLayout.Override.AllowRowSummaries = DefaultableBoolean.True
        Else
            Dim band As UltraGridBand
            For Each band In tabla.DisplayLayout.Bands
                ' ya que todas las filas de una banda tienen los mismos filtros en RowFilterMode.AllRowsInBand this
                ' limpiará los filtros
                band.ColumnFilters.ClearAllFilters()
            Next
            tabla.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.False
            'tabla.DisplayLayout.Override.AllowRowSummaries = DefaultableBoolean.False
            'tabla.DisplayLayout.Override.SummaryDisplayArea = SummaryDisplayAreas.tr
        End If
        Return 0
    End Function

    Public Shared Sub Formato_Tablas_Grid(nombre As UltraGrid)
        ' Definición y asignación de colores personalizados para el grid
        Dim color_marron As Color = Color.FromArgb(84, 64, 50)
        Dim color_crema As Color = Color.FromArgb(224, 224, 224)
        Dim color_seleccion As Color = Color.FromArgb(226, 242, 167)

        ' Configuración de la fuente para el UltraGrid
        nombre.Font = New Font("Segoe UI", 8.5!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))

        ' Configuración del diseño del grid
        With nombre.DisplayLayout

            ' Alineación vertical del texto en las celdas
            .Appearance.TextVAlign = VAlign.Middle

            ' Deshabilitar la eliminación de filas
            .Override.AllowDelete = DefaultableBoolean.False

            ' Deshabilitar la actualización (edición) de celdas
            .Override.AllowUpdate = DefaultableBoolean.False

            ' Configuración de la navegación por Tab
            .TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl

            ' Mostrar filas vacías en el grid
            .EmptyRowSettings.ShowEmptyRows = True

            ' Configuración de los conectores de fila
            .RowConnectorColor = Color.Red
            .RowConnectorStyle = RowConnectorStyle.Dashed

            ' Estilo de desplazamiento inmediato
            .ScrollStyle = ScrollStyle.Immediate

            ' Configuración de la apariencia general del grid
            With .Appearance
                .ImageHAlign = HAlign.Default
                .ImageVAlign = VAlign.Middle
                .TextHAlign = HAlign.Left
                .TextVAlign = VAlign.Middle
                .BackColor = color_crema
                .BackColor2 = color_crema
                .BorderColor = Color.Gainsboro
                .BorderColor2 = Color.Gainsboro
                .ForeColor = Color.Black
            End With

            ' Configuración de la caja de agrupar por columnas (GroupByBox)
            With .GroupByBox
                .BorderStyle = UIElementBorderStyle.Solid
                .Hidden = True
                With .Appearance
                    .BackColor = Color.White
                    .BackColor2 = Color.White
                    .BackGradientStyle = GradientStyle.Vertical
                    .BorderColor = SystemColors.Window
                End With
            End With

            ' Configuración de la apariencia de las celdas y filas
            With .Override
                ' Apariencia de los encabezados de columna
                With .HeaderAppearance
                    .TextHAlignAsString = "Center"
                    .TextVAlignAsString = "Middle"
                    .BackColor = color_crema
                    .BackColor2 = color_crema
                    .ForeColor = Color.Black
                End With

                ' Apariencia de las filas en estado normal
                With .RowAppearance
                    .BackColor = SystemColors.Window
                    .BorderColor = Color.Silver
                End With

                ' Apariencia de la fila seleccionada
                With .SelectedRowAppearance
                    .TextVAlignAsString = "Middle"
                    .BackColor = color_seleccion
                    .BackColor2 = color_seleccion
                    .ForeColor = Color.Black
                End With

                ' Apariencia de la celda activa
                With .ActiveCellAppearance
                    .TextVAlignAsString = "Middle"
                    .BackColor = color_seleccion
                    .BackColor2 = color_seleccion
                    .ForeColor = Color.Black
                End With

                ' Apariencia de la fila activa
                With .ActiveRowAppearance
                    .TextVAlignAsString = "Middle"
                    .BackColor = color_seleccion
                    .BackColor2 = color_seleccion
                    .ForeColor = Color.Black
                End With
            End With
        End With

        'Configuración para ajustar automáticamente todas las columnas en función del contenido
        nombre.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        nombre.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
    End Sub

    Public Shared Sub Formato_Tablas_Grid_Sin_Ajustar(nombre As UltraGrid)
        ' Definición y asignación de colores personalizados para el grid
        Dim color_marron As Color = Color.FromArgb(84, 64, 50)
        Dim color_crema As Color = Color.FromArgb(224, 224, 224)
        Dim color_seleccion As Color = Color.FromArgb(226, 242, 167)

        ' Configuración de la fuente para el UltraGrid
        nombre.Font = New Font("Segoe UI", 8.5!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))

        ' Configuración del diseño del grid
        With nombre.DisplayLayout

            ' Alineación vertical del texto en las celdas
            .Appearance.TextVAlign = VAlign.Middle

            ' Deshabilitar la eliminación de filas
            .Override.AllowDelete = DefaultableBoolean.False

            ' Deshabilitar la actualización (edición) de celdas
            .Override.AllowUpdate = DefaultableBoolean.False

            ' Configuración de la navegación por Tab
            .TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl

            ' Mostrar filas vacías en el grid
            .EmptyRowSettings.ShowEmptyRows = True

            ' Configuración de los conectores de fila
            .RowConnectorColor = Color.Red
            .RowConnectorStyle = RowConnectorStyle.Dashed

            ' Estilo de desplazamiento inmediato
            .ScrollStyle = ScrollStyle.Immediate

            ' Configuración de la apariencia general del grid
            With .Appearance
                .ImageHAlign = HAlign.Default
                .ImageVAlign = VAlign.Middle
                .TextHAlign = HAlign.Left
                .TextVAlign = VAlign.Middle
                .BackColor = color_crema
                .BackColor2 = color_crema
                .BorderColor = Color.Gainsboro
                .BorderColor2 = Color.Gainsboro
                .ForeColor = Color.Black
            End With

            ' Configuración de la caja de agrupar por columnas (GroupByBox)
            With .GroupByBox
                .BorderStyle = UIElementBorderStyle.Solid
                .Hidden = True
                With .Appearance
                    .BackColor = Color.White
                    .BackColor2 = Color.White
                    .BackGradientStyle = GradientStyle.Vertical
                    .BorderColor = SystemColors.Window
                End With
            End With

            ' Configuración de la apariencia de las celdas y filas
            With .Override
                ' Apariencia de los encabezados de columna
                With .HeaderAppearance
                    .TextHAlignAsString = "Center"
                    .TextVAlignAsString = "Middle"
                    .BackColor = color_crema
                    .BackColor2 = color_crema
                    .ForeColor = Color.Black
                End With

                ' Apariencia de las filas en estado normal
                With .RowAppearance
                    .BackColor = SystemColors.Window
                    .BorderColor = Color.Silver
                End With

                ' Apariencia de la fila seleccionada
                With .SelectedRowAppearance
                    .TextVAlignAsString = "Middle"
                    .BackColor = color_seleccion
                    .BackColor2 = color_seleccion
                    .ForeColor = Color.Black
                End With

                ' Apariencia de la celda activa
                With .ActiveCellAppearance
                    .TextVAlignAsString = "Middle"
                    .BackColor = color_seleccion
                    .BackColor2 = color_seleccion
                    .ForeColor = Color.Black
                End With

                ' Apariencia de la fila activa
                With .ActiveRowAppearance
                    .TextVAlignAsString = "Middle"
                    .BackColor = color_seleccion
                    .BackColor2 = color_seleccion
                    .ForeColor = Color.Black
                End With
            End With
        End With

        ' Deshabilitar ajuste automático
        nombre.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None

        ' Configurar independencia de las bandas
        nombre.DisplayLayout.Override.RowSizing = UltraWinGrid.RowSizing.Free
        nombre.DisplayLayout.Override.RowSizingArea = Infragistics.Win.UltraWinGrid.RowSizingArea.Default
        ' Verificar y configurar bandas
        If nombre.DisplayLayout.Bands.Count > 0 Then
            nombre.DisplayLayout.Bands(0).RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.None
        End If

        If nombre.DisplayLayout.Bands.Count > 1 Then
            nombre.DisplayLayout.Bands(1).RowLayoutStyle = Infragistics.Win.UltraWinGrid.RowLayoutStyle.None
        End If
        nombre.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free
        nombre.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate
        nombre.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill
    End Sub

    Public Shared Sub Formato_Tablas_Grid_Asistencia(nombre As UltraGrid)
        ' Definición y asignación de colores personalizados para el grid
        Dim color_marron As Color = Color.FromArgb(84, 64, 50)
        Dim color_crema As Color = Color.FromArgb(224, 224, 224)
        Dim color_seleccion As Color = Color.FromArgb(226, 242, 167)

        ' Configuración de la fuente para el UltraGrid
        nombre.Font = New Font("Segoe UI", 8.5!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))

        ' Configuración del diseño del grid
        With nombre.DisplayLayout
            ' Alineación vertical del texto en las celdas
            .Appearance.TextVAlign = VAlign.Middle

            ' Deshabilitar la eliminación de filas
            .Override.AllowDelete = DefaultableBoolean.False

            ' Deshabilitar la actualización (edición) de celdas
            .Override.AllowUpdate = DefaultableBoolean.False

            ' Configuración de la navegación por Tab
            .TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl

            ' Mostrar filas vacías en el grid
            .EmptyRowSettings.ShowEmptyRows = True

            ' Configuración de los conectores de fila
            .RowConnectorColor = Color.Red
            .RowConnectorStyle = RowConnectorStyle.Dashed

            ' Estilo de desplazamiento inmediato
            .ScrollStyle = ScrollStyle.Immediate

            ' Configuración de la apariencia general del grid
            With .Appearance
                .ImageHAlign = HAlign.Default
                .ImageVAlign = VAlign.Middle
                .TextHAlign = HAlign.Left
                .TextVAlign = VAlign.Middle
                .BackColor = color_crema
                .BackColor2 = color_crema
                .BorderColor = Color.Gainsboro
                .BorderColor2 = Color.Gainsboro
                .ForeColor = Color.Black
            End With

            ' Configuración de la caja de agrupar por columnas (GroupByBox)
            With .GroupByBox
                .BorderStyle = UIElementBorderStyle.Solid
                .Hidden = True
                With .Appearance
                    .BackColor = Color.White
                    .BackColor2 = Color.White
                    .BackGradientStyle = GradientStyle.Vertical
                    .BorderColor = SystemColors.Window
                End With
            End With

            ' Configuración de la apariencia de las celdas y filas
            With .Override
                ' Apariencia de los encabezados de columna
                With .HeaderAppearance
                    .TextHAlignAsString = "Center"
                    .TextVAlignAsString = "Middle"
                    .BackColor = color_crema
                    .BackColor2 = color_crema
                    .ForeColor = Color.Black
                End With

                ' Apariencia de las filas en estado normal
                With .RowAppearance
                    .BackColor = SystemColors.Window
                    .BorderColor = Color.Silver
                End With

                ' Apariencia de la fila seleccionada
                With .SelectedRowAppearance
                    .TextVAlignAsString = "Middle"
                    .BackColor = color_seleccion
                    .BackColor2 = color_seleccion
                    .ForeColor = Color.Black
                End With

                ' Apariencia de la celda activa
                With .ActiveCellAppearance
                    .TextVAlignAsString = "Middle"
                    .BackColor = color_seleccion
                    .BackColor2 = color_seleccion
                    .ForeColor = Color.Black
                End With

                ' Apariencia de la fila activa
                With .ActiveRowAppearance
                    .TextVAlignAsString = "Middle"
                    .BackColor = color_seleccion
                    .BackColor2 = color_seleccion
                    .ForeColor = Color.Black
                End With
            End With
        End With

        ' Configuración para ajustar automáticamente todas las columnas en función del contenido
        nombre.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
    End Sub

    Public Shared Sub Formato_Tablas_Grid_Simulacion(nombre As UltraGrid)
        ' Definición y asignación de colores personalizados para el grid (igual que Formato_Tablas_Grid)
        Dim color_marron As Color = Color.FromArgb(84, 64, 50)
        Dim color_crema As Color = Color.FromArgb(224, 224, 224)
        Dim color_seleccion As Color = Color.FromArgb(226, 242, 167)

        ' Configuración de la fuente para el UltraGrid (igual que Formato_Tablas_Grid)
        nombre.Font = New Font("Segoe UI", 8.5!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))

        With nombre.DisplayLayout
            ' FUNCIONALIDAD ESPECÍFICA DE SIMULACIÓN: Primera fila editable, resto no editable
            If nombre.Rows.Count > 0 Then
                Dim primeraFila As Infragistics.Win.UltraWinGrid.UltraGridRow = nombre.Rows(0)
                For Each cell As Infragistics.Win.UltraWinGrid.UltraGridCell In primeraFila.Cells
                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                Next
            End If
            For i As Integer = 1 To nombre.Rows.Count - 1
                Dim fila As Infragistics.Win.UltraWinGrid.UltraGridRow = nombre.Rows(i)
                For Each cell As Infragistics.Win.UltraWinGrid.UltraGridCell In fila.Cells
                    cell.Activation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
                Next
            Next

            ' FORMATO VISUAL IGUAL A Formato_Tablas_Grid
            ' Alineación vertical del texto en las celdas
            .Appearance.TextVAlign = VAlign.Middle

            ' Deshabilitar la eliminación de filas
            .Override.AllowDelete = DefaultableBoolean.False

            ' Deshabilitar la actualización (edición) de celdas por defecto
            .Override.AllowUpdate = DefaultableBoolean.True

            ' Configuración de la navegación por Tab
            .TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl

            ' Mostrar filas vacías en el grid
            .EmptyRowSettings.ShowEmptyRows = True
            .EmptyRowSettings.Style = Infragistics.Win.UltraWinGrid.EmptyRowStyle.AlignWithDataRows

            ' Configuración de los conectores de fila
            .RowConnectorColor = Color.Red
            .RowConnectorStyle = RowConnectorStyle.Dashed

            ' Estilo de desplazamiento inmediato
            .ScrollStyle = ScrollStyle.Immediate

            ' Configuración de la apariencia general del grid
            With .Appearance
                .ImageHAlign = HAlign.Default
                .ImageVAlign = VAlign.Middle
                .TextHAlign = HAlign.Left
                .TextVAlign = VAlign.Middle
                .BackColor = color_crema
                .BackColor2 = color_crema
                .BorderColor = Color.Gainsboro
                .BorderColor2 = Color.Gainsboro
                .ForeColor = Color.Black
            End With

            ' Configuración de la caja de agrupar por columnas (GroupByBox)
            With .GroupByBox
                .BorderStyle = UIElementBorderStyle.Solid
                .Hidden = True
                With .Appearance
                    .BackColor = Color.White
                    .BackColor2 = Color.White
                    .BackGradientStyle = GradientStyle.Vertical
                    .BorderColor = SystemColors.Window
                End With
            End With

            ' Configuración de la apariencia de las celdas y filas
            With .Override
                ' Apariencia de los encabezados de columna
                With .HeaderAppearance
                    .TextHAlignAsString = "Center"
                    .TextVAlignAsString = "Middle"
                    .BackColor = color_crema
                    .BackColor2 = color_crema
                    .ForeColor = Color.Black
                End With

                ' Apariencia de las filas en estado normal
                With .RowAppearance
                    .BackColor = SystemColors.Window
                    .BorderColor = Color.Silver
                End With

                ' Apariencia de la fila seleccionada
                With .SelectedRowAppearance
                    .TextVAlignAsString = "Middle"
                    .BackColor = color_seleccion
                    .BackColor2 = color_seleccion
                    .ForeColor = Color.Black
                End With

                ' Apariencia de la celda activa
                With .ActiveCellAppearance
                    .TextVAlignAsString = "Middle"
                    .BackColor = color_seleccion
                    .BackColor2 = color_seleccion
                    .ForeColor = Color.Black
                End With

                ' Apariencia de la fila activa
                With .ActiveRowAppearance
                    .TextVAlignAsString = "Middle"
                    .BackColor = color_seleccion
                    .BackColor2 = color_seleccion
                    .ForeColor = Color.Black
                End With
            End With

            ' Configuración para ajustar automáticamente todas las columnas en función del contenido
            .AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
            .Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti
        End With
    End Sub

    Public Shared Sub Formato_Tablas_Grid_UltimaColumnaEditable(nombre As UltraGrid)
        Dim color_marron As Color = Color.FromArgb(84, 64, 50)
        Dim color_crema As Color = Color.FromArgb(224, 224, 224)
        Dim color_seleccion As Color = Color.FromArgb(226, 242, 167)

        nombre.Font = New Font("Segoe UI", 8.5!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))

        With nombre.DisplayLayout
            .Appearance.TextVAlign = VAlign.Middle
            .Override.AllowDelete = DefaultableBoolean.False
            .TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl

            .EmptyRowSettings.ShowEmptyRows = True

            .RowConnectorColor = Color.Red
            .RowConnectorStyle = RowConnectorStyle.Dashed

            .ScrollStyle = ScrollStyle.Immediate

            With .Appearance
                .ImageHAlign = HAlign.Default
                .ImageVAlign = VAlign.Middle
                .TextHAlign = HAlign.Left
                .TextVAlign = VAlign.Middle
                .BackColor = color_crema
                .BackColor2 = color_crema
                .BorderColor = Color.Gainsboro
                .BorderColor2 = Color.Gainsboro
                .ForeColor = Color.Black
            End With

            With .GroupByBox
                .BorderStyle = UIElementBorderStyle.Solid
                .Hidden = True
                With .Appearance
                    .BackColor = Color.White
                    .BackColor2 = Color.White
                    .BackGradientStyle = GradientStyle.Vertical
                    .BorderColor = SystemColors.Window
                End With
            End With

            With .Override
                .HeaderAppearance.TextHAlignAsString = "Center"
                .HeaderAppearance.TextVAlignAsString = "Middle"
                .HeaderAppearance.BackColor = color_crema
                .HeaderAppearance.ForeColor = Color.Black

                .RowAppearance.BackColor = SystemColors.Window
                .RowAppearance.BorderColor = Color.Silver

                .SelectedRowAppearance.BackColor = color_seleccion
                .SelectedRowAppearance.ForeColor = Color.Black

                .ActiveCellAppearance.BackColor = color_seleccion
                .ActiveCellAppearance.ForeColor = Color.Black

                .ActiveRowAppearance.BackColor = color_seleccion
                .ActiveRowAppearance.ForeColor = Color.Black

                .AllowUpdate = DefaultableBoolean.True
            End With
        End With

        nombre.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn

        AddHandler nombre.InitializeLayout, Sub(sender As Object, e As InitializeLayoutEventArgs)
                                                For i As Integer = 0 To e.Layout.Bands(0).Columns.Count - 2
                                                    e.Layout.Bands(0).Columns(i).CellActivation = Activation.NoEdit
                                                Next

                                                e.Layout.Bands(0).Columns(e.Layout.Bands(0).Columns.Count - 1).CellActivation = Activation.AllowEdit
                                            End Sub
    End Sub

    Public Shared Sub Formato_Tablas_Grid_AntePenultimaColumnaEditable(nombre As UltraGrid)
        Dim color_marron As Color = Color.FromArgb(84, 64, 50)
        Dim color_crema As Color = Color.FromArgb(224, 224, 224)
        Dim color_seleccion As Color = Color.FromArgb(226, 242, 167)

        nombre.Font = New Font("Segoe UI", 8.5!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))

        With nombre.DisplayLayout
            .Appearance.TextVAlign = VAlign.Middle
            .Override.AllowDelete = DefaultableBoolean.False
            .TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl

            .EmptyRowSettings.ShowEmptyRows = True

            .RowConnectorColor = Color.Red
            .RowConnectorStyle = RowConnectorStyle.Dashed

            .ScrollStyle = ScrollStyle.Immediate

            With .Appearance
                .ImageHAlign = HAlign.Default
                .ImageVAlign = VAlign.Middle
                .TextHAlign = HAlign.Left
                .TextVAlign = VAlign.Middle
                .BackColor = color_crema
                .BackColor2 = color_crema
                .BorderColor = Color.Gainsboro
                .BorderColor2 = Color.Gainsboro
                .ForeColor = Color.Black
            End With

            With .GroupByBox
                .BorderStyle = UIElementBorderStyle.Solid
                .Hidden = True
                With .Appearance
                    .BackColor = Color.White
                    .BackColor2 = Color.White
                    .BackGradientStyle = GradientStyle.Vertical
                    .BorderColor = SystemColors.Window
                End With
            End With

            With .Override
                .HeaderAppearance.TextHAlignAsString = "Center"
                .HeaderAppearance.TextVAlignAsString = "Middle"
                .HeaderAppearance.BackColor = color_crema
                .HeaderAppearance.ForeColor = Color.Black

                .RowAppearance.BackColor = SystemColors.Window
                .RowAppearance.BorderColor = Color.Silver

                .SelectedRowAppearance.BackColor = color_seleccion
                .SelectedRowAppearance.ForeColor = Color.Black

                .ActiveCellAppearance.BackColor = color_seleccion
                .ActiveCellAppearance.ForeColor = Color.Black

                .ActiveRowAppearance.BackColor = color_seleccion
                .ActiveRowAppearance.ForeColor = Color.Black

                .AllowUpdate = DefaultableBoolean.True
            End With
        End With

        nombre.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns

        AddHandler nombre.InitializeLayout, Sub(sender As Object, e As InitializeLayoutEventArgs)
                                                For i As Integer = 0 To e.Layout.Bands(0).Columns.Count - 1
                                                    e.Layout.Bands(0).Columns(i).CellActivation = Activation.NoEdit
                                                Next

                                                e.Layout.Bands(0).Columns(e.Layout.Bands(0).Columns.Count - 2).CellActivation = Activation.AllowEdit
                                            End Sub
    End Sub

    Public Shared Sub Formato_Tablas_Grid_AnteAntePenultimaColumnaEditable(nombre As UltraGrid)
        Dim color_marron As Color = Color.FromArgb(84, 64, 50)
        Dim color_crema As Color = Color.FromArgb(224, 224, 224)
        Dim color_seleccion As Color = Color.FromArgb(226, 242, 167)

        nombre.Font = New Font("Segoe UI", 8.5!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))

        With nombre.DisplayLayout
            .Appearance.TextVAlign = VAlign.Middle
            .Override.AllowDelete = DefaultableBoolean.False
            .TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl

            .EmptyRowSettings.ShowEmptyRows = True

            .RowConnectorColor = Color.Red
            .RowConnectorStyle = RowConnectorStyle.Dashed

            .ScrollStyle = ScrollStyle.Immediate

            With .Appearance
                .ImageHAlign = HAlign.Default
                .ImageVAlign = VAlign.Middle
                .TextHAlign = HAlign.Left
                .TextVAlign = VAlign.Middle
                .BackColor = color_crema
                .BackColor2 = color_crema
                .BorderColor = Color.Gainsboro
                .BorderColor2 = Color.Gainsboro
                .ForeColor = Color.Black
            End With

            With .GroupByBox
                .BorderStyle = UIElementBorderStyle.Solid
                .Hidden = True
                With .Appearance
                    .BackColor = Color.White
                    .BackColor2 = Color.White
                    .BackGradientStyle = GradientStyle.Vertical
                    .BorderColor = SystemColors.Window
                End With
            End With

            With .Override
                .HeaderAppearance.TextHAlignAsString = "Center"
                .HeaderAppearance.TextVAlignAsString = "Middle"
                .HeaderAppearance.BackColor = color_crema
                .HeaderAppearance.ForeColor = Color.Black

                .RowAppearance.BackColor = SystemColors.Window
                .RowAppearance.BorderColor = Color.Silver

                .SelectedRowAppearance.BackColor = color_seleccion
                .SelectedRowAppearance.ForeColor = Color.Black

                .ActiveCellAppearance.BackColor = color_seleccion
                .ActiveCellAppearance.ForeColor = Color.Black

                .ActiveRowAppearance.BackColor = color_seleccion
                .ActiveRowAppearance.ForeColor = Color.Black

                .AllowUpdate = DefaultableBoolean.True
            End With
        End With

        nombre.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn

        AddHandler nombre.InitializeLayout, Sub(sender As Object, e As InitializeLayoutEventArgs)
                                                For i As Integer = 0 To e.Layout.Bands(0).Columns.Count - 1
                                                    e.Layout.Bands(0).Columns(i).CellActivation = Activation.NoEdit
                                                Next

                                                e.Layout.Bands(0).Columns(e.Layout.Bands(0).Columns.Count - 3).CellActivation = Activation.AllowEdit
                                            End Sub
    End Sub

    Public Shared Sub Formato_Tablas_Grid_DosUltimasColumnaEditable(nombre As UltraGrid)
        Dim color_marron As Color = Color.FromArgb(84, 64, 50)
        Dim color_crema As Color = Color.FromArgb(224, 224, 224)
        Dim color_seleccion As Color = Color.FromArgb(226, 242, 167)

        nombre.Font = New Font("Segoe UI", 8.5!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))

        With nombre.DisplayLayout
            .Appearance.TextVAlign = VAlign.Middle
            .Override.AllowDelete = DefaultableBoolean.False
            .TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl

            .EmptyRowSettings.ShowEmptyRows = True

            .RowConnectorColor = Color.Red
            .RowConnectorStyle = RowConnectorStyle.Dashed

            .ScrollStyle = ScrollStyle.Immediate

            With .Appearance
                .ImageHAlign = HAlign.Default
                .ImageVAlign = VAlign.Middle
                .TextHAlign = HAlign.Left
                .TextVAlign = VAlign.Middle
                .BackColor = color_crema
                .BackColor2 = color_crema
                .BorderColor = Color.Gainsboro
                .BorderColor2 = Color.Gainsboro
                .ForeColor = Color.Black
            End With

            With .GroupByBox
                .BorderStyle = UIElementBorderStyle.Solid
                .Hidden = True
                With .Appearance
                    .BackColor = Color.White
                    .BackColor2 = Color.White
                    .BackGradientStyle = GradientStyle.Vertical
                    .BorderColor = SystemColors.Window
                End With
            End With

            With .Override
                .HeaderAppearance.TextHAlignAsString = "Center"
                .HeaderAppearance.TextVAlignAsString = "Middle"
                .HeaderAppearance.BackColor = color_crema
                .HeaderAppearance.ForeColor = Color.Black

                .RowAppearance.BackColor = SystemColors.Window
                .RowAppearance.BorderColor = Color.Silver

                .SelectedRowAppearance.BackColor = color_seleccion
                .SelectedRowAppearance.ForeColor = Color.Black

                .ActiveCellAppearance.BackColor = color_seleccion
                .ActiveCellAppearance.ForeColor = Color.Black

                .ActiveRowAppearance.BackColor = color_seleccion
                .ActiveRowAppearance.ForeColor = Color.Black

                .AllowUpdate = DefaultableBoolean.True
            End With
        End With

        nombre.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn

        AddHandler nombre.InitializeLayout, Sub(sender As Object, e As InitializeLayoutEventArgs)
                                                For i As Integer = 0 To e.Layout.Bands(0).Columns.Count - 1
                                                    e.Layout.Bands(0).Columns(i).CellActivation = Activation.NoEdit
                                                Next

                                                ' Hacer editables las dos últimas columnas
                                                e.Layout.Bands(0).Columns(e.Layout.Bands(0).Columns.Count - 2).CellActivation = Activation.AllowEdit
                                                e.Layout.Bands(0).Columns(e.Layout.Bands(0).Columns.Count - 1).CellActivation = Activation.AllowEdit
                                            End Sub
    End Sub

    Public Shared Sub Formato_Tablas_Grid_TresUltimasColumnaEditable(nombre As UltraGrid)
        Dim color_marron As Color = Color.FromArgb(84, 64, 50)
        Dim color_crema As Color = Color.FromArgb(224, 224, 224)
        Dim color_seleccion As Color = Color.FromArgb(226, 242, 167)

        nombre.Font = New Font("Segoe UI", 8.5!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))

        With nombre.DisplayLayout
            .Appearance.TextVAlign = VAlign.Middle
            .Override.AllowDelete = DefaultableBoolean.False
            .TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl

            .EmptyRowSettings.ShowEmptyRows = True

            .RowConnectorColor = Color.Red
            .RowConnectorStyle = RowConnectorStyle.Dashed

            .ScrollStyle = ScrollStyle.Immediate

            With .Appearance
                .ImageHAlign = HAlign.Default
                .ImageVAlign = VAlign.Middle
                .TextHAlign = HAlign.Left
                .TextVAlign = VAlign.Middle
                .BackColor = color_crema
                .BackColor2 = color_crema
                .BorderColor = Color.Gainsboro
                .BorderColor2 = Color.Gainsboro
                .ForeColor = Color.Black
            End With

            With .GroupByBox
                .BorderStyle = UIElementBorderStyle.Solid
                .Hidden = True
                With .Appearance
                    .BackColor = Color.White
                    .BackColor2 = Color.White
                    .BackGradientStyle = GradientStyle.Vertical
                    .BorderColor = SystemColors.Window
                End With
            End With

            With .Override
                .HeaderAppearance.TextHAlignAsString = "Center"
                .HeaderAppearance.TextVAlignAsString = "Middle"
                .HeaderAppearance.BackColor = color_crema
                .HeaderAppearance.ForeColor = Color.Black

                .RowAppearance.BackColor = SystemColors.Window
                .RowAppearance.BorderColor = Color.Silver

                .SelectedRowAppearance.BackColor = color_seleccion
                .SelectedRowAppearance.ForeColor = Color.Black

                .ActiveCellAppearance.BackColor = color_seleccion
                .ActiveCellAppearance.ForeColor = Color.Black

                .ActiveRowAppearance.BackColor = color_seleccion
                .ActiveRowAppearance.ForeColor = Color.Black

                .AllowUpdate = DefaultableBoolean.True
            End With
        End With

        nombre.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn

        AddHandler nombre.InitializeLayout, Sub(sender As Object, e As InitializeLayoutEventArgs)
                                                For i As Integer = 0 To e.Layout.Bands(0).Columns.Count - 1
                                                    e.Layout.Bands(0).Columns(i).CellActivation = Activation.NoEdit
                                                Next

                                                ' Hacer editables las dos últimas columnas
                                                e.Layout.Bands(0).Columns(e.Layout.Bands(0).Columns.Count - 3).CellActivation = Activation.AllowEdit
                                                e.Layout.Bands(0).Columns(e.Layout.Bands(0).Columns.Count - 2).CellActivation = Activation.AllowEdit
                                                e.Layout.Bands(0).Columns(e.Layout.Bands(0).Columns.Count - 1).CellActivation = Activation.AllowEdit
                                            End Sub
    End Sub

    Public Shared Sub Formato_Tablas_Grid_CuatroUltimasColumnaEditable(nombre As UltraGrid)
        Dim color_marron As Color = Color.FromArgb(84, 64, 50)
        Dim color_crema As Color = Color.FromArgb(224, 224, 224)
        Dim color_seleccion As Color = Color.FromArgb(226, 242, 167)

        nombre.Font = New Font("Segoe UI", 8.5!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))

        With nombre.DisplayLayout
            .Appearance.TextVAlign = VAlign.Middle
            .Override.AllowDelete = DefaultableBoolean.False
            .TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl

            .EmptyRowSettings.ShowEmptyRows = True

            .RowConnectorColor = Color.Red
            .RowConnectorStyle = RowConnectorStyle.Dashed

            .ScrollStyle = ScrollStyle.Immediate

            With .Appearance
                .ImageHAlign = HAlign.Default
                .ImageVAlign = VAlign.Middle
                .TextHAlign = HAlign.Left
                .TextVAlign = VAlign.Middle
                .BackColor = color_crema
                .BackColor2 = color_crema
                .BorderColor = Color.Gainsboro
                .BorderColor2 = Color.Gainsboro
                .ForeColor = Color.Black
            End With

            With .GroupByBox
                .BorderStyle = UIElementBorderStyle.Solid
                .Hidden = True
                With .Appearance
                    .BackColor = Color.White
                    .BackColor2 = Color.White
                    .BackGradientStyle = GradientStyle.Vertical
                    .BorderColor = SystemColors.Window
                End With
            End With

            With .Override
                .HeaderAppearance.TextHAlignAsString = "Center"
                .HeaderAppearance.TextVAlignAsString = "Middle"
                .HeaderAppearance.BackColor = color_crema
                .HeaderAppearance.ForeColor = Color.Black

                .RowAppearance.BackColor = SystemColors.Window
                .RowAppearance.BorderColor = Color.Silver

                .SelectedRowAppearance.BackColor = color_seleccion
                .SelectedRowAppearance.ForeColor = Color.Black

                .ActiveCellAppearance.BackColor = color_seleccion
                .ActiveCellAppearance.ForeColor = Color.Black

                .ActiveRowAppearance.BackColor = color_seleccion
                .ActiveRowAppearance.ForeColor = Color.Black

                .AllowUpdate = DefaultableBoolean.True
            End With
        End With

        nombre.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn

        AddHandler nombre.InitializeLayout, Sub(sender As Object, e As InitializeLayoutEventArgs)
                                                For i As Integer = 0 To e.Layout.Bands(0).Columns.Count - 1
                                                    e.Layout.Bands(0).Columns(i).CellActivation = Activation.NoEdit
                                                Next

                                                ' Hacer editables las dos últimas columnas
                                                e.Layout.Bands(0).Columns(e.Layout.Bands(0).Columns.Count - 4).CellActivation = Activation.AllowEdit
                                                e.Layout.Bands(0).Columns(e.Layout.Bands(0).Columns.Count - 3).CellActivation = Activation.AllowEdit
                                                e.Layout.Bands(0).Columns(e.Layout.Bands(0).Columns.Count - 2).CellActivation = Activation.AllowEdit
                                                e.Layout.Bands(0).Columns(e.Layout.Bands(0).Columns.Count - 1).CellActivation = Activation.AllowEdit
                                            End Sub
    End Sub

    Public Shared Sub Formato_Tablas_Grid_PrimeraColumnaEditable(nombre As UltraGrid)
        Dim color_marron As Color = Color.FromArgb(84, 64, 50)
        Dim color_crema As Color = Color.FromArgb(224, 224, 224)
        Dim color_seleccion As Color = Color.FromArgb(226, 242, 167)
        nombre.Font = New Font("Segoe UI", 8.5!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        With nombre.DisplayLayout
            .Appearance.TextVAlign = VAlign.Middle
            .Override.AllowDelete = DefaultableBoolean.False
            .TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl
            .EmptyRowSettings.ShowEmptyRows = True
            .RowConnectorColor = Color.Red
            .RowConnectorStyle = RowConnectorStyle.Dashed
            .ScrollStyle = ScrollStyle.Immediate
            With .Appearance
                .ImageHAlign = HAlign.Default
                .ImageVAlign = VAlign.Middle
                .TextHAlign = HAlign.Left
                .TextVAlign = VAlign.Middle
                .BackColor = color_crema
                .BackColor2 = color_crema
                .BorderColor = Color.Gainsboro
                .BorderColor2 = Color.Gainsboro
                .ForeColor = Color.Black
            End With
            With .GroupByBox
                .BorderStyle = UIElementBorderStyle.Solid
                .Hidden = True
                With .Appearance
                    .BackColor = Color.White
                    .BackColor2 = Color.White
                    .BackGradientStyle = GradientStyle.Vertical
                    .BorderColor = SystemColors.Window
                End With
            End With
            With .Override
                .HeaderAppearance.TextHAlignAsString = "Center"
                .HeaderAppearance.TextVAlignAsString = "Middle"
                .HeaderAppearance.BackColor = color_crema
                .HeaderAppearance.ForeColor = Color.Black
                .RowAppearance.BackColor = SystemColors.Window
                .RowAppearance.BorderColor = Color.Silver
                .SelectedRowAppearance.BackColor = color_seleccion
                .SelectedRowAppearance.ForeColor = Color.Black
                .ActiveCellAppearance.BackColor = color_seleccion
                .ActiveCellAppearance.ForeColor = Color.Black
                .ActiveRowAppearance.BackColor = color_seleccion
                .ActiveRowAppearance.ForeColor = Color.Black
                .AllowUpdate = DefaultableBoolean.True
            End With
        End With
        nombre.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn
        AddHandler nombre.InitializeLayout, Sub(sender As Object, e As InitializeLayoutEventArgs)
                                                ' Hacer todas las columnas no editables primero
                                                For i As Integer = 0 To e.Layout.Bands(0).Columns.Count - 1
                                                    e.Layout.Bands(0).Columns(i).CellActivation = Activation.NoEdit
                                                Next
                                                ' Hacer editable solo la primera columna (índice 0)
                                                If e.Layout.Bands(0).Columns.Count > 0 Then
                                                    e.Layout.Bands(0).Columns(0).CellActivation = Activation.AllowEdit
                                                End If
                                            End Sub
    End Sub

    Public Shared Sub Formato_Tablas_Grid_SegundaColumnaEditable(nombre As UltraGrid)
        Dim color_marron As Color = Color.FromArgb(84, 64, 50)
        Dim color_crema As Color = Color.FromArgb(224, 224, 224)
        Dim color_seleccion As Color = Color.FromArgb(226, 242, 167)
        nombre.Font = New Font("Segoe UI", 8.5!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        With nombre.DisplayLayout
            .Appearance.TextVAlign = VAlign.Middle
            .Override.AllowDelete = DefaultableBoolean.False
            .TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl
            .EmptyRowSettings.ShowEmptyRows = True
            .RowConnectorColor = Color.Red
            .RowConnectorStyle = RowConnectorStyle.Dashed
            .ScrollStyle = ScrollStyle.Immediate
            With .Appearance
                .ImageHAlign = HAlign.Default
                .ImageVAlign = VAlign.Middle
                .TextHAlign = HAlign.Left
                .TextVAlign = VAlign.Middle
                .BackColor = color_crema
                .BackColor2 = color_crema
                .BorderColor = Color.Gainsboro
                .BorderColor2 = Color.Gainsboro
                .ForeColor = Color.Black
            End With
            With .GroupByBox
                .BorderStyle = UIElementBorderStyle.Solid
                .Hidden = True
                With .Appearance
                    .BackColor = Color.White
                    .BackColor2 = Color.White
                    .BackGradientStyle = GradientStyle.Vertical
                    .BorderColor = SystemColors.Window
                End With
            End With
            With .Override
                .HeaderAppearance.TextHAlignAsString = "Center"
                .HeaderAppearance.TextVAlignAsString = "Middle"
                .HeaderAppearance.BackColor = color_crema
                .HeaderAppearance.ForeColor = Color.Black
                .RowAppearance.BackColor = SystemColors.Window
                .RowAppearance.BorderColor = Color.Silver
                .SelectedRowAppearance.BackColor = color_seleccion
                .SelectedRowAppearance.ForeColor = Color.Black
                .ActiveCellAppearance.BackColor = color_seleccion
                .ActiveCellAppearance.ForeColor = Color.Black
                .ActiveRowAppearance.BackColor = color_seleccion
                .ActiveRowAppearance.ForeColor = Color.Black
                .AllowUpdate = DefaultableBoolean.True
            End With
        End With
        nombre.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn

        ' MODIFICACIÓN: Solo la segunda columna editable (índice 1)
        AddHandler nombre.InitializeLayout, Sub(sender As Object, e As InitializeLayoutEventArgs)
                                                ' Todas las columnas no editables
                                                For i As Integer = 0 To e.Layout.Bands(0).Columns.Count - 1
                                                    e.Layout.Bands(0).Columns(i).CellActivation = Activation.NoEdit
                                                Next

                                                ' Solo la segunda columna editable (índice 1)
                                                If e.Layout.Bands(0).Columns.Count >= 2 Then
                                                    e.Layout.Bands(0).Columns(1).CellActivation = Activation.AllowEdit
                                                End If
                                            End Sub
    End Sub

    Public Shared Sub Formato_Tablas_Grid_CincoUltimasColumnaEditable(nombre As UltraGrid)
        Dim color_marron As Color = Color.FromArgb(84, 64, 50)
        Dim color_crema As Color = Color.FromArgb(224, 224, 224)
        Dim color_seleccion As Color = Color.FromArgb(226, 242, 167)

        nombre.Font = New Font("Segoe UI", 8.5!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))

        With nombre.DisplayLayout
            .Appearance.TextVAlign = VAlign.Middle
            .Override.AllowDelete = DefaultableBoolean.False
            .TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl

            .EmptyRowSettings.ShowEmptyRows = True

            .RowConnectorColor = Color.Red
            .RowConnectorStyle = RowConnectorStyle.Dashed

            .ScrollStyle = ScrollStyle.Immediate

            With .Appearance
                .ImageHAlign = HAlign.Default
                .ImageVAlign = VAlign.Middle
                .TextHAlign = HAlign.Left
                .TextVAlign = VAlign.Middle
                .BackColor = color_crema
                .BackColor2 = color_crema
                .BorderColor = Color.Gainsboro
                .BorderColor2 = Color.Gainsboro
                .ForeColor = Color.Black
            End With

            With .GroupByBox
                .BorderStyle = UIElementBorderStyle.Solid
                .Hidden = True
                With .Appearance
                    .BackColor = Color.White
                    .BackColor2 = Color.White
                    .BackGradientStyle = GradientStyle.Vertical
                    .BorderColor = SystemColors.Window
                End With
            End With

            With .Override
                .HeaderAppearance.TextHAlignAsString = "Center"
                .HeaderAppearance.TextVAlignAsString = "Middle"
                .HeaderAppearance.BackColor = color_crema
                .HeaderAppearance.ForeColor = Color.Black

                .RowAppearance.BackColor = SystemColors.Window
                .RowAppearance.BorderColor = Color.Silver

                .SelectedRowAppearance.BackColor = color_seleccion
                .SelectedRowAppearance.ForeColor = Color.Black

                .ActiveCellAppearance.BackColor = color_seleccion
                .ActiveCellAppearance.ForeColor = Color.Black

                .ActiveRowAppearance.BackColor = color_seleccion
                .ActiveRowAppearance.ForeColor = Color.Black

                .AllowUpdate = DefaultableBoolean.True
            End With
        End With

        nombre.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn

        AddHandler nombre.InitializeLayout, Sub(sender As Object, e As InitializeLayoutEventArgs)
                                                For i As Integer = 0 To e.Layout.Bands(0).Columns.Count - 1
                                                    e.Layout.Bands(0).Columns(i).CellActivation = Activation.NoEdit
                                                Next

                                                ' Hacer editables las dos últimas columnas
                                                e.Layout.Bands(0).Columns(e.Layout.Bands(0).Columns.Count - 5).CellActivation = Activation.AllowEdit
                                                e.Layout.Bands(0).Columns(e.Layout.Bands(0).Columns.Count - 4).CellActivation = Activation.AllowEdit
                                                e.Layout.Bands(0).Columns(e.Layout.Bands(0).Columns.Count - 3).CellActivation = Activation.AllowEdit
                                                e.Layout.Bands(0).Columns(e.Layout.Bands(0).Columns.Count - 2).CellActivation = Activation.AllowEdit
                                                e.Layout.Bands(0).Columns(e.Layout.Bands(0).Columns.Count - 1).CellActivation = Activation.AllowEdit
                                            End Sub
    End Sub

    Public Shared Sub Formato_Tablas_Grid_Formula_Base(nombre As UltraGrid)
        Dim color_marron As Color = Color.FromArgb(84, 64, 50)
        Dim color_crema As Color = Color.FromArgb(224, 224, 224)
        Dim color_seleccion As Color = Color.FromArgb(226, 242, 167)

        nombre.Font = New Font("Segoe UI", 8.5!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))

        With nombre.DisplayLayout
            .Appearance.TextVAlign = VAlign.Middle

            .Override.AllowDelete = DefaultableBoolean.False

            .Override.AllowUpdate = DefaultableBoolean.True

            .TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl

            .EmptyRowSettings.ShowEmptyRows = True

            .RowConnectorColor = Color.Red
            .RowConnectorStyle = RowConnectorStyle.Dashed

            .ScrollStyle = ScrollStyle.Immediate

            With .Appearance
                .ImageHAlign = HAlign.Default
                .ImageVAlign = VAlign.Middle
                .TextHAlign = HAlign.Left
                .TextVAlign = VAlign.Middle
                .BackColor = color_crema
                .BackColor2 = color_crema
                .BorderColor = Color.Gainsboro
                .BorderColor2 = Color.Gainsboro
                .ForeColor = Color.Black
            End With

            With .GroupByBox
                .BorderStyle = UIElementBorderStyle.Solid
                .Hidden = True
                With .Appearance
                    .BackColor = Color.White
                    .BackColor2 = Color.White
                    .BackGradientStyle = GradientStyle.Vertical
                    .BorderColor = SystemColors.Window
                End With
            End With

            With .Override
                With .HeaderAppearance
                    .TextHAlignAsString = "Center"
                    .TextVAlignAsString = "Middle"
                    .BackColor = color_crema
                    .BackColor2 = color_crema
                    .ForeColor = Color.Black
                End With

                With .RowAppearance
                    .BackColor = SystemColors.Window
                    .BorderColor = Color.Silver
                End With

                With .SelectedRowAppearance
                    .TextVAlignAsString = "Middle"
                    .BackColor = color_seleccion
                    .BackColor2 = color_seleccion
                    .ForeColor = Color.Black
                End With

                With .ActiveCellAppearance
                    .TextVAlignAsString = "Middle"
                    .BackColor = color_seleccion
                    .BackColor2 = color_seleccion
                    .ForeColor = Color.Black
                End With

                With .ActiveRowAppearance
                    .TextVAlignAsString = "Middle"
                    .BackColor = color_seleccion
                    .BackColor2 = color_seleccion
                    .ForeColor = Color.Black
                End With
            End With

            For Each columna As UltraGridColumn In nombre.DisplayLayout.Bands(0).Columns
                If columna.Index = 0 Then
                    columna.CellActivation = Activation.NoEdit ' No permitir edición en la columna 0
                Else
                    columna.CellActivation = Activation.AllowEdit ' Permitir edición en las demás columnas
                    columna.MaskInput = "{double:9.2}"
                End If
            Next
        End With

        nombre.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ExtendLastColumn
    End Sub

    Public Shared Sub Totales_Formato(tabla As UltraGrid, e As InitializeLayoutEventArgs, indice_columna As Integer)
        ' Verifica si la tabla tiene filas antes de continuar
        If (tabla.Rows.Count > 0) Then
            ' Limpia cualquier resumen anterior del UltraGrid
            e.Layout.Bands(0).Summaries.Clear()

            ' Obtiene la primera banda del UltraGrid
            Dim gridband As UltraGridBand
            gridband = tabla.DisplayLayout.Bands(0)

            ' Agrega un resumen (conteo) para la columna especificada por 'indice_columna'
            ' y configura el formato de visualización del resumen
            gridband.Summaries.Add(SummaryType.Count, gridband.Columns(indice_columna)).DisplayFormat = "{0:###.##}"

            ' Configura el estilo de visualización del resumen en la vista de agrupar
            e.Layout.Override.GroupBySummaryDisplayStyle = GroupBySummaryDisplayStyle.SummaryCells

            ' Establece la apariencia del pie de resumen (Summary Footer)
            e.Layout.Override.SummaryFooterAppearance.BackColor = Color.Khaki

            ' Establece la apariencia del valor de resumen
            e.Layout.Override.SummaryValueAppearance.BackColor = Color.Khaki
            e.Layout.Override.SummaryValueAppearance.ForeColor = Color.Black
            e.Layout.Override.SummaryValueAppearance.FontData.Bold = DefaultableBoolean.True

            ' Establece la apariencia del valor de resumen cuando está agrupado
            e.Layout.Override.GroupBySummaryValueAppearance.BackColor = Color.Khaki
            e.Layout.Override.GroupBySummaryValueAppearance.ForeColor = Color.Black
            e.Layout.Override.GroupBySummaryValueAppearance.TextHAlign = HAlign.Left

            ' Configura el texto de pie de resumen en la banda
            e.Layout.Bands(0).SummaryFooterCaption = "N° Registros :"

            ' Establece la apariencia del texto de pie de resumen para que sea en negrita
            e.Layout.Override.SummaryFooterCaptionAppearance.FontData.Bold = DefaultableBoolean.True

            ' Asegura que el pie de resumen sea visible
            e.Layout.Override.SummaryFooterCaptionVisible = DefaultableBoolean.True
            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed
            ' Establece el espacio antes y después del pie de resumen
            e.Layout.Override.SummaryFooterSpacingAfter = 5
            e.Layout.Override.SummaryFooterSpacingBefore = 5
        End If
    End Sub

    Public Shared Sub SumarTotales_Formato(tabla As UltraGrid, e As InitializeLayoutEventArgs, indice_columna As Integer)

        ' Verifica si la tabla tiene filas antes de continuar
        If (tabla.Rows.Count > 0) Then

            ' Obtiene la primera banda del UltraGrid
            Dim gridband As UltraGridBand
            gridband = tabla.DisplayLayout.Bands(0)

            ' Agrega un resumen (suma) para la columna especificada por 'indice_columna'
            ' y configura el formato de visualización del resumen
            gridband.Summaries.Add(SummaryType.Sum, gridband.Columns(indice_columna)).DisplayFormat = "{0:###,###.##}"

            ' Configura el estilo de visualización del resumen en la vista de agrupar
            e.Layout.Override.GroupBySummaryDisplayStyle = GroupBySummaryDisplayStyle.SummaryCells

            ' Establece la apariencia del pie de resumen (Summary Footer)
            e.Layout.Override.SummaryFooterAppearance.BackColor = Color.Khaki

            ' Establece la apariencia del valor de resumen
            e.Layout.Override.SummaryValueAppearance.BackColor = Color.Khaki
            e.Layout.Override.SummaryValueAppearance.ForeColor = Color.Black
            e.Layout.Override.SummaryValueAppearance.FontData.Bold = DefaultableBoolean.True

            ' Establece la apariencia del valor de resumen cuando está agrupado
            e.Layout.Override.GroupBySummaryValueAppearance.BackColor = Color.Khaki
            e.Layout.Override.GroupBySummaryValueAppearance.ForeColor = Color.Black
            e.Layout.Override.GroupBySummaryValueAppearance.TextHAlign = HAlign.Right
            e.Layout.Override.SummaryValueAppearance.TextHAlign = HAlign.Right
            e.Layout.Override.GroupBySummaryValueAppearance.TextVAlign = HAlign.Right

            ' Configura el texto del pie de resumen para mostrar "Total :"
            e.Layout.Bands(0).SummaryFooterCaption = "Total :"
            e.Layout.Override.SummaryFooterCaptionAppearance.FontData.Bold = DefaultableBoolean.True
            e.Layout.Override.SummaryFooterCaptionAppearance.TextHAlign = HAlign.Left
            e.Layout.Override.SummaryFooterAppearance.TextHAlign = HAlign.Left

            ' Asegura que el pie de resumen sea visible
            e.Layout.Override.SummaryFooterCaptionVisible = DefaultableBoolean.True
            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed
            ' Establece el espacio antes y después del pie de resumen
            e.Layout.Override.SummaryFooterSpacingAfter = 5
            e.Layout.Override.SummaryFooterSpacingBefore = 5
        End If
    End Sub

    Public Shared Sub Formato_Tablas_Grid_Permisos(nombre As UltraGrid)
        Dim color_marron As Color = Color.FromArgb(84, 64, 50)
        Dim color_crema As Color = Color.FromArgb(224, 224, 224)
        Dim color_seleccion As Color = Color.FromArgb(226, 242, 167)
        nombre.Font = New Font("Segoe UI", 8.5!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))

        With nombre.DisplayLayout
            .Appearance.TextVAlign = VAlign.Middle
            .Override.AllowUpdate = DefaultableBoolean.True
            .TabNavigation = Infragistics.Win.UltraWinGrid.TabNavigation.NextControl
            .EmptyRowSettings.ShowEmptyRows = True
            .RowConnectorColor = Color.Red
            .RowConnectorStyle = RowConnectorStyle.Dashed
            .ScrollStyle = ScrollStyle.Immediate

            With .Appearance
                .ImageHAlign = HAlign.Default
                .ImageVAlign = VAlign.Middle
                .TextHAlign = HAlign.Left
                .TextVAlign = VAlign.Middle
                .BackColor = color_crema
                .BackColor2 = color_crema
                .BorderColor = Color.Gainsboro
                .BorderColor2 = Color.Gainsboro
                .ForeColor = Color.Black
            End With

            With .GroupByBox
                .BorderStyle = UIElementBorderStyle.Solid
                .Hidden = True
                With .Appearance
                    .BackColor = Color.White
                    .BackColor2 = Color.White
                    .BackGradientStyle = GradientStyle.Vertical
                    .BorderColor = SystemColors.Window
                End With
            End With

            With .Override
                With .HeaderAppearance
                    .TextHAlignAsString = "Center"
                    .TextVAlignAsString = "Middle"
                    .BackColor = color_crema
                    .BackColor2 = color_crema
                    .ForeColor = Color.Black
                End With

                With .RowAppearance
                    .BackColor = SystemColors.Window
                    .BorderColor = Color.Silver
                End With

                With .SelectedRowAppearance
                    .TextVAlignAsString = "Middle"
                    .BackColor = color_seleccion
                    .BackColor2 = color_seleccion
                    .ForeColor = Color.Black
                End With

                With .ActiveCellAppearance
                    .TextVAlignAsString = "Middle"
                    .BackColor = color_seleccion
                    .BackColor2 = color_seleccion
                    .ForeColor = Color.Black
                End With

                With .ActiveRowAppearance
                    .TextVAlignAsString = "Middle"
                    .BackColor = color_seleccion
                    .BackColor2 = color_seleccion
                    .ForeColor = Color.Black
                End With
            End With
        End With

        nombre.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
    End Sub

    Public Shared Sub PromedioTotales_Formato(tabla As UltraGrid, e As InitializeLayoutEventArgs, indice_columna As Integer)
        ' Verifica si la tabla tiene filas antes de continuar
        If (tabla.Rows.Count > 0) Then
            ' Obtiene la primera banda del UltraGrid
            Dim gridband As UltraGridBand
            gridband = tabla.DisplayLayout.Bands(0)
            ' Agrega un resumen (promedio) para la columna especificada por 'indice_columna'
            ' y configura el formato de visualización del resumen
            gridband.Summaries.Add(SummaryType.Average, gridband.Columns(indice_columna)).DisplayFormat = "{0:###,###.##}"
            ' Configura el estilo de visualización del resumen en la vista de agrupar
            e.Layout.Override.GroupBySummaryDisplayStyle = GroupBySummaryDisplayStyle.SummaryCells
            ' Establece la apariencia del pie de resumen (Summary Footer)
            e.Layout.Override.SummaryFooterAppearance.BackColor = Color.Khaki
            ' Establece la apariencia del valor de resumen
            e.Layout.Override.SummaryValueAppearance.BackColor = Color.Khaki
            e.Layout.Override.SummaryValueAppearance.ForeColor = Color.Black
            e.Layout.Override.SummaryValueAppearance.FontData.Bold = DefaultableBoolean.True
            ' Establece la apariencia del valor de resumen cuando está agrupado
            e.Layout.Override.GroupBySummaryValueAppearance.BackColor = Color.Khaki
            e.Layout.Override.GroupBySummaryValueAppearance.ForeColor = Color.Black
            e.Layout.Override.GroupBySummaryValueAppearance.TextHAlign = HAlign.Right
            e.Layout.Override.SummaryValueAppearance.TextHAlign = HAlign.Right
            e.Layout.Override.GroupBySummaryValueAppearance.TextVAlign = HAlign.Right
            ' Configura el texto del pie de resumen para mostrar "Promedio :"
            e.Layout.Bands(0).SummaryFooterCaption = "Promedio :"
            e.Layout.Override.SummaryFooterCaptionAppearance.FontData.Bold = DefaultableBoolean.True
            e.Layout.Override.SummaryFooterCaptionAppearance.TextHAlign = HAlign.Left
            e.Layout.Override.SummaryFooterAppearance.TextHAlign = HAlign.Left
            ' Asegura que el pie de resumen sea visible
            e.Layout.Override.SummaryFooterCaptionVisible = DefaultableBoolean.True
            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed
            ' Establece el espacio antes y después del pie de resumen
            e.Layout.Override.SummaryFooterSpacingAfter = 5
            e.Layout.Override.SummaryFooterSpacingBefore = 5
        End If
    End Sub

    Public Shared Sub PromedioTotales_divisiondoscolumnas(tabla As UltraGrid, e As InitializeLayoutEventArgs, indice_columna_numerador As Integer, indice_columna_denominador As Integer, indice_columna_mostrar As Integer)
        ' Verifica si la tabla tiene filas antes de continuar
        If (tabla.Rows.Count > 0) Then
            Try
                Dim gridband As UltraGridBand = tabla.DisplayLayout.Bands(0)

                ' Verifica que los índices sean válidos
                If indice_columna_numerador >= gridband.Columns.Count OrElse indice_columna_denominador >= gridband.Columns.Count OrElse indice_columna_mostrar >= gridband.Columns.Count Then
                    Debug.WriteLine("Error: Índices de columna fuera de rango")
                    Return
                End If

                ' Obtiene los nombres de las columnas para la fórmula
                Dim nombreColumnaNumerador As String = gridband.Columns(indice_columna_numerador).Key
                Dim nombreColumnaDenominador As String = gridband.Columns(indice_columna_denominador).Key

                ' Limpia cualquier resumen anterior de la banda
                For i As Integer = gridband.Summaries.Count - 1 To 0 Step -1
                    If gridband.Summaries(i).Key = "PromedioDivision" Then
                        gridband.Summaries.RemoveAt(i)
                    End If
                Next

                ' Crea la fórmula usando sintaxis compatible con UltraGrid
                Dim formula As String = String.Format("sum([{0}])/sum([{1}])", nombreColumnaNumerador, nombreColumnaDenominador)

                ' Agrega el resumen de fórmula a la banda (no a la columna)
                Dim summary As SummarySettings = gridband.Summaries.Add("PromedioDivision", SummaryType.Formula, Nothing)
                summary.Formula = formula
                summary.DisplayFormat = "{0:###,###.##}"
                summary.SummaryPosition = SummaryPosition.UseSummaryPositionColumn

                ' Configuraciones esenciales para mostrar resúmenes
                e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed
                e.Layout.Override.AllowRowSummaries = AllowRowSummaries.True

                ' Configuraciones de apariencia
                e.Layout.Override.SummaryValueAppearance.BackColor = Color.Khaki
                e.Layout.Override.SummaryValueAppearance.ForeColor = Color.Black
                e.Layout.Override.SummaryValueAppearance.FontData.Bold = DefaultableBoolean.True
                e.Layout.Override.SummaryValueAppearance.TextHAlign = HAlign.Right

                ' Configura el texto del pie de resumen
                e.Layout.Bands(0).SummaryFooterCaption = "Promedio Peso/Animal :"
                e.Layout.Override.SummaryFooterCaptionVisible = DefaultableBoolean.True

                Debug.WriteLine("Resumen agregado exitosamente")

            Catch ex As Exception
                Debug.WriteLine($"Error en PromedioTotales_divisiondoscolumnas: {ex.Message}")
            End Try
        End If
    End Sub


    ' MÉTODO ALTERNATIVO: Si el anterior no funciona, prueba este
    Public Shared Sub PromedioTotales_Alternativo(tabla As UltraGrid, e As InitializeLayoutEventArgs, indice_columna_numerador As Integer, indice_columna_denominador As Integer, indice_columna_mostrar As Integer)
        If tabla.Rows.Count > 0 Then
            Try
                Dim gridband As UltraGridBand = tabla.DisplayLayout.Bands(0)

                ' Método usando Custom Summary
                Dim summary As SummarySettings = gridband.Summaries.Add(SummaryType.Custom, gridband.Columns(indice_columna_mostrar))
                summary.Key = "DivisionCustom"
                summary.DisplayFormat = "{0:###,###.##}"

                ' Configuraciones básicas
                e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed
                e.Layout.Override.AllowRowSummaries = AllowRowSummaries.True

                ' Tendrás que manejar el evento SummaryValueChanged para calcular manualmente
                ' AddHandler tabla.SummaryValueChanged, AddressOf CalcularDivisionCustom

                Debug.WriteLine("Resumen personalizado agregado")

            Catch ex As Exception
                Debug.WriteLine($"Error: {ex.Message}")
            End Try
        End If
    End Sub

    ' MÉTODO MÁS SIMPLE: Solo para verificar que funcionen los resúmenes
    Public Shared Sub PromedioTotales_Test(tabla As UltraGrid, e As InitializeLayoutEventArgs, indice_columna As Integer)
        If tabla.Rows.Count > 0 Then
            Dim gridband As UltraGridBand = tabla.DisplayLayout.Bands(0)

            ' Prueba con un resumen simple primero
            Dim summary As SummarySettings = gridband.Summaries.Add(SummaryType.Sum, gridband.Columns(indice_columna))
            summary.DisplayFormat = "{0:###,###.##}"

            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed
            e.Layout.Override.AllowRowSummaries = AllowRowSummaries.True

            Debug.WriteLine("Resumen de prueba agregado")
        End If
    End Sub

    Public Shared Sub Colorear_SegunValor(tabla As UltraGrid, Color_Fondo As Color, Color_texto As Color, valor As String, columna As Integer)
        If (tabla.Rows.Count > 0) Then
            For index As Integer = 0 To tabla.Rows.Count - 1
                Dim estado As String = tabla.Rows(index).Cells(columna).Value.ToString
                If (estado = valor) Then
                    Dim i As Integer = columna
                    With tabla.Rows(index).Cells(i).SelectedAppearance
                        .BackColor = Color_Fondo
                        .FontData.Bold = DefaultableBoolean.True
                        .ForeColor = Color_texto
                    End With
                    With tabla.Rows(index).Cells(i).Appearance
                        .BackColor = Color_Fondo
                        .FontData.Bold = DefaultableBoolean.True
                        .ForeColor = Color_texto
                    End With
                    With tabla.Rows(index).Cells(i).ActiveAppearance
                        .BackColor = Color_Fondo
                        .FontData.Bold = DefaultableBoolean.True
                        .ForeColor = Color_texto
                    End With
                End If
            Next
        End If
    End Sub


    Public Shared Sub Colorear_SegunClave(tabla As UltraGrid, Color_Fondo As Color, Color_Texto As Color, clave As String, columna As Integer)
        If (tabla.Rows.Count > 0) Then
            For index As Integer = 0 To tabla.Rows.Count - 1
                Dim estado As String = tabla.Rows(index).Cells(columna).Value.ToString()
                If (estado.Contains(clave)) Then
                    Dim i As Integer = columna
                    With tabla.Rows(index).Cells(i).SelectedAppearance
                        .BackColor = Color_Fondo
                        .FontData.Bold = DefaultableBoolean.True
                        .ForeColor = Color_Texto
                    End With
                    With tabla.Rows(index).Cells(i).Appearance
                        .BackColor = Color_Fondo
                        .FontData.Bold = DefaultableBoolean.True
                        .ForeColor = Color_Texto
                    End With
                    With tabla.Rows(index).Cells(i).ActiveAppearance
                        .BackColor = Color_Fondo
                        .FontData.Bold = DefaultableBoolean.True
                        .ForeColor = Color_Texto
                    End With
                End If
            Next
        End If
    End Sub

    Public Shared Sub ColorearColumnas_SegunValor(tabla As UltraGrid, Color_Fondo As Color, Color_texto As Color, valor As String, columnaCondicional As Integer, columnas As String)
        If (tabla.Rows.Count > 0) Then
            For index As Integer = 0 To tabla.Rows.Count - 1
                Dim estado As String = tabla.Rows(index).Cells(columnaCondicional).Value.ToString()
                If (estado = valor) Then
                    ' Convertir la lista de columnas separadas por comas en un array
                    Dim columnasArray() As String = columnas.Split(","c)

                    ' Iterar sobre cada columna y aplicar los colores
                    For Each col As String In columnasArray
                        Dim colIndex As Integer
                        If Integer.TryParse(col.Trim(), colIndex) Then ' Convertir string a número
                            With tabla.Rows(index).Cells(colIndex).SelectedAppearance
                                .BackColor = Color_Fondo
                                .FontData.Bold = DefaultableBoolean.True
                                .ForeColor = Color_texto
                            End With
                            With tabla.Rows(index).Cells(colIndex).Appearance
                                .BackColor = Color_Fondo
                                .FontData.Bold = DefaultableBoolean.True
                                .ForeColor = Color_texto
                            End With
                            With tabla.Rows(index).Cells(colIndex).ActiveAppearance
                                .BackColor = Color_Fondo
                                .FontData.Bold = DefaultableBoolean.True
                                .ForeColor = Color_texto
                            End With
                        End If
                    Next
                End If
            Next
        End If
    End Sub


    Public Shared Sub Formato_Tablas_Grid_Pivot(nombre As Infragistics.Win.UltraWinGrid.UltraGrid)
        Dim color_marron As System.Drawing.Color
        color_marron = System.Drawing.Color.FromArgb(CType(CType(84, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(50, Byte), Integer))

        Dim color_crema As System.Drawing.Color
        color_crema = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(236, Byte), Integer))
        nombre.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        With nombre.DisplayLayout
            .Appearance.TextVAlign = VAlign.Middle
            .Override.AllowDelete = DefaultableBoolean.False
            .EmptyRowSettings.ShowEmptyRows = False

            .RowConnectorColor = System.Drawing.Color.Red
            .RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Dashed

            '.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free
            .Override.AllowUpdate = DefaultableBoolean.True
            .Override.CellClickAction = CellClickAction.CellSelect
            .Override.AllowMultiCellOperations = AllowMultiCellOperation.Copy
            .Override.ColumnAutoSizeMode = ColumnAutoSizeMode.AllRowsInBand

            .ScrollStyle = ScrollStyle.Immediate
            With .Appearance
                .ImageHAlign = HAlign.Default
                .ImageVAlign = VAlign.Middle
                .TextHAlign = HAlign.Left
                .TextVAlign = VAlign.Middle
                '.BackColor = Color.Transparent
                '.BorderColor = Color.Black
                '.BorderColor2 = Color.Black
                .ForeColor = Color.Black
            End With

            With .GroupByBox
                .BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid
                .Hidden = True
                With .Appearance
                    '.BackColor = Color.Transparent
                    '.BackColor2 = Color.Transparent
                    .BackGradientStyle = Infragistics.Win.GradientStyle.Vertical
                    '.BorderColor = Color.Black
                    '.BorderColor2 = Color.Black
                End With
            End With
            With .Override
                With .HeaderAppearance
                    .TextHAlignAsString = "Center"
                    .TextVAlignAsString = "Middle"
                    .BackColor = Color.White
                    .BackColor2 = Color.White
                    .ForeColor = Color.Black
                End With
                With .RowAppearance
                    .BackColor = System.Drawing.SystemColors.Window
                    .BorderColor = System.Drawing.Color.Silver
                End With
                With .SelectedRowAppearance
                    .TextVAlignAsString = "Middle"
                    .BackColor = Color.Khaki
                    .BackColor2 = Color.Khaki
                    .ForeColor = Color.Black
                    .FontData.BoldAsString = "true"
                    .FontData.Name = "Segoe UI"
                    .FontData.SizeInPoints = 9.0!
                End With
                With .FilterCellAppearance
                    .TextVAlignAsString = "Middle"
                End With

                With .ActiveCellAppearance
                    .TextVAlignAsString = "Middle"
                    .BackColor = Color.Khaki
                    .BackColor2 = Color.Khaki
                    .ForeColor = Color.Black
                    .FontData.BoldAsString = "true"
                    .FontData.Name = "Segoe UI"
                    .FontData.SizeInPoints = 9.0!
                End With
                With .ActiveRowAppearance
                    .TextVAlignAsString = "Middle"
                    .BackColor = Color.Khaki
                    .BackColor2 = Color.Khaki
                    .ForeColor = Color.Black
                    .FontData.BoldAsString = "true"
                    .FontData.Name = "Segoe UI"
                    .FontData.SizeInPoints = 9.0!

                End With
                With .RowPreviewAppearance
                    .TextVAlignAsString = "Middle"
                End With
            End With
        End With
    End Sub

    Public Shared Sub ColorearStockPorPorcentaje(tabla As UltraGrid, colActual As Integer, colMinimo As Integer)
        If tabla.Rows.Count = 0 Then Exit Sub

        For Each fila As UltraGridRow In tabla.Rows
            ' Lee valores de stock actual y stock mínimo
            Dim stockActual As Decimal = 0
            Dim stockMinimo As Decimal = 0

            Decimal.TryParse(fila.Cells(colActual).Value.ToString(), stockActual)
            Decimal.TryParse(fila.Cells(colMinimo).Value.ToString(), stockMinimo)

            ' Calcula el porcentaje: si stockMinimo = 0, lo tratamos como 0% para forzar rojo
            Dim porcentaje As Decimal = If(stockMinimo > 0, (stockActual / stockMinimo) * 100D, 0D)

            ' Determina el color de fondo según el porcentaje
            Dim colorFondo As Color
            Dim colorTexto As Color = Color.White

            If porcentaje <= 100 Then
                colorFondo = Color.Red
            ElseIf porcentaje <= 120 Then
                colorFondo = Color.Orange
            Else
                colorFondo = Color.Green
            End If

            ' Aplica apariencias al cell de stock actual
            With fila.Cells(colActual)
                With .Appearance
                    .BackColor = colorFondo
                    .ForeColor = colorTexto
                    .FontData.Bold = DefaultableBoolean.True
                End With
                With .SelectedAppearance
                    .BackColor = colorFondo
                    .ForeColor = colorTexto
                    .FontData.Bold = DefaultableBoolean.True
                End With
                With .ActiveAppearance
                    .BackColor = colorFondo
                    .ForeColor = colorTexto
                    .FontData.Bold = DefaultableBoolean.True
                End With
            End With
        Next
    End Sub

    Public Shared Sub Colorear_SegunValor_mayor_a(tabla As UltraGrid, Color_Fondo As Color, Color_texto As Color, valor As Decimal, columna As Integer)
        If (tabla.Rows.Count > 0) Then
            For index As Integer = 0 To tabla.Rows.Count - 1
                Dim valor_celda As Decimal = tabla.Rows(index).Cells(columna).Value.ToString
                If (valor_celda > valor) Then
                    Dim i As Integer = columna
                    With tabla.Rows(index).Cells(i).SelectedAppearance
                        .BackColor = Color_Fondo
                        .FontData.Bold = DefaultableBoolean.True
                        .ForeColor = Color_texto
                    End With
                    With tabla.Rows(index).Cells(i).Appearance
                        .BackColor = Color_Fondo
                        .FontData.Bold = DefaultableBoolean.True
                        .ForeColor = Color_texto
                    End With
                    With tabla.Rows(index).Cells(i).ActiveAppearance
                        .BackColor = Color_Fondo
                        .FontData.Bold = DefaultableBoolean.True
                        .ForeColor = Color_texto
                    End With
                End If
            Next
        End If
    End Sub
    Public Shared Sub Colorear_SegunValor_menor_a(tabla As UltraGrid, Color_Fondo As Color, Color_texto As Color, valor As Decimal, columna As Integer)
        If (tabla.Rows.Count > 0) Then
            For index As Integer = 0 To tabla.Rows.Count - 1
                Dim valor_celda As Decimal = tabla.Rows(index).Cells(columna).Value.ToString
                If (valor_celda < valor) Then
                    Dim i As Integer = columna
                    With tabla.Rows(index).Cells(i).SelectedAppearance
                        .BackColor = Color_Fondo
                        .FontData.Bold = DefaultableBoolean.True
                        .ForeColor = Color_texto
                    End With
                    With tabla.Rows(index).Cells(i).Appearance
                        .BackColor = Color_Fondo
                        .FontData.Bold = DefaultableBoolean.True
                        .ForeColor = Color_texto
                    End With
                    With tabla.Rows(index).Cells(i).ActiveAppearance
                        .BackColor = Color_Fondo
                        .FontData.Bold = DefaultableBoolean.True
                        .ForeColor = Color_texto
                    End With
                End If
            Next
        End If
    End Sub

    Public Shared Sub Colorear_SegunValor_igual_a(tabla As UltraGrid, Color_Fondo As Color, Color_texto As Color, valor As Decimal, columna As Integer)
        If (tabla.Rows.Count > 0) Then
            For index As Integer = 0 To tabla.Rows.Count - 1
                Dim valor_celda As Decimal = tabla.Rows(index).Cells(columna).Value.ToString
                If (valor_celda = valor) Then
                    Dim i As Integer = columna
                    With tabla.Rows(index).Cells(i).SelectedAppearance
                        .BackColor = Color_Fondo
                        .FontData.Bold = DefaultableBoolean.True
                        .ForeColor = Color_texto
                    End With

                    With tabla.Rows(index).Cells(i).Appearance
                        .BackColor = Color_Fondo
                        .FontData.Bold = DefaultableBoolean.True
                        .ForeColor = Color_texto
                    End With

                    With tabla.Rows(index).Cells(i).ActiveAppearance
                        .BackColor = Color_Fondo
                        .FontData.Bold = DefaultableBoolean.True
                        .ForeColor = Color_texto
                    End With

                End If

            Next
        End If
    End Sub

    Public Shared Function ObtenerSemanaDelAnio(fecha As DateTime) As Integer
        Dim culture As CultureInfo = CultureInfo.CurrentCulture
        Dim calendar As Calendar = culture.Calendar
        Dim weekOfYear As Integer = calendar.GetWeekOfYear(fecha, culture.DateTimeFormat.CalendarWeekRule, culture.DateTimeFormat.FirstDayOfWeek)

        If weekOfYear > 52 Then
            Return 1
        Else
            Return weekOfYear
        End If
    End Function

    Public Shared Function ObtenerDiaPIC(fechaNacimiento As DateTime) As Integer
        Dim fechaReferencia As DateTime = New DateTime(2024, 1, 1).AddDays(-88)
        Dim diasTotales As Integer = (DateTime.Now - fechaReferencia).Days
        Dim diasDesdeNacimiento As Integer = (DateTime.Now - fechaNacimiento).Days
        Dim diaPIGActual As Integer = (diasTotales Mod 1000) + 1
        Dim edadPIC As Integer = (diaPIGActual - diasDesdeNacimiento) Mod 1000

        If edadPIC <= 0 Then
            edadPIC += 1000
        End If

        Return edadPIC
    End Function

    Public Shared Function LlenarComboAnios(cb As ComboBox, Optional anioInicio As Integer = 2024)
        Dim anioFin As Integer = DateTime.Now.Year
        cb.Items.Clear()

        For i As Integer = anioInicio To anioFin
            cb.Items.Add(i.ToString())
        Next

        cb.DropDownStyle = ComboBoxStyle.DropDownList
        Dim anioSeleccionado As Integer = Math.Max(DateTime.Now.Year, anioInicio)
        cb.Text = anioSeleccionado.ToString()
    End Function

    Public Shared Function LlenarComboMeses(cb As ComboBox) As Boolean
        Try
            cb.Items.Clear()
            For i As Integer = 1 To 12
                Dim nombreMes As String = New DateTime(2000, i, 1).ToString("MMMM", New System.Globalization.CultureInfo("es-PE"))
                nombreMes = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nombreMes)
                cb.Items.Add(nombreMes)
            Next
            cb.DropDownStyle = ComboBoxStyle.DropDownList
            cb.SelectedIndex = DateTime.Now.Month - 1
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function LlenarComboSemanas(cbSemanas As ComboBox, año As Integer, mes As Integer) As Boolean
        Try
            cbSemanas.Items.Clear()

            Dim primerDia As Date = New Date(año, mes, 1)
            Dim ultimoDia As Date = primerDia.AddMonths(1).AddDays(-1)

            Dim semanasDelMes As New List(Of Integer)

            Dim diaActual As Date = primerDia
            While diaActual <= ultimoDia
                Dim numeroSemana As Integer = GetWeekOfYear(diaActual)
                If Not semanasDelMes.Contains(numeroSemana) Then
                    semanasDelMes.Add(numeroSemana)
                End If
                diaActual = diaActual.AddDays(1)
            End While

            semanasDelMes.Sort()

            For Each semana As Integer In semanasDelMes
                cbSemanas.Items.Add($"Sem {semana}")
            Next

            cbSemanas.DropDownStyle = ComboBoxStyle.DropDownList

            Dim semanaActual As Integer = GetWeekOfYear(DateTime.Now)
            If DateTime.Now.Year = año AndAlso DateTime.Now.Month = mes Then
                Dim indice As Integer = semanasDelMes.IndexOf(semanaActual)
                If indice >= 0 Then
                    cbSemanas.SelectedIndex = indice
                End If
            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Shared Function GetWeekOfYear(fecha As Date) As Integer
        Dim cultura As New System.Globalization.CultureInfo("es-PE")
        Dim calendar As System.Globalization.Calendar = cultura.Calendar
        Return calendar.GetWeekOfYear(fecha, System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Monday)
    End Function

    Public Shared Function ObtenerNumeroMes(cbMeses As ComboBox) As Integer
        If cbMeses.SelectedIndex >= 0 Then
            Return cbMeses.SelectedIndex + 1
        End If
        Return 0
    End Function

    Public Shared Function ObtenerNumeroSemana(cbSemanas As ComboBox) As Integer
        If cbSemanas.SelectedIndex >= 0 Then
            Dim textoSemana As String = cbSemanas.SelectedItem.ToString()
            Dim numeroSemana As String = textoSemana.Replace("Sem ", "")
            Return Convert.ToInt32(numeroSemana)
        End If
        Return 0
    End Function

    Public Shared Sub PosicionarFecha(dtp As DateTimePicker, año As Integer, Optional numMes As Integer = 0, Optional numSemana As Integer = 0)
        Try
            dtp.Value = ObtenerFecha(año, numMes, numSemana)
        Catch ex As Exception
            dtp.Value = DateTime.Now
        End Try
    End Sub

    Public Shared Function ObtenerFecha(año As Integer, Optional numMes As Integer = 0, Optional numSemana As Integer = 0) As Date
        Try
            If numMes = 0 Then
                Return New Date(año, 1, 1)
            End If

            If numSemana = 0 Then
                Return New Date(año, numMes, 1)
            End If

            Dim primerDiaMes As Date = New Date(año, numMes, 1)
            Dim ultimoDiaMes As Date = primerDiaMes.AddMonths(1).AddDays(-1)

            Dim diaActual As Date = primerDiaMes
            While diaActual <= ultimoDiaMes
                If GetWeekOfYear(diaActual) = numSemana Then
                    Return diaActual
                End If
                diaActual = diaActual.AddDays(1)
            End While

            Return primerDiaMes
        Catch ex As Exception
            Return DateTime.Now
        End Try
    End Function

    Public Shared Function ObtenerNumeroSemanaFecha(fecha As Date) As Integer
        Dim primerDiaAño As Date = New Date(fecha.Year, 1, 1)
        Dim primerDomingo As Date = primerDiaAño.AddDays((6 - primerDiaAño.DayOfWeek + 7) Mod 7)

        If primerDomingo > primerDiaAño Then
            primerDomingo = primerDomingo.AddDays(-7)
        End If

        Dim numeroSemana As Integer = CInt(Math.Ceiling((fecha - primerDomingo).Days / 7))

        Return numeroSemana
    End Function

    Public Shared Function ObtenerPeriodoDeSemana(año As Integer, numeroSemana As Integer) As String
        Dim intervalo As (Date, Date) = ObtenerIntervaloSemana(año, numeroSemana)
        Dim fechaInicio As Date = intervalo.Item1
        Dim fechaFin As Date = intervalo.Item2

        Dim cultura As System.Globalization.CultureInfo = System.Globalization.CultureInfo.GetCultureInfo("es-ES")

        Dim textoInicio As String = fechaInicio.ToString("dddd dd", cultura)
        Dim textoFin As String = fechaFin.ToString("dddd dd", cultura)

        If fechaInicio.Month = fechaFin.Month Then
            ' Mismo mes
            Dim textoMes As String = fechaInicio.ToString("MMMM", cultura)
            Return "del " & textoInicio & " al " & textoFin & " de " & textoMes
        Else
            Dim textoMesInicio As String = fechaInicio.ToString("MMMM", cultura)
            Dim textoMesFin As String = fechaFin.ToString("MMMM", cultura)
            Return "del " & textoInicio & " de " & textoMesInicio & " al " & textoFin & " de " & textoMesFin
        End If
    End Function

    Public Shared Function ObtenerIntervaloSemana(ByVal anio As Integer, ByVal numeroSemana As Integer) As (Date, Date)
        Dim primerDiaAño As Date = New Date(anio, 1, 1)
        Dim primerViernes As Date = primerDiaAño.AddDays((5 - primerDiaAño.DayOfWeek + 7) Mod 7)

        If primerViernes > primerDiaAño Then
            primerViernes = primerViernes.AddDays(-7)
        End If

        Dim fechaInicio As Date = primerViernes.AddDays((numeroSemana - 1) * 7)
        Dim fechaFin As Date = fechaInicio.AddDays(6) ' Jueves de la semana siguiente

        Return (fechaInicio, fechaFin)
    End Function


    Public Shared Sub DivisionTotales_Formato(
    tabla As UltraGrid,
    e As InitializeLayoutEventArgs,
    indice_columna_numerador As Integer,
    indice_columna_denominador As Integer,
    indice_columna_mostrar As Integer,
    Optional formato_texto As String = "División Total:",
    Optional formato_display As String = "{0:###,###.##}"
)
        If tabla.Rows.Count = 0 Then Exit Sub

        Dim band As UltraGridBand = tabla.DisplayLayout.Bands(0)

        ' 1) Validar índices
        If indice_columna_numerador >= band.Columns.Count _
       OrElse indice_columna_denominador >= band.Columns.Count _
       OrElse indice_columna_mostrar >= band.Columns.Count Then
            Debug.WriteLine("Error: Índices fuera de rango")
            Return
        End If

        ' 2) Crear clave única para este resumen basada en la columna donde se muestra
        Dim claveResumen As String = "DivisionTotales_" & indice_columna_mostrar.ToString()

        ' 3) Eliminar cualquier resumen anterior con la misma clave específica
        For i As Integer = band.Summaries.Count - 1 To 0 Step -1
            If band.Summaries(i).Key = claveResumen Then
                band.Summaries.RemoveAt(i)
            End If
        Next

        ' 4) Calcular manualmente numerador y denominador
        Dim totalNum As Decimal = 0D, totalDen As Decimal = 0D
        For Each r As UltraGridRow In tabla.Rows
            If Not r.IsFilteredOut AndAlso r.IsDataRow Then
                totalNum += Convert.ToDecimal(r.Cells(indice_columna_numerador).Value)
                totalDen += Convert.ToDecimal(r.Cells(indice_columna_denominador).Value)
            End If
        Next
        Dim resultado As Decimal = If(totalDen <> 0D, totalNum / totalDen, 0D)

        ' 5) Crear el Summary de tipo External con clave única
        Dim summary As SummarySettings = band.Summaries.Add(
        claveResumen, SummaryType.External, band.Columns(indice_columna_mostrar))
        summary.DisplayFormat = formato_display
        summary.SummaryPosition = SummaryPosition.UseSummaryPositionColumn

        ' 6) Habilitar cálculo externo de resumen
        e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed
        e.Layout.Override.AllowRowSummaries = AllowRowSummaries.True

        ' 7) Estilos y caption visible
        With e.Layout.Override
            .SummaryFooterCaptionVisible = DefaultableBoolean.True
            .SummaryFooterCaptionAppearance.FontData.Bold = DefaultableBoolean.True
            .SummaryFooterCaptionAppearance.TextHAlign = HAlign.Left

            .SummaryFooterAppearance.BackColor = Color.Khaki
            .SummaryFooterAppearance.ForeColor = Color.Black
            .SummaryFooterAppearance.FontData.Bold = DefaultableBoolean.True
        End With
        band.SummaryFooterCaption = formato_texto

        ' 8) Guardar el valor en el Tag del grid con clave única
        Dim dict As Dictionary(Of String, Object)
        If TypeOf tabla.Tag Is Dictionary(Of String, Object) Then
            dict = CType(tabla.Tag, Dictionary(Of String, Object))
        Else
            dict = New Dictionary(Of String, Object)
            tabla.Tag = dict
        End If
        dict(claveResumen & "_Valor") = resultado

        ' 9) Suscribir el evento ExternalSummaryValueRequested solo una vez
        RemoveHandler tabla.ExternalSummaryValueRequested, AddressOf Grid_ExternalSummaryValueRequested
        AddHandler tabla.ExternalSummaryValueRequested, AddressOf Grid_ExternalSummaryValueRequested
    End Sub

    ' Manejador que inyecta el valor calculado en el resumen
    Private Shared Sub Grid_ExternalSummaryValueRequested(
    sender As Object,
    e As ExternalSummaryValueEventArgs
)
        ' Verificar si es un resumen de división (las claves empiezan con "DivisionTotales_")
        If e.SummaryValue.SummarySettings.Key.StartsWith("DivisionTotales_") Then
            Dim grid = DirectCast(sender, UltraGrid)
            Dim dict = TryCast(grid.Tag, Dictionary(Of String, Object))
            If dict IsNot Nothing Then
                Dim claveValor As String = e.SummaryValue.SummarySettings.Key & "_Valor"
                If dict.ContainsKey(claveValor) Then
                    ' Asignar el valor external correspondiente
                    e.SummaryValue.SetExternalSummaryValue(dict(claveValor))
                End If
            End If
        End If
    End Sub
End Class
