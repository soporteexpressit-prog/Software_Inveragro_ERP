Imports CapaNegocio
Imports CapaObjetos

Public Class FrmListaRacionesPresupuesto
    Public IdUbicacionDestino As Integer = 0
    Dim cn As New cnNucleo
    Private ReadOnly _frmAlimentacionPresupuesto As FrmAlimentacionPresupuesto

    Public Sub New(frmAlimentacionPresupuesto As FrmAlimentacionPresupuesto)
        InitializeComponent()
        _frmAlimentacionPresupuesto = frmAlimentacionPresupuesto
    End Sub

    Private Sub FrmListaRacionesPresupuesto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            ListarAlimentos()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ListarAlimentos()
        Try
            Dim obj As New coNucleo With {
                .IdUbicacion = IdUbicacionDestino
            }
            dtgListado.DataSource = cn.Cn_ListarRacionesPresupuesto(obj)
            dtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True
            dtgListado.DisplayLayout.Bands(0).Columns("idUnidadMedida").Hidden = True
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        Try
            If dtgListado.Rows.Count = 0 OrElse e.Cell.Row Is Nothing OrElse e.Cell.Row.Cells(0).Value Is Nothing Then
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
                Return
            End If

            Dim cells = e.Cell.Row.Cells
            Dim codigo = SafeGetString(cells, 0)
            Dim descripcion = SafeGetString(cells, 1)
            Dim stock As Decimal = Convert.ToDecimal(SafeGetString(cells, 2))
            Dim um As String = SafeGetString(cells, 3)
            Dim idUm As Integer = SafeGetInteger(cells, 4)

            _frmAlimentacionPresupuesto.LlenarCamposAlimento(codigo, descripcion, stock, um, idUm)
            Me.Close()

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

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class