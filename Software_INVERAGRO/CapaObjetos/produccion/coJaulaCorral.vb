Public Class coJaulaCorral
    Private _Codigo As Integer
    Private _Descripcion As String
    Private _Capacidad As Integer
    Private _IdGalpon As Nullable(Of Integer)
    Private _IdSala As Nullable(Of Integer)
    Private _IdUbicacion As Integer
    Private _IdLote As Integer
    Private _Tipo As String
    Private _Estado As String
    Private _Largo As Decimal
    Private _Ancho As Decimal
    Private _Abreviatura As String
    Private _EsClinica As String
    Private _IdArea As Integer
    Private _Operacion As Integer
    Private _IdCampaña As Integer
    Private _Coderror As Integer
    Private _Cantidad As Integer

    Public Property Codigo As Integer
        Get
            Return _Codigo
        End Get
        Set(value As Integer)
            _Codigo = value
        End Set
    End Property
    Public Property Descripcion As String
        Get
            Return _Descripcion
        End Get
        Set(value As String)
            _Descripcion = value
        End Set
    End Property

    Public Property Capacidad As Integer
        Get
            Return _Capacidad
        End Get
        Set(value As Integer)
            _Capacidad = value
        End Set
    End Property

    Public Property IdGalpon As Nullable(Of Integer)
        Get
            Return _IdGalpon
        End Get
        Set(value As Nullable(Of Integer))
            _IdGalpon = value
        End Set
    End Property

    Public Property IdSala As Nullable(Of Integer)
        Get
            Return _IdSala
        End Get
        Set(value As Nullable(Of Integer))
            _IdSala = value
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

    Public Property IdLote As Integer
        Get
            Return _IdLote
        End Get
        Set(value As Integer)
            _IdLote = value
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

    Public Property Ancho As Decimal
        Get
            Return _Ancho
        End Get
        Set(value As Decimal)
            _Ancho = value
        End Set
    End Property

    Public Property Largo As Decimal
        Get
            Return _Largo
        End Get
        Set(value As Decimal)
            _Largo = value
        End Set
    End Property

    Public Property Abreviatura As String
        Get
            Return _Abreviatura
        End Get
        Set(value As String)
            _Abreviatura = value
        End Set
    End Property

    Public Property EsClinica As String
        Get
            Return _EsClinica
        End Get
        Set(value As String)
            _EsClinica = value
        End Set
    End Property

    Public Property IdArea As Integer
        Get
            Return _IdArea
        End Get
        Set(value As Integer)
            _IdArea = value
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

    Public Property Operacion As Integer
        Get
            Return _Operacion
        End Get
        Set(value As Integer)
            _Operacion = value
        End Set
    End Property

    Public Property IdCampaña As Integer
        Get
            Return _IdCampaña
        End Get
        Set(value As Integer)
            _IdCampaña = value
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

    Public Property Cantidad As Integer
        Get
            Return _Cantidad
        End Get
        Set(value As Integer)
            _Cantidad = value
        End Set
    End Property
End Class
