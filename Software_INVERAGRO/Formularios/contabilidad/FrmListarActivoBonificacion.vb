Imports CapaNegocio
Imports CapaObjetos

Public Class FrmListarActivoBonificacion
    Dim cn As New cnActivo
    Private ReadOnly _frmRegistrarBinificacionVNN As FrmRegistrarBonificacionVehiculoNN
    Private SelectedRows As New List(Of DataRow)

    Public Sub New(frmRegistrarBinificacionVNN As FrmRegistrarBonificacionVehiculoNN)
        InitializeComponent()
        _frmRegistrarBinificacionVNN = frmRegistrarBinificacionVNN
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub

    Private Sub FrmListarActivoBonificacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clsBasicas.Filtrar_Tabla(dtgListado, True)
        Inicializar()
    End Sub
    Sub Inicializar()
        dtpFechaDesde.Value = DateTime.Now
        dtpFechaHasta.Value = DateTime.Now

        Dim obj As New coActivo
        obj.FechaDesde = Nothing
        obj.FechaHasta = Nothing

        Dim dt As DataTable = cn.Cn_ListarActivosVehiculos(obj)
        dtgListado.DataSource = dt
        clsBasicas.Formato_Tablas_Grid(dtgListado)
    End Sub
    Sub ListarActivosVehiculos()
        Dim obj As New coActivo

        If dtpFechaDesde.Value = DateTimePicker.MinimumDateTime Then
            obj.FechaDesde = Nothing
        Else
            obj.FechaDesde = dtpFechaDesde.Value
        End If

        If dtpFechaHasta.Value = DateTimePicker.MinimumDateTime Then
            obj.FechaHasta = Nothing
        Else
            obj.FechaHasta = dtpFechaHasta.Value
        End If

        Dim dt As DataTable = cn.Cn_ListarActivosVehiculos(obj)
        dtgListado.DataSource = dt
        clsBasicas.Formato_Tablas_Grid(dtgListado)
    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        If (dtgListado.Rows.Count > 0) Then
            If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                _frmRegistrarBinificacionVNN.LlenarCamposActivo(
                     e.Cell.Row.Cells(0).Value.ToString(),
                    e.Cell.Row.Cells(1).Value.ToString(),
                     e.Cell.Row.Cells(2).Value.ToString()
                    )
                Dispose()
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If dtpFechaDesde.Value > dtpFechaHasta.Value Then
            msj_advert(MensajesSistema.mensajesGenerales("FECHA_INICIO_MAYOR_FIN"))
            Return
        End If
        ListarActivosVehiculos()
    End Sub
End Class