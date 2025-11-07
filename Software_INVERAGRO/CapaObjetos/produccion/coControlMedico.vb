Public Class coControlMedico
    Private _Operacion As Integer
    Private _Codigo As Integer
    Private _EdadLote As Integer
    Private _ModoAplicacion As String
    Private _FechaControl As Date
    Private _FechaInicio As Date
    Private _FechaFin As Nullable(Of Date)
    Private _IdArea As Integer
    Private _Observacion As String
    Private _IdUsuario As Integer
    Private _ListaDestinadoCerdoLote As String
    Private _ListaMedicamentoEnfermedad As String
    Private _IdPlantel As Integer
    Private _IdControlMedico As Integer
    Private _IdControlFicha As Integer
    Private _MotivoAnulacion As String
    Private _IdLote As Integer
    Private _IdEnfermedad As Integer
    Private _IdMedicamento As Integer
    Private _Tipo As String
    Private _Coderror As Integer
    Private _Estado As String
    Private _IdUbicacion As Integer
    Private _Archivo As Byte()
    Private _CostoPrograma As Decimal
    Private _Anio As Integer
    Private _Afectados As Integer
    Private _IdGalpon As Integer
    Private _Duracion As Integer
    Private _CodVacuna As String
    Private _FVencimientoVacuna As Date
    Private _NumAplicacion As Integer
    Private _Via As String
    Private _Dosis As Decimal
    Private _CantDiaria As Decimal
    Private _CantAnimales As Integer
    Private _IdConversion As Integer
    Private _CantidadOrigen As Integer
    Private _NumSemana As Integer
    Private _MlAnimal As Decimal
    Private _GestacionIndividual As Integer
    Private _NombreVacunaComercial As String

    Public Property Operacion As Integer
        Get
            Return _Operacion
        End Get
        Set(value As Integer)
            _Operacion = value
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
    Public Property ModoAplicacion As String
        Get
            Return _ModoAplicacion
        End Get
        Set(value As String)
            _ModoAplicacion = value
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

    Public Property FechaFin As Nullable(Of Date)
        Get
            Return _FechaFin
        End Get
        Set(value As Nullable(Of Date))
            _FechaFin = value
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

    Public Property IdUsuario As Integer
        Get
            Return _IdUsuario
        End Get
        Set(value As Integer)
            _IdUsuario = value
        End Set
    End Property

    Public Property ListaDestinadoCerdoLote As String
        Get
            Return _ListaDestinadoCerdoLote
        End Get
        Set(value As String)
            _ListaDestinadoCerdoLote = value
        End Set
    End Property

    Public Property ListaMedicamentoEnfermedad As String
        Get
            Return _ListaMedicamentoEnfermedad
        End Get
        Set(value As String)
            _ListaMedicamentoEnfermedad = value
        End Set
    End Property

    Public Property IdPlantel As Integer
        Get
            Return _IdPlantel
        End Get
        Set(value As Integer)
            _IdPlantel = value
        End Set
    End Property

    Public Property IdControlMedico As Integer
        Get
            Return _IdControlMedico
        End Get
        Set(value As Integer)
            _IdControlMedico = value
        End Set
    End Property

    Public Property IdLote As Integer
        Get
            Return _IdLote
        End Get
        Set(value As Integer)
            _IdLote = value
        End Set
    End Property
    Public Property IdMedicamento As Integer
        Get
            Return _IdMedicamento
        End Get
        Set(value As Integer)
            _IdMedicamento = value
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

    Public Property Coderror As Integer
        Get
            Return _Coderror
        End Get
        Set(value As Integer)
            _Coderror = value
        End Set
    End Property

    Public Property IdControlFicha As Integer
        Get
            Return _IdControlFicha
        End Get
        Set(value As Integer)
            _IdControlFicha = value
        End Set
    End Property

    Public Property MotivoAnulacion As String
        Get
            Return _MotivoAnulacion
        End Get
        Set(value As String)
            _MotivoAnulacion = value
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

    Public Property IdEnfermedad As Integer
        Get
            Return _IdEnfermedad
        End Get
        Set(value As Integer)
            _IdEnfermedad = value
        End Set
    End Property

    Public Property CostoPrograma As Decimal
        Get
            Return _CostoPrograma
        End Get
        Set(value As Decimal)
            _CostoPrograma = value
        End Set
    End Property

    Public Property FechaControl As Date
        Get
            Return _FechaControl
        End Get
        Set(value As Date)
            _FechaControl = value
        End Set
    End Property

    Public Property IdArea As Integer
        Get
            Return _IdArea
        End Get
        Set(value As Integer)
            _IdArea = value
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

    Public Property Archivo As Byte()
        Get
            Return _Archivo
        End Get
        Set(value As Byte())
            _Archivo = value
        End Set
    End Property

    Public Sub SetArchivo(pdfData As Byte())
        Me.Archivo = pdfData
    End Sub

    Public Property Anio As Integer
        Get
            Return _Anio
        End Get
        Set(value As Integer)
            _Anio = value
        End Set
    End Property

    Public Property Afectados As Integer
        Get
            Return _Afectados
        End Get
        Set(value As Integer)
            _Afectados = value
        End Set
    End Property

    Public Property IdGalpon As Integer
        Get
            Return _IdGalpon
        End Get
        Set(value As Integer)
            _IdGalpon = value
        End Set
    End Property

    Public Property Duracion As Integer
        Get
            Return _Duracion
        End Get
        Set(value As Integer)
            _Duracion = value
        End Set
    End Property

    Public Property CodVacuna As String
        Get
            Return _CodVacuna
        End Get
        Set(value As String)
            _CodVacuna = value
        End Set
    End Property

    Public Property FVencimientoVacuna As Date
        Get
            Return _FVencimientoVacuna
        End Get
        Set(value As Date)
            _FVencimientoVacuna = value
        End Set
    End Property

    Public Property NumAplicacion As Integer
        Get
            Return _NumAplicacion
        End Get
        Set(value As Integer)
            _NumAplicacion = value
        End Set
    End Property

    Public Property Via As String
        Get
            Return _Via
        End Get
        Set(value As String)
            _Via = value
        End Set
    End Property

    Public Property Dosis As Decimal
        Get
            Return _Dosis
        End Get
        Set(value As Decimal)
            _Dosis = value
        End Set
    End Property

    Public Property CantDiaria As Decimal
        Get
            Return _CantDiaria
        End Get
        Set(value As Decimal)
            _CantDiaria = value
        End Set
    End Property

    Public Property CantAnimales As Integer
        Get
            Return _CantAnimales
        End Get
        Set(value As Integer)
            _CantAnimales = value
        End Set
    End Property

    Public Property IdConversion As Integer
        Get
            Return _IdConversion
        End Get
        Set(value As Integer)
            _IdConversion = value
        End Set
    End Property

    Public Property CantidadOrigen As Integer
        Get
            Return _CantidadOrigen
        End Get
        Set(value As Integer)
            _CantidadOrigen = value
        End Set
    End Property

    Public Property NumSemana As Integer
        Get
            Return _NumSemana
        End Get
        Set(value As Integer)
            _NumSemana = value
        End Set
    End Property

    Public Property MlAnimal As Decimal
        Get
            Return _MlAnimal
        End Get
        Set(value As Decimal)
            _MlAnimal = value
        End Set
    End Property

    Public Property GestacionIndividual As Integer
        Get
            Return _GestacionIndividual
        End Get
        Set(value As Integer)
            _GestacionIndividual = value
        End Set
    End Property

    Public Property NombreVacunaComercial As String
        Get
            Return _NombreVacunaComercial
        End Get
        Set(value As String)
            _NombreVacunaComercial = value
        End Set
    End Property
End Class
