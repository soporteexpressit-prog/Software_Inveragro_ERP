Imports System.Reflection
Imports System.Runtime.InteropServices
Imports CapaNegocio
Imports CapaObjetos
Imports DevComponents.DotNetBar
Imports DevComponents.DotNetBar.Controls
Imports Microsoft.VisualBasic.ApplicationServices
Imports Stimulsoft.Report

Public Class FrmMenu
    Dim gestor As New clsBasicas()
    Private Sub AbrirFomEnPanel(ByVal FormHijo As Object)
        If Me.PanelContenedor.Controls.Count > 0 Then
            Me.PanelContenedor.Controls.RemoveAt(0)
        End If
        Dim fh As Form = TryCast(FormHijo, Form)
        Dim gestor As New clsBasicas()
        fh.TopLevel = False
        fh.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        fh.Dock = DockStyle.Fill
        Me.PanelContenedor.Controls.Add(fh)
        Me.PanelContenedor.Tag = fh
        fh.Show()

    End Sub



    Dim MensajeBG As String = ""
    Dim ConError As Integer = 0
    Dim tipocierre As Boolean = False
    Dim Salir As Boolean = False
    Dim ctlMDI As MdiClient


    <DllImport("User32", CharSet:=CharSet.Auto, ExactSpelling:=True)>
    Public Shared Function SetParent(hWndChild As IntPtr, hWndParent As IntPtr) As IntPtr
    End Function
    Function buscar_presente(FPROC As Form) As Boolean
        Dim bole As Boolean = False
        For i As Integer = 0 To Application.OpenForms.Count - 1
            If Application.OpenForms.Item(i).Name = FPROC.Name AndAlso Application.OpenForms.Item(i).Text = FPROC.Text Then
                Application.OpenForms.Item(i).Focus()
                bole = True
            End If
        Next
        Return bole
    End Function

    Private _RunningAlertId As Long = 0
    'Sub CargarPermisosLogin()
    '    'Obtenemos todos los permisos del ususario
    '    Try
    '        Dim obj As New CoUsuarios
    '        Dim cn_user As New CnUsuarios

    '        If (FI_DniUsuario.Length = 0) Then
    '            obj.Dni = System.Security.Principal.WindowsIdentity.GetCurrent().Name
    '        Else
    '            obj.Dni = FI_DniUsuario
    '        End If
    '        DtTmpPermisos = cn_user.Cn_Consultar_Permisos_x_Usuario_Login(obj).Copy
    '    Catch ex As Exception
    '        basicas.controlException(Name, ex)
    '    End Try
    'End Sub

    'Private Sub Click_Alerta2(alertId As Long)
    '    ' MessageBox.Show(alertId.ToString)

    '    Dim documento_iden As New v1_FrmControlDocumentos
    '    Dim bole As Boolean = False
    '    bole = buscar_presente(documento_iden)
    '    If bole = False Then
    '        Dim documento_identidad As v1_FrmControlDocumentos = documento_iden
    '        documento_identidad.MdiParent = Me
    '        'documento_identidad.WindowState = FormWindowState.Maximized
    '        documento_identidad.Show()
    '        documento_identidad = Nothing
    '    End If

    'End Sub

    Public Sub GestiondeAlertas()
        Try
            Dim numproductos As Integer = 0 ' Inicializamos a 0
            Dim numctas As Integer = 0 ' Inicializamos a 0
            Dim numordenes As Integer = 0 ' Inicializamos a 0
            Dim numpedidos As Integer = 0 ' Inicializamos a 0
            Dim obj As New coProductos
            Dim cn As New cnProducto
            obj.IdUbicacion = 1
            Dim ds As New DataSet
            ds = cn.Cn_ListarAlertas(obj).Copy
            ds.DataSetName = "tmp"

            ' Recorremos el DataTable para contar los productos en alerta
            For Each row As DataRow In ds.Tables(0).Rows
                numproductos = Convert.ToInt32(row("numproductos"))
            Next

            For Each row As DataRow In ds.Tables(1).Rows
                numctas = Convert.ToInt32(row("numctas"))
            Next

            For Each row As DataRow In ds.Tables(2).Rows
                numordenes = Convert.ToInt32(row("num_ordenes"))
            Next
            For Each row As DataRow In ds.Tables(3).Rows
                numpedidos = Convert.ToInt32(row("num_pedidos"))
            Next

            ' Solo mostrar la alerta si hay productos en alerta
            If numproductos > 0 Then
                ' Generamos el mensaje con la cantidad de productos en alerta
                Dim mensajeAlerta As String = $"Existen {numproductos} producto(s) en alerta de stock mínimo."
                ' Configuración de la alerta
                Dim colores As eDesktopAlertColor = eDesktopAlertColor.Red
                Dim position As eAlertPosition = eAlertPosition.BottomRight
                ' Mostramos la alerta con el mensaje formateado
                DesktopAlert.Show(mensajeAlerta, "", eSymbolSet.Awesome, Color.Empty, colores, position, 6, _RunningAlertId, AddressOf Click_Alerta)
            End If

            If numctas > 0 Then
                ' Generamos el mensaje con la cantidad de productos en alerta
                Dim mensajeAlerta As String = $"Existen {numctas} Cuentas por Pagar por Vencer"
                ' Configuración de la alerta
                Dim colores As eDesktopAlertColor = eDesktopAlertColor.Red
                Dim position As eAlertPosition = eAlertPosition.BottomRight
                ' Mostramos la alerta con el mensaje formateado
                DesktopAlert.Show(mensajeAlerta, "", eSymbolSet.Awesome, Color.Empty, colores, position, 6, _RunningAlertId, AddressOf Click_Alerta2)
            End If

            If numordenes > 0 Then
                ' Generamos el mensaje con la cantidad de productos en alerta
                Dim mensajeAlerta As String = $"Existen {numordenes} Ordenes de Compra Enviadas a Facturación"
                ' Configuración de la alerta
                Dim colores As eDesktopAlertColor = eDesktopAlertColor.Red
                Dim position As eAlertPosition = eAlertPosition.BottomRight
                ' Mostramos la alerta con el mensaje formateado
                DesktopAlert.Show(mensajeAlerta, "", eSymbolSet.Awesome, Color.Empty, colores, position, 6, _RunningAlertId, AddressOf Click_Alerta3)
            End If

            If numpedidos > 0 Then
                ' Generamos el mensaje con la cantidad de productos en alerta
                Dim mensajeAlerta As String = $"Existen {numpedidos} Pedido de Venta Enviadas a Facturación"
                ' Configuración de la alerta
                Dim colores As eDesktopAlertColor = eDesktopAlertColor.Red
                Dim position As eAlertPosition = eAlertPosition.BottomRight
                ' Mostramos la alerta con el mensaje formateado
                DesktopAlert.Show(mensajeAlerta, "", eSymbolSet.Awesome, Color.Empty, colores, position, 6, _RunningAlertId, AddressOf Click_Alerta4)
            End If
        Catch ex As Exception
            ' Manejo de excepciones mejorado
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    'Public Sub Mensaje2()
    '    Dim colores As eDesktopAlertColor = eDesktopAlertColor.Red
    '    Dim position As eAlertPosition = eAlertPosition.BottomRight
    '    DesktopAlert.Show("EXISTEN PRODUCTOS SIN ROTACIÓN", "", eSymbolSet.Awesome, Color.Empty, colores, position, 6, _RunningAlertId, AddressOf Click_Alerta2)
    'End Sub
    'Public Sub Mensaje3()
    '    Dim colores As eDesktopAlertColor = eDesktopAlertColor.Red
    '    Dim position As eAlertPosition = eAlertPosition.BottomRight
    '    DesktopAlert.Show("EXISTEN VENTAS SIN DESPACHAR", "", eSymbolSet.Awesome, Color.Empty, colores, position, 6, _RunningAlertId, AddressOf Click_Alerta3)
    'End Sub
    Private Sub Click_Alerta(ByVal alertId As Long)
        Dim documento_iden As New FrmMant_Producto
        Dim bole As Boolean = False
        bole = buscar_presente(documento_iden)
        If bole = False Then
            Dim documento_identidad As FrmMant_Producto = documento_iden
            documento_identidad.MdiParent = Me
            'documento_identidad.WindowState = FormWindowState.Maximized
            documento_identidad.Show()
            documento_identidad = Nothing
        End If
    End Sub

    Private Sub Click_Alerta2(ByVal alertId As Long)
        Dim documento_iden As New FrmCuentasPagar
        Dim bole As Boolean = False
        bole = buscar_presente(documento_iden)
        If bole = False Then
            Dim documento_identidad As FrmCuentasPagar = documento_iden
            documento_identidad.MdiParent = Me
            'documento_identidad.WindowState = FormWindowState.Maximized
            documento_identidad.Show()
            documento_identidad = Nothing
        End If
    End Sub
    Private Sub Click_Alerta3(ByVal alertId As Long)
        Dim documento_iden As New FrmBuscarOrdenesCompraPendientesFacturacion
        Dim bole As Boolean = False
        bole = buscar_presente(documento_iden)
        If bole = False Then
            Dim documento_identidad As FrmBuscarOrdenesCompraPendientesFacturacion = documento_iden
            documento_identidad.MdiParent = Me
            'documento_identidad.WindowState = FormWindowState.Maximized
            documento_identidad.Show()
            documento_identidad = Nothing
        End If
    End Sub
    Private Sub Click_Alerta4(ByVal alertId As Long)
        Dim documento_iden As New FrmBuscarPedidosVentasPendientesFacturacion
        Dim bole As Boolean = False
        bole = buscar_presente(documento_iden)
        If bole = False Then
            Dim documento_identidad As FrmBuscarPedidosVentasPendientesFacturacion = documento_iden
            documento_identidad.MdiParent = Me
            'documento_identidad.WindowState = FormWindowState.Maximized
            documento_identidad.Show()
            documento_identidad = Nothing
        End If
    End Sub

    ' Método recursivo para asignar eventos Click a los secundarios y sus anidados
    Private Sub AsignarEventoClicAMenuItems(menuItem As ToolStripMenuItem)
        For Each subItem As ToolStripMenuItem In menuItem.DropDownItems
            ' Asigna el evento Click al subItem
            AddHandler subItem.Click, AddressOf ToolStripMenuItem_Click

            ' Si este subItem tiene más elementos, llama recursivamente
            If subItem.HasDropDownItems Then
                AsignarEventoClicAMenuItems(subItem)
            End If
        Next
    End Sub

    Private Sub ToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim clickedItem As ToolStripMenuItem = CType(sender, ToolStripMenuItem)

        ' Busca el principal activo
        Dim mainItem As ToolStripMenuItem = clickedItem
        While TypeOf mainItem.OwnerItem Is ToolStripMenuItem
            mainItem = CType(mainItem.OwnerItem, ToolStripMenuItem)
        End While

        ' Establece el principal activo
        CType(MenuStrip1.Renderer, CustomRenderer).SetActiveMainItem(mainItem)

        ' Refresca el menú para aplicar cambios visuales
        MenuStrip1.Refresh()
    End Sub
    Private Sub FrmMenuPrincipalv4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'lblusuario.Text = GlobalReferences.nombreuser

        Me.Text = "INVERAGRO :::: " + "  " + " " + "USUARIO :" + " " + GlobalReferences.nombreuser
        GestiondeAlertas()

        MenuStrip1.Renderer = New CustomRenderer()

        ' Asigna los eventos Click a los ítems principales y sus secundarios recursivamente
        For Each mainItem As ToolStripMenuItem In MenuStrip1.Items
            AsignarEventoClicAMenuItems(mainItem)
        Next
        'lblversion.Text = VP_VersionSistema


        ' Configuración inicial del formulario
        IsMdiContainer = True

        ' Carga de permisos y menú
        'Try
        '    CargarPermisosLogin()
        '    Cargar_Menu()
        'Catch ex As Exception
        '    basicas.controlException(Name, ex)
        '    MsgBox(ex.Message)
        '    Return
        'End Try

        ' Configuración adicional del formulario
        For Each ctl As Control In Me.Controls
            If TypeOf ctl Is MdiClient Then
                'ctl.BackColor = Color.White

            End If
        Next
    End Sub

    Dim msm As String = ""
    Private Function dynamicallyLoadedObject(objectname As String) As Form
        'Creamos virtualmente la estructura de nuestro Formulario'
        Dim returnobject As New Object
        Dim asm As Assembly = Nothing
        Try
            asm = Assembly.GetExecutingAssembly()
            For Each item As Type In asm.GetTypes
                If item.Name.Trim.Equals(objectname) Then
                    objectname = item.Namespace & "." & objectname
                    Exit For
                End If
            Next
            returnobject = DirectCast(asm.CreateInstance(objectname), Object)

        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
        Return returnobject
    End Function
    'Sub AbrirFormulario(nombre As String)
    '    ''Indicamos que nombre tiene el formulario que queremos abri
    '    'Try
    '    '    Dim oformulario As New Form()
    '    '    oformulario = dynamicallyLoadedObject(nombre)
    '    '    Dim bole As Boolean = False
    '    '    bole = buscar_presente(oformulario)
    '    '    If bole = False Then
    '    '        Dim oformulario2 As New Form() '
    '    '        oformulario2 = dynamicallyLoadedObject(nombre)
    '    '        oformulario2 = oformulario
    '    '        oformulario2.MdiParent = Me
    '    '        'oformulario2.WindowState = FormWindowState.Maximized
    '    '        oformulario2.Show()
    '    '        oformulario2 = Nothing
    '    '    End If
    '    'Catch ex As Exception
    '    '    clsBasicas.controlException(Name, ex)
    '    'End Try

    '    ' Limpiamos el PanelContenedor si ya tiene controles
    '    If Me.PanelContenedor.Controls.Count > 0 Then
    '        Me.PanelContenedor.Controls.RemoveAt(0)
    '    End If
    '    ' Convertimos el objeto a un formulario
    '    Dim oformulario As New Form()
    '    oformulario = dynamicallyLoadedObject(nombre)
    '    Dim fh As Form = TryCast(oformulario, Form)
    '    fh.TopLevel = False ' Esto asegura que el formulario hijo no se comporte como una ventana independiente
    '    fh.FormBorderStyle = FormBorderStyle.None ' Quitamos el borde para que no parezca una ventana separada
    '    fh.Dock = DockStyle.Fill ' Acoplamos el formulario para que llene el panel
    '    ' Añadimos el formulario al panel
    '    Me.PanelContenedor.Controls.Add(fh)
    '    Me.PanelContenedor.Tag = fh
    '    ' Mostramos el formulario
    '    fh.Show()
    'End Sub
    Private Sub AbrirFormulario(nombre As String)
        ' Limpiamos el Panel4 si ya tiene controles
        If Me.Panel4.Controls.Count > 0 Then
            Me.Panel4.Controls.Clear()
        End If

        ' Creamos una instancia del formulario dinámicamente
        Dim oFormulario As Form = dynamicallyLoadedObject(nombre)

        ' Verificamos si se creó correctamente el formulario
        If oFormulario Is Nothing Then
            msj_advert("El formulario especificado no existe.")
            Exit Sub
        End If

        ' Configuramos el formulario para que se adapte al panel
        oFormulario.TopLevel = False
        oFormulario.FormBorderStyle = FormBorderStyle.None
        oFormulario.Dock = DockStyle.Fill


        'las dos lineas de abajo es para el login no borrar (PERMISOS SUB MODULOS Y BOTONES)
        ' Ahora llamamos a ConfigurarPermisosBotones usando 'fh'
        Dim idPersonaValido As Integer = GlobalReferences.ActiveSessionId
        ' Llama a ConfigurarPermisosBotones pasando el formulario actual
        ConfigurarPermisosBotones(oFormulario, idPersonaValido)

        ' Añadimos el formulario al Panel4 y lo mostramos
        Me.Panel4.Controls.Add(oFormulario)
        Me.Panel4.Tag = oFormulario

        ' Intentamos mostrar el formulario
        Try
            oFormulario.Show()
        Catch ex As ObjectDisposedException
            msj_advert("No se puede acceder al formulario ya cerrado.")
        End Try
    End Sub


    Private Sub btnProductos_Click(sender As Object, e As EventArgs) Handles btnProductos.Click
        AbrirFormulario("FrmMant_Producto")
    End Sub

    Private Sub btnOtrosIngresosAlmacen_Click(sender As Object, e As EventArgs) Handles toolOtrosIngresosAlmacen.Click
        AbrirFormulario("FrmControlIngresosInventario")
    End Sub

    Private Sub btnOtrasSalidasAlmacen_Click(sender As Object, e As EventArgs) Handles toolOtrasSalidasAlmacen.Click
        AbrirFormulario("FrmControlSalidasInventario")
    End Sub

    Private Sub btnProveedores_Click(sender As Object, e As EventArgs) Handles toolProveedores.Click
        AbrirFormulario("FrmMant_Proveedor")
    End Sub

    Private Sub btnOrdenesCompras_Click(sender As Object, e As EventArgs) Handles toolOrdenesCompras.Click
        AbrirFormulario("FrmControlIngresosOrdenesdeCompras")
    End Sub

    Private Sub btnTiposDocumentos_Click(sender As Object, e As EventArgs) Handles btnTiposDocumentos.Click
        AbrirFormulario("FrmTipoDocumento")
    End Sub

    Private Sub btnBancos_Click(sender As Object, e As EventArgs) Handles btnBancos.Click
        AbrirFormulario("FrmBanco")
    End Sub

    Private Sub btnMonedas_Click(sender As Object, e As EventArgs) Handles btnMonedas.Click
        AbrirFormulario("FrmMoneda")
    End Sub

    Private Sub btnCuentaBancos_Click(sender As Object, e As EventArgs) Handles btnCuentaBancos.Click
        AbrirFormulario("FrmCuentaBanco")
    End Sub

    Private Sub btnPlanCuentas_Click(sender As Object, e As EventArgs) Handles btnPlanCuentas.Click
        AbrirFormulario("FrmPlanCuenta")
    End Sub

    Private Sub btnGirosEmpresa_Click(sender As Object, e As EventArgs) Handles btnGirosEmpresa.Click
        AbrirFormulario("FrmGiroEmpresa")
    End Sub

    Private Sub btnUbicaciones_Click(sender As Object, e As EventArgs) Handles btnUbicaciones.Click
        AbrirFormulario("FrmUbicacion")
    End Sub

    Private Sub btnMotivosTransacciones_Click(sender As Object, e As EventArgs) Handles btnMotivosTransacciones.Click
        AbrirFormulario("FrmMotivoTransaccion")
    End Sub

    Private Sub btnCuentasPagar_Click(sender As Object, e As EventArgs) Handles toolCuentasPagar.Click
        AbrirFormulario("FrmCuentasPagar")
    End Sub

    Private Sub btnCuentasxCobrar_Click(sender As Object, e As EventArgs) Handles toolCuentasxCobrar.Click
        AbrirFormulario("FrmCuentasCobrar")
    End Sub

    Private Sub btnGestionCompras_Click(sender As Object, e As EventArgs) Handles toolGestionCompras.Click
        AbrirFormulario("FrmControlCompras")
    End Sub

    Private Sub btnGestionVentas_Click(sender As Object, e As EventArgs) Handles toolGestionVentas.Click
        AbrirFormulario("FrmControlVentas")
    End Sub

    Private Sub btnRecepcionProductos_Click(sender As Object, e As EventArgs) Handles toolRecepcionProductos.Click
        AbrirFormulario("FrmProductoRecepcionado")
    End Sub

    Private Sub btnCategoriaActivo_Click(sender As Object, e As EventArgs) Handles btnCategoriaActivo.Click
        AbrirFormulario("FrmCategoriaActivo")
    End Sub

    Private Sub btnTipoActivo_Click(sender As Object, e As EventArgs) Handles btnTipoActivo.Click
        AbrirFormulario("FrmTipoActivo")
    End Sub

    Private Sub btnMarcasActivos_Click(sender As Object, e As EventArgs) Handles btnMarcasActivos.Click
        AbrirFormulario("FrmMarcaActivo")
    End Sub

    Private Sub btnControlActivos_Click(sender As Object, e As EventArgs) Handles btnControlActivos.Click
        AbrirFormulario("FrmControlActivo")
    End Sub

    Private Sub btnTiposSeguro_Click(sender As Object, e As EventArgs) Handles btnTiposSeguro.Click
        AbrirFormulario("FrmTipoSeguro")
    End Sub

    Private Sub btnProveedoresSeguros_Click(sender As Object, e As EventArgs) Handles btnProveedoresSeguros.Click
        AbrirFormulario("FrmProveedorSeguro")
    End Sub

    Private Sub btnSeguroActivos_Click(sender As Object, e As EventArgs) Handles btnSeguroActivos.Click
        AbrirFormulario("FrmControlSeguroActivo")
    End Sub

    Private Sub btnAperturarCaja_Click(sender As Object, e As EventArgs) Handles btnAperturarCaja.Click
        AbrirFormulario("FrmAperturaCaja")
    End Sub

    Private Sub btnCerrarCaja_Click(sender As Object, e As EventArgs) Handles btnCerrarCaja.Click
        AbrirFormulario("FrmCerrarCaja")
    End Sub

    Private Sub btnResumenesCaja_Click(sender As Object, e As EventArgs) Handles btnResumenesCaja.Click
        AbrirFormulario("FrmResumenCaja")
    End Sub

    Private Sub btnMovimientosCaja_Click(sender As Object, e As EventArgs) Handles btnMovimientosCaja.Click
        AbrirFormulario("FrmControlCaja")
    End Sub

    Private Sub btnControlBonificacionSNN_Click(sender As Object, e As EventArgs) Handles toolControlBonificacionSNN.Click
        AbrirFormulario("FrmControlBonificacionNN")
    End Sub

    Private Sub btnControlFormulas_Click(sender As Object, e As EventArgs) Handles toolControlFormulas.Click
        AbrirFormulario("FrmControlFormula")
    End Sub

    Private Sub btnTrabajadores_Click(sender As Object, e As EventArgs) Handles btnTrabajadores.Click
        AbrirFormulario("FrmMant_Trabajador")
    End Sub

    Private Sub btnMotivosMemorandum_Click(sender As Object, e As EventArgs) Handles btnMotivosMemorandum.Click
        AbrirFormulario("FrmMotivoMemoDespido")
    End Sub

    Private Sub btnMemorandum_Click(sender As Object, e As EventArgs) Handles btnMemorandum.Click
        AbrirFormulario("FrmControlMemoDespido")
    End Sub

    Private Sub btnControlSeguroTrabajadores_Click(sender As Object, e As EventArgs) Handles btnControlSeguroTrabajadores.Click
        AbrirFormulario("FrmControlSCTR")
    End Sub

    Private Sub btnEnfermedades_Click(sender As Object, e As EventArgs) Handles btnEnfermedades.Click
        AbrirFormulario("FrmEnfermedad")
    End Sub

    Private Sub btnControlClientes_Click(sender As Object, e As EventArgs) Handles btnControlClientes.Click
        AbrirFormulario("FrmControlClientes")
    End Sub

    Private Sub btnControlTipoMotivoEntrega_Click(sender As Object, e As EventArgs) Handles btnControlTipoMotivoEntrega.Click
        AbrirFormulario("FrmTipoMotivoEpp")
    End Sub

    Private Sub btnControlEPP_Click(sender As Object, e As EventArgs) Handles btnControlEPP.Click
        AbrirFormulario("FrmControlEpp")
    End Sub

    Private Sub btnMotivosMemorandum2_Click(sender As Object, e As EventArgs) Handles btnMotivosMemorandum2.Click
        AbrirFormulario("FrmMotivoMemoDespido")
    End Sub

    Private Sub btnMemorandum2_Click(sender As Object, e As EventArgs) Handles btnMemorandum2.Click
        AbrirFormulario("FrmControlMemoDespido")
    End Sub

    Private Sub btnAreaCapacitadora2_Click(sender As Object, e As EventArgs) Handles btnAreaCapacitadora2.Click
        AbrirFormulario("FrmAreaCapacitadora")
    End Sub

    Private Sub btnTemaCapacitacion2_Click(sender As Object, e As EventArgs) Handles btnTemaCapacitacion2.Click
        AbrirFormulario("FrmTemaCapacitacion")
    End Sub

    Private Sub btnTipoCapacitacion2_Click(sender As Object, e As EventArgs) Handles btnTipoCapacitacion2.Click
        AbrirFormulario("FrmTipoCapacitacion")
    End Sub

    Private Sub btnCapacitaciones2_Click(sender As Object, e As EventArgs) Handles btnCapacitaciones2.Click
        AbrirFormulario("FrmControlCapacitacion")
    End Sub

    Private Sub CONTROLDEPREMIXEROSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles toolControlPremixeros.Click
        AbrirFormulario("FrmControlPremixero")
    End Sub

    Private Sub MANTENIMIENTODEFORMATOSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MANTENIMIENTODEFORMATOSToolStripMenuItem.Click
        AbrirFormulario("FrmFormatosRRHH")
    End Sub

    Private Sub CONTROLDEASISTENCIAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CONTROLDEASISTENCIAToolStripMenuItem.Click
        AbrirFormulario("FrmAsistencia")
    End Sub


    Private Sub CONTROLDEINCIDENCIASYACCIDENTESToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnIncidentesyaccidentes.Click
        AbrirFormulario("FrmControlIncidenteAccidente")
    End Sub

    Private Sub PEDIDOSPENDIENTESToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PEDIDOSPENDIENTESToolStripMenuItem.Click
        AbrirFormulario("FrmControlPedidosRequerimientos")
    End Sub

    Private Sub ATENCIONDEPEDIDOSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ATENCIONDEPEDIDOSToolStripMenuItem.Click
        AbrirFormulario("FrmControlAtencionesPedidosRequerimientos")
    End Sub

    Private Sub PEDIDOSPARAORDENESDECOMPRAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles toolPedidosparaOrdenesCompra.Click
        AbrirFormulario("FrmControlPedidoSinStock")
    End Sub

    Private Sub CONTROLDEPEDIDODEALIMENTOSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles toolControlPedidoAlimentos.Click
        AbrirFormulario("FrmControlPedidoAlimento")
    End Sub

    Private Sub CATEGORIASToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CATEGORIASToolStripMenuItem.Click
        AbrirFormulario("FrmCategoriaProducto")
    End Sub

    Private Sub MARCASToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UNIDADDEMEDIDAToolStripMenuItem.Click
        AbrirFormulario("FrmMarca")
    End Sub

    Private Sub UNIDADDEMEDIDAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnunidadesmedida.Click
        AbrirFormulario("FrmUnidadMedida")
    End Sub

    Private Sub CONTROLDEALIMENTOSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles toolControlAlimentos.Click
        AbrirFormulario("FrmControlAlimento")
    End Sub

    Private Sub CONTROLDERACIONESToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles toolControlRacionesyAnti.Click
        AbrirFormulario("FrmControlRacion")
    End Sub

    Private Sub btnParametrosAlertas_Click(sender As Object, e As EventArgs) Handles btnParametrosAlertas.Click
        AbrirFormulario("FrmParametrizaciónAlertas")
    End Sub

    Private Sub btnGestionUsuarios_Click(sender As Object, e As EventArgs) Handles btnGestionUsuarios.Click
        AbrirFormulario("FrmAdministracionUsuarios")
    End Sub

    Private Sub btnPerfiles_Click(sender As Object, e As EventArgs) Handles btnPerfiles.Click
        AbrirFormulario("FrmPerfiles")
    End Sub

    Private Sub btnUsuarios_Click(sender As Object, e As EventArgs) Handles btnUsuarios.Click
        AbrirFormulario("FrmUsuarios")
    End Sub
    Dim formularios As New List(Of Type) From {
GetType(FrmMant_ProductoUbicaciones),
GetType(FrmControlAlimento),
GetType(FrmTemaCapacitacion),
GetType(FrmControlIncidenteAccidente),
GetType(FrmControlClientes),
GetType(FrmMant_Proveedor),
GetType(FrmMant_Producto),
GetType(FrmControlIngresosInventario),
GetType(FrmControlSalidasInventario),
GetType(FrmControlCombustible),
GetType(FrmControlIngresosOrdenesdeCompras),
GetType(FrmConsolidadoPedidoAlimento),
GetType(FrmTipoDocumento),
GetType(FrmBanco),
GetType(FrmMoneda),
GetType(FrmCuentaBanco),
GetType(FrmPlanCuenta),
GetType(FrmGiroEmpresa),
GetType(FrmUbicacion),
GetType(FrmMotivoTransaccion),
GetType(FrmCuentasPagar),
GetType(FrmCuentasCobrar),
GetType(FrmControlCompras),
GetType(FrmPreparacionRacion),
GetType(FrmControlVentas),
GetType(FrmProductoRecepcionado),
GetType(FrmCategoriaActivo),
GetType(FrmTipoActivo),
GetType(FrmMarcaActivo),
GetType(FrmControlActivo),
GetType(FrmTipoSeguro),
GetType(FrmProveedorSeguro),
GetType(FrmControlSeguroActivo),
GetType(FrmAperturaCaja),
GetType(FrmCerrarCaja),
GetType(FrmResumenCaja),
GetType(FrmControlCaja),
GetType(FrmControlBonificacionNN),
GetType(FrmControlFormula),
GetType(FrmControlRacion),
GetType(FrmControlPeriodoMedicacionRacion),
GetType(FrmGalpon),
GetType(FrmTipoIncidencia),
GetType(FrmMant_Trabajador),
GetType(FrmMotivoMemoDespido),
GetType(FrmControlMemoDespido),
GetType(FrmAreaCapacitadora),
GetType(FrmTipoCurso),
GetType(FrmTemaCapacitacion),
GetType(FrmTemarioCapacitacion),
GetType(FrmTipoCapacitacion),
GetType(FrmControlCapacitacion),
GetType(FrmControlSCTR),
GetType(FrmEnfermedad),
GetType(FrmControlPedidosVentas),
GetType(FrmTipoMotivoEpp),
GetType(FrmControlEpp),
GetType(FrmControlPremixero),
GetType(FrmFormatosRRHH),
GetType(FrmControlPedidosRequerimientos),
GetType(FrmControlAtencionesPedidosRequerimientos),
GetType(FrmControlPedidoSinStock),
GetType(FrmControlPedidoAlimento),
GetType(FrmSimulacionFormula),
GetType(FrmCategoriaProducto),
GetType(FrmParametrizaciónAlertas),
GetType(FrmAdministracionUsuarios),
GetType(FrmPerfiles),
GetType(FrmUsuarios),
GetType(FrmControlExcedente),
GetType(FrmControlDespacho),
GetType(FrmControlRecepcionRacion),
GetType(FrmMarca),
    GetType(FrmTemarioCapacitacion),
GetType(FrmTipoCapacitacion),
GetType(FrmControlCapacitacion),
GetType(FrmMotivoMemoDespido),
GetType(FrmControlMemoDespido),
GetType(FrmAreaCapacitadora),
GetType(FrmTipoCurso),
GetType(FrmAsistencia),
GetType(FrmControlTransportesIF),
GetType(FrmSala),
GetType(FrmControlCorral),
GetType(FrmControlJaula),
GetType(FrmControlVerraco),
GetType(FrmControlRaza),
GetType(FrmControlRelacionPesoEdad),
GetType(FrmPrinIngresosyDescuentos),
GetType(FrmControlCerda),
GetType(FrmControlInseminacion),
GetType(FrmPedidoGeneticoPorcino),
GetType(FrmControlMaterialGenetico),
GetType(FrmControlGestacion),
GetType(FrmControlMaternidadDestete),
GetType(FrmControlMedicacion),
GetType(FrmHistoricoMortalidad),
GetType(FrmControlEnvioCamal),
GetType(FrmControlMadreFutura),
GetType(FrmMantenimientoParametroProduccion),
GetType(FrmControlBajada),
GetType(FrmControlLotes),
GetType(FrmControlInventario),
GetType(FrmGuiaTratamientos),
GetType(FrmControlEmbarcadero),
GetType(FrmControlCampana),
GetType(FrmAdministrarUsuariosCelular),
GetType(FrmAdministrarUsuariosCelular),
GetType(FrmPresentacionProducto),
GetType(FrmConductores),
GetType(Frmcondiciondepago),
GetType(FrmCargo),
GetType(FrmCroquis),
GetType(FrmControlPedidosVentasCerdos),
GetType(FrmControlTransferencias),
GetType(FrmControlAlimentoCerda),
GetType(FrmControlGuiasTraslado),
GetType(FrmDespachosCerdosVenta),
GetType(FrmRegularizacionCerdo),
GetType(FrmControlPedidosVentaProductos),
GetType(FrmControlTranportes),
GetType(FrmUnidadMedida)}
    Private Sub SIMULACIÓNDEFORMULAToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SIMULACIÓNDEFORMULAToolStripMenuItem1.Click
        AbrirFormulario("FrmSimulacionFormula")
    End Sub

    Private Sub btnPreparacionAlimento_Click(sender As Object, e As EventArgs) Handles btnPreparacionAlimento.Click
        AbrirFormulario("FrmPreparacionRacion")
    End Sub

    Dim listaFormularios As New List(Of Type) From {
GetType(FrmTemaCapacitacion),
GetType(FrmMant_ProductoUbicaciones),
GetType(FrmControlAlimento),
GetType(FrmMant_Proveedor),
GetType(FrmMant_Producto),
GetType(FrmControlIngresosInventario),
GetType(FrmControlAlimentoCerda),
GetType(FrmControlSalidasInventario),
GetType(FrmControlCombustible),
GetType(FrmControlIngresosOrdenesdeCompras),
GetType(FrmTipoDocumento),
GetType(FrmConsolidadoPedidoAlimento),
GetType(FrmBanco),
GetType(FrmMoneda),
GetType(FrmCuentaBanco),
GetType(FrmPlanCuenta),
GetType(FrmGiroEmpresa),
GetType(FrmUbicacion),
GetType(FrmMotivoTransaccion),
GetType(FrmCuentasPagar),
GetType(FrmCuentasCobrar),
GetType(FrmControlCompras),
GetType(FrmPreparacionRacion),
GetType(FrmControlVentas),
GetType(FrmProductoRecepcionado),
GetType(FrmCategoriaActivo),
GetType(FrmTipoActivo),
GetType(FrmMarcaActivo),
GetType(FrmControlActivo),
GetType(FrmTipoSeguro),
GetType(FrmProveedorSeguro),
GetType(FrmControlSeguroActivo),
GetType(FrmAperturaCaja),
GetType(FrmCerrarCaja),
GetType(FrmResumenCaja),
GetType(FrmControlCaja),
GetType(FrmControlBonificacionNN),
GetType(FrmControlFormula),
GetType(FrmControlRacion),
GetType(FrmGalpon),
GetType(FrmControlPeriodoMedicacionRacion),
GetType(FrmTipoIncidencia),
GetType(FrmMant_Trabajador),
GetType(FrmMotivoMemoDespido),
GetType(FrmControlMemoDespido),
GetType(FrmAreaCapacitadora),
GetType(FrmTipoCurso),
GetType(FrmTemaCapacitacion),
GetType(FrmTemarioCapacitacion),
GetType(FrmTipoCapacitacion),
GetType(FrmControlCapacitacion),
GetType(FrmControlSCTR),
GetType(FrmEnfermedad),
GetType(FrmControlClientes),
GetType(FrmControlPedidosVentas),
GetType(FrmTipoMotivoEpp),
GetType(FrmControlEpp),
GetType(FrmControlPremixero),
GetType(FrmFormatosRRHH),
GetType(FrmControlIncidenteAccidente),
GetType(FrmControlPedidosRequerimientos),
GetType(FrmControlAtencionesPedidosRequerimientos),
GetType(FrmControlPedidoSinStock),
GetType(FrmControlPedidoAlimento),
GetType(FrmSimulacionFormula),
GetType(FrmCategoriaProducto),
GetType(FrmMarca),
GetType(FrmParametrizaciónAlertas),
GetType(FrmAdministracionUsuarios),
GetType(FrmPerfiles),
GetType(FrmUsuarios),
    GetType(FrmTemarioCapacitacion),
GetType(FrmTipoCapacitacion),
GetType(FrmControlCapacitacion),
GetType(FrmMotivoMemoDespido),
GetType(FrmControlMemoDespido),
GetType(FrmAreaCapacitadora),
GetType(FrmTipoCurso),
GetType(FrmAsistencia),
GetType(FrmControlTransportesIF),
GetType(FrmSala),
GetType(FrmControlCorral),
GetType(FrmControlJaula),
GetType(FrmControlVerraco),
GetType(FrmControlRaza),
GetType(FrmControlRelacionPesoEdad),
GetType(FrmPrinIngresosyDescuentos),
GetType(FrmControlCerda),
GetType(FrmControlInseminacion),
GetType(FrmPedidoGeneticoPorcino),
GetType(FrmControlMaterialGenetico),
GetType(FrmControlGestacion),
GetType(FrmControlMaternidadDestete),
GetType(FrmControlMedicacion),
GetType(FrmHistoricoMortalidad),
GetType(FrmControlEnvioCamal),
GetType(FrmControlMadreFutura),
GetType(FrmMantenimientoParametroProduccion),
GetType(FrmControlBajada),
GetType(FrmControlLotes),
GetType(FrmControlInventario),
GetType(FrmGuiaTratamientos),
GetType(FrmControlEmbarcadero),
GetType(FrmControlCampana),
GetType(FrmCroquis),
GetType(FrmControlPedidosVentasCerdos),
GetType(FrmControlTransferencias),
GetType(FrmControlGuiasTraslado),
GetType(FrmDespachosCerdosVenta),
GetType(FrmRegularizacionCerdo),
GetType(FrmControlPedidosVentaProductos),
GetType(FrmControlTranportes),
GetType(FrmControlExcedente),
GetType(FrmAdministrarUsuariosCelular),
GetType(FrmAdministrarUsuariosCelular),
GetType(FrmPresentacionProducto),
GetType(FrmConductores),
GetType(Frmcondiciondepago),
GetType(FrmCargo),
GetType(FrmControlDespacho),
GetType(FrmControlRecepcionRacion),
GetType(FrmUnidadMedida)}

    Dim formcapa As New FrmTemaCapacitacion()
    Dim frmControlIncidenteAccidente As New FrmControlIncidenteAccidente()
    Dim formpro As New FrmMant_Proveedor()
    Dim loginNegocio As New cnLogin()


    Private Sub ConfigurarPermisosBotones(form As Form, idPersona As Integer)
        Try
            Dim botones As List(Of (NombreBoton As String, Estado As Boolean)) = loginNegocio.ObtenerBotonesPorUsuario(idPersona)

            ' Verificar si hay botones una sola vez
            If botones Is Nothing OrElse botones.Count = 0 Then
                msj_advert("El usuario no tiene botones activados")
                Return
            End If

            Dim toolStrip As ToolStrip = ObtenerToolStrip(form)
            If toolStrip Is Nothing Then
                msj_advert("No se encontró ToolStrip en el formulario " & form.Name)
                Return
            End If

            For Each boton In botones
                ' Intentar configurar como ToolStripButton
                Dim buttonControl As ToolStripButton = BuscarBotonPorNombreRecursivo(toolStrip, boton.NombreBoton)
                If buttonControl IsNot Nothing Then
                    buttonControl.Visible = boton.Estado
                    Continue For
                End If

                ' Intentar configurar como ToolStripDropDownButton
                Dim dropDownControl As ToolStripDropDownButton = BuscarDropDownPorNombreRecursivo(toolStrip, boton.NombreBoton)
                If dropDownControl IsNot Nothing Then
                    dropDownControl.Visible = boton.Estado
                    Continue For
                End If

                ' Intentar configurar como ToolStripSplitButton
                Dim splitButtonControl As ToolStripSplitButton = BuscarSplitButtonPorNombreRecursivo(toolStrip, boton.NombreBoton)
                If splitButtonControl IsNot Nothing Then
                    splitButtonControl.Visible = boton.Estado
                    Continue For
                End If

                ' Si llegamos aquí, el botón no se encontró - descomenta para diagnosticar
                ' MessageBox.Show($"No se encontró el botón o menú {boton.NombreBoton} en el formulario {form.Name}", "Error")
            Next
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    ' Método mejorado para buscar cualquier ToolStrip en el formulario
    Private Function ObtenerToolStrip(form As Form) As ToolStrip
        ' Primero intentar buscar específicamente ToolStrip1 como antes
        For Each tipo In listaFormularios
            If tipo.IsInstanceOfType(form) Then
                Dim propInfo = tipo.GetProperty("ToolStrip1", BindingFlags.Instance Or BindingFlags.Public Or BindingFlags.NonPublic)
                If propInfo IsNot Nothing Then
                    Dim toolStrip = TryCast(propInfo.GetValue(form), ToolStrip)
                    If toolStrip IsNot Nothing Then Return toolStrip
                End If
            End If
        Next

        ' Si no se encuentra, buscar cualquier control ToolStrip en el formulario
        For Each control As Control In form.Controls
            If TypeOf control Is ToolStrip Then
                Return DirectCast(control, ToolStrip)
            End If
        Next

        ' Buscar ToolStrips en contenedores anidados
        Return BuscarToolStripEnControles(form.Controls)
    End Function

    ' Método para buscar ToolStrip en controles anidados
    Private Function BuscarToolStripEnControles(controls As Control.ControlCollection) As ToolStrip
        For Each control As Control In controls
            If TypeOf control Is ToolStrip Then
                Return DirectCast(control, ToolStrip)
            End If

            ' Buscar en controles hijos
            If control.Controls.Count > 0 Then
                Dim toolStrip As ToolStrip = BuscarToolStripEnControles(control.Controls)
                If toolStrip IsNot Nothing Then Return toolStrip
            End If
        Next

        Return Nothing
    End Function

    ' Método para buscar ToolStripButton recursivamente en todo el ToolStrip
    Private Function BuscarBotonPorNombreRecursivo(toolStrip As ToolStrip, itemName As String) As ToolStripButton
        If toolStrip?.Items Is Nothing Then Return Nothing

        For Each item As ToolStripItem In toolStrip.Items
            ' Verificar si es el botón que buscamos
            Dim button As ToolStripButton = TryCast(item, ToolStripButton)
            If button IsNot Nothing AndAlso button.Name = itemName Then
                Return button
            End If

            ' Buscar en elementos desplegables
            Dim dropDownButton As ToolStripDropDownButton = TryCast(item, ToolStripDropDownButton)
            If dropDownButton?.DropDownItems IsNot Nothing Then
                For Each subItem As ToolStripItem In dropDownButton.DropDownItems
                    Dim foundButton As ToolStripButton = BuscarBotonEnItem(subItem, itemName)
                    If foundButton IsNot Nothing Then Return foundButton
                Next
            End If

            ' Buscar en SplitButton también
            Dim splitButton As ToolStripSplitButton = TryCast(item, ToolStripSplitButton)
            If splitButton?.DropDownItems IsNot Nothing Then
                For Each subItem As ToolStripItem In splitButton.DropDownItems
                    Dim foundButton As ToolStripButton = BuscarBotonEnItem(subItem, itemName)
                    If foundButton IsNot Nothing Then Return foundButton
                Next
            End If
        Next

        Return Nothing
    End Function

    ' Método auxiliar para buscar botón en un item individual
    Private Function BuscarBotonEnItem(item As ToolStripItem, itemName As String) As ToolStripButton
        ' Verificar si este item es el botón
        Dim button As ToolStripButton = TryCast(item, ToolStripButton)
        If button IsNot Nothing AndAlso button.Name = itemName Then
            Return button
        End If

        ' Buscar en submenús si es un menú desplegable
        Dim dropDownItem As ToolStripDropDownItem = TryCast(item, ToolStripDropDownItem)
        If dropDownItem?.DropDownItems IsNot Nothing Then
            For Each subItem As ToolStripItem In dropDownItem.DropDownItems
                Dim foundButton As ToolStripButton = BuscarBotonEnItem(subItem, itemName)
                If foundButton IsNot Nothing Then Return foundButton
            Next
        End If

        Return Nothing
    End Function

    ' Método para buscar ToolStripDropDownButton recursivamente
    Private Function BuscarDropDownPorNombreRecursivo(toolStrip As ToolStrip, itemName As String) As ToolStripDropDownButton
        If toolStrip?.Items Is Nothing Then Return Nothing

        For Each item As ToolStripItem In toolStrip.Items
            ' Verificar si es el dropdown que buscamos
            Dim dropDown As ToolStripDropDownButton = TryCast(item, ToolStripDropDownButton)
            If dropDown IsNot Nothing AndAlso dropDown.Name = itemName Then
                Return dropDown
            End If

            ' Buscar en elementos desplegables
            If dropDown?.DropDownItems IsNot Nothing Then
                For Each subItem As ToolStripItem In dropDown.DropDownItems
                    Dim foundDropDown As ToolStripDropDownButton = BuscarDropDownEnItem(subItem, itemName)
                    If foundDropDown IsNot Nothing Then Return foundDropDown
                Next
            End If

            ' Buscar también en SplitButton
            Dim splitButton As ToolStripSplitButton = TryCast(item, ToolStripSplitButton)
            If splitButton?.DropDownItems IsNot Nothing Then
                For Each subItem As ToolStripItem In splitButton.DropDownItems
                    Dim foundDropDown As ToolStripDropDownButton = BuscarDropDownEnItem(subItem, itemName)
                    If foundDropDown IsNot Nothing Then Return foundDropDown
                Next
            End If
        Next

        Return Nothing
    End Function

    ' Método auxiliar para buscar dropdown en un item individual
    Private Function BuscarDropDownEnItem(item As ToolStripItem, itemName As String) As ToolStripDropDownButton
        ' Verificar si este item es el dropdown
        Dim dropDown As ToolStripDropDownButton = TryCast(item, ToolStripDropDownButton)
        If dropDown IsNot Nothing AndAlso dropDown.Name = itemName Then
            Return dropDown
        End If

        ' Buscar en submenús si es un menú desplegable
        If dropDown?.DropDownItems IsNot Nothing Then
            For Each subItem As ToolStripItem In dropDown.DropDownItems
                Dim foundDropDown As ToolStripDropDownButton = BuscarDropDownEnItem(subItem, itemName)
                If foundDropDown IsNot Nothing Then Return foundDropDown
            Next
        End If

        ' También buscar en SplitButton
        Dim splitButton As ToolStripSplitButton = TryCast(item, ToolStripSplitButton)
        If splitButton?.DropDownItems IsNot Nothing Then
            For Each subItem As ToolStripItem In splitButton.DropDownItems
                Dim foundDropDown As ToolStripDropDownButton = BuscarDropDownEnItem(subItem, itemName)
                If foundDropDown IsNot Nothing Then Return foundDropDown
            Next
        End If

        Return Nothing
    End Function

    ' Método para buscar ToolStripSplitButton recursivamente
    Private Function BuscarSplitButtonPorNombreRecursivo(toolStrip As ToolStrip, itemName As String) As ToolStripSplitButton
        If toolStrip?.Items Is Nothing Then Return Nothing

        For Each item As ToolStripItem In toolStrip.Items
            ' Verificar si es el split button que buscamos
            Dim splitButton As ToolStripSplitButton = TryCast(item, ToolStripSplitButton)
            If splitButton IsNot Nothing AndAlso splitButton.Name = itemName Then
                Return splitButton
            End If

            ' Buscar en elementos desplegables de DropDownButton
            Dim dropDown As ToolStripDropDownButton = TryCast(item, ToolStripDropDownButton)
            If dropDown?.DropDownItems IsNot Nothing Then
                For Each subItem As ToolStripItem In dropDown.DropDownItems
                    Dim foundSplitButton As ToolStripSplitButton = BuscarSplitButtonEnItem(subItem, itemName)
                    If foundSplitButton IsNot Nothing Then Return foundSplitButton
                Next
            End If

            ' Buscar en elementos desplegables de SplitButton
            If splitButton?.DropDownItems IsNot Nothing Then
                For Each subItem As ToolStripItem In splitButton.DropDownItems
                    Dim foundSplitButton As ToolStripSplitButton = BuscarSplitButtonEnItem(subItem, itemName)
                    If foundSplitButton IsNot Nothing Then Return foundSplitButton
                Next
            End If
        Next

        Return Nothing
    End Function

    ' Método auxiliar para buscar split button en un item individual
    Private Function BuscarSplitButtonEnItem(item As ToolStripItem, itemName As String) As ToolStripSplitButton
        ' Verificar si este item es el split button
        Dim splitButton As ToolStripSplitButton = TryCast(item, ToolStripSplitButton)
        If splitButton IsNot Nothing AndAlso splitButton.Name = itemName Then
            Return splitButton
        End If

        ' Buscar en submenús si es un menú desplegable
        Dim dropDownItem As ToolStripDropDownItem = TryCast(item, ToolStripDropDownItem)
        If dropDownItem?.DropDownItems IsNot Nothing Then
            For Each subItem As ToolStripItem In dropDownItem.DropDownItems
                Dim foundSplitButton As ToolStripSplitButton = BuscarSplitButtonEnItem(subItem, itemName)
                If foundSplitButton IsNot Nothing Then Return foundSplitButton
            Next
        End If

        Return Nothing
    End Function

    Private Sub toolControlStockAlmacenes_Click(sender As Object, e As EventArgs) Handles toolControlStockAlmacenes.Click
        AbrirFormulario("FrmMant_ProductoUbicaciones")
    End Sub

    Private Sub CONTROLDEPERIODODERACIÓNMEDICADAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CONTROLDEPERIODODERACIÓNMEDICADAToolStripMenuItem.Click
        AbrirFormulario("FrmControlPeriodoMedicacionRacion")
    End Sub


    Private Sub CONTROLDEEXEDENTESToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CONTROLDEEXEDENTESToolStripMenuItem.Click
        AbrirFormulario("FrmControlExcedente")
    End Sub

    Private Sub CONTROLDEDESPACHOSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CONTROLDEDESPACHOSToolStripMenuItem.Click
        AbrirFormulario("FrmControlDespacho")
    End Sub

    Private Sub RECEPCIÓNDERACIÓNToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RECEPCIÓNDERACIÓNToolStripMenuItem.Click
        AbrirFormulario("FrmControlRecepcionRacion")
    End Sub

    Private Sub GALPONESToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GALPONESToolStripMenuItem.Click
        AbrirFormulario("FrmGalpon")
    End Sub

    Private Sub SALASToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SALASToolStripMenuItem1.Click
        AbrirFormulario("FrmSala")
    End Sub

    Private Sub CORRALESToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CORRALESToolStripMenuItem.Click
        AbrirFormulario("FrmControlCorral")
    End Sub

    Private Sub JAULASToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JAULASToolStripMenuItem.Click
        AbrirFormulario("FrmControlJaula")
    End Sub

    Private Sub CONTROLDEVERRACOSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CONTROLDEVERRACOSToolStripMenuItem.Click
        AbrirFormulario("FrmControlVerraco")
    End Sub

    Private Sub RELACIÓNPESOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RELACIÓNPESOToolStripMenuItem.Click
        AbrirFormulario("FrmControlRelacionPesoEdad")
    End Sub

    Private Sub ControToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ControlPagosydescuentos.Click
        AbrirFormulario("FrmPrinIngresosyDescuentos")
    End Sub

    Private Sub CONTROLDECERDASToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CONTROLDECERDASToolStripMenuItem.Click
        AbrirFormulario("FrmControlCerda")
    End Sub

    Private Sub PEDIDOSEMENPORCINOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PEDIDOSEMENPORCINOToolStripMenuItem.Click
        AbrirFormulario("FrmPedidoGeneticoPorcino")
    End Sub

    Private Sub CONTROLMATERIALGENÉTICOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CONTROLMATERIALGENÉTICOToolStripMenuItem.Click
        AbrirFormulario("FrmControlMaterialGenetico")
    End Sub

    Private Sub CONTROLDEMATERNIDADToolStripMenuItem_Click(sender As Object, e As EventArgs)
        AbrirFormulario("FrmControlMaternidadDestete")
    End Sub

    Private Sub TIPOSDEINCIDENCIASToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TIPOSDEINCIDENCIASToolStripMenuItem.Click
        AbrirFormulario("FrmTipoIncidencia")
    End Sub

    Private Sub CONTROLDEMEDICACIÓNToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CONTROLDEMEDICACIÓNToolStripMenuItem.Click
        AbrirFormulario("FrmControlMedicacion")
    End Sub

    Private Sub MORTALIDADToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MORTALIDADToolStripMenuItem.Click
        AbrirFormulario("FrmHistoricoMortalidad")
    End Sub

    Private Sub CONTROLDEENVIOCAMALToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CONTROLDEENVIOCAMALToolStripMenuItem.Click
        AbrirFormulario("FrmControlEnvioCamal")
    End Sub

    Private Sub CONTROLDEMADRESFUTURASToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CONTROLDEMADRESFUTURASToolStripMenuItem.Click
        AbrirFormulario("FrmControlMadreFutura")
    End Sub

    Private Sub PARÁMETROSREPRODUCTIVOSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PARÁMETROSREPRODUCTIVOSToolStripMenuItem.Click
        AbrirFormulario("FrmMantenimientoParametroProduccion")
    End Sub

    Private Sub CONTROLDEBAJADAToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CONTROLDEBAJADAToolStripMenuItem1.Click
        AbrirFormulario("FrmControlBajada")
    End Sub

    Private Sub CONTROLDELOTESToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CONTROLDELOTESToolStripMenuItem1.Click
        AbrirFormulario("FrmControlLotes")
    End Sub

    Private Sub CONTROLDEINVENTARIOSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CONTROLDEINVENTARIOSSUBMN2.Click
        AbrirFormulario("FrmControlInventario")
    End Sub

    Private Sub btnGuiaTratamientos_Click(sender As Object, e As EventArgs) Handles btnGuiaTratamientos.Click
        AbrirFormulario("FrmGuiaTratamientos")
    End Sub

    Private Sub CONTROLDEEMBARCADEROToolStripMenuItem_Click(sender As Object, e As EventArgs)
        AbrirFormulario("FrmControlEmbarcadero")
    End Sub

    Private Sub CONTROLDECAMPAÑASToolStripMenuItem_Click(sender As Object, e As EventArgs)
        AbrirFormulario("FrmControlCampana")
    End Sub

    Private Sub CROQUISDEPLANTELESToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CROQUISDEPLANTELESToolStripMenuItem.Click
        AbrirFormulario("FrmCroquis")
    End Sub

    Private Sub PEDIDOSDECERDOSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles btnpedidoscerdos.Click
        AbrirFormulario("FrmControlPedidosVentasCerdos")
    End Sub

    Private Sub GUIASDETRASLADOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GUIASDETRASLADOToolStripMenuItem.Click
        AbrirFormulario("FrmControlGuiasTraslado")
    End Sub

    Private Sub REGULARIZACIÓNCERDOSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles REGULARIZACIÓNCERDOSToolStripMenuItem.Click
        AbrirFormulario("FrmRegularizacionCerdo")
    End Sub

    Private Sub PEDIDOSDEVENTADEPRODUCTOSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PEDIDOSDEVENTADEPRODUCTOSToolStripMenuItem.Click
        AbrirFormulario("FrmControlPedidosVentaProductos")
    End Sub

    Private Sub CONTROLDEALIMENTOCERDAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CONTROLDEALIMENTOCERDAToolStripMenuItem.Click
        AbrirFormulario("FrmControlAlimentoCerda")
    End Sub

    Private Sub CONTROLDETRANSPORTESToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CONTROLDETRANSPORTESTSUBMN2.Click
        AbrirFormulario("FrmControlTranportes")
    End Sub

    Private Sub CONTROLDEDESCANSOSMEDICOS_Click(sender As Object, e As EventArgs) Handles CONTROLDEDESCANSOSMEDICOS.Click
        AbrirFormulario("FrmControlTransportesIF")
    End Sub

    Private Sub FrmMenu_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Application.Exit()
    End Sub

    Private Sub cerrarsecion_Click(sender As Object, e As EventArgs)
        'Try
        '    Dim result As DialogResult = MessageBox.Show(
        '       "¿Está seguro que desea cerrar sesión?",
        '       "Confirmación de cierre de sesión",
        '       MessageBoxButtons.YesNo,
        '       MessageBoxIcon.Question
        '   )
        '    If result = DialogResult.Yes Then
        '        Application.Exit()
        '    Else
        '    End If
        'Catch ex As Exception
        '    clsBasicas.controlException(Name, ex)
        'End Try
    End Sub

    Private Sub ADMINISTRARUSUARIOSDISPOSITIVOMOVILToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ADMINISTRARUSUARIOSDISPOSITIVOMOVILToolStripMenuItem.Click
        AbrirFormulario("FrmAdministrarUsuariosCelular")
    End Sub

    Private Sub ADMINISTRARPERMISOSMOVILESToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ADMINISTRARPERMISOSMOVILESToolStripMenuItem.Click
        AbrirFormulario("FrmAdministrarUsuariosCelular")
    End Sub

    Private Sub PRESENTACIONESPRODUCTOSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PRESENTACIONESPRODUCTOSToolStripMenuItem.Click
        AbrirFormulario("FrmPresentacionProducto")
    End Sub

    Private Sub CONTROLDECONDUCTORESToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CONTROLDECONDUCTORESToolStripMenuItem.Click
        AbrirFormulario("FrmConductores")
    End Sub

    Private Sub CONDICIONDEPAGOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CONDICIONDEPAGOToolStripMenuItem.Click
        AbrirFormulario("Frmcondiciondepago")
    End Sub

    Private Sub CARGOSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CARGOSToolStripMenuItem.Click
        AbrirFormulario("FrmCargo")
    End Sub


    Private Sub toolSalir_Click(sender As Object, e As EventArgs) Handles toolSalir.Click
        Try
            Dim result As DialogResult = MessageBox.Show(
               "¿Está seguro que desea cerrar sesión?",
               "Confirmación de cierre de sesión",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question
           )
            If result = DialogResult.Yes Then
                Application.Exit()
            Else
            End If
        Catch ex As Exception
            clsBasicas.controlException(Name, ex)
        End Try
    End Sub

    Private Sub TRANSFERENCIASToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TRANSFERENCIASToolStripMenuItem.Click
        AbrirFormulario("FrmControlTransferencias")
    End Sub

    Private Sub PLANTELESToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PLANTELESToolStripMenuItem.Click
        AbrirFormulario("FrmPlanteles")
    End Sub
    Private Sub REPORTESDELSISTEMAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles REPORTESDELSISTEMAToolStripMenuItem.Click
        AbrirFormulario("FrmReporteSistema")
    End Sub

    Private Sub GESTIÓNDELOTESToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GESTIÓNDELOTESToolStripMenuItem.Click
        AbrirFormulario("FrmGestionLotes")
    End Sub

    Private Sub CONTROLDEASIGNACIONESDEREQUERIMIENTOSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CONTROLDEASIGNACIONESDEREQUERIMIENTOSToolStripMenuItem.Click
        AbrirFormulario("FrmControlAsignacionesRequerimientos")
    End Sub

    Private Sub CONTROLDEMATERNIDADToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CONTROLDEMATERNIDADToolStripMenuItem1.Click
        AbrirFormulario("FrmControlMaternidadDestete")
    End Sub

    Private Sub Cicloreproductivotoolstring_Click(sender As Object, e As EventArgs) Handles Cicloreproductivotoolstring.Click
        AbrirFormulario("FrmControlGestacion")
    End Sub

    Private Sub GESTIÓNDEPERSONALDEPRODUCCIÓNToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GESTIÓNDEPERSONALDEPRODUCCIÓNToolStripMenuItem.Click
        AbrirFormulario("FrmControlPersonalProduccion")
    End Sub

    Private Sub PROTOCOLOSANITARIOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PROTOCOLOSANITARIOToolStripMenuItem.Click
        AbrirFormulario("FrmPlanSanitario")
    End Sub

    Private Sub HISTÓRICODEENFERMEDADESGRANJAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HISTÓRICODEENFERMEDADESGRANJAToolStripMenuItem.Click
        AbrirFormulario("FrmHistoricoEnfermedadesGranja")
    End Sub

    Private Sub CONTROLDECAMPAÑASToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CONTROLDECAMPAÑASToolStripMenuItem1.Click
        AbrirFormulario("FrmControlCampaña")
    End Sub

    Private Sub PROGRAMADEALIMENTACIÓNToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PROGRAMADEALIMENTACIÓNToolStripMenuItem.Click
        AbrirFormulario("FrmProgramaAlimentacion")
    End Sub

    Private Sub CAMPAÑASToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CAMPAÑASToolStripMenuItem.Click
        AbrirFormulario("FrmDespachosCerdosVenta")
    End Sub
End Class