Public Class coControlAsistencia
    Private _UltimoDiaReg As Integer
    Private _idHorario As Integer?
    Private _Lista_Asistencias As String
    Private _Lista_Asistencias_Eventuales As String = Nothing
    Private _UltimoDiaRegEventual As Integer?
    Private _Tipo As String
    Private _Mes As Integer?
    Private _Anio As Integer
    Private _Coderror As Integer

    Private _Datos As String
    Private _NumDocumento As String
    Private _Lista_NumDocumentos As String
    Private _IdUbicacion As Integer
    Private _TipoQuincena As Integer
    Private _FechaDesde As Date
    Private _FechaHasta As Date

    Private _Codigo As Integer
    Private _IdUsuario As Integer
    Private _Dia As Integer

    Private _Tipoperiodo As String
    Private _Estado As String
    Private _observacion As String
    Private _FechaInicio As Date
    Private _FechaFin As Date

    Private _TipoTrabajador As String
    Private _DiaInicio As Integer
    Private _DiaFin As Integer

    Public Property idHorario As Integer?
        Get
            Return _idHorario
        End Get
        Set(value As Integer?)
            _idHorario = value
        End Set
    End Property


    Public Property UltimoDiaReg As Integer
        Get
            Return _UltimoDiaReg
        End Get
        Set(value As Integer)
            _UltimoDiaReg = value
        End Set
    End Property

    Public Property Mes As Integer?
        Get
            Return _Mes
        End Get
        Set(value As Integer?)
            _Mes = value
        End Set
    End Property

    Public Property UltimoDiaRegEventual As Integer?
        Get
            Return _UltimoDiaRegEventual
        End Get
        Set(value As Integer?)
            _UltimoDiaRegEventual = value
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

    Public Property CodeError As Integer
        Get
            Return _Coderror
        End Get
        Set(value As Integer)
            _Coderror = value
        End Set
    End Property

    Public Property Lista_Asistencias As String
        Get
            Return _Lista_Asistencias
        End Get
        Set(value As String)
            _Lista_Asistencias = value
        End Set
    End Property
    Public Property observacion As String
        Get
            Return _observacion
        End Get
        Set(value As String)
            _observacion = value
        End Set
    End Property

    Public Property Datos As String
        Get
            Return _Datos
        End Get
        Set(value As String)
            _Datos = value
        End Set
    End Property

    Public Property NumDocumento As String
        Get
            Return _NumDocumento
        End Get
        Set(value As String)
            _NumDocumento = value
        End Set
    End Property

    Public Property Lista_NumDocumentos As String
        Get
            Return _Lista_NumDocumentos
        End Get
        Set(value As String)
            _Lista_NumDocumentos = value
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

    Public Property TipoQuincena As Integer
        Get
            Return _TipoQuincena
        End Get
        Set(value As Integer)
            _TipoQuincena = value
        End Set
    End Property
    Public Property FechaDesde As Date
        Get
            Return _FechaDesde
        End Get
        Set(value As Date)
            _FechaDesde = value
        End Set
    End Property
    Public Property FechaHasta As Date
        Get
            Return _FechaHasta
        End Get
        Set(value As Date)
            _FechaHasta = value
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
    Public Property IdUsuario As Integer
        Get
            Return _IdUsuario
        End Get
        Set(value As Integer)
            _IdUsuario = value
        End Set
    End Property
    Public Property Dia As Integer
        Get
            Return _Dia
        End Get
        Set(value As Integer)
            _Dia = value
        End Set
    End Property
    Public Property Tipo As String
        Get
            Return _Tipo
        End Get
        Set(value As String)
            _Tipo = value
        End Set
    End Property
    Public Property Lista_Asistencias_Eventuales As String
        Get
            Return _Lista_Asistencias_Eventuales
        End Get
        Set(value As String)
            _Lista_Asistencias_Eventuales = value
        End Set
    End Property
    Public Property Tipoperiodo As String
        Get
            Return _Tipoperiodo
        End Get
        Set(value As String)
            _Tipoperiodo = value
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
    Public Property FechaInicio As Date
        Get
            Return _FechaInicio
        End Get
        Set(value As Date)
            _FechaInicio = value
        End Set
    End Property
    Public Property FechaFin As Date
        Get
            Return _FechaFin
        End Get
        Set(value As Date)
            _FechaFin = value
        End Set
    End Property

    Public Property TipoTrabajador As String
        Get
            Return _TipoTrabajador
        End Get
        Set(value As String)
            _TipoTrabajador = value
        End Set
    End Property

    Public Property DiaInicio As Integer
        Get
            Return _DiaInicio
        End Get
        Set(value As Integer)
            _DiaInicio = value
        End Set
    End Property

    Public Property DiaFin As Integer
        Get
            Return _DiaFin
        End Get
        Set(value As Integer)
            _DiaFin = value
        End Set
    End Property
End Class
