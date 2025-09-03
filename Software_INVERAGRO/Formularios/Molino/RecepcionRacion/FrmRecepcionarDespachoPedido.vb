Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win.UltraWinGrid

Public Class FrmRecepcionarDespachoPedido
    Dim cn As New cnControlRecepcionAlimento
    Public idRecepcion As Integer

    Private Sub FrmRecepcionarDespachoPedido_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConsultarDetalleRecepcionAlimento()
        DtpFechaRecepcion.Value = Now.Date
    End Sub

    Private Sub ConsultarDetalleRecepcionAlimento()
        Try
            Dim obj As New coControlRecepcionAlimento With {
                .Codigo = idRecepcion
            }
            clsBasicas.Formato_Tablas_Grid_DosUltimasColumnaEditable(dtgListado)
            dtgListado.DataSource = cn.Cn_ConsultarDetalleRecepcionAlimentoxId(obj)
            dtgListado.DisplayLayout.Bands(0).Columns("iddetrecepcion").Hidden = True
            FormatoColumnas()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub FormatoColumnas()
        Try
            If dtgListado.Rows.Count > 0 Then
                Dim colorCantidadRecibida As Color = Color.LightGray

                For Each fila As UltraGridRow In dtgListado.Rows
                    If fila.Cells.Exists("Cant. Recibida") Or fila.Cells.Exists("Sacos Extra Recibido") Then
                        fila.Cells("Cant. Recibida").Appearance.BackColor = colorCantidadRecibida
                        fila.Cells("Cant. Recibida").Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                        fila.Cells("Sacos Extra Recibido").Appearance.BackColor = colorCantidadRecibida
                        fila.Cells("Sacos Extra Recibido").Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                    End If
                Next
                dtgListado.Refresh()
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub


    Private Sub dtgListado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dtgListado.KeyPress
        If dtgListado.ActiveCell IsNot Nothing AndAlso dtgListado.ActiveCell.Column.Key = "Cant. Recibida" Then
            Dim activeText As String = dtgListado.ActiveCell.Text
            Dim pressedKey As Char = e.KeyChar

            If Not (Char.IsDigit(pressedKey) OrElse pressedKey = "."c OrElse Char.IsControl(pressedKey)) Then
                e.Handled = True
                Exit Sub
            End If

            If pressedKey = "."c AndAlso activeText.Contains(".") Then
                e.Handled = True
                Exit Sub
            End If

            Dim newText As String = activeText
            If Not Char.IsControl(pressedKey) Then
                newText &= pressedKey
            Else
                newText = activeText
            End If

            Dim parts() As String = newText.Split("."c)

            If parts(0).Length > 3 Then
                e.Handled = True
                Exit Sub
            End If

            If parts.Length > 1 Then
                If parts(1).Length > 3 Then
                    e.Handled = True
                    Exit Sub
                End If
            End If

            e.Handled = False
        End If

        If dtgListado.ActiveCell IsNot Nothing AndAlso dtgListado.ActiveCell.Column.Key = "Sacos Extra Recibido" Then
            Dim activeText As String = dtgListado.ActiveCell.Text
            Dim pressedKey As Char = e.KeyChar

            If Not (Char.IsDigit(pressedKey) OrElse pressedKey = "."c OrElse Char.IsControl(pressedKey)) Then
                e.Handled = True
                Exit Sub
            End If

            If pressedKey = "."c AndAlso activeText.Contains(".") Then
                e.Handled = True
                Exit Sub
            End If

            Dim newText As String = activeText
            If Not Char.IsControl(pressedKey) Then
                newText &= pressedKey
            Else
                newText = activeText
            End If

            Dim parts() As String = newText.Split("."c)

            If parts(0).Length > 3 Then
                e.Handled = True
                Exit Sub
            End If

            If parts.Length > 1 Then
                If parts(1).Length > 3 Then
                    e.Handled = True
                    Exit Sub
                End If
            End If

            e.Handled = False
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            dtgListado.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode)

            For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In dtgListado.Rows
                Dim cantidadRecibida As Double = 0
                Dim cantidadEnviada As Double = 0

                If row.Cells("Cant. Recibida").Value IsNot Nothing AndAlso
                   row.Cells("Cant. Enviada").Value IsNot Nothing Then

                    If Double.TryParse(row.Cells("Cant. Recibida").Value.ToString(), cantidadRecibida) AndAlso
                       Double.TryParse(row.Cells("Cant. Enviada").Value.ToString(), cantidadEnviada) Then

                        If cantidadRecibida > cantidadEnviada Then
                            msj_advert("La cantidad recibida no puede ser mayor a la cantidad enviada")
                            Exit Sub
                        End If
                    End If
                End If
            Next

            If DtpFechaRecepcion.Value > Now.Date Then
                msj_advert("La fecha de recepción no puede ser mayor a la fecha actual")
                Return
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE LA CONFIRMACIÓN DE LA RECEPCIÓN?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coControlRecepcionAlimento With {
                .FechaControl = DtpFechaRecepcion.Value,
                .Codigo = idRecepcion,
                .IdUsuario = VP_IdUser,
                .ListarRacionesRecibidas = CreacionArrayCantidadRacionRecibida()
            }

            Dim MensajeBgWk As String = cn.Cn_RegistrarRecepcionRaciones(obj)
            If (obj.Coderror = 0) Then
                msj_ok(MensajeBgWk)
                Close()
            Else
                msj_advert(MensajeBgWk)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Function CreacionArrayCantidadRacionRecibida() As String
        Dim array_valvulas As String = ""
        If (dtgListado.Rows.Count = 0) Then
            array_valvulas = "0"
        Else
            For i = 0 To dtgListado.Rows.Count - 1
                If (dtgListado.Rows(i).Cells(0).Value.ToString.Trim.Length <> 0) Then
                    With dtgListado.Rows(i)
                        array_valvulas = array_valvulas &
                            .Cells("iddetrecepcion").Value.ToString.Trim & "+" &
                            .Cells("Cant. Recibida").Value.ToString.Trim & "+" &
                            .Cells("Sacos Extra Recibido").Value.ToString.Trim & ","
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