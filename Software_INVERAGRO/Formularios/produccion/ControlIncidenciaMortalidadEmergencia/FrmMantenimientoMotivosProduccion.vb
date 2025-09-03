Imports CapaNegocio
Imports CapaObjetos

Public Class FrmMantenimientoMotivosProduccion
    Dim cn As New cnTipoIncidencia
    Public operacion As Integer = 0
    Public idTipoIncidencia As Integer = 0
    Public descripcion As String = ""
    Public tipo As String = ""

    Private Sub FrmMantenimientoMotivosProduccion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            CmbTipoIncidencia.SelectedIndex = 0

            If operacion = 1 Then
                ConsultarxIdTipoIncidencia()
                TxtMotivo.Text = descripcion
                CmbTipoIncidencia.Text = tipo
            Else
                ListarAmbiente()
            End If

            FormatearTablaGrid()
            clsBasicas.Formato_Tablas_Grid_UltimaColumnaEditable(DtgListado)
            DtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ConsultarxIdTipoIncidencia()
        Try
            Dim obj As New coTipoIncidencia With {
                .Codigo = idTipoIncidencia
            }
            Dim dt As New DataTable
            dt = cn.Cn_ConsultarxIdTipoIncidencia(obj)
            DtgListado.DataSource = dt
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub FormatearTablaGrid()
        With DtgListado.DisplayLayout.Bands(0).Columns("Ambiente")
            .Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
            .CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit
        End With

        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In DtgListado.Rows
            If row.Cells("Ambiente").Value IsNot Nothing AndAlso IsNumeric(row.Cells("Ambiente").Value) Then
                Dim cellValue As Integer = CInt(row.Cells("Ambiente").Value)
                If cellValue Then
                    row.Cells("Ambiente").Value = True
                Else
                    row.Cells("Ambiente").Value = False
                End If
            Else
                row.Cells("Ambiente").Value = False
            End If
        Next
    End Sub

    Private Sub ListarAmbiente()
        Try
            DtgListado.DataSource = cn.Cn_ListarAmbiente()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
            DtgListado.DisplayLayout.Bands(0).Columns(0).Hidden = True
        End Try
    End Sub

    Private Sub btnGuardarPcorr_Click(sender As Object, e As EventArgs) Handles btnGuardarPcorr.Click
        Try
            DtgListado.UpdateData()
            Dim ambienteSeleccionado As Boolean = False

            For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In DtgListado.Rows
                If row.Cells("Ambiente").Value = True Then
                    ambienteSeleccionado = True
                    Exit For
                End If
            Next

            If Not ambienteSeleccionado Then
                msj_advert("Seleccione al menos un ambiente")
                Return
            End If

            If String.IsNullOrWhiteSpace(TxtMotivo.Text) Then
                msj_advert("Ingrese un motivo")
                Return
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE GUARDAR ESTE REGISTRO?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coTipoIncidencia With {
               .Operacion = operacion,
               .Codigo = idTipoIncidencia,
               .Descripcion = TxtMotivo.Text,
               .ListaIdsAmbiente = CrearStringAmbiente(),
               .Tipo = CmbTipoIncidencia.Text
            }

            Dim mensaje As String = cn.Cn_Mantenimiento(obj)

            If obj.Coderror = 0 Then
                msj_ok(mensaje)
                Dispose()
            Else
                msj_advert(mensaje)
            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Function CrearStringAmbiente()
        Dim listaIds As String = ""
        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In DtgListado.Rows
            If row.Cells("Ambiente").Value = True Then
                If String.IsNullOrEmpty(listaIds) Then
                    listaIds = row.Cells("IdAmbiente").Value.ToString()
                Else
                    listaIds &= "," & row.Cells("IdAmbiente").Value.ToString()
                End If
            End If
        Next

        Return listaIds
    End Function

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class