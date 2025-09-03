Public Class coControlEpp
    Private _Codigo As Integer
    Private _Fecha As Date
    Private _Estado As String
    Private _IdSolicitante As Integer
    Private _IdTipoMotivoEpp As Integer
    Private _IdUbicacion As Integer
    Private _Operacion As Integer
    Private _Coderror As Integer
    Private _Iduser As Integer
    Private _FechaDesde As Nullable(Of Date)
    Private _FechaHasta As Nullable(Of Date)
    Private _lista_items As String
    Private _IdUserAnulacion As Integer
    Private _MotivoAnulacion As String
    Private _observacion As String

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

    Public Property Estado As String
        Get
            Return _Estado
        End Get
        Set(value As String)
            _Estado = value
        End Set
    End Property
    Public Property IdSolicitante As Integer
        Get
            Return _IdSolicitante
        End Get
        Set(value As Integer)
            _IdSolicitante = value
        End Set
    End Property
    Public Property IdTipoMotivoEpp As Integer
        Get
            Return _IdTipoMotivoEpp
        End Get
        Set(value As Integer)
            _IdTipoMotivoEpp = value
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
    Public Property observacion As String
        Get
            Return _observacion
        End Get
        Set(value As String)
            _observacion = value
        End Set
    End Property
    Public Property Iduser As Integer
        Get
            Return _Iduser
        End Get
        Set(value As Integer)
            _Iduser = value
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
    Public Property Lista_items As String
        Get
            Return _lista_items
        End Get
        Set(value As String)
            _lista_items = value
        End Set
    End Property
End Class
