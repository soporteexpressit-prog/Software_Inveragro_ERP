Imports CapaDatos
Imports CapaNegocio
Imports CapaObjetos

Public Class FrmObjetivoPartos
    Dim cn As New cnControlLoteDestete
    Public idPlantel As Integer = 0
    Private search As Boolean = False

    Private Sub FrmObjetivoPartos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            ListarLotes()
            ConsultarxId()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        clsBasicas.LlenarComboAnios(CmbAnios)
    End Sub

    Sub ListarLotes()
        Dim cn As New cnControlLoteDestete
        Dim obj As New coControlLoteDestete With {
           .Anio = CmbAnios.Text,
           .idPlantel = idPlantel
        }
        Dim tb As New DataTable
        tb = cn.Cn_ConsultarLotesAnioCombo(obj).Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione un Plantel"
        With CmbLotes
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
        search = True
    End Sub

    Sub ConsultarxId()
        Try
            Dim obj As New coControlLoteDestete With {
                .IdLote = CmbLotes.Value
            }
            Dim dt As New DataTable
            dt = cn.Cn_ConsultarMetaPartoxLote(obj).Copy
            If (dt.Rows.Count > 0) Then
                NumNuevaCantidad.Value = dt.Rows(0)("metaPartos")
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub CmbAnios_TextChanged(sender As Object, e As EventArgs) Handles CmbAnios.TextChanged
        If (search) Then
            ListarLotes()
        End If
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            If (NumNuevaCantidad.Value <= 0) Then
                msj_advert("El objetivo debe ser mayor a 0")
                Return
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE REGISTRAR ESTE OBJETIVO?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coControlLoteDestete With {
                .IdLote = CmbLotes.Value,
                .Meta = NumNuevaCantidad.Value
            }

            Dim mensaje As String = cn.Cn_ActualizarMetaPartos(obj)
            If (obj.Coderror = 0) Then
                msj_ok(mensaje)
            Else
                msj_advert(mensaje)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub CmbLotes_ValueChanged(sender As Object, e As EventArgs) Handles CmbLotes.ValueChanged
        ConsultarxId()
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class