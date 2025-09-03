Public Class coMoneda
    Private _Codigo As Integer
    Private _Descripcion As String
    Private _Abreviatura As String
    Private _Operacion As Integer
    Private _Coderror As Integer
    Private _Iduser As Integer
    Private _preciocompra As Decimal
    Private _precioventa As Decimal

    Public Property precioventa As Decimal
        Get
            Return _precioventa
        End Get
        Set(value As Decimal)
            _precioventa = value
        End Set
    End Property
    Public Property preciocompra As Decimal
        Get
            Return _preciocompra
        End Get
        Set(value As Decimal)
            _preciocompra = value
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
