Imports CapaNegocio
Imports CapaObjetos

Public Class FrmListarMedicamentoRecomendadoT
    Dim cn As New cnEnfermedad
    Public idEnfermedad As Integer = 0
    Public IdPlantel As Integer = 0
    Private ReadOnly _frmRegistrarTratamientoMedicacion As FrmRegistrarTratamientoCerdo

    Public Sub New(frmRegistrarTratamientoMedicacion As FrmRegistrarTratamientoCerdo)
        InitializeComponent()
        _frmRegistrarTratamientoMedicacion = frmRegistrarTratamientoMedicacion
    End Sub

    Private Sub FrmListaMedicamentoCerdoLote_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            clsBasicas.Filtrar_Tabla(dtgListado, True)
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            ListarMedicamentos()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ListarMedicamentos()
        Dim obj As New coEnfermedad
        obj.Codigo = idEnfermedad
        obj.IdUbicacion = IdPlantel
        Dim dt As DataTable = cn.Cn_ConsultarMedicamentoRecomendadoPorEnfermedad(obj)
        dtgListado.DataSource = dt
        clsBasicas.Filtrar_Tabla(dtgListado, True)
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        dtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True
        dtgListado.DisplayLayout.Bands(0).Columns("Unidad Medida").Hidden = True
        dtgListado.DisplayLayout.Bands(0).Columns("Stock").Hidden = True
    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        If dtgListado.Rows.Count > 0 Then
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow

            If activeRow IsNot Nothing AndAlso activeRow.Cells.Count > 0 AndAlso activeRow.Cells(0).Value IsNot Nothing Then
                If activeRow.Cells(0).Value.ToString().Trim().Length > 0 Then
                    Dim codigo As String = activeRow.Cells(0).Value.ToString()
                    Dim descripcion As String = If(activeRow.Cells.Count > 1 AndAlso activeRow.Cells(1).Value IsNot Nothing, activeRow.Cells(1).Value.ToString(), "")
                    Dim unidadMinima As String = If(activeRow.Cells.Count > 2 AndAlso activeRow.Cells(2).Value IsNot Nothing, activeRow.Cells(2).Value.ToString(), "")

                    _frmRegistrarTratamientoMedicacion.LlenarCamposMedicamentoRacion(codigo, descripcion, unidadMinima)
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