Public Class coControlDespacho
    Private _Codigo As Integer
    Private _Fecha As Date
    Private _FechaDesde As Date?
    Private _FechaHasta As Date?
    Private _EstadoPreparacion As String
    Private _Observacion As String
    Private _IdSalida As Integer
    Private _IdUbicacionOrigen As Integer
    Private _IdUbicacionDestino As Integer
    Private _IdTransporte As Integer
    Private _IdConductor As Integer
    Private _ListaDetalleRecepcion As String
    Private _DespachoCompleto As Integer
    Private _IdUserAnulacion As Integer
    Private _MotivoAnulacion As String
    Private _Coderror As Integer

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

    Public Property EstadoPreparacion As String
        Get
            Return _EstadoPreparacion
        End Get
        Set(value As String)
            _EstadoPreparacion = value
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

    Public Property IdSalida As Integer
        Get
            Return _IdSalida
        End Get
        Set(value As Integer)
            _IdSalida = value
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

    Public Property IdTransporte As Integer
        Get
            Return _IdTransporte
        End Get
        Set(value As Integer)
            _IdTransporte = value
        End Set
    End Property

    Public Property IdConductor As Integer
        Get
            Return _IdConductor
        End Get
        Set(value As Integer)
            _IdConductor = value
        End Set
    End Property

    Public Property ListaDetalleRecepcion As String
        Get
            Return _ListaDetalleRecepcion
        End Get
        Set(value As String)
            _ListaDetalleRecepcion = value
        End Set
    End Property

    Public Property DespachoCompleto As Integer
        Get
            Return _DespachoCompleto
        End Get
        Set(value As Integer)
            _DespachoCompleto = value
        End Set
    End Property

    Public Property IdUserAnulacion As Integer
        Get
            Return _IdUserAnulacion
        End Get
        Set(value As Integer)
            _IdUserAnulacion = value
        End Set
    End Property

    Public Property MotivoAnulacion As String
        Get
            Return _MotivoAnulacion
        End Get
        Set(value As String)
            _MotivoAnulacion = value
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
