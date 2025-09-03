Public Class coControlDespachoCerdoVenta
    Private _FechaDesde As Date
    Private _FechaHasta As Date
    Private _FechaControl As Date
    Private _Estado As String
    Private _NombreProveedor As String
    Private _IdPlantel As Integer
    Private _IdSalida As Integer
    Private _PesoPromedio As Double
    Private _Observacion As String
    Private _ListaCerdosPeso As String
    Private _IdMotivoTransaccion As Integer
    Private _PesoBruto As Double
    Private _IdUsuario As Integer
    Private _IdRacion As Integer
    Private _NumSacosDespachados As Decimal
    Private _CantidadCerdos As Integer
    Private _Codigo As Integer
    Private _Coderror As Integer

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

    Public Property Estado As String
        Get
            Return _Estado
        End Get
        Set(value As String)
            _Estado = value
        End Set
    End Property

    Public Property NombreProveedor As String
        Get
            Return _NombreProveedor
        End Get
        Set(value As String)
            _NombreProveedor = value
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

    Public Property IdSalida As Integer
        Get
            Return _IdSalida
        End Get
        Set(value As Integer)
            _IdSalida = value
        End Set
    End Property

    Public Property PesoPromedio As Double
        Get
            Return _PesoPromedio
        End Get
        Set(value As Double)
            _PesoPromedio = value
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

    Public Property ListaCerdosPeso As String
        Get
            Return _ListaCerdosPeso
        End Get
        Set(value As String)
            _ListaCerdosPeso = value
        End Set
    End Property

    Public Property IdMotivoTransaccion As Integer
        Get
            Return _IdMotivoTransaccion
        End Get
        Set(value As Integer)
            _IdMotivoTransaccion = value
        End Set
    End Property

    Public Property PesoBruto As Double
        Get
            Return _PesoBruto
        End Get
        Set(value As Double)
            _PesoBruto = value
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

    Public Property IdRacion As Integer
        Get
            Return _IdRacion
        End Get
        Set(value As Integer)
            _IdRacion = value
        End Set
    End Property

    Public Property NumSacosDespachados As Decimal
        Get
            Return _NumSacosDespachados
        End Get
        Set(value As Decimal)
            _NumSacosDespachados = value
        End Set
    End Property

    Public Property CantidadCerdos As Integer
        Get
            Return _CantidadCerdos
        End Get
        Set(value As Integer)
            _CantidadCerdos = value
        End Set
    End Property

    Public Property Codigo As Integer
        Get
            Return _Codigo
        End Get
        Set(value As Integer)
            _Codigo = value
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
