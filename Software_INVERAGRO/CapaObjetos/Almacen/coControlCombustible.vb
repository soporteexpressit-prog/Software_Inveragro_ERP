Public Class coControlCombustible
    Private _Fecha_Emision As Date
    Private _Estado_Recepcion As String
    Private _Liquidado As String
    Private _IdUser As Integer
    Private _IdTipoDocumento As Integer
    Private _IdResponsable As Integer
    Private _Lista_Items As String
    Private _Coderror As Integer

    Public Property Fecha_Emision As Date
        Get
            Return _Fecha_Emision
        End Get
        Set(value As Date)
            _Fecha_Emision = value
        End Set
    End Property

    Public Property Estado_Recepcion As String
        Get
            Return _Estado_Recepcion
        End Get
        Set(value As String)
            _Estado_Recepcion = value
        End Set
    End Property

    Public Property Liquidado As String
        Get
            Return _Liquidado
        End Get
        Set(value As String)
            _Liquidado = value
        End Set
    End Property

    Public Property IdUser As Integer
        Get
            Return _IdUser
        End Get
        Set(value As Integer)
            _IdUser = value
        End Set
    End Property

    Public Property IdTipoDocumento As Integer
        Get
            Return _IdTipoDocumento
        End Get
        Set(value As Integer)
            _IdTipoDocumento = value
        End Set
    End Property

    Public Property IdResponsable As Integer
        Get
            Return _IdResponsable
        End Get
        Set(value As Integer)
            _IdResponsable = value
        End Set
    End Property

    Public Property Lista_Items As String
        Get
            Return _Lista_Items
        End Get
        Set(value As String)
            _Lista_Items = value
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
