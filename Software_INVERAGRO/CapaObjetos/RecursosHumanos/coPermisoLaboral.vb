Public Class coPermisoLaboral
    Private _idPersona As Integer
    Private _idpermisolaboral As Integer
    Private _TipoPermiso As Integer
    Private _idauditoria As Integer
    Private _adelantoDias As Integer
    Private _operacion As String
    Private _NombreAseguradora As String
    Private _NombrePersona As String
    Private _DNI As String
    Private _Edad As Integer
    Private _Puesto As String
    Private _Sexo As String
    Private _NumDias As Integer
    Private _Descripcion As String
    Private _Area As String
    Private _Cargo As String
    Private _FechaInicio As Date
    Private _FechaFin As Date
    Private _Codigo As Integer
    Private _Coderror As Integer
    Private _ventaV As String
    Private _DiasPendientes As Integer
    Private _docPaternidad As Byte()
    Public Property ventaV As String
        Get
            Return _ventaV
        End Get
        Set(value As String)
            _ventaV = value
        End Set
    End Property
    Public Property idpermisolaboral As Integer
        Get
            Return _idpermisolaboral
        End Get
        Set(value As Integer)
            _idpermisolaboral = value
        End Set
    End Property
    Public Property DiasPendientes As Integer
        Get
            Return _DiasPendientes
        End Get
        Set(value As Integer)
            _DiasPendientes = value
        End Set
    End Property
    Public Property adelantoDias As Integer
        Get
            Return _adelantoDias
        End Get
        Set(value As Integer)
            _adelantoDias = value
        End Set
    End Property
    Public Property idauditoria As Integer
        Get
            Return _idauditoria
        End Get
        Set(value As Integer)
            _idauditoria = value
        End Set
    End Property
    Public Property operacion As Integer
        Get
            Return _operacion
        End Get
        Set(value As Integer)
            _operacion = value
        End Set
    End Property
    Public Property Area As String
        Get
            Return _Area
        End Get
        Set(value As String)
            _Area = value
        End Set
    End Property
    Public Property Cargo As String
        Get
            Return _Cargo
        End Get
        Set(value As String)
            _Cargo = value
        End Set
    End Property
    Public Property docPaternidad As Byte()
        Get
            Return _docPaternidad
        End Get
        Set(value As Byte())
            _docPaternidad = value
        End Set
    End Property
    Public Sub SetdocPaternidad(pdfData As Byte())
        Me.docPaternidad = pdfData
    End Sub
    Public Property Coderror As Integer
        Get
            Return _Coderror
        End Get
        Set(value As Integer)
            _Coderror = value
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

    Public Property codigo As Integer
        Get
            Return _Codigo
        End Get
        Set(value As Integer)
            _Codigo = value
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
    Public Property IdPersona As Integer
        Get
            Return _idPersona
        End Get
        Set(value As Integer)
            _idPersona = value
        End Set
    End Property
    Public Property TipoPermiso As Integer
        Get
            Return _TipoPermiso
        End Get
        Set(value As Integer)
            _TipoPermiso = value
        End Set
    End Property
    Public Property NombreAseguradora As String
        Get
            Return _NombreAseguradora
        End Get
        Set(value As String)
            _NombreAseguradora = value
        End Set
    End Property
    Public Property NombrePersona As String
        Get
            Return _NombrePersona
        End Get
        Set(value As String)
            _NombrePersona = value
        End Set
    End Property
    Public Property DNI As String
        Get
            Return _DNI
        End Get
        Set(value As String)
            _DNI = value
        End Set
    End Property
    Public Property Edad As Integer
        Get
            Return _Edad
        End Get
        Set(value As Integer)
            _Edad = value
        End Set
    End Property
    Public Property Puesto As String
        Get
            Return _Puesto
        End Get
        Set(value As String)
            _Puesto = value
        End Set
    End Property
    Public Property Sexo As String
        Get
            Return _Sexo
        End Get
        Set(value As String)
            _Sexo = value
        End Set
    End Property
    Public Property NumDias As Integer
        Get
            Return _NumDias
        End Get
        Set(value As Integer)
            _NumDias = value
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
End Class
