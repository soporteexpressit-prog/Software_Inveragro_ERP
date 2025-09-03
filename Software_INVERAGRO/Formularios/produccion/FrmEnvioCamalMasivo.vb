Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win.UltraWinGrid

Public Class FrmEnvioCamalMasivo
    Dim cnAnimal As New cnControlAnimal
    Dim idMotivoCamal As Integer = 0
    Public idUbicacion As Integer = 0
    Dim tbtmp As New DataTable

    Private Sub FrmEnvioCamalMasivo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            clsBasicas.Formato_Tablas_Grid_UltimaColumnaEditable(DtgListado)
            clsBasicas.Filtrar_Tabla(DtgListado, True)
            TxtMotivoMortalidad.ReadOnly = True
            LblPeso.Visible = False
            TxtPeso.Visible = False
            ConsultarInicializarDiccionario()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ConsultarInicializarDiccionario()
        DtpFecha.Value = VariablesGlobales.ParametrosEnvioCamalMasivo("fEnvioCamal")
        DtpFecha.Enabled = If(VariablesGlobales.ParametrosEnvioCamalMasivo("fEnvioCamalBloqueo") = 1, False, True)
        idMotivoCamal = VariablesGlobales.ParametrosEnvioCamalMasivo("idMotivoCamal")
        TxtMotivoMortalidad.Text = VariablesGlobales.ParametrosEnvioCamalMasivo("valorMotivoCamal").ToString()
        BtnMotivoCamal.Enabled = If(VariablesGlobales.ParametrosEnvioCamalMasivo("motivoCamalBloqueo") = 1, False, True)
    End Sub

    Private Sub BtnMotivoCamal_Click(sender As Object, e As EventArgs) Handles BtnMotivoCamal.Click
        Try
            Dim frm As New FrmListarIncidenciaMandarCamalMasivo(Me)
            frm.ShowDialog()
            If idMotivoCamal = 87 Or idMotivoCamal = 88 Then
                LblPeso.Visible = True
                TxtPeso.Visible = True
                TxtPeso.Text = "0"
            Else
                LblPeso.Visible = False
                TxtPeso.Visible = False
                TxtPeso.Text = "0"
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Public Sub LlenarCampoMotivoMortalidad(id As String, motivo As String)
        idMotivoCamal = id
        TxtMotivoMortalidad.Text = motivo
    End Sub

    Private Sub BtnMotivo_Click(sender As Object, e As EventArgs) Handles BtnMotivo.Click
        If CInt(VariablesGlobales.ParametrosEnvioCamalMasivo("motivoCamalBloqueo")) = 1 Then
            BtnMotivoCamal.Enabled = True
            VariablesGlobales.ParametrosEnvioCamalMasivo("idMotivoCamal") = 0
            VariablesGlobales.ParametrosEnvioCamalMasivo("valorMotivoCamal") = ""
            VariablesGlobales.ParametrosEnvioCamalMasivo("motivoCamalBloqueo") = 0
        Else
            BtnMotivoCamal.Enabled = False
            VariablesGlobales.ParametrosEnvioCamalMasivo("idMotivoCamal") = idMotivoCamal
            VariablesGlobales.ParametrosEnvioCamalMasivo("valorMotivoCamal") = TxtMotivoMortalidad.Text
            VariablesGlobales.ParametrosEnvioCamalMasivo("motivoCamalBloqueo") = 1
        End If
    End Sub

    Private Sub BtnBloquearFecha_Click(sender As Object, e As EventArgs) Handles BtnBloquearFecha.Click
        If CInt(VariablesGlobales.ParametrosEnvioCamalMasivo("fEnvioCamalBloqueo")) = 1 Then
            DtpFecha.Enabled = True
            VariablesGlobales.ParametrosEnvioCamalMasivo("fEnvioCamal") = Now.Date
            VariablesGlobales.ParametrosEnvioCamalMasivo("fEnvioCamalBloqueo") = 0
        Else
            DtpFecha.Enabled = False
            VariablesGlobales.ParametrosEnvioCamalMasivo("fEnvioCamal") = DtpFecha.Value
            VariablesGlobales.ParametrosEnvioCamalMasivo("fEnvioCamalBloqueo") = 1
        End If
    End Sub

    Private Sub BloquearControladores()
        Ptbx_Cargando.Visible = True
        BtnMotivo.Enabled = False
        TxtMotivoMortalidad.Enabled = False
        txtDescripcion.Enabled = False
        BtnBloquearFecha.Enabled = False
        TxtPeso.Enabled = False
        ToolStrip1.Enabled = False
    End Sub

    Private Sub DesbloquearControladores()
        Ptbx_Cargando.Visible = False
        BtnMotivo.Enabled = True
        TxtMotivoMortalidad.Enabled = True
        txtDescripcion.Enabled = True
        BtnBloquearFecha.Enabled = True
        TxtPeso.Enabled = True
        ToolStrip1.Enabled = True
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            BloquearControladores()

            Dim obj As New coControlAnimal With {
                .IdPlantel = idUbicacion
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlAnimal = CType(e.Argument, coControlAnimal)
            tbtmp = cnAnimal.Cn_ConsultarCerdasCamal(obj).Copy
            tbtmp.TableName = "tmp"
            e.Result = tbtmp
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        DesbloquearControladores()
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            DtgListado.DataSource = CType(e.Result, DataTable)
            DtgListado.DisplayLayout.Bands(0).Columns("idAnimal").Hidden = True
        End If
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

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            DtgListado.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode)

            If DtpFecha.Value > Now.Date Then
                msj_advert("La fecha no puede ser mayor a la fecha actual")
                Return
            End If

            If idMotivoCamal = 0 Then
                msj_advert("Debe seleccionar un motivo de envío a camal")
                Return
            End If

            If idMotivoCamal = 87 Or idMotivoCamal = 88 Then
                If TxtPeso.Text = "" Then
                    msj_advert("Debe ingresar el peso del cerdo")
                    Exit Sub
                ElseIf CDec(TxtPeso.Text) <= 0 Then
                    msj_advert("El peso del cerdo no debe ser cero")
                    Exit Sub
                End If
            End If

            Dim cadenaIds As String = ObtenerIdsAnimalesMarcados()

            If String.IsNullOrEmpty(cadenaIds) Then
                msj_advert("Debe seleccionar al menos un animal para enviar al camal.")
                Return
            End If

            Dim obj As New coControlAnimal With {
                .IdUsuario = VP_IdUser,
                .Observacion = txtDescripcion.Text,
                .FechaControl = DtpFecha.Value,
                .Peso = If(TxtPeso.Text = "", 0, CDec(TxtPeso.Text)),
                .IdMotivoMortalidadCamal = idMotivoCamal,
                .ListaCriasRegistrar = cadenaIds
            }

            If (MessageBox.Show("¿ESTÁ SEGURO DE ENVIAR ESTOS ANIMALES A CAMAL?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim MensajeBgWk As String = cnAnimal.Cn_RegistrarEnvioCamalMasivo(obj)
            If (obj.Coderror = 0) Then
                msj_ok(MensajeBgWk)
                Consultar()
                ConsultarInicializarDiccionario()
            Else
                msj_advert(MensajeBgWk)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Function ObtenerIdsAnimalesMarcados() As String
        Dim listaIdsAnimales As New List(Of String)

        For Each row As UltraGridRow In DtgListado.Rows
            If row.IsDataRow Then
                Dim enviar As Boolean = False

                If row.Cells("Envíar").Value IsNot Nothing Then
                    enviar = CBool(row.Cells("Envíar").Value)
                End If

                If enviar Then
                    Dim idAnimal As String = row.Cells("idAnimal").Value?.ToString().Trim()
                    If Not String.IsNullOrWhiteSpace(idAnimal) Then
                        listaIdsAnimales.Add(idAnimal)
                    End If
                End If
            End If
        Next

        Return String.Join(",", listaIdsAnimales)
    End Function

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class