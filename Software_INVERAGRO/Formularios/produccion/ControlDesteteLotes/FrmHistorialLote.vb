Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports iText.IO.Font

Public Class FrmHistorialLote
    Dim cnMedico As New cnControlMedico
    Dim cnLote As New cnControlLoteDestete
    Dim ds As New DataSet
    Public idLote As Integer = 0
    Public idUbicacion As Integer = 0

    Private Sub FrmHistorialLote_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ConsultarControlFichaxIdLote()
            Consultar()
            clsBasicas.Formato_Tablas_Grid_Sin_Ajustar(dtgListado)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ConsultarControlFichaxIdLote()
        Dim obj As New coControlLoteDestete With {
                .IdLote = idLote,
                .IdPlantel = idUbicacion
            }
        Dim dt As New DataTable
        dt = cnLote.Cn_ConsultarHistorialLote(obj).Copy
        If (dt.Rows.Count > 0) Then
            LblLote.Text = dt.Rows(0)("Lote").ToString()
            LblFechaNacLote.Text = dt.Rows(0)("fNacimiento").ToString()
            LblMadresParto.Text = dt.Rows(0)("totalMadresParto").ToString()
            LblPesoTotalNac.Text = dt.Rows(0)("pesoTotalNacParto")
            LblCriasParto.Text = dt.Rows(0)("TotalAnimalesParto")
            LblPesoPromNac.Text = (CInt(LblPesoTotalNac.Text) / CInt(LblCriasParto.Text)).ToString("0.00")
            LblMachosParto.Text = dt.Rows(0)("TotalMachosParto").ToString()
            LblHembrasParto.Text = dt.Rows(0)("TotalHembrasParto").ToString()
            LblTotalMomias.Text = dt.Rows(0)("TotalMomiasParto").ToString()
            LblTotalMuertos.Text = dt.Rows(0)("TotalMuertosParto").ToString()

            LblMadresDestete.Text = dt.Rows(0)("totalMadresDestete").ToString()
            LblPesoTotalDest.Text = dt.Rows(0)("pesoTotalNacDestete")
            LblCriasDestete.Text = dt.Rows(0)("TotalAnimalesDestete").ToString()
            LblPesoPromDest.Text = (CInt(LblPesoTotalDest.Text) / CInt(LblCriasDestete.Text)).ToString("0.00")
            LblMachosDestete.Text = dt.Rows(0)("TotalMachosDestete").ToString()
            LblHembrasDestete.Text = dt.Rows(0)("TotalHembrasDestete").ToString()
        End If
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True

            Dim obj As New coControlMedico With {
                .IdLote = idLote,
                .IdPlantel = idUbicacion
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlMedico = CType(e.Argument, coControlMedico)

            ds = cnMedico.Cn_ConsultarMedicacionxLote(obj).Copy
            ds.DataSetName = "tmp"
            Dim relation1 As New DataRelation("tb_relacion1", ds.Tables(0).Columns(0), ds.Tables(1).Columns(0), False)
            ds.Relations.Add(relation1)
            ds.Tables(0).Columns(0).ColumnMapping = MappingType.Hidden
            ds.Tables(1).Columns(0).ColumnMapping = MappingType.Hidden
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
            Dim estado As Integer = 2

            'estadoPeso
            clsBasicas.Colorear_SegunValor(dtgListado, Color.PaleGreen, Color.DarkGreen, "APLICADO", estado)
            clsBasicas.Colorear_SegunValor(dtgListado, Color.IndianRed, Color.White, "ANULADO", estado)

            'centrar columnas
            With dtgListado.DisplayLayout.Bands(0)
                .Columns(estado).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub
End Class