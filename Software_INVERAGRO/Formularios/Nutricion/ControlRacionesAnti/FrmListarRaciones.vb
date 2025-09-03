Imports CapaNegocio
Imports CapaObjetos

Public Class FrmListarRaciones
    Dim cnAlimento As New cnControlAlimento
    Dim cn As New cnNucleo
    Private insumosSeleccionados As String = ""
    Public idExtra As Integer

    Private Sub FrmListarRaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Consultar()
    End Sub

    Sub Consultar()
        Try
            dtgListado.DataSource = cn.Cn_ListarRacionesSinPlanMedico()
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            dtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListado_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListado.DoubleClickCell
        If dtgListado.Rows.Count > 0 AndAlso dtgListado.ActiveRow IsNot Nothing Then
            Dim cellValue = dtgListado.ActiveRow.Cells(0).Value
            If cellValue IsNot Nothing AndAlso cellValue.ToString().Length <> 0 Then
                Dim valorPrimeraColumna As String = cellValue.ToString()

                If insumosSeleccionados.Contains(valorPrimeraColumna) Then
                    Dim valoresArray As List(Of String) = insumosSeleccionados.Split(","c).ToList()
                    valoresArray.Remove(valorPrimeraColumna)
                    insumosSeleccionados = String.Join(",", valoresArray)

                    For Each celda As Infragistics.Win.UltraWinGrid.UltraGridCell In dtgListado.ActiveRow.Cells
                        celda.Appearance.BackColor = Color.White
                    Next
                Else
                    If String.IsNullOrEmpty(insumosSeleccionados) Then
                        insumosSeleccionados = valorPrimeraColumna
                    Else
                        insumosSeleccionados &= "," & valorPrimeraColumna
                    End If

                    For Each celda As Infragistics.Win.UltraWinGrid.UltraGridCell In dtgListado.ActiveRow.Cells
                        celda.Appearance.BackColor = Color.LightBlue
                    Next
                End If
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub

    Private Sub btnAsignar_Click(sender As Object, e As EventArgs) Handles btnAsignar.Click
        Try
            Dim _mensaje As String = ""

            If String.IsNullOrEmpty(insumosSeleccionados) Then
                msj_advert("Debe seleccionar al menos un insumo.")
                Return
            End If

            Dim result As DialogResult = MessageBox.Show("¿ESTÁ SEGURO DE ASIGNAR ESTE PLAN MEDICADO A RACIONES?", "Confirmar Acción", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            If result = DialogResult.Yes Then
                Dim obj As New coControlFormulacion
                obj.Codigo = idExtra
                obj.ListaIdsInsumos = insumosSeleccionados

                _mensaje = cnAlimento.Cn_MantenimientoPlanMedicado(obj)

                If obj.Coderror = 0 Then
                    msj_ok(_mensaje)
                    Me.Close()
                Else
                    msj_advert(_mensaje)
                End If
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class