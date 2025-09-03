Public Class coControlincidencia
    Private _idPersona As Integer
    Private _idEncargado As Integer
    Private _TipoDeAccidente As String
    Private _NombreAseguradora As String
    Private _NombrePersona As String
    Private _DNI As String
    Private _Edad As Integer
    Private _Puesto As String
    Private _Sexo As String
    Private _Turno As String
    Private _Area As String
    Private _LugarExacto As String
    Private _HorasTrabajadas As TimeSpan
    Private _FechaOcurrencia As DateTime
    Private _FechaInicioInv As DateTime
    Private _Gravedad As String
    Private _Grado As String
    Private _NumDias As Integer
    Private _NumPersonas As Integer
    Private _Descripcion As String
    Private _DescripcionClaramente As String
    Private _Probabilidad As String
    Private _Consecuencia As String
    Private _FechaDesde As Date
    Private _FechaHasta As Date
    Private _NombreEncargado As String
    Private _Codigo As Integer
    Private _Coderror As Integer
    Private _Archivo As Byte()
    Private _IdUsuarioLogueado As Integer
    Private _cargo As String


    Public Property cargo As String
        Get
            Return _cargo
        End Get
        Set(value As String)
            _cargo = value
        End Set
    End Property
    Public Property IdUsuarioLogueado As Integer
        Get
            Return _IdUsuarioLogueado
        End Get
        Set(value As Integer)
            _IdUsuarioLogueado = value
        End Set
    End Property
    Public Property TotalTrabajadores As Integer
    Public Property NoAsegurados As Integer
    Public Property Asegurados As Integer

    Private _Causas As New List(Of String)()
    Public Property Causas As List(Of String)
        Get
            Return _Causas
        End Get
        Set(value As List(Of String))
            _Causas = value
        End Set
    End Property
    Public Property Archivo As Byte()
        Get
            Return _Archivo
        End Get
        Set(value As Byte())
            _Archivo = value
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
    Public Property FechaDesde As Date
        Get
            Return _FechaDesde
        End Get
        Set(value As Date)
            _FechaDesde = value
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

    Public Property FechaHasta As Date
        Get
            Return _FechaHasta
        End Get
        Set(value As Date)
            _FechaHasta = value
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
    Public Property IdEncargado As Integer
        Get
            Return _idEncargado
        End Get
        Set(value As Integer)
            _idEncargado = value
        End Set
    End Property
    Public Property TipoDeAccidente As String
        Get
            Return _TipoDeAccidente
        End Get
        Set(value As String)
            _TipoDeAccidente = value
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
    Public Property Turno As String
        Get
            Return _Turno
        End Get
        Set(value As String)
            _Turno = value
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
    Public Property LugarExacto As String
        Get
            Return _LugarExacto
        End Get
        Set(value As String)
            _LugarExacto = value
        End Set
    End Property
    Public Property HorasTrabajadas As TimeSpan
        Get
            Return _HorasTrabajadas
        End Get
        Set(value As TimeSpan)
            _HorasTrabajadas = value
        End Set
    End Property
    Public Property FechaOcurrencia As DateTime
        Get
            Return _FechaOcurrencia
        End Get
        Set(value As DateTime)
            _FechaOcurrencia = value
        End Set
    End Property
    Public Property FechaInicioInv As DateTime
        Get
            Return _FechaInicioInv
        End Get
        Set(value As DateTime)
            _FechaInicioInv = value
        End Set
    End Property
    Public Property Gravedad As String
        Get
            Return _Gravedad
        End Get
        Set(value As String)
            _Gravedad = value
        End Set
    End Property
    Public Property Grado As String
        Get
            Return _Grado
        End Get
        Set(value As String)
            _Grado = value
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
    Public Property NumPersonas As Integer
        Get
            Return _NumPersonas
        End Get
        Set(value As Integer)
            _NumPersonas = value
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
    Public Property DescripcionClaramente As String
        Get
            Return _DescripcionClaramente
        End Get
        Set(value As String)
            _DescripcionClaramente = value
        End Set
    End Property
    Public Property Probabilidad As String
        Get
            Return _Probabilidad
        End Get
        Set(value As String)
            _Probabilidad = value
        End Set
    End Property
    Public Property Consecuencia As String
        Get
            Return _Consecuencia
        End Get
        Set(value As String)
            _Consecuencia = value
        End Set
    End Property
    Public Property NombreEncargado As String
        Get
            Return _NombreEncargado
        End Get
        Set(value As String)
            _NombreEncargado = value
        End Set
    End Property
    Public Sub SetArchivo(pdfData As Byte())
        Me.Archivo = pdfData
    End Sub
End Class
