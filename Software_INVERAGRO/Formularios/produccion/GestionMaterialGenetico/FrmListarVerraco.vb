Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmListarVerraco
    Dim cn As New cnControlAnimal
    Public idPlantel As Integer = 0
    Private ReadOnly _frmMantMaterialGenetico As FrmMantMaterialGenetico

    Public Sub New(frmMantMaterialGenetico As FrmMantMaterialGenetico)
        InitializeComponent()
        _frmMantMaterialGenetico = frmMantMaterialGenetico
    End Sub

    Private Sub FrmListarVerraco_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clsBasicas.Filtrar_Tabla(dtgListado, True)
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        ListarVerracoDisponible()
    End Sub

    Sub ListarVerracoDisponible()
        Try
            Dim obj As New coControlAnimal With {
                .idPlantel = idPlantel
            }
            dtgListado.DataSource = cn.Cn_ListarVerracoDisponible(obj)
            dtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True
            Colorear()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Colorear()
        If (dtgListado.Rows.Count > 0) Then
            Dim estadoExtraccion As Integer = 6
            Dim condReproductiva As Integer = 7

            'estadoExtraccion
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGreen, Color.DarkGreen, "ENTRENAR", estadoExtraccion)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGreen, Color.DarkGreen, "DISPONIBLE", estadoExtraccion)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "NO DISPONIBLE", estadoExtraccion)

            'comportamientoCamborough
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGreen, Color.DarkGreen, "APTO", condReproductiva)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "NO APTO", condReproductiva)

            'centrar columnas
            With dtgListado.DisplayLayout.Bands(0)
                .Columns(estadoExtraccion).CellAppearance.TextHAlign = HAlign.Center
                .Columns(condReproductiva).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        Try
            If (dtgListado.Rows.Count > 0) Then
                If (dtgListado.ActiveRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim condicionReproductiva As String = dtgListado.ActiveRow.Cells("Estado Extracción").Value.ToString

                    If (condicionReproductiva = "NO DISPONIBLE") Then
                        If (MessageBox.Show("¿ESTÁ SEGURO DE REGISTRAR EXTRACCIÓN SEMEN DE ESTE CERDO?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                            Return
                        End If
                    End If

                    Dim id As Integer = e.Cell.Row.Cells("idAnimal").Value
                    Dim codigo As String = e.Cell.Row.Cells("Código").Value
                    Dim lineaGenetica As String = e.Cell.Row.Cells("Línea Genética").Value

                    _frmMantMaterialGenetico.LlenarCamposVerraco(id, codigo, lineaGenetica)
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