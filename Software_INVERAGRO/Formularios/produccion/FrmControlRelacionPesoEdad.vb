Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmControlRelacionPesoEdad
    Dim cn As New cnControlRelacionPesoEdad
    Dim ds As New DataSet
    Private formLoaded As Boolean = False


    Private Sub FrmControlRelacionPesoEdad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            Inicializar()
            Consultar()
            ObtenerAnios()
            formLoaded = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ObtenerAnios()
        For i As Integer = DateTime.Now.Year - 10 To DateTime.Now.Year + 20
            CmbAnios.Items.Add(i.ToString())
        Next
        CmbAnios.DropDownStyle = ComboBoxStyle.DropDownList
        CmbAnios.Text = DateTime.Now.Year.ToString()
    End Sub

    Private Sub Inicializar()
        Try
            clsBasicas.Filtrar_Tabla(dtgListado, True)
            Ptbx_Cargando.Visible = True
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True

            Dim obj As New coControlRelacionPesoEdad With {
                .Anio = If(formLoaded, CInt(CmbAnios.Text), 0)
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlRelacionPesoEdad = CType(e.Argument, coControlRelacionPesoEdad)

            ds = cn.Cn_ConsultarRelacionPesoEdad(obj).Copy
            ds.DataSetName = "tmp"
            Dim relation1 As New DataRelation("tb_relacion1", ds.Tables(0).Columns(0), ds.Tables(1).Columns(0), False)
            ds.Relations.Add(relation1)
            ds.Tables(1).Columns(0).ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns(1).ColumnMapping = MappingType.Hidden

            e.Result = ds
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Ptbx_Cargando.Visible = False
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            dtgListado.DataSource = ds.Tables(0)
            Colorear()
        End If
    End Sub

    Sub Colorear()
        If (dtgListado.Rows.Count > 0) Then
            Dim estado As Integer = 4

            'estado
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Red, Color.White, "INACTIVO", estado)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.Green, Color.White, "ACTIVO", estado)

            'centrar columnas
            With dtgListado.DisplayLayout.Bands(0)
                .Columns(estado).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub BtnNuevoRelacionPeso_Click(sender As Object, e As EventArgs) Handles BtnNuevoRelacionPeso.Click
        Try
            Dim frm As New FrmRegistrarTablaRelacionPesoEdad
            frm.ShowDialog()
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub CmbAnios_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbAnios.SelectedIndexChanged
        If formLoaded Then
            Consultar()
        End If
    End Sub

    Private Sub BtnFiltro_Click(sender As Object, e As EventArgs) Handles BtnFiltro.Click
        Dim isFilterActive As Boolean = Not BtnFiltro.Checked
        BtnFiltro.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtgListado, isFilterActive)
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListado.ActiveRow
            If (dtgListado.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim estado As String = activeRow.Cells(4).Value.ToString

                    If (estado = "INACTIVO") Then
                        msj_advert("ESTE REGISTRO YA SE ENCUENTRA CANCELADO")
                        Return
                    End If

                    If MsgBox("¿ESTÁ SEGURO DE CANCELAR ESTE REGISTRO?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Registrar Medicación") = MsgBoxResult.No Then
                        Return
                    End If

                    Dim obj As New coControlRelacionPesoEdad With {
                        .Codigo = Convert.ToInt32(activeRow.Cells(0).Value)
                    }
                    Dim _mensaje As String = ""

                    _mensaje = cn.Cn_CancelarRelacionPesoEdad(obj)
                    If (obj.Coderror = 0) Then
                        msj_ok(_mensaje)
                        Consultar()
                    Else
                        msj_advert(_mensaje)
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

    Private Sub BtnExportarRelacionPeso_Click(sender As Object, e As EventArgs) Handles BtnExportarRelacionPeso.Click
        Try
            If (dtgListado.Rows.Count = 0) Then
                msj_advert(MensajesSistema.mensajesGenerales("SIN_RESULTADOS"))
                Return
            Else
                clsBasicas.ExportarExcel("CONTROL DE RELACION EDAD - PESO", dtgListado)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Dispose()
    End Sub
End Class