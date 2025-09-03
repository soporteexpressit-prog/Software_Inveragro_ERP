Public Class coControlMaterialGenetico
    Private _Codigo As Integer
    Private _FechaExtraccion As Date
    Private _FechaProcesamiento As Date
    Private _Volumen As Decimal
    Private _MotilidadPura As Decimal
    Private _MotilidadDiluida As Decimal
    Private _Dosis As Integer
    Private _IdUsuario As Integer
    Private _IdVerraco As Nullable(Of Integer)
    Private _IdUbicacionOrigen As Integer
    Private _IdUbicacionDestino As Integer
    Private _IdEncargado As Integer
    Private _Tipo As String
    Private _FechaDesde As Date
    Private _FechaHasta As Date
    Private _FechaControl As Date
    Private _Coderror As Integer
    Private _IdAlmacenPrincipal As Integer
    Private _IdAlmacenSolicitante As Integer
    Private _ListaProductos As String
    Private _Mensaje As String
    Private _IdProducto As Integer
    Private _Observacion As String
    Private _CodSemenCompra As String
    Private _Estado As String

    Public Property Codigo As Integer
        Get
            Return _Codigo
        End Get
        Set(value As Integer)
            _Codigo = value
        End Set
    End Property

    Public Property FechaExtraccion As Date
        Get
            Return _FechaExtraccion
        End Get
        Set(value As Date)
            _FechaExtraccion = value
        End Set
    End Property

    Public Property FechaProcesamiento As Date
        Get
            Return _FechaProcesamiento
        End Get
        Set(value As Date)
            _FechaProcesamiento = value
        End Set
    End Property

    Public Property Volumen As Decimal
        Get
            Return _Volumen
        End Get
        Set(value As Decimal)
            _Volumen = value
        End Set
    End Property

    Public Property MotilidadPura As Decimal
        Get
            Return _MotilidadPura
        End Get
        Set(value As Decimal)
            _MotilidadPura = value
        End Set
    End Property

    Public Property MotilidadDiluida As Decimal
        Get
            Return _MotilidadDiluida
        End Get
        Set(value As Decimal)
            _MotilidadDiluida = value
        End Set
    End Property

    Public Property Dosis As Integer
        Get
            Return _Dosis
        End Get
        Set(value As Integer)
            _Dosis = value
        End Set
    End Property

    Public Property IdUsuario As Integer
        Get
            Return _IdUsuario
        End Get
        Set(value As Integer)
            _IdUsuario = value
        End Set
    End Property

    Public Property IdVerraco As Integer?
        Get
            Return _IdVerraco
        End Get
        Set(value As Integer?)
            _IdVerraco = value
        End Set
    End Property

    Public Property IdUbicacionOrigen As Integer
        Get
            Return _IdUbicacionOrigen
        End Get
        Set(value As Integer)
            _IdUbicacionOrigen = value
        End Set
    End Property

    Public Property IdUbicacionDestino As Integer
        Get
            Return _IdUbicacionDestino
        End Get
        Set(value As Integer)
            _IdUbicacionDestino = value
        End Set
    End Property

    Public Property IdEncargado As Integer
        Get
            Return _IdEncargado
        End Get
        Set(value As Integer)
            _IdEncargado = value
        End Set
    End Property

    Public Property Tipo As String
        Get
            Return _Tipo
        End Get
        Set(value As String)
            _Tipo = value
        End Set
    End Property

    Public Property FechaDesde As Date
        Get
            Return _FechaDesde
        End Get
        Set(value As Date)
            _FechaDesde = value
        End Set
    End Property

    Public Property FechaHasta As Date
        Get
            Return _FechaHasta
        End Get
        Set(value As Date)
            _FechaHasta = value
        End Set
    End Property

    Public Property FechaControl As Date
        Get
            Return _FechaControl
        End Get
        Set(value As Date)
            _FechaControl = value
        End Set
    End Property

    Public Property Coderror As Integer
        Get
            Return _Coderror
        End Get
        Set(value As Integer)
            _Coderror = value
        End Set
    End Property

    Public Property IdAlmacenPrincipal As Integer
        Get
            Return _IdAlmacenPrincipal
        End Get
        Set(value As Integer)
            _IdAlmacenPrincipal = value
        End Set
    End Property

    Public Property IdAlmacenSolicitante As Integer
        Get
            Return _IdAlmacenSolicitante
        End Get
        Set(value As Integer)
            _IdAlmacenSolicitante = value
        End Set
    End Property

    Public Property ListaProductos As String
        Get
            Return _ListaProductos
        End Get
        Set(value As String)
            _ListaProductos = value
        End Set
    End Property

    Public Property Mensaje As String
        Get
            Return _Mensaje
        End Get
        Set(value As String)
            _Mensaje = value
        End Set
    End Property

    Public Property IdProducto As Integer
        Get
            Return _IdProducto
        End Get
        Set(value As Integer)
            _IdProducto = value
        End Set
    End Property

    Public Property Observacion As String
        Get
            Return _Observacion
        End Get
        Set(value As String)
            _Observacion = value
        End Set
    End Property

    Public Property CodSemenCompra As String
        Get
            Return _CodSemenCompra
        End Get
        Set(value As String)
            _CodSemenCompra = value
        End Set
    End Property

    Public Property Estado As String
        Get
            Return _Estado
        End Get
        Set(value As String)
            _Estado = value
        End Set
    End Property
End Class
