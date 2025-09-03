Public Class coActivo
    Private _codigo As Integer
    Private _descripcion As String
    Private _fechaAdquisicion As Date
    Private _nota As String
    Private _placa As String
    Private _numSerie As String
    Private _capacidad As Decimal
    Private _estado As String
    Private _idUser As Integer
    Private _costoAdquisicion As Decimal
    Private _idMarca As Integer
    Private _vidaUtil As Nullable(Of Integer)
    Private _tipo As String
    Private _Operacion As Integer
    Private _Coderror As Integer
    Private _idDetalleRecepcion As Integer
    Private _numOrden As Integer
    Private _fechaDesde As Nullable(Of Date)
    Private _fechaHasta As Nullable(Of Date)
    Private _MotivoAnulacion As String
    Private _IdUserAnulacion As Integer

    Public Property Codigo As Integer
        Get
            Return _codigo
        End Get
        Set(value As Integer)
            _codigo = value
        End Set
    End Property

    Public Property Descripcion As String
        Get
            Return _descripcion
        End Get
        Set(value As String)
            _descripcion = value
        End Set
    End Property

    Public Property FechaAdquisicion As Date
        Get
            Return _fechaAdquisicion
        End Get
        Set(value As Date)
            _fechaAdquisicion = value
        End Set
    End Property

    Public Property Nota As String
        Get
            Return _nota
        End Get
        Set(value As String)
            _nota = value
        End Set
    End Property

    Public Property Tipo As String
        Get
            Return _tipo
        End Get
        Set(value As String)
            _tipo = value
        End Set
    End Property

    Public Property Placa As String
        Get
            Return _placa
        End Get
        Set(value As String)
            _placa = value
        End Set
    End Property

    Public Property NumSerie As String
        Get
            Return _numSerie
        End Get
        Set(value As String)
            _numSerie = value
        End Set
    End Property

    Public Property Capacidad As Decimal
        Get
            Return _capacidad
        End Get
        Set(value As Decimal)
            _capacidad = value
        End Set
    End Property

    Public Property Estado As String
        Get
            Return _estado
        End Get
        Set(value As String)
            _estado = value
        End Set
    End Property

    Public Property IdUser As Integer
        Get
            Return _idUser
        End Get
        Set(value As Integer)
            _idUser = value
        End Set
    End Property

    Public Property CostoAdquisicion As Decimal
        Get
            Return _costoAdquisicion
        End Get
        Set(value As Decimal)
            _costoAdquisicion = value
        End Set
    End Property

    Public Property IdMarca As Integer
        Get
            Return _idMarca
        End Get
        Set(value As Integer)
            _idMarca = value
        End Set
    End Property

    Public Property VidaUtil As Nullable(Of Integer)
        Get
            Return _vidaUtil
        End Get
        Set(value As Nullable(Of Integer))
            _vidaUtil = value
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

    Public Property IdDetalleRecepcion As Integer
        Get
            Return _idDetalleRecepcion
        End Get
        Set(value As Integer)
            _idDetalleRecepcion = value
        End Set
    End Property

    Public Property NumOrden As Integer
        Get
            Return _numOrden
        End Get
        Set(value As Integer)
            _numOrden = value
        End Set
    End Property

    Public Property FechaDesde As Nullable(Of Date)
        Get
            Return _fechaDesde
        End Get
        Set(value As Nullable(Of Date))
            _fechaDesde = value
        End Set
    End Property

    Public Property FechaHasta As Nullable(Of Date)
        Get
            Return _fechaHasta
        End Get
        Set(value As Nullable(Of Date))
            _fechaHasta = value
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

    Public Property IdUserAnulacion As Integer
        Get
            Return _IdUserAnulacion
        End Get
        Set(value As Integer)
            _IdUserAnulacion = value
        End Set
    End Property
End Class
