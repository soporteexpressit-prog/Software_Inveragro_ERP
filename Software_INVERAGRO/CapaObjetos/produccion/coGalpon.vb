Public Class coGalpon
    Private _Codigo As Integer
    Private _Descripcion As String
    Private _IdArea As Integer
    Private _IdUbicacion As Nullable(Of Integer)
    Private _EsEmbarcadero As String
    Private _Operacion As Integer
    Private _Coderror As Integer

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

    Public Property IdArea As Integer
        Get
            Return _IdArea
        End Get
        Set(value As Integer)
            _IdArea = value
        End Set
    End Property

    Public Property IdUbicacion As Nullable(Of Integer)
        Get
            Return _IdUbicacion
        End Get
        Set(value As Nullable(Of Integer))
            _IdUbicacion = value
        End Set
    End Property

    Public Property EsEmbarcadero As String
        Get
            Return _EsEmbarcadero
        End Get
        Set(value As String)
            _EsEmbarcadero = value
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
End Class
