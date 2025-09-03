Imports System.IO
Imports CapaDatos
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Public Class FrmDerechoHabientes
    Private ReadOnly _frmTrabajador As FrmTrabajador
    Dim cn As New cnDerechoHabientos
    Dim cn_item As New cnTrabajador
    Public Property esEdicion As Integer
    Public Property idhijo As Integer
    Public Sub New(frmTrabajador As FrmTrabajador)
        InitializeComponent()
        _frmTrabajador = frmTrabajador
    End Sub
    Sub ListarTablas()
        Try
            Dim ds As New DataSet
            ds = cn_item.Cn_ListarTablasMaestrasTrabajadores().Copy
            ds.DataSetName = "tmp"
            ds.Tables(0).Columns(1).ColumnName = "Motivos"
            Dim nuevaFila As DataRow = ds.Tables(0).NewRow()
            nuevaFila(0) = DBNull.Value
            nuevaFila(1) = "Selecciona el motivo"
            ds.Tables(0).Rows.InsertAt(nuevaFila, 0)
            Dim indice_tabla As Integer = 0
            indice_tabla = 14
            ds.Tables(indice_tabla).Columns(1).ColumnName = "Descripción"
            With cbxtipodocvinculante
                .DataSource = ds.Tables(indice_tabla)
                .DisplayMember = ds.Tables(indice_tabla).Columns(1).ColumnName
                .ValueMember = ds.Tables(indice_tabla).Columns(0).ColumnName
                If (ds.Tables(indice_tabla).Rows.Count > 0) Then
                    .Value = ds.Tables(indice_tabla).Rows(0)(0)
                End If
            End With
            indice_tabla = 15
            ds.Tables(indice_tabla).Columns(1).ColumnName = "Descripción"
            With cbxvinculofamiliar
                .DataSource = ds.Tables(indice_tabla)
                .DisplayMember = ds.Tables(indice_tabla).Columns(1).ColumnName
                .ValueMember = ds.Tables(indice_tabla).Columns(0).ColumnName
                If (ds.Tables(indice_tabla).Rows.Count > 0) Then
                    .Value = ds.Tables(indice_tabla).Rows(0)(0)
                End If
            End With
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Sub ListarTipoDocumento()
        Dim cn As New cnTrabajador
        Dim tb As New DataTable
        tb = cn.Cn_ListarTipoDocIdentidad().Copy
        tb.TableName = "tmp"
        tb.Columns(1).ColumnName = "Seleccione una Tipo Documento Identidad"
        With cbxtipodocidentidadhijo
            .DataSource = tb
            .DisplayMember = tb.Columns(1).ColumnName
            .ValueMember = tb.Columns(0).ColumnName
            If (tb.Rows.Count > 0) Then
                .Value = tb.Rows(0)(0)
            End If
        End With
    End Sub
    Private Sub FrmItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ListarTablas()
            ListarTipoDocumento()
            cbxsexohijo.SelectedIndex = 0
            If (esEdicion = 0) Then

            Else
            End If
            If (esEdicion <> 0) Then
                _frmTrabajador._operacion = 1
                If (esEdicion = 1) Then
                    Consultar3()
                    Refresh()
                Else
                End If
            Else
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub



    Private Sub btnBuscarArchivo_Click_1(sender As Object, e As EventArgs) Handles btnBuscarArchivo.Click
        Dim openFileDialog As New OpenFileDialog()

        openFileDialog.Filter = "Archivos PDF|*.pdf|Todos los archivos|*.*"
        openFileDialog.Title = "Selecciona un archivo PDF"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Dim selectedFilePath As String = openFileDialog.FileName
            txtdocumento.Text = selectedFilePath
        End If
    End Sub
    Private Sub btnsalir_Click(sender As Object, e As EventArgs) Handles btnsalir.Click
        Dispose()
    End Sub
    Sub Consultar3()
        Dim obj As New coTrabajador
        Dim cn As New cnTrabajador
        obj.IdPersona = _frmTrabajador._Codigo
        obj.idhijo = idhijo
        Dim tb As New DataTable
        tb = cn.Cn_ConsultarxCodigo(obj).Copy
        tb.TableName = "tmp"

        If tb.Rows.Count > 0 Then
            Dim tbhijo As DataTable = cn.Cc_ConsultarxCodigoHijos(obj)
            If tbhijo.Rows.Count > 0 Then
                Dim row As DataRow = tbhijo.Rows(0)
                txtnrodochijo.Text = If(IsDBNull(row(0)), "", row(0).ToString())
                dtpconcepcionhijo.Value = If(IsDBNull(row(1)), Date.Now, Convert.ToDateTime(row(1)))
                dtpfechanacimientohijo.Value = If(IsDBNull(row(2)), Date.Now, Convert.ToDateTime(row(2)))
                cbxsexohijo.SelectedItem = If(IsDBNull(row(3)), Nothing, row(3).ToString())
                txtnombrehijo.Text = If(IsDBNull(row(4)), "", row(4).ToString())
                txtapaternohijo.Text = If(IsDBNull(row(5)), "", row(5).ToString())
                txtamaternohijo.Text = If(IsDBNull(row(6)), "", row(6).ToString())
                txtnrodocvinculante.Text = If(IsDBNull(row(7)), "", row(7).ToString())
                AsignarValorComboBox(cbxtipodocvinculante, row(8).ToString())
                AsignarValorComboBox(cbxvinculofamiliar, row(9).ToString())
                AsignarValorComboBox(cbxtipodocidentidadhijo, row(10).ToString())
            End If
        Else
            MessageBox.Show("No se encontró ningún registro con el código especificado.")
        End If
    End Sub
    Private Sub AsignarValorComboBox(cmb As UltraCombo, valor As String)
        Dim encontrado As Boolean = True

        For Each row As UltraGridRow In cmb.Rows
            If row.Cells(cmb.ValueMember).Value.ToString() = valor Then
                encontrado = True
                Exit For
            End If
        Next

        If encontrado Then
            cmb.Value = valor
        Else
            MessageBox.Show($"El valor '{valor}' no existe en las opciones del ComboBox '{cmb.Name}'.")
            cmb.Value = -1
        End If
    End Sub


    Private Sub btnGuardarmodelu_Click(sender As Object, e As EventArgs) Handles btnGuardarmodelu.Click
        Try
            If _frmTrabajador._operacion = 0 OrElse _frmTrabajador._operacion = 1 Then
                If cbxtipodocidentidadhijo.Value Is Nothing Then
                    msj_advert("Seleccione un Tipo de Documento de Identidad")
                    Return
                End If
                If cbxsexohijo.SelectedItem Is Nothing Then
                    msj_advert("Seleccione un Genero")
                    Return
                End If
                If txtnrodochijo.Text.Length = 0 Then
                    txtnrodochijo.Focus()
                    msj_advert("N° Documento no Válido")
                    Return
                End If
                If txtnombrehijo.Text.Length = 0 Then
                    txtnombrehijo.Focus()
                    msj_advert("Ingrese nombre")
                    Return
                End If
                If txtapaternohijo.Text.Length = 0 Then
                    txtapaternohijo.Focus()
                    msj_advert("Ingrese un apellido paterno")
                    Return
                End If
                If txtamaternohijo.Text.Length = 0 Then
                    msj_advert("Ingrese un apellido materno")
                    Return
                End If
                If cbxvinculofamiliar.Text.Length = 0 Then
                    msj_advert("seleccione vinculo familiar")
                    Return
                End If
                If cbxtipodocvinculante.Text.Length = 0 Then
                    msj_advert("seleccione tipo de vinculo familiar")
                    Return
                End If
                If txtnrodocvinculante.Text.Length = 0 Then
                    txtnrodocvinculante.Focus()
                    msj_advert("Ingrese numero de documento")
                    Return
                End If
                If txtdocumento.Text.Length = 0 Then
                    txtdocumento.Focus()
                    msj_advert("Ingrese un documento")
                    Return
                End If
            End If
            If _frmTrabajador._operacion = 0 Then
                Dim tipoDocIdentidadHijo, vinculoFamiliar, tipoDocVinculante As Integer
                If Not Integer.TryParse(cbxtipodocidentidadhijo.Value?.ToString(), tipoDocIdentidadHijo) Then tipoDocIdentidadHijo = 0
                If Not Integer.TryParse(cbxvinculofamiliar.Value?.ToString(), vinculoFamiliar) Then vinculoFamiliar = 0
                If Not Integer.TryParse(cbxtipodocvinculante.Value?.ToString(), tipoDocVinculante) Then tipoDocVinculante = 0

                _frmTrabajador.LlenarCamposDerechoHabiente(
                txtnrodochijo.Text.Trim(),
                dtpconcepcionhijo.Text.Trim(),
                dtpfechanacimientohijo.Text.Trim(),
                cbxsexohijo.Text.Trim(),
                tipoDocIdentidadHijo,
                txtnombrehijo.Text.Trim(),
                txtapaternohijo.Text.Trim(),
                txtamaternohijo.Text.Trim(),
                vinculoFamiliar,
                tipoDocVinculante,
                txtnrodocvinculante.Text.Trim(),
                txtdocumento.Text.Trim()
            )
            ElseIf _frmTrabajador._operacion = 1 Then
                If esEdicion = 0 Then
                    InsertarHijo()
                End If
                If esEdicion = 1 Then
                    actualizarHijo()
                End If
            End If

        Catch ex As Exception
            msj_advert($"Error: {ex.Message}")
        End Try
    End Sub
    Private Sub InsertarHijo()
        Try
            Dim objDerechoHabiente As New coDerechoHabiento With {
            .numDocumentoHijo = txtnrodochijo.Text.Trim(),
            .mesConcepcion = dtpconcepcionhijo.Text.Trim(),
            .fNacimientoHijo = dtpfechanacimientohijo.Text.Trim(),
            .sexoHijo = cbxsexohijo.Text.Trim(),
            .idTipoDocIdentidadHijo = CInt(cbxtipodocidentidadhijo.Value),
            .nombresHijo = txtnombrehijo.Text.Trim(),
            .apellidoPaternoHijo = txtapaternohijo.Text.Trim(),
            .apellidoMaternoHijo = txtamaternohijo.Text.Trim(),
            .idVinculoFamiliar = CInt(cbxvinculofamiliar.Value),
            .idTipoDocVinculante = CInt(cbxtipodocvinculante.Value),
            .nroDocVinculante = txtnrodocvinculante.Text.Trim(),
            .idPersona = _frmTrabajador._Codigo
        }

            ' Verificar archivo
            If Not String.IsNullOrEmpty(txtdocumento.Text) Then
                Dim fileInfo As New FileInfo(txtdocumento.Text)
                If fileInfo.Length > 400 * 1024 Then
                    msj_advert("El archivo PDF excede el tamaño máximo permitido de 400 kB.")
                    Return
                End If
                objDerechoHabiente.Setdochijo(File.ReadAllBytes(txtdocumento.Text))
            End If
            Dim resultado As String = cn.Cn_Mantenimiento(objDerechoHabiente)
            If String.IsNullOrEmpty(resultado) Then
                MessageBox.Show("Operación exitosa", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _frmTrabajador.ConsultarHijosPorIdPersona()
                Dispose()
            Else
                msj_advert(resultado)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub actualizarHijo()
        Try
            Dim objDerechoHabiente As New coDerechoHabiento With {
            .numDocumentoHijo = txtnrodochijo.Text.Trim(),
            .mesConcepcion = dtpconcepcionhijo.Text.Trim(),
            .fNacimientoHijo = dtpfechanacimientohijo.Text.Trim(),
            .sexoHijo = cbxsexohijo.Text.Trim(),
            .idTipoDocIdentidadHijo = CInt(cbxtipodocidentidadhijo.Value),
            .nombresHijo = txtnombrehijo.Text.Trim(),
            .apellidoPaternoHijo = txtapaternohijo.Text.Trim(),
            .apellidoMaternoHijo = txtamaternohijo.Text.Trim(),
            .idVinculoFamiliar = CInt(cbxvinculofamiliar.Value),
            .idTipoDocVinculante = CInt(cbxtipodocvinculante.Value),
            .nroDocVinculante = txtnrodocvinculante.Text.Trim(),
            .idPersona = _frmTrabajador._Codigo
        }
            Dim obj2 As New coTrabajador
            obj2.idhijo = idhijo

            ' Verificar archivo
            If Not String.IsNullOrEmpty(txtdocumento.Text) Then
                Dim fileInfo As New FileInfo(txtdocumento.Text)
                If fileInfo.Length > 400 * 1024 Then
                    msj_advert("El archivo PDF excede el tamaño máximo permitido de 400 kB.")
                    Return
                End If
                objDerechoHabiente.Setdochijo(File.ReadAllBytes(txtdocumento.Text))
            End If

            ' Guardar en la base de datos
            Dim resultado As String = cn.Cn_Actualizahijo(objDerechoHabiente, obj2)
            If String.IsNullOrEmpty(resultado) Then
                MessageBox.Show("Operación exitosa", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _frmTrabajador.ConsultarHijosPorIdPersona()
                Dispose()
            Else
                msj_advert(resultado)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CargarDatosYAsignarValorComboBox(ByVal cmb As UltraCombo, ByVal dt As DataTable, ByVal displayMember As String, ByVal valueMember As String, ByVal valorASeleccionar As String)
        Try
            cmb.DataSource = dt
            cmb.DisplayMember = displayMember
            cmb.ValueMember = valueMember

            If dt.Rows.Count > 0 Then
                Dim valorExiste As Boolean = dt.AsEnumerable().Any(Function(row) row(valueMember).ToString() = valorASeleccionar)

                If valorExiste Then
                    cmb.Value = valorASeleccionar ' Asignar el valor si existe
                Else
                    MessageBox.Show($"El valor '{valorASeleccionar}' no existe en la lista.", "Valor no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    cmb.Value = Nothing ' Limpiar selección si el valor no existe
                End If
            Else
                MessageBox.Show("La tabla asociada al ComboBox está vacía.", "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                cmb.Value = Nothing
            End If
        Catch ex As Exception
            MessageBox.Show($"Error al cargar datos o asignar valor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtnombrehijo_TextChanged(sender As Object, e As EventArgs) Handles txtnombrehijo.TextChanged
        If System.Text.RegularExpressions.Regex.IsMatch(txtnombrehijo.Text, "\d") Then
            txtnombrehijo.Text = System.Text.RegularExpressions.Regex.Replace(txtnombrehijo.Text, "\d", "")
            txtnombrehijo.SelectionStart = txtnombrehijo.Text.Length
        End If
    End Sub

    Private Sub txtapaternohijo_TextChanged(sender As Object, e As EventArgs) Handles txtapaternohijo.TextChanged
        If System.Text.RegularExpressions.Regex.IsMatch(txtapaternohijo.Text, "\d") Then
            txtapaternohijo.Text = System.Text.RegularExpressions.Regex.Replace(txtapaternohijo.Text, "\d", "")
            txtapaternohijo.SelectionStart = txtapaternohijo.Text.Length
        End If
    End Sub

    Private Sub txtamaternohijo_TextChanged(sender As Object, e As EventArgs) Handles txtamaternohijo.TextChanged
        If System.Text.RegularExpressions.Regex.IsMatch(txtamaternohijo.Text, "\d") Then
            txtamaternohijo.Text = System.Text.RegularExpressions.Regex.Replace(txtamaternohijo.Text, "\d", "")
            txtamaternohijo.SelectionStart = txtamaternohijo.Text.Length
        End If
    End Sub

    Private Sub txtnrodochijo_TextChanged(sender As Object, e As EventArgs) Handles txtnrodochijo.TextChanged
        Dim cursorPosition As Integer = txtnrodochijo.SelectionStart ' Guardar posición del cursor
        txtnrodochijo.Text = New String(txtnrodochijo.Text.Where(Function(c) Char.IsDigit(c)).ToArray())
        txtnrodochijo.SelectionStart = Math.Min(cursorPosition, txtnrodochijo.Text.Length) ' Restaurar posición del cursor
    End Sub

    Private Sub txtnrodocvinculante_TextChanged(sender As Object, e As EventArgs) Handles txtnrodocvinculante.TextChanged
        Dim cursorPosition As Integer = txtnrodocvinculante.SelectionStart ' Guardar posición del cursor
        txtnrodocvinculante.Text = New String(txtnrodocvinculante.Text.Where(Function(c) Char.IsDigit(c)).ToArray())
        txtnrodocvinculante.SelectionStart = Math.Min(cursorPosition, txtnrodocvinculante.Text.Length) ' Restaurar posición del cursor
    End Sub

    Private Sub cbxvinculofamiliar_InitializeLayout_1(sender As Object, e As InitializeLayoutEventArgs) Handles cbxvinculofamiliar.InitializeLayout
        For Each column As UltraGridColumn In e.Layout.Bands(0).Columns
            column.PerformAutoResize(PerformAutoSizeType.AllRowsInBand, True)
            column.CellActivation = Activation.NoEdit
        Next
        With cbxvinculofamiliar
            .DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList ' Evitar edición de texto
            .DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.False ' Evitar filtros
        End With
    End Sub

    Private Sub cbxtipodocvinculante_InitializeLayout_1(sender As Object, e As InitializeLayoutEventArgs) Handles cbxtipodocvinculante.InitializeLayout
        For Each column As UltraGridColumn In e.Layout.Bands(0).Columns
            column.PerformAutoResize(PerformAutoSizeType.AllRowsInBand, True)
            column.CellActivation = Activation.NoEdit
        Next
        With cbxtipodocvinculante
            .DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList ' Evitar edición de texto
            .DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.False ' Evitar filtros
        End With

    End Sub

    Private Sub cbxtipodocidentidadhijo_InitializeLayout_1(sender As Object, e As InitializeLayoutEventArgs) Handles cbxtipodocidentidadhijo.InitializeLayout
        For Each column As UltraGridColumn In e.Layout.Bands(0).Columns
            column.PerformAutoResize(PerformAutoSizeType.AllRowsInBand, True)
            column.CellActivation = Activation.NoEdit
        Next
        With cbxtipodocidentidadhijo
            .DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList ' Evitar edición de texto
            .DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.False ' Evitar filtros
        End With
    End Sub

    Private Sub dtpfechanacimientohijo_ValueChanged(sender As Object, e As EventArgs) Handles dtpfechanacimientohijo.ValueChanged
        dtpconcepcionhijo.Value = dtpfechanacimientohijo.Value
    End Sub
    Private Sub dtpconcepcionhijo_ValueChanged(sender As Object, e As EventArgs) Handles dtpconcepcionhijo.ValueChanged
        dtpfechanacimientohijo.Value = dtpconcepcionhijo.Value
    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub
End Class