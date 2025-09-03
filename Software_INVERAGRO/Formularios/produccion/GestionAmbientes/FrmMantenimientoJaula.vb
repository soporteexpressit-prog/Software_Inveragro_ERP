Imports CapaNegocio
Imports CapaObjetos

Public Class FrmMantenimientoJaula
    Dim cn As New cnJaulaCorral
    Dim _Operacion As Integer = 0
    Public _CodJaula As Integer = 0
    Public _IdUbicacion As Integer = 0
    Public estadoCapacidad As String = ""
    Public abreviatura As String = ""

    Private Sub FrmJaula_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ListarPlanteles()
            cmbUbicacion.Value = _IdUbicacion
            cmbUbicacion.Enabled = False
            TxtAbreviatura.Text = abreviatura
            ListarSala()
            LblSala.Visible = False
            CmbSala.Visible = False
            If (_CodJaula <> 0) Then
                _Operacion = 1
                ConsultarxIdCorral()
                ChkCargaMasiva.Visible = False
                lblCantidad.Visible = False
                NumCantidad.Visible = False
            Else
                CbxEstado.SelectedIndex = 0
                CbxEstado.Enabled = False
                ChkCargaMasiva.Visible = True
                lblCantidad.Visible = False
                NumCantidad.Visible = False
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

    Sub ListarSala()
        Dim cn As New cnSala
        Dim tb As New DataTable
        tb = cn.Cn_Listar().Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione un Sala"
        With CmbSala
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
                .Codigo = _CodJaula
            }
            Dim dt As New DataTable
            dt = cn.Cn_ConsultarxId(obj).Copy
            If (dt.Rows.Count > 0) Then
                txtDescripcion.Text = dt.Rows(0)("descripcion").ToString()
                CbxEstado.Text = dt.Rows(0)("estado").ToString()
                cmbUbicacion.Value = dt.Rows(0)("idUbicacion").ToString()
                ListarGalpones(cmbUbicacion.Value)
                cmbGalpon.Value = dt.Rows(0)("idGalpon")
                CkxSala.Checked = dt.Rows(0)("idSala") IsNot DBNull.Value
                If CkxSala.Checked Then
                    CmbSala.Value = dt.Rows(0)("idSala")
                End If
                NumCapacidad.Value = dt.Rows(0)("capacidad")
                TxtAbreviatura.Text = dt.Rows(0)("abreviatura")
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub Mantenimiento()
        Try

            If _Operacion = 0 Then
                If ChkCargaMasiva.Checked Then
                    If NumCantidad.Value <= 0 Then
                        msj_advert("Debe ingresar una cantidad mayor a 0.")
                        Return
                    End If

                    If (MessageBox.Show("¿ESTÁ SEGURO DE REGISTRAR " & NumCantidad.Value & " JAULAS?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                        Return
                    End If

                    Dim objCargaMasiva As New coJaulaCorral With {
                        .Cantidad = NumCantidad.Value,
                        .Capacidad = NumCapacidad.Value,
                        .Estado = CbxEstado.Text,
                        .IdGalpon = cmbGalpon.Value,
                        .IdSala = If(CkxSala.Checked, CmbSala.Value, Nothing)
                    }

                    Dim _mensajeCargaMasiva As String = cn.Cn_RegistrarJaulaPorCantidad(objCargaMasiva)

                    If (objCargaMasiva.Coderror = 0) Then
                        msj_ok(_mensajeCargaMasiva)
                        Dispose()
                    Else
                        msj_advert(_mensajeCargaMasiva)
                    End If

                    Return
                End If
            End If

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

            If (MessageBox.Show("¿ESTÁ SEGURO DE REGISTRAR LA JAULA?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coJaulaCorral With {
                .Operacion = _Operacion,
                .Codigo = _CodJaula,
                .Descripcion = txtDescripcion.Text,
                .Capacidad = NumCapacidad.Value,
                .Estado = CbxEstado.Text,
                .IdGalpon = cmbGalpon.Value,
                .IdSala = If(CkxSala.Checked, CmbSala.Value, Nothing),
                .Tipo = "JAULA",
                .Abreviatura = TxtAbreviatura.Text
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

    Private Sub CkxSala_CheckedChanged(sender As Object, e As EventArgs) Handles CkxSala.CheckedChanged
        If (CkxSala.Checked) Then
            LblSala.Visible = True
            CmbSala.Visible = True
        Else
            LblSala.Visible = False
            CmbSala.Visible = False
        End If
    End Sub

    Private Sub ChkCargaMasiva_CheckedChanged(sender As Object, e As EventArgs) Handles ChkCargaMasiva.CheckedChanged
        If (ChkCargaMasiva.Checked) Then
            lblDescripcion.Visible = False
            txtDescripcion.Visible = False
            lblAbreviatura.Visible = False
            TxtAbreviatura.Visible = False
            lblCantidad.Visible = True
            NumCantidad.Visible = True
            NumCantidad.Focus()
        Else
            lblDescripcion.Visible = True
            txtDescripcion.Visible = True
            lblAbreviatura.Visible = True
            TxtAbreviatura.Visible = True
            lblCantidad.Visible = False
            NumCantidad.Visible = False
        End If
    End Sub

    Private Sub cmbUbicacion_ValueChanged(sender As Object, e As EventArgs) Handles cmbUbicacion.ValueChanged
        Try
            ListarGalpones(cmbUbicacion.Value)
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnGuardarPcorr_Click(sender As Object, e As EventArgs) Handles btnGuardarPcorr.Click
        Mantenimiento()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class