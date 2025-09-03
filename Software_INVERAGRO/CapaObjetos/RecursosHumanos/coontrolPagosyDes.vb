Public Class coControlPagosyDes
    Private _NombreConcepto As String
    Private _TipoConcepto As String
    Private _tiposueldo As String
    Private _estado As String
    Private _fechavacacion As String
    Private _FechaInicio As Date
    Private _FechaFin As Date
    Private _idPersona As Integer
    Private _IdUbicacion As Integer
    Private _diasvendidos As Integer
    Private _Fecha As DateTime
    Private _Salario As Decimal
    Private _AsignacionFamiliar As Decimal
    Private _IngresoBasico As Decimal
    Private _CostoDia As Decimal
    Private _CostoPorHoraConAsigFam As Decimal
    Private _CostoPorHoraSinAsigFam As Decimal
    Private _importevacacionesvendidas As Double
    Private _DiasAsistidos As Integer
    Private _DiasNoAsistidos As Integer
    Private _TotalHorasTrabajadas As Decimal
    Private _Periodo As String
    Private _DiasFeriados As Integer
    Private _DiasDomingoDescanso As Integer
    Private _frecuenciapago As Integer
    Private _Extrabono As Decimal
    Private _valorspdec As Decimal
    Private _valorsp As Decimal
    Private _Descripcionsp As String
    Private _Descripcion As String
    Private _Monto As Double
    Private _TipoQuincena As Integer
    Private _Mes As Integer?
    Private _Anio As Integer
    Private _Coderror As Integer
    Private _Codigo As Integer
    Private _Operacion As Integer
    Private _Iduser As Integer
    Private _Importe As Double
    Private _montograti As Double
    Private _MontoCts As Double
    Private _IdConceptoSueldo As Integer
    Private _iddetalleconcepto As Integer
    Private _idregimenlaboral As Integer
    Private _TipoSemana As Integer
    Private _idsegurosocial As Integer
    Private _numdiasvacaciones As Integer
    Private _idregimenp As Integer
    Private _idpago As Integer
    Private _porcentaje As Double
    Private _bonoagrario As Double
    Private _horasmarrana As Double
    Private _diapermisomedico As Integer
    Private _essalud As Double
    Private _montoeventual As Double
    Private _valorhoraextra As Double
    Private _salariobase As Double
    Private _costohorasmarrana As Double
    Private _validarcuenta As Integer
    Private _diasdescanso As Integer
    Private _ultimoDiaMarcacion As Integer
    Private _diasvacaciones As Integer
    Private _Nfetrabajado As Integer
    Private _Nfenotrabajado As Integer
    Private _observacion As String
    Private _diasdescansoeti As String
    Private _ListaIdsPago As String

    Public Property ListaIdsPago As String
        Get
            Return _ListaIdsPago
        End Get
        Set(value As String)
            _ListaIdsPago = value
        End Set
    End Property
    Public Property diasdescansoeti As String
        Get
            Return _diasdescansoeti
        End Get
        Set(value As String)
            _diasdescansoeti = value
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
    Public Property diasvendidos As Integer
        Get
            Return _diasvendidos
        End Get
        Set(value As Integer)
            _diasvendidos = value
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
    Public Property diapermisomedico As Integer
        Get
            Return _diapermisomedico
        End Get
        Set(value As Integer)
            _diapermisomedico = value
        End Set
    End Property
    Public Property montograti As Double
        Get
            Return _montograti
        End Get
        Set(value As Double)
            _montograti = value
        End Set
    End Property
    Public Property MontoCts As Double
        Get
            Return _MontoCts
        End Get
        Set(value As Double)
            _MontoCts = value
        End Set
    End Property
    Public Property costohorasmarrana As Double
        Get
            Return _costohorasmarrana
        End Get
        Set(value As Double)
            _costohorasmarrana = value
        End Set
    End Property
    Public Property importevacacionesvendidas As Double
        Get
            Return _importevacacionesvendidas
        End Get
        Set(value As Double)
            _importevacacionesvendidas = value
        End Set
    End Property
    Public Property horasmarrana As Double
        Get
            Return _horasmarrana
        End Get
        Set(value As Double)
            _horasmarrana = value
        End Set
    End Property
    Public Property Nfetrabajado As Integer
        Get
            Return _Nfetrabajado
        End Get
        Set(value As Integer)
            _Nfetrabajado = value
        End Set
    End Property
    Public Property Nfenotrabajado As Integer
        Get
            Return _Nfenotrabajado
        End Get
        Set(value As Integer)
            _Nfenotrabajado = value
        End Set
    End Property
    Public Property validarcuenta As Integer
        Get
            Return _validarcuenta
        End Get
        Set(value As Integer)
            _validarcuenta = value
        End Set
    End Property
    Public Property diasvacaciones As Integer
        Get
            Return _diasvacaciones
        End Get
        Set(value As Integer)
            _diasvacaciones = value
        End Set
    End Property

    Public Property ultimoDiaMarcacion As Integer
        Get
            Return _ultimoDiaMarcacion
        End Get
        Set(value As Integer)
            _ultimoDiaMarcacion = value
        End Set
    End Property
    Public Property diasdescanso As Integer
        Get
            Return _diasdescanso
        End Get
        Set(value As Integer)
            _diasdescanso = value
        End Set
    End Property

    Public Property salariobase As Double
        Get
            Return _salariobase
        End Get
        Set(value As Double)
            _salariobase = value
        End Set
    End Property
    Public Property valorhoraextra As Double
        Get
            Return _valorhoraextra
        End Get
        Set(value As Double)
            _valorhoraextra = value
        End Set
    End Property
    Public Property essalud As Double
        Get
            Return _essalud
        End Get
        Set(value As Double)
            _essalud = value
        End Set
    End Property
    Public Property fechavacacion As String
        Get
            Return _fechavacacion
        End Get
        Set(value As String)
            _fechavacacion = value
        End Set
    End Property
    Public Property montoeventual As Double
        Get
            Return _montoeventual
        End Get
        Set(value As Double)
            _montoeventual = value
        End Set
    End Property
    Public Property bonoagrario As Double
        Get
            Return _bonoagrario
        End Get
        Set(value As Double)
            _bonoagrario = value
        End Set
    End Property
    Public Property porcentaje As Double
        Get
            Return _porcentaje
        End Get
        Set(value As Double)
            _porcentaje = value
        End Set
    End Property
    Public Property idpago As Integer
        Get
            Return _idpago
        End Get
        Set(value As Integer)
            _idpago = value
        End Set
    End Property
    Public Property numdiasvacaciones As Integer
        Get
            Return _numdiasvacaciones
        End Get
        Set(value As Integer)
            _numdiasvacaciones = value
        End Set
    End Property
    Public Property frecuenciapago As Integer
        Get
            Return _frecuenciapago
        End Get
        Set(value As Integer)
            _frecuenciapago = value
        End Set
    End Property
    Public Property idregimenlaboral As Integer
        Get
            Return _idregimenlaboral
        End Get
        Set(value As Integer)
            _idregimenlaboral = value
        End Set
    End Property
    Public Property idregimenp As Integer
        Get
            Return _idregimenp
        End Get
        Set(value As Integer)
            _idregimenp = value
        End Set
    End Property
    Public Property idsegurosocial As Integer
        Get
            Return _idsegurosocial
        End Get
        Set(value As Integer)
            _idsegurosocial = value
        End Set
    End Property
    Public Property TipoSemana As Integer
        Get
            Return _TipoSemana
        End Get
        Set(value As Integer)
            _TipoSemana = value
        End Set
    End Property
    Public Property iddetalleconcepto As Integer
        Get
            Return _iddetalleconcepto
        End Get
        Set(value As Integer)
            _iddetalleconcepto = value
        End Set
    End Property
    Public Property IdConceptoSueldo As Integer
        Get
            Return _IdConceptoSueldo
        End Get
        Set(value As Integer)
            _IdConceptoSueldo = value
        End Set
    End Property
    Public Property Importe As Double
        Get
            Return _Importe
        End Get
        Set(value As Double)
            _Importe = value
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
    Public Property Operacion As Integer
        Get
            Return _Operacion
        End Get
        Set(value As Integer)
            _Operacion = value
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
    Public Property tiposueldo As String
        Get
            Return _tiposueldo
        End Get
        Set(value As String)
            _tiposueldo = value
        End Set
    End Property
    Public Property estado As String
        Get
            Return _estado
        End Get
        Set(value As String)
            _estado = value
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
    Public Property Mes As Integer?
        Get
            Return _Mes
        End Get
        Set(value As Integer?)
            _Mes = value
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
    Public Property Descripcionsp As String
        Get
            Return _Descripcionsp
        End Get
        Set(value As String)
            _Descripcionsp = value
        End Set
    End Property
    Public Property valorspdec As Decimal
        Get
            Return _valorspdec
        End Get
        Set(value As Decimal)
            _valorspdec = value
        End Set
    End Property
    Public Property valorsp As Decimal
        Get
            Return _valorsp
        End Get
        Set(value As Decimal)
            _valorsp = value
        End Set
    End Property
    Public Property DiasDomingoDescanso As Integer
        Get
            Return _DiasDomingoDescanso
        End Get
        Set(value As Integer)
            _DiasDomingoDescanso = value
        End Set
    End Property
    Public Property DiasFeriados As Integer
        Get
            Return _DiasFeriados
        End Get
        Set(value As Integer)
            _DiasFeriados = value
        End Set
    End Property
    Public Property DiasAsistidos As Integer
        Get
            Return _DiasAsistidos
        End Get
        Set(value As Integer)
            _DiasAsistidos = value
        End Set
    End Property

    Public Property DiasNoAsistidos As Integer
        Get
            Return _DiasNoAsistidos
        End Get
        Set(value As Integer)
            _DiasNoAsistidos = value
        End Set
    End Property

    Public Property TotalHorasTrabajadas As Decimal
        Get
            Return _TotalHorasTrabajadas
        End Get
        Set(value As Decimal)
            _TotalHorasTrabajadas = value
        End Set
    End Property

    Public Property Periodo As String
        Get
            Return _Periodo
        End Get
        Set(value As String)
            _Periodo = value
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

    Public Property Fecha As DateTime
        Get
            Return New DateTime(_Fecha.Year, _Fecha.Month, 1)
        End Get
        Set(value As DateTime)
            _Fecha = New DateTime(value.Year, value.Month, 1)
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

    Public Property Salario As Decimal
        Get
            Return _Salario
        End Get
        Set(value As Decimal)
            _Salario = value
        End Set
    End Property
    Public Property Extrabono As Decimal
        Get
            Return _Extrabono
        End Get
        Set(value As Decimal)
            _Extrabono = value
        End Set
    End Property
    Public Property AsignacionFamiliar As Decimal
        Get
            Return _AsignacionFamiliar
        End Get
        Set(value As Decimal)
            _AsignacionFamiliar = value
        End Set
    End Property

    Public Property IngresoBasico As Decimal
        Get
            Return _IngresoBasico
        End Get
        Set(value As Decimal)
            _IngresoBasico = value
        End Set
    End Property

    Public Property CostoDia As Decimal
        Get
            Return _CostoDia
        End Get
        Set(value As Decimal)
            _CostoDia = value
        End Set
    End Property

    Public Property CostoPorHoraConAsigFam As Decimal
        Get
            Return _CostoPorHoraConAsigFam
        End Get
        Set(value As Decimal)
            _CostoPorHoraConAsigFam = value
        End Set
    End Property

    Public Property CostoPorHoraSinAsigFam As Decimal
        Get
            Return _CostoPorHoraSinAsigFam
        End Get
        Set(value As Decimal)
            _CostoPorHoraSinAsigFam = value
        End Set
    End Property
    Public Property NombreConcepto As String
        Get
            Return _NombreConcepto
        End Get
        Set(value As String)
            _NombreConcepto = value
        End Set
    End Property
    Public Property TipoConcepto As String
        Get
            Return _TipoConcepto
        End Get
        Set(value As String)
            _TipoConcepto = value
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

    Public Property Monto As Double
        Get
            Return _Monto
        End Get
        Set(value As Double)
            _Monto = value
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
End Class
