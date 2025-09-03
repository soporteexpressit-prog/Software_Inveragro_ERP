Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmPrimerFiltroCerda
    Dim cn As New cnControlLoteDestete
    Private DtDetalle As New DataTable("TempDetFiltro")
    Public DtDetallePura As New DataTable("TempDetFiltroPura")
    Dim idMotivo As Integer = 0
    Dim idCerda As Integer = 0
    Dim tatuajeCamborough As String = ""
    Public idLote As Integer = 0
    Public valorLote As String = ""
    Public valorPlantel As String = ""
    Public idPlantel As Integer = 0
    Public numFiltroDescarte As Integer = 0
    Public SelectedPuras As New HashSet(Of Integer)

    Private Sub FrmPrimerFiltroCerda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            CargarTablaDetalleFiltro()
            CargarTablaDetalleFiltroPura()
            ConsultarPurasChanchillasRetorno()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        LblLote.Text = valorLote
        LblPlantel.Text = valorPlantel
        TextPuras.ReadOnly = True
        TextChanchillas.ReadOnly = True
        TxtMotivo.ReadOnly = True
        TxtCodArete.ReadOnly = True
        CmbTipoCerda.SelectedIndex = 0
        DtpFechaDepuracion.Value = Now.Date
        clsBasicas.Formato_Tablas_Grid(DtgListado)
        OcultarCamposSegunTipoCerda()
    End Sub

    Sub ConsultarPurasChanchillasRetorno()
        Try
            Dim obj As New coControlLoteDestete With {
                .IdLote = idLote,
                .IdPlantel = idPlantel,
                .NumDepuracion = numFiltroDescarte
            }
            Dim dt As New DataTable
            dt = cn.Cn_ConsultarAnimalesRetornarxLote(obj).Copy
            If (dt.Rows.Count > 0) Then
                TextPuras.Text = dt.Rows(0)("CantPura").ToString()
                TextChanchillas.Text = dt.Rows(0)("CantCamborough").ToString()
                tatuajeCamborough = dt.Rows(0)("tatuajeCambor").ToString()
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Public Sub LlenarCampoMotivo(id As String, motivo As String)
        idMotivo = id
        TxtMotivo.Text = motivo
    End Sub

    Private Sub BtnMotivoMortalidad_Click(sender As Object, e As EventArgs) Handles BtnMotivoMortalidad.Click
        Dim frm As New FrmListarMotivoDescarteMadreFutura(Me)
        frm.ShowDialog()
    End Sub

    Sub CargarTablaDetalleFiltro()
        DtDetalle = New DataTable("TempDetFiltro")
        DtDetalle.Columns.Add("idCerda", GetType(Integer))
        DtDetalle.Columns.Add("idMotivo", GetType(Integer))
        DtDetalle.Columns.Add("codArete", GetType(String))
        DtDetalle.Columns.Add("motivo", GetType(String))
        DtDetalle.Columns.Add("cantidad", GetType(Integer))
        DtDetalle.Columns.Add("tipo", GetType(String))
        DtDetalle.Columns.Add("nota", GetType(String))
        DtDetalle.Columns.Add("btneliminar", GetType(String))
        DtgListado.DataSource = DtDetalle
    End Sub

    Sub CargarTablaDetalleFiltroPura()
        DtDetallePura = New DataTable("TempDetFiltroPura")
        DtDetallePura.Columns.Add("idCerda", GetType(Integer))
        DtDetallePura.Columns.Add("codArete", GetType(String))
        DtgListadoPuras.DataSource = DtDetallePura
    End Sub

    Private Sub DtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles DtgListado.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(0).Hidden = True
                .Columns(1).Hidden = True
                .Columns(2).Header.Caption = "Tatuaje"
                .Columns(2).Width = 100
                .Columns(3).Header.Caption = "Motivo"
                .Columns(3).Width = 100
                .Columns(4).Header.Caption = "Cantidad"
                .Columns(4).Width = 65
                .Columns(5).Header.Caption = "Tipo"
                .Columns(5).Width = 90
                .Columns(6).Header.Caption = "Nota"
                .Columns(6).Width = 150
                .Columns(7).Header.Caption = "Eliminar"
                .Columns(7).Width = 60
                .Columns(7).Style = UltraWinGrid.ColumnStyle.Button
                .Columns(7).CellButtonAppearance.Image = My.Resources.ico_eliminar
                .Columns(7).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnAgregar_Click(sender As Object, e As EventArgs) Handles BtnAgregar.Click
        Try
            Dim cantPuras As Integer = 0
            Dim cantChanchillas As Integer = 0

            For i = 0 To DtgListado.Rows.Count - 1
                If (DtgListado.Rows(i).Cells(5).Value.ToString = "PURAS") Then
                    cantPuras = cantPuras + CInt(DtgListado.Rows(i).Cells("cantidad").Value)
                Else
                    cantChanchillas = cantChanchillas + CInt(DtgListado.Rows(i).Cells("cantidad").Value)
                End If
            Next

            If CmbTipoCerda.Text = "PURAS" And DtDetallePura.Rows.Count = 0 Then
                msj_advert("No ha seleccionado ninguna cerda pura")
                Return
            End If

            If (idMotivo = 0) Then
                msj_advert("Ingrese el Motivo")
                Return
            End If

            If String.IsNullOrEmpty(TxtNota.Text) Then
                msj_advert("Ingrese una Nota")
                Return
            End If

            If CmbTipoCerda.Text = "PURAS" Then
                cantPuras = cantPuras + DtDetallePura.Rows.Count
                If cantPuras > CInt(TextPuras.Text) Then
                    msj_advert("La cantidad de puras supera el total disponible")
                    Return
                End If

                For Each filaCerda As DataRow In DtDetallePura.Rows
                    Dim idCerdaPura As Integer = CInt(filaCerda("idCerda"))
                    Dim codAretePura As String = filaCerda("codArete").ToString()

                    Dim existeProducto = DtDetalle.Select("idCerda = " & idCerdaPura)
                    If existeProducto.Length > 0 Then
                        msj_advert("La cerda con código " & codAretePura & " ya fue registrada")
                        Continue For
                    End If

                    Dim dr As DataRow = DtDetalle.NewRow
                    dr(0) = idCerdaPura
                    dr(1) = idMotivo
                    dr(2) = codAretePura
                    dr(3) = TxtMotivo.Text
                    dr(4) = 1
                    dr(5) = "PURAS"
                    dr(6) = TxtNota.Text
                    DtDetalle.Rows.Add(dr)
                Next

                DtDetalle.AcceptChanges()
                DtgListado.DataSource = DtDetalle
                DtgListado.DataBind()

                LimpiarCamposCerdasDescarte()
                SelectedPuras.Clear()
                DtDetallePura.Clear()
                DtgListadoPuras.DataSource = DtDetallePura
                DtgListadoPuras.DataBind()

            Else
                cantChanchillas = cantChanchillas + CInt(NumCantidad.Value)

                If cantChanchillas > CInt(TextChanchillas.Text) Then
                    msj_advert("La cantidad de CAMBOROUGH supera el total disponible")
                    Return
                End If

                If NumCantidad.Value <= 0 Then
                    msj_advert("Ingrese una Cantidad")
                    Return
                ElseIf idMotivo = 0 Then
                    msj_advert("Ingrese el Motivo")
                    Return
                Else
                    Dim dr As DataRow = DtDetalle.NewRow
                    dr(0) = idCerda
                    dr(1) = idMotivo
                    dr(2) = tatuajeCamborough
                    dr(3) = TxtMotivo.Text
                    dr(4) = NumCantidad.Value
                    dr(5) = "CAMBOROUGH"
                    dr(6) = TxtNota.Text
                    DtDetalle.Rows.Add(dr)

                    DtDetalle.AcceptChanges()
                    DtgListado.DataSource = DtDetalle
                    DtgListado.DataBind()

                    LimpiarCamposCerdasDescarte()
                End If
            End If
            LblNumRegistros.Text = DtgListado.Rows.Count.ToString()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub LimpiarCamposCerdasDescarte()
        idMotivo = 0
        idCerda = 0
        TxtMotivo.Text = ""
        TxtCodArete.Text = ""
        NumCantidad.Value = 0
        TxtNota.Text = "NINGUNA"
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            If (DtpFechaDepuracion.Value > Now.Date) Then
                msj_advert("La fecha de depuración no puede ser mayor a la fecha actual")
                Return
            End If

            If (DtgListado.Rows.Count = 0) Then
                msj_advert("Ingrese al menos un registro")
                Return
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE REGISTRAR DEPURACIÓN DE ESTAS CERDAS?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coControlLoteDestete With {
                .IdLote = idLote,
                .ListaCerdoDescarte = ArrayCerdasDescarte(),
                .IdPlantel = idPlantel,
                .IdUsuario = VP_IdUser,
                .NumDepuracion = numFiltroDescarte,
                .FechaControl = DtpFechaDepuracion.Value
            }

            Dim mensaje As String = cn.Cn_RegistrarControlDescarteMadreFutura(obj)
            If (obj.Coderror = 0) Then
                msj_ok(mensaje)
                Dispose()
            Else
                msj_advert(mensaje)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Function ArrayCerdasDescarte() As String
        Dim array_valvulas As String = ""
        If (DtgListado.Rows.Count = 0) Then
            array_valvulas = "0"
        Else
            For i = 0 To DtgListado.Rows.Count - 1
                If (DtgListado.Rows(i).Cells("idCerda").Value.ToString.Trim.Length <> 0) Then
                    With DtgListado.Rows(i)
                        array_valvulas = array_valvulas & .Cells("idCerda").Value.ToString.Trim & "+" &
                            .Cells("cantidad").Value.ToString.Trim & "+" &
                            .Cells("idMotivo").Value.ToString.Trim & "+" &
                            .Cells("nota").Value.ToString.Trim & ","
                    End With
                End If
            Next
            array_valvulas = array_valvulas.Substring(0, array_valvulas.Length - 1)
        End If
        Return array_valvulas
    End Function

    Private Sub CmbTipoCerda_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbTipoCerda.SelectedIndexChanged
        OcultarCamposSegunTipoCerda()
    End Sub

    Private Sub OcultarCamposSegunTipoCerda()
        If CmbTipoCerda.Text = "CAMBOROUGH" Then
            BtnCerdaCodificada.Visible = False
            LblCodArete.Visible = False
            TxtCodArete.Visible = False
            LblCantidadChanchillas.Visible = True
            NumCantidad.Visible = True
        Else
            LblCantidadChanchillas.Visible = False
            NumCantidad.Visible = False
            BtnCerdaCodificada.Visible = True
            LblCodArete.Visible = True
            TxtCodArete.Visible = True
        End If
    End Sub

    Public Sub LlenarCamposCerda(idAnimal As Integer, codArete As String)
        idCerda = idAnimal
        TxtCodArete.Text = codArete
    End Sub

    Private Sub BtnCerdaCodificada_Click(sender As Object, e As EventArgs) Handles BtnCerdaCodificada.Click
        Try
            Dim frm As New FrmListarCerdasCodificadasxLote(Me) With {
                .idLote = idLote,
                .idPlantel = idPlantel,
                .numDepuracion = numFiltroDescarte
            }
            frm.ShowDialog()

            If DtgListadoPuras.Rows.Count > 0 Then
                If DtgListadoPuras.Rows.Count = 1 Then
                    TxtCodArete.Text = DtgListadoPuras.Rows(0).Cells(1).Value.ToString()
                Else
                    TxtCodArete.Text = DtgListadoPuras.Rows(0).Cells(1).Value.ToString() + "..."
                End If
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub NumCantidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles NumCantidad.KeyPress
        clsBasicas.ValidarNumeros(e)
    End Sub

    Private Sub DtgListado_ClickCellButton(sender As Object, e As UltraWinGrid.CellEventArgs) Handles DtgListado.ClickCellButton
        If e.Cell.Column.Key = "btneliminar" Then
            Dim result As DialogResult = MessageBox.Show("¿ESTÁ SEGURO DE ELIMINAR ESTE REGISTRO?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                Dim rowIndex As Integer = e.Cell.Row.Index
                DtDetalle.Rows.RemoveAt(rowIndex)
                DtDetalle.AcceptChanges()
                DtgListado.DataSource = DtDetalle
                LblNumRegistros.Text = DtgListado.Rows.Count.ToString()
            End If
        End If
    End Sub

    Private Sub BtnInformacionPuras_Click(sender As Object, e As EventArgs) Handles BtnInformacionPuras.Click
        Dim codigos As String = String.Join(" / ", DtDetallePura.AsEnumerable().Select(Function(row) row.Field(Of String)("codArete")))
        If String.IsNullOrEmpty(codigos) Then
            msj_advert("No hay cerdas puras seleccionadas.")
            Return
        End If
        MessageBox.Show("CERDAS SELECCIONADAS: " & codigos, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub TxtNota_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtNota.KeyPress
        If e.KeyChar = "+"c Or e.KeyChar = ","c Then
            e.Handled = True
        End If
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class