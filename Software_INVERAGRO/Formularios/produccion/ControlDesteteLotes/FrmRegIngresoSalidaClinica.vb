Imports CapaNegocio
Imports CapaObjetos

Public Class FrmRegIngresoSalidaClinica
    Dim cnLote As New cnControlLoteDestete
    Public idLote As Integer
    Public idPlantel As Integer
    Public valorPlantel As String
    Public valorLote As String

    Private Sub FrmRegIngresoSalidaClinica_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ListarDetalleCorralesLote()
            ListarAnimalesJaulaCorral()
            ListarClinicas()
            LblLote.Text = valorLote
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ListarDetalleCorralesLote()
        Try
            Dim obj As New coControlLoteDestete With {
                .IdLote = idLote,
                .IdPlantel = idPlantel
            }

            Dim ds As DataSet = cnLote.Cn_ConsultarAnimalesLoteClinica(obj)

            If ds IsNot Nothing AndAlso ds.Tables.Count > 0 Then
                DtgListadoCerdos.DataSource = ds.Tables(0)
                DtgListadoCerdos.DisplayLayout.Bands(0).Columns(0).Hidden = True
                clsBasicas.Filtrar_Tabla(DtgListadoCerdos, True)
                clsBasicas.Formato_Tablas_Grid(DtgListadoCerdos)

                If ds.Tables.Count > 1 AndAlso ds.Tables(1).Rows.Count > 0 Then
                    TxtPuras.Text = CInt(ds.Tables(1).Rows(0)("CantPura"))
                    TxtCambo.Text = CInt(ds.Tables(1).Rows(0)("CantCambo"))
                    TxtEngorde.Text = CInt(ds.Tables(1).Rows(0)("CantEngorde"))
                End If
            End If
            Inicializar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ListarClinicas()
        Dim tb As New DataTable
        Dim obj As New coControlLoteDestete With {
            .IdPlantel = idPlantel
        }

        tb = cnLote.Cn_ConsultarClinica(obj).Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione una Clínica"
        With CmbClinica
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Private Sub Inicializar()
        TxtPuras.ReadOnly = True
        TxtCambo.ReadOnly = True
        TxtEngorde.ReadOnly = True
        LblPlantel.Text = valorPlantel
    End Sub

    Private Sub ListarAnimalesJaulaCorral()
        Try
            Dim obj As New coControlLoteDestete With {
                .IdPlantel = idPlantel
            }

            DtgListadoCerdosClinica.DataSource = cnLote.Cn_ConsultarAnimalesClinica(obj)
            DtgListadoCerdosClinica.DisplayLayout.Bands(0).Columns(0).Hidden = True
            clsBasicas.Filtrar_Tabla(DtgListadoCerdosClinica, True)
            clsBasicas.Formato_Tablas_Grid(DtgListadoCerdosClinica)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub DtgListadoCerdosClinica_InitializeRow(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles DtgListadoCerdosClinica.InitializeRow
        Dim column As Infragistics.Win.UltraWinGrid.UltraGridColumn = DtgListadoCerdosClinica.DisplayLayout.Bands(0).Columns("Retirar")
        column.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Button
        column.ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
        If Not e.ReInitialize Then
            e.Row.Cells("Retirar").Value = "Retirar"
            e.Row.Cells("Retirar").Appearance.TextHAlign = Infragistics.Win.HAlign.Center
        End If
    End Sub

    Private Sub DtgListadoCerdosClinica_ClickCellButton(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles DtgListadoCerdosClinica.ClickCellButton
        Try
            With DtgListadoCerdosClinica
                If (e.Cell.Column.Key = "Retirar") Then
                    Dim tipo As String = .Rows(e.Cell.Row.Index).Cells("Tipo").Value

                    If tipo = "PURAS" Then
                        Dim idAnimal As Integer = .Rows(e.Cell.Row.Index).Cells("idAnimal").Value

                        If (MessageBox.Show("¿ESTÁ SEGURO DE RETIRAR A ESTE ANIMAL DE CLÍNICA?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                            Return
                        End If

                        Dim obj As New coControlLoteDestete With {
                            .IdAnimal = idAnimal,
                            .IdLote = idLote,
                            .CantidadTatuadas = 0,
                            .CantidadVenta = 0,
                            .TipoFiltro = "PURA",
                            .IdPlantel = idPlantel
                        }

                        Dim _mensaje As String = cnLote.Cn_RetirarAnimalClinica(obj)
                        If (obj.Coderror = 0) Then
                            msj_ok(_mensaje)
                            ListarDetalleCorralesLote()
                            ListarAnimalesJaulaCorral()
                        Else
                            msj_advert(_mensaje)
                        End If
                    Else
                        Dim cantidadNoPuras As Integer = .Rows(e.Cell.Row.Index).Cells("Cantidad").Value

                        Dim frm As New FrmCantidadSacarClinica With {
                            .idLote = idLote,
                            .cantidadNoPuras = cantidadNoPuras,
                            .tipo = tipo,
                            .idPlantel = idPlantel
                        }
                        frm.ShowDialog()
                        ListarDetalleCorralesLote()
                        ListarAnimalesJaulaCorral()
                    End If
                End If
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            If CriasPurasSeleccionadas() = "" And NumCamborough.Value = 0 And NumEngorde.Value = 0 Then
                msj_advert("Seleccione al menos una cría pura o ingrese una cantidad de Camborough o Engorde")
                Exit Sub
            End If

            If NumCamborough.Value > CInt(TxtCambo.Text) Then
                msj_advert("La cantidad de Camborough no puede ser mayor a la cantidad de Camborough en el lote")
                Exit Sub
            ElseIf NumEngorde.Value > CInt(TxtEngorde.Text) Then
                msj_advert("La cantidad de Engorde no puede ser mayor a la cantidad de Engorde en el lote")
                Exit Sub
            ElseIf CmbClinica.Value Is Nothing Then
                msj_advert("Seleccione una clínica")
                Exit Sub
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE MANDAR A CLÍNICA ESTAS CRÍAS?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coControlLoteDestete With {
                .ListaCriasRegistrar = CriasPurasSeleccionadas(),
                .CantidadTatuadas = NumCamborough.Value,
                .CantidadVenta = NumEngorde.Value,
                .IdLote = idLote,
                .IdPlantel = idPlantel,
                .IdJaulaCorral = CmbClinica.Value
            }

            Dim MensajeBgWk As String = cnLote.Cn_RegistrarAnimalClinica(obj)

            If (obj.Coderror = 0) Then
                msj_ok(MensajeBgWk)
                ListarDetalleCorralesLote()
                ListarAnimalesJaulaCorral()
                NumCamborough.Value = 0
                NumEngorde.Value = 0
            Else
                msj_advert(MensajeBgWk)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Function CriasPurasSeleccionadas() As String
        Dim lista As String = ""
        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In DtgListadoCerdos.Rows
            If row.Appearance.BackColor = Color.LightBlue Then
                lista &= row.Cells("idAnimal").Value & ","
            End If
        Next

        If lista.Length > 0 Then lista = lista.TrimEnd(","c)

        Return lista
    End Function


    Private Sub DtgListadoCerdos_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles DtgListadoCerdos.DoubleClickCell
        Dim fila As Infragistics.Win.UltraWinGrid.UltraGridRow = e.Cell.Row

        If fila.Appearance.BackColor = Color.LightBlue Then
            fila.Appearance.BackColor = Color.White
        Else
            fila.Appearance.BackColor = Color.LightBlue
        End If
    End Sub

    Private Sub DtgListadoCerdos_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles DtgListadoCerdos.InitializeLayout
        Try
            If (DtgListadoCerdos.Rows.Count = 0) Then
            Else
                e.Layout.Bands(0).Summaries.Clear()
                clsBasicas.Totales_Formato(DtgListadoCerdos, e, 1)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub DtgListadoCerdosClinica_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles DtgListadoCerdosClinica.InitializeLayout
        Try
            If (DtgListadoCerdosClinica.Rows.Count = 0) Then
            Else
                e.Layout.Bands(0).Summaries.Clear()
                clsBasicas.Totales_Formato(DtgListadoCerdosClinica, e, 1)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub

End Class