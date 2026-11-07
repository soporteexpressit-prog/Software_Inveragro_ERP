Imports CapaNegocio
Imports CapaObjetos

Public Class FrmRkcTrabajadoresxArea
    Dim cn As New cnControlAnimal
    Dim tbtmp As New DataTable
    Public IdCampaña As Integer
    Public IdsArea As String

    Private Sub FrmRkcTrabajadoresxArea_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If (IdsArea = "1") Then
                LblNombreArea.Text = "MATERNIDAD"
            ElseIf (IdsArea = "11,2") Then
                LblNombreArea.Text = "CHANCHILLA / GESTACIÓN"
            ElseIf (IdsArea = "3") Then
                LblNombreArea.Text = "RECRÍA"
            ElseIf (IdsArea = "4") Then
                LblNombreArea.Text = "ENGORDE"
            End If
            clsBasicas.Formato_Tablas_Grid(dtgListado)
            Consultar()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub Consultar()
        If Not BackgroundWorker1.IsBusy Then
            Dim obj As New coControlAnimal With {
                .IdCampaña = IdCampaña,
                .ListaItems = IdsArea
            }

            BackgroundWorker1.RunWorkerAsync(obj)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim obj As coControlAnimal = CType(e.Argument, coControlAnimal)
            tbtmp = cn.Cn_ConsultarPersonaxArea(obj).Copy
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
            dtgListado.DataSource = CType(e.Result, DataTable)
        End If
    End Sub
End Class