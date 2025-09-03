Public Class coPlanCuenta
    Private _Codigo As Integer
    Private _NumeroCuenta As String
    Private _Descripcion As String
    Private _tipocalificacion As String
    Private _IdSuperior As Nullable(Of Integer)
    Private _Operacion As Integer
    Private _Coderror As Integer
    Private _Iduser As Integer

    Public Property Codigo As Integer
        Get
            Return _Codigo
        End Get
        Set(value As Integer)
            _Codigo = value
        End Set
    End Property
    Public Property NumeroCuenta As String
        Get
            Return _NumeroCuenta
        End Get
        Set(value As String)
            _NumeroCuenta = value
        End Set
    End Property
    Public Property tipocalificacion As String
        Get
            Return _tipocalificacion
        End Get
        Set(value As String)
            _tipocalificacion = value
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

    Public Property IdSuperior As Nullable(Of Integer)
        Get
            Return _IdSuperior
        End Get
        Set(value As Nullable(Of Integer))
            _IdSuperior = value
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

    Public Property Iduser As Integer
        Get
            Return _Iduser
        End Get
        Set(value As Integer)
            _Iduser = value
        End Set
    End Property
End Class
