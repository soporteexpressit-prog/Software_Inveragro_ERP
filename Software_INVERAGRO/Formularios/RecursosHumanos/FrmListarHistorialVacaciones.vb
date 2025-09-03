Imports CapaNegocio
Imports CapaObjetos

Public Class FrmListarHistorialVacaciones
    Private _idPersona As Integer
    Private cn As New cnTrabajador  ' Asumiendo que tienes una clase cnTrabajador para la capa de negocio

    ' Constructor que recibe el IdPersona
    Public Sub New(idPersona As Integer)
        InitializeComponent()
        _idPersona = idPersona
    End Sub
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub FrmListarHistorialVacaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clsBasicas.Filtrar_Tabla(dtgListado, True)
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        ListarTrabajadoresActivos()
    End Sub
    Sub ListarTrabajadoresActivos()
        Dim obj As New coTrabajador
        obj.IdPersona = _idPersona
        dtgListado.DataSource = cn.Cc_Consultarhistorialpersona(obj)
    End Sub
    Private Sub ConfigurarGrid()
    End Sub
    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub
End Class