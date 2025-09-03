Public Class coControlPremixero
    Private _IdPremixero As Integer
    Private _IdAsignacionPremixero As Integer
    Private _Descripcion As String
    Private _EstadoPremixero As String
    Private _EstadoAsignacionPremixero As String
    Private _IdTrabajador As Integer
    Private _IdUsuario As Integer
    Private _Operacion As Integer
    Private _Coderror As Integer

    Public Property IdPremixero As Integer
        Get
            Return _IdPremixero
        End Get
        Set(value As Integer)
            _IdPremixero = value
        End Set
    End Property

    Public Property IdAsignacionPremixero As Integer
        Get
            Return _IdAsignacionPremixero
        End Get
        Set(value As Integer)
            _IdAsignacionPremixero = value
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

    Public Property EstadoPremixero As String
        Get
            Return _EstadoPremixero
        End Get
        Set(value As String)
            _EstadoPremixero = value
        End Set
    End Property

    Public Property EstadoAsignacionPremixero As String
        Get
            Return _EstadoAsignacionPremixero
        End Get
        Set(value As String)
            _EstadoAsignacionPremixero = value
        End Set
    End Property

    Public Property IdTrabajador As Integer
        Get
            Return _IdTrabajador
        End Get
        Set(value As Integer)
            _IdTrabajador = value
        End Set
    End Property

    Public Property IdUsuario As Integer
        Get
            Return _IdUsuario
        End Get
        Set(value As Integer)
            _IdUsuario = value
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
