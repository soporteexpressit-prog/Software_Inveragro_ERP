Imports CapaNegocio
Imports CapaObjetos

Public Class FrmVisualizacionAlimentacionPresupuesto
    Public idPlantel As Integer = 6
    Dim cn As New cnControlAlimento

    Private Sub FrmVisualizacionAlimentacionPresupuesto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            clsBasicas.Formato_Tablas_Grid_UltimaColumnaEditable(dtgListado)
            ListarAlimentoCerdo()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ListarAlimentoCerdo()
        Dim dt As DataTable = cn.Cn_ListarAlimentoPresupuesto(idPlantel)
        dtgListado.DataSource = dt
        dtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            dtgListado.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode)

            If (MessageBox.Show("¿ESTÁ SEGURO DE ACTUALIZAR ESTOS REGISTROS?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coControlAlimento With {
                .ListaAlimentos = CreacionArrayProducto()
            }

            Dim MensajeBgWk As String = cn.Cn_ActualizarEstadoPresupuestoProducto(obj)
            If (obj.Coderror = 0) Then
                msj_ok(MensajeBgWk)
                Dispose()
            Else
                msj_advert(MensajeBgWk)
            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Function CreacionArrayProducto() As String
        Dim array_valvulas As String = ""

        If dtgListado.Rows.Count = 0 Then
            array_valvulas = "0"
        Else
            For i = 0 To dtgListado.Rows.Count - 1
                If dtgListado.Rows(i).Cells(0).Value.ToString.Trim.Length <> 0 Then
                    With dtgListado.Rows(i)
                        Dim visualizarValor As String = "0"
                        If Convert.ToBoolean(.Cells("Visualizar").Value) = True Then
                            visualizarValor = "1"
                        End If

                        array_valvulas &= .Cells("Código").Value.ToString.Trim & "+" & visualizarValor & ","
                    End With
                End If
            Next

            array_valvulas = array_valvulas.Substring(0, array_valvulas.Length - 1)
        End If

        Return array_valvulas
    End Function


    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dispose()
    End Sub
End Class