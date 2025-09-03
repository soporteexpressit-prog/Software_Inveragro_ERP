Imports System.Data.SqlClient
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports System.IO
Imports System.Text
Imports OfficeOpenXml
Public Class FrmMant_Trabajador
    Dim cn As New cnTrabajador
    Dim tbtmp As New DataTable
    Public Property DNI As String
    Public Property CUSP As String
    Public Property TipoAFP As String
    Sub ConsultarItems()
        'Pasamos todos los parametros y ejecutamos el hilo para cargar la busqueda
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True
            GrupoMasOpcionesBusqueda.Enabled = False
            ToolStrip1.Enabled = False
            BackgroundWorker1.RunWorkerAsync()
            ColorearGrid()
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As New coTrabajador
            Dim cn As New cnTrabajador
            tbtmp = cn.Cn_Consultar(obj).Copy
            tbtmp.TableName = "tmp"
            e.Result = tbtmp

        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Ptbx_Cargando.Visible = False
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            dtg_Listado.DataSource = CType(e.Result, DataTable)
            GrupoMasOpcionesBusqueda.Enabled = True
            ToolStrip1.Enabled = True
        End If
    End Sub

    Private Sub FMant_Producto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            WindowState = Windows.Forms.FormWindowState.Maximized
            clsBasicas.Formato_Tablas_Grid(dtg_Listado)
            Ptbx_Cargando.Visible = True
            ConsultarItems()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Sub ImprimirReporteTrabajador()
        Dim selectedRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtg_Listado.ActiveRow
        If selectedRow Is Nothing Then
            MsgBox("Por favor, seleccione un registro.")
            Return
        End If
        Dim selectedId As Integer = CInt(selectedRow.Cells(0).Value)
        Dim obj As New coTrabajador
        Dim dsCapacitacion As New DataSet
        obj.IdPersona = selectedId
        dsCapacitacion = cn.Cn_ConsultarIdpersonacontrato(obj).Copy

        Try
            Dim StiReport1 As New Stimulsoft.Report.StiReport
            StiReport1.Load(clsBasicas.Ruta_Reporte("Rpt_Trabajador.mrt"))
            StiReport1.Compile()
            StiReport1.Dictionary.Clear()
            StiReport1.RegData(dsCapacitacion)
            StiReport1.Dictionary.Synchronize()
            StiReport1.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub Generarfotocheck()
        Dim selectedRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtg_Listado.ActiveRow
        If selectedRow Is Nothing Then
            MsgBox("Por favor, seleccione un registro.")
            Return
        End If
        Dim selectedId As Integer = CInt(selectedRow.Cells(0).Value)
        Dim obj As New coTrabajador
        Dim dsCapacitacion As New DataSet
        obj.IdPersona = selectedId
        dsCapacitacion = cn.Cn_Generarfotocheck(obj).Copy

        Try
            Dim StiReport1 As New Stimulsoft.Report.StiReport
            StiReport1.Load(clsBasicas.Ruta_Reporte("Rpt_Fotocheck.mrt"))
            StiReport1.Compile()
            StiReport1.Dictionary.Clear()
            StiReport1.RegData(dsCapacitacion)
            StiReport1.Dictionary.Synchronize()
            StiReport1.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub dtg_ListaProducto_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs)
        Try
            dtg_Listado.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
            dtg_Listado.DisplayLayout.AutoFitStyle = AutoFitStyle.ExtendLastColumn
            dtg_Listado.DisplayLayout.PerformAutoResizeColumns(True, PerformAutoSizeType.AllRowsInBand)
            e.Layout.UseFixedHeaders = True
            With e.Layout.Bands(0)
            End With
            e.Layout.Bands(0).Summaries.Clear()
            e.Layout.Override.AllowRowSummaries = AllowRowSummaries.False
            Dim ColumnContarItems As UltraGridColumn = e.Layout.Bands(0).Columns(1)
            Dim symaryColumnContarItems As SummarySettings = e.Layout.Bands(0).Summaries.Add("symaryColumnContarItems", SummaryType.Count, ColumnContarItems)
            symaryColumnContarItems.DisplayFormat = "{0:N2}"
            symaryColumnContarItems.Appearance.TextHAlign = HAlign.Right
            e.Layout.Override.SummaryDisplayArea = SummaryDisplayAreas.TopFixed
            e.Layout.Override.SummaryDisplayArea = e.Layout.Override.SummaryDisplayArea OrElse SummaryDisplayAreas.GroupByRowsFooter
            e.Layout.Override.SummaryDisplayArea = e.Layout.Override.SummaryDisplayArea OrElse SummaryDisplayAreas.InGroupByRows
            symaryColumnContarItems.SummaryDisplayArea = SummaryDisplayAreas.BottomFixed OrElse SummaryDisplayAreas.GroupByRowsFooter
            e.Layout.Override.GroupBySummaryDisplayStyle = GroupBySummaryDisplayStyle.SummaryCells
            e.Layout.Override.SummaryFooterAppearance.BackColor = Color.Khaki
            e.Layout.Override.SummaryValueAppearance.BackColor = Color.Khaki
            e.Layout.Override.SummaryValueAppearance.ForeColor = Color.Black
            e.Layout.Override.SummaryValueAppearance.FontData.Bold = DefaultableBoolean.True
            e.Layout.Override.GroupBySummaryValueAppearance.BackColor = Color.Khaki
            e.Layout.Override.GroupBySummaryValueAppearance.ForeColor = Color.Black
            e.Layout.Override.GroupBySummaryValueAppearance.TextHAlign = HAlign.Right
            e.Layout.Bands(0).SummaryFooterCaption = "Totales : "
            e.Layout.Override.SummaryFooterCaptionAppearance.FontData.Bold = DefaultableBoolean.True
            e.Layout.Override.SummaryFooterCaptionVisible = DefaultableBoolean.True
            e.Layout.Override.SummaryFooterSpacingAfter = 5
            e.Layout.Override.SummaryFooterSpacingBefore = 5
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub ImprimirListado()
        Try
            Dim ds As New DataSet("bd")
            ds.Tables.Add(tbtmp.Copy)
            Dim StiReport1 As New Stimulsoft.Report.StiReport
            StiReport1.Load(clsBasicas.Ruta_Reporte("Rpt_Trabajadores.mrt"))
            StiReport1.Compile()
            StiReport1.Dictionary.Clear()
            StiReport1.RegData(ds)
            StiReport1.Dictionary.Synchronize()
            StiReport1.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btn_nuevo_Click(sender As Object, e As EventArgs) Handles btn_nuevoRrhhtra.Click
        Try
            Dim f As New FrmTrabajador
            f._Codigo = 0
            f.ShowDialog()
            ConsultarItems()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub btn_editar_Click_1(sender As Object, e As EventArgs) Handles btn_editarRrhhtra.Click
        Try
            If (dtg_Listado.Rows.Count > 0) Then
                If (dtg_Listado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim f As New FrmTrabajador
                    f._Codigo = dtg_Listado.ActiveRow.Cells(0).Value.ToString
                    f._tipotrabajador = dtg_Listado.ActiveRow.Cells(13).Value.ToString
                    f.ShowDialog()
                    ConsultarItems()
                Else
                    msj_advert("Seleccione un Registro")
                End If
            Else
                msj_advert("Seleccione un Registro")
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub btnexportar_excel_Click_1(sender As Object, e As EventArgs)


    End Sub

    Private Sub btnImprimirListaInventario_Click_1(sender As Object, e As EventArgs) Handles btnImprimirListaInventarioRrhhtra.Click
        ImprimirListado()
    End Sub

    Private Sub btn_buscar_Click_1(sender As Object, e As EventArgs)
        Ptbx_Cargando.Visible = True
        ConsultarItems()
    End Sub

    Private Sub btn_cerrar_Click_1(sender As Object, e As EventArgs) Handles btn_cerrar.Click
        Close()
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True
            GrupoMasOpcionesBusqueda.Enabled = False
            ToolStrip1.Enabled = False
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub


    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles btnexportar_excelRrhhtra.Click
        'Validamos sin existen registros, si es asi exportamos a excel toda la lista de la grilla
        Try
            If (dtg_Listado.Rows.Count = 0) Then
                msj_advert("No existen Registros vuelva a Buscar por Favor")
                Return
            Else
                clsBasicas.ExportarExcel("Lista de Trabajadores", dtg_Listado)
            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim isFilterActive As Boolean = Not ToolStripButton1.Checked
        ToolStripButton1.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtg_Listado, isFilterActive)
    End Sub

    Private Sub ToolStripButton2_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton2.Click

        If ToolStripButton2.Checked Then
            dtg_Listado.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
            dtg_Listado.DisplayLayout.GroupByBox.Hidden = False
        Else
            dtg_Listado.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.Horizontal
            dtg_Listado.DisplayLayout.GroupByBox.Hidden = True
            dtg_Listado.DisplayLayout.Bands(0).SortedColumns.Clear() ' Eliminar agrupamiento y orden
        End If
        ToolStripButton2.Checked = Not ToolStripButton2.Checked

    End Sub

    Sub ColorearGrid()
        clsBasicas.Colorear_SegunValor(dtg_Listado, Color.Red, Color.White, "INACTIVO", 12)
        clsBasicas.Colorear_SegunValor(dtg_Listado, Color.Green, Color.White, "ACTIVO", 12)
        clsBasicas.Colorear_SegunValor(dtg_Listado, Color.Orange, Color.White, "EVENTUAL", 13)
        clsBasicas.Colorear_SegunValor(dtg_Listado, Color.Green, Color.White, "PLANILLA", 13)
    End Sub



    Public Sub GenerarArchivos(rutaArchivo As String)
        Dim cn_item As New cnTrabajador
        Try
            Dim dtIde As DataTable = cn_item.Cn_Consultardocsunat() ' Esto ya existe para el archivo IDE
            If dtIde.Rows.Count = 0 Then
                MsgBox("No existen datos para generar el archivo IDE.", MsgBoxStyle.Information, "Generación de Archivo")
                Return
            End If
            If Not Directory.Exists(rutaArchivo) Then
                Directory.CreateDirectory(rutaArchivo)
            End If
            Dim archivoIde As String = Path.Combine(rutaArchivo, "registro_sunat.ide")
            If File.Exists(archivoIde) Then
                File.Delete(archivoIde)
            End If
            Using writer As New StreamWriter(archivoIde, False, System.Text.Encoding.UTF8)
                For Each row As DataRow In dtIde.Rows
                    Dim linea As String = FormatearLineaIde(row)
                    writer.WriteLine(linea)
                Next
            End Using

            Dim dtTra As DataTable = cn_item.Cn_ConsultardocsunatE5() ' Llamada al nuevo procedimiento almacenado
            If dtTra.Rows.Count = 0 Then
                MsgBox("No existen datos para generar el archivo TRA.", MsgBoxStyle.Information, "Generación de Archivo")
                Return
            End If
            Dim archivoTra As String = Path.Combine(rutaArchivo, "registro_sunat.tra")
            If File.Exists(archivoTra) Then
                File.Delete(archivoTra)
            End If
            Using writer As New StreamWriter(archivoTra, False, System.Text.Encoding.UTF8)
                For Each row As DataRow In dtTra.Rows
                    Dim linea As String = FormatearLineaTra(row) ' Nuevo método para formatear línea para archivo TRA
                    writer.WriteLine(linea)
                Next
            End Using

            Dim dtper As DataTable = cn_item.Cn_ConsultardocsunatE11() ' Llamada al nuevo procedimiento almacenado
            If dtper.Rows.Count = 0 Then
                MsgBox("No existen datos para generar el archivo per.", MsgBoxStyle.Information, "Generación de Archivo")
                Return
            End If
            Dim archivoper As String = Path.Combine(rutaArchivo, "registro_sunat.per")
            If File.Exists(archivoper) Then
                File.Delete(archivoper)
            End If
            Using writer As New StreamWriter(archivoper, False, System.Text.Encoding.UTF8)
                For Each row As DataRow In dtper.Rows
                    Dim linea As String = FormatearLineaper(row) ' Nuevo método para formatear línea para archivo per
                    writer.WriteLine(linea)
                Next
            End Using

            Dim dtcta As DataTable = cn_item.Cn_ConsultardocsunatE17p1() ' Llamada al nuevo procedimiento almacenado
            If dtcta.Rows.Count = 0 Then
                MsgBox("No existen datos para generar el archivo per.", MsgBoxStyle.Information, "Generación de Archivo")
                Return
            End If
            Dim archivocta As String = Path.Combine(rutaArchivo, "registro_sunat.cta")
            If File.Exists(archivocta) Then
                File.Delete(archivocta)
            End If
            Using writer As New StreamWriter(archivocta, False, System.Text.Encoding.UTF8)
                For Each row As DataRow In dtcta.Rows
                    Dim linea As String = FormatearLineaE17P1(row) ' Nuevo método para formatear línea para archivo per
                    writer.WriteLine(linea)
                Next
            End Using

            Dim dtedu As DataTable = cn_item.Cn_ConsultardocsunatE17p2() ' Llamada al nuevo procedimiento almacenado
            If dtedu.Rows.Count = 0 Then
                MsgBox("No existen datos para generar el archivo per.", MsgBoxStyle.Information, "Generación de Archivo")
                Return
            End If
            Dim archivoedu As String = Path.Combine(rutaArchivo, "registro_sunat.edu")
            If File.Exists(archivoedu) Then
                File.Delete(archivoedu)
            End If
            Using writer As New StreamWriter(archivoedu, False, System.Text.Encoding.UTF8)
                For Each row As DataRow In dtedu.Rows
                    Dim linea As String = FormatearLineaE17P2(row) ' Nuevo método para formatear línea para archivo per
                    writer.WriteLine(linea)
                Next
            End Using


            Dim dtest As DataTable = cn_item.Cn_ConsultardocsunatE17p3() ' Llamada al nuevo procedimiento almacenado
            If dtest.Rows.Count = 0 Then
                MsgBox("No existen datos para generar el archivo per.", MsgBoxStyle.Information, "Generación de Archivo")
                Return
            End If
            Dim archivoest As String = Path.Combine(rutaArchivo, "registro_sunat.est")
            If File.Exists(archivoest) Then
                File.Delete(archivoest)
            End If
            Using writer As New StreamWriter(archivoest, False, System.Text.Encoding.UTF8)
                For Each row As DataRow In dtest.Rows
                    Dim linea As String = FormatearLineaE17P3(row) ' Nuevo método para formatear línea para archivo per
                    writer.WriteLine(linea)
                Next
            End Using

            Dim dte13 As DataTable = cn_item.Cn_ConsultardocsunatE13() ' Llamada al nuevo procedimiento almacenado
            If dte13.Rows.Count = 0 Then
                MsgBox("No existen datos para generar el archivo per.", MsgBoxStyle.Information, "Generación de Archivo")
                Return
            End If
            Dim archivoe13 As String = Path.Combine(rutaArchivo, "registro_sunate13.txt")
            If File.Exists(archivoe13) Then
                File.Delete(archivoe13)
            End If
            Using writer As New StreamWriter(archivoe13, False, System.Text.Encoding.UTF8)
                For Each row As DataRow In dte13.Rows
                    Dim linea As String = FormatearLineaE13(row) ' Nuevo método para formatear línea para archivo per
                    writer.WriteLine(linea)
                Next
            End Using


            Dim dte24 As DataTable = cn_item.Cn_ConsultardocsunatE24() ' Llamada al nuevo procedimiento almacenado
            If dte24.Rows.Count = 0 Then
                MsgBox("No existen datos para generar el archivo per.", MsgBoxStyle.Information, "Generación de Archivo")
                Return
            End If
            Dim archivoe24 As String = Path.Combine(rutaArchivo, "registro_sunate24.txt")
            If File.Exists(archivoe24) Then
                File.Delete(archivoe24)
            End If
            Using writer As New StreamWriter(archivoe24, False, System.Text.Encoding.UTF8)
                For Each row As DataRow In dte24.Rows
                    Dim linea As String = FormatearLineaE24(row) ' Nuevo método para formatear línea para archivo per
                    writer.WriteLine(linea)
                Next
            End Using
            MsgBox("Los archivos se han generado correctamente en la ruta: " & archivoe24, MsgBoxStyle.Information, "Generación de Archivo")
        Catch ex As Exception
            MsgBox("Error al generar los archivos: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Function FormatearLineaIde(row As DataRow) As String
        Dim idTipoDocIdentidad As String = row("idTipoDocIdentidad").ToString()
        Dim numdocumento As String = row("numdocumento").ToString()
        Dim paisEmision As String = If(String.IsNullOrEmpty(row("pais emision").ToString()), "", row("pais emision").ToString())
        Dim fechaNacimiento As String = If(String.IsNullOrEmpty(row("fecha nacimiento").ToString()), "", Convert.ToDateTime(row("fecha nacimiento")).ToString("d", Globalization.CultureInfo.GetCultureInfo("es-ES")))
        Dim apellidoPaterno As String = If(String.IsNullOrEmpty(row("apellidoPaterno").ToString()), "", row("apellidoPaterno").ToString())
        Dim apellidoMaterno As String = If(String.IsNullOrEmpty(row("apellidoMaterno").ToString()), "", row("apellidoMaterno").ToString())
        Dim nombre As String = If(String.IsNullOrEmpty(row("nombre").ToString()), "", row("nombre").ToString())
        Dim sexo As String = row("SEXO").ToString()
        Dim celular As String = If(String.IsNullOrEmpty(row("celular").ToString()), "", row("celular").ToString())
        Dim correo As String = If(String.IsNullOrEmpty(row("correo").ToString()), "", row("correo").ToString())
        Dim centroAtencion As String = "1"
        Dim linea As String = String.Join("|", idTipoDocIdentidad, numdocumento, paisEmision, fechaNacimiento, apellidoPaterno, apellidoMaterno, nombre, sexo, "", "", celular, correo, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", centroAtencion)
        linea &= "|"
        Return linea
    End Function
    Private Function FormatearLineaTra(row As DataRow) As String
        Dim idTipoDocIdentidad As String = "0" & row("idTipoDocIdentidad").ToString()
        Dim numdocumento As String = row("numdocumento").ToString()
        Dim tipoPasaporte As String = If(String.IsNullOrEmpty(row("TipoPasaporte").ToString()), "604", row("TipoPasaporte").ToString())
        Dim regimenLaboral As String = If(String.IsNullOrEmpty(row("RegimenLaboral").ToString()), "-", row("RegimenLaboral").ToString())
        Dim nivelEducativo As String = If(String.IsNullOrEmpty(row("NivelEducativo").ToString()), "", row("NivelEducativo").ToString())
        Dim ocupacion As String = If(String.IsNullOrEmpty(row("Ocupacion").ToString()), "", row("Ocupacion").ToString())
        Dim discapacidad As String = "0"
        Dim cuspp As String = If(String.IsNullOrEmpty(row("Cuspp").ToString()), "", row("Cuspp").ToString())
        Dim sctr As String = ""
        Dim tpContrato As String = If(String.IsNullOrEmpty(row("tpcontrato").ToString()), "", row("tpcontrato").ToString())
        Dim regimenAtipico As String = "0"
        Dim jornadaMax As String = "1"
        Dim horarioNoturno As String = "0"
        Dim sindicato As String = "0"
        Dim periodoRemuneracion As String = If(String.IsNullOrEmpty(row("periodoremuneracion").ToString()), "", row("periodoremuneracion").ToString())
        Dim sueldo As String = If(String.IsNullOrEmpty(row("sueldo").ToString()), "", row("sueldo").ToString())
        Dim situacion As String = If(String.IsNullOrEmpty(row("situacion").ToString()), "", row("situacion").ToString())
        Dim exonerado5ta As String = "0"
        Dim situacionEspecial As String = "0"
        Dim tipoPago As String = If(String.IsNullOrEmpty(row("tipopago").ToString()), "3", row("tipopago").ToString()) ' Valor por defecto 3
        Dim categoriaOcupacion As String = If(String.IsNullOrEmpty(row("categoriaocupacion").ToString()), "", row("categoriaocupacion").ToString())
        Dim convenioDobleTributo As String = "0"
        Dim numruc As String = ""
        Dim linea As String = String.Join("|", idTipoDocIdentidad, numdocumento, tipoPasaporte, regimenLaboral, nivelEducativo, ocupacion, discapacidad, cuspp, sctr, tpContrato, regimenAtipico, jornadaMax, horarioNoturno, sindicato, periodoRemuneracion, sueldo, situacion, exonerado5ta, situacionEspecial, tipoPago, categoriaOcupacion, convenioDobleTributo, numruc)
        linea &= "|"
        Return linea
    End Function
    Private Function FormatearLineaper(row As DataRow) As String
        Dim idTipoDocIdentidad As String = "0" & row("idTipoDocIdentidad").ToString()
        Dim numdocumento As String = row("numdocumento").ToString()
        Dim tipoPasaporte As String = If(String.IsNullOrEmpty(row("TipoPasaporte").ToString()), "604", row("TipoPasaporte").ToString())
        Dim categoria As String = "1"
        Dim lineaBase As String = String.Join("|", idTipoDocIdentidad, numdocumento, tipoPasaporte, categoria)
        Dim fechas As New List(Of String) From {
        If(String.IsNullOrEmpty(row("fechainicio").ToString()), "", Convert.ToDateTime(row("fechainicio")).ToString("dd/MM/yyyy")),
        If(String.IsNullOrEmpty(row("fechainicio2").ToString()), "", Convert.ToDateTime(row("fechainicio2")).ToString("dd/MM/yyyy")),
        If(String.IsNullOrEmpty(row("fregimensalud").ToString()), "", Convert.ToDateTime(row("fregimensalud")).ToString("dd/MM/yyyy")),
        If(String.IsNullOrEmpty(row("fRegimenpensionario").ToString()), "", Convert.ToDateTime(row("fRegimenpensionario")).ToString("dd/MM/yyyy")),
        If(String.IsNullOrEmpty(row("fregimensalud2").ToString()), "", Convert.ToDateTime(row("fregimensalud2")).ToString("dd/MM/yyyy"))
    }
        Dim contador As Integer = 1
        Dim resultado As New StringBuilder()
        For Each fecha As String In fechas
            If Not String.IsNullOrEmpty(fecha) Then
                resultado.AppendLine($"{idTipoDocIdentidad}|{numdocumento}|{tipoPasaporte}|{categoria}|{contador}|{fecha}||||")
                contador += 1
            End If
        Next
        Return resultado.ToString()
    End Function
    Private Function FormatearLineaE17P1(row As DataRow) As String
        Dim idTipoDocIdentidad As String = "0" & row("idTipoDocIdentidad").ToString()
        Dim numdocumento As String = row("numdocumento").ToString() ' '40109171'
        Dim paisEmision As String = If(String.IsNullOrEmpty(row("TipoPasaporte").ToString()), "", row("TipoPasaporte").ToString())
        Dim codigoPais As String = If(String.IsNullOrEmpty(row("codsunat").ToString()), "", row("codsunat").ToString())
        Dim pasaporte As String = If(String.IsNullOrEmpty(row("numcuenta").ToString()), "", row("numcuenta").ToString())
        Dim linea As String = String.Join("|", idTipoDocIdentidad, numdocumento, paisEmision, codigoPais, pasaporte)
        Return linea & "|"
    End Function
    Private Function FormatearLineaE17P2(row As DataRow) As String
        Dim idTipoDocIdentidad As String = "0" & row("idTipoDocIdentidad").ToString()
        Dim numdocumento As String = row("numdocumento").ToString() ' '40109171'
        Dim paisEmision As String = If(String.IsNullOrEmpty(row("TipoPasaporte").ToString()), "", row("TipoPasaporte").ToString())
        Dim formacionsuperior As String = If(String.IsNullOrEmpty(row("formacionsuperior").ToString()), "", row("formacionsuperior").ToString())
        Dim Institucioncompletaperu As String = If(String.IsNullOrEmpty(row("Institucioncompletaperu").ToString()), "", row("Institucioncompletaperu").ToString())
        Dim codigoinstitucion As String = If(String.IsNullOrEmpty(row("codigoinstitucion").ToString()), "", row("codigoinstitucion").ToString())
        Dim codigocarrera As String = If(String.IsNullOrEmpty(row("codigocarrera").ToString()), "", row("codigocarrera").ToString())
        Dim añodeegreso As String = If(String.IsNullOrEmpty(row("añodeegreso").ToString()), "", row("añodeegreso").ToString())
        Dim linea As String = String.Join("|", idTipoDocIdentidad, numdocumento, paisEmision, formacionsuperior, Institucioncompletaperu, codigoinstitucion, codigocarrera, añodeegreso)
        Return linea & "|"
    End Function
    Private Function FormatearLineaE17P3(row As DataRow) As String
        Dim idTipoDocIdentidad As String = "0" & row("idTipoDocIdentidad").ToString()
        Dim numdocumento As String = row("numdocumento").ToString()
        Dim paisEmision As String = If(String.IsNullOrEmpty(row("TipoPasaporte").ToString()), "", row("TipoPasaporte").ToString())
        Dim codigoPais As String = If(String.IsNullOrEmpty(row("ruc").ToString()), "", row("ruc").ToString())
        Dim pasaporte As String = If(String.IsNullOrEmpty(row("domiciliofiscal").ToString()), "", row("domiciliofiscal").ToString())
        Dim linea As String = String.Join("|", idTipoDocIdentidad, numdocumento, paisEmision, codigoPais, pasaporte)
        Return linea & "|"
    End Function
    Private Function FormatearLineaE13(row As DataRow) As String
        ' Asignar valores desde las columnas del DataRow
        Dim idTipoDocIdentidad As String = "0" & row("idTipoDocIdentidad").ToString()
        Dim numdocumento As String = row("numdocumento").ToString()
        Dim tdochijo As String = "0" & row("tdochijo").ToString()
        Dim numdochijo As String = row("numdochijo").ToString()
        Dim pais As String = row("pais").ToString()
        Dim fechaNacimiento As String = row("FechaNacimiento").ToString()
        Dim apellidoPaterno As String = row("apellidoPaterno").ToString()
        Dim apellidoMaterno As String = row("apellidoMaterno").ToString()
        Dim nombres As String = row("nombres").ToString()
        Dim sexo As String = row("SEXO").ToString()
        Dim vinculofamiliar As String = row("vinculofamiliar").ToString()
        Dim tipodocvinculante As String = row("tipodocvinculante").ToString()
        Dim nroDocVinculante As String = row("nroDocVinculante").ToString()
        Dim mesconcepcion As String = row("mesConcepcion").ToString()
        Dim tipovia As String = row("tipovia").ToString()
        Dim nombrevia As String = row("nombrevia").ToString()
        Dim numvia As String = row("numvia").ToString()
        Dim departamento As String = row("departamento").ToString()
        Dim interior As String = row("interior").ToString()
        Dim mzna As String = row("mzna").ToString()
        Dim lote As String = row("lote").ToString()
        Dim km As String = row("km").ToString()
        Dim block As String = row("blocke").ToString()
        Dim etapa As String = row("etapa").ToString()
        Dim tipozona As String = row("tipozona").ToString()
        Dim nombrezona As String = row("nombrezona").ToString()
        Dim referencia As String = row("referencia").ToString()
        Dim ubigeo As String = row("ubigeo").ToString()
        Dim indicadorcentro As String = row("indicadorcentro").ToString()
        Dim telefonocod As String = row("telefonocod").ToString()
        Dim numtelefono As String = row("numtelefono").ToString()
        Dim correoelectronico As String = row("correoelectronico").ToString()

        ' Concatenar todos los valores separados por el delimitador '|'
        Dim linea As String = String.Join("|", idTipoDocIdentidad, numdocumento, tdochijo, numdochijo, pais, fechaNacimiento,
                                      apellidoPaterno, apellidoMaterno, nombres, sexo, vinculofamiliar, tipodocvinculante,
                                      nroDocVinculante, mesconcepcion, tipovia, nombrevia, numvia, departamento, interior, mzna, lote, km,
                                      block, etapa, tipozona, nombrezona, referencia, ubigeo, indicadorcentro, telefonocod,
                                      numtelefono, correoelectronico)

        ' Agregar el separador final y retornar la línea
        Return linea & "|"
    End Function

    Private Function FormatearLineaE24(row As DataRow) As String
        ' Asignar valores desde las columnas del DataRow
        Dim idTipoDocIdentidad As String = "0" & row("idTipoDocIdentidad").ToString()
        Dim numdocumento As String = row("numdocumento").ToString()
        Dim tdochijo As String = "0" & row("tdochijo").ToString()
        Dim numdochijo As String = row("numdochijo").ToString()
        Dim pais As String = row("pais").ToString()
        Dim fechaNacimiento As String = row("FechaNacimiento").ToString()
        Dim apellidoPaterno As String = row("apellidoPaterno").ToString()
        Dim apellidoMaterno As String = row("apellidoMaterno").ToString()
        Dim nombres As String = row("nombres").ToString()
        Dim vinculofamiliar As String = row("vinculofamiliar").ToString()
        Dim fechabaja As String = row("fechabaja").ToString()
        Dim motivobaja As String = row("motivobaja").ToString()

        ' Concatenar todos los valores separados por el delimitador '|'
        Dim linea As String = String.Join("|", idTipoDocIdentidad, numdocumento, tdochijo, numdochijo, pais, fechaNacimiento,
                                      apellidoPaterno, apellidoMaterno, nombres, vinculofamiliar, fechabaja,
                                      motivobaja)

        ' Agregar el separador final y retornar la línea
        Return linea & "|"
    End Function


    Private Sub ReporteSunatToolStripMenuItem1_Click(sender As Object, e As EventArgs)

    End Sub


    Private Sub ReporteDatosTrabajadorToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ReporteDatosTrabajadorToolStripMenuItem1.Click
        ImprimirReporteTrabajador()
    End Sub


    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Try
            If (dtg_Listado.Rows.Count > 0) Then
                If Not String.IsNullOrEmpty(dtg_Listado.ActiveRow.Cells(0).Value.ToString()) Then
                    Dim codigo As String = dtg_Listado.ActiveRow.Cells(0).Value.ToString()
                    Dim resultado As DialogResult = MessageBox.Show("¿Estás seguro de que quieres convertirlo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If resultado = DialogResult.Yes Then
                        Try
                            Dim f As New FrmMantenimientoCliente
                            f._Codigo = dtg_Listado.ActiveRow.Cells(0).Value.ToString

                            f.ShowDialog()
                            f.Consultar()
                        Catch ex As Exception
                            clsBasicas.controlException(Name, ex)
                        End Try
                    Else
                        msj_advert(MensajesSistema.mensajesGenerales("Conversión cancelada."))
                    End If
                Else
                    msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
                End If
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Catch ex As Exception
            'clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Try
            If (dtg_Listado.Rows.Count > 0) Then
                If Not String.IsNullOrEmpty(dtg_Listado.ActiveRow.Cells(0).Value.ToString()) Then
                    Dim codigo As String = dtg_Listado.ActiveRow.Cells(0).Value.ToString()
                    Dim resultado As DialogResult = MessageBox.Show("¿Estás seguro de que quieres convertirlo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If resultado = DialogResult.Yes Then
                        Try
                            Dim f As New FrmProveedor
                            f._Codigo = dtg_Listado.ActiveRow.Cells(0).Value.ToString
                            f._TipoProveedor = 1
                            f.ShowDialog()
                            f.Consultar()
                        Catch ex As Exception
                            clsBasicas.controlException(Name, ex)
                        End Try
                    Else
                        msj_advert(MensajesSistema.mensajesGenerales("Conversión cancelada."))
                    End If
                Else
                    msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
                End If
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Catch ex As Exception
            'clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ReporteSunatPorEmpleadoToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GenerarFotocheckToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GenerarFotocheckToolStripMenuItem.Click
        Generarfotocheck()
    End Sub
    Public Sub GenerarArchivoExcel(rutaArchivo As String)
        Dim cn_item As New cnTrabajador
        Try
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial
            Dim dtExcel As DataTable = cn_item.Cn_ConsultarExportarExcelAFP()
            If dtExcel.Rows.Count = 0 Then
                MsgBox("No existen datos para generar el archivo Excel.", MsgBoxStyle.Information, "Generación de Archivo")
                Return
            End If
            If Not Directory.Exists(rutaArchivo) Then
                Directory.CreateDirectory(rutaArchivo)
            End If
            Dim archivoExcel As String = Path.Combine(rutaArchivo, "exportacion_afp.xlsx")
            If File.Exists(archivoExcel) Then
                File.Delete(archivoExcel)
            End If
            Using package As New OfficeOpenXml.ExcelPackage()
                Dim worksheet As OfficeOpenXml.ExcelWorksheet = package.Workbook.Worksheets.Add("AFP Export")
                ' Llenar los datos desde el DataTable
                Dim rowIndex As Integer = 1
                For Each row As DataRow In dtExcel.Rows
                    worksheet.Cells(rowIndex, 1).Value = 0 ' Columna ID con valor fijo
                    worksheet.Cells(rowIndex, 2).Value = Convert.ToInt64(row("numDocumento"))
                    worksheet.Cells(rowIndex, 3).Value = row("apellidoPaterno").ToString()
                    worksheet.Cells(rowIndex, 4).Value = row("apellidoMaterno").ToString()
                    worksheet.Cells(rowIndex, 5).Value = row("nombre").ToString()
                    rowIndex += 1
                Next
                worksheet.Cells.AutoFitColumns()
                package.SaveAs(New IO.FileInfo(archivoExcel))
            End Using

            MsgBox("Archivo Excel generado correctamente en: " & archivoExcel, MsgBoxStyle.Information, "Generación de Archivo")
        Catch ex As Exception
            MsgBox("Error al generar el archivo Excel: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub ExportarAfpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportarAfpToolStripMenuItem.Click
        Dim rutaArchivo As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Documentos")
        GenerarArchivoExcel(rutaArchivo)
    End Sub

    Private Sub ExprotarAFPPorEmpleadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExprotarAFPPorEmpleadoToolStripMenuItem.Click
        Dim frmReporte As New FormularioSunat()
        frmReporte.Show()
    End Sub

    Private Sub ImportarAfpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportarAfpToolStripMenuItem.Click
        Dim cn_item As New cnTrabajador
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Archivos Excel|*.xlsx;*.xls"
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Dim filePath As String = openFileDialog.FileName
            Dim excelData As New List(Of FrmMant_Trabajador)() ' Lista para almacenar los datos
            Try
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial
                Using package As New ExcelPackage(New IO.FileInfo(filePath))
                    Dim worksheet = package.Workbook.Worksheets(0)
                    For row As Integer = 2 To worksheet.Dimension.End.Row
                        Dim dni = worksheet.Cells(row, 2).Text.Trim()
                        Dim cusp = worksheet.Cells(row, 6).Text.Trim()
                        Dim tipoAfp = worksheet.Cells(row, 15).Text.Trim()
                        Dim tipocomision = worksheet.Cells(row, 14).Text.Trim()

                        If Not String.IsNullOrEmpty(dni) Then
                            ' Crear el objeto FrmMant_Trabajador y añadirlo a la lista
                            Dim data As New FrmMant_Trabajador With {
                            .DNI = dni,
                            .CUSP = If(String.IsNullOrEmpty(cusp), Nothing, cusp),
                            .TipoAFP = "AFP " + tipoAfp + " " + tipocomision
                        }
                            excelData.Add(data)
                        End If
                    Next
                End Using

                Dim dataString As String = ConvertListToDelimitedString(excelData)
                Dim result As DataSet = cn_item.Cn_ProcesarExcelAfp(dataString)
                MessageBox.Show("Procesamiento completado con éxito.")
            Catch ex As Exception
                MessageBox.Show($"Error: {ex.Message}")
            End Try
        End If
    End Sub

    Private Function ConvertListToDelimitedString(excelData As List(Of FrmMant_Trabajador)) As String
        Dim result As New StringBuilder()
        For Each item In excelData
            result.AppendLine($"{item.DNI},{item.CUSP},{item.TipoAFP}")
        Next
        Return result.ToString()
    End Function

    Private Sub ReporteGeneralSunatToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteGeneralSunatToolStripMenuItem.Click
        Dim rutaArchivo As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Documentos")
        GenerarArchivos(rutaArchivo)
    End Sub

    Private Sub ReporteSunatPorEmpleadoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ReporteSunatPorEmpleadoToolStripMenuItem1.Click
        Dim frmReporte As New FormularioSunat()
        frmReporte.Show()
    End Sub
    Private Sub ConvertirAConductorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConvertirAConductorToolStripMenuItem.Click
        Try
            If (dtg_Listado.Rows.Count > 0) Then
                If (dtg_Listado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim f As New Mant_Conductores
                    f._Codigo = dtg_Listado.ActiveRow.Cells(0).Value.ToString
                    f._tipotrabajador = dtg_Listado.ActiveRow.Cells(13).Value.ToString
                    f._operacion = 1
                    f.ShowDialog()
                    ConsultarItems()
                Else
                    msj_advert("Seleccione un Registro")
                End If
            Else
                msj_advert("Seleccione un Registro")
            End If
        Catch ex As Exception
            'clsBasicas.controlException(Name, ex)
        End Try
    End Sub


    Private Sub dtg_Listado_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles dtg_Listado.InitializeLayout
        Try
            clsBasicas.Colorear_SegunValor(dtg_Listado, Color.Red, Color.White, "INACTIVO", 12)
            clsBasicas.Colorear_SegunValor(dtg_Listado, Color.Green, Color.White, "ACTIVO", 12)
            clsBasicas.Colorear_SegunValor(dtg_Listado, Color.Orange, Color.White, "EVENTUAL", 13)
            clsBasicas.Colorear_SegunValor(dtg_Listado, Color.Green, Color.White, "PLANILLA", 13)
            clsBasicas.Totales_Formato(dtg_Listado, e, 1)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ReporteDeSueldoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteDeSueldoToolStripMenuItem.Click
        Dim frmReporte As New FrmReporteSueldoTrabajadores()
        frmReporte.Show()
    End Sub
End Class