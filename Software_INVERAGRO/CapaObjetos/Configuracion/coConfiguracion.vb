Public Class coConfiguracion
    Private _IdConfiguracion As Integer
    Private _Valor As String
    Private _Imagen As Byte()
    Private _Texto As String
    Private _Coderror As Integer

    Public Property IdConfiguracion As Integer
        Get
            Return _IdConfiguracion
        End Get
        Set(value As Integer)
            _IdConfiguracion = value
        End Set
    End Property

    Public Property Valor As String
        Get
            Return _Valor
        End Get
        Set(value As String)
            _Valor = value
        End Set
    End Property

    Public Property Imagen As Byte()
        Get
            Return _Imagen
        End Get
        Set(value As Byte())
            _Imagen = value
        End Set
    End Property

    Public Property Texto As String
        Get
            Return _Texto
        End Get
        Set(value As String)
            _Texto = value
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
