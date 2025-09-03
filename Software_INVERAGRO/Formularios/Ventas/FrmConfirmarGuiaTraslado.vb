Imports System.IO
Imports CapaNegocio
Imports CapaObjetos

Public Class FrmConfirmarGuiaTraslado
    Dim cn As New cnVentas
    Public Property id As Integer
    Private Sub btnSubirArchivo_Click(sender As Object, e As EventArgs) Handles btnSubirArchivo.Click
        Dim openFileDialog As New OpenFileDialog()

        openFileDialog.Filter = "Archivos PDF|*.pdf|Todos los archivos|*.*"
        openFileDialog.Title = "Selecciona un archivo PDF"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Dim selectedFilePath As String = openFileDialog.FileName
            txtArchivo.Text = selectedFilePath
        End If
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If (txthorometrofinal.Text.Length = 0) Then
                msj_advert("Ingrese Horometro Final")
            End If
            Dim obj As New coVentas
            obj.Idguia = id
            obj.Codigo = cbxpedidoreferencia.ActiveRow.Cells(0).Value.ToString
            obj.Cantidad = cbxpedidoreferencia.ActiveRow.Cells(2).Value.ToString
            obj.Idproducto = cbxpedidoreferencia.ActiveRow.Cells(3).Value.ToString
            obj.Horometro_final = txthorometrofinal.Text
            obj.Cantidadsacos = txtcantidadsacos.Text
            If Not String.IsNullOrEmpty(txtArchivo.Text) Then
                Dim fileInfo As New FileInfo(txtArchivo.Text)
                If fileInfo.Length > 400 * 1024 Then
                    msj_advert("El archivo excede el tamaño máximo permitido de 400 kB.")
                    Return
                End If
                Dim pdfData As Byte() = File.ReadAllBytes(txtArchivo.Text)
                obj.SetArchivo(pdfData)
            End If

            If MsgBox("¿Esta Seguro de Registrar Archivo ?", MsgBoxStyle.OkCancel, "Aviso") = MsgBoxResult.Ok Then
                Dim MensajeBgWk As String = ""
                MensajeBgWk = cn.Cn_ConfirmarEntregaPedido(obj)
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
    Public Sub ListarPedidosCerdosxGuia()
        Try
            ' Inicializar conexión y obtener datos
            Dim cn As New cnProducto
            Dim tbtmpplanteles As New DataTable
            tbtmpplanteles = cn.Cn_ListarPedidosCerdos_x_guia(id).Copy

            With cbxpedidoreferencia
                .DataSource = tbtmpplanteles
                .DisplayMember = tbtmpplanteles.Columns(1).ColumnName ' Nombre de la columna a mostrar
                .ValueMember = tbtmpplanteles.Columns(0).ColumnName   ' Nombre de la columna del valor
                If tbtmpplanteles.Rows.Count > 0 Then
                    .Value = tbtmpplanteles.Rows(0)(0) ' Seleccionar el primer valor
                End If
            End With

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        Finally
        End Try
    End Sub
    Private Sub FrmMantArchivoMemorandum_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtArchivo.ReadOnly = True
        ListarPedidosCerdosxGuia()
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub

    Private Sub txthorometrofinal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txthorometrofinal.KeyPress
        clsBasicas.ValidarNumeros(e)
    End Sub

    Private Sub cbxpedidoreferencia_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cbxpedidoreferencia.InitializeLayout
        Try
            With e.Layout.Bands(0)
                .Columns(0).Hidden = True
                .Columns(1).Header.Caption = "Descripción Pedido"
                .Columns(1).Width = 300
                .Columns(3).Hidden = True
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
End Class