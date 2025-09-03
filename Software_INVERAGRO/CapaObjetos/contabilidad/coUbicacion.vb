Public Class coUbicacion
    Private _Codigo As Integer
    Private _Descripcion As String
    Private _Operacion As Integer
    Private _Densidad As Nullable(Of Decimal)
    Private _Coderror As Integer
    Private _Iduser As Integer
    Private _NumChanchillas As Integer
    Private _Anio As Integer

    Private _Codigo2 As Integer
    Private _Codigo3 As Integer
    Private _Codreturn As Integer

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

    Public Property Operacion As Integer
        Get
            Return _Operacion
        End Get
        Set(value As Integer)
            _Operacion = value
        End Set
    End Property

    Public Property Densidad As Nullable(Of Decimal)
        Get
            Return _Densidad
        End Get
        Set(value As Nullable(Of Decimal))
            _Densidad = value
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

    Public Property Iduser As Integer
        Get
            Return _Iduser
        End Get
        Set(value As Integer)
            _Iduser = value
        End Set
    End Property

    Public Property Codigo2 As Integer
        Get
            Return _Codigo2
        End Get
        Set(value As Integer)
            _Codigo2 = value
        End Set
    End Property

    Public Property Codigo3 As Integer
        Get
            Return _Codigo3
        End Get
        Set(value As Integer)
            _Codigo3 = value
        End Set
    End Property

    Public Property Codreturn As Integer
        Get
            Return _Codreturn
        End Get
        Set(value As Integer)
            _Codreturn = value
        End Set
    End Property

    Public Property NumChanchillas As Integer
        Get
            Return _NumChanchillas
        End Get
        Set(value As Integer)
            _NumChanchillas = value
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
