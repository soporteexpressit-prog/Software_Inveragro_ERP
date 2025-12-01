Public Class coControlPreparacionAlimento
    Private _Codigo As Integer
    Private _Fecha As Date
    Private _IdUsuario As Integer
    Private _IdUbicacion As Integer
    Private _ListaInsumoPreparacion As String
    Private _ListaRaciones As String
    Private _ListaIdsSalida As String
    Private _ListaIdsDetalleSalida As String
    Private _Tipo As String
    Private _Coderror As Integer
    Private _FechaDesde As Date?
    Private _FechaHasta As Date?
    Private _Cantidad As Double
    Private _IdUbicacionDestino As Integer

    Public Property Codigo As Integer
        Get
            Return _Codigo
        End Get
        Set(value As Integer)
            _Codigo = value
        End Set
    End Property

    Public Property Fecha As Date
        Get
            Return _Fecha
        End Get
        Set(value As Date)
            _Fecha = value
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

    Public Property IdUbicacion As Integer
        Get
            Return _IdUbicacion
        End Get
        Set(value As Integer)
            _IdUbicacion = value
        End Set
    End Property

    Public Property ListaInsumoPreparacion As String
        Get
            Return _ListaInsumoPreparacion
        End Get
        Set(value As String)
            _ListaInsumoPreparacion = value
        End Set
    End Property

    Public Property ListaRaciones As String
        Get
            Return _ListaRaciones
        End Get
        Set(value As String)
            _ListaRaciones = value
        End Set
    End Property

    Public Property ListaIdsSalida As String
        Get
            Return _ListaIdsSalida
        End Get
        Set(value As String)
            _ListaIdsSalida = value
        End Set
    End Property

    Public Property ListaIdsDetalleSalida As String
        Get
            Return _ListaIdsDetalleSalida
        End Get
        Set(value As String)
            _ListaIdsDetalleSalida = value
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

    Public Property Coderror As Integer
        Get
            Return _Coderror
        End Get
        Set(value As Integer)
            _Coderror = value
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

    Public Property Cantidad As Double
        Get
            Return _Cantidad
        End Get
        Set(value As Double)
            _Cantidad = value
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
End Class
