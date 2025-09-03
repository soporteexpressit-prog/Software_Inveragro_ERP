Imports CapaNegocio
Imports CapaObjetos

Public Class FrmCroquisPlantel4
    Dim cn As New cnJaulaCorral
    Dim ds As New DataSet

    Private Sub FrmCroquisPlantel4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            Ptbx_Cargando.Visible = True

            Dim obj As New coJaulaCorral With {
                .IdUbicacion = 7
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coJaulaCorral = CType(e.Argument, coJaulaCorral)

            ds = cn.Cn_ConsultarAnimalesCroquis(obj).Copy
            ds.DataSetName = "tmp"
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
            Dim contenedores() As FlowLayoutPanel = {Galpon01, Galpon02, Galpon03, Galpon04, Galpon05, Galpon06, Galpon07, Galpon08, Galpon09}
            Dim lblTotalAniGalpon() As Label = {LblTotalAniGalpon1, LblTotalAniGalpon2, LblTotalAniGalpon3, LblTotalAniGalpon4, LblTotalAniGalpon5, LblTotalAniGalpon6, LblTotalAniGalpon7, LblTotalAniGalpon8, LblTotalAniGalpon9}
            Dim lblTotalCorrGalpon() As Label = {LblTotalCorrGalpon1, LblTotalCorrGalpon2, LblTotalCorrGalpon3, LblTotalCorrGalpon4, LblTotalCorrGalpon5, LblTotalCorrGalpon6, LblTotalCorrGalpon7, LblTotalCorrGalpon8, LblTotalCorrGalpon9}
            Dim galponData As DataTable = ds.Tables(0)
            Dim galpones As New Dictionary(Of String, List(Of DataRow))()
            Dim cantidadesAniGalpon As New List(Of Integer)()
            Dim cantidadesCorrCorrales As New List(Of Integer)()

            If ds.Tables.Count > 1 AndAlso ds.Tables(1).Rows.Count > 0 Then
                LblTotalCorrales.Text = CInt(ds.Tables(1).Rows(0)("Cantidad de Corrales"))
                LblCapacidadTotal.Text = CInt(ds.Tables(1).Rows(0)("Capacidad Total"))
                LblTotalAniGranja.Text = CInt(ds.Tables(1).Rows(0)("Cantidad Total de Animales"))
                LblDensidadxCorral.Text = CDec(ds.Tables(1).Rows(0)("Densidad por Corral")).ToString("F2")
            End If

            For Each fila As DataRow In galponData.Rows
                Dim galpon As String = fila("Galpón").ToString()
                Dim cantidadAniGalpon As Integer = fila("Cantidad Animal Galpón")
                Dim cantidadCorrales As Integer = fila("Cantidad Corrales")

                If Not galpones.ContainsKey(galpon) Then
                    galpones(galpon) = New List(Of DataRow)()
                    cantidadesAniGalpon.Add(cantidadAniGalpon)
                    cantidadesCorrCorrales.Add(cantidadCorrales)
                End If
                galpones(galpon).Add(fila)
            Next

            For i As Integer = 0 To contenedores.Length - 1
                contenedores(i).Controls.Clear() ' Limpia el contenido del contenedor actual
                contenedores(i).AutoScroll = True ' Habilitar scroll para este FlowLayoutPanel
                contenedores(i).FlowDirection = FlowDirection.LeftToRight ' Ordenar de izquierda a derecha
                contenedores(i).WrapContents = True ' Permitir que los elementos se ajusten en filas

                If i < galpones.Count Then
                    Dim galponNombre As String = galpones.Keys(i)

                    ' Crear un Label como encabezado para el galpón
                    Dim labelGalpon As New Label()
                    labelGalpon.Text = galponNombre
                    labelGalpon.Font = New Font("Arial", 10, FontStyle.Bold)
                    labelGalpon.Width = contenedores(i).Width
                    labelGalpon.TextAlign = ContentAlignment.MiddleCenter
                    labelGalpon.Margin = New Padding(0, 6, 0, 0)

                    contenedores(i).Controls.Add(labelGalpon) ' Agrega el encabezado al contenedor

                    If i < lblTotalAniGalpon.Length Then
                        lblTotalAniGalpon(i).Text = cantidadesAniGalpon(i).ToString()
                        lblTotalCorrGalpon(i).Text = cantidadesCorrCorrales(i).ToString()
                    End If

                    ' Crear y agregar los paneles de corrales al FlowLayoutPanel
                    For Each corralFila As DataRow In galpones(galponNombre)
                        Dim corralPanel As New Panel()
                        corralPanel.Size = New Size(60, 45) ' Ajusta el tamaño según tu preferencia
                        corralPanel.BorderStyle = BorderStyle.FixedSingle
                        corralPanel.Margin = New Padding(5)

                        Dim cantidadAnimales As Integer = Convert.ToInt32(corralFila("Cantidad Animales"))
                        Dim limiteAnimales As Integer = Convert.ToInt32(corralFila("Límite de Animales"))

                        If cantidadAnimales = 0 Then
                            corralPanel.BackColor = Color.White ' Celda vacía
                        ElseIf cantidadAnimales < limiteAnimales Then
                            corralPanel.BackColor = Color.Red
                            corralPanel.ForeColor = Color.White
                            corralPanel.Font = New Font(corralPanel.Font, FontStyle.Bold)
                        Else
                            corralPanel.BackColor = ColorTranslator.FromHtml("#9AEBA3") ' Celda llena, pinta de color verde claro
                        End If

                        ' Crear y configurar un Label para mostrar la información del corral
                        Dim labelCorral As New Label With {
                            .Text = corralFila("Corral / Jaula").ToString() & vbCrLf & "N°: " & corralFila("Cantidad Animales").ToString() & vbCrLf & corralFila("largo").ToString() & " x " & corralFila("ancho").ToString(),
                            .Dock = DockStyle.Fill,
                            .TextAlign = ContentAlignment.MiddleCenter
                        }

                        corralPanel.Controls.Add(labelCorral)
                        contenedores(i).Controls.Add(corralPanel)
                    Next
                End If
            Next
        End If
    End Sub

    Private Sub PanelPrincipal_Paint(sender As Object, e As PaintEventArgs) Handles PanelPrincipal.Paint

    End Sub
End Class