Imports CapaNegocio

Public Class FrmListarEnfermedadCerdoPs
    Dim cn As New cnEnfermedad
    Private ReadOnly _frmMantPlanSanitario As FrmMantPlanSanitario

    Public Sub New(frmMantPlanSanitario As FrmMantPlanSanitario)
        InitializeComponent()
        _frmMantPlanSanitario = frmMantPlanSanitario
    End Sub

    Private Sub FrmListarEnfermedadCerdoPs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        dtgListado.DisplayLayout.Bands(0).Columns("Codigo").Hidden = True
        dtgListado.DisplayLayout.Bands(0).Columns("Descripcion").Hidden = True
        dtgListado.DisplayLayout.Bands(0).Columns("F.Registro").Hidden = True
        dtgListado.DisplayLayout.Bands(0).Columns("Nivel").Hidden = True
    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        If dtgListado.Rows.Count > 0 Then
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow

            If activeRow IsNot Nothing AndAlso activeRow.Cells.Count > 0 AndAlso activeRow.Cells(0).Value IsNot Nothing Then
                If activeRow.Cells(0).Value.ToString().Trim().Length > 0 Then
                    Dim codigo As String = activeRow.Cells(0).Value.ToString()
                    Dim descripcion As String = If(activeRow.Cells.Count > 1 AndAlso activeRow.Cells(1).Value IsNot Nothing, activeRow.Cells(1).Value.ToString(), "")

                    _frmMantPlanSanitario.LlenarCamposEnfermedad(codigo, descripcion)
                    Me.Close()
                Else
                    msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
                End If
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class