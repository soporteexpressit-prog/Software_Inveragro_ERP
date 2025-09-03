Imports CapaNegocio
Imports CapaObjetos

Public Class FrmGestionarVisualizacionRacion
    Dim cn As New cnNucleo
    Public idUbicacion As Integer = 0

    Private Sub FrmGestionarVisualizacionRacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            clsBasicas.Formato_Tablas_Grid_UltimaColumnaEditable(DtgListado)
            ListarAmbiente()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ListarAmbiente()
        Try
            Dim obj As New coNucleo With {
                .IdUbicacion = idUbicacion
            }
            DtgListado.DataSource = cn.Cn_ConsultarRaciones(obj)
            DtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnGuardarPcorr_Click(sender As Object, e As EventArgs) Handles btnGuardarPcorr.Click
        Try
            DtgListado.UpdateData()
            DtgListado.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode)

            If (MessageBox.Show("¿ESTÁ SEGURO DE GUARDAR ESTE REGISTRO?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coNucleo With {
                .Codigo = idUbicacion,
                .ListaItems = CreacionArray()
            }

            Dim _mensaje As String = cn.Cn_PermisoVerRacioxUbicacion(obj)
            If (obj.Coderror = 0) Then
                msj_ok(_mensaje)
                Dispose()
            Else
                msj_advert(_mensaje)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Function CreacionArray() As String
        Dim array_valvulas As String = ""
        If (DtgListado.Rows.Count = 0) Then
            array_valvulas = "0"
        Else
            For i = 0 To DtgListado.Rows.Count - 1
                If (DtgListado.Rows(i).Cells(0).Value.ToString.Trim.Length <> 0) Then
                    With DtgListado.Rows(i)
                        Dim permisoValor As String = If(CBool(.Cells("Permiso").Value), "1", "0")
                        array_valvulas &= .Cells("Código").Value.ToString.Trim & "+" & permisoValor & ","
                    End With
                End If
            Next
            array_valvulas = array_valvulas.Substring(0, array_valvulas.Length - 1)
        End If
        Return array_valvulas
    End Function

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class