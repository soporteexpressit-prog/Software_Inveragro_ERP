Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmListarMaterialGeneticoEditar
    Dim cn As New cnControlMaterialGenetico
    Private ReadOnly _frmEditarInseminacion As FrmEditarInseminacion
    Public idPlantel As Integer = 0

    Public Sub New(frmEditarInseminacion As FrmEditarInseminacion)
        InitializeComponent()
        _frmEditarInseminacion = frmEditarInseminacion
    End Sub

    Private Sub FrmListarMaterialGeneticoEditar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            clsBasicas.ListarPlantelesAsignados(CmbUbicacionDestino)
            Consultar()
            CmbUbicacionDestino.SelectedValue = idPlantel
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Consultar()
        Try
            Dim obj As New coControlMaterialGenetico With {
                .IdUbicacionDestino = CmbUbicacionDestino.SelectedValue
            }
            dtgListado.DataSource = cn.Cn_ConsultarxIdUbicacionDestino(obj)
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            dtgListado.DisplayLayout.Bands(0).Columns("idMaterialGenetico").Hidden = True
            Colorear()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Colorear()
        If (dtgListado.Rows.Count > 0) Then
            Dim tipoAdquisicion As Integer = 7
            Dim estadoSemen As Integer = 8

            'tipoAdquisicion
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGreen, Color.DarkGreen, "GRANJA", tipoAdquisicion)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightBlue, Color.Black, "COMPRADO", tipoAdquisicion)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightPink, Color.Black, "REGULARIZACIÓN", tipoAdquisicion)

            'estadoSemen
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGreen, Color.DarkGreen, "ÓPTIMO", estadoSemen)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightYellow, Color.Goldenrod, "PRÓXIMO VENCER", estadoSemen)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.MistyRose, Color.IndianRed, "NO ÓPTIMO", estadoSemen)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "DESCARTADO", estadoSemen)

            'centrar columnas
            With dtgListado.DisplayLayout.Bands(0)
                .Columns(tipoAdquisicion).CellAppearance.TextHAlign = HAlign.Center
                .Columns(estadoSemen).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Consultar()
    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        Try
            If (dtgListado.Rows.Count > 0) Then
                If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim id As Integer = e.Cell.Row.Cells("idMaterialGenetico").Value
                    Dim codVerraco As String = e.Cell.Row.Cells("Cod Cerdo").Value
                    Dim numDosisDisponibles As Integer = e.Cell.Row.Cells("N° Dosis").Value - e.Cell.Row.Cells("N° Dosis Utilizadas").Value

                    _frmEditarInseminacion.LlenarCamposMaterialGenetico(id, codVerraco, numDosisDisponibles)
                    Me.Close()
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

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class