Public Class coEnfermedad
    Private _Codigo As Integer
    Private _Nombre As String
    Private _Descripcion As String
    Private _TipoNivel As String
    Private _ViaAplicacion As String
    Private _Operacion As Integer
    Private _Lista_Detalle_Tratamiento As String
    Private _Dosis As String
    Private _Dias As String
    Private _Frecuencia As String
    Private _Estado As String
    Private _Observacion As String
    Private _EdadLote As Integer
    Private _IdUbicacion As Integer
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
    Public Property Nombre As String
        Get
            Return _Nombre
        End Get
        Set(value As String)
            _Nombre = value
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

    Public Property TipoNivel As String
        Get
            Return _TipoNivel
        End Get
        Set(value As String)
            _TipoNivel = value
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

    Public Property ViaAplicacion As String
        Get
            Return _ViaAplicacion
        End Get
        Set(value As String)
            _ViaAplicacion = value
        End Set
    End Property
    Public Property Lista_Detalle_Tratamiento As String
        Get
            Return _Lista_Detalle_Tratamiento
        End Get
        Set(value As String)
            _Lista_Detalle_Tratamiento = value
        End Set
    End Property
    Public Property Dosis As String
        Get
            Return _Dosis
        End Get
        Set(value As String)
            _Dosis = value
        End Set
    End Property
    Public Property Dias As String
        Get
            Return _Dias
        End Get
        Set(value As String)
            _Dias = value
        End Set
    End Property
    Public Property Frecuencia As String
        Get
            Return _Frecuencia
        End Get
        Set(value As String)
            _Frecuencia = value
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
    Public Property IdUbicacion As Integer
        Get
            Return _IdUbicacion
        End Get
        Set(value As Integer)
            _IdUbicacion = value
        End Set
    End Property

    Public Property Observacion As String
        Get
            Return _Observacion
        End Get
        Set(value As String)
            _Observacion = value
        End Set
    End Property

    Public Property EdadLote As Integer
        Get
            Return _EdadLote
        End Get
        Set(value As Integer)
            _EdadLote = value
        End Set
    End Property
End Class
