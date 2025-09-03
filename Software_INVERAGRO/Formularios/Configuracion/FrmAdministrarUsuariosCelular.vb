Imports System.Text
Imports CapaDatos
Imports CapaNegocio
Imports CapaObjetos
Imports Infragistics.Win

Public Class FrmAdministrarUsuariosCelular

    Dim ds As DataSet
    Dim dt As DataTable
    Dim cn As New cnAdministrarUsuarios()
    Private currentHierarchy As New Dictionary(Of String, Integer)
    Dim estadoDiccionario As New Dictionary(Of Tuple(Of Integer, Integer), Boolean)
    Dim cn2 As New cnPerfil
    Private operacion As Integer = 0
    Dim idPerfil As Integer

    Private Sub FrmAdministrarUsuariosCelular_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clsBasicas.Formato_Tablas_Grid(dtgListarPerfiles)
        ListarPerfiles()
        ListarModulosSubModulos()
        ListarSoloModulos()

        clsBasicas.Formato_Tablas_Grid(dtgListarPerfiles)
        clsBasicas.Formato_Tablas_Grid_Permisos(dtgPermisos)
        DesactivarTxt()
    End Sub
    Private Sub btnAsignar_Click(sender As Object, e As EventArgs) Handles btnAsignar.Click
        Dim f As New FrmAsignarPerfilMovil
        f.ShowDialog()
    End Sub

    Sub DesactivarTxt()
        txtCodigo.Enabled = False
        txtRol.Enabled = False
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Close()
    End Sub

    Private Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Dim f As New FrmActualizarPerfilMovil
        f.ShowDialog()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        operacion = 0
        CancelarDos()
    End Sub

    Sub ObtenerPermisosSubModuloNivel1PorId(ByVal idPerfil As Integer, ByVal idModulo As Integer)
        Try
            Dim obj As New coAdministrarUsuarios
            obj.IdPerfil = idPerfil
            obj.IdModulo = idModulo
            dt = cn.Cn_ObtenerPermisosSubModuloCelularPorId(obj).Copy
            dtgPermisos.DataSource = dt
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ObtenerPermisosModuloPorId(ByVal idPerfil As Integer)
        Try
            Dim obj As New coAdministrarUsuarios
            obj.IdPerfil = idPerfil
            dt = cn.Cn_ObtenerPermisosModuloCelularPorId(obj).Copy
            dtgPermisos.DataSource = dt
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ListarPerfiles()
        Try
            dt = cn2.Cn_ListarPerfilesDispositivoMovil().Copy
            dtgListarPerfiles.DataSource = dt
            Colorear()
            dtgListarPerfiles.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ListarSoloModulos()
        Try
            dt = cn.Cn_ListarModulosCelular().Copy
            dtgPermisos.DataSource = dt
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ObtenerSubModuloNivel1(ByVal idModulo As Integer)
        Try
            Dim obj As New coAdministrarUsuarios
            obj.IdModulo = idModulo
            dt = cn.Cn_ObtenerSubModuloCelularPorId(obj).Copy

            dtgPermisos.DataSource = dt
            dtgPermisos.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Sub ListarModulosSubModulos()
        ds = cn.Cn_ListarModulosSubModulosCelular().Copy
        ds.DataSetName = "tmp"

        treeViewModulos.Nodes.Clear()

        For Each row As DataRow In ds.Tables(0).Rows
            Dim parentNode As TreeNode = New TreeNode(row("Modulo").ToString())
            parentNode.Tag = row

            ' Solo se agrega el nodo del módulo, no se procesan los submódulos
            treeViewModulos.Nodes.Add(parentNode)
        Next
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
            ElseIf currentNode.Level = 1 Then ' Sub Módulo Nivel 1
                currentHierarchy("Cod. SubModulo") = Convert.ToInt32(nodeData("Código"))
            End If
            currentNode = currentNode.Parent
        End While

        If selectedNode IsNot Nothing Then
            ' Es un nodo de "Módulo"
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
            Dim idSubModuloNivel1 As Integer = If(currentHierarchy.ContainsKey("Cod. SubModulo"), currentHierarchy("Cod. SubModulo"), Nothing)

            ' Intenta obtener los valores de las columnas que forman la clave
            If e.Cell.Row.Cells.Exists("Cod. Modulo") Then
                idModulo = Convert.ToInt32(e.Cell.Row.Cells("Cod. Modulo").Value)
            End If
            If e.Cell.Row.Cells.Exists("Cod. SubModulo") Then
                idSubModuloNivel1 = Convert.ToInt32(e.Cell.Row.Cells("Cod. SubModulo").Value)
            End If
            ' Depuración adicional
            Console.WriteLine($"idModulo: {idModulo}, idSubModuloNivel1: {idSubModuloNivel1}")

            ' Crea la clave de la fila usando una Tuple
            Dim clave As Tuple(Of Integer, Integer) = Tuple.Create(idModulo, idSubModuloNivel1)

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
            For Each kvp As KeyValuePair(Of Tuple(Of Integer, Integer), Boolean) In estadoDiccionario
                Console.WriteLine($"Clave: ({kvp.Key.Item1}, {kvp.Key.Item2}), Valor: {kvp.Value}")
            Next

            'Imprimir el contenido actualizado del diccionario en la consola
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
        Dim idSubModuloNivel1 As Integer = If(currentHierarchy.ContainsKey("Cod. SubModulo"), currentHierarchy("Cod. SubModulo"), Nothing)

        If e.Row.Cells.Exists("Cod. Modulo") Then
            idModulo = Convert.ToInt32(e.Row.Cells("Cod. Modulo").Value)
        End If
        If e.Row.Cells.Exists("Cod. SubModulo") Then
            idSubModuloNivel1 = Convert.ToInt32(e.Row.Cells("Cod. SubModulo").Value)
        End If

        Dim clave As Tuple(Of Integer, Integer) = Tuple.Create(idModulo, idSubModuloNivel1)

        ' Si el diccionario contiene un estado para esta fila, aplicarlo
        If estadoDiccionario.ContainsKey(clave) Then
            e.Row.Cells("Estado").Value = estadoDiccionario(clave)
        ElseIf e.Row.Cells.Exists("Estado") Then
            ' Si no está en el diccionario, guardamos el valor original
            Dim estadoOriginal As Boolean = Convert.ToBoolean(e.Row.Cells("Estado").Value)
            estadoDiccionario(clave) = estadoOriginal
        End If
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

    Private Function ConvertDiccionarioToString() As String
        Dim resultado As New StringBuilder()
        Dim totalElementos As Integer = estadoDiccionario.Count
        Dim contador As Integer = 0

        For Each kvp As KeyValuePair(Of Tuple(Of Integer, Integer), Boolean) In estadoDiccionario
            Dim clave As Tuple(Of Integer, Integer) = kvp.Key
            Dim estado As Boolean = kvp.Value

            Dim formato As String = $"{clave.Item1}+{clave.Item2}+{estado}"
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
        msj = cn.Cn_RegDetallePermisoCelular(obj)
        Console.WriteLine("IdPerfil: " & idPerfil)
        Console.WriteLine("Lista de Permisos: " & obj.Lista_Permisos)
        If obj.Coderror <> 0 Then
            msj_advert(msj)
        Else
            msj_ok(msj)
            CancelarDos()
            ListarPerfiles()
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

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        estadoDiccionario.Clear()
        currentHierarchy.Clear()
        operacion = 1
        Cambio()
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

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim isFilterActive As Boolean = Not ToolStripButton1.Checked
        ToolStripButton1.Checked = isFilterActive
        clsBasicas.Filtrar_Tabla(dtgListarPerfiles, isFilterActive)
    End Sub
End Class