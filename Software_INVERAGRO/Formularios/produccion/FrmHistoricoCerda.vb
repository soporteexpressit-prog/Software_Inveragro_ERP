Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmHistoricoCerda
    Dim cn As New cnControlAnimal
    Public idCerda As Integer = 0
    Public codAnimal As String = ""
    Public etapa As String = ""
    Public idUbicacion As Integer = 0

    Private Sub FrmHistoricoCerda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LblCodArete.Text = codAnimal
        LblEtapa.Text = etapa
        ConsultarHistoricoxIdCerda()
        If etapa = "" Then
            LblEtapaAnimal.Visible = False
        End If
    End Sub

    Private Sub ConsultarHistoricoxIdCerda()
        Try
            Dim obj As New coControlAnimal With {
                .Codigo = idCerda
            }
            DtgListadoHistorico.DataSource = cn.Cn_ConsultarHistoricoxIdCerda(obj).Copy
            clsBasicas.Formato_Tablas_Grid(DtgListadoHistorico)
            DtgListadoHistorico.DisplayLayout.Bands(0).Columns(0).Hidden = True
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub DtgListadoHistorico_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles DtgListadoHistorico.InitializeLayout
        Try
            clsBasicas.Formato_Tablas_Grid(DtgListadoHistorico)
            With e.Layout.Bands(0)
                .Columns("Editar").Style = UltraWinGrid.ColumnStyle.Button
                .Columns("Editar").CellButtonAppearance.Image = My.Resources.lapiz ' Imagen por defecto
                .Columns("Editar").ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
                .Columns("Editar").CellClickAction = UltraWinGrid.CellClickAction.EditAndSelectText
                .Columns("Editar").CellButtonAppearance.ImageHAlign = HAlign.Center
                .Columns("Editar").Width = 50
            End With
            With e.Layout.Bands(0)
                .Columns("Eliminar").Style = UltraWinGrid.ColumnStyle.Button
                .Columns("Eliminar").CellButtonAppearance.Image = My.Resources.ico_eliminar
                .Columns("Eliminar").ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
                .Columns("Eliminar").CellClickAction = UltraWinGrid.CellClickAction.EditAndSelectText
                .Columns("Eliminar").CellButtonAppearance.ImageHAlign = HAlign.Center
                .Columns("Eliminar").Width = 50
            End With
            If (DtgListadoHistorico.Rows.Count > 0) Then
                e.Layout.Bands(0).Summaries.Clear()
                clsBasicas.Totales_Formato(DtgListadoHistorico, e, 0)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub DtgListadoHistorico_InitializeRow(sender As Object, e As UltraWinGrid.InitializeRowEventArgs) Handles DtgListadoHistorico.InitializeRow
        Try
            If e.Row.Cells(3).Value IsNot Nothing Then
                Dim tipoControl As String = e.Row.Cells(3).Value.ToString().ToUpper()

                If tipoControl = "DESTETE" OrElse tipoControl = "ENVÍO AL CAMAL" Then
                    e.Row.Cells("Editar").ButtonAppearance.Image = My.Resources.buscar16px
                End If
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub


    Private Sub DtgListadoHistorico_ClickCellButton(sender As Object, e As CellEventArgs) Handles DtgListadoHistorico.ClickCellButton
        Dim cn As New cnControlGestacion
        Dim cnAnimal As New cnControlAnimal

        If e.Cell.Column.Key = "Editar" Then
            Dim dataSource As DataTable = TryCast(DtgListadoHistorico.DataSource, DataTable)
            If dataSource Is Nothing OrElse dataSource.Rows.Count = 0 Then
                msj_advert("No hay registros disponibles para editar.")
                Return
            End If
            Dim valorColumna As String = e.Cell.Row.Cells("Descripción del evento").Value.ToString()
            Dim rowIndex As Integer = e.Cell.Row.Index

            If valorColumna = "DESTETE" Then
                Dim frm As New FrmVisualizarDesteteHembra()
                Dim idFicha As Integer = Convert.ToInt32(e.Cell.Row.Cells("idControlFicha").Value)
                frm.idControlFicha = idFicha
                frm.ShowDialog()
                Return
            ElseIf valorColumna = "ENVÍO AL CAMAL" Then
                Dim frm As New FrmVisualizarEnvioCamalHembra()
                Dim idFicha As Integer = Convert.ToInt32(e.Cell.Row.Cells("idControlFicha").Value)
                frm.idControlFicha = idFicha
                frm.ShowDialog()
                Return
            End If

            Dim eventosRestringidos As String() = {
                "MORTALIDAD",
                "DESTETE",
                "RECIBIMIENTO DE LECHÓN",
                "DONACIÓN DE LECHÓN",
                "ENVÍO AL CAMAL",
                "VENDIDO"
            }

            If eventosRestringidos.Contains(valorColumna) Then
                msj_advert("Editar solo está disponible para evento de parto, mortalidad de crías, servicio y pérdidas reproductivas")
                Return
            End If

            If rowIndex >= 0 AndAlso rowIndex < dataSource.Rows.Count Then
                Select Case valorColumna.ToUpper()
                    Case "PARTO"
                        Dim frm As New FrmRegParto With {
                            .idControlParto = e.Cell.Row.Cells(0).Value,
                            .idUbicacion = idUbicacion,
                            .arete = codAnimal
                        }
                        frm.ShowDialog()
                        ConsultarHistoricoxIdCerda()
                    Case "MORTALIDAD CRÍAS"
                        Dim frm As New FrmMandarCamalMortalidadCriaCerda With {
                            .idControlFichaMortalidad = e.Cell.Row.Cells(0).Value
                        }
                        frm.ShowDialog()
                        ConsultarHistoricoxIdCerda()
                    Case "SERVICIO"
                        Dim frm As New FrmRegistrarInseminacion With {
                            .idServicio = e.Cell.Row.Cells(0).Value,
                            .idPlantel = idUbicacion
                        }
                        frm.ShowDialog()
                        ConsultarHistoricoxIdCerda()
                    Case "REPETICIÓN CELO", "FALSA PREÑEZ", "ABORTO"
                        Dim frm As New FrmRegistrarTestGestacion With {
                            .idControlFicha = e.Cell.Row.Cells(0).Value
                        }
                        frm.ShowDialog()
                        ConsultarHistoricoxIdCerda()
                End Select
            Else
                msj_advert("Fila no válida para eliminar")
            End If
        End If

        If e.Cell.Column.Key = "Eliminar" Then
            Dim dataSource As DataTable = TryCast(DtgListadoHistorico.DataSource, DataTable)
            If dataSource Is Nothing OrElse dataSource.Rows.Count = 0 Then
                msj_advert("No hay registros disponibles para eliminar.")
                Return
            End If
            Dim valorColumna As String = e.Cell.Row.Cells("Descripción del evento").Value.ToString()
            Dim rowIndex As Integer = e.Cell.Row.Index

            If valorColumna = "VENDIDO" Then
                msj_advert("ESTE EVENTO YA NO PUEDE SER ELIMINADO")
                Return
            End If

            If valorColumna = "RECIBIMIENTO DE LECHÓN" Then
                msj_advert("DEBE ELIMINAR LOS EVENTOS DE DONACIONES PARA QUE SE ELIMINE EL EVENTO DE RECIBIMIENTO DE LECHÓN")
                Return
            End If

            If valorColumna = "DESTETE NULO" Then
                msj_advert("ESTE EVENTO NO SE PUEDE ELIMINAR, DEBE ELIMINAR EL EVENTO QUE CAUSO EL DESTETE NULO")
                Return
            End If

            If rowIndex >= 0 AndAlso rowIndex < dataSource.Rows.Count Then

                If (MessageBox.Show("¿ESTÁ SEGURO DE ELIMINAR ESTE EVENTO?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                    Return
                End If

                Dim obj As Object = Nothing
                Dim mensaje As String = ""

                Select Case valorColumna.ToUpper()
                    Case "REPETICIÓN CELO", "FALSA PREÑEZ", "ABORTO"
                        obj = New coControlAnimal With {
                            .IdControlFicha = e.Cell.Row.Cells(0).Value
                        }
                        mensaje = cnAnimal.Cn_EliminarPerdidaReproductiva(DirectCast(obj, coControlAnimal))

                    Case "MORTALIDAD CRÍAS"
                        obj = New coControlAnimal With {
                            .IdControlFicha = e.Cell.Row.Cells(0).Value
                        }
                        mensaje = cnAnimal.Cn_EliminarMortalidadCriasMaternidad(DirectCast(obj, coControlAnimal))
                    Case "DONACIÓN DE LECHÓN"
                        obj = New coControlAnimal With {
                            .IdControlFichaDonacion = e.Cell.Row.Cells(0).Value,
                            .Codigo = idCerda
                        }
                        mensaje = cnAnimal.Cn_EliminarMovimientoCriasMaternidad(DirectCast(obj, coControlAnimal))
                    Case "SERVICIO"
                        obj = New coControlAnimal With {
                            .IdControlFicha = e.Cell.Row.Cells(0).Value
                        }
                        mensaje = cnAnimal.Cn_EliminarServicio(DirectCast(obj, coControlAnimal))
                    Case "PARTO"
                        obj = New coControlAnimal With {
                            .IdControlFicha = e.Cell.Row.Cells(0).Value
                        }
                        mensaje = cnAnimal.Cn_EliminarParto(DirectCast(obj, coControlAnimal))
                    Case "MORTALIDAD"
                        obj = New coControlAnimal With {
                            .IdControlFicha = e.Cell.Row.Cells(0).Value
                        }
                        mensaje = cnAnimal.Cn_EliminarMortalidad(DirectCast(obj, coControlAnimal))
                    Case "DESTETE"
                        obj = New coControlAnimal With {
                            .IdControlFicha = e.Cell.Row.Cells(0).Value
                        }
                        mensaje = cnAnimal.Cn_EliminarDestete(DirectCast(obj, coControlAnimal))
                    Case "ENVÍO AL CAMAL"
                        obj = New coControlAnimal With {
                            .IdHistorialEnvioCamal = e.Cell.Row.Cells(0).Value,
                            .MotivoAnulacion = "NINGUNO"
                        }
                        mensaje = cnAnimal.Cn_AnularEnvioCamal(DirectCast(obj, coControlAnimal))
                End Select

                If obj.Coderror = 0 Then
                    msj_ok(mensaje)
                    ConsultarHistoricoxIdCerda()
                Else
                    msj_advert(mensaje)
                End If
            Else
                msj_advert("Fila no válida para eliminar")
            End If
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class