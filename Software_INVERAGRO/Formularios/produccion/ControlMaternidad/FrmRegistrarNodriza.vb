Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmRegistrarNodriza
    Private cn As New cnControlAnimal
    Dim idDonadora As Integer = 0
    Dim idLoteDonadora As Integer = 0
    Dim idLoteDonadoraSelected As Integer = 0
    Dim valorLoteDonadora As String = ""
    Dim idNodriza As Integer = 0
    Public idUbicacion As Integer = 0
    Public DtDetalle As New DataTable("TempDetDonadoras")
    Private CriasDonadas As String = ""
    Private IdsCriasDonadas As String = ""
    Private DonacionCerdaCriasDict As New Dictionary(Of Integer, String)

    Private Sub FrmRegistrarNodriza_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtUbicacion.ReadOnly = True
        TxtCodCerda.ReadOnly = True
        NumCriasDonar.ReadOnly = True
        CargarTablaDonadoras()
        clsBasicas.Formato_Tablas_Grid(dtgListado)
        Inicializar()
    End Sub

    Private Sub Inicializar()
        idNodriza = 0
        LblCodArete.Text = "-"
        TxtUbicacion.Text = ""
        LblTotalCrias.Text = "0"
        LblNumDonadoras.Text = "0"
        BtnCriasCerda.Enabled = False
        BtnBuscarCerdaDonante.Enabled = False
        RtnDejarVacia.Visible = False
        RtnSeguirLactando.Visible = False
        RtnDejarVacia.Checked = False
        RtnSeguirLactando.Checked = False
        DonacionCerdaCriasDict.Clear()
        ConsultarInicializarDiccionario()
    End Sub

    Private Sub ConsultarInicializarDiccionario()
        DtpFecha.Value = VariablesGlobales.ParametrosNodriza("fNodriza")
        DtpFecha.Enabled = If(VariablesGlobales.ParametrosNodriza("fNodrizaBloqueo") = 1, False, True)
    End Sub

    Public Sub LlenarCamposCerdaDonadora(id As Integer, codigo As String, idLoteDonadoraValue As Integer, valorLote As String)
        idDonadora = id
        TxtCodCerda.Text = codigo
        idLoteDonadoraSelected = idLoteDonadoraValue
        valorLoteDonadora = valorLote

        If dtgListado.Rows.Count = 0 Then
            idLoteDonadora = idLoteDonadoraValue
        End If
    End Sub

    Public Sub GuardarSeleccionCrias(selectedIdsCriasString As String, numeroTotalCrias As Integer, consultarVacia As String)
        CriasDonadas = selectedIdsCriasString
        NumCriasDonar.Text = numeroTotalCrias

        If consultarVacia = "SI" Then
            RtnDejarVacia.Visible = True
            RtnSeguirLactando.Visible = True
        End If
    End Sub

    Private Sub BtnBuscarCerdaDonante_Click(sender As Object, e As EventArgs) Handles BtnBuscarCerdaDonante.Click
        Try

            If idNodriza = 0 Then
                msj_advert("Seleccione una nodriza")
                Return
            End If

            LimpiarCamposCerdaDonadora()
            Dim frm As New FrmListarCerdaDonadora(Me) With {
                .idPlantel = idUbicacion,
                .idCodAreteNodriza = LblCodArete.Text
            }
            frm.ShowDialog()
            If idDonadora > 0 Then
                BtnCriasCerda.Enabled = True
            Else
                BtnCriasCerda.Enabled = False
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnCriasCerda_Click(sender As Object, e As EventArgs) Handles BtnCriasCerda.Click
        Try
            RtnDejarVacia.Visible = False
            RtnSeguirLactando.Visible = False
            RtnDejarVacia.Checked = False
            RtnSeguirLactando.Checked = False
            Dim frm As New FrmListarCriasDonante(Me) With {
                .idCerda = idDonadora
            }
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub CargarTablaDonadoras()
        DtDetalle = New DataTable("TempDetDonadoras")
        DtDetalle.Columns.Add("idAnimal", GetType(Integer))
        DtDetalle.Columns.Add("codArete", GetType(String))
        DtDetalle.Columns.Add("cantidad", GetType(String))
        DtDetalle.Columns.Add("esVacia", GetType(String))
        DtDetalle.Columns.Add("lote", GetType(String))
        DtDetalle.Columns.Add("btneliminar", GetType(String))
        dtgListado.DataSource = DtDetalle
    End Sub

    Private Sub dtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListado.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(0).Hidden = True
                .Columns(1).Header.Caption = "Código Arete"
                .Columns(2).Header.Caption = "Cantidad"
                .Columns(3).Header.Caption = "Es Vacía"
                .Columns(4).Header.Caption = "Lote"
                .Columns(5).Header.Caption = "Eliminar"
                .Columns(5).Style = UltraWinGrid.ColumnStyle.Button
                .Columns(5).CellButtonAppearance.Image = My.Resources.ico_eliminar
                .Columns(5).ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListado_ClickCellButton(sender As Object, e As UltraWinGrid.CellEventArgs) Handles dtgListado.ClickCellButton
        If e.Cell.Column.Key = "btneliminar" Then
            Dim result As DialogResult = MessageBox.Show("¿ESTÁ SEGURO QUE DESEA ELIMINAR A ESTA DONADORA?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Yes Then
                Dim rowIndex As Integer = e.Cell.Row.Index
                Dim idCerdaDonadora As Integer = CInt(dtgListado.Rows(rowIndex).Cells(0).Value)

                If DonacionCerdaCriasDict.ContainsKey(idCerdaDonadora) Then
                    DonacionCerdaCriasDict.Remove(idCerdaDonadora)
                End If

                DtDetalle.Rows.RemoveAt(rowIndex)
                DtDetalle.AcceptChanges()
                dtgListado.DataSource = DtDetalle
                dtgListado.DataBind()
                LblNumDonadoras.Text = DtDetalle.Rows.Count.ToString()
                LblTotalCrias.Text = DtDetalle.AsEnumerable().Sum(Function(row) Convert.ToInt32(row("cantidad"))).ToString()

                If dtgListado.Rows.Count = 0 Then
                    idLoteDonadora = 0
                End If
            End If
        End If
    End Sub

    Private Sub BtnAgregar_Click(sender As Object, e As EventArgs) Handles BtnAgregar.Click
        Try
            If (idDonadora = 0) Then
                msj_advert("Seleccione donadora")
                Return
            ElseIf (NumCriasDonar.Text.Length = 0) Then
                msj_advert("seleccione las crias a donar")
                Return
            ElseIf (CInt(NumCriasDonar.Text) = 0) Then
                msj_advert("seleccione las crias a donar")
                Return
            End If

            If idLoteDonadora <> 0 Then
                If idLoteDonadora <> idLoteDonadoraSelected Then
                    msj_advert("Todas las donadoras deben pertenecer al mismo lote")
                    Return
                End If
            End If

            Dim existeDonadora = DtDetalle.Select("idAnimal = " & idDonadora)
            If existeDonadora.Length > 0 Then
                msj_advert("la cerda donadora ya existe en la lista")
                Return
            End If

            If RtnDejarVacia.Visible AndAlso Not RtnDejarVacia.Checked AndAlso Not RtnSeguirLactando.Checked Then
                msj_advert("Debe seleccionar una opción para la cerda si se deja vacía o se sigue lactando.")
                Return
            End If

            GuardarDonacion()

            Dim dr As DataRow = DtDetalle.NewRow
            dr(0) = idDonadora
            dr(1) = TxtCodCerda.Text
            dr(2) = NumCriasDonar.Text
            dr(3) = If(RtnDejarVacia.Checked, "SI", "NO")
            dr(4) = valorLoteDonadora
            DtDetalle.Rows.Add(dr)
            DtDetalle.AcceptChanges()
            dtgListado.DataSource = DtDetalle
            dtgListado.DataBind()
            LblNumDonadoras.Text = DtDetalle.Rows.Count.ToString()
            LblTotalCrias.Text = DtDetalle.AsEnumerable().Sum(Function(row) Convert.ToInt32(row("cantidad"))).ToString()

            LimpiarCamposCerdaDonadora()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub LimpiarCamposCerdaDonadora()
        idDonadora = 0
        TxtCodCerda.Text = ""
        NumCriasDonar.Text = ""
        BtnCriasCerda.Enabled = False
        RtnDejarVacia.Visible = False
        RtnSeguirLactando.Visible = False
        RtnDejarVacia.Checked = False
        RtnSeguirLactando.Checked = False
    End Sub

    Private Sub GuardarDonacion()
        If DonacionCerdaCriasDict.ContainsKey(idDonadora) Then
            DonacionCerdaCriasDict(idDonadora) = CriasDonadas
        Else
            DonacionCerdaCriasDict.Add(idDonadora, CriasDonadas)
        End If
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            If DtpFecha.Value > Now.Date Then
                msj_advert("La fecha no puede ser mayor a la fecha actual")
                Return
            End If

            If idNodriza = 0 Then
                msj_advert("Seleccione nodriza")
                Return
            End If

            If DtDetalle.Rows.Count = 0 Then
                msj_advert("Ingrese al menos una donadora")
                Return
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE REGISTRAR NODRIZA?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim totalCriasDonar As Integer = 0
            For i = 0 To DtDetalle.Rows.Count - 1
                totalCriasDonar += Convert.ToInt32(DtDetalle.Rows(i)(2))
            Next

            Dim obj As New coControlAnimal With {
                .FechaControl = DtpFecha.Value,
                .Codigo = idNodriza,
                .ListaCerdasDonantes = CreacionArrayDonanteCantidad(),
                .ListaIdsCriasDonantes = IdsCriasDonadas,
                .TotalCriasDonar = totalCriasDonar,
                .IdUsuario = VP_IdUser,
                .IdLote = idLoteDonadora
            }

            Dim _mensaje As String = cn.Cn_RegistrarNodrizaje(obj)
            If (obj.Coderror = 0) Then
                msj_ok(_mensaje)
                Inicializar()
                LimpiarCamposCerdaDonadora()
                LimpiarTablaDonadora()
            Else
                msj_advert(_mensaje)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub LimpiarTablaDonadora()
        dtgListado.DataSource = Nothing
        CargarTablaDonadoras()
    End Sub

    Function CreacionArrayDonanteCantidad() As String
        Dim array_valvulas As String = ""
        Dim crias_donadas As String = ""

        If (dtgListado.Rows.Count = 0) Then
            array_valvulas = "0"
            crias_donadas = "0"
        Else
            For i = 0 To dtgListado.Rows.Count - 1
                If (dtgListado.Rows(i).Cells(0).Value.ToString.Trim.Length <> 0) Then
                    With dtgListado.Rows(i)
                        array_valvulas = array_valvulas & .Cells("idAnimal").Value.ToString.Trim & "+" &
                            .Cells("cantidad").Value.ToString.Trim & "+" &
                            .Cells("esVacia").Value.ToString.Trim & ","
                        Dim idAnimal As Integer = Convert.ToInt32(.Cells("idAnimal").Value.ToString.Trim)

                        If DonacionCerdaCriasDict.ContainsKey(idAnimal) Then
                            crias_donadas &= DonacionCerdaCriasDict(idAnimal) & ","
                        End If
                    End With
                End If
            Next

            If array_valvulas.Length > 0 Then
                array_valvulas = array_valvulas.Substring(0, array_valvulas.Length - 1)
            End If

            If crias_donadas.Length > 0 Then
                crias_donadas = crias_donadas.Substring(0, crias_donadas.Length - 1)
            End If
        End If

        IdsCriasDonadas = crias_donadas
        Return array_valvulas
    End Function

    Public Sub LlenarCamposCerdaNodriza(codigo As String, datos As String, ubicacion As String)
        idNodriza = codigo
        LblCodArete.Text = datos
        TxtUbicacion.Text = ubicacion
    End Sub

    Private Sub BtnBuscarCerda_Click(sender As Object, e As EventArgs) Handles BtnBuscarCerda.Click
        Try
            Dim frm As New FrmListarCerdasVacias(Me) With {
                .idPlantel = idUbicacion
            }
            frm.ShowDialog()

            If idNodriza <> 0 Then
                BtnBuscarCerdaDonante.Enabled = True
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnBloquearFechaNodrizaje_Click(sender As Object, e As EventArgs) Handles BtnBloquearFechaNodrizaje.Click
        If CInt(VariablesGlobales.ParametrosNodriza("fNodrizaBloqueo")) = 1 Then
            DtpFecha.Enabled = True
            VariablesGlobales.ParametrosNodriza("fNodriza") = Now.Date
            VariablesGlobales.ParametrosNodriza("fNodrizaBloqueo") = 0
        Else
            DtpFecha.Enabled = False
            VariablesGlobales.ParametrosNodriza("fNodriza") = DtpFecha.Value
            VariablesGlobales.ParametrosNodriza("fNodrizaBloqueo") = 1
        End If
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class