Imports CapaNegocio
Imports CapaObjetos

Public Class FrmModificarCampaña
    Dim cn As New cnControlAlimento
    Public idUbicacion As Integer = 0
    Public idPedido As Integer = 0
    Public valorPlantel As String = ""

    Private Sub FrmModificarCampaña_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            LblPlantel.Text = valorPlantel
            clsBasicas.LlenarComboAnios(CmbAnios)

            ListarCampañas()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ListarCampañas()
        Dim cn As New cnUbicacion
        Dim tb As New DataTable
        Dim obj As New coUbicacion With {
            .Codigo = idUbicacion,
            .Anio = CmbAnios.Text
        }
        tb = cn.Cn_ListarCampañas(obj).Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione un Plantel"
        With CmbCampaña
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            If (MessageBox.Show("¿ESTÁ SEGURO DE MODIFICAR LA CAMPAÑA DE ESTE PLANTEL?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coControlAlimento With {
                .Codigo = idPedido,
                .IdCampana = CmbCampaña.Value
            }

            Dim _mensaje As String = cn.Cn_ModificarCampañaPedido(obj)
            If (obj.Coderror = 0) Then
                msj_ok(_mensaje)
                Dispose()
            Else
                msj_advert(_mensaje)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dispose()
    End Sub
End Class