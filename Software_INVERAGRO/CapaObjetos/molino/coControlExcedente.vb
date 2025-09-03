Public Class coControlExcedente
    Private _Codigo As Integer
    Private _IdUsuario As Integer
    Private _IdUbicacion As Integer
    Private _ListaInsumosExtra As String
    Private _Estado As String
    Private _Coderror As Integer
    Private _FechaDesde As Date?
    Private _FechaHasta As Date?
    Private _IdUserAnulacion As Integer
    Private _MotivoAnulacion As String

    Public Property Codigo As Integer
        Get
            Return _Codigo
        End Get
        Set(value As Integer)
            _Codigo = value
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

    Public Property ListaInsumosExtra As String
        Get
            Return _ListaInsumosExtra
        End Get
        Set(value As String)
            _ListaInsumosExtra = value
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

    Public Property Coderror As Integer
        Get
            Return _Coderror
        End Get
        Set(value As Integer)
            _Coderror = value
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
End Class
