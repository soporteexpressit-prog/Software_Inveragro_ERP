Imports CapaNegocio
Imports CapaObjetos

Public Class FrmFichaCicloVidaVerraco
    Dim cn As New cnControlAnimal
    Dim cnMaterialGenetico As New cnControlMaterialGenetico
    Dim ds As New DataSet
    Public idVerraco As Integer = 0
    Dim aplicacionInossure As String = ""

    Private Sub FrmFichaCicloVidaVerraco_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            ConsultarxIdVerraco()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        AddHandler HistorialMedicacion.Enter, AddressOf HistorialMedico_Enter
        AddHandler HistoricoExtraccion.Enter, AddressOf HistoricoExtraccion_Enter
        dtpFechaDesdeControlMedico.Value = Now.Date
        dtpFechaHastaControlMedico.Value = Now.Date
        DtpFechaDesdeExtraccion.Value = Now.Date
        DtpFechaDesdeExtraccion.Value = Now.Date
        LblNumDosis.Visible = False
        NumDosis.Visible = False
    End Sub

    Sub ConsultarxIdVerraco()
        Try
            Dim obj As New coControlAnimal With {
                .Codigo = idVerraco
            }
            Dim dt As New DataTable
            dt = cn.Cn_ConsultarGeneralAnimalxId(obj).Copy
            If (dt.Rows.Count > 0) Then
                LblCodArete.Text = dt.Rows(0)("codArete").ToString()
                LblCodAreteMadre.Text = dt.Rows(0)("codAreteMadre").ToString()
                LblEstado.Text = dt.Rows(0)("estadoVida").ToString()
                LblFechaNacimiento.Text = dt.Rows(0)("fNacimiento").ToString()
                LblLineaGenetica.Text = dt.Rows(0)("genetica").ToString()
                LblPeso.Text = dt.Rows(0)("peso").ToString()
                LblDiasVida.Text = dt.Rows(0)("diasVida").ToString()
                LblClasificacion.Text = dt.Rows(0)("clasificacion").ToString()
                LblNumExtracciones.Text = dt.Rows(0)("numExtracciones").ToString()
                LblEstadoExtraccion.Text = dt.Rows(0)("estadoExtraccion").ToString()
                LblCondReproductiva.Text = dt.Rows(0)("condReproductiva").ToString()
                LblUbicacion.Text = dt.Rows(0)("ubicacion").ToString()
                LblTipoAdquisicion.Text = dt.Rows(0)("tipoAdquisicion").ToString()
                aplicacionInossure = dt.Rows(0)("Estado Aplicación").ToString()
                LblAplicadoInossure.Text = aplicacionInossure

                If aplicacionInossure = "APLICADO" Then
                    LblNumDosis.Visible = True
                    NumDosis.Visible = True
                    NumDosis.Text = dt.Rows(0)("Número de Dosis").ToString()
                    LblAplicadoInossure.Visible = False
                End If

                If (LblEstado.Text = "VIVO") Then
                        LblEstado.BackColor = Color.Green
                        LblEstado.ForeColor = Color.White
                    Else
                        LblEstado.BackColor = Color.Red
                        LblEstado.ForeColor = Color.White
                    End If

                    If (LblCondReproductiva.Text = "APTO") Then
                        LblCondReproductiva.BackColor = Color.LightGreen
                        LblCondReproductiva.ForeColor = Color.DarkGreen
                    ElseIf (LblCondReproductiva.Text = "NO APTO") Then
                        LblCondReproductiva.BackColor = Color.LightCoral
                        LblCondReproductiva.ForeColor = Color.White
                    End If
                End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub HistorialMedico_Enter(sender As Object, e As EventArgs)
        ConsultarHistorialMedicoxIdVerraco()
    End Sub

    Private Sub BtnBuscarControlMedico_Click(sender As Object, e As EventArgs) Handles BtnBuscarControlMedico.Click
        ConsultarHistorialMedicoxIdVerraco()
    End Sub

    Private Sub ConsultarHistorialMedicoxIdVerraco()
        Try
            If dtpFechaDesdeControlMedico.Value > dtpFechaHastaControlMedico.Value Then
                msj_advert(MensajesSistema.mensajesGenerales("FECHA_INICIO_MAYOR_FIN"))
                Return
            End If

            Dim obj As New coControlAnimal With {
                .Codigo = idVerraco,
                .FechaDesde = dtpFechaDesdeControlMedico.Value,
                .FechaHasta = dtpFechaHastaControlMedico.Value
            }

            ds = cn.Cn_ConsultarMedicacionxIdAnimal(obj).Copy
            ds.DataSetName = "tmp"

            Dim relation1 As New DataRelation("tb_relacion1", ds.Tables.Item(0).Columns.Item(0), ds.Tables.Item(1).Columns.Item(0), False)

            ds.Relations.Add(relation1)
            dtgListadoMedicacion.DataSource = ds
            clsBasicas.Formato_Tablas_Grid(dtgListadoMedicacion)
            clsBasicas.Colorear_SegunValor(dtgListadoMedicacion, Color.Green, Color.White, "APLICADO", 5)
            clsBasicas.Colorear_SegunValor(dtgListadoMedicacion, Color.Red, Color.White, "CANCELADO", 5)
            dtgListadoMedicacion.DisplayLayout.Bands(0).Columns(0).Hidden = True
            dtgListadoMedicacion.DisplayLayout.Bands(1).Columns(0).Hidden = True
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub HistoricoExtraccion_Enter(sender As Object, e As EventArgs)
        ConsultarHistoricoExtraccionxIdVerraco()
    End Sub

    Private Sub ConsultarHistoricoExtraccionxIdVerraco()
        Try
            If DtpFechaDesdeExtraccion.Value > DtpFechaHastaExtraccion.Value Then
                msj_advert(MensajesSistema.mensajesGenerales("FECHA_INICIO_MAYOR_FIN"))
                Return
            End If

            Dim obj As New coControlMaterialGenetico With {
                .FechaDesde = DtpFechaDesdeExtraccion.Value,
                .FechaHasta = DtpFechaHastaExtraccion.Value,
                .IdVerraco = idVerraco
            }
            dtgListadoExtraccion.DataSource = cnMaterialGenetico.Cn_ConsultarExtraccionesxIdVerraco(obj)
            clsBasicas.Colorear_SegunValor(dtgListadoExtraccion, Color.LightGreen, Color.DarkGreen, "ÓPTIMO", 10)
            clsBasicas.Colorear_SegunValor(dtgListadoExtraccion, Color.LightYellow, Color.Goldenrod, "PRÓXIMO VENCER", 10)
            clsBasicas.Colorear_SegunValor(dtgListadoExtraccion, Color.MistyRose, Color.IndianRed, "NO ÓPTIMO", 10)
            clsBasicas.Colorear_SegunValor(dtgListadoExtraccion, Color.Red, Color.White, "CERRADO", 10)
            clsBasicas.Formato_Tablas_Grid(dtgListadoExtraccion)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub BtnBuscarExtraccion_Click(sender As Object, e As EventArgs) Handles BtnBuscarExtraccion.Click
        ConsultarHistoricoExtraccionxIdVerraco()
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class