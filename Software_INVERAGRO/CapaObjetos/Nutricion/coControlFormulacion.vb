Public Class coControlFormulacion
    Private _Codigo As Integer
    Private _Descripcion As String
    Private _Preparacion As Decimal
    Private _Iduser As Integer
    Private _IdFormulaBase As Integer
    Private _Estado As String
    Private _ListaDetalleRacion As String
    Private _ListaAsignacionRacion As String
    Private _FechaElaboracion As Date
    Private _Motivo As String
    Private _Operacion As Integer
    Private _Coderror As Integer
    Private _fechaDesde As Nullable(Of Date)
    Private _fechaHasta As Nullable(Of Date)
    'Para la tabla ProductoFormula
    Private _IdProductoFormula As Integer
    Private _IdProductoNuevo As Integer
    Private _EstadoProductoFormula As String
    Private _ListaIdsInsumos As String
    Private _IdNucleo As Integer
    Private _Msj As String
    Private _TipoPremixero As String
    Private _IdFormulaRacion As Integer
    Private _Diseño As Double
    Private _ListaIdsDetalleSalida As String
    Private _Nota As String
    Private _IdUbicacion As Integer
    Private _Tipo As String
    Private _IdsUbicacion As String
    Private _IdNutricionista As Integer
    Private _IdPeriodoMedicion As Integer
    Private _IdPeriodoPlus As Integer
    Private _Anio As Integer

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

    Public Property Preparacion As Decimal
        Get
            Return _Preparacion
        End Get
        Set(value As Decimal)
            _Preparacion = value
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

    Public Property IdFormulaBase As Integer
        Get
            Return _IdFormulaBase
        End Get
        Set(value As Integer)
            _IdFormulaBase = value
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

    Public Property ListaDetalleRacion As String
        Get
            Return _ListaDetalleRacion
        End Get
        Set(value As String)
            _ListaDetalleRacion = value
        End Set
    End Property

    Public Property ListaAsignacionRacion As String
        Get
            Return _ListaAsignacionRacion
        End Get
        Set(value As String)
            _ListaAsignacionRacion = value
        End Set
    End Property

    Public Property FechaElaboracion As Date
        Get
            Return _FechaElaboracion
        End Get
        Set(value As Date)
            _FechaElaboracion = value
        End Set
    End Property

    Public Property Motivo As String
        Get
            Return _Motivo
        End Get
        Set(value As String)
            _Motivo = value
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

    Public Property FechaDesde As Date?
        Get
            Return _fechaDesde
        End Get
        Set(value As Date?)
            _fechaDesde = value
        End Set
    End Property

    Public Property FechaHasta As Date?
        Get
            Return _fechaHasta
        End Get
        Set(value As Date?)
            _fechaHasta = value
        End Set
    End Property

    Public Property IdProductoFormula As Integer
        Get
            Return _IdProductoFormula
        End Get
        Set(value As Integer)
            _IdProductoFormula = value
        End Set
    End Property

    Public Property IdProductoNuevo As Integer
        Get
            Return _IdProductoNuevo
        End Get
        Set(value As Integer)
            _IdProductoNuevo = value
        End Set
    End Property

    Public Property EstadoProductoFormula As String
        Get
            Return _EstadoProductoFormula
        End Get
        Set(value As String)
            _EstadoProductoFormula = value
        End Set
    End Property

    Public Property ListaIdsInsumos As String
        Get
            Return _ListaIdsInsumos
        End Get
        Set(value As String)
            _ListaIdsInsumos = value
        End Set
    End Property

    Public Property IdNucleo As Integer
        Get
            Return _IdNucleo
        End Get
        Set(value As Integer)
            _IdNucleo = value
        End Set
    End Property

    Public Property Msj As String
        Get
            Return _Msj
        End Get
        Set(value As String)
            _Msj = value
        End Set
    End Property

    Public Property TipoPremixero As String
        Get
            Return _TipoPremixero
        End Get
        Set(value As String)
            _TipoPremixero = value
        End Set
    End Property

    Public Property IdFormulaRacion As Integer
        Get
            Return _IdFormulaRacion
        End Get
        Set(value As Integer)
            _IdFormulaRacion = value
        End Set
    End Property

    Public Property Diseño As Double
        Get
            Return _Diseño
        End Get
        Set(value As Double)
            _Diseño = value
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

    Public Property Nota As String
        Get
            Return _Nota
        End Get
        Set(value As String)
            _Nota = value
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

    Public Property Tipo As String
        Get
            Return _Tipo
        End Get
        Set(value As String)
            _Tipo = value
        End Set
    End Property

    Public Property IdsUbicacion As String
        Get
            Return _IdsUbicacion
        End Get
        Set(value As String)
            _IdsUbicacion = value
        End Set
    End Property

    Public Property IdNutricionista As String
        Get
            Return _IdNutricionista
        End Get
        Set(value As String)
            _IdNutricionista = value
        End Set
    End Property

    Public Property IdPeriodoMedicion As String
        Get
            Return _IdPeriodoMedicion
        End Get
        Set(value As String)
            _IdPeriodoMedicion = value
        End Set
    End Property

    Public Property IdPeriodoPlus As String
        Get
            Return _IdPeriodoPlus
        End Get
        Set(value As String)
            _IdPeriodoPlus = value
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
End Class
