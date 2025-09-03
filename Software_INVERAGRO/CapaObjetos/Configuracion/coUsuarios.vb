Public Class coUsuarios
    Private _Operacion As Integer
    Private _Codigo As Integer
    Private _Usuario As String
    Private _Clave As Byte()
    Private _Coderror As Integer
    Private _cambiarclave As Integer

    Public Property cambiarclave As Integer
        Get
            Return _cambiarclave
        End Get
        Set(value As Integer)
            _cambiarclave = value
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

    Public Property Codigo As Integer
        Get
            Return _Codigo
        End Get
        Set(value As Integer)
            _Codigo = value
        End Set
    End Property

    Public Property Usuario As String
        Get
            Return _Usuario
        End Get
        Set(value As String)
            _Usuario = value
        End Set
    End Property
    Public Property Clave As Byte()
        Get
            Return _Clave
        End Get
        Set(value As Byte())
            _Clave = value
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
