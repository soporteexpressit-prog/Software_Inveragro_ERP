Public Class coCuentaBanco
    Private _Codigo As Integer
    Private _CodReferencia As String
    Private _NumeroCuenta As String
    Private _Estado As String
    Private _IdMoneda As Nullable(Of Integer)
    Private _IdBanco As Nullable(Of Integer)
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
    Public Property CodReferencia As String
        Get
            Return _CodReferencia
        End Get
        Set(value As String)
            _CodReferencia = value
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
    Public Property Estado As String
        Get
            Return _Estado
        End Get
        Set(value As String)
            _Estado = value
        End Set
    End Property

    Public Property IdMoneda As Nullable(Of Integer)
        Get
            Return _IdMoneda
        End Get
        Set(value As Nullable(Of Integer))
            _IdMoneda = value
        End Set
    End Property

    Public Property IdBanco As Nullable(Of Integer)
        Get
            Return _IdBanco
        End Get
        Set(value As Nullable(Of Integer))
            _IdBanco = value
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
