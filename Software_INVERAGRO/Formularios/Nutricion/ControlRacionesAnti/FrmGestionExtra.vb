Imports System.ComponentModel
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmGestionExtra
    Dim cn As New cnControlAlimento
    Dim ds As New DataSet
    Dim _idMedicamento As Integer
    Private _CodAnti As Integer
    Dim _Operacion As Integer
    Public tipo As String

    Private Sub FrmGestionAnti_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            Ptbx_Cargando.Visible = True
            cmbEstado.SelectedIndex = 0
            dtpFechaDesde.Value = Now.Date
            dtpFechaHasta.Value = Now.Date
            lblTitulo.Text = "CONTROL DE " & tipo
            If (tipo = "ANTI") Then
                btnAsignarPlanMedicado.Visible = False
            Else
                btnAsignarPlanMedicado.Visible = True
            End If
            Consultar()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BloquearControles()
        GrupoFiltros.Enabled = False
        Ptbx_Cargando.Visible = True
        BarraOpciones.Enabled = False
    End Sub

    Private Sub DesbloquearControles()
        GrupoFiltros.Enabled = True
        Ptbx_Cargando.Visible = False
        BarraOpciones.Enabled = True
    End Sub

    Sub Consultar(Optional ByVal fechaDesde As Date? = Nothing, Optional ByVal fechaHasta As Date? = Nothing)
        If Not BackgroundWorker1.IsBusy Then
            BloquearControles()

            Dim obj As New coControlAlimento With {
                .Estado = cmbEstado.Text,
                .Tipo = tipo
            }
            If fechaDesde.HasValue Then
                obj.FechaDesde = fechaDesde
            Else
                obj.FechaDesde = Nothing
            End If

            If fechaHasta.HasValue Then
                obj.FechaHasta = fechaHasta
            Else
                obj.FechaHasta = Nothing
            End If

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlAlimento = CType(e.Argument, coControlAlimento)

            ds = cn.Cn_ConsultarExtra(obj).Copy
            ds.DataSetName = "tmp"
            Dim relation1 As New DataRelation("tb_relacion1", ds.Tables(0).Columns(0), ds.Tables(1).Columns(0), False)
            ds.Relations.Add(relation1)
            ds.Tables(0).Columns(0).ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns(0).ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns(1).ColumnMapping = MappingType.Hidden
            e.Result = ds
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            dtgListado.DataSource = ds.Tables(0)
            DesbloquearControles()
            Colorear()
            If tipo = "ANTI" Then
                dtgListado.DisplayLayout.Bands(0).Columns("Fecha de Rotación").Hidden = True
            End If
        End If
    End Sub

    Sub Colorear()
        If (dtgListado.Rows.Count > 0) Then
            Dim estado As Integer = 5

            'estado
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "CANCELADO", estado)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.LightGray, Color.Black, "PENDIENTE", estado)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ACTIVO", estado)

            'centrar columnas
            With dtgListado.DisplayLayout.Bands(0)
                .Columns(estado).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If dtpFechaDesde.Value > dtpFechaHasta.Value Then
            msj_advert("La fecha 'Desde' debe ser anterior o igual a la fecha 'Hasta'.")
            Return
        End If

        Dim fechaDesde As Date? = dtpFechaDesde.Value
        Dim fechaHasta As Date? = dtpFechaHasta.Value
        Consultar(fechaDesde, fechaHasta)
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim f As New FrmRegistrarExtra With {
            .tipoExtra = tipo
        }
        f.ShowDialog()
        Consultar()
    End Sub

    Private Sub btnActivar_Click(sender As Object, e As EventArgs) Handles btnActivar.Click
        Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
        If (dtgListado.Rows.Count > 0) Then
            If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                If activeRow.Band.Index = 0 Then
                    Dim estado = dtgListado.DisplayLayout.ActiveRow.Cells("Estado").Value.ToString

                    If estado = "ACTIVO" Then
                        msj_advert("El " & tipo & " YA SE ENCUENTRA ACTIVO")
                        Return
                    ElseIf estado = "CANCELADO" Then
                        msj_advert("El " & tipo & " YA FUE CANCELADO")
                        Return
                    End If

                    Dim result As DialogResult = MessageBox.Show("¿ESTA SEGURO DE ACTIVAR " & tipo & "?", "Confirmar Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If result = DialogResult.Yes Then
                        Dim obj As New coControlAlimento With {
                            .Codigo = CInt(dtgListado.DisplayLayout.ActiveRow.Cells(0).Value),
                            .Tipo = tipo,
                            .Estado = "ACTIVO"
                        }

                        Dim MensajeBgWk As String = cn.Cn_ActualizarEstadoExtra(obj)
                        If (obj.Coderror = 0) Then
                            msj_ok(MensajeBgWk)
                            Consultar()
                        Else
                            msj_advert(MensajeBgWk)
                        End If
                    End If
                Else
                    msj_advert(MensajesSistema.mensajesGenerales("SELECCION_FILA_CONTENEDOR"))
                End If
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Else
            msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
        End If
    End Sub
    Private Sub btnDesactivar_Click(sender As Object, e As EventArgs) Handles btnDesactivar.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            If (dtgListado.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    If activeRow.Band.Index = 0 Then
                        Dim estado = dtgListado.DisplayLayout.ActiveRow.Cells("Estado").Value.ToString

                        If estado = "ACTIVO" Or estado = "PENDIENTE" Then
                            Dim result As DialogResult = MessageBox.Show("¿ESTA SEGURO DE DESACTIVAR " & tipo & "?", "Confirmar Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            If result = DialogResult.Yes Then
                                Dim obj As New coControlAlimento With {
                                    .Codigo = CInt(dtgListado.DisplayLayout.ActiveRow.Cells(0).Value),
                                    .Estado = "CANCELADO",
                                    .Tipo = tipo
                                }

                                Dim MensajeBgWk As String = cn.Cn_ActualizarEstadoExtra(obj)
                                If (obj.Coderror = 0) Then
                                    msj_ok(MensajeBgWk)
                                    Consultar()
                                Else
                                    msj_advert(MensajeBgWk)
                                End If
                            End If
                        ElseIf estado = "CANCELADO" Then
                            msj_advert("EL " & tipo & " YA FUE CANCELADO")
                        End If
                    Else
                        msj_advert(MensajesSistema.mensajesGenerales("SELECCION_FILA_CONTENEDOR"))
                    End If
                Else
                    msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
                End If
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnAsignarPlanMedicado_Click(sender As Object, e As EventArgs) Handles btnAsignarPlanMedicado.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            If (dtgListado.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    If activeRow.Band.Index = 0 Then
                        Dim estado As String = dtgListado.DisplayLayout.ActiveRow.Cells("Estado").Value.ToString

                        If (estado <> "ACTIVO") Then
                            msj_advert("NO EXISTE UN PLAN MEDICADO CON ESTADO ACTIVO")
                            Return
                        End If

                        Dim f As New FrmListarRaciones With {
                            .idExtra = CInt(dtgListado.DisplayLayout.ActiveRow.Cells(0).Value)
                        }
                        f.ShowDialog()
                        Consultar()
                    Else
                        msj_advert(MensajesSistema.mensajesGenerales("SELECCION_FILA_CONTENEDOR"))
                    End If
                Else
                    msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
                End If
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnExportar_Click(sender As Object, e As EventArgs) Handles BtnExportar.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("CONTROL MEDICACIÓN EXTRA", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class