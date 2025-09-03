Public Class coControlGestacion
    Private _Operacion As Integer
    Private _Codigo As Integer
    Private _CantidadExpulsada As Integer
    Private _IdPlantel As Integer
    Private _NumDosis As Integer
    Private _IdUsuario As Integer
    Private _IdMaterialGenetico As Integer
    Private _IdDetalleInseminacion As Integer
    Private _IdCerda As Integer
    Private _FechaMonta As Date
    Private _IdPersona As Integer
    Private _CodCorporal As Decimal
    Private _FechaDesde As Date
    Private _FechaHasta As Date
    Private _ViaAplicacion As String
    Private _TipoSemen As String
    Private _ListaServicios As String
    Private _IdControlFicha As Integer
    Private _Peso As Decimal
    Private _Coderror As Integer

    Public Property Operacion As Integer
        Get
            Return _Operacion
        End Get
        Set(value As Integer)
            _Operacion = value
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

    Public Property CantidadExpulsada As Integer
        Get
            Return _CantidadExpulsada
        End Get
        Set(value As Integer)
            _CantidadExpulsada = value
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

    Public Property NumDosis As Integer
        Get
            Return _NumDosis
        End Get
        Set(value As Integer)
            _NumDosis = value
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

    Public Property IdMaterialGenetico As Integer
        Get
            Return _IdMaterialGenetico
        End Get
        Set(value As Integer)
            _IdMaterialGenetico = value
        End Set
    End Property

    Public Property IdDetalleInseminacion As Integer
        Get
            Return _IdDetalleInseminacion
        End Get
        Set(value As Integer)
            _IdDetalleInseminacion = value
        End Set
    End Property

    Public Property IdCerda As Integer
        Get
            Return _IdCerda
        End Get
        Set(value As Integer)
            _IdCerda = value
        End Set
    End Property

    Public Property FechaMonta As Date
        Get
            Return _FechaMonta
        End Get
        Set(value As Date)
            _FechaMonta = value
        End Set
    End Property

    Public Property IdPersona As Integer
        Get
            Return _IdPersona
        End Get
        Set(value As Integer)
            _IdPersona = value
        End Set
    End Property

    Public Property CodCorporal As Decimal
        Get
            Return _CodCorporal
        End Get
        Set(value As Decimal)
            _CodCorporal = value
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

    Public Property ViaAplicacion As String
        Get
            Return _ViaAplicacion
        End Get
        Set(value As String)
            _ViaAplicacion = value
        End Set
    End Property

    Public Property TipoSemen As String
        Get
            Return _TipoSemen
        End Get
        Set(value As String)
            _TipoSemen = value
        End Set
    End Property

    Public Property ListaServicios As String
        Get
            Return _ListaServicios
        End Get
        Set(value As String)
            _ListaServicios = value
        End Set
    End Property

    Public Property IdControlFicha As Integer
        Get
            Return _IdControlFicha
        End Get
        Set(value As Integer)
            _IdControlFicha = value
        End Set
    End Property

    Public Property Peso As Decimal
        Get
            Return _Peso
        End Get
        Set(value As Decimal)
            _Peso = value
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
