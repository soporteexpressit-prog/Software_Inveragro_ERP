Imports CapaNegocio
Imports CapaObjetos
Imports System.ComponentModel

Public Class FrmReporteSueldoTrabajadores
    Dim cn As New cnTrabajador
    Dim tbtmp As New DataTable
    Public Property DNI As String
    Public Property CUSP As String
    Public Property TipoAFP As String
    Private Sub btn_cerrar_Click(sender As Object, e As EventArgs) Handles btn_cerrar.Click
        Dispose()
    End Sub

    Private Sub FrmReporteSueldoTrabajadores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            WindowState = Windows.Forms.FormWindowState.Maximized
            clsBasicas.Formato_Tablas_Grid(dtg_Listado)
            Ptbx_Cargando.Visible = True
            ConsultarItems()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub ConsultarItems()
        'Pasamos todos los parametros y ejecutamos el hilo para cargar la busqueda
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True
            GrupoMasOpcionesBusqueda.Enabled = False
            ToolStrip1.Enabled = False
            BackgroundWorker1.RunWorkerAsync()
        End If
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

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As New coTrabajador
            Dim cn As New cnTrabajador
            tbtmp = cn.Cn_Consultarsueldo(obj).Copy
            tbtmp.TableName = "tmp"
            e.Result = tbtmp

        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub btnexportar_excelRrhhtra_Click(sender As Object, e As EventArgs) Handles btnexportar_excelRrhhtra.Click
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
End Class