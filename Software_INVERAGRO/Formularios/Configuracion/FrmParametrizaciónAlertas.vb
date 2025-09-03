Imports CapaNegocio
Imports CapaObjetos

Public Class FrmParametrizaciónAlertas
    Dim cn As New cnCaja
    Dim imagefoto As Byte() = Nothing
    Private loadNewImageFoto As Boolean = False
    Private Sub FrmCotizacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.Size = New Size(754, 763)

        ConsultarOrdenCompra()
    End Sub

    Sub ConsultarOrdenCompra()
        Dim ds As New DataSet
        ds = cn.Cn_ConsultarConfiguracionParametros().Copy

        ' Validar si hay tablas y filas en el DataSet
        If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
            Dim row As DataRow = ds.Tables(0).Rows(0) ' Tomar la primera fila
            numv1.Value = row(0).ToString
            Dim foto As Byte() = Nothing
            If Not IsDBNull(row(1)) Then
                foto = CType(row(1), Byte())
            End If
            clsBasicas.ConvertVarBinaryToPictureBox(foto, picFoto)
            txtsumini.Text = row(2).ToString
            txtseguromasvida.Text = row(3).ToString
            txtasignafamiliar.Text = row(4).ToString
            tbnagrario.Text = row(5).ToString
            txtessalud.Text = row(6).ToString
            txt_montodarioeventual.Text = row(7).ToString
            txtprecioplantel1.Text = row(8).ToString
            txtprecioplantel1molinero.Text = row(9).ToString
            txtprecioplantel2.Text = row(10).ToString
            txtprecioplantel3.Text = row(11).ToString
            txtprecioplantel4.Text = row(12).ToString
            txtprecioplantel5.Text = row(13).ToString
            txtcostomolino.Text = row(14).ToString
            txtcostomarrana.Text = row(15).ToString

        End If
    End Sub



    Private Sub TsBtn_Guardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If MsgBox("¿Esta Seguro de Guardar la Configuración?", MsgBoxStyle.OkCancel, "Aviso") = MsgBoxResult.Cancel Then
                Return
            End If
            Dim obj As New coCaja
            obj.Iduser = VP_IdUser
            obj.V1 = numv1.Value
            obj.sueldominimo = txtsumini.Text
            obj.masvida = txtseguromasvida.Text
            obj.asigfamiliar = txtasignafamiliar.Text
            obj.bonoagrario = tbnagrario.Text
            obj.essalud = txtessalud.Text
            obj.montoeventual = txt_montodarioeventual.Text
            obj.plantel1 = txtprecioplantel1.Text
            obj.plantel1monitoreo = txtprecioplantel1molinero.Text
            obj.plantel2 = txtprecioplantel2.Text
            obj.plantel3 = txtprecioplantel3.Text
            obj.plantel4 = txtprecioplantel4.Text
            obj.plantel5 = txtprecioplantel5.Text
            obj.costomolino = txtcostomolino.Text
            obj.costomarrana = txtcostomarrana.Text
            If picFoto.Image IsNot Nothing Then
                If (loadNewImageFoto) Then
                    Dim optimizedImageBytes As Byte() = clsBasicas.OptimizeImageFromPictureBox(picFoto)
                    picFoto.Image = clsBasicas.ByteArrayToImage(optimizedImageBytes)
                    imagefoto = optimizedImageBytes
                End If
            End If
            obj.Img = If(loadNewImageFoto AndAlso imagefoto IsNot Nothing, imagefoto, Nothing)
            Dim MensajeBgWk As String = ""
            MensajeBgWk = cn.Cn_GuardarConfigirucaionParametros(obj)
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

    Private Sub btnseleccionar1_Click(sender As Object, e As EventArgs) Handles btnseleccionar1.Click
        Dim ofd As New OpenFileDialog()
        ofd.Title = "Seleccionar Imagen"
        ofd.Filter = "Archivos de Imagen|*.jpg;*.jpeg;*.png;*.bmp"
        ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
        If ofd.ShowDialog() = DialogResult.OK Then
            picFoto.Image = Image.FromFile(ofd.FileName)
            loadNewImageFoto = True
        End If
    End Sub

    Private Sub TsBtn_Cerrar_Click(sender As Object, e As EventArgs) Handles TsBtn_Cerrar.Click
        Close()
    End Sub
End Class