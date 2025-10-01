Imports CapaDatos
Imports CapaNegocio
Imports CapaObjetos

Public Class FrmMantenimientoGalpon
    Dim cn As New cnGalpon
    Public _IdGalpon As Integer = 0
    Private _Operacion As Integer = 0

    Private Sub FrmMantenimientoGalpon_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Inicializar()
            ListarPlanteles()
            ListarAreas()
            If (_IdGalpon <> 0) Then
                _Operacion = 1
                ConsultarxIdUbicacion()
            Else
                _Operacion = 0
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        TxtDescripcion.Clear()
        TxtDescripcion.Clear()
        CkxEsEmbarcadero.Checked = False
    End Sub

    Sub ListarPlanteles()
        Dim cn As New cnUbicacion
        Dim tb As New DataTable
        tb = cn.Cn_ListarPlanteles().Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione un Plantel"
        With CmbUbicacion
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Sub ListarAreas()
        Dim cn As New cnArea
        Dim tb As New DataTable
        tb = cn.Cn_Listar().Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione una Área"
        With CmbArea
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Sub ConsultarxIdUbicacion()
        Try
            Dim obj As New coGalpon With {
                .Codigo = _IdGalpon
            }
            Dim dt As New DataTable
            dt = cn.Cn_ConsultarxId(obj).Copy
            If (dt.Rows.Count > 0) Then
                TxtDescripcion.Text = dt.Rows(0)("descripcion").ToString()
                CmbUbicacion.Value = CInt(dt.Rows(0)("idUbicacion").ToString())
                CmbArea.Value = CInt(dt.Rows(0)("idArea").ToString())
                CkxEsEmbarcadero.Checked = dt.Rows(0)("esEmbarcadero").ToString() = "SI"
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnGuardarPcorr_Click(sender As Object, e As EventArgs) Handles btnGuardarPcorr.Click
        Mantenimiento()
    End Sub

    Sub Mantenimiento()
        Try
            Dim _mensaje As String = ""
            If (_Operacion = 0 OrElse _Operacion = 1) AndAlso (TxtDescripcion.Text = "" OrElse TxtDescripcion.Text.Length = 0) Then
                msj_advert("Descripción no Valida")
                Return
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE ESTA ACCIÓN?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coGalpon With {
                .Operacion = _Operacion,
                .Codigo = _IdGalpon,
                .Descripcion = TxtDescripcion.Text,
                .IdArea = CmbArea.Value,
                .IdUbicacion = CmbUbicacion.Value,
                .EsEmbarcadero = If(CkxEsEmbarcadero.Checked, "SI", "NO")
            }

            _mensaje = cn.Cn_Mantenimiento(obj)
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

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class