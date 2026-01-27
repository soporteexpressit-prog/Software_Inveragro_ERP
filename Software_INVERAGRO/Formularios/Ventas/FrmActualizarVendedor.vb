Imports CapaNegocio
Imports CapaObjetos
Imports Stimulsoft.Report.StiOptions.Export
Imports System.IO

Public Class FrmActualizarVendedor
    Dim cn As New cnVentas
    Public _codigo As Integer = 0
    Public operacion As Integer = 0
    Private Sub btnguardar_Click(sender As Object, e As EventArgs) Handles btnguardar.Click
        Try
            Dim obj As New coVentas
            obj.Codigo = _codigo
            obj.Iduser = cbxvendedor.SelectedValue
            obj.Observacion = cbxvendedor.Text
            Dim MensajeBgWk As String = ""
            If operacion = 0 Then
                MensajeBgWk = cn.Cn_Regactualizacionvendedor(obj)
            ElseIf operacion = 1 Then
                MensajeBgWk = cn.Cn_Regactualizacioncerdo(obj)
            ElseIf operacion = 2 Then
                MensajeBgWk = cn.Cn_Regactualizacionatipopeso(obj)
            End If
            If (obj.Coderror = 0) Then
                msj_ok(MensajeBgWk)
                Dispose()
            Else
                msj_advert(MensajeBgWk)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btncerrar_Click(sender As Object, e As EventArgs) Handles btncerrar.Click
        Dispose()
    End Sub

    Private Sub FrmActualizarVendedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If operacion = 0 Then
            clsBasicas.ListartodosVendedoresyconductores(cbxvendedor)
            Me.Text = "Actualizar Vendedor"
            GrupoMasOpcionesBusqueda.Text = "Actualizar Vendedor"
        ElseIf operacion = 1 Then
            ListarTablas()
            Me.Text = "Actualizar Cerdo"
            GrupoMasOpcionesBusqueda.Text = "Actualizar Cerdo"
            Label12.Text = "Motivo de Transacción : "
        ElseIf operacion = 2 Then
            Listartipopeso()
            Me.Text = "Actualizar Tipo de Peso"
            GrupoMasOpcionesBusqueda.Text = "Actualizar Tipo de Peso"
            Label12.Text = "Tipo de Peso : "
        End If
    End Sub


    Sub Listartipopeso()
        Try
            Dim ds As New DataSet
            ds = cn.Cn_ListarTablasMaestrasPedidoVentaCerdo().Copy
            ds.DataSetName = "tmp"
            ds.Tables(0).Columns(1).ColumnName = "Seleccione una Moneda"

            Dim indice_tabla As Integer = 0
            indice_tabla = 1
            indice_tabla = 2
            indice_tabla = 4
            ds.Tables(indice_tabla).Columns(1).ColumnName = "Seleccione un Tipo de peso"
            With cbxvendedor
                .DataSource = ds.Tables(indice_tabla)
                .DisplayMember = ds.Tables(indice_tabla).Columns(1).ColumnName
                .ValueMember = ds.Tables(indice_tabla).Columns(0).ColumnName
                If (ds.Tables(indice_tabla).Rows.Count > 0) Then
                    .SelectedValue = ds.Tables(indice_tabla).Rows(0)(0)
                End If
            End With


        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ListarTablas()
        Try
            Dim ds As New DataSet
            ds = cn.Cn_ListarTablasMaestrasPedidoVentaCerdo().Copy
            ds.DataSetName = "tmp"
            ds.Tables(0).Columns(1).ColumnName = "Seleccione una Moneda"

            Dim indice_tabla As Integer = 0
            indice_tabla = 1
            indice_tabla = 2
            ds.Tables(indice_tabla).Columns(1).ColumnName = "Seleccione un Motivo de Transacción"
            With cbxvendedor
                .DataSource = ds.Tables(indice_tabla)
                .DisplayMember = ds.Tables(indice_tabla).Columns(1).ColumnName
                .ValueMember = ds.Tables(indice_tabla).Columns(0).ColumnName
                If (ds.Tables(indice_tabla).Rows.Count > 0) Then
                    .SelectedValue = ds.Tables(indice_tabla).Rows(0)(0)
                End If
            End With


        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

End Class