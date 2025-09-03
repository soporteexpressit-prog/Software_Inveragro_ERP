Imports CapaNegocio

Public Class FrmListarEnfermedadesCerdo
    Dim cn As New cnEnfermedad
    Private ReadOnly _frmNuevoTratamiento As FrmNuevoTratamiento

    Public Sub New(frmNuevoTratamiento As FrmNuevoTratamiento)
        InitializeComponent()
        _frmNuevoTratamiento = frmNuevoTratamiento
    End Sub

    Private Sub FrmListarEnfermedadCerdo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            FrmListarEnfermedades()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub FrmListarEnfermedades()
        Dim dt As DataTable = cn.Cn_Listar()
        dtgListado.DataSource = dt
        clsBasicas.Filtrar_Tabla(dtgListado, True)
        clsBasicas.Formato_Tablas_Grid(dtgListado)
    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                Dim codigo As String = e.Cell.Row.Cells(0).Value.ToString()
                Dim descripcion As String = e.Cell.Row.Cells(1).Value.ToString()
                Dim nivel As String = e.Cell.Row.Cells(3).Value.ToString()
                _frmNuevoTratamiento.LlenarCamposEnfermedad(codigo, descripcion)
                Me.Close()
            Else
                msj_advert("Seleccione un Registro")
            End If
        Else
            msj_advert("Seleccione un Registro")
        End If
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class