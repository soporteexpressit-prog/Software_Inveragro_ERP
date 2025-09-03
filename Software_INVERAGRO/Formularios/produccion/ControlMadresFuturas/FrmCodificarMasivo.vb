Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win.UltraWinGrid

Public Class FrmCodificarMasivo
    Dim cn As New cnControlLoteDestete
    Dim cnAnimal As New cnControlAnimal
    Public IdPlantel As Integer = 0
    Public IdLote As Integer = 0
    Dim tbtmp As New DataTable
    Public idJaulaCorral As Integer = 0

    Private Sub FrmCodificarMasivo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ListarGenetica()
            Inicializar()
            If (IdPlantel > 0) Then
                ListarGalpones(IdPlantel)
            End If
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Inicializar()
        TxtJaulaCorral.ReadOnly = True
        TxtSala.ReadOnly = True
        RbnCorral.Checked = True
        clsBasicas.Formato_Tablas_Grid_CincoUltimasColumnaEditable(DtgListado)
        clsBasicas.Filtrar_Tabla(DtgListado, True)
        ConsultarInicializarDiccionario()
    End Sub

    Private Sub ConsultarInicializarDiccionario()
        DtpFechaLlegada.Value = VariablesGlobales.ParametrosCodificacionAnimales("fLlegada")
        DtpFechaLlegada.Enabled = If(VariablesGlobales.ParametrosCodificacionAnimales("fLlegadaBloqueo") = 1, False, True)
        CmbGenetica.Value = VariablesGlobales.ParametrosCodificacionAnimales("idGenetica")
        CmbGenetica.Enabled = If(VariablesGlobales.ParametrosCodificacionAnimales("geneticaBloqueo") = 1, False, True)
        If VariablesGlobales.ParametrosCodificacionAnimales("jaulaCorralBloqueo") = 1 Then
            idJaulaCorral = VariablesGlobales.ParametrosCodificacionAnimales("idJaulaCorral")
            TxtJaulaCorral.Text = VariablesGlobales.ParametrosCodificacionAnimales("valorJaulaCorral")
            TxtSala.Text = VariablesGlobales.ParametrosCodificacionAnimales("valorSala")
            BtnBuscarJaulaCorral.Enabled = False
        End If
    End Sub

    Sub ListarGenetica()
        Dim cn As New cnControlMaterialGenetico
        Dim tb As New DataTable
        tb = cn.Cn_ListarGeneticaCerda().Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione Genética"
        With CmbGenetica
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Sub ListarGalpones(idplantel As Integer)
        Dim cn As New cnGalpon
        Dim tb As New DataTable
        Dim obj As New coGalpon With {
            .IdUbicacion = idplantel
        }
        tb = cn.Cn_Listar_Galpones_Por_Plantel(obj).Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione un Galpón"
        With CmbGalpon
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True
            ToolStrip1.Enabled = False

            Dim obj As New coControlLoteDestete With {
                .IdLote = IdLote,
                .IdPlantel = IdPlantel
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlLoteDestete = CType(e.Argument, coControlLoteDestete)
            tbtmp = cn.Cn_ConsultarMadresFuturasCodificar(obj).Copy
            tbtmp.TableName = "tmp"
            e.Result = tbtmp
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Ptbx_Cargando.Visible = False
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            DtgListado.DataSource = CType(e.Result, DataTable)
            ToolStrip1.Enabled = True
            DtgListado.DisplayLayout.Bands(0).Columns("idAnimal").Hidden = True
            ColorearUltimas4Columnas()
        End If
    End Sub

    Sub ColorearUltimas4Columnas()
        If DtgListado.Rows.Count > 0 Then
            Dim colorFondo As Color = Color.LightBlue

            For Each fila As UltraGridRow In DtgListado.Rows
                Dim totalColumnas As Integer = fila.Cells.Count

                For i As Integer = totalColumnas - 5 To totalColumnas - 1
                    fila.Cells(i).Appearance.BackColor = colorFondo
                    fila.Cells(i).Appearance.BackColorAlpha = Infragistics.Win.Alpha.Opaque
                    fila.Cells(i).Appearance.TextHAlign = Infragistics.Win.HAlign.Center
                Next
            Next
        End If
    End Sub

    Private Sub PintarFilasChanchilla()
        For Each fila As UltraGridRow In DtgListado.Rows
            Dim arete As String = fila.Cells("Arete").Value?.ToString().Trim()
            Dim tatuaje As String = fila.Cells("Tatuaje").Value?.ToString().Trim()

            If Not String.IsNullOrWhiteSpace(arete) And Not String.IsNullOrWhiteSpace(tatuaje) Then
                fila.Appearance.BackColor = Color.LightGreen
            Else
                fila.Appearance.BackColor = Color.White
            End If
        Next
    End Sub

    Private Sub CmbGalpon_TextChanged(sender As Object, e As EventArgs) Handles CmbGalpon.TextChanged
        idJaulaCorral = 0
        TxtJaulaCorral.Text = ""
        TxtSala.Text = ""
    End Sub

    Private Sub BtnBuscarJaulaCorral_Click(sender As Object, e As EventArgs) Handles BtnBuscarJaulaCorral.Click
        Try
            Dim frm As New FrmListarJaulaCorralMf(Me) With {
                .idGalpon = CmbGalpon.Value,
                .tipo = If(RbnCorral.Checked, "CORRAL", "JAULA")
            }
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Public Sub LlenarCamposJaulaCorral(codigo As Integer, descripcion As String, sala As String)
        idJaulaCorral = codigo
        TxtJaulaCorral.Text = descripcion
        TxtSala.Text = sala
    End Sub

    Private Sub DtgListado_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles DtgListado.InitializeLayout
        Try
            If (DtgListado.Rows.Count = 0) Then
            Else
                e.Layout.Bands(0).Summaries.Clear()
                clsBasicas.Totales_Formato(DtgListado, e, 1)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub DtgListado_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles DtgListado.AfterCellUpdate
        Try
            PintarFilasChanchilla()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub DtgListado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DtgListado.KeyPress
        If DtgListado.ActiveCell IsNot Nothing AndAlso DtgListado.ActiveCell.Column.Key = "Índice" Then
            Dim activeText As String = DtgListado.ActiveCell.Text
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

        If DtgListado.ActiveCell IsNot Nothing AndAlso DtgListado.ActiveCell.Column.Key = "N° Tetillas" Then
            Dim pressedKey As Char = e.KeyChar

            If Not (Char.IsDigit(pressedKey) OrElse Char.IsControl(pressedKey)) Then
                e.Handled = True
                Exit Sub
            End If

            Dim activeText As String = DtgListado.ActiveCell.Text

            If Char.IsDigit(pressedKey) AndAlso activeText.Length >= 3 Then
                e.Handled = True
                Exit Sub
            End If

            e.Handled = False
        End If

        If DtgListado.ActiveCell IsNot Nothing AndAlso DtgListado.ActiveCell.Column.Key = "Peso" Then
            Dim activeText As String = DtgListado.ActiveCell.Text
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

    Private Sub BtnBloquearCorral_Click(sender As Object, e As EventArgs) Handles BtnBloquearCorral.Click
        If CInt(VariablesGlobales.ParametrosCodificacionAnimales("jaulaCorralBloqueo")) = 1 Then
            BtnBuscarJaulaCorral.Enabled = True
            VariablesGlobales.ParametrosCodificacionAnimales("jaulaCorralBloqueo") = 0
        Else
            BtnBuscarJaulaCorral.Enabled = False
            VariablesGlobales.ParametrosCodificacionAnimales("jaulaCorralBloqueo") = 1
        End If
        VariablesGlobales.ParametrosCodificacionAnimales("idJaulaCorral") = idJaulaCorral
        VariablesGlobales.ParametrosCodificacionAnimales("valorJaulaCorral") = TxtJaulaCorral.Text
        VariablesGlobales.ParametrosCodificacionAnimales("valorSala") = TxtSala.Text
    End Sub

    Private Sub BtnBloquearFecha_Click(sender As Object, e As EventArgs) Handles BtnBloquearFecha.Click
        If CInt(VariablesGlobales.ParametrosCodificacionAnimales("fLlegadaBloqueo")) = 1 Then
            DtpFechaLlegada.Enabled = True
            VariablesGlobales.ParametrosCodificacionAnimales("fLlegada") = Now.Date
            VariablesGlobales.ParametrosCodificacionAnimales("fLlegadaBloqueo") = 0
        Else
            DtpFechaLlegada.Enabled = False
            VariablesGlobales.ParametrosCodificacionAnimales("fLlegada") = DtpFechaLlegada.Value
            VariablesGlobales.ParametrosCodificacionAnimales("fLlegadaBloqueo") = 1
        End If
    End Sub

    Private Sub BtnBloquearGenetica_Click(sender As Object, e As EventArgs) Handles BtnBloquearGenetica.Click
        If CInt(VariablesGlobales.ParametrosCodificacionAnimales("geneticaBloqueo")) = 1 Then
            CmbGenetica.Enabled = True
            VariablesGlobales.ParametrosCodificacionAnimales("idGenetica") = 1
            VariablesGlobales.ParametrosCodificacionAnimales("geneticaBloqueo") = 0
        Else
            CmbGenetica.Enabled = False
            VariablesGlobales.ParametrosCodificacionAnimales("idGenetica") = CmbGenetica.Value
            VariablesGlobales.ParametrosCodificacionAnimales("geneticaBloqueo") = 1
        End If
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            DtgListado.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode)

            If DtpFechaLlegada.Value > Now.Date Then
                msj_advert("La fecha de llegada no puede ser mayor a la actual")
                Return
            End If

            If (idJaulaCorral = 0) Then
                msj_advert("Seleccione un Ubicación")
                Return
            End If

            Dim aretes As New HashSet(Of String)()
            Dim tatuajes As New HashSet(Of String)()
            For Each row As UltraGridRow In DtgListado.Rows
                If row.Appearance.BackColor = Color.LightGreen Then
                    Dim arete As String = row.Cells("Arete").Value?.ToString().Trim()
                    Dim tatuaje As String = row.Cells("Tatuaje").Value?.ToString().Trim()

                    If Not String.IsNullOrWhiteSpace(arete) Then
                        If Not aretes.Add(arete) Then
                            msj_advert($"El Arete '{arete}' ya está registrado.")
                            Return
                        End If
                    End If

                    If Not String.IsNullOrWhiteSpace(tatuaje) Then
                        If Not tatuajes.Add(tatuaje) And (CmbGenetica.Value = 1 Or CmbGenetica.Value = 2) Then
                            msj_advert($"El Tatuaje '{tatuaje}' ya está registrado.")
                            Return
                        End If
                    End If
                End If
            Next

            For Each row As UltraGridRow In DtgListado.Rows
                If row.Appearance.BackColor = Color.LightGreen Then

                    Dim indice As String = row.Cells("Índice").Value?.ToString().Trim()
                    Dim nTetillas As String = row.Cells("N° Tetillas").Value?.ToString().Trim()
                    Dim peso As String = row.Cells("Peso").Value?.ToString().Trim()

                    If String.IsNullOrWhiteSpace(indice) Then
                        msj_advert("El Índice no puede ser cero.")
                        Return
                    End If

                    If String.IsNullOrWhiteSpace(nTetillas) OrElse CInt(nTetillas) = 0 Then
                        msj_advert("El N° Tetillas no puede ser cero.")
                        Return
                    End If

                    If String.IsNullOrWhiteSpace(peso) Then
                        msj_advert("El Peso no puede estar vacío.")
                        Return
                    End If
                End If
            Next

            If (MessageBox.Show("¿ESTÁ SEGURO DE CODIFICAR ESTOS ANIMALES?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coControlAnimal With {
               .FechaLlegada = DtpFechaLlegada.Value,
               .IdGenetica = CmbGenetica.Value,
               .IdJaulaCorral = idJaulaCorral,
               .ListaCriasRegistrar = CreacionArrayChanchillasCodificadas()
            }

            Dim mensaje As String = cnAnimal.Cn_RegistrarCodificacionAnimal(obj)
            If (obj.Coderror = 0) Then
                msj_ok(mensaje)
                ConsultarInicializarDiccionario()
                Consultar()
            Else
                msj_advert(mensaje)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Function CreacionArrayChanchillasCodificadas() As String
        Dim array_valvulas As String = ""

        If (DtgListado.Rows.Count = 0) Then
            array_valvulas = "0"
        Else
            For i = 0 To DtgListado.Rows.Count - 1
                If (DtgListado.Rows(i).Cells(0).Value.ToString.Trim.Length <> 0) Then
                    Dim arete As String = DtgListado.Rows(i).Cells("Arete").Value?.ToString().Trim()
                    Dim tatuaje As String = DtgListado.Rows(i).Cells("Tatuaje").Value?.ToString().Trim()

                    If Not String.IsNullOrWhiteSpace(arete) And Not String.IsNullOrWhiteSpace(tatuaje) Then
                        With DtgListado.Rows(i)
                            array_valvulas = array_valvulas & .Cells("idAnimal").Value.ToString.Trim & "+" &
                            .Cells("Arete").Value.ToString.Trim & "+" &
                            .Cells("Tatuaje").Value.ToString.Trim & "+" &
                            .Cells("Sexo").Value.ToString.Trim & "+" &
                            .Cells("Índice").Value.ToString.Trim & "+" &
                            .Cells("N° Tetillas").Value.ToString.Trim & "+" &
                            .Cells("Peso").Value.ToString.Trim & ","
                        End With
                    End If
                End If
            Next

            array_valvulas = array_valvulas.Substring(0, array_valvulas.Length - 1)
        End If
        Return array_valvulas
    End Function

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class