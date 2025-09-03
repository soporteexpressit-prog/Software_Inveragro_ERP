Imports CapaNegocio
Imports CapaObjetos

Public Class FrmListaMedicacionPorRacion
    Dim cn As New cnControlAlimento
    Dim ds As New DataSet
    Public idRacion As Integer = 0
    Public tipo As String = ""
    Private ReadOnly _frmImpresionFormula As FrmImpresionFormula

    Public Sub New(frmImpresionFormula As FrmImpresionFormula)
        InitializeComponent()
        _frmImpresionFormula = frmImpresionFormula
    End Sub

    Private Sub FrmListaMedicacionPorRacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Consultar()
        clsBasicas.Formato_Tablas_Grid(dtgListado)
    End Sub

    Sub Consultar()
        Try
            Dim obj As New coControlAlimento With {
                .IdRacion = idRacion,
                .Tipo = tipo
            }

            ds = cn.Cn_ConsultarMedicacionesPlusRacion(obj).Copy
            ds.DataSetName = "tmp"

            Dim relation1 As New DataRelation("tb_relacion1", ds.Tables.Item(0).Columns.Item(0), ds.Tables.Item(1).Columns.Item(0), False)

            ds.Relations.Add(relation1)
            dtgListado.DataSource = ds
            dtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True
            dtgListado.DisplayLayout.Bands(0).Columns("idUbicacion").Hidden = True
            dtgListado.DisplayLayout.Bands(1).Columns(0).Hidden = True
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        Try
            If dtgListado.Rows.Count > 0 Then
                If dtgListado.ActiveRow IsNot Nothing AndAlso e.Cell IsNot Nothing AndAlso e.Cell.Value IsNot DBNull.Value AndAlso e.Cell.Value IsNot Nothing AndAlso e.Cell.Value.ToString().Trim() <> "" Then
                    Dim filaSeleccionada As Infragistics.Win.UltraWinGrid.UltraGridRow = e.Cell.Row

                    If filaSeleccionada.Band.Index = 0 Then
                        Dim idSeleccionado As Integer = filaSeleccionada.Cells(0).Value
                        Dim tipo As String = filaSeleccionada.Cells("Medicación").Value
                        Dim ubicacion As String = filaSeleccionada.Cells("Ubicación").Value
                        Dim idUbicacion As Integer = filaSeleccionada.Cells("idUbicacion").Value

                        _frmImpresionFormula.ActualizarMedicacionRacion(idSeleccionado, tipo, ubicacion, idUbicacion)
                        Me.Close()
                    ElseIf filaSeleccionada.Band.Index = 1 Then
                        msj_advert("Debe seleccionar un ítem contenedor.")
                    End If
                Else
                    msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
                End If
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
End Class