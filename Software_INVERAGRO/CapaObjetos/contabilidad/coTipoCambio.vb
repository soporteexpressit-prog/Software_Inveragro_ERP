Public Class coTipoCambio
    Private _Codigo As Integer
    Private _Fecha As Nullable(Of Date)
    Private _PrecioCompra As Double
    Private _PrecioVenta As Double
    Private _IdMoneda As Nullable(Of Integer)
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
    Public Property Fecha As Nullable(Of Date)
        Get
            Return _Fecha
        End Get
        Set(value As Nullable(Of Date))
            _Fecha = value
        End Set
    End Property

    Public Property PrecioCompra As Double
        Get
            Return _PrecioCompra
        End Get
        Set(value As Double)
            _PrecioCompra = value
        End Set
    End Property

    Public Property PrecioVenta As Double
        Get
            Return _PrecioVenta
        End Get
        Set(value As Double)
            _PrecioVenta = value
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
