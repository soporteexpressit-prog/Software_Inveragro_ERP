Imports System.Text
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports iText.Kernel.Pdf.Canvas.Wmf

Public Class FrmAdministracionUsuarios
    Dim ds As DataSet
    Dim dt As DataTable
    Dim cn As New cnAdministrarUsuarios()
    Dim cn2 As New cnPerfil
    Dim idPerfil As Integer
    Dim estadoDiccionario As New Dictionary(Of Tuple(Of Integer, Integer, Integer, Integer), Boolean)
    Private currentHierarchy As New Dictionary(Of String, Integer)
    Private operacion As Integer = 0


    Private Sub FrmAdministracionUsuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListarPerfiles()
        ListarModulosSubModulos()
        ListarSoloModulos()
        'InicializarDtgPrueba()

        clsBasicas.Formato_Tablas_Grid(dtgListarPerfiles)
        clsBasicas.Formato_Tablas_Grid_Permisos(dtgPermisos)
        DesactivarTxt()
    End Sub

    Private Sub InicializarDtgPrueba()
        dt = New DataTable()
        dt.Columns.Add("Cod.", GetType(Integer))
        dt.Columns.Add("Nombre del Formulario", GetType(Integer))
        dt.Columns.Add("Estado", GetType(Boolean))

        dtgPermisos.DataSource = dt
    End Sub

    Sub ObtenerPermisosBotonesPorId(ByVal idPerfil As Integer, ByVal idSubModuloNivel1 As Integer, ByVal idSubModuloNivel2 As Integer?)
        Try
            Dim obj As New coAdministrarUsuarios
            obj.IdPerfil = idPerfil
            obj.IdSubModuloNivel1 = idSubModuloNivel1

            If idSubModuloNivel2.HasValue Then
                obj.IdSubModuloNivel2 = idSubModuloNivel2.Value
            Else
                obj.IdSubModuloNivel2 = Nothing
            End If

            dt = cn.Cn_ObtenerPermisosBotonesPorId(obj).Copy
            dtgPermisos.DataSource = dt
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Sub ObtenerPermisosSubModuloNivel2PorId(ByVal idPerfil As Integer, ByVal idSubModuloNivel1 As Integer)
        Try
            Dim obj As New coAdministrarUsuarios
            obj.IdPerfil = idPerfil
            obj.IdSubModuloNivel1 = idSubModuloNivel1
            dt = cn.Cn_ObtenerPermisosSubModuloNivel2PorId(obj).Copy
            dtgPermisos.DataSource = dt
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Sub ObtenerPermisosSubModuloNivel1PorId(ByVal idPerfil As Integer, ByVal idModulo As Integer)
        Try
            Dim obj As New coAdministrarUsuarios
            obj.IdPerfil = idPerfil
            obj.IdModulo = idModulo
            dt = cn.Cn_ObtenerPermisosSubModuloNivel1PorId(obj).Copy
            dtgPermisos.DataSource = dt
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Sub ObtenerPermisosModuloPorId(ByVal idPerfil As Integer)
        Try
            Dim obj As New coAdministrarUsuarios
            obj.IdPerfil = idPerfil
            dt = cn.Cn_ObtenerPermisosModuloPorId(obj).Copy
            dtgPermisos.DataSource = dt
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Sub ListarPerfiles()
        Try
            dt = cn2.Cn_ListarPerfiles().Copy
            dtgListarPerfiles.DataSource = dt
            Colorear()
            dtgListarPerfiles.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Sub ListarSoloModulos()
        Try
            dt = cn.Cn_ListarModulos().Copy
            dtgPermisos.DataSource = dt
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub
    Sub ObtenerSubModuloNivel1(ByVal idModulo As Integer)
        Try
            Dim obj As New coAdministrarUsuarios
            obj.IdModulo = idModulo
            dt = cn.Cn_ObtenerSubModuloNivel1xId(obj).Copy

            dtgPermisos.DataSource = dt
            dtgPermisos.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ObtenerSubModuloNivel2(ByVal idSubModuloNivel1 As Integer)
        Try
            Dim obj As New coAdministrarUsuarios
            obj.IdSubModuloNivel1 = idSubModuloNivel1
            dt = cn.Cn_ObtenerSubModuloNivel2xId(obj).Copy

            dtgPermisos.DataSource = dt
            dtgPermisos.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ObtenerBotones(ByVal idSubModuloNivel1 As Integer, ByVal idSubModuloNivel2 As Integer?)
        Try
            Dim obj As New coAdministrarUsuarios
            obj.IdSubModuloNivel1 = idSubModuloNivel1

            If idSubModuloNivel2.HasValue Then
                obj.IdSubModuloNivel2 = idSubModuloNivel2.Value
            Else
                obj.IdSubModuloNivel2 = Nothing
            End If

            dt = cn.Cn_ObtenerBotonesxId(obj).Copy
            dtgPermisos.DataSource = dt
            dtgPermisos.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try

    End Sub

    Sub ListarModulosSubModulos()
        ds = cn.Cn_ListarModulosSubModulos().Copy
        ds.DataSetName = "tmp"

        Dim relation1 As New DataRelation("tb_relacion1", ds.Tables.Item(0).Columns.Item(0), ds.Tables.Item(1).Columns.Item(0), False)
        ds.Relations.Add(relation1)

        Dim relation2 As New DataRelation("tb_relacion2", ds.Tables.Item(1).Columns.Item(1), ds.Tables.Item(2).Columns.Item(0), False)
        ds.Relations.Add(relation2)

        treeViewModulos.Nodes.Clear()

        For Each row As DataRow In ds.Tables(0).Rows
            Dim parentNode As TreeNode = New TreeNode(row("Modulo").ToString()) '
            parentNode.Tag = row

            For Each childRow As DataRow In row.GetChildRows(relation1)
                Dim childNode As TreeNode = New TreeNode(childRow("Sub Modulo Nivel 1").ToString())
                childNode.Tag = childRow

                For Each grandChildRow As DataRow In childRow.GetChildRows(relation2)
                    Dim grandChildNode As TreeNode = New TreeNode(grandChildRow("Sub Modulo Nivel 2").ToString())
                    grandChildNode.Tag = grandChildRow
                    childNode.Nodes.Add(grandChildNode)
                Next

                parentNode.Nodes.Add(childNode)
            Next

            treeViewModulos.Nodes.Add(parentNode)
        Next

        ' Opcional: Expande todos los nodos
        'treeViewModulos.ExpandAll()
    End Sub

    Public Sub LlenarCamposCapacitador(codigo As Integer, rol As String)
        idPerfil = codigo
        txtCodigo.Text = codigo
        txtRol.Text = rol
    End Sub

    Private Sub dtgListarPerfiles_DoubleClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickCellEventArgs) Handles dtgListarPerfiles.DoubleClickCell
        Try
            If (dtgListarPerfiles.Rows.Count > 0) Then
                Dim activeRow = dtgListarPerfiles.ActiveRow
                If activeRow IsNot Nothing AndAlso activeRow.Cells(0).Value IsNot Nothing AndAlso activeRow.Cells(0).Value.ToString().Length <> 0 Then
                    If activeRow.Cells(0).Value IsNot Nothing AndAlso activeRow.Cells(1).Value IsNot Nothing AndAlso
                   activeRow.Cells(2).Value IsNot Nothing Then

                        LlenarCamposCapacitador(
                        activeRow.Cells(0).Value.ToString(),
                        activeRow.Cells(1).Value.ToString()
                    )
                    Else
                        msj_advert("Algunas celdas no tienen valores válidos.")
                    End If
                Else
                    msj_advert("Seleccione un Registro válido.")
                End If
            Else
                msj_advert("Seleccione un Registro.")
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub DesactivarTxt()
        txtCodigo.Enabled = False
        txtRol.Enabled = False
    End Sub

    Sub Cancelar()
        txtCodigo.Clear()
        txtRol.Clear()

        estadoDiccionario.Clear()
    End Sub

    Sub Colorear()
        If (dtgListarPerfiles.Rows.Count > 0) Then
            Dim permisoAsignado As Integer = 3

            'permisoAsignado
            clsBasicas.Colorear_SegunValor(dtgListarPerfiles, Color.Red, Color.White, "NO", permisoAsignado)
            clsBasicas.Colorear_SegunValor(dtgListarPerfiles, Color.Green, Color.White, "SI", permisoAsignado)

            'centrar columnas
            With dtgListarPerfiles.DisplayLayout.Bands(0)
                .Columns(permisoAsignado).CellAppearance.TextHAlign = HAlign.Center
            End With
        End If
    End Sub

    Private Sub treeViewModulos_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles treeViewModulos.AfterSelect
        Dim selectedNode As TreeNode = e.Node

        ' Resetear la jerarquía actual
        currentHierarchy.Clear()

        ' Reconstruir la jerarquía basada en el nodo seleccionado
        Dim currentNode As TreeNode = selectedNode
        While currentNode IsNot Nothing
            Dim nodeData As DataRow = CType(currentNode.Tag, DataRow)
            If currentNode.Level = 0 Then ' Módulo
                currentHierarchy("Cod. Modulo") = Convert.ToInt32(nodeData("Código"))
            ElseIf currentNode.Level = 1 Then ' SubModulo Nivel 1
                currentHierarchy("Cod. SubModuloNivel1") = Convert.ToInt32(nodeData("Código"))
            ElseIf currentNode.Level = 2 Then ' SubModulo Nivel 2
                currentHierarchy("Cod. SubModuloNivel2") = Convert.ToInt32(nodeData("Código"))
            End If
            currentNode = currentNode.Parent
        End While

        ' Verifica si es un nodo de "Sub Modulo Nivel 2"
        If selectedNode.Parent IsNot Nothing AndAlso selectedNode.Parent.Parent IsNot Nothing Then
            ' Es un nodo de "Sub Modulo Nivel 2"
            Dim subModuloNivel2 As DataRow = CType(selectedNode.Tag, DataRow)
            Dim subModuloNivel1 As DataRow = CType(selectedNode.Tag, DataRow)

            Console.WriteLine("Columnas disponibles en subModuloNivel1: (TABLA 2)")
            For Each col As DataColumn In subModuloNivel1.Table.Columns
                Console.WriteLine(col.ColumnName)
            Next

            Console.WriteLine("Columnas disponibles en subModuloNivel2: (TABLA 2)")
            For Each col As DataColumn In subModuloNivel2.Table.Columns
                Console.WriteLine(col.ColumnName)
            Next

            Dim idSubModuloNivel1 As Integer = Convert.ToInt32(subModuloNivel1("idSubModuloNivel1"))
            Dim codigoSubModuloNivel2 As Integer = Convert.ToInt32(subModuloNivel2("Código"))

            If operacion = 1 Then
                ObtenerPermisosBotonesPorId(idPerfil, idSubModuloNivel1, codigoSubModuloNivel2)
            Else
                ObtenerBotones(idSubModuloNivel1, codigoSubModuloNivel2)
            End If


        ElseIf selectedNode.Parent IsNot Nothing Then
            ' Es un nodo de "Sub Modulo Nivel 1"
            Dim subModuloNivel1 As DataRow = CType(selectedNode.Tag, DataRow)
            Dim idModulo As DataRow = CType(selectedNode.Tag, DataRow)
            Console.WriteLine("Columnas disponibles en subModuloNivel1: (TABLA 1)")
            For Each col As DataColumn In subModuloNivel1.Table.Columns
                Console.WriteLine(col.ColumnName)
            Next

            Dim codigoSubModuloNivel1 As Integer = Convert.ToInt32(subModuloNivel1("Código"))

            Dim codigoIdModulo As Integer = Convert.ToInt32(subModuloNivel1("idModulo"))
            Console.WriteLine("idModulo: " & codigoIdModulo)

            If operacion = 1 Then
                If selectedNode.Nodes.Count > 0 Then 'Si tiene hijos, se llama al método para obtener los que están dentro de ese subModulo
                    ObtenerPermisosSubModuloNivel2PorId(idPerfil, codigoSubModuloNivel1)
                Else
                    ObtenerPermisosBotonesPorId(idPerfil, codigoSubModuloNivel1, Nothing) 'Si no tiene hijos, se sigue el método normalmente 
                End If
            Else
                If selectedNode.Nodes.Count > 0 Then 'Si tiene hijos, se llama al método para obtener los que están dentro de ese subModulo
                    ObtenerSubModuloNivel2(codigoSubModuloNivel1)
                Else
                    ObtenerBotones(codigoSubModuloNivel1, Nothing) 'Si no tiene hijos, se sigue el método normalmente 
                End If
            End If

        ElseIf selectedNode IsNot Nothing Then
            ' Es un nodo de "Modulo"
            Dim modulo As DataRow = CType(selectedNode.Tag, DataRow)
            Console.WriteLine("Columnas disponibles en modulo: (TABLA 0)")
            For Each col As DataColumn In modulo.Table.Columns
                Console.WriteLine(col.ColumnName)
            Next

            Dim codigoModulo As Integer = Convert.ToInt32(modulo("Código"))
            Console.WriteLine(codigoModulo)

            If operacion = 1 Then
                ObtenerPermisosSubModuloNivel1PorId(idPerfil, codigoModulo)
            Else
                ObtenerSubModuloNivel1(codigoModulo)
            End If

        End If
        clsBasicas.Formato_Tablas_Grid_Permisos(dtgPermisos)
    End Sub

    Private Sub dtgPermisos_AfterCellUpdate(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtgPermisos.AfterCellUpdate
        ' Verifica si la columna modificada es la columna de estado
        If e.Cell.Column.Key = "Estado" Then
            ' Forzar la actualización del valor en la celda
            e.Cell.Row.Update()

            ' Inicializa variables con valores predeterminados
            Dim idModulo As Integer = If(currentHierarchy.ContainsKey("Cod. Modulo"), currentHierarchy("Cod. Modulo"), Nothing)
            Dim idSubModuloNivel1 As Integer = If(currentHierarchy.ContainsKey("Cod. SubModuloNivel1"), currentHierarchy("Cod. SubModuloNivel1"), Nothing)
            Dim idSubModuloNivel2 As Integer = If(currentHierarchy.ContainsKey("Cod. SubModuloNivel2"), currentHierarchy("Cod. SubModuloNivel2"), Nothing)
            Dim idBotones As Integer = Nothing

            ' Intenta obtener los valores de las columnas que forman la clave
            If e.Cell.Row.Cells.Exists("Cod. Modulo") Then
                idModulo = Convert.ToInt32(e.Cell.Row.Cells("Cod. Modulo").Value)
            End If
            If e.Cell.Row.Cells.Exists("Cod. SubModuloNivel1") Then
                idSubModuloNivel1 = Convert.ToInt32(e.Cell.Row.Cells("Cod. SubModuloNivel1").Value)
            End If
            If e.Cell.Row.Cells.Exists("Cod. SubModuloNivel2") Then
                idSubModuloNivel2 = Convert.ToInt32(e.Cell.Row.Cells("Cod. SubModuloNivel2").Value)
            End If
            If e.Cell.Row.Cells.Exists("Cod. Boton") Then
                idBotones = Convert.ToInt32(e.Cell.Row.Cells("Cod. Boton").Value)
            End If

            ' Depuración adicional
            Console.WriteLine($"idModulo: {idModulo}, idSubModuloNivel1: {idSubModuloNivel1}, idSubModuloNivel2: {idSubModuloNivel2}, idBotones: {idBotones}")

            ' Crea la clave de la fila usando una Tuple
            Dim clave As Tuple(Of Integer, Integer, Integer, Integer) = Tuple.Create(idModulo, idSubModuloNivel1, idSubModuloNivel2, idBotones)

            ' Obtiene el nuevo valor del estado (True o False)
            Dim nuevoEstado As Boolean = Convert.ToBoolean(e.Cell.Value)

            ' Guarda el valor en el diccionario
            If estadoDiccionario.ContainsKey(clave) Then
                estadoDiccionario(clave) = nuevoEstado
            Else
                estadoDiccionario.Add(clave, nuevoEstado)
            End If

            ' Forzar la actualización visual del grid
            dtgPermisos.UpdateData()

            ' Imprimir el contenido actualizado del diccionario en la consola
            Console.WriteLine("Contenido actualizado del diccionario:")
            For Each kvp As KeyValuePair(Of Tuple(Of Integer, Integer, Integer, Integer), Boolean) In estadoDiccionario
                Console.WriteLine($"Clave: ({kvp.Key.Item1}, {kvp.Key.Item2}, {kvp.Key.Item3}, {kvp.Key.Item4}), Valor: {kvp.Value}")
            Next

            ' Imprimir el contenido actualizado del diccionario en la consola
            Console.WriteLine("Contenido actualizado del diccionario:")
            Console.WriteLine(ConvertDiccionarioToString())

            ' Imprimir el número de elementos en el diccionario
            Console.WriteLine($"Número de elementos en el diccionario: {estadoDiccionario.Count}")
        End If

    End Sub

    Private Sub dtgPermisos_CellChange(sender As Object, e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles dtgPermisos.CellChange
        If e.Cell.Column.Key = "Estado" Then
            e.Cell.Row.Update()
            dtgPermisos.UpdateData()
        End If
    End Sub

    Private Sub dtgPermisos_InitializeRow(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles dtgPermisos.InitializeRow
        Dim idModulo As Integer = If(currentHierarchy.ContainsKey("Cod. Modulo"), currentHierarchy("Cod. Modulo"), Nothing)
        Dim idSubModuloNivel1 As Integer = If(currentHierarchy.ContainsKey("Cod. SubModuloNivel1"), currentHierarchy("Cod. SubModuloNivel1"), Nothing)
        Dim idSubModuloNivel2 As Integer = If(currentHierarchy.ContainsKey("Cod. SubModuloNivel2"), currentHierarchy("Cod. SubModuloNivel2"), Nothing)
        Dim idBotones As Integer = Nothing

        If e.Row.Cells.Exists("Cod. Modulo") Then
            idModulo = Convert.ToInt32(e.Row.Cells("Cod. Modulo").Value)
        End If
        If e.Row.Cells.Exists("Cod. SubModuloNivel1") Then
            idSubModuloNivel1 = Convert.ToInt32(e.Row.Cells("Cod. SubModuloNivel1").Value)
        End If
        If e.Row.Cells.Exists("Cod. SubModuloNivel2") Then
            idSubModuloNivel2 = Convert.ToInt32(e.Row.Cells("Cod. SubModuloNivel2").Value)
        End If
        If e.Row.Cells.Exists("Cod. Boton") Then
            idBotones = Convert.ToInt32(e.Row.Cells("Cod. Boton").Value)
        End If

        Dim clave As Tuple(Of Integer, Integer, Integer, Integer) = Tuple.Create(idModulo, idSubModuloNivel1, idSubModuloNivel2, idBotones)

        ' Si el diccionario contiene un estado para esta fila, aplicarlo
        If estadoDiccionario.ContainsKey(clave) Then
            e.Row.Cells("Estado").Value = estadoDiccionario(clave)
        ElseIf e.Row.Cells.Exists("Estado") Then
            ' Si no está en el diccionario, guardamos el valor original
            Dim estadoOriginal As Boolean = Convert.ToBoolean(e.Row.Cells("Estado").Value)
            estadoDiccionario(clave) = estadoOriginal
        End If
    End Sub

    Private Function ConvertDiccionarioToString() As String
        Dim resultado As New StringBuilder()
        Dim totalElementos As Integer = estadoDiccionario.Count
        Dim contador As Integer = 0

        For Each kvp As KeyValuePair(Of Tuple(Of Integer, Integer, Integer, Integer), Boolean) In estadoDiccionario
            Dim clave As Tuple(Of Integer, Integer, Integer, Integer) = kvp.Key
            Dim estado As Boolean = kvp.Value

            Dim formato As String = $"{clave.Item1}+{clave.Item2}+{clave.Item3}+{clave.Item4}+{estado}"
            resultado.Append(formato)

            contador += 1
            If contador < totalElementos Then
                resultado.Append(",")
            End If
        Next

        Return resultado.ToString()
    End Function
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        If estadoDiccionario.Count = 0 Then
            msj_advert("No se han seleccionado permisos.")
            Return
        End If

        If idPerfil = 0 Then
            msj_advert("Seleccione un perfil.")
            Return
        End If

        If (MessageBox.Show("¿ESTÁ SEGURO DE GUARDAR LOS PERMISOS PARA ESTE PERFIL?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No) Then
            Return
        End If

        Dim msj As String
        Dim obj As New coAdministrarUsuarios
        obj.IdPerfil = idPerfil
        obj.Lista_Permisos = ConvertDiccionarioToString()
        obj.Operacion = operacion
        msj = cn.Cn_RegDetallePermiso(obj)
        If obj.Coderror <> 0 Then
            msj_advert(msj)
        Else
            msj_ok(msj)
            CancelarDos()
            ListarPerfiles()
        End If
    End Sub

    Private Sub btnAsignar_Click(sender As Object, e As EventArgs) Handles btnAsignar.Click
        Dim f As New FrmAsignarPerfil
        f.ShowDialog()
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Dim f As New FrmActualizarPerfil
        f.ShowDialog()
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Try
            Dim activeRow As Infragistics.Win.UltraWinGrid.UltraGridRow = dtgListarPerfiles.ActiveRow
            If (dtgListarPerfiles.Rows.Count > 0) Then
                If (activeRow.Cells(0).Value.ToString.Length <> 0) Then
                    Dim permisoAsignado As String = activeRow.Cells(3).Value.ToString

                    If permisoAsignado = "NO" Then
                        msj_advert("El perfil seleccionado no tiene permisos asignados para poder editar.")
                        Return
                    Else
                        estadoDiccionario.Clear()
                        currentHierarchy.Clear()
                        operacion = 1
                        Cambio()
                    End If
                Else
                    msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
                End If
            Else
                msj_advert(MensajesSistema.mensajesGenerales("SELECCIONE_REGISTRO"))
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        operacion = 0
        CancelarDos()
    End Sub
    Sub Cambio()
        If Not txtCodigo.Text = "" Then
            txtRol.Enabled = False
            txtCodigo.Enabled = False
            btnEditar.Visible = False
            btnGuardar.Visible = True
            btnCancelar.Visible = True

            ObtenerPermisosModuloPorId(idPerfil)
        Else
            msj_advert("Seleccione un Registro")
        End If
    End Sub

    Sub CancelarDos()
        btnEditar.Visible = True
        btnCancelar.Visible = False
        txtCodigo.Clear()
        txtCodigo.Enabled = False
        txtRol.Clear()
        txtRol.Enabled = False

        estadoDiccionario.Clear()
        ListarSoloModulos()
    End Sub
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Dispose()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim isFilterActive As Boolean = Not ToolStripButton1.Checked
        ToolStripButton1.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtgListarPerfiles, isFilterActive)
    End Sub
End Class