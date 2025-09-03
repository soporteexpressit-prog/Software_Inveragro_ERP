Imports CapaDatos
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmAgregarConceptoSueldo
    Dim ds As New DataSet
    Private cn As New cnControlPagosyDes()
    Private formularioPrincipal As FrmControlPagosDescuentos
    Public LabelFormulario As String
    Public Tipo As String
    Public Tipoconcepto As Integer
    Public id As Integer
    Public idpago As Integer
    Public Periodo As String
    Public _tipopago As String = ""
    Public Sub New(ByRef formPrincipal As FrmControlPagosDescuentos)
        InitializeComponent()
        formularioPrincipal = formPrincipal
    End Sub
    Sub ListarTablas()
        Try
            Dim ds As New DataSet
            ds = cn.Cn_ListarTablasMaestrasConceptos().Copy
            ds.DataSetName = "tmp"
            ds.Tables(Tipoconcepto).Columns(1).ColumnName = "Conceptos"
            Dim nuevaFila As DataRow = ds.Tables(Tipoconcepto).NewRow()
            nuevaFila(0) = DBNull.Value
            nuevaFila(1) = "Selecciona el motivo"
            ds.Tables(Tipoconcepto).Rows.InsertAt(nuevaFila, 0)
            Dim indice_tabla As Integer = Tipoconcepto
            With cbxTipoConcepto
                .DataSource = ds.Tables(indice_tabla)
                .DisplayMember = ds.Tables(indice_tabla).Columns(1).ColumnName
                .ValueMember = ds.Tables(indice_tabla).Columns(0).ColumnName
                If (ds.Tables(indice_tabla).Rows.Count > 0) Then
                    .Value = ds.Tables(indice_tabla).Rows(0)(0)
                End If
            End With
            If _tipopago = "EVENTUAL" Then
                With cbxTipoConcepto
                    .DataSource = ds.Tables(indice_tabla)
                    .DisplayMember = ds.Tables(indice_tabla).Columns(1).ColumnName
                    .ValueMember = ds.Tables(indice_tabla).Columns(0).ColumnName
                    If (ds.Tables(indice_tabla).Rows.Count > 0) Then
                        .Value = ds.Tables(indice_tabla).Rows(6)(0)
                    End If
                End With
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub FrmAgregarConceptoSueldo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListarTablas()
        Select Case Tipo
            Case "SALARIO BASE"
                Me.Text = "AGREGAR SALARIO BASE"
            Case "DESCUENTO EXTRA"
                Me.Text = "AGREGAR DESCUENTO EXTRA"
            Case "APORTE EMPLEADOR"
                Me.Text = "AGREGAR APORTE EMPLEADOR"
            Case "SALARIO EXTRA"
                Me.Text = "AGREGAR INGRESO EXTRA"
            Case "DESCUENTO BASE"
                Me.Text = "AGREGAR DESCUENTO BASE"
            Case Else
                Me.Text = "AGREGAR CONCEPTO SUELDO"
        End Select

    End Sub
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If cbxTipoConcepto.Value Is Nothing OrElse IsDBNull(cbxTipoConcepto.Value) OrElse cbxTipoConcepto.Value = 0 Then
                MsgBox("Por favor, seleccione un concepto", MsgBoxStyle.Exclamation, "Advertencia")
                Exit Sub
            End If
            If String.IsNullOrEmpty(txtMontoconcepto.Text) OrElse cbxTipoConcepto.Value Is Nothing Then
                MsgBox("Por favor, complete todos los campos requeridos.", MsgBoxStyle.Exclamation, "Advertencia")
                Exit Sub
            End If
            InsertarMontoConcepto()
            formularioPrincipal.ListarTablas(id, idpago, Periodo)
            Dispose()
        Catch ex As Exception
            MsgBox("Ocurrió un error al guardar el monto concepto: " & ex.Message, MsgBoxStyle.Exclamation, "Advertencia")
        End Try
    End Sub


    Public Sub InsertarMontoConcepto()
        Dim nuevosueldoba As New coControlPagosyDes With {
        .IdPersona = id,
        .Importe = txtMontoconcepto.Text,
        .IdConceptoSueldo = cbxTipoConcepto.Value,
        .TipoQuincena = idpago,
        .Periodo = Periodo
    }
        Dim resultado As String = cn.Cn_AgregamosDetallesueldo(nuevosueldoba)
        If resultado = "" Then
            ' MsgBox("Concepto agregado correctamente.", MsgBoxStyle.Information, "Operación exitosa")
        Else
            MsgBox(resultado, MsgBoxStyle.Critical, "ALERTA")
        End If
    End Sub


    Private Sub txtmonto_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles txtMontoconcepto.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs)
        Dispose()
    End Sub

    Private Sub cbxTipoConcepto_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cbxTipoConcepto.InitializeLayout
        For Each column As UltraGridColumn In e.Layout.Bands(0).Columns
            column.PerformAutoResize(PerformAutoSizeType.AllRowsInBand, True)
            If column.Index = 0 Then
                column.Hidden = True
            End If
        Next
        With cbxTipoConcepto
            .DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList ' Evitar edición de texto
            .DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.False ' Evitar filtros
        End With
    End Sub
End Class