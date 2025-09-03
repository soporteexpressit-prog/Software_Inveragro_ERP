Imports CapaNegocio
Imports CapaObjetos

Public Class FrmCroquisPlantel2
    Dim cn As New cnJaulaCorral
    Dim ds As New DataSet

    Private Sub FrmCroquisPlantel2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                .IdUbicacion = 2
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coJaulaCorral = CType(e.Argument, coJaulaCorral)

            ds = cn.Cn_ConsultarAnimalesCroquisReproduccion(obj).Copy
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
            Dim contenedores() As FlowLayoutPanel = {Galpon01_1, Galpon01_2, Galpon02_1, Galpon02_2, Galpon03_1, Galpon03_2, Galpon04_1, Galpon04_2, Galpon05_1, Galpon05_2, Galpon06, Galpon07, Galpon08}
            Dim lblTotalAniGalpon() As Label = {LblTotalAniGalpon1_1, LblTotalAniGalpon1_2, LblTotalAniGalpon2_1, LblTotalAniGalpon2_2, LblTotalAniGalpon3_1, LblTotalAniGalpon3_2, LblTotalAniGalpon4_1, LblTotalAniGalpon4_2, LblTotalAniGalpon5_1, LblTotalAniGalpon5_2, LblTotalAniGalpon6, LblTotalAniGalpon7, LblTotalAniGalpon8}
            Dim lblTotalCorrGalpon() As Label = {LblTotalCorrGalpon1_1, LblTotalCorrGalpon1_2, LblTotalCorrGalpon2_1, LblTotalCorrGalpon2_2, LblTotalCorrGalpon3_1, LblTotalCorrGalpon3_2, LblTotalCorrGalpon4_1, LblTotalCorrGalpon4_2, LblTotalCorrGalpon5_1, LblTotalCorrGalpon5_2, LblTotalCorrGalpon6, LblTotalCorrGalpon7, LblTotalCorrGalpon8}
            Dim galponData As DataTable = ds.Tables(0)
            Dim galpones As New Dictionary(Of String, List(Of DataRow))()
            Dim cantidadesAniGalpon As New List(Of Integer)()
            Dim cantidadesCorrCorrales As New List(Of Integer)()

            If ds.Tables.Count > 1 AndAlso ds.Tables(1).Rows.Count > 0 Then
                LblTotalCorrales.Text = CInt(ds.Tables(1).Rows(0)("Cantidad de Corrales"))
                LblTotalJaulas.Text = CInt(ds.Tables(1).Rows(0)("Cantidad de Jaulas"))
                LblCapacidadTotal.Text = CInt(ds.Tables(1).Rows(0)("Capacidad Total"))
                LblTotalAniGranja.Text = CInt(ds.Tables(1).Rows(0)("Cantidad Total de Animales"))
                LblDensidadxCorral.Text = CDec(ds.Tables(1).Rows(0)("Densidad por Corral")).ToString("F2")
            End If

            For Each fila As DataRow In galponData.Rows
                Dim galpon As String = fila("Galpón").ToString()
                Dim sala As String = fila("Sala").ToString()
                Dim area As String = fila("Área").ToString()
                Dim galponSala As String = $"{galpon} / {sala} / {area}" ' Combinar galpón y sala
                Dim cantidadAniGalpon As Integer = fila("Cantidad Animal Galpón y Sala")
                Dim cantidadCorrales As Integer = fila("Cantidad Corrales")

                If Not galpones.ContainsKey(galponSala) Then
                    galpones(galponSala) = New List(Of DataRow)()
                    cantidadesAniGalpon.Add(cantidadAniGalpon)
                    cantidadesCorrCorrales.Add(cantidadCorrales)
                End If
                galpones(galponSala).Add(fila)
            Next

            For i As Integer = 0 To contenedores.Length - 1
                contenedores(i).Controls.Clear() ' Limpia el contenido del contenedor actual
                contenedores(i).AutoScroll = True ' Habilitar scroll para este FlowLayoutPanel
                contenedores(i).FlowDirection = FlowDirection.LeftToRight ' Ordenar de izquierda a derecha
                contenedores(i).WrapContents = True ' Permitir que los elementos se ajusten en filas

                If i < galpones.Count Then
                    Dim galponSalaNombre As String = galpones.Keys(i)

                    ' Crear un Label como encabezado para el galpón y la sala
                    Dim labelGalpon As New Label With {
                        .Text = galponSalaNombre, ' Nombre en formato "GAL-1 / SALA 1"
                        .Font = New Font("Arial", 10, FontStyle.Bold),
                        .Width = contenedores(i).Width,
                        .TextAlign = ContentAlignment.MiddleCenter,
                        .Margin = New Padding(0, 6, 0, 0)
                    }

                    contenedores(i).Controls.Add(labelGalpon) ' Agrega el encabezado al contenedor

                    If i < lblTotalAniGalpon.Length Then
                        lblTotalAniGalpon(i).Text = cantidadesAniGalpon(i).ToString()
                        lblTotalCorrGalpon(i).Text = cantidadesCorrCorrales(i).ToString()
                    End If

                    For Each corralFila As DataRow In galpones(galponSalaNombre)
                        Dim corralPanel As New Panel()

                        ' Verificar si es "VARIAS JAULAS" para ajustar el tamaño
                        If corralFila("Corral / Jaula").ToString() = "VARIAS JAULAS" Then
                            corralPanel.Size = New Size(160, 45) ' Más ancho para varias jaulas
                        Else
                            corralPanel.Size = New Size(60, 45) ' Tamaño estándar
                        End If

                        corralPanel.BorderStyle = BorderStyle.FixedSingle
                        corralPanel.Margin = New Padding(5)

                        Dim cantidadAnimales As Integer = Convert.ToInt32(corralFila("Cantidad Animales"))
                        If cantidadAnimales = 0 Then
                            corralPanel.BackColor = Color.White
                        Else
                            corralPanel.BackColor = ColorTranslator.FromHtml("#9AEBA3") ' Celda llena , pinta de color verde claro
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
End Class