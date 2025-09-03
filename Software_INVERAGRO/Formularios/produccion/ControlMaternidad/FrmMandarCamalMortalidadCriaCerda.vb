Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmMandarCamalMortalidadCriaCerda
    Dim cn As New cnControlAnimal
    Dim ds As New DataSet
    Dim criasMuertas As New List(Of Integer)
    Dim idMotivoMortalidadCamal As Integer = 0
    Dim totalCrias As Integer = 0
    Public idUbicacion As Integer = 0
    Public idControlFichaMortalidad As Integer = 0
    Dim idCerda As Integer = 0
    Dim idResponsableMortalidad As Integer = 0

    Private Sub FrmMortalidadCriaCerda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListarDetalleParto()
        TxtMotivoMortalidad.ReadOnly = True
        TxtNombreEncargado.ReadOnly = True

        If idControlFichaMortalidad = 0 Then
            BtnBloquearFechaMortalidad.Enabled = True
            LblSeleccionarCerda.Visible = True
            BtnBuscarCerda.Visible = True
            ConsultarInicializarDiccionario()
        Else
            NoMostrarCandados()
            BtnBloquearFechaMortalidad.Enabled = False
            LblSeleccionarCerda.Visible = False
            BtnBuscarCerda.Visible = False
            ConsultarxId()
            LblCriasSeleccionadas.Text = ContarFilasSeleccionadasPorColor().ToString()
        End If
        OcultarVisualizarResponsable()
    End Sub

    Private Sub ConsultarInicializarDiccionario()
        DtpFechaMortalidad.Value = VariablesGlobales.ParametrosMortalidadCriasMaternidad("fMortalidad")
        DtpFechaMortalidad.Enabled = If(VariablesGlobales.ParametrosMortalidadCriasMaternidad("fMortalidadBloqueo") = 1, False, True)
        idMotivoMortalidadCamal = VariablesGlobales.ParametrosMortalidadCriasMaternidad("idMotivoMortalidad")
        TxtMotivoMortalidad.Text = VariablesGlobales.ParametrosMortalidadCriasMaternidad("valorMotivoMortalidad").ToString()
        BtnMotivoMortalidad.Enabled = If(VariablesGlobales.ParametrosMortalidadCriasMaternidad("motivoMortalidadBloqueo") = 1, False, True)
    End Sub

    Private Sub NoMostrarCandados()
        BtnBloquearFechaMortalidad.Visible = False
        BtnMotivo.Visible = False
    End Sub

    Sub ConsultarxId()
        Try
            Dim obj As New coControlAnimal With {
                .Codigo = idControlFichaMortalidad
            }
            Dim ds As New DataSet
            ds = cn.Cn_ConsultarControlFichaMortalidadCrias(obj).Copy
            If (ds.Tables(0).Rows.Count > 0) Then
                idCerda = ds.Tables(0).Rows(0)("idAnimal")
                LblCodArete.Text = ds.Tables(0).Rows(0)("codCerdo")
                DtpFechaMortalidad.Value = ds.Tables(0).Rows(0)("fControl")
                idMotivoMortalidadCamal = ds.Tables(0).Rows(0)("idTipoIncidencia")
                TxtMotivoMortalidad.Text = ds.Tables(0).Rows(0)("descripcion")
                idResponsableMortalidad = ds.Tables(0).Rows(0)("idPersona")
                TxtNombreEncargado.Text = ds.Tables(0).Rows(0)("datos")
            End If

            If (ds.Tables(1).Rows.Count > 0) Then
                DtgListadoCrias.DataSource = ds.Tables(1)
            End If

            For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In DtgListadoCrias.Rows
                If row.Cells("Estado").Value.ToString() = "MUERTO" Then
                    row.Appearance.BackColor = Color.LightBlue
                    criasMuertas.Add(row.Index)
                End If
            Next

            MostrarVaciaLactando()
            Colorear()
            LblMuertoCod.Text = ObtenerTotalMuertos()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub OcultarVisualizarResponsable()
        If IdMotivoMortalidadCamal = 47 Or IdMotivoMortalidadCamal = 48 Then
            LblResponsable.Visible = True
            BtnEncargado.Visible = True
            TxtNombreEncargado.Visible = True
        Else
            LblResponsable.Visible = False
            BtnEncargado.Visible = False
            TxtNombreEncargado.Visible = False
        End If
    End Sub

    Private Sub ListarDetalleParto()
        Try
            Dim obj As New coControlAnimal With {
                .Codigo = idCerda,
                .IdControlFichaMortalidad = idControlFichaMortalidad
            }

            ds = cn.Cn_ConsultarDetallePartoMortalidad(obj)
            DtgListadoCrias.DataSource = ds.Tables(0)
            clsBasicas.Formato_Tablas_Grid(DtgListadoCrias)
            DtgListadoCrias.DisplayLayout.Bands(0).Columns(0).Hidden = True
            totalCrias = ds.Tables(0).Rows.Count
            criasMuertas.Clear()

            MostrarVaciaLactando()
            Colorear()
            LblMuertoCod.Text = ObtenerTotalMuertos()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Colorear()
        If (DtgListadoCrias.Rows.Count > 0) Then
            Dim estadoVivoCod As Integer = 5

            'estadoVivoCod
            clsBasicas.Colorear_SegunValor(DtgListadoCrias, Color.LightGreen, Color.DarkGreen, "VIVO", estadoVivoCod)
            clsBasicas.Colorear_SegunValor(DtgListadoCrias, Color.LightCoral, Color.White, "MUERTO", estadoVivoCod)

            'centrar columnas
            With DtgListadoCrias.DisplayLayout.Bands(0)
                .Columns(estadoVivoCod).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Public Function ObtenerTotalMuertos() As Integer
        Dim cantidad As Integer = 0

        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In DtgListadoCrias.Rows
            If row.Cells("estado").Value.ToString() = "MUERTO" Then
                cantidad += 1
            End If
        Next

        Return cantidad
    End Function

    Public Function ObtenerTotalVivos() As Integer
        Dim cantidad As Integer = 0

        For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In DtgListadoCrias.Rows
            If row.Cells("estado").Value.ToString() = "VIVO" Then
                cantidad += 1
            End If
        Next

        Return cantidad
    End Function

    Private Sub dtgListadoCod_DoubleClickCell(sender As Object, e As UltraWinGrid.DoubleClickCellEventArgs) Handles DtgListadoCrias.DoubleClickCell
        Dim fila As Infragistics.Win.UltraWinGrid.UltraGridRow = e.Cell.Row

        If fila IsNot Nothing AndAlso fila.Cells IsNot Nothing AndAlso fila.Cells.Count > 0 AndAlso
       fila.Cells(0) IsNot Nothing AndAlso Not IsDBNull(fila.Cells(0).Value) AndAlso
       Not String.IsNullOrWhiteSpace(fila.Cells(0).Value?.ToString()) Then
            Dim estadoVida As String = fila.Cells("Estado").Value.ToString()

            If estadoVida = "MUERTO" And idControlFichaMortalidad = 0 Then
                msj_advert("El cerdo seleccionado se encuentra " & estadoVida)
                Return
            End If

            If criasMuertas.Contains(fila.Index) Then
                criasMuertas.Remove(fila.Index)
                fila.Appearance.BackColor = Color.White
            Else
                criasMuertas.Add(fila.Index)
                fila.Appearance.BackColor = Color.LightBlue
            End If

            MostrarVaciaLactando()
            LblCriasSeleccionadas.Text = ContarFilasSeleccionadasPorColor().ToString()
        End If
    End Sub

    Private Function ContarFilasSeleccionadasPorColor() As Integer
        Dim contador As Integer = 0
        For Each fila As Infragistics.Win.UltraWinGrid.UltraGridRow In DtgListadoCrias.Rows
            If fila.Appearance.BackColor = Color.LightBlue Then
                contador += 1
            End If
        Next
        Return contador
    End Function

    Private Sub MostrarVaciaLactando()
        Dim totalFilas As Integer = DtgListadoCrias.Rows.Count
        Dim totalSeleccionadas As Integer = criasMuertas.Count
        Dim totalVivos As Integer = ObtenerTotalVivos()

        If idControlFichaMortalidad = 0 Then
            If totalFilas > 0 AndAlso totalVivos = totalSeleccionadas Then
                CbxMortalidadTotal.Checked = True
                RtnDejarVacia.Visible = True
                RtnSeguirLactando.Visible = True
            Else
                CbxMortalidadTotal.Checked = False
                RtnDejarVacia.Visible = False
                RtnSeguirLactando.Visible = False
            End If
        Else
            If totalFilas > 0 AndAlso totalFilas = totalSeleccionadas Then
                CbxMortalidadTotal.Checked = True
                RtnDejarVacia.Visible = True
                RtnSeguirLactando.Visible = True
            Else
                CbxMortalidadTotal.Checked = False
                RtnDejarVacia.Visible = False
                RtnSeguirLactando.Visible = False
            End If
        End If
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            If DtpFechaMortalidad.Value > Now.Date Then
                msj_advert("La fecha de mortalidad no puede ser mayor a la fecha actual.")
                Return
            End If

            If criasMuertas.Count = 0 Then
                msj_advert("Debe seleccionar al menos un lechón para registrar la mortalidad.")
                Return
            End If

            If RtnDejarVacia.Visible AndAlso Not RtnDejarVacia.Checked AndAlso Not RtnSeguirLactando.Checked Then
                msj_advert("Debe seleccionar una opción para la cerda si se deja vacía o se sigue lactando.")
                Return
            End If

            If (IdMotivoMortalidadCamal = 0) Then
                msj_advert("Debe seleccionar un motivo de mortalidad.")
                Return
            End If

            If (IdMotivoMortalidadCamal = 47 Or IdMotivoMortalidadCamal = 48) Then
                If idResponsableMortalidad = 0 Then
                    msj_advert("Debe seleccionar un responsable de la mortalidad.")
                    Return
                End If
            End If


            Dim obj As New coControlAnimal With {
                .FechaControl = DtpFechaMortalidad.Value,
                .ListaIdsCriasConCod = CrearStringIdsCerdo(),
                .IdMotivoMortalidadCamal = idMotivoMortalidadCamal,
                .IdUsuario = VP_IdUser,
                .IdResponsable = If(idMotivoMortalidadCamal = 47 Or idMotivoMortalidadCamal = 48, idResponsableMortalidad, VP_IdUser),
                .Codigo = idCerda,
                .DejarVaciaoLactando = If(RtnDejarVacia.Checked, "SI", "NO"),
                .IdControlFichaMortalidad = idControlFichaMortalidad
            }

            If idControlFichaMortalidad = 0 Then
                If (MessageBox.Show("¿ESTÁ SEGURO DE REGISTRAR MORTALIDAD DE ANIMALES?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                    Return
                End If
            Else
                If (MessageBox.Show("¿ESTÁ SEGURO DE ACTUALIZAR MORTALIDAD DE ANIMALES?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                    Return
                End If
            End If

            Dim MensajeBgWk As String = cn.Cn_MantenimientoMortalidadMaternidad(obj)

            If (obj.Coderror = 0) Then
                msj_ok(MensajeBgWk)
                LimpiarTipoMortalidad()
                If idControlFichaMortalidad = 0 Then
                    ListarDetalleParto()
                    LblCriasSeleccionadas.Text = ContarFilasSeleccionadasPorColor().ToString()
                Else
                    Dispose()
                End If
            Else
                msj_advert(MensajeBgWk)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub LimpiarTipoMortalidad()
        criasMuertas.Clear()
        RtnDejarVacia.Checked = False
        RtnSeguirLactando.Checked = False
        RtnDejarVacia.Visible = False
        RtnSeguirLactando.Visible = False
        CbxMortalidadTotal.Checked = False
    End Sub

    Private Function CrearStringIdsCerdo() As String
        Dim seleccionados As String = ""

        For Each filaIndex As Integer In criasMuertas
            seleccionados &= DtgListadoCrias.Rows(filaIndex).Cells(0).Value.ToString() & ", "
        Next

        If seleccionados.Length > 2 Then
            seleccionados = seleccionados.Substring(0, seleccionados.Length - 2)
        End If

        Return seleccionados
    End Function

    Public Sub LlenarCampoMotivoMortalidad(id As Integer, motivo As String)
        IdMotivoMortalidadCamal = id
        TxtMotivoMortalidad.Text = motivo
        idResponsableMortalidad = 0
        TxtNombreEncargado.Text = ""

        OcultarVisualizarResponsable()
    End Sub

    Private Sub BtnMotivoMortalidad_Click(sender As Object, e As EventArgs) Handles BtnMotivoMortalidad.Click
        Dim frm As New FrmListarMotivoMandaCamalMortalidad(Me) With {
            .tipo = "MORTALIDAD",
            .ambiente = "MATERNIDAD"
        }
        frm.ShowDialog()
    End Sub

    Private Sub dtgListadoCod_InitializeLayout(sender As Object, e As UltraWinGrid.InitializeLayoutEventArgs) Handles DtgListadoCrias.InitializeLayout
        Try
            If (DtgListadoCrias.Rows.Count = 0) Then
            Else
                e.Layout.Bands(0).Summaries.Clear()
                clsBasicas.Totales_Formato(DtgListadoCrias, e, 1)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Public Sub LlenarCamposResponsableMortalidad(codigo As Integer, datos As String)
        idResponsableMortalidad = codigo
        TxtNombreEncargado.Text = datos
    End Sub

    Private Sub CbxMortalidadTotal_CheckedChanged(sender As Object, e As EventArgs) Handles CbxMortalidadTotal.CheckedChanged
        Try
            If DtgListadoCrias.Rows.Count = 0 Then
                CbxMortalidadTotal.Checked = False
                Return
            End If

            If CbxMortalidadTotal.Checked Then
                For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In DtgListadoCrias.Rows
                    If row.Cells("Estado").Value.ToString() = "VIVO" Then
                        If Not criasMuertas.Contains(row.Index) Then
                            criasMuertas.Add(row.Index)
                            row.Appearance.BackColor = Color.LightBlue
                        End If
                    End If
                Next
                RtnDejarVacia.Visible = True
                RtnSeguirLactando.Visible = True
                LblCriasSeleccionadas.Text = ContarFilasSeleccionadasPorColor().ToString()
            Else
                For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In DtgListadoCrias.Rows
                    If row.Cells("Estado").Value.ToString() = "VIVO" Then
                        If criasMuertas.Contains(row.Index) Then
                            criasMuertas.Remove(row.Index)
                            row.Appearance.BackColor = Color.White
                        End If
                    End If
                Next
                RtnDejarVacia.Visible = False
                RtnSeguirLactando.Visible = False
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnEncargado_Click(sender As Object, e As EventArgs) Handles BtnEncargado.Click
        Try
            Dim frm As New FrmListaEncargadoMortalidadCrias(Me)
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Public Sub LlenarCamposCerdaMortalidad(codigo As Integer, datos As String)
        idCerda = codigo
        LblCodArete.Text = datos
        ListarDetalleParto()
    End Sub

    Private Sub BtnBuscarCerda_Click(sender As Object, e As EventArgs) Handles BtnBuscarCerda.Click
        Try
            Dim frm As New FrmListarCerdaLactanteMortalidad(Me) With {
                .idPlantel = idUbicacion
            }
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnBloquearFechaMortalidad_Click(sender As Object, e As EventArgs) Handles BtnBloquearFechaMortalidad.Click
        If CInt(VariablesGlobales.ParametrosMortalidadCriasMaternidad("fMortalidadBloqueo")) = 1 Then
            DtpFechaMortalidad.Enabled = True
            VariablesGlobales.ParametrosMortalidadCriasMaternidad("fMortalidad") = Now.Date
            VariablesGlobales.ParametrosMortalidadCriasMaternidad("fMortalidadBloqueo") = 0
        Else
            DtpFechaMortalidad.Enabled = False
            VariablesGlobales.ParametrosMortalidadCriasMaternidad("fMortalidad") = DtpFechaMortalidad.Value
            VariablesGlobales.ParametrosMortalidadCriasMaternidad("fMortalidadBloqueo") = 1
        End If
    End Sub

    Private Sub BtnMotivo_Click(sender As Object, e As EventArgs) Handles BtnMotivo.Click
        If CInt(VariablesGlobales.ParametrosMortalidadCriasMaternidad("motivoMortalidadBloqueo")) = 1 Then
            BtnMotivoMortalidad.Enabled = True
            VariablesGlobales.ParametrosMortalidadCriasMaternidad("idMotivoMortalidad") = 0
            VariablesGlobales.ParametrosMortalidadCriasMaternidad("valorMotivoMortalidad") = ""
            VariablesGlobales.ParametrosMortalidadCriasMaternidad("motivoMortalidadBloqueo") = 0
        Else
            BtnMotivoMortalidad.Enabled = False
            VariablesGlobales.ParametrosMortalidadCriasMaternidad("idMotivoMortalidad") = idMotivoMortalidadCamal
            VariablesGlobales.ParametrosMortalidadCriasMaternidad("valorMotivoMortalidad") = TxtMotivoMortalidad.Text
            VariablesGlobales.ParametrosMortalidadCriasMaternidad("motivoMortalidadBloqueo") = 1
        End If
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class