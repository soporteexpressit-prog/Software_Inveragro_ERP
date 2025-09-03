Imports CapaNegocio
Imports CapaObjetos

Public Class FrmMantMaterialGenetico
    Dim cn As New cnControlMaterialGenetico
    Dim idVerracoSemen As Integer = 0
    Public idMaterialGenetico As Integer = 0
    Public idUbicacion As Integer = 0

    Private Sub FrmMantMaterialGenetico_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ListarPlantelesOrigen()
            ListarPlantelesDestino()
            Inicializar()
            CmbUbicacionOrigen.Value = idUbicacion
            CmbUbicacionDestino.Value = idUbicacion
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub Inicializar()
        TxtCodigoVerraco.ReadOnly = True
        TxtLineaGenetica.ReadOnly = True
        DtpFechaExtraccion.Value = Now.Date
        DtpFechaProcesamiento.Value = Now.Date
        CbxGraja.Checked = True
        TxtVolumen.Select()
        LblStock.Visible = False
        LblCantStock.Text = ""
        LblTipoProducto.Text = ""
    End Sub

    Sub ListarPlantelesOrigen(Optional ByVal flag As Integer = 0)
        Dim cn As New cnUbicacion
        Dim tb As New DataTable
        tb = cn.Cn_ListarPlantelesReproduccion(flag).Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione un Plantel"
        With CmbUbicacionOrigen
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Sub ListarPlantelesDestino()
        Dim cn As New cnUbicacion
        Dim tb As New DataTable
        tb = cn.Cn_ListarPlantelesReproduccion().Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione un Plantel"
        With CmbUbicacionDestino
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub

    Public Sub LlenarCamposVerraco(id As Integer, codigo As String, lineaGenetica As String)
        idVerracoSemen = id
        TxtCodigoVerraco.Text = codigo
        TxtLineaGenetica.Text = lineaGenetica
    End Sub

    Public Sub LlenarCamposExternoSemenVerraco(codigo As Integer, numDocumento As String, lineaGenetica As String, stock As Integer, tipoProducto As String)
        idVerracoSemen = codigo
        TxtCodigoVerraco.Text = numDocumento
        TxtLineaGenetica.Text = lineaGenetica
        LblStock.Visible = Not CbxSinOrigen.Checked
        LblCantStock.Visible = Not CbxSinOrigen.Checked
        LblCantStock.Text = stock
        LblTipoProducto.Text = tipoProducto
        TxtNumDosis.Text = stock
    End Sub

    Private Sub CbxGraja_CheckedChanged(sender As Object, e As EventArgs) Handles CbxGraja.CheckedChanged
        If CbxGraja.Checked Then
            UgbInfoMG.Text = "INFORMACIÓN DEL VERRACO"
            LblStock.Visible = False
            LblMotilidadPura.Visible = True
            TxtMotilidadPura.Visible = True
            LblVolumen.Visible = True
            TxtVolumen.Visible = True
            TxtCodigo.Visible = False
            LblCodigo.Visible = False
            ListarPlantelesOrigen(0)
            CmbUbicacionOrigen.Value = idUbicacion
        Else
            UgbInfoMG.Text = "INFORMACIÓN DEL MATERIAL GENÉTICO"
            LblMotilidadPura.Visible = False
            TxtMotilidadPura.Visible = False
            LblVolumen.Visible = False
            TxtVolumen.Visible = False
            TxtCodigo.Visible = True
            LblCodigo.Visible = True
            ListarPlantelesOrigen(1)
            CmbUbicacionOrigen.Value = idUbicacion
        End If
        TxtMotilidadDiluida.Text = ""
        TxtNumDosis.Text = ""
        LblCantStock.Text = ""
        LblTipoProducto.Text = ""
        TxtMotilidadPura.Text = ""
        TxtCodigoVerraco.Text = ""
        TxtLineaGenetica.Text = ""
        TxtVolumen.Text = ""
        TxtCodigo.Text = ""
        idVerracoSemen = 0
    End Sub

    Private Sub BtnBuscarVerraco_Click(sender As Object, e As EventArgs) Handles BtnBuscarVerraco.Click
        If CbxGraja.Checked Then
            Dim f As New FrmListarVerraco(Me) With {
                .idPlantel = CmbUbicacionOrigen.Value
            }
            f.ShowDialog()
        Else
            Dim f As New FrmListarMatGeneticoRecepcionado(Me) With {
                .tipo = If(CbxSinOrigen.Checked, "REGULARIZACIÓN", "COMPRADO"),
                .idUbicacion = CmbUbicacionOrigen.Value
            }
            f.ShowDialog()
        End If
    End Sub

    Private Sub BtnGuardar_Click(sender As Object, e As EventArgs) Handles BtnGuardar.Click
        Try
            If String.IsNullOrWhiteSpace(TxtVolumen.Text) And CbxGraja.Checked Then
                msj_advert("Ingrese un Volumen")
                Return
            ElseIf String.IsNullOrWhiteSpace(TxtCodigo.Text) And Not CbxGraja.Checked Then
                msj_advert("Ingrese código de semen")
                Return
            ElseIf (Not IsNumeric(TxtVolumen.Text) OrElse CDec(TxtVolumen.Text) <= 0) And CbxGraja.Checked Then
                msj_advert("Ingrese un Volumen válido mayor a 0")
                Return
            End If

            If String.IsNullOrWhiteSpace(TxtMotilidadDiluida.Text) Then
                msj_advert("Ingrese Motilidad Diluida")
                Return
            ElseIf Not IsNumeric(TxtMotilidadDiluida.Text) OrElse CDec(TxtMotilidadDiluida.Text) <= 0 Then
                msj_advert("Ingrese una Motilidad Diluida válida mayor a 0")
                Return
            End If

            If CbxGraja.Checked Then
                If String.IsNullOrWhiteSpace(TxtMotilidadPura.Text) Then
                    msj_advert("Ingrese Motilidad Pura")
                    Return
                ElseIf Not IsNumeric(TxtMotilidadPura.Text) OrElse CDec(TxtMotilidadPura.Text) <= 0 Then
                    msj_advert("Ingrese una Motilidad Pura válida mayor a 0")
                    Return
                End If
            End If

            If CbxGraja.Checked AndAlso idVerracoSemen = 0 Then
                msj_advert("Seleccione un Verraco")
                Return
            End If

            If Not CbxGraja.Checked AndAlso idVerracoSemen = 0 Then
                msj_advert("Seleccione un material genético")
                Return
            End If

            If String.IsNullOrWhiteSpace(TxtNumDosis.Text) Then
                msj_advert("Ingrese Número de Dosis")
                Return
            ElseIf Not IsNumeric(TxtNumDosis.Text) OrElse CDec(TxtNumDosis.Text) <= 0 Then
                msj_advert("Ingrese Número de Dosis válido mayor a 0")
                Return
            End If

            If DtpFechaProcesamiento.Value > DtpFechaExtraccion.Value Then
                msj_advert("La fecha de procesamiento no puede ser mayor a la fecha de extracción")
                Return
            End If

            If Not CbxSinOrigen.Checked Then
                If Not CbxGraja.Checked AndAlso CDec(TxtNumDosis.Text) > CDec(LblCantStock.Text) Then
                    msj_advert("El número de dosis no puede ser mayor al stock")
                    Return
                End If
            End If

            If (MessageBox.Show("¿ESTÁ SEGURO DE REGISTRAR EXTRACCIÓN DE MATERIAL GENÉTICO?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim tipoFinal As String = If(CbxGraja.Checked, "GRANJA", "COMPRADO")
            If CbxSinOrigen.Checked Then
                tipoFinal = "REGULARIZACIÓN"
            End If

            Dim obj As New coControlMaterialGenetico With {
                .FechaExtraccion = DtpFechaExtraccion.Value,
                .FechaProcesamiento = DtpFechaProcesamiento.Value,
                .Volumen = If(CbxGraja.Checked, TxtVolumen.Text, Nothing),
                .MotilidadPura = If(CbxGraja.Checked, TxtMotilidadPura.Text, Nothing),
                .MotilidadDiluida = TxtMotilidadDiluida.Text,
                .Dosis = TxtNumDosis.Text,
                .IdUsuario = VP_IdUser,
                .IdVerraco = If(CbxGraja.Checked, idVerracoSemen, Nothing),
                .IdEncargado = VP_IdUser,
                .IdUbicacionOrigen = CmbUbicacionOrigen.Value,
                .IdUbicacionDestino = CmbUbicacionDestino.Value,
                .Tipo = tipoFinal,
                .IdProducto = If(CbxGraja.Checked, Nothing, idVerracoSemen),
                .Observacion = TxtObservacion.Text,
                .CodSemenCompra = If(CbxGraja.Checked, Nothing, TxtCodigo.Text)
            }

            Dim mensaje As String = cn.Cn_Mantenimiento(obj)
            If (obj.Coderror = 0) Then
                msj_ok(mensaje)
                Dispose()
            Else
                msj_advert(mensaje)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub TxtVolumen_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtVolumen.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub TxtMotilidad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtMotilidadPura.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub TxtMotilidadDiluida_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtMotilidadDiluida.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub TxtNumDosis_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtNumDosis.KeyPress
        clsBasicas.ValidarNumeros(e)
    End Sub

    Private Sub CbxSinOrigen_CheckedChanged(sender As Object, e As EventArgs) Handles CbxSinOrigen.CheckedChanged
        If CbxSinOrigen.Checked Then
            CbxGraja.Visible = False
            CbxGraja.Checked = False
            TxtCodigo.Text = ""
            TxtMotilidadDiluida.Text = ""
            TxtNumDosis.Text = ""
            TxtCodigoVerraco.Text = ""
            TxtLineaGenetica.Text = ""
            idVerracoSemen = 0
            CmbUbicacionOrigen.Value = idUbicacion
            CmbUbicacionDestino.Value = idUbicacion
            CmbUbicacionOrigen.Enabled = False
            CmbUbicacionDestino.Enabled = False
        Else
            CbxGraja.Checked = True
            CbxGraja.Visible = True
            CmbUbicacionOrigen.Enabled = True
            CmbUbicacionDestino.Enabled = True
        End If
        LblStock.Visible = False
        LblCantStock.Visible = False
    End Sub

    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Dispose()
    End Sub
End Class