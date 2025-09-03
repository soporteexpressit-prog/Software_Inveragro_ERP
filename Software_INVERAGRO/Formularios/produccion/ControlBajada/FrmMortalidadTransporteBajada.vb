Imports CapaNegocio
Imports CapaObjetos

Public Class FrmMortalidadTransporteBajada
    Dim cnLote As New cnControlLoteDestete
    Public idLote As Integer
    Public idPlantel As Integer
    Public valorPlantelSalida As String
    Public valorLote As String
    Public codigo As Integer = 0

    Private Sub FrmMortalidadTransporteBajada_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListarDetalleCorralesLote()
        dtpFechaConfirmacion.Value = Now.Date
    End Sub

    Private Sub ListarDetalleCorralesLote()
        Try
            Dim obj As New coControlLoteDestete With {
                .IdLote = idLote,
                .IdMovimientoBajada = codigo,
                .IdPlantel = idPlantel,
                .TipoFiltro = "BAJADA"
            }

            Dim resultado As Object = cnLote.Cn_ConsultarAnimalesLoteTransitoBajadaRetorno(obj)

            If TypeOf resultado Is String Then
                msj_advert(resultado.ToString())
                Dispose()
            Else
                Dim ds As DataSet = CType(resultado, DataSet)

                If ds IsNot Nothing AndAlso ds.Tables.Count > 0 Then
                    DtgListadoCerdos.DataSource = ds.Tables(0)
                    DtgListadoCerdos.DisplayLayout.Bands(0).Columns(0).Hidden = True
                    DtgListadoCerdos.DisplayLayout.Bands(0).Columns("Lote").Hidden = True
                    clsBasicas.Filtrar_Tabla(DtgListadoCerdos, True)
                    clsBasicas.Formato_Tablas_Grid(DtgListadoCerdos)

                    If ds.Tables.Count > 1 AndAlso ds.Tables(1).Rows.Count > 0 Then
                        TxtPuras.Text = CInt(ds.Tables(1).Rows(0)("CantPura"))
                        TxtCambo.Text = CInt(ds.Tables(1).Rows(0)("CantCambo"))
                        TxtEngorde.Text = CInt(ds.Tables(1).Rows(0)("CantEngorde"))
                    End If
                End If
                Inicializar()
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        TxtPuras.ReadOnly = True
        TxtCambo.ReadOnly = True
        TxtEngorde.ReadOnly = True
        LblPlantelSalida.Text = valorPlantelSalida
        LblLote.Text = valorLote
    End Sub

    Private Sub BtnConfirmarBajada_Click(sender As Object, e As EventArgs) Handles BtnConfirmarBajada.Click
        Try
            Dim numPuras As Integer = 0
            Dim totalMuertos As Integer = 0

            If dtpFechaConfirmacion.Value > Now.Date Then
                msj_advert("La fecha de confirmación no puede ser mayor a la fecha actual")
                Return
            End If

            If NumCamborough.Value > CInt(TxtCambo.Text) Then
                msj_advert("El número de Camborough no puede ser mayor al número de cerdos disponibles")
                Return
            End If

            If NumEngorde.Value > CInt(TxtEngorde.Text) Then
                msj_advert("El número de Engorde no puede ser mayor al número de cerdos disponibles")
                Return
            End If

            For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In DtgListadoCerdos.Rows
                If row.Appearance.BackColor = Color.LightBlue Then
                    numPuras += 1
                End If
            Next

            totalMuertos = numPuras + NumCamborough.Value + NumEngorde.Value

            If (MessageBox.Show("¿ESTÁ SEGURO DE CONFIRMAR BAJADA CON " & totalMuertos & " ANIMALES MUERTOS?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coControlLoteDestete With {
                .ListaIdsCerdosRegistrados = ObtenerFilasSeleccionadas(),
                .CantidadTatuadas = NumCamborough.Value,
                .CantidadVenta = NumEngorde.Value,
                .IdLote = idLote,
                .IdPlantel = idPlantel,
                .IdUsuario = VP_IdUser,
                .IdMovimientoBajada = codigo,
                .FechaControl = dtpFechaConfirmacion.Value
            }

            Dim mensaje As String = cnLote.Cn_RegistrarConfirmacionBajada(obj)
            If (obj.Coderror = 0) Then
                msj_ok(mensaje)
                Close()
            Else
                msj_advert(mensaje)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Function ObtenerFilasSeleccionadas() As String
        Dim valores As New List(Of String)

        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In DtgListadoCerdos.Rows
            If row.Appearance.BackColor = Color.LightBlue Then
                If Not IsDBNull(row.Cells(0).Value) AndAlso Not String.IsNullOrEmpty(row.Cells(0).Text.Trim()) Then
                    valores.Add(row.Cells(0).Value.ToString())
                End If
            End If
        Next

        Return String.Join(",", valores)
    End Function

    Private Sub DtgListadoCerdos_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles DtgListadoCerdos.DoubleClickCell
        Dim row As Infragistics.Win.UltraWinGrid.UltraGridRow = e.Cell.Row
        Dim tieneValor As Boolean = False

        For Each cell As Infragistics.Win.UltraWinGrid.UltraGridCell In row.Cells
            If Not IsDBNull(cell.Value) AndAlso Not String.IsNullOrEmpty(cell.Text.Trim()) Then
                tieneValor = True
                Exit For
            End If
        Next

        If Not tieneValor Then Return

        If row.Appearance.BackColor = Color.LightBlue Then
            row.Appearance.BackColor = Color.White
        Else
            row.Appearance.BackColor = Color.LightBlue
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

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class