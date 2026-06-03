Imports System.ComponentModel
Imports CapaNegocio
Imports CapaObjetos

Public Class FrmReporteMermasConsolidado
    Dim cn As New cnControlLoteDestete
    Dim tbtmp As New DataTable
    Dim search As Boolean = False
    Dim anio As Integer = 0
    Dim mes As Integer = 0

    Public Sub New()
        InitializeComponent()
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.Size = New Size(1300, 800)
    End Sub

    Private Sub FrmReporteMermasConsolidado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        Ptbx_Cargando.Visible = True
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        clsBasicas.Filtrar_Tabla(dtgListado, True)
        clsBasicas.LlenarComboAnios(CmbAnios)
        clsBasicas.LlenarComboMeses(CmbMeses)
        anio = CInt(CmbAnios.Text)
        mes = clsBasicas.ObtenerNumeroMes(CmbMeses)
    End Sub

    Private Sub CmbMeses_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbMeses.SelectedIndexChanged
        If CmbMeses.SelectedIndex >= 0 Then
            Dim año As Integer = CInt(CmbAnios.Text)
            Dim mesSeleccionado As Integer = clsBasicas.ObtenerNumeroMes(CmbMeses)
        End If
    End Sub

    Private Sub CkbOmitirMes_CheckedChanged(sender As Object, e As EventArgs) Handles CkbOmitirMes.CheckedChanged
        If CkbOmitirMes.Checked Then
            CmbMeses.Enabled = False
            mes = 0
        Else
            CmbMeses.Enabled = True
            mes = clsBasicas.ObtenerNumeroMes(CmbMeses)
        End If
    End Sub

    Private Sub BloquearControladores()
        Ptbx_Cargando.Visible = True
        CmbAnios.Enabled = False
        ToolStrip1.Enabled = False
    End Sub

    Private Sub DesbloquearControladores()
        Ptbx_Cargando.Visible = False
        CmbAnios.Enabled = True
        If Not CkbOmitirMes.Checked Then
            CmbMeses.Enabled = True
        End If
        ToolStrip1.Enabled = True
    End Sub

    Sub Consultar()
        BloquearControladores()
        Try
            Dim obj As New coControlLoteDestete With {
                .Anio = anio,
                .Mes = mes
            }
            dtgListado.DataSource = cn.Cn_ReporteMermasconsolidado(obj).Copy
            DesbloquearControladores()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
            DesbloquearControladores()
        End Try
    End Sub

    Private Sub BtnBusqueda_Click(sender As Object, e As EventArgs) Handles BtnBusqueda.Click
        Try
            anio = CInt(CmbAnios.Text)
            mes = If(CkbOmitirMes.Checked, 0, clsBasicas.ObtenerNumeroMes(CmbMeses))
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub

End Class