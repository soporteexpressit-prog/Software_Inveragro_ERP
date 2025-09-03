Imports CapaNegocio
Imports CapaObjetos

Public Class FrmVisualizarDesteteHembra
    Dim cn As New cnControlLoteDestete
    Public idControlFicha As Integer
    Dim tbtmp As New DataTable
    Dim mensaje As String

    Private Sub FrmVisualizarDesteteHembra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Label10.Text = "Peso (X" & ChrW(&H305) & ") Destete:"
            Consultar()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            Dim obj As New coControlLoteDestete With {
                .IdControlFicha = idControlFicha
            }
            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlLoteDestete = CType(e.Argument, coControlLoteDestete)
            tbtmp = cn.Cn_ConsultarInformacionDestete(obj).Copy
            tbtmp.TableName = "tmp"
            e.Result = tbtmp
        Catch ex As Exception
            e.Cancel = True
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If e.Error IsNot Nothing OrElse e.Cancelled Then
            msj_advert("Error al Cargar los Datos")
        Else
            Dim dt As DataTable = CType(e.Result, DataTable)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Dim row As DataRow = dt.Rows(0)

                LblFechaControl.Text = Format(CDate(row("fControl")), "dd/MM/yyyy")
                LblNacidosMachos.Text = row("totalNacidosMachos").ToString()
                LblNacidosHembras.Text = row("totalNacidosHembras").ToString()
                LblResponsable.Text = row("datos").ToString()
                LblLote.Text = row("numLote").ToString()
                LblCodCerdo.Text = row("codCerdo").ToString()
                LblCondCorporal.Text = row("condCorporal").ToString()
                LblPesoDestete.Text = Format(CDec(row("pesoDestete")), "0.00")
                LblPromDestete.Text = Format(CDec(row("pesoPromDestete")), "0.00")
                LblDestetoNodriza.Text = row("destetoNodriza").ToString()
                LblPlantel.Text = row("plantel").ToString()
                LblArea.Text = row("area").ToString()

                mensaje = "El destete registro " & row("numPuras").ToString() & " puras y " & row("numCambor").ToString() & " camborough."
                LblMensaje.Text = mensaje

                If LblDestetoNodriza.Text = "SI" Then
                    LblDestetoNodriza.BackColor = Color.Red
                    LblDestetoNodriza.ForeColor = Color.White
                ElseIf LblDestetoNodriza.Text = "NO" Then
                    LblDestetoNodriza.BackColor = Color.Green
                    LblDestetoNodriza.ForeColor = Color.White
                Else
                    LblDestetoNodriza.BackColor = Color.LightGray
                    LblDestetoNodriza.ForeColor = Color.Black
                End If
            Else
                msj_advert("No se encontraron datos para el ID ingresado")
            End If

        End If
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Dispose()
    End Sub
End Class