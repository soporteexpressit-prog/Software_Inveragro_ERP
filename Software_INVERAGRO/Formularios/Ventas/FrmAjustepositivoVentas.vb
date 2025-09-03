Imports CapaDatos
Imports CapaNegocio
Imports CapaObjetos
Imports Stimulsoft.Report.StiOptions.Export

Public Class FrmAjustepositivoVentas
    Dim cn As New cnVentas
    Public _idguia As Integer = 0
    Public _codigo As Integer = 0
    Public operacion As Integer
    Dim tbtmpplanteles As New DataTable
    Dim DvPlanteles As DataView
    Dim idproducto As Integer = 0
    Public Sub ListarPedidosCerdosxGuia()
        Try
            ' Inicializar conexión y obtener datos
            Dim cn As New cnProducto
            If operacion = 1 Or operacion = 2 Then
                tbtmpplanteles = cn.Cn_ListarPedidosCerdos_x_guia_controlventas(_idguia).Copy
            Else
                tbtmpplanteles = cn.Cn_ListarPedidosCerdos_x_guia(_idguia).Copy
            End If
            With cbxpedidoreferencia
                .DataSource = tbtmpplanteles
                .DisplayMember = tbtmpplanteles.Columns(1).ColumnName ' Nombre de la columna a mostrar
                .ValueMember = tbtmpplanteles.Columns(0).ColumnName   ' Nombre de la columna del valor
                If tbtmpplanteles.Rows.Count > 0 Then
                    .Value = tbtmpplanteles.Rows(0)(0) ' Seleccionar el primer valor
                    idproducto = Convert.ToInt32(tbtmpplanteles.Rows(0)(3))
                End If
            End With

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        Finally
        End Try
    End Sub

    Private Sub FrmAjustepositivoVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListarPedidosCerdosxGuia()
        ComboBox1.SelectedIndex = 0
        If operacion = 2 Then
            txtcantidad.Visible = False
            Label4.Visible = False
            Label1.Visible = True
            ComboBox1.Visible = True
            btnguardarnuerte.Visible = False
            btnanular.Visible = True
            Text = " Anular Ajuste"
        Else
            txtcantidad.Visible = True
            Label4.Visible = True
            btnguardarnuerte.Visible = True
            btnanular.Visible = False
            Label1.Visible = False
            ComboBox1.Visible = False
        End If
    End Sub
    Private Sub btnguardarnuerte_Click(sender As Object, e As EventArgs) Handles btnguardarnuerte.Click
        Try
            If MsgBox("¿Esta Seguro de Registrar el Ajuste Irrecuperable?", MsgBoxStyle.OkCancel, "Aviso") = MsgBoxResult.Cancel Then
                Return
            End If
            If (txtcantidad.TextLength = 0) Then
                msj_advert("Ingrese un Cantidad")
                Return
            Else
                Dim obj As New coVentas
                obj.Codigo = _idguia
                obj.Idproducto = cbxpedidoreferencia.ActiveRow.Cells(0).Value.ToString
                obj.Cantidad = txtcantidad.Text
                obj.Iduser = VP_IdUser
                Dim MensajeBgWk As String = ""
                MensajeBgWk = cn.Cn_RegAjustepositivoventa(obj)
                If (obj.Coderror = 0) Then
                    msj_ok(MensajeBgWk)
                    Dispose()
                Else
                    msj_advert(MensajeBgWk)
                End If

            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub cbxpedidoreferencia_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cbxpedidoreferencia.InitializeLayout
        Try
            ' Validar que el objeto ActiveRow no sea Nothing
            If cbxpedidoreferencia.ActiveRow IsNot Nothing AndAlso
           cbxpedidoreferencia.ActiveRow.Cells IsNot Nothing AndAlso
           cbxpedidoreferencia.ActiveRow.Cells.Count > 2 Then

            Else
            End If
        Catch ex As Exception
            ' Manejar cualquier excepción
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles btnanular.Click
        Try
            If MsgBox("¿Esta Seguro de Registrar el Ajuste Irrecuperable?", MsgBoxStyle.OkCancel, "Aviso") = MsgBoxResult.Cancel Then
                Return
            End If
            If (txtobservacion.TextLength = 0) Then
                msj_advert("Ingrese un observacion")
                Return
            Else
                Dim obj As New coVentas
                obj.Codigo = _idguia
                obj.Idproducto = cbxpedidoreferencia.ActiveRow.Cells(0).Value.ToString
                obj.Iduser = VP_IdUser
                obj.Observacion = txtobservacion.Text
                If ComboBox1.SelectedIndex = 0 Then
                    obj.IdMotivoTransaccion = 24
                ElseIf ComboBox1.SelectedIndex = 1 Then
                    obj.IdMotivoTransaccion = 22
                End If
                Dim MensajeBgWk As String = ""
                MensajeBgWk = cn.Cn_Reganulacionajuste(obj)
                If (obj.Coderror = 0) Then
                    msj_ok(MensajeBgWk)
                    Dispose()
                Else
                    msj_advert(MensajeBgWk)
                End If

            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
End Class