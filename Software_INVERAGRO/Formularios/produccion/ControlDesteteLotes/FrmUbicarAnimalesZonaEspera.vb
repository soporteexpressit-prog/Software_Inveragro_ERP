Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmUbicarAnimalesZonaEspera
    Dim cnLoteDestete As New cnControlLoteDestete
    Dim cn As New cnJaulaCorral
    Public idPlantel As Integer = 0
    Public idLote As Integer = 0
    Dim cantCriasUbicadas As Integer = 0
    Dim cantAnimalesZonaEspera As Integer = 0

    Private Sub FrmUbicarAnimalesZonaEspera_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            ListarCorralesJaula()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        RbtCorrales.Checked = True
    End Sub

    Private Sub ListarCorralesJaula()
        Try
            Dim obj As New coJaulaCorral With {
                .IdUbicacion = idPlantel,
                .Tipo = IIf(RbtCorrales.Checked, "CORRAL", "JAULA"),
                .IdLote = idLote
            }

            dtgListado.DataSource = cn.Cn_ConsultarAmbientesRecriaEngorde(obj)
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            clsBasicas.Filtrar_Tabla(dtgListado, True)
            dtgListado.DisplayLayout.Bands(0).Columns("idJaulaCorral").Hidden = True
            dtgListado.DisplayLayout.Bands(0).Columns("N° Disponible").Hidden = True
            If dtgListado.Rows.Count > 0 Then
                LblCorralJaula.Text = dtgListado.Rows(0).Cells("Corral").Value.ToString
            Else
                LblCorralJaula.Text = "-"
            End If
            cantAnimalesZonaEspera = ObtenerCantidadZonaEspera()
            LblNumZonaEspera.Text = cantAnimalesZonaEspera.ToString()
            Colorear()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Colorear()
        If (dtgListado.Rows.Count > 0) Then
            Dim estadoCapacidad As Integer = 6

            'estadoCapacidad
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGreen, Color.DarkGreen, "LIBRE", estadoCapacidad)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightYellow, Color.DarkGoldenrod, "PARCIAL", estadoCapacidad)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightCoral, Color.White, "LLENO", estadoCapacidad)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "NO DISPONIBLE", estadoCapacidad)

            'centrar columnas
            With dtgListado.DisplayLayout.Bands(0)
                .Columns(estadoCapacidad).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub dtgListado_ClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles dtgListado.ClickCell
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow

        If activeRow IsNot Nothing AndAlso Not activeRow.IsFilterRow Then
            LblCorralJaula.Text = activeRow.Cells("Corral").Value?.ToString()
        Else
            LblCorralJaula.Text = "- - -"
        End If
    End Sub

    Private Function ObtenerCantidadZonaEspera() As Integer
        If dtgListado.Rows.Count = 0 Then
            Return 0
        End If

        Dim cantidad As Integer

        For Each row As UltraGridRow In dtgListado.Rows
            If row.Cells("Corral").Value.ToString() = "ZONA-ESPERA" Then
                cantidad = row.Cells("Cap. Ocupada").Value.ToString()
                row.Hidden = True
                Exit For
            End If
        Next

        Return cantidad
    End Function

    Private Sub dtgListado_InitializeRow(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dtgListado.InitializeRow
        Dim column As Infragistics.Win.UltraWinGrid.UltraGridColumn = dtgListado.DisplayLayout.Bands(0).Columns("Editar")
        column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
        If Not e.ReInitialize Then
            e.Row.Cells("Editar").Value = "Editar"
            e.Row.Cells("Editar").Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        End If
    End Sub

    Private Sub dtgListado_ClickCellButton(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtgListado.ClickCellButton
        Try
            With dtgListado
                If (e.Cell.Column.Key = "Editar") Then
                    If (LblCorralJaula.Text = "- - -") Then
                        msj_advert("Seleccione un Corral o Jaula")
                        Return
                    End If

                    Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow

                    If activeRow IsNot Nothing AndAlso Not activeRow.IsFilterRow Then
                        NumCantidadIngresar.Value = activeRow.Cells("Cant. Ingresada").Value?.ToString()
                        cantAnimalesZonaEspera += NumCantidadIngresar.Value
                        LblNumZonaEspera.Text = cantAnimalesZonaEspera
                        activeRow.Cells("Cant. Ingresada").Value = 0
                    End If
                End If
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnIngresar_Click(sender As Object, e As EventArgs) Handles BtnIngresar.Click
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If (dtgListado.Rows.Count > 0) Then
            If (activeRow.Cells("idJaulaCorral").Value.ToString.Length <> 0) Then
                If (NumCantidadIngresar.Value > 0) Then

                    If (activeRow.Cells("Cant. Ingresada").Value > 0) Then
                        msj_advert("Ya se ha ingresado una cantidad en este ambiente, si desea modificalor de clic a editar")
                        Return
                    End If

                    If (NumCantidadIngresar.Value > cantAnimalesZonaEspera) Then
                        msj_advert("La cantidad ingresada no puede ser mayor a la cantidad de animales en zona de espera")
                        Return
                    End If

                    If (NumCantidadIngresar.Value > activeRow.Cells("N° Disponible").Value) Then
                        msj_advert("La cantidad ingresada no puede ser mayor a la capacidad del ambiente")
                        Return
                    End If

                    activeRow.Cells("Cant. Ingresada").Value = NumCantidadIngresar.Value
                    cantAnimalesZonaEspera -= NumCantidadIngresar.Value
                    LblNumZonaEspera.Text = cantAnimalesZonaEspera
                    NumCantidadIngresar.Value = 0
                Else
                    msj_advert("La cantidad ingresada debe ser mayor a 0")
                End If
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            Dim cantidadIngresada As Integer = 0

            If (CInt(LblNumZonaEspera.Text) <> 0) Then
                msj_advert("Debe distribuir todas las crías")
                Return
            End If

            For Each fila As UltraGridRow In dtgListado.Rows
                If Not fila.Cells("Cant. Ingresada").Value Is Nothing AndAlso IsNumeric(fila.Cells("Cant. Ingresada").Value) AndAlso Convert.ToDecimal(fila.Cells("Cant. Ingresada").Value) > 0 Then
                    cantidadIngresada += Convert.ToDecimal(fila.Cells("Cant. Ingresada").Value)
                End If
            Next

            If cantidadIngresada = 0 Then
                msj_advert("Debe ingresar una cantidad en al menos un ambiente")
                Return
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE CAMBIAR UBICACIÓN DE CRÍAS?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coControlLoteDestete With {
                .ListaIdsCorralCantidad = ObtenerFilasConCantidad(),
                .IdLote = idLote,
                .IdPlantel = idPlantel
            }

            Dim MensajeBgWk As String = cnLoteDestete.Cn_RegistrarMovimientoZonaEspera(obj)

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

    Private Function ObtenerFilasConCantidad() As String
        Dim resultado As String = ""

        For Each fila As UltraGridRow In dtgListado.Rows
            If Not fila.Cells("Cant. Ingresada").Value Is Nothing AndAlso IsNumeric(fila.Cells("Cant. Ingresada").Value) AndAlso Convert.ToDecimal(fila.Cells("Cant. Ingresada").Value) > 0 Then
                Dim id As String = fila.Cells("idJaulaCorral").Value.ToString()
                Dim cantidad As String = fila.Cells("Cant. Ingresada").Value.ToString()

                resultado &= id & "+" & cantidad & ","
            End If
        Next

        If resultado.Length > 0 Then
            resultado = resultado.TrimEnd(","c)
        End If

        Return resultado
    End Function

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class