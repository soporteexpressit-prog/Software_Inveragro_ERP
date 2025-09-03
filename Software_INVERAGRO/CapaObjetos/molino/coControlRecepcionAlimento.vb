Public Class coControlRecepcionAlimento
    Private _Codigo As Integer
    Private _FechaDesde As Date?
    Private _FechaHasta As Date?
    Private _FechaControl As Date
    Private _EstadoPedido As String
    Private _ListarRacionesRecibidas As String
    Private _IdUsuario As Integer
    Private _Coderror As Integer

    Public Property Codigo As Integer
        Get
            Return _Codigo
        End Get
        Set(value As Integer)
            _Codigo = value
        End Set
    End Property

    Public Property FechaDesde As Date?
        Get
            Return _FechaDesde
        End Get
        Set(value As Date?)
            _FechaDesde = value
        End Set
    End Property

    Public Property FechaHasta As Date?
        Get
            Return _FechaHasta
        End Get
        Set(value As Date?)
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

    Public Property EstadoPedido As String
        Get
            Return _EstadoPedido
        End Get
        Set(value As String)
            _EstadoPedido = value
        End Set
    End Property

    Public Property ListarRacionesRecibidas As String
        Get
            Return _ListarRacionesRecibidas
        End Get
        Set(value As String)
            _ListarRacionesRecibidas = value
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

    Public Property Coderror As Integer
        Get
            Return _Coderror
        End Get
        Set(value As Integer)
            _Coderror = value
        End Set
    End Property
End Class
