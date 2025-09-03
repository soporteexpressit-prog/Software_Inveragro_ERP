Imports CapaNegocio
Imports CapaObjetos

Public Class FrmMantenimientoCorral
    Dim cn As New cnJaulaCorral
    Dim _Operacion As Integer = 0
    Public _CodCorral As Integer = 0
    Public _Densidad As Decimal = 0
    Public _IdUbicacion As Integer = 0
    Public estadoCapacidad As String = ""

    Private Sub FrmCorral_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            TxtAncho.Text = "1"
            TxtLargo.Text = "1"
            ListarPlanteles()
            cmbUbicacion.Value = _IdUbicacion
            cmbUbicacion.Enabled = False
            LblDensidad.Text = _Densidad.ToString("F3")
            If (_CodCorral <> 0) Then
                _Operacion = 1
                ConsultarxIdCorral()
            Else
                CbxEstado.SelectedIndex = 0
                CbxEstado.Enabled = False
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ListarPlanteles()
        Dim cn As New cnUbicacion
        Dim tb As New DataTable
        tb = cn.Cn_ListarPlanteles().Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione un Plantel"
        With cmbUbicacion
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Sub ListarGalpones(idplantel As Integer)
        Dim cn As New cnGalpon
        Dim tb As New DataTable
        Dim obj As New coGalpon
        obj.IdUbicacion = idplantel
        tb = cn.Cn_Listar_Galpones_Por_Plantel(obj).Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione un Galpón"
        With cmbGalpon
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Sub ConsultarxIdCorral()
        Try
            Dim obj As New coJaulaCorral With {
                .Codigo = _CodCorral
            }
            Dim dt As New DataTable
            dt = cn.Cn_ConsultarxId(obj).Copy
            If (dt.Rows.Count > 0) Then
                txtDescripcion.Text = dt.Rows(0)("descripcion").ToString()
                CbxEstado.Text = dt.Rows(0)("estado").ToString()
                cmbUbicacion.Value = dt.Rows(0)("idUbicacion").ToString()
                ListarGalpones(cmbUbicacion.Value)
                cmbGalpon.Value = dt.Rows(0)("idGalpon")
                NumCapacidad.Value = dt.Rows(0)("capacidad")
                TxtAncho.Text = dt.Rows(0)("ancho")
                TxtLargo.Text = dt.Rows(0)("largo")
                TxtAbreviatura.Text = dt.Rows(0)("abreviatura").ToString()
                ChxClinica.Checked = If(dt.Rows(0)("esClinica").ToString() = "SI", True, False)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Mantenimiento()
        Try
            If (_Operacion = 0 OrElse _Operacion = 1) AndAlso (txtDescripcion.Text = "" OrElse txtDescripcion.Text.Length = 0) Then
                msj_advert("Descripción no Valida")
                Return
            End If

            If (_Operacion = 0 OrElse _Operacion = 1) AndAlso (TxtAbreviatura.Text = "" OrElse TxtAbreviatura.Text.Length = 0) Then
                msj_advert("Abreviatura no Valida")
                Return
            End If

            If (estadoCapacidad <> "LIBRE" AndAlso CbxEstado.Text = "INACTIVO") Then
                msj_advert("No se puede cambiar el estado a INACTIVO, debido a que la capacidad de la jaula esta en estado " & estadoCapacidad)
                Return
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE ESTA ACCIÓN?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coJaulaCorral With {
                .Operacion = _Operacion,
                .Codigo = _CodCorral,
                .Descripcion = txtDescripcion.Text,
                .Capacidad = NumCapacidad.Value,
                .Estado = CbxEstado.Text,
                .IdGalpon = cmbGalpon.Value,
                .IdSala = Nothing,
                .Tipo = "CORRAL",
                .Largo = CDec(TxtLargo.Text),
                .Ancho = CDec(TxtAncho.Text),
                .Abreviatura = TxtAbreviatura.Text,
                .esClinica = If(ChxClinica.Checked, "SI", "NO")
            }

            Dim _mensaje As String = cn.Cn_Mantenimiento(obj)
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

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardarPcorr.Click
        Mantenimiento()
    End Sub

    Private Sub cmbUbicacion_ValueChanged(sender As Object, e As EventArgs) Handles cmbUbicacion.ValueChanged
        Try
            ListarGalpones(cmbUbicacion.Value)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub NumCapacidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles NumCapacidad.KeyPress
        clsBasicas.ValidarNumeros(e)
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub

    Private Sub TxtAncho_TextChanged(sender As Object, e As EventArgs) Handles TxtAncho.TextChanged
        If TxtAncho.Text <> "" And TxtAncho.Text <> "1" Then
            If CInt(TxtAncho.Text) > 0 Then
                Dim ancho As Decimal = Convert.ToDecimal(TxtAncho.Text)
                Dim largo As Decimal = Convert.ToDecimal(TxtLargo.Text)
                Dim capacidad As Decimal = (ancho * largo) / CDec(LblDensidad.Text) + 5
                If capacidad > 1000 Then
                    TxtAncho.Text = "1"
                    TxtLargo.Text = "1"
                    NumCapacidad.Value = 0
                    msj_advert("La capacidad no puede ser mayor a 1000")
                Else
                    NumCapacidad.Value = capacidad
                    LblDensidadRecomendada.Text = "Capacidad Recomendada: " & capacidad.ToString("F2") & " cerdos/m2"
                End If
            Else
                TxtAncho.Text = "1"
            End If
        Else
            TxtAncho.Text = "1"
        End If
    End Sub

    Private Sub TxtLargo_TextChanged(sender As Object, e As EventArgs) Handles TxtLargo.TextChanged
        If TxtLargo.Text <> "" And TxtLargo.Text <> "1" Then
            If CInt(TxtAncho.Text) > 0 Then
                Dim ancho As Decimal = Convert.ToDecimal(TxtAncho.Text)
                Dim largo As Decimal = Convert.ToDecimal(TxtLargo.Text)
                Dim capacidad As Decimal = (ancho * largo) / CDec(LblDensidad.Text) + 5
                If capacidad > 1000 Then
                    TxtAncho.Text = "1"
                    TxtLargo.Text = "1"
                    NumCapacidad.Value = 0
                    msj_advert("La capacidad no puede ser mayor a 1000")
                Else
                    NumCapacidad.Value = capacidad
                    LblDensidadRecomendada.Text = "Capacidad Recomendada: " & capacidad.ToString("F2") & " cerdos/m2"
                End If
            Else
                TxtAncho.Text = "1"
            End If
        Else
            TxtLargo.Text = "1"
        End If
    End Sub

    Private Sub TxtAncho_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtAncho.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub TxtLargo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtLargo.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub
End Class