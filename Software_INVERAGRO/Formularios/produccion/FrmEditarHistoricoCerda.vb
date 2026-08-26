Imports CapaNegocio
Imports CapaObjetos

Public Class FrmEditarHistoricoCerda
    Dim cn As New cnControlAnimal
    Public idCerda As Integer = 0
    Public codAnimal As String = ""
    Public etapa As String = ""
    Public idUbicacion As Integer = 0

    Private Sub FrmEditarHistoricoCerda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LblCodArete.Text = codAnimal
        LblEtapa.Text = etapa
        ConsultarHistoricoxIdCerda()
        If etapa = "" Then
            LblEtapaAnimal.Visible = False
        End If
    End Sub

    Private Sub ConsultarHistoricoxIdCerda()
        Try
            Dim obj As New coControlAnimal With {
                .Codigo = idCerda
            }
            DtgListadoHistorico.DataSource = cn.Cn_ConsultarHistoricoxIdCerda(obj).Copy
            clsBasicas.Formato_Tablas_Grid(DtgListadoHistorico)
            DtgListadoHistorico.DisplayLayout.Bands(0).Columns(0).Hidden = True
            DtgListadoHistorico.DisplayLayout.Bands(0).Columns("PIC").Hidden = True
            DtgListadoHistorico.DisplayLayout.Bands(0).Columns("Registrado Por:").Hidden = True
            DtgListadoHistorico.DisplayLayout.Bands(0).Columns("Responsable").Hidden = True
            DtgListadoHistorico.DisplayLayout.Bands(0).Columns("Editar").Hidden = True
            DtgListadoHistorico.DisplayLayout.Bands(0).Columns("Eliminar").Hidden = True


            'Ancho de la columna NOTA
            DtgListadoHistorico.DisplayLayout.Bands(0).Columns("NOTA").Width = 350
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            Dim idsOrdenados As New List(Of String)
            If DtgListadoHistorico.Rows IsNot Nothing Then
                For Each row As Infragistics.Win.UltraWinGrid.UltraGridRow In DtgListadoHistorico.Rows
                    idsOrdenados.Add(row.Cells(0).Value.ToString())
                Next
            End If

            ' 1. Invertimos el orden de las filas que extrajimos
            idsOrdenados.Reverse()

            msj_advert("Se guardará el siguiente orden de historial: " & String.Join(", ", idsOrdenados))

            ' 2. Unimos la lista con comas (Ej: "49697,67771,67789") para enviarlo como String al PA
            Dim cadenaIds As String = String.Join(",", idsOrdenados)

            Dim obj As New coControlAnimal With {
                .Codigo = idCerda,
                .ListaIdsControlFicha = cadenaIds
            }

            If (MessageBox.Show("¿ESTÁ SEGURO DE ACTUALIZAR HISTORIAL DE " & codAnimal & " ?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
                Return
            End If

            Dim MensajeBgWk As String = cn.Cn_EditarHistorialHembra(obj)
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

    Private Sub MoverFila(direccion As Integer) ' -1 para subir, 1 para bajar
        Try
            ' 1. Obtener la fila seleccionada actualmente
            If DtgListadoHistorico.ActiveRow Is Nothing Then Return
            Dim row As Infragistics.Win.UltraWinGrid.UltraGridRow = DtgListadoHistorico.ActiveRow

            ' 2. Verificar que sea una fila con datos (no vacía) comprobando la primera columna (ID)
            If Not row.IsDataRow Then Return
            Dim idValue = row.Cells(0).Value
            If idValue Is Nothing OrElse String.IsNullOrWhiteSpace(idValue.ToString()) Then Return

            ' 3. Operar directamente sobre el DataTable conectado
            Dim dt As DataTable = CType(DtgListadoHistorico.DataSource, DataTable)

            ' Obtener el DataRow subyacente para saber su índice real
            Dim dataRowView As DataRowView = CType(row.ListObject, DataRowView)
            If dataRowView Is Nothing Then Return
            Dim actualRow As DataRow = dataRowView.Row
            Dim indexActual As Integer = dt.Rows.IndexOf(actualRow)
            Dim indexNuevo As Integer = indexActual + direccion

            ' 4. Validar limites y mover
            If indexNuevo >= 0 AndAlso indexNuevo < dt.Rows.Count Then
                ' Clonamos pasamos los datos
                Dim newRow As DataRow = dt.NewRow()
                newRow.ItemArray = actualRow.ItemArray

                ' Reordenamos
                dt.Rows.Remove(actualRow)
                dt.Rows.InsertAt(newRow, indexNuevo)
                dt.AcceptChanges()

                ' Mantenemos el foco en la fila recién movida
                DtgListadoHistorico.Rows.GetRowWithListIndex(indexNuevo).Activate()
                DtgListadoHistorico.Rows.GetRowWithListIndex(indexNuevo).Selected = True
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnMoveUp_Click(sender As Object, e As EventArgs) Handles btnMoveUp.Click
        MoverFila(-1)
    End Sub

    Private Sub btnMoveDown_Click(sender As Object, e As EventArgs) Handles btnMoveDown.Click
        MoverFila(1)
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Dispose()
    End Sub
End Class