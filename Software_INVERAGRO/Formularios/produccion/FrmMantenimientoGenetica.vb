Imports CapaDatos
Imports CapaNegocio
Imports CapaObjetos

Public Class FrmMantenimientoGenetica
    Dim cn As New cnControlAnimal
    Dim _Operacion As Integer = 0
    Public _CodGenetica As Integer = 0
    Public _Modulo As String = ""

    Private Sub FrmMantenimientoGenetica_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If _Modulo = "CERDA" Then
                CbxTipo.Items.Add("CERDA")
                CbxTipo.Items.Add("AMBOS")
                CbxTipo.SelectedIndex = 0
            ElseIf _Modulo = "VERRACO" Then
                CbxTipo.Items.Add("VERRACO")
                CbxTipo.Items.Add("AMBOS")
                CbxTipo.SelectedIndex = 0
            End If

            If (_CodGenetica <> 0) Then
                _Operacion = 1
                ConsultarxIdGenetica()
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ConsultarxIdGenetica()
        Try
            Dim obj As New coControlAnimal With {
                .Codigo = _CodGenetica
            }
            Dim dt As New DataTable
            dt = cn.Cn_ConsultarGeneticaxId(obj).Copy
            If (dt.Rows.Count > 0) Then
                TxtCodigo.Text = dt.Rows(0)("categoria").ToString()
                TxtDescripcion.Text = dt.Rows(0)("descripcion").ToString()
                CbxTipo.Text = dt.Rows(0)("tipo").ToString()
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Mantenimiento()
        Try
            If (_Operacion = 0 OrElse _Operacion = 1) AndAlso (TxtCodigo.Text = "" OrElse TxtCodigo.Text.Length = 0) Then
                msj_advert("codigo no Valida")
                Return
            End If

            If (_Operacion = 0 OrElse _Operacion = 1) AndAlso (TxtDescripcion.Text = "" OrElse TxtDescripcion.Text.Length = 0) Then
                msj_advert("Descripción no Valida")
                Return
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE REGISTRAR GENETICA?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coControlAnimal With {
                .Operacion = _Operacion,
                .Codigo = _CodGenetica,
                .Observacion = TxtCodigo.Text,
                .MotivoAnulacion = TxtDescripcion.Text,
                .TipoControl = CbxTipo.Text
            }

            Dim _mensaje As String = cn.Cn_MantenimientoGenetica(obj)

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

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Mantenimiento()
    End Sub

    Private Sub BtnSalir_Click(sender As Object, e As EventArgs) Handles BtnSalir.Click
        Dispose()
    End Sub
End Class