Public Class coNucleo
    Private _Codigo As Integer
    Private _Descripcion As String
    Private _Abreviatura As String
    Private _idUsuario As Integer
    Private _IdUbicacion As Integer
    Private _IdLote As Integer
    Private _IdGrupo As Integer
    Private _Estado As String
    Private _Operacion As Integer
    Private _Coderror As Integer
    Private _Tipo As String
    Private _IdNutricionista As Integer
    Private _ListaItems As String
    Private _FechaDesde As Date
    Private _FechaHasta As Date

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

    Public Property Abreviatura As String
        Get
            Return _Abreviatura
        End Get
        Set(value As String)
            _Abreviatura = value
        End Set
    End Property

    Public Property IdUsuario As Integer
        Get
            Return _idUsuario
        End Get
        Set(value As Integer)
            _idUsuario = value
        End Set
    End Property

    Public Property IdGrupo As Integer
        Get
            Return _IdGrupo
        End Get
        Set(value As Integer)
            _IdGrupo = value
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

    Public Property IdUbicacion As Integer
        Get
            Return _IdUbicacion
        End Get
        Set(value As Integer)
            _IdUbicacion = value
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

    Public Property Coderror As Integer
        Get
            Return _Coderror
        End Get
        Set(value As Integer)
            _Coderror = value
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

    Public Property IdNutricionista As Integer
        Get
            Return _IdNutricionista
        End Get
        Set(value As Integer)
            _IdNutricionista = value
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
End Class
