Imports System.ComponentModel
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmRegistrarTratamientoCerdo
    Dim cn As New cnControlMedico
    Dim cnUnidadMedida As New cnUnidadMedida
    Dim codMedicacion As Integer = 0
    Dim codEnfermedad As Integer = 0
    Public DtDetalleCerdosLotes As New DataTable("TempDetCerdosLotes")
    Public idPlantel As Integer = 0
    Public idCerdo As Integer = 0
    Dim unidadMinima As String = ""

    Private Sub FrmRegistrarTratamientoMedicacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ListarAreas()
            CargarTablaDetalleCerdoLote()
            Inicializar()
            If idPlantel = 1 Or idPlantel = 2 Then
                RtnIndividual.Visible = True
            Else
                RtnIndividual.Visible = False
            End If
            CbxIndividual.Visible = False
            ListarUnidadesMedida(CmbVia.Text)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ListarGalpones(idplantel As Integer)
        Dim cn As New cnGalpon
        Dim tb As New DataTable
        Dim obj As New coGalpon With {
            .IdUbicacion = idplantel,
            .IdArea = cmbArea.Value
        }
        tb = cn.Cn_ListarGalponesXPlantelArea(obj).Copy
        If tb.Rows.Count = 0 Then
            Dim newRow As DataRow = tb.NewRow()
            newRow(0) = 0
            newRow(1) = "NO HAY GALPONES REGISTRADOS"
            tb.Rows.Add(newRow)
        End If
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione un Galpón"
        With cmbGalpon
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Private Sub Inicializar()
        clsBasicas.LlenarComboAnios(CmbAnios)
        NumLote.Value = clsBasicas.ObtenerNumeroSemanaFecha(DateTime.Now)
        dtpFechaMedicacion.Value = Now.Date
        TxtMedicamento.ReadOnly = True
        TxtEnfermedad.ReadOnly = True
        TxtArete.ReadOnly = True
        CmbVia.SelectedIndex = 0
        RtnGalpon.Checked = True
    End Sub

    Sub ListarAreas()
        Dim cn As New cnArea
        Dim tb As New DataTable
        tb = cn.Cn_Listar().Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione una Área"
        With cmbArea
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Sub ListarUnidadesMedida(tipo As String)
        Dim cn As New cnArea
        Dim tb As New DataTable
        tb = cnUnidadMedida.Cn_ConsultarUnidadMedidaSanidad(tipo).Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione una Área"
        With cbUnidadMedida
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Private Sub RtnGalpon_CheckedChanged(sender As Object, e As EventArgs) Handles RtnGalpon.CheckedChanged
        If RtnGalpon.Checked Then
            clsBasicas.Formato_Tablas_Grid_AntePenultimaColumnaEditable(DtgListadoCerdoLote)
            CambiarEncabezadoColumnas("GALPON")
            LimpiarTablaCerdosLotes()
            OcultarCampoGalpon()
            LblEdad.Visible = False
            LblEdadCerda.Visible = False
        ElseIf RtnIndividual.Checked Then
            clsBasicas.Formato_Tablas_Grid(DtgListadoCerdoLote)
            CambiarEncabezadoColumnas("INDIVIDUAL")
            LimpiarTablaCerdosLotes()
            MostrarCampoGalpon()
            LblEdad.Visible = True
            LblEdadCerda.Visible = True
        End If
    End Sub

    Sub CargarTablaDetalleCerdoLote()
        DtDetalleCerdosLotes = New DataTable("TempDetCerdosLotes")
        DtDetalleCerdosLotes.Columns.Add("codLote", GetType(Integer))
        DtDetalleCerdosLotes.Columns.Add("lote", GetType(String))
        DtDetalleCerdosLotes.Columns.Add("edad", GetType(Integer))
        DtDetalleCerdosLotes.Columns.Add("numAnimales", GetType(Integer))
        DtDetalleCerdosLotes.Columns.Add("cantidad", GetType(String))
        DtDetalleCerdosLotes.Columns.Add("btneliminar", GetType(String))
        DtgListadoCerdoLote.DataSource = DtDetalleCerdosLotes
    End Sub

    Private Sub DtgListadoCerdoLote_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles DtgListadoCerdoLote.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(0).Hidden = True
                .Columns(1).Header.Caption = "Lote"
                .Columns(2).Header.Caption = "Edad"
                .Columns(3).Header.Caption = "N° Animales"
                .Columns(4).Header.Caption = "N° Afectados"
                .Columns(5).Header.Caption = "Eliminar"
                .Columns(5).Width = 70
                .Columns(5).Style = UltraWinGrid.ColumnStyle.Button
                .Columns(5).CellButtonAppearance.Image = My.Resources.ico_eliminar
                .Columns(5).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub DtgListadoCerdoLote_ClickCellButton(sender As Object, e As UltraWinGrid.CellEventArgs) Handles DtgListadoCerdoLote.ClickCellButton
        If e.Cell.Column.Key = "btneliminar" Then
            Dim result As DialogResult = MessageBox.Show("¿Está seguro de que desea eliminar cerdo/lote/galpón?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                Dim rowIndex As Integer = e.Cell.Row.Index
                Dim codParticipante As Integer = CInt(DtgListadoCerdoLote.Rows(rowIndex).Cells(0).Value)

                DtDetalleCerdosLotes.Rows.RemoveAt(rowIndex)
                DtDetalleCerdosLotes.AcceptChanges()
                DtgListadoCerdoLote.DataSource = DtDetalleCerdosLotes
                LblTotalAnimales.Text = SumarTotalAnimales().ToString("N0")
            End If
        End If
    End Sub

    Public Sub LlenarCamposMedicamentoRacion(codigo As Integer, descripcion As String, um As String)
        codMedicacion = codigo
        TxtMedicamento.Text = descripcion
        unidadMinima = um
    End Sub

    Public Sub LlenarCamposEnfermedad(codigo As Integer, descripcion As String)
        codEnfermedad = codigo
        TxtEnfermedad.Text = descripcion
    End Sub

    Private Sub BtnAgregarMedicamento_Click(sender As Object, e As EventArgs) Handles BtnAgregarMedicamento.Click
        Try
            Dim f As New FrmListarMedicacionTratamiento(Me) With {
                .idPlantel = idPlantel
            }
            f.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub LimpiarCamposMedicamentoRacion()
        codMedicacion = 0
        TxtMedicamento.Text = ""
        TxtEnfermedad.Text = ""
        codEnfermedad = 0
    End Sub

    Private Sub LimpiarTablaCerdosLotes()
        DtDetalleCerdosLotes.Clear()
        DtDetalleCerdosLotes.AcceptChanges()
        DtgListadoCerdoLote.DataSource = DtDetalleCerdosLotes
    End Sub

    Private Sub BtnBuscarEnfermedad_Click(sender As Object, e As EventArgs) Handles BtnBuscarEnfermedad.Click
        Try
            Dim f As New FrmListarEnfermedadTratamiento(Me)
            f.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Public Sub LlenarCamposCerdo(codigo As Integer, descripcion As String, edad As Integer)
        idCerdo = codigo
        TxtArete.Text = descripcion
        LblEdadCerda.Text = edad.ToString()
    End Sub

    Private Sub BtnAgregarCerdosLotes_Click(sender As Object, e As EventArgs) Handles BtnAgregarCerdosLotes.Click
        Try
            If RtnIndividual.Checked Then
                Dim f As New FrmListarCerdosxPlantel(Me) With {
                    .idPlantel = idPlantel,
                    .idArea = cmbArea.Value
                }
                f.ShowDialog()
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub CambiarEncabezadoColumnas(opcion As String)
        Try
            With DtgListadoCerdoLote
                Select Case opcion
                    Case "INDIVIDUAL"
                        .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Arete"
                        .DisplayLayout.Bands(0).Columns(5).Header.Caption = "Eliminar"
                    Case "GALPON"
                        .DisplayLayout.Bands(0).Columns(2).Header.Caption = "Lote"
                        .DisplayLayout.Bands(0).Columns(5).Header.Caption = "Eliminar"
                End Select
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub


    Private Sub TxtCantidad_KeyPress(sender As Object, e As KeyPressEventArgs)
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            DtgListadoCerdoLote.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode)
            Dim intervalo As (Date, Date) = clsBasicas.ObtenerIntervaloSemana(CInt(CmbAnios.Text), NumLote.Value)
            Dim fechaInicio As Date = intervalo.Item1
            Dim fechaFin As Date = intervalo.Item2
            Dim totalAnimales As Integer = 0

            If dtpFechaMedicacion.Value > Now.Date Then
                msj_advert("La fecha no puede ser mayor a la fecha actual")
                Return
            End If

            If DiasTratamiento.Value < 1 Then
                msj_advert("Los días de tratamiento no pueden ser menor a 1")
                Return
            End If

            If codMedicacion = 0 Then
                msj_advert("Seleccione un Medicamento")
                Return
            End If

            If codEnfermedad = 0 Then
                msj_advert("Seleccione una Enfermedad")
                Return
            End If

            If cbUnidadMedida.Value Is Nothing OrElse cbUnidadMedida.Value = 0 Then
                msj_advert("Seleccione una unidad de medida")
                Return
            End If

            If txtCantidadOrigen.Text.Trim.Length = 0 Then
                msj_advert("La cantidad no puede estar vacía")
                Return
            End If

            If CInt(txtCantidadOrigen.Text.Trim()) <= 0 Then
                msj_advert("La cantidad debe ser mayor a cero")
                Return
            End If

            If TxtDosis.Text.Trim.Length = 0 Then
                msj_advert("Ingrese la dosis")
                Return
            ElseIf CInt(TxtDosis.Text) <= 0 Then
                msj_advert("La dosis no puede ser menor o igual a 0")
                Return
            End If

            If TxtCantDiaria.Text.Trim.Length = 0 Then
                msj_advert("Ingrese la cantidad diaria")
                Return
            ElseIf CInt(TxtCantDiaria.Text) <= 0 Then
                msj_advert("La cantidad diaria no puede ser menor o igual a 0")
                Return
            End If

            For i = 0 To DtgListadoCerdoLote.Rows.Count - 1
                If CInt(DtgListadoCerdoLote.Rows(i).Cells("cantidad").Value) > 0 Then
                    totalAnimales += CInt(DtgListadoCerdoLote.Rows(i).Cells("cantidad").Value)
                End If
            Next

            If cmbArea.Value = 2 And Not CbxIndividual.Checked Then
                If CbxAplicacionParcial.Checked Then
                    If NumTratados.Value = 0 Then
                        msj_advert("Número de tratados no válido")
                        Return
                    End If
                End If

                RtnIndividual.Checked = False
            Else
                If DtDetalleCerdosLotes.Rows.Count = 0 Then
                    msj_advert("Debe agregar al menos un registro")
                    Return
                End If

                If RtnGalpon.Checked Then
                    For i = 0 To DtgListadoCerdoLote.Rows.Count - 1
                        If CInt(DtgListadoCerdoLote.Rows(i).Cells("cantidad").Value) <= 0 Then
                            msj_advert("La cantidad de afectados no puede ser menor o igual a 0")
                            Return
                        End If
                    Next
                End If

                If RtnGalpon.Checked Then
                    For i = 0 To DtgListadoCerdoLote.Rows.Count - 1
                        Dim cantidad As Integer = CInt(DtgListadoCerdoLote.Rows(i).Cells("cantidad").Value)
                        Dim numAnimales As Integer = CInt(DtgListadoCerdoLote.Rows(i).Cells("numAnimales").Value)

                        If cantidad > numAnimales Then
                            msj_advert("La cantidad de afectados no puede ser mayor a la cantidad de animales en el lote")
                            Return
                        End If
                    Next
                End If
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE REGISTRAR MEDICACIÓN O TRATAMIENTO?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coControlMedico With {
                .ModoAplicacion = If(RtnIndividual.Checked, "INDIVIDUAL", "LOTE"),
                .FechaControl = dtpFechaMedicacion.Value,
                .Observacion = TxtObservacion.Text,
                .ListaDestinadoCerdoLote = CreacionStringDestinadoCerdoLote(),
                .IdUsuario = VP_IdUser,
                .IdGalpon = If(RtnIndividual.Checked, 0, cmbGalpon.Value),
                .IdPlantel = idPlantel,
                .Duracion = DiasTratamiento.Value,
                .IdMedicamento = codMedicacion,
                .IdEnfermedad = codEnfermedad,
                .Dosis = CDec(TxtDosis.Text),
                .CantDiaria = CDec(TxtCantDiaria.Text),
                .Via = CmbVia.Text,
                .CantAnimales = totalAnimales,
                .IdConversion = cbUnidadMedida.Value,
                .CantidadOrigen = CInt(txtCantidadOrigen.Text.Trim()),
                .IdArea = cmbArea.Value,
                .NumSemana = If(cmbArea.Value = 2 And Not CbxIndividual.Checked, NumLote.Value, 0),
                .FechaInicio = If(cmbArea.Value = 2 And Not CbxIndividual.Checked, fechaInicio, dtpFechaMedicacion.Value),
                .FechaFin = If(cmbArea.Value = 2 And Not CbxIndividual.Checked, fechaFin, dtpFechaMedicacion.Value),
                .Afectados = NumTratados.Value,
                .MlAnimal = If(String.IsNullOrWhiteSpace(TxtMlAnimal.Text), 0, CDec(TxtMlAnimal.Text)),
                .GestacionIndividual = If(cmbArea.Value = 2 And CbxIndividual.Checked, 1, 0)
            }

            Dim _mensaje As String = cn.Cn_RegistrarTratamiento(obj)
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

    Function CreacionStringDestinadoCerdoLote() As String
        Dim array_valvulas As String = ""
        If (DtgListadoCerdoLote.Rows.Count = 0) Then
            array_valvulas = "0"
        Else
            For i = 0 To DtgListadoCerdoLote.Rows.Count - 1
                If (DtgListadoCerdoLote.Rows(i).Cells(0).Value.ToString.Trim.Length <> 0) Then
                    With DtgListadoCerdoLote.Rows(i)
                        array_valvulas = array_valvulas & .Cells("codLote").Value.ToString.Trim & "+" &
                            .Cells("cantidad").Value.ToString.Trim & ","
                    End With
                End If
            Next

            array_valvulas = array_valvulas.Substring(0, array_valvulas.Length - 1)
        End If
        Return array_valvulas
    End Function

    Private Sub btnMedicamendoRecomendado_Click(sender As Object, e As EventArgs) Handles btnMedicamendoRecomendado.Click
        Try
            If codEnfermedad = 0 Then
                msj_advert("Seleccione una Enfermedad")
                Return
            Else
                Dim f As New FrmListarMedicamentoRecomendadoT(Me) With {
                    .idEnfermedad = codEnfermedad,
                    .IdPlantel = idPlantel
                }
                f.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnAgregarCerdo_Click(sender As Object, e As EventArgs) Handles BtnAgregarCerdo.Click
        Try
            If idCerdo = 0 Then
                msj_advert("Seleccione un Animal")
                Return
            Else
                Dim existeProducto = DtDetalleCerdosLotes.Select("codLote = " & idCerdo)
                If existeProducto.Length > 0 Then
                    msj_advert("El animal ya existe en la lista")
                    Return
                End If

                Dim dr As DataRow = DtDetalleCerdosLotes.NewRow
                dr(0) = idCerdo
                dr(1) = TxtArete.Text
                dr(2) = LblEdadCerda.Text
                dr(3) = 1
                dr(4) = 1
                DtDetalleCerdosLotes.Rows.Add(dr)
                DtDetalleCerdosLotes.AcceptChanges()
                DtgListadoCerdoLote.DataSource = DtDetalleCerdosLotes
                DtgListadoCerdoLote.DataBind()

                LimpiarCampoCerdo()
                LblTotalAnimales.Text = SumarTotalAnimales().ToString("N0")
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub LimpiarCampoCerdo()
        idCerdo = 0
        TxtArete.Text = ""
        LblEdadCerda.Text = "0"
    End Sub

    Private Sub OcultarCampoGalpon()
        BtnAgregarCerdosLotes.Visible = False
        TxtArete.Visible = False
        LblArete.Visible = False
        BtnAgregarCerdo.Visible = False
        LblGalpon.Visible = True
        cmbGalpon.Visible = True
    End Sub

    Private Sub MostrarCampoGalpon()
        BtnAgregarCerdosLotes.Visible = True
        TxtArete.Visible = True
        LblArete.Visible = True
        BtnAgregarCerdo.Visible = True
        LblGalpon.Visible = False
        cmbGalpon.Visible = False
    End Sub

    Private Function SumarTotalAnimales() As Integer
        Dim total As Integer = 0

        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In DtgListadoCerdoLote.Rows
            If row.Cells("cantidad").Value IsNot Nothing AndAlso IsNumeric(row.Cells("cantidad").Value) Then
                total += CInt(row.Cells("cantidad").Value)
            End If
        Next
        Return total
    End Function

    Private Sub cmbGalpon_ValueChanged(sender As Object, e As EventArgs) Handles cmbGalpon.ValueChanged
        Try
            CargarTablaDetalleCerdoLote()
            LimpiarTablaCerdosLotes()

            Dim obj As New coGalpon
            Dim cn As New cnGalpon
            obj.Codigo = cmbGalpon.Value

            Dim dtResultado As DataTable = cn.Cn_ConsLotesxGalpon(obj).Copy

            For Each filaOrigen As DataRow In dtResultado.Rows
                Dim dr As DataRow = DtDetalleCerdosLotes.NewRow

                dr(0) = filaOrigen("idLote")
                dr(1) = filaOrigen("Lote")
                dr(2) = filaOrigen("Edad")
                dr(3) = filaOrigen("NumAnimales")
                dr(4) = 0

                DtDetalleCerdosLotes.Rows.Add(dr)
            Next

            DtDetalleCerdosLotes.AcceptChanges()
            DtgListadoCerdoLote.DataSource = DtDetalleCerdosLotes
            DtgListadoCerdoLote.DataBind()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub DtgListadoCerdoLote_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DtgListadoCerdoLote.KeyPress
        If DtgListadoCerdoLote.ActiveCell IsNot Nothing AndAlso DtgListadoCerdoLote.ActiveCell.Column.Key = "cantidad" Then
            Dim pressedKey As Char = e.KeyChar

            If Not (Char.IsDigit(pressedKey) OrElse Char.IsControl(pressedKey)) Then
                e.Handled = True
                Exit Sub
            End If

            If Char.IsDigit(pressedKey) Then
                Dim activeText As String = DtgListadoCerdoLote.ActiveCell.Text
                Dim newText As String = activeText & pressedKey

                Dim numero As Integer
                If Integer.TryParse(newText, numero) Then
                    If numero > 2000 Then
                        e.Handled = True
                        Exit Sub
                    End If
                End If
            End If

            e.Handled = False
        End If
    End Sub

    Private Sub TxtNota_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = "+"c Or e.KeyChar = ","c Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtDosis_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDosis.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub TxtCantDiaria_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCantDiaria.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub TxtCantDiaria_TextChanged(sender As Object, e As EventArgs) Handles TxtCantDiaria.TextChanged
        If TxtCantDiaria.Text.Trim.Length > 0 Then
            If CDec(TxtCantDiaria.Text) > 0 Then
                txtCantidadOrigen.Text = CDec(TxtCantDiaria.Text) * DiasTratamiento.Value
            End If
        End If
    End Sub

    Private Sub DiasTratamiento_ValueChanged(sender As Object, e As EventArgs) Handles DiasTratamiento.ValueChanged
        If TxtCantDiaria.Text.Trim.Length > 0 Then
            If CDec(TxtCantDiaria.Text) > 0 Then
                txtCantidadOrigen.Text = CDec(TxtCantDiaria.Text) * DiasTratamiento.Value
            End If
        End If
    End Sub

    Private Sub NumLote_ValueChanged(sender As Object, e As EventArgs) Handles NumLote.ValueChanged
        If CmbAnios.Text = "" Or NumLote.Value = 0 Then
            LblPeriodo.Text = ""
            Return
        End If

        Dim intervalo As (Date, Date) = clsBasicas.ObtenerIntervaloSemana(CmbAnios.Text, NumLote.Value)
        LblPeriodo.Text = clsBasicas.ObtenerPeriodoDeSemana(CmbAnios.Text, NumLote.Value)
        LblLoteGestacion.Text = "Lote " & (NumLote.Value + 17).ToString()
    End Sub

    Private Sub cmbArea_TextChanged(sender As Object, e As EventArgs) Handles cmbArea.TextChanged
        If cmbArea.Value IsNot Nothing Then
            If CbxIndividual.Checked And cmbArea.Value <> 2 Then
                msj_advert("Desactive el check de individual")
                cmbArea.Value = 2
                Return
            End If

            CargarTablaDetalleCerdoLote()
            LimpiarTablaCerdosLotes()

            If Not RtnIndividual.Checked Then
                ListarGalpones(idPlantel)
            End If

            If cmbArea.Value = 2 Then
                GrupoBtnAplicacion.Visible = False
                LblAplicacion.Visible = False
                LblAnio.Visible = True
                CmbAnios.Visible = True
                LblSemana.Visible = True
                NumLote.Visible = True
                LblLoteGestacion.Visible = True
                LblPeriodo.Visible = True
                GrupoDestino.Visible = False
                CbxAplicacionParcial.Visible = True
                CbxAplicacionParcial.Checked = False
                Me.Size = New Size(575, 500)
                CbxIndividual.Visible = True
            Else
                GrupoBtnAplicacion.Visible = True
                LblAplicacion.Visible = True
                LblAnio.Visible = False
                CmbAnios.Visible = False
                LblSemana.Visible = False
                NumLote.Visible = False
                LblLoteGestacion.Visible = False
                LblPeriodo.Visible = False
                GrupoDestino.Visible = True
                CbxAplicacionParcial.Visible = False
                LblTratados.Visible = False
                NumTratados.Visible = False
                CbxIndividual.Visible = False
                CbxIndividual.Checked = False
                Me.Size = New Size(575, 700)
            End If
        End If
    End Sub

    Private Sub CbxAplicacionParcial_CheckedChanged(sender As Object, e As EventArgs) Handles CbxAplicacionParcial.CheckedChanged
        If CbxAplicacionParcial.Checked Then
            LblTratados.Visible = True
            NumTratados.Visible = True
        Else
            LblTratados.Visible = False
            NumTratados.Visible = False
        End If
    End Sub

    Private Sub CmbVia_TextChanged(sender As Object, e As EventArgs) Handles CmbVia.TextChanged
        If CmbVia.Text = "AGUA" Then
            LabelDosis.Text = "Dosis mg/pv :"
        Else
            LabelDosis.Text = "Dosis ml/pv :"
        End If
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtMlAnimal.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub CmbVia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbVia.SelectedIndexChanged
        If String.IsNullOrWhiteSpace(CmbVia.Text) Then
            Return
        End If
        ListarUnidadesMedida(CmbVia.Text)
    End Sub


    Private Sub Editor_KeyUp(sender As Object, e As KeyEventArgs)
        Try
            ' Actualizar el total mientras escribe
            LblTotalAnimales.Text = SumarTotalAnimales().ToString("N0")
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub DtgListadoCerdoLote_AfterCellUpdate(sender As Object, e As UltraWinGrid.CellEventArgs) Handles DtgListadoCerdoLote.AfterCellUpdate
        Try
            LblTotalAnimales.Text = SumarTotalAnimales().ToString("N0")
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub CbxIndividual_CheckedChanged(sender As Object, e As EventArgs) Handles CbxIndividual.CheckedChanged
        If CbxIndividual.Checked Then
            GrupoBtnAplicacion.Visible = True
            LblAplicacion.Visible = True
            LblAnio.Visible = False
            CmbAnios.Visible = False
            LblSemana.Visible = False
            NumLote.Visible = False
            LblLoteGestacion.Visible = False
            LblPeriodo.Visible = False
            GrupoDestino.Visible = True
            CbxAplicacionParcial.Visible = False
            LblTratados.Visible = False
            NumTratados.Visible = False
            RtnIndividual.Checked = True
            GrupoBtnAplicacion.Visible = False
            LblAplicacion.Visible = False
            Me.Size = New Size(575, 700)
        Else
            GrupoBtnAplicacion.Visible = False
            LblAplicacion.Visible = False
            LblAnio.Visible = True
            CmbAnios.Visible = True
            LblSemana.Visible = True
            NumLote.Visible = True
            LblLoteGestacion.Visible = True
            LblPeriodo.Visible = True
            GrupoDestino.Visible = False
            CbxAplicacionParcial.Visible = True
            CbxAplicacionParcial.Checked = False
            Me.Size = New Size(575, 500)
        End If
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class