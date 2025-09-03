Imports CapaNegocio

Public Class FrmListarDistritos
    Public Sub New(frmTrabajador As Object)
        InitializeComponent()
        ' Verificar el tipo del objeto recibido
        If TypeOf frmTrabajador Is FrmTrabajador Then
            _frmTrabajador = CType(frmTrabajador, FrmTrabajador)
        End If
    End Sub

    Private ReadOnly _frmTrabajador As FrmTrabajador
    Dim cn As New cnTrabajador

    Private Sub FrmListarDistritos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clsBasicas.Filtrar_Tabla(dtgListado, True)
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        ListarDistritos()

        If dtgListado.DisplayLayout.Bands.Count > 0 Then
            If dtgListado.DisplayLayout.Bands(0).Columns.Count > 1 Then
                dtgListado.DisplayLayout.Bands(0).Columns(3).Hidden = True
                dtgListado.DisplayLayout.Bands(0).Columns(4).Hidden = True
            End If
        End If
    End Sub

    Sub ListarDistritos()
        Dim dt As DataTable = cn.Cn_ListarDistritos()
        dtgListado.DataSource = dt
    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        Try
            ' Verificar que el grid tenga filas
            If dtgListado.Rows.Count = 0 Then
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
                Return
            End If

            ' Obtener la fila activa
            Dim activeRow = dtgListado.ActiveRow
            If activeRow Is Nothing OrElse Not activeRow.IsDataRow Then
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
                Return
            End If

            ' Validar que las celdas necesarias contengan valores
            Dim requiredCells = {0, 1, 3, 4} ' Índices de las celdas requeridas
            For Each cellIndex In requiredCells
                If activeRow.Cells(cellIndex).Value Is Nothing OrElse String.IsNullOrWhiteSpace(activeRow.Cells(cellIndex).Value.ToString()) Then
                    msj_advert("Algunas celdas no tienen valores válidos.")
                    Return
                End If
            Next

            ' Llenar campos según el formulario correspondiente
            If _frmTrabajador IsNot Nothing Then
                _frmTrabajador.LlenarCamposUbicacion(
                activeRow.Cells(0).Value.ToString(),
                activeRow.Cells(1).Value.ToString(),
                activeRow.Cells(3).Value.ToString(),
                activeRow.Cells(4).Value.ToString())
            Else
                msj_advert("No se ha especificado un formulario válido para llenar.")
                Return
            End If

            ' Cerrar el formulario actual
            Me.Dispose()

        Catch ex As Exception
            clsBasicas.controlException("Error en dtgListado_DoubleClickCell", ex)
        End Try
    End Sub


    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub

End Class