Public Class coProductos
    Private _Operacion As Integer
    Private _Idproducto As Integer
    Private _Descripcion As String
    Private _Stockminimo As Decimal
    Private _Presentacion As String
    Private _Lotes As String
    Private _AfectoIgv As String
    Private _Estado As String
    Private _Observacion As String
    Private _IdUsuario As Integer
    Private _IdCategoria As Integer
    Private _Idmarca As Integer
    Private _Msj As String
    Private _Coderror As Integer
    Private _idUbicacion As Integer
    Private _idUnidadMedida As Integer
    Private _codigobarras As String
    Private _FechaDesde As Date
    Private _FechaHasta As Date
    Private _PrincioActivo As String
    Private _Equivalencia As Decimal
    Private _Idpresentacion As Integer
    Private _ListaItems As String
    Private _IdIngreso As Integer
    Private _uniporpresentacion As Integer
    Private _Comprar As String
    Private _Vender As String
    Private _esmolino As String
    Private _EsRacionExterna As Boolean
    Private _IdProductoEquivalencia As Integer

    Public Property Idproducto As Integer
        Get
            Return _Idproducto
        End Get
        Set(value As Integer)
            _Idproducto = value
        End Set
    End Property
    Public Property uniporpresentacion As Integer
        Get
            Return _uniporpresentacion
        End Get
        Set(value As Integer)
            _uniporpresentacion = value
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
    Public Property esmolino As String
        Get
            Return _esmolino
        End Get
        Set(value As String)
            _esmolino = value
        End Set
    End Property

    Public Property Stockminimo As Decimal
        Get
            Return _Stockminimo
        End Get
        Set(value As Decimal)
            _Stockminimo = value
        End Set
    End Property

    Public Property Presentacion As String
        Get
            Return _Presentacion
        End Get
        Set(value As String)
            _Presentacion = value
        End Set
    End Property

    Public Property Lotes As String
        Get
            Return _Lotes
        End Get
        Set(value As String)
            _Lotes = value
        End Set
    End Property

    Public Property AfectoIgv As String
        Get
            Return _AfectoIgv
        End Get
        Set(value As String)
            _AfectoIgv = value
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

    Public Property Observacion As String
        Get
            Return _Observacion
        End Get
        Set(value As String)
            _Observacion = value
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

    Public Property Idmarca As Integer
        Get
            Return _Idmarca
        End Get
        Set(value As Integer)
            _Idmarca = value
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

    Public Property Coderror As Integer
        Get
            Return _Coderror
        End Get
        Set(value As Integer)
            _Coderror = value
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

    Public Property IdCategoria As Integer
        Get
            Return _IdCategoria
        End Get
        Set(value As Integer)
            _IdCategoria = value
        End Set
    End Property

    Public Property IdUbicacion As Integer
        Get
            Return _idUbicacion
        End Get
        Set(value As Integer)
            _idUbicacion = value
        End Set
    End Property

    Public Property IdUnidadMedida As Integer
        Get
            Return _idUnidadMedida
        End Get
        Set(value As Integer)
            _idUnidadMedida = value
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

    Public Property Codigobarras As String
        Get
            Return _codigobarras
        End Get
        Set(value As String)
            _codigobarras = value
        End Set
    End Property

    Public Property PrincioActivo As String
        Get
            Return _PrincioActivo
        End Get
        Set(value As String)
            _PrincioActivo = value
        End Set
    End Property

    Public Property Equivalencia As Decimal
        Get
            Return _Equivalencia
        End Get
        Set(value As Decimal)
            _Equivalencia = value
        End Set
    End Property

    Public Property Idpresentacion As Integer
        Get
            Return _Idpresentacion
        End Get
        Set(value As Integer)
            _Idpresentacion = value
        End Set
    End Property

    Public Property ListaItems As String
        Get
            Return _ListaItems
        End Get
        Set(value As String)
            _ListaItems = value
        End Set
    End Property

    Public Property IdIngreso As Integer
        Get
            Return _IdIngreso
        End Get
        Set(value As Integer)
            _IdIngreso = value
        End Set
    End Property

    Public Property Comprar As String
        Get
            Return _Comprar
        End Get
        Set(value As String)
            _Comprar = value
        End Set
    End Property

    Public Property Vender As String
        Get
            Return _Vender
        End Get
        Set(value As String)
            _Vender = value
        End Set
    End Property

    Public Property EsRacionExterna As Boolean
        Get
            Return _EsRacionExterna
        End Get
        Set(value As Boolean)
            _EsRacionExterna = value
        End Set
    End Property

    Public Property IdProductoEquivalencia As Integer
        Get
            Return _IdProductoEquivalencia
        End Get
        Set(value As Integer)
            _IdProductoEquivalencia = value
        End Set
    End Property
End Class
