Imports CapaNegocio
Imports CapaObjetos

Public Class FrmListaRacionesExcedente
    Public IdUbicacionDestino As Integer = 0
    Dim cn As New cnNucleo

    Private ReadOnly _frmRegistrarExcedentexRacion As FrmRegistrarExcedentexRacion

    Public Sub New(frmRegistrarExcedentexRacion As FrmRegistrarExcedentexRacion)
        InitializeComponent()
        _frmRegistrarExcedentexRacion = frmRegistrarExcedentexRacion
    End Sub

    Private Sub FrmListaRacionesExcedente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListarRaciones()
    End Sub

    Private Sub ListarRaciones()
        Try
            clsBasicas.Formato_Tablas_Grid(DtgListado)
            ListarAlimentos()
            DtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True
            DtgListado.DisplayLayout.Bands(0).Columns("idAnti").Hidden = True
            DtgListado.DisplayLayout.Bands(0).Columns("idPlanMedicado").Hidden = True
            DtgListado.DisplayLayout.Bands(0).Columns("idPeriodoMedicacion").Hidden = True
            DtgListado.DisplayLayout.Bands(0).Columns("totalMedicacionesActivas").Hidden = True
            DtgListado.DisplayLayout.Bands(0).Columns("idPeriodoPlus").Hidden = True
            DtgListado.DisplayLayout.Bands(0).Columns("totalPlusActivas").Hidden = True
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ListarAlimentos()
        Try
            Dim obj As New coNucleo With {
            .IdUbicacion = IdUbicacionDestino
            }
            DtgListado.DataSource = cn.Cn_ListarRacionesAntiMedicadas(obj)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles DtgListado.DoubleClickCell
        Try
            If DtgListado.Rows.Count = 0 OrElse e.Cell.Row Is Nothing OrElse e.Cell.Row.Cells(0).Value Is Nothing Then
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
                Return
            End If

            Dim cells = e.Cell.Row.Cells
            Dim codigo = SafeGetString(cells, 0)
            Dim descripcion = SafeGetString(cells, 1)
            Dim idAnti = SafeGetInteger(cells, 2)
            Dim idPlanMedicado = SafeGetInteger(cells, 3)
            Dim idPeriodoMedicacion = SafeGetInteger(cells, 4)
            Dim totalMedicacionesActivas = SafeGetInteger(cells, 5)
            Dim idPlus = SafeGetInteger(cells, 6)
            Dim totalPlus = SafeGetInteger(cells, 7)

            _frmRegistrarExcedentexRacion.LlenarCamposAlimento(codigo, descripcion, idAnti, idPlanMedicado, idPeriodoMedicacion, totalMedicacionesActivas, idPlus, totalPlus)
            Dispose()

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Function SafeGetString(cells As Infragistics.Win.UltraWinGrid.CellsCollection, index As Integer) As String
        Return If(index < cells.Count AndAlso cells(index).Value IsNot Nothing, cells(index).Value.ToString(), String.Empty)
    End Function

    Private Function SafeGetInteger(cells As Infragistics.Win.UltraWinGrid.CellsCollection, index As Integer) As Integer
        Dim value = SafeGetString(cells, index)
        Dim result As Integer
        Return If(Integer.TryParse(value, result), result, 0)
    End Function

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles DtgListado.InitializeLayout
        Try
            If (DtgListado.Rows.Count = 0) Then
            Else
                e.Layout.Bands(0).Summaries.Clear()
                clsBasicas.Totales_Formato(DtgListado, e, 1)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class