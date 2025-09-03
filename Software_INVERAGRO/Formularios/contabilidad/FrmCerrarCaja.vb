Imports CapaNegocio
Imports CapaObjetos

Public Class FrmCerrarCaja
    Dim cn As New cnCaja
    Public _codigo As Integer = 0
    Public _idpersona As Integer = 0

    Private Sub FrmCotizacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.Size = New Size(754, 763)
        txtfecha.ReadOnly = True
        txttapertura.ReadOnly = True
        txtsaldoanterior.ReadOnly = True
        txtmontoingreso.ReadOnly = True
        txtmontoegreso.ReadOnly = True
        txtsaldofinal.ReadOnly = True
        txtusuario.ReadOnly = True
        ConsultarOrdenCompra()
        CenterGroupBox()
    End Sub

    Sub ConsultarOrdenCompra()
        Dim ds As New DataSet
        ds = cn.Cn_ConsultarCajaResumen().Copy

        ' Validar si hay tablas y filas en el DataSet
        If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
            Dim row As DataRow = ds.Tables(0).Rows(0) ' Tomar la primera fila
            _codigo = row(0).ToString
            _idpersona = row(1).ToString
            txtusuario.Text = row(2).ToString
            txtfecha.Text = row(3).ToString
            txttapertura.Text = clsBasicas.FormatearComoDecimal(row(5).ToString())
            txtsaldoanterior.Text = clsBasicas.FormatearComoDecimal(row(6).ToString())
            txtmontoingreso.Text = clsBasicas.FormatearComoDecimal(row(7).ToString())
            txtmontoegreso.Text = clsBasicas.FormatearComoDecimal(row(8).ToString())
            txtsaldofinal.Text = clsBasicas.FormatearComoDecimal(row(9).ToString())
        Else
            ' Mostrar un mensaje si no hay datos
            msj_advert("La Caja ya se encuentra CERRADA.")
            Dispose()

        End If
    End Sub



    Private Sub TsBtn_Guardar_Click(sender As Object, e As EventArgs) Handles btnGuardarctcc.Click
        Try
            If MsgBox("¿Esta Seguro de Cerrar Caja?", MsgBoxStyle.OkCancel, "Aviso") = MsgBoxResult.Cancel Then
                Return
            End If
            Dim obj As New coCaja
            obj.Idcaja = _codigo
            obj.Iduser = VP_IdUser
            Dim MensajeBgWk As String = ""
            MensajeBgWk = cn.Cn_CerrarCaja(obj)
            If (obj.Codreturn = 0) Then
                msj_ok(MensajeBgWk)
                Dispose()
            Else
                msj_advert(MensajeBgWk)
            End If

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub CenterGroupBox()
        If GroupBox1 IsNot Nothing Then
            ' Calcula la posición para centrar el GroupBox
            GroupBox1.Left = (Me.ClientSize.Width - GroupBox1.Width) / 2
            GroupBox1.Top = (Me.ClientSize.Height - GroupBox1.Height) / 2
        End If
    End Sub

    Private Sub FrmCerrarCaja_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        CenterGroupBox()
    End Sub

    Private Sub TsBtn_Cerrar_Click(sender As Object, e As EventArgs) Handles TsBtn_Cerrar.Click
        Dispose()
    End Sub
End Class