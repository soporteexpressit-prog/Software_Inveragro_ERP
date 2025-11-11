Imports CapaDatos
Imports CapaNegocio
Imports CapaObjetos

Public Class FrmNuevoAlimento
    Public idPlantel As Integer = 0
    Public valorPlantel As String
    Dim cn As New cnControlAlimento
    Dim cn2 As New cnJaulaCorral
    Dim codAlimento As Integer = 0
    Dim codGalpon As Integer = 0
    Dim idLote As Integer = 0
    Public SelectedGalponCorral As New HashSet(Of Integer)
    Private actualizarDesdeCodigo As Boolean = False
    Private idUnidadMedida As Integer = 0


    Private Sub FrmNuevoAlimento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ListarGalpones()
            Inicializar()
            ListarCampañasActivas()
            ListarAreas()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        CbxAnti.Checked = False
        txtAlimento.ReadOnly = True
        lblPlantel.Text = valorPlantel
        LblLote.Visible = False
        TxtLote.Visible = False
        BtnBuscarLote.Visible = False
        TxtLote.ReadOnly = True
        If idPlantel = 1 Or idPlantel = 2 Then
            CmbCampaña.Visible = False
            LblCampaña.Visible = False
            CbxLote.Checked = True
        Else
            CmbCampaña.Visible = True
            LblCampaña.Visible = True
            LblArea.Visible = False
            cmbArea.Visible = False
        End If
        CbxLote.Visible = False
    End Sub

    Sub ListarGalpones()
        Try
            Dim cn As New cnGalpon
            Dim tb As New DataTable
            Dim obj As New coGalpon With {
                .IdUbicacion = idPlantel
            }
            tb = cn.Cn_ConsGalponesPorUbicacion(obj).Copy
            tb.TableName = "tmp"
            tb.Columns(1).ColumnName = "Seleccione un Galpón"
            With CmbGalpones
                .DataSource = tb
                .DisplayMember = tb.Columns(1).ColumnName
                .ValueMember = tb.Columns(0).ColumnName
                If (tb.Rows.Count > 0) Then
                    .Value = tb.Rows(0)(0)
                End If
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ListarAreas()
        Dim cn As New cnArea
        Dim tb As New DataTable
        tb = cn.Cn_Listar().Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione una Área"
        With cmbArea
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Sub ListarCampañasActivas()
        Dim cn As New cnControlLoteDestete
        Dim obj As New coControlLoteDestete With {
            .IdPlantel = idPlantel
        }
        Dim tb As New DataTable
        tb = cn.Cn_ConsultarCampañasActivas(obj).Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione una Campaña"
        With CmbCampaña
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Private Sub BtnBuscarAlimento_Click(sender As Object, e As EventArgs) Handles BtnBuscarAlimento.Click
        Dim frm As New FrmListarAlimentoCerdos(Me) With {
            .idPlantel = idPlantel
        }
        frm.ShowDialog()
    End Sub

    Public Sub LlenarCamposAlimento(codigo As Integer, descripcion As String, idUniMedida As Integer, stock As Decimal)
        codAlimento = codigo
        txtAlimento.Text = descripcion
        LblStock.Text = Convert.ToDecimal(stock).ToString("N4")
        idUnidadMedida = idUniMedida

        CalcularKilogramos(idUnidadMedida)
    End Sub

    Private Sub txtStock_TextChanged(sender As Object, e As EventArgs)
        CalcularKilogramos(idUnidadMedida)
    End Sub

    Private Sub BtnAgregarGalpon_Click(sender As Object, e As EventArgs)
        Try
            Dim frm As New FrmListarGalpones(Me) With {
                .idPlantel = idPlantel
            }
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub CalcularKilogramos(idUnidadMedida As Integer)
        Try
            Dim idUnidadMedidaKg As Integer = 6
            Dim idUnidadMedidaTonelada As Integer = 3

            If idUnidadMedida = idUnidadMedidaKg Then
                Return
            End If

            If Not String.IsNullOrEmpty(LblStock.Text) AndAlso IsNumeric(LblStock.Text) Then
                Dim cantidadToneladas As Decimal = Decimal.Parse(LblStock.Text)
                Dim cantidadKilogramos As Decimal = cantidadToneladas * 1000D ' 1 tonelada = 1000 kg
                LblStock.Text = cantidadKilogramos.ToString("0.00") ' Aquí podrías renombrar el control si ya no son sacos
            Else
                LblStock.Text = "0.00"
            End If
        Catch ex As Exception
            msj_advert("Error al calcular los kilogramos: " & ex.Message)
        End Try
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            Dim tipo As String

            If CbxAnti.Checked And CbxMedicado.Checked Then
                tipo = "ANTI-MEDICADO"
            ElseIf CbxAnti.Checked Then
                tipo = "ANTI"
            ElseIf CbxMedicado.Checked Then
                tipo = "MEDICADO"
            Else
                tipo = "NORMAL"
            End If

            If DtpFechaAlimento.Value.Date > Date.Now.Date Then
                msj_advert("La fecha de salida de alimento no puede ser mayor a la fecha actual")
                DtpFechaAlimento.Value = Date.Now.Date
                Return
            End If

            If txtObservacion.Text.Length = 0 Then
                msj_advert("Ingrese una observación")
                Return
            End If

            If txtCantidadTotal.Text.Length = 0 Then
                msj_advert("Ingrese una cantidad válida")
                Return
            End If

            If ValidarDecimal(txtCantidadTotal.Text) <= 0 Then
                msj_advert("Ingrese una cantidad válida")
                Return
            End If

            If ValidarDecimal(txtCantidadTotal.Text) > ValidarDecimal(LblStock.Text) Then
                msj_advert("La cantidad total no puede ser mayor al stock disponible en kilogramos")
                Return
            End If

            Dim cantidadEnKg As Decimal = ValidarDecimal(txtCantidadTotal.Text)
            Dim cantidadEnToneladas As Decimal = Math.Round(cantidadEnKg / 1000D, 4)

            If (MessageBox.Show("¿ESTÁ SEGURO DE REGISTRAR EL ALIMENTO PARA LA CERDA?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coControlAlimento With {
                .FechaControl = DtpFechaAlimento.Value,
                .Observacion = txtObservacion.Text,
                .IdUbicacion = idPlantel,
                .IdUsuario = VP_IdUser,
                .IdProducto = codAlimento,
                .Codigo = If(CbxLote.Checked, idLote, CmbGalpones.Value),
                .Cantidad = cantidadEnToneladas,
                .TipoAlimento = tipo,
                .Tipo = If(CbxLote.Checked, "LOTE", "GALPON"),
                .IdCampana = If(idPlantel = 1 Or idPlantel = 2, 0, CmbCampaña.Value),
                .IdArea = If(idPlantel = 1 Or idPlantel = 2, cmbArea.Value, 0)
            }

            Dim _mensaje As String = cn.Cn_RegistrarAlimentoCerdo(obj)
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

    Private Function ValidarDecimal(valorTexto As String) As Decimal
        Dim textoLimpio As String = valorTexto.Trim()

        If textoLimpio.EndsWith(".") Then
            textoLimpio &= "0"
        End If

        Return CDec(textoLimpio)
    End Function
    Private Sub txtCantidadTotal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidadTotal.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub BtnLote_Click(sender As Object, e As EventArgs) Handles BtnBuscarLote.Click
        Try
            Dim frm As New FrmListarLotesAlimentacion(Me) With {
                .idUbicacion = idPlantel
            }
            frm.ShowDialog()
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Public Sub LlenarLoteAlimentacion(codigo As Integer, descripcion As String)
        idLote = codigo
        TxtLote.Text = descripcion
    End Sub

    Private Sub CbxLote_CheckedChanged(sender As Object, e As EventArgs) Handles CbxLote.CheckedChanged
        If CbxLote.Checked Then
            LblLote.Visible = True
            TxtLote.Visible = True
            BtnBuscarLote.Visible = True
            CmbGalpones.Visible = False
            LblGalpon.Visible = False
        Else
            LblLote.Visible = False
            TxtLote.Visible = False
            BtnBuscarLote.Visible = False
            CmbGalpones.Visible = True
            LblGalpon.Visible = True
        End If
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class