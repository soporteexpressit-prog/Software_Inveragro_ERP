Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win.UltraWinGrid
Imports System.IO
Imports System.Text

Public Class FormularioSunat
    Dim cn As New cnTrabajador
    Dim tbtmp As New DataTable
    Private SelectedRows As New List(Of UltraGridRow)
    Private Sub FormularioSunat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            clsBasicas.Formato_Tablas_Grid(dtg_Listado)
            dtg_Listado.DisplayLayout.Override.SelectTypeRow = SelectType.SingleAutoDrag
            dtg_Listado.DisplayLayout.Override.SelectTypeCell = SelectType.None ' Evitar selección de celdas individuales
            ConsultarItems()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub dtg_Listado_DoubleClickRow(sender As Object, e As DoubleClickRowEventArgs) Handles dtg_Listado.DoubleClickRow
        Try
            Dim row As UltraGridRow = e.Row
            If row IsNot Nothing AndAlso Not row.IsFilterRow Then
                If SelectedRows.Contains(row) Then
                    SelectedRows.Remove(row)
                    row.Appearance.BackColor = Color.White
                Else
                    SelectedRows.Add(row)
                    row.Appearance.BackColor = Color.LightBlue
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al seleccionar la fila: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Function ObtenerIdsSeleccionados() As String
        Dim listaIds As New List(Of String)
        For Each fila As UltraGridRow In SelectedRows
            listaIds.Add(fila.Cells(0).Value.ToString())
        Next
        Return String.Join(",", listaIds)
    End Function
    Private Sub btnprocesar_Click(sender As Object, e As EventArgs) Handles btnprocesar.Click
        Try
            Dim listaIds As String = ObtenerIdsSeleccionados()
            If String.IsNullOrEmpty(listaIds) Then
                MsgBox("Por favor, seleccione al menos un trabajador.", MsgBoxStyle.Information, "Selección de Trabajadores")
                Return
            End If
            Dim rutaArchivo As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Documentos")
            GenerarArchivoIde2(rutaArchivo, listaIds)
            MsgBox("Archivo generado correctamente.", MsgBoxStyle.Information, "Proceso Completado")
            Dispose()
        Catch ex As Exception
            MsgBox("Ocurrió un error durante el proceso: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub ConsultarItems()
        Try
            Dim obj As New coTrabajador
            tbtmp = cn.Cn_ConsultartrabajadoresSunat(obj).Copy
            tbtmp.TableName = "tmp"
            dtg_Listado.DataSource = tbtmp
            OcultarColumnas()
        Catch ex As Exception
            MsgBox("Error al cargar los datos: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub OcultarColumnas()
        For Each colIndex As Integer In {1, 2, 5, 6, 7, 8, 9, 10, 11}
            If tbtmp.Columns.Count > colIndex Then
                dtg_Listado.DisplayLayout.Bands(0).Columns(colIndex).Hidden = True
            End If
        Next
    End Sub
    Private Sub btn_cerrar_Click(sender As Object, e As EventArgs) Handles btn_cerrar.Click
        Dispose()
    End Sub
    Public Sub GenerarArchivoIde2(rutaArchivo As String, listaIds As String)
        Dim cn_item As New cnTrabajador
        Try
            Dim ds As DataSet = cn_item.Cn_ConsultarsunatxempleadoE4(listaIds)
            If ds Is Nothing OrElse ds.Tables.Count = 0 OrElse ds.Tables(0).Rows.Count = 0 Then
                MsgBox("No existen datos para generar el archivo.", MsgBoxStyle.Information, "Generación de Archivo")
                Return
            End If
            If Not Directory.Exists(rutaArchivo) Then
                Directory.CreateDirectory(rutaArchivo)
            End If
            Dim archivoFinal As String = Path.Combine(rutaArchivo, "registro_sunatporpersona.ide")
            If File.Exists(archivoFinal) Then
                File.Delete(archivoFinal)
            End If
            Using writer As New StreamWriter(archivoFinal, False, System.Text.Encoding.UTF8)
                For Each row As DataRow In ds.Tables(0).Rows
                    Dim linea As String = FormatearLinea(row)
                    writer.WriteLine(linea)
                Next
            End Using

            Dim dtTra As DataSet = cn_item.Cn_ConsultarsunatxempleadoE5(listaIds)
            If dtTra Is Nothing OrElse dtTra.Tables.Count = 0 OrElse dtTra.Tables(0).Rows.Count = 0 Then
                MsgBox("No existen datos para generar el archivo.", MsgBoxStyle.Information, "Generación de Archivo")
                Return
            End If
            Dim archivoTra As String = Path.Combine(rutaArchivo, "registro_sunat.tra")
            If File.Exists(archivoTra) Then
                File.Delete(archivoTra)
            End If
            Using writer As New StreamWriter(archivoTra, False, System.Text.Encoding.UTF8)
                For Each row As DataRow In dtTra.Tables(0).Rows
                    Dim linea As String = FormatearLineaTra(row)
                    writer.WriteLine(linea)
                Next
            End Using


            Dim dtper As DataSet = cn_item.Cn_ConsultarsunatxempleadoE11(listaIds) ' Llamada al nuevo procedimiento almacenado
            If dtper Is Nothing OrElse dtper.Tables.Count = 0 OrElse dtper.Tables(0).Rows.Count = 0 Then
                MsgBox("No existen datos para generar el archivo.", MsgBoxStyle.Information, "Generación de Archivo")
                Return
            End If
            Dim archivoper As String = Path.Combine(rutaArchivo, "registro_sunat.per")
            If File.Exists(archivoper) Then
                File.Delete(archivoper)
            End If
            Using writer As New StreamWriter(archivoper, False, System.Text.Encoding.UTF8)
                For Each row As DataRow In dtper.Tables(0).Rows
                    Dim linea As String = FormatearLineaper(row)
                    writer.WriteLine(linea)
                Next
            End Using
            'MsgBox("Archivo per generado correctamente en la ruta: " & archivoper, MsgBoxStyle.Information, "Generación de Archivo")

            Dim dtcta As DataSet = cn_item.Cn_ConsultarsunatxempleadoE17p1(listaIds) ' Llamada al nuevo procedimiento almacenado
            If dtcta Is Nothing OrElse dtcta.Tables.Count = 0 OrElse dtcta.Tables(0).Rows.Count = 0 Then
                MsgBox("No existen datos para generar el archivo.", MsgBoxStyle.Information, "Generación de Archivo")
                Return
            End If
            Dim archivocta As String = Path.Combine(rutaArchivo, "registro_sunat.cta")
            If File.Exists(archivocta) Then
                File.Delete(archivocta)
            End If
            Using writer As New StreamWriter(archivocta, False, System.Text.Encoding.UTF8)
                For Each row As DataRow In dtcta.Tables(0).Rows
                    Dim linea As String = FormatearLineaE17P1(row)
                    writer.WriteLine(linea)
                Next
            End Using

            Dim dtedu As DataSet = cn_item.Cn_ConsultarsunatxempleadoE17p2(listaIds) ' Llamada al nuevo procedimiento almacenado
            If dtedu Is Nothing OrElse dtedu.Tables.Count = 0 OrElse dtedu.Tables(0).Rows.Count = 0 Then
                MsgBox("No existen datos para generar el archivo.", MsgBoxStyle.Information, "Generación de Archivo")
                Return
            End If
            Dim archivoedu As String = Path.Combine(rutaArchivo, "registro_sunat.edu")
            If File.Exists(archivoedu) Then
                File.Delete(archivoedu)
            End If
            Using writer As New StreamWriter(archivoedu, False, System.Text.Encoding.UTF8)
                For Each row As DataRow In dtedu.Tables(0).Rows
                    Dim linea As String = FormatearLineaE17P2(row)
                    writer.WriteLine(linea)
                Next
            End Using


            Dim dtest As DataSet = cn_item.Cn_ConsultarsunatxempleadoE17p3(listaIds) ' Llamada al nuevo procedimiento almacenado
            If dtest Is Nothing OrElse dtest.Tables.Count = 0 OrElse dtest.Tables(0).Rows.Count = 0 Then
                MsgBox("No existen datos para generar el archivo.", MsgBoxStyle.Information, "Generación de Archivo")
                Return
            End If
            Dim archivoest As String = Path.Combine(rutaArchivo, "registro_sunat.est")
            If File.Exists(archivoest) Then
                File.Delete(archivoest)
            End If
            Using writer As New StreamWriter(archivoest, False, System.Text.Encoding.UTF8)
                For Each row As DataRow In dtest.Tables(0).Rows
                    Dim linea As String = FormatearLineaE17P3(row)
                    writer.WriteLine(linea)
                Next
            End Using

            Dim dte13 As DataSet = cn_item.Cn_ConsultarsunatxempleadoE13(listaIds) ' Llamada al nuevo procedimiento almacenado
            If dte13 Is Nothing OrElse dte13.Tables.Count = 0 OrElse dte13.Tables(0).Rows.Count = 0 Then
                MsgBox("No existen datos para generar el archivo.", MsgBoxStyle.Information, "Generación de Archivo")
                Return
            End If
            Dim archivoe13 As String = Path.Combine(rutaArchivo, "registro_sunate13.txt")
            If File.Exists(archivoe13) Then
                File.Delete(archivoe13)
            End If
            Using writer As New StreamWriter(archivoe13, False, System.Text.Encoding.UTF8)
                For Each row As DataRow In dte13.Tables(0).Rows
                    Dim linea As String = FormatearLineaE13(row)
                    writer.WriteLine(linea)
                Next
            End Using


            Dim dte24 As DataSet = cn_item.Cn_ConsultarsunatxempleadoE24(listaIds) ' Llamada al nuevo procedimiento almacenado
            If dte24 Is Nothing OrElse dte24.Tables.Count = 0 OrElse dte24.Tables(0).Rows.Count = 0 Then
                MsgBox("No existen datos para generar el archivo.", MsgBoxStyle.Information, "Generación de Archivo")
                Return
            End If
            Dim archivoe24 As String = Path.Combine(rutaArchivo, "registro_sunate24.txt")
            If File.Exists(archivoe24) Then
                File.Delete(archivoe24)
            End If
            Using writer As New StreamWriter(archivoe24, False, System.Text.Encoding.UTF8)
                For Each row As DataRow In dte24.Tables(0).Rows
                    Dim linea As String = FormatearLineaE24(row)
                    writer.WriteLine(linea)
                Next
            End Using
            MsgBox("Los archivos se han generado correctamente en la ruta: " & archivoe24, MsgBoxStyle.Information, "Generación de Archivo")
        Catch ex As Exception
            MsgBox("Error al generar el archivo: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
    Private Sub dtg_Listado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dtg_Listado.InitializeRow
        With dtg_Listado
            .DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
            .DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
            .DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False
        End With
        clsBasicas.Colorear_SegunValor(dtg_Listado, Color.Red, Color.White, "INACTIVO", 12)
        clsBasicas.Colorear_SegunValor(dtg_Listado, Color.Green, Color.White, "ACTIVO", 12)
        clsBasicas.Colorear_SegunValor(dtg_Listado, Color.Orange, Color.White, "EVENTUAL", 13)
        clsBasicas.Colorear_SegunValor(dtg_Listado, Color.Green, Color.White, "PLANILLA", 13)
    End Sub
    ' Formatear la línea para el archivo
    Private Function FormatearLinea(row As DataRow) As String
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

        Dim linea As String = String.Join("|", idTipoDocIdentidad, numdocumento, paisEmision, fechaNacimiento, apellidoPaterno, apellidoMaterno, nombre, sexo, "", "", celular, correo, "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", centroAtencion)
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
        Dim numdocumento As String = row("numdocumento").ToString()
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
    Public Sub GenerarArchivoExcelxempleado(rutaArchivo As String, listaIds As String)
        Dim cn_item As New cnTrabajador
        Try
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial
            Dim dsExcel As DataSet = cn_item.Cn_ConsultarExportarExcelAFPxempleado(listaIds)
            If dsExcel Is Nothing OrElse dsExcel.Tables.Count = 0 OrElse dsExcel.Tables(0).Rows.Count = 0 Then
                MsgBox("No existen datos para generar el archivo Excel.", MsgBoxStyle.Information, "Generación de Archivo")
                Return
            End If
            If Not Directory.Exists(rutaArchivo) Then
                Directory.CreateDirectory(rutaArchivo)
            End If
            Dim archivoExcel As String = Path.Combine(rutaArchivo, "exportacion_afpxempleado.xlsx")
            If File.Exists(archivoExcel) Then
                File.Delete(archivoExcel)
            End If
            Using package As New OfficeOpenXml.ExcelPackage()
                Dim worksheet As OfficeOpenXml.ExcelWorksheet = package.Workbook.Worksheets.Add("AFP Export")
                Dim rowIndex As Integer = 1
                For Each row As DataRow In dsExcel.Tables(0).Rows
                    worksheet.Cells(rowIndex, 1).Value = 0
                    worksheet.Cells(rowIndex, 2).Value = Convert.ToInt64(row("numDocumento"))
                    worksheet.Cells(rowIndex, 3).Value = row("apellidoPaterno").ToString()
                    worksheet.Cells(rowIndex, 4).Value = row("apellidoMaterno").ToString()
                    worksheet.Cells(rowIndex, 5).Value = row("nombre").ToString()
                    rowIndex += 1
                Next
                worksheet.Cells.AutoFitColumns()
                'worksheet.Cells(1, 1, rowIndex - 1, 1).Style.Numberformat.Format = "0" ' Establecer formato numérico
                package.SaveAs(New IO.FileInfo(archivoExcel))
            End Using

            ' Mostrar mensaje de éxito
            MsgBox("Archivo Excel generado correctamente en: " & archivoExcel, MsgBoxStyle.Information, "Generación de Archivo")
        Catch ex As Exception
            ' Mostrar mensaje de error en caso de fallo
            MsgBox("Error al generar el archivo Excel: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub




    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        Try
            Dim listaIds As String = ObtenerIdsSeleccionados()
            If String.IsNullOrEmpty(listaIds) Then
                MsgBox("Por favor, seleccione al menos un trabajador.", MsgBoxStyle.Information, "Selección de Trabajadores")
                Return
            End If
            Dim rutaArchivo As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Documentos")
            GenerarArchivoExcelxempleado(rutaArchivo, listaIds)
            MsgBox("Archivo generado correctamente.", MsgBoxStyle.Information, "Proceso Completado")
            Dispose()
        Catch ex As Exception
            MsgBox("Ocurrió un error durante el proceso: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class
