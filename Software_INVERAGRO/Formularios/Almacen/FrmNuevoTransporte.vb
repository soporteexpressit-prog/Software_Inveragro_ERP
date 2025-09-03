Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmNuevoTransporte
    Public operacion As Integer
    Public codigo As Integer
    Dim cn As New cnTransporte

    Private Sub FrmNuevoTransporte_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txt_numplaca.Text = ""
        txt_capacidad.Text = ""
        txt_modelo.Text = ""
        ListarTablas()
        txt_año.Format = DateTimePickerFormat.Custom
        txt_año.CustomFormat = "yyyy"
        txt_año.ShowUpDown = True
        If operacion = 1 Then
            cbestado.Visible = False
            Label5.Visible = False
            cbestado.SelectedIndex = 0
            cbtipovehiculo.SelectedIndex = 0
            cbmarca.SelectedIndex = 0
        Else
            Consultar()
        End If

    End Sub
    Sub ListarTablas()
        Try
            Dim ds As New DataSet
            ds = cn.Cn_ListarTablasMaestrastranportes().Copy
            ds.DataSetName = "tmp"
            Dim indice_tabla_tipovehiculo As Integer = 0
            Dim indice_tabla_marca As Integer = 1
            ds.Tables(indice_tabla_tipovehiculo).Columns(1).ColumnName = "TIPO"
            With cbtipovehiculo
                .DataSource = ds.Tables(indice_tabla_tipovehiculo)
                .DisplayMember = "TIPO"
                .ValueMember = "Codigo"
                If (ds.Tables(indice_tabla_tipovehiculo).Rows.Count > 0) Then
                    .SelectedValue = ds.Tables(indice_tabla_tipovehiculo).Rows(0)("Codigo")
                End If
            End With
            ds.Tables(indice_tabla_marca).Columns(1).ColumnName = "TIPO"
            With cbmarca
                .DataSource = ds.Tables(indice_tabla_marca)
                .DisplayMember = "TIPO"
                .ValueMember = "Codigo"
                If (ds.Tables(indice_tabla_marca).Rows.Count > 0) Then
                    .SelectedValue = ds.Tables(indice_tabla_marca).Rows(0)("Codigo")
                End If
            End With

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        If (txt_numplaca.Text = "") Then
            msj_advert("Debe ingresar un numero de placa.")
            Return
        ElseIf (txt_capacidad.Text = "") Then
            msj_advert("Debe ingresar una capacidad.")
            Return
        ElseIf (txt_modelo.Text = "") Then
            msj_advert("Debe ingresar un modelo.")
            Return
        Else
            Dim result As DialogResult = MessageBox.Show("¿Está seguro de guardar el transporte?", "Confirmar Anulación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If result = DialogResult.Yes Then
                Dim obj As New coTransporte
                obj.operacion = operacion
                If operacion = 2 Then
                    obj.Codigo = codigo
                End If
                obj.numplaca = txt_numplaca.Text
                obj.capacidadcarga = txt_capacidad.Text
                obj.modelo = txt_modelo.Text
                obj.tipovehiculo = cbtipovehiculo.SelectedValue
                obj.marca = cbmarca.SelectedValue
                obj.aniofabricacion = txt_año.Text
                obj.estado = cbestado.Text
                obj.pesotara = txtpesotara.Text
                Dim rpta As String = cn.Cn_insertar_transporte(obj)
                If (obj.Coderror = 0) Then
                    msj_ok(rpta)
                    Me.Close()
                Else
                    msj_advert(rpta)
                End If
                FrmControlTranportes.Consultar()
                Dispose()
            End If
        End If
    End Sub

    Sub Consultar()
        Try
            Dim obj As New coTransporte With {
                .Codigo = codigo
            }

            Dim dt As DataTable = cn.Cn_consultarxid(obj)

            If dt.Rows.Count > 0 Then
                Dim fila As DataRow = dt.Rows(0) ' Tomar la primera fila del resultado

                txt_numplaca.Text = fila("numPlaca").ToString()
                cbtipovehiculo.SelectedValue = fila("tipoVehiculo")
                cbmarca.SelectedValue = fila("marca")
                txt_modelo.Text = fila("modelo").ToString()
                txt_año.Value = New Date(Convert.ToInt32(fila("anioFabricacion")), 1, 1)
                txt_capacidad.Text = fila("capacidadcarga").ToString()
                cbestado.Text = fila("estado").ToString()
                txtpesotara.Text = fila("pesototal").ToString()
            Else
                MessageBox.Show("No se encontraron datos para el transporte seleccionado.", "Consultar Transporte", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Error al consultar los datos del transporte: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub txt_capacidad_TextChanged(sender As Object, e As EventArgs) Handles txt_capacidad.TextChanged
        Dim texto As String = txt_capacidad.Text
        Dim textoFiltrado As String = ""
        Dim puntoDecimalEncontrado As Boolean = False

        For Each c As Char In texto
            If Char.IsDigit(c) Then
                textoFiltrado &= c
            ElseIf c = "."c And Not puntoDecimalEncontrado Then
                textoFiltrado &= c
                puntoDecimalEncontrado = True
            End If
        Next

        ' Si el texto ha cambiado después del filtrado, actualiza el valor del TextBox.
        If textoFiltrado <> texto Then
            Dim cursorPos As Integer = txt_capacidad.SelectionStart
            txt_capacidad.Text = textoFiltrado
            txt_capacidad.SelectionStart = Math.Max(0, cursorPos - (texto.Length - textoFiltrado.Length))
        End If
    End Sub

    Private Sub btnsalir_Click(sender As Object, e As EventArgs) Handles btnsalir.Click
        Dispose()
    End Sub

    Private Sub txtpesotara_TextChanged(sender As Object, e As EventArgs) Handles txtpesotara.TextChanged
        Dim texto As String = txtpesotara.Text
        Dim textoFiltrado As String = ""
        Dim puntoDecimalEncontrado As Boolean = False

        For Each c As Char In texto
            If Char.IsDigit(c) Then
                textoFiltrado &= c
            ElseIf c = "."c And Not puntoDecimalEncontrado Then
                textoFiltrado &= c
                puntoDecimalEncontrado = True
            End If
        Next

        ' Si el texto ha cambiado después del filtrado, actualiza el valor del TextBox.
        If textoFiltrado <> texto Then
            Dim cursorPos As Integer = txtpesotara.SelectionStart
            txtpesotara.Text = textoFiltrado
            txtpesotara.SelectionStart = Math.Max(0, cursorPos - (texto.Length - textoFiltrado.Length))
        End If
    End Sub

    Private Sub btnnuevoytipo_Click(sender As Object, e As EventArgs) Handles btnnuevoytipo.Click
        Dim f As New FrmManttipoymarcavehiculo()
        f.ShowDialog()
        ListarTablas()
    End Sub
End Class