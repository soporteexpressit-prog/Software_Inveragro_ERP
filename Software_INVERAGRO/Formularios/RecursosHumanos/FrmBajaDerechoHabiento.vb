Imports System.IO
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid

Public Class FrmBajaDerechoHabiento
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
            indice_tabla = 16
            ds.Tables(indice_tabla).Columns(1).ColumnName = "Descripción"
            With cbxmotivodebaja
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

    Private Sub FrmBajaDerechoHabiento_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            ListarTablas()
            If (esEdicion = 0) Then

            Else
            End If
            If (esEdicion <> 0) Then
                _frmTrabajador._operacion = 1
                If (esEdicion = 1) Then
                    'Consultar3()
                    Refresh()
                Else
                End If
            Else
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Private Sub actualizarbajafamilia()
        Try
            Dim objDerechoHabiente As New coDerechoHabiento
            objDerechoHabiente.fbaja = dtfechabaja.Value
            objDerechoHabiente.idmotivobaja = cbxmotivodebaja.Value
            objDerechoHabiente.idPersona = _frmTrabajador._Codigo

            Dim obj2 As New coTrabajador
            obj2.idhijo = idhijo

            ' Llamar al método para actualizar
            Dim resultado As String = cn.Cn_Actualizabajafamilia(objDerechoHabiente, obj2)

            ' Validar el resultado
            If String.IsNullOrEmpty(resultado) Then
                MessageBox.Show("Operación exitosa", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                _frmTrabajador.ConsultarHijosPorIdPersona()
                Dispose()
            Else
                msj_advert(resultado) ' Mostrar mensaje si hay un error específico
            End If
        Catch ex As Exception
            ' Mostrar mensaje de error en caso de excepción
            MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

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
                txtnombrehijo.Text = If(IsDBNull(row(4)), "", row(4).ToString())
                txtapaternohijo.Text = If(IsDBNull(row(5)), "", row(5).ToString())
                txtamaternohijo.Text = If(IsDBNull(row(6)), "", row(6).ToString())
            End If
        Else
            MessageBox.Show("No se encontró ningún registro con el código especificado.")
        End If
    End Sub

    Private Sub cbxmotivodebaja_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cbxmotivodebaja.InitializeLayout
        For Each column As UltraGridColumn In e.Layout.Bands(0).Columns
            column.PerformAutoResize(PerformAutoSizeType.AllRowsInBand, True)
        Next
        cbxmotivodebaja.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        e.Layout.Override.AllowUpdate = DefaultableBoolean.False
        e.Layout.Override.CellClickAction = CellClickAction.RowSelect
        e.Layout.Bands(0).ColHeadersVisible = False
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim result As DialogResult = MessageBox.Show("¿Está seguro de que desea dar de baja a este familiar?",
                                                 "Confirmación",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Warning)
        If result = DialogResult.Yes Then
            actualizarbajafamilia()
        End If
    End Sub


    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub
End Class