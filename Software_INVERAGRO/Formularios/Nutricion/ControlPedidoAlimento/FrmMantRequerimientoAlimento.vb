Imports CapaNegocio
Imports CapaObjetos

Public Class FrmMantRequerimientoAlimento
    Dim cn As New cnControlAlimento
    Dim dtRequerimientos As New DataTable
    Public idSalida As Integer

    Private Sub FrmMantRequerimientoAlimento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtCantidad.ReadOnly = True
        CargarRaciones()
    End Sub

    Private Sub CargarRaciones()
        Try
            Dim obj As New coControlAlimento With {
                .Codigo = idSalida
            }
            dtRequerimientos = cn.Cn_ObtenerRequerimientoAlimentoxId(obj)


            If Not dtRequerimientos.Columns.Contains("Cantidad Ajustada") Then
                dtRequerimientos.Columns.Add("Cantidad Ajustada", GetType(Decimal))

                For Each row As DataRow In dtRequerimientos.Rows
                    row("Cantidad Ajustada") = row("Cantidad")
                Next
            End If

            Dim viewRaciones As DataView = New DataView(dtRequerimientos)
            Dim dtRacionesSinRepetir As DataTable = viewRaciones.ToTable(True, "Código", "Ración", "Cantidad", "Cantidad Ajustada")
            dtgListadoAlimento.DataSource = dtRacionesSinRepetir
            clsBasicas.Formato_Tablas_Grid(dtgListadoAlimento)
            dtgListadoAlimento.DisplayLayout.Bands(0).Columns("Código").Hidden = True
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub dtgListadoAlimento_AfterRowActivate(sender As Object, e As EventArgs) Handles dtgListadoAlimento.AfterRowActivate
        Dim codigoRacion As Integer = CInt(dtgListadoAlimento.ActiveRow.Cells("Código").Value)
        Dim filas() As DataRow = dtRequerimientos.Select("Código = " & codigoRacion)

        If filas.Length > 0 Then
            txtCantidad.Text = filas(0)("Cantidad").ToString()
            txtCantidadAjustada.Text = filas(0)("Cantidad Ajustada").ToString()
        End If

        CargarMedicamentos(codigoRacion)
    End Sub
    Private Sub txtCantidadAjustada_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidadAjustada.KeyPress
        clsBasicas.ValidarDecimalEstricto(sender, e)
    End Sub

    Private Sub txtCantidadAjustada_TextChanged(sender As Object, e As EventArgs) Handles txtCantidadAjustada.TextChanged

        Dim cantidadAjustada As Decimal
        If Decimal.TryParse(txtCantidadAjustada.Text, cantidadAjustada) Then
            Dim codigoRacion As Integer = CInt(dtgListadoAlimento.ActiveRow.Cells("Código").Value)

            Dim filas() As DataRow = dtRequerimientos.Select("Código = " & codigoRacion)
            If filas.Length > 0 Then
                filas(0)("Cantidad Ajustada") = cantidadAjustada
            End If

            For Each row As DataRow In DirectCast(dtgListadoAlimento.DataSource, DataTable).Rows
                If CInt(row("Código")) = codigoRacion Then
                    row("Cantidad Ajustada") = cantidadAjustada
                    Exit For
                End If
            Next

            dtgListadoAlimento.Refresh()
        End If
    End Sub

    Private Sub CargarMedicamentos(ByVal idDetalleSalida As Integer)
        Dim viewMedicamentos As DataView = New DataView(dtRequerimientos)
        viewMedicamentos.RowFilter = "Código = " & idDetalleSalida & " AND [idMedicamentoRacion] IS NOT NULL"

        If viewMedicamentos.Count > 0 Then
            dtgListadoMedicamento.DataSource = viewMedicamentos.ToTable()
            dtgListadoMedicamento.DisplayLayout.Bands(0).Columns(0).Hidden = True
            dtgListadoMedicamento.DisplayLayout.Bands(0).Columns(1).Hidden = True
            dtgListadoMedicamento.DisplayLayout.Bands(0).Columns(2).Hidden = True
            dtgListadoMedicamento.DisplayLayout.Bands(0).Columns(3).Hidden = True
            dtgListadoMedicamento.DisplayLayout.Bands(0).Columns(6).Hidden = True
        Else
            Dim dtNoMedicamentos As New DataTable
            dtNoMedicamentos.Columns.Add("Mensaje", GetType(String))
            Dim row As DataRow = dtNoMedicamentos.NewRow()
            row("Mensaje") = "No se encontraron medicamentos"
            dtNoMedicamentos.Rows.Add(row)

            dtgListadoMedicamento.DataSource = dtNoMedicamentos
        End If

        clsBasicas.Formato_Tablas_Grid(dtgListadoMedicamento)
    End Sub


    Private Sub btnAprobar_Click(sender As Object, e As EventArgs) Handles btnAprobar.Click
        Try
            Console.WriteLine("Array: " + creacion_de_array_alimento())
            For i = 0 To dtgListadoAlimento.Rows.Count - 1
                Dim cantidadAjustada As Decimal = CDec(dtgListadoAlimento.Rows(i).Cells("Cantidad Ajustada").Value)
                If cantidadAjustada = 0 Then
                    msj_advert("Existen raciones con la cantidad ajustada en 0. Por favor revise antes de continuar.")
                    Return
                End If
            Next

            If (MessageBox.Show("¿Está seguro de aprobar el requerimiento de alimento?", "Aprobar Requerimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim obj As New coControlAlimento
            obj.Codigo = idSalida
            obj.IdUsuario = VP_IdUser
            obj.ListaAlimentos = creacion_de_array_alimento()

            Dim MensajeBgWk As String = ""
            MensajeBgWk = cn.Cn_ActualizarRequerimientoAlimento(obj)
            If (obj.Coderror = 0) Then
                msj_ok(MensajeBgWk)
                Close()
            Else
                msj_advert(MensajeBgWk)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Function creacion_de_array_alimento() As String
        Dim array_alimentos As String = ""

        If (dtgListadoAlimento.Rows.Count = 0) Then
            array_alimentos = "0"
        Else
            For i = 0 To dtgListadoAlimento.Rows.Count - 1
                If (dtgListadoAlimento.Rows(i).Cells("Código").Value.ToString.Trim.Length <> 0) Then
                    With dtgListadoAlimento.Rows(i)
                        array_alimentos &= .Cells("Código").Value.ToString.Trim & "+" &
                            .Cells("Cantidad Ajustada").Value.ToString.Trim & ","
                    End With
                End If
            Next
        End If

        Return array_alimentos
    End Function

    Private Sub dtgListadoAlimento_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles dtgListadoAlimento.InitializeLayout
        Try
            If (dtgListadoAlimento.Rows.Count = 0) Then
            Else
                e.Layout.Bands(0).Summaries.Clear()
                clsBasicas.Totales_Formato(dtgListadoAlimento, e, 1)
                clsBasicas.SumarTotales_Formato(dtgListadoAlimento, e, 2)
                clsBasicas.SumarTotales_Formato(dtgListadoAlimento, e, 3)
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class