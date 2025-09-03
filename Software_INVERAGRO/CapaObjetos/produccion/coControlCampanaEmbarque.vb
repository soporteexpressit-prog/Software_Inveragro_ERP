Public Class coControlCampanaEmbarque
    Private _Codigo As Integer
    Private _IdPlantel As Integer
    Private _FechaDesde As Date
    Private _FechaHasta As Date
    Private _IdCampaña As Integer
    Private _Anio As Integer
    Private _Coderror As Integer

    Public Property Codigo As Integer
        Get
            Return _Codigo
        End Get
        Set(value As Integer)
            _Codigo = value
        End Set
    End Property

    Public Property Anio As Integer
        Get
            Return _Anio
        End Get
        Set(value As Integer)
            _Anio = value
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

    Public Property IdPlantel As Integer
        Get
            Return _IdPlantel
        End Get
        Set(value As Integer)
            _IdPlantel = value
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

    Public Property Coderror As Integer
        Get
            Return _Coderror
        End Get
        Set(value As Integer)
            _Coderror = value
        End Set
    End Property
End Class
