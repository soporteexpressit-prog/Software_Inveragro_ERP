Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmFichaCicloVidaCerda
    Dim cn As New cnControlAnimal
    Dim ds As New DataSet
    Public idCerda As Integer = 0

    Private Sub FrmFichaCicloVidaCerda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ConsultarxIdCerda()
        Inicializar()
    End Sub

    Private Sub Inicializar()
        Me.Width = 1200
        AddHandler HistorialMedicacion.Enter, AddressOf HistorialMedico_Enter
        AddHandler EtapaGestacion.Enter, AddressOf EtapaGestacion_Enter
        AddHandler Partos.Enter, AddressOf Partos_Enter
        AddHandler Abortos.Enter, AddressOf Abortos_Enter
        AddHandler Historico.Enter, AddressOf Historico_Enter
        dtpFechaDesdeControlMedico.Value = Now.Date
        dtpFechaHastaControlMedico.Value = Now.Date
    End Sub

    Sub ConsultarxIdCerda()
        Try
            Dim obj As New coControlAnimal With {
                .Codigo = idCerda
            }
            Dim dt As New DataTable
            dt = cn.Cn_ConsultarGeneralAnimalxId(obj).Copy
            If (dt.Rows.Count > 0) Then
                LblCodArete.Text = dt.Rows(0)("codArete").ToString()
                LblCodAreteMadre.Text = dt.Rows(0)("codAreteMadre").ToString()
                LblEstado.Text = dt.Rows(0)("estadoVida").ToString()
                LblFechaNacimiento.Text = dt.Rows(0)("fNacimiento").ToString()
                LblLineaGenetica.Text = dt.Rows(0)("genetica").ToString()
                LblPeso.Text = dt.Rows(0)("peso").ToString()
                LblDisponibilidad.Text = dt.Rows(0)("disponibilidad").ToString()
                LblDiasVida.Text = dt.Rows(0)("diasVida").ToString()
                LblClasificacion.Text = dt.Rows(0)("clasificacion").ToString()
                LblCondCorporal.Text = dt.Rows(0)("condCorporal").ToString()
                LblNumTetillas.Text = dt.Rows(0)("numTetillas").ToString()
                LblCalificacionPatas.Text = dt.Rows(0)("calificacionPatas").ToString()
                LblNumPartos.Text = dt.Rows(0)("numPartos").ToString()
                LblDiasEtapa.Text = dt.Rows(0)("diasEtapa").ToString()
                LblEtapaReproduccion.Text = dt.Rows(0)("etapaReproduccion").ToString()
                LblCondReproductiva.Text = dt.Rows(0)("condReproductiva").ToString()
                LblUbicacion.Text = dt.Rows(0)("ubicacion").ToString()
                LblTipoAdquisicion.Text = dt.Rows(0)("tipoAdquisicion").ToString()

                If (LblEstado.Text = "VIVO") Then
                    LblEstado.BackColor = Color.Green
                    LblEstado.ForeColor = Color.White
                Else
                    LblEstado.BackColor = Color.Red
                    LblEstado.ForeColor = Color.White
                End If

                If (LblDisponibilidad.Text = "EN PROCESO") Then
                    LblDisponibilidad.BackColor = Color.LightGoldenrodYellow
                    LblDisponibilidad.ForeColor = Color.Goldenrod
                ElseIf (LblDisponibilidad.Text = "DISPONIBLE") Then
                    LblDisponibilidad.BackColor = Color.LightGreen
                    LblDisponibilidad.ForeColor = Color.ForestGreen
                ElseIf (LblDisponibilidad.Text = "NO DISPONIBLE") Then
                    LblDisponibilidad.BackColor = Color.LightCoral
                    LblDisponibilidad.ForeColor = Color.White
                Else
                    LblDisponibilidad.BackColor = Color.Thistle
                    LblDisponibilidad.ForeColor = Color.DarkOrchid
                End If
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub HistorialMedico_Enter(sender As Object, e As EventArgs)
        ConsultarHistorialMedicoxIdCerda()
    End Sub

    Private Sub BtnBuscarControlMedico_Click(sender As Object, e As EventArgs) Handles BtnBuscarControlMedico.Click
        ConsultarHistorialMedicoxIdCerda()
    End Sub

    Private Sub ConsultarHistorialMedicoxIdCerda()
        Try
            If dtpFechaDesdeControlMedico.Value > dtpFechaHastaControlMedico.Value Then
                msj_advert(MensajesSistema.mensajesGenerales("FECHA_INICIO_MAYOR_FIN"))
                Return
            End If

            Dim obj As New coControlAnimal With {
                .Codigo = idCerda,
                .FechaDesde = dtpFechaDesdeControlMedico.Value,
                .FechaHasta = dtpFechaHastaControlMedico.Value
            }

            ds = cn.Cn_ConsultarMedicacionxIdAnimal(obj).Copy
            ds.DataSetName = "tmp"

            Dim relation1 As New DataRelation("tb_relacion1", ds.Tables.Item(0).Columns.Item(0), ds.Tables.Item(1).Columns.Item(0), False)

            ds.Relations.Add(relation1)
            dtgListadoMedicacion.DataSource = ds
            clsBasicas.Formato_Tablas_Grid(dtgListadoMedicacion)
            clsBasicas.Colorear_SegunValor(dtgListadoMedicacion, Color.Green, Color.White, "APLICADO", 5)
            clsBasicas.Colorear_SegunValor(dtgListadoMedicacion, Color.Red, Color.White, "CANCELADO", 5)
            dtgListadoMedicacion.DisplayLayout.Bands(0).Columns(0).Hidden = True
            dtgListadoMedicacion.DisplayLayout.Bands(1).Columns(0).Hidden = True
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub LlenarComboConAnios(combo As ComboBox)
        combo.Items.Clear()
        For i As Integer = DateTime.Now.Year - 10 To DateTime.Now.Year + 10
            combo.Items.Add(i.ToString())
        Next
        combo.DropDownStyle = ComboBoxStyle.DropDownList
        combo.Text = DateTime.Now.Year.ToString()
    End Sub

    Private Sub EtapaGestacion_Enter(sender As Object, e As EventArgs)
        LlenarComboConAnios(CmbAniosGestacion)
    End Sub

    Private Sub ConsultarHistorialGestacionxIdCerda()
        Try
            Dim obj As New coControlAnimal With {
                .Codigo = idCerda,
                .Anio = CmbAniosGestacion.Text,
                .EtapaReproductiva = "SERVICIO"
            }

            ds = cn.Cn_ConsultarHistorialGestacionMaternidadxIdCerda(obj).Copy
            ds.DataSetName = "tmp"

            Dim relation1 As New DataRelation("tb_relacion1", ds.Tables.Item(0).Columns.Item(0), ds.Tables.Item(1).Columns.Item(0), False)

            ds.Relations.Add(relation1)
            dtgListadoGestacion.DataSource = ds
            clsBasicas.Formato_Tablas_Grid(dtgListadoGestacion)

            dtgListadoGestacion.DisplayLayout.Bands(0).Columns(0).Hidden = True
            dtgListadoGestacion.DisplayLayout.Bands(1).Columns(0).Hidden = True
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub CmbAniosGestacion_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbAniosGestacion.SelectedValueChanged
        ConsultarHistorialGestacionxIdCerda()
    End Sub

    Private Sub Abortos_Enter(sender As Object, e As EventArgs)
        Try
            Dim obj As New coControlAnimal With {
                .Codigo = idCerda
            }
            dtgListadoAborto.DataSource = cn.Cn_ConsultarHistorialAbortoxIdCerda(obj).Copy
            clsBasicas.Formato_Tablas_Grid(dtgListadoAborto)
            clsBasicas.Colorear_SegunValor(dtgListadoAborto, Color.Red, Color.White, "ABORTO", 3)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Partos_Enter()
        LlenarComboConAnios(CmbAniosPartos)
    End Sub

    Private Sub ConsultarHistorialPartoxIdCerda()
        Try
            Dim obj As New coControlAnimal With {
                .Codigo = idCerda,
                .Anio = CmbAniosPartos.Text
            }

            ds = cn.Cn_ConsultarHistorialPartosxIdCerda(obj).Copy
            ds.DataSetName = "tmp"
            dtgListadoPartos.DataSource = ds
            clsBasicas.Formato_Tablas_Grid(dtgListadoPartos)
            dtgListadoPartos.DisplayLayout.Bands(0).Columns(0).Hidden = True
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Historico_Enter()
        ConsultarHistoricoxIdCerda()
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

    Private Sub CmbAniosPartos_SelectedValueChanged(sender As Object, e As EventArgs) Handles CmbAniosPartos.SelectedValueChanged
        ConsultarHistorialPartoxIdCerda()
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub

    Private Sub DtgListadoHistorico_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles DtgListadoHistorico.InitializeLayout
        Try
            clsBasicas.Formato_Tablas_Grid(DtgListadoHistorico)
            With e.Layout.Bands(0)
                .Columns(5).Header.Caption = "Eliminar evento"
                .Columns(5).Style = UltraWinGrid.ColumnStyle.Button
                .Columns(5).CellButtonAppearance.Image = My.Resources.ico_eliminar
                .Columns(5).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
                .Columns(5).CellClickAction = UltraWinGrid.CellClickAction.EditAndSelectText ' Para asegurar que el botón sea clickeable
                For Each columnns As UltraGridColumn In e.Layout.Bands(0).Columns
                    columnns.PerformAutoResize(PerformAutoSizeType.AllRowsInBand, True)
                Next
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub


    Private Sub DtgListadoHistorico_ClickCellButton(sender As Object, e As CellEventArgs) Handles DtgListadoHistorico.ClickCellButton
        Dim cn As New cnControlGestacion
        Dim cnAnimal As New cnControlAnimal

        If e.Cell.Column.Key = "Eliminar evento" Then
            Dim dataSource As DataTable = TryCast(DtgListadoHistorico.DataSource, DataTable)
            If dataSource Is Nothing OrElse dataSource.Rows.Count = 0 Then
                msj_advert("No hay registros disponibles para eliminar.")
                Return
            End If
            Dim valorColumna As String = e.Cell.Row.Cells(2).Value.ToString()
            Dim rowIndex As Integer = e.Cell.Row.Index

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
End Class