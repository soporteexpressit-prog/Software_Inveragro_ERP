Public Class coControlCapacitacion
    Private _Codigo As Integer
    Private _FechaCapacitacion As Date
    Private _IdTipoCapacitacion As Integer
    Private _IdCapacitador As Integer
    Private _IdTemarioCapacitacion As Integer
    Private _IdUsuario As Integer
    Private _FechaDesde As Nullable(Of Date)
    Private _FechaHasta As Nullable(Of Date)
    Private _Operacion As Integer
    Private _IdPlantel As Integer
    Private _Coderror As Integer
    Private _lista_items As String
    Private _RutaEvidencia As String
    Private _Estado As String

    Public Property Codigo As Integer
        Get
            Return _Codigo
        End Get
        Set(value As Integer)
            _Codigo = value
        End Set
    End Property

    Public Property FechaCapacitacion As Date
        Get
            Return _FechaCapacitacion
        End Get
        Set(value As Date)
            _FechaCapacitacion = value
        End Set
    End Property

    Public Property IdTipoCapacitacion As Integer
        Get
            Return _IdTipoCapacitacion
        End Get
        Set(value As Integer)
            _IdTipoCapacitacion = value
        End Set
    End Property

    Public Property IdCapacitador As Integer
        Get
            Return _IdCapacitador
        End Get
        Set(value As Integer)
            _IdCapacitador = value
        End Set
    End Property

    Public Property IdTemarioCapacitacion As Integer
        Get
            Return _IdTemarioCapacitacion
        End Get
        Set(value As Integer)
            _IdTemarioCapacitacion = value
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

    Public Property FechaDesde As Nullable(Of Date)
        Get
            Return _FechaDesde
        End Get
        Set(value As Nullable(Of Date))
            _FechaDesde = value
        End Set
    End Property

    Public Property FechaHasta As Nullable(Of Date)
        Get
            Return _FechaHasta
        End Get
        Set(value As Nullable(Of Date))
            _FechaHasta = value
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

    Public Property Coderror As Integer
        Get
            Return _Coderror
        End Get
        Set(value As Integer)
            _Coderror = value
        End Set
    End Property

    Public Property Lista_items As String
        Get
            Return _lista_items
        End Get
        Set(value As String)
            _lista_items = value
        End Set
    End Property

    Public Property RutaEvidencia As String
        Get
            Return _RutaEvidencia
        End Get
        Set(value As String)
            _RutaEvidencia = value
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

    Public Property IdPlantel As Integer
        Get
            Return _IdPlantel
        End Get
        Set(value As Integer)
            _IdPlantel = value
        End Set
    End Property
End Class
