Public Class coTrabajador
    Private _Operacion As Integer
    Private _idPersona As Integer
    Private _esedicioncontrato As Integer
    Private _Tipo As String
    Private _NumDocumento As String
    Private _Datos As String
    Private _apaterno As String
    Private _amaterno As String
    Private _Sexo As String
    Private _EstadoCivil As String
    Private _FNacimiento As DateTime
    Private _Direccion As String
    Private _Celular As String
    Private _Correo As String
    Private _Usuario As String
    Private _Clave As String
    Private _IdUsuario As String
    Private _FRegistro As Date
    Private _Estado As String
    Private _ArchivoFoto As Byte()
    Private _ArchivoFirma As Byte()
    Private _IdGiroEmpresa As Integer
    Private _IdTipoDocIdentidad As Integer
    Private _Coderror As Integer
    Private _FechaDesde As Nullable(Of Date)
    Private _FechaHasta As Nullable(Of Date)
    Private _IdTipoSeguroPlanilla As Integer
    Private _asignacionfamiliar As String
    Private _IdDistrito As Integer
    Private _Categoria As String
    Private _idCargosistena As Integer
    Private _Fecha As DateTime
    Private _TipoPagoextra As Integer
    Private _Personaconfianza As Integer
    Private _CUSSP As String
    Private _FechaIngreso As DateTime
    Private _FechaFinContrato As DateTime
    Private _FechaSeguroPrivado As DateTime
    Private _FechaSeguroSocial As DateTime
    Private _FechaRegPensionario As DateTime
    Private _idSeguroSocial As Integer
    Private _idRegimenPnnsionario As Integer
    Private _idRegimenLaboral As Integer
    Private _FechaBaja As DateTime
    Private _Remuneracion As Double
    Private _NroCuenta As String
    Private _Lista_Cods_Sunat As String
    Private _IdCargo As Integer
    Private _idFormadePago As Integer
    Private _idFormadePagoextra As Integer
    Private _idBanco As String
    Private _ListaNegra As Boolean
    Private _IdUbicacion As Integer
    Private _IdArea As Integer
    Private _Lista_Hijos As String
    Private _NroCuentaextra As String
    Private _idBancoextra As Integer
    Private _ExtraBono As Double
    Private _Tipocuenta As String
    Private _Tipocuentaextra As String
    Private _Idtiporegistrosunat As Integer
    Private _IdCargoocupacional As Integer
    Private _lista_vinculofamiliar As String
    Private _dnihijo As String
    Private _idcontrato As Integer
    Private _idubicacionpersona As Integer
    Private _idhijo As Integer
    Private _EstadoContrato As String
    Private _sinpagoextra As String
    Private _idmotivobajatrabajador As Integer
    Private _idfrecuenciadepago As Integer
    Private _Dias As Integer
    Private _sibono As Integer
    Public Property Mensaje As String
    Public Property sibono As Integer
        Get
            Return _sibono
        End Get
        Set(value As Integer)
            _sibono = value
        End Set
    End Property
    Public Property idfrecuenciadepago As Integer
        Get
            Return _idfrecuenciadepago
        End Get
        Set(value As Integer)
            _idfrecuenciadepago = value
        End Set
    End Property
    Public Property idmotivobajatrabajador As Integer
        Get
            Return _idmotivobajatrabajador
        End Get
        Set(value As Integer)
            _idmotivobajatrabajador = value
        End Set
    End Property
    Public Property EstadoContrato As String
        Get
            Return _EstadoContrato
        End Get
        Set(value As String)
            _EstadoContrato = value
        End Set
    End Property
    Public Property sinpagoextra As String
        Get
            Return _sinpagoextra
        End Get
        Set(value As String)
            _sinpagoextra = value
        End Set
    End Property
    Public Property idhijo As Integer
        Get
            Return _idhijo
        End Get
        Set(value As Integer)
            _idhijo = value
        End Set
    End Property
    Public Property idubicacionpersona As Integer
        Get
            Return _idubicacionpersona
        End Get
        Set(value As Integer)
            _idubicacionpersona = value
        End Set
    End Property
    Public Property idcontrato As Integer
        Get
            Return _idcontrato
        End Get
        Set(value As Integer)
            _idcontrato = value
        End Set
    End Property
    Public Property esedicioncontrato As Integer
        Get
            Return _esedicioncontrato
        End Get
        Set(value As Integer)
            _esedicioncontrato = value
        End Set
    End Property
    Public Property idRegimenLaboral As Integer
        Get
            Return _idRegimenLaboral
        End Get
        Set(value As Integer)
            _idRegimenLaboral = value
        End Set
    End Property
    Public Property idRegimenPnnsionario As Integer
        Get
            Return _idRegimenPnnsionario
        End Get
        Set(value As Integer)
            _idRegimenPnnsionario = value
        End Set
    End Property

    Public Property idSeguroSocial As Integer
        Get
            Return _idSeguroSocial
        End Get
        Set(value As Integer)
            _idSeguroSocial = value
        End Set
    End Property
    Public Property dnihijo As String
        Get
            Return _dnihijo
        End Get
        Set(value As String)
            _dnihijo = value
        End Set
    End Property
    Public Property idFormadePagoextra As Integer
        Get
            Return _idFormadePagoextra
        End Get
        Set(value As Integer)
            _idFormadePagoextra = value
        End Set
    End Property
    Public Property lista_vinculofamiliar As String
        Get
            Return _lista_vinculofamiliar
        End Get
        Set(value As String)
            _lista_vinculofamiliar = value
        End Set
    End Property
    Public Property IdCargoocupacional As Integer
        Get
            Return _IdCargoocupacional
        End Get
        Set(value As Integer)
            _IdCargoocupacional = value
        End Set
    End Property
    Public Property Idtiporegistrosunat As Integer
        Get
            Return _Idtiporegistrosunat
        End Get
        Set(value As Integer)
            _Idtiporegistrosunat = value
        End Set
    End Property
    Public Property idCargosistena As Integer
        Get
            Return _idCargosistena
        End Get
        Set(value As Integer)
            _idCargosistena = value
        End Set
    End Property
    Public Property TipoPagoextra As Integer
        Get
            Return _TipoPagoextra
        End Get
        Set(value As Integer)
            _TipoPagoextra = value
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
    Public Property Tipocuentaextra As String
        Get
            Return _Tipocuentaextra
        End Get
        Set(value As String)
            _Tipocuentaextra = value
        End Set
    End Property
    Public Property ListaNegra As Boolean
        Get
            Return _ListaNegra
        End Get
        Set(value As Boolean)
            _ListaNegra = value
        End Set
    End Property

    Public Property Personaconfianza As Integer
        Get
            Return _Personaconfianza
        End Get
        Set(value As Integer)
            _Personaconfianza = value
        End Set
    End Property

    Public Property FechaFinContrato As DateTime
        Get
            Return _FechaFinContrato
        End Get
        Set(value As DateTime)
            _FechaFinContrato = value
        End Set
    End Property
    Public Property Tipocuenta As String
        Get
            Return _Tipocuenta
        End Get
        Set(value As String)
            _Tipocuenta = value
        End Set
    End Property

    Public Property NroCuentaextra As String
        Get
            Return _NroCuentaextra
        End Get
        Set(value As String)
            _NroCuentaextra = value
        End Set
    End Property
    Public Property idBancoextra As Integer
        Get
            Return _idBancoextra
        End Get
        Set(value As Integer)
            _idBancoextra = value
        End Set
    End Property

    Public Property Categoria As String
        Get
            Return _Categoria
        End Get
        Set(value As String)
            _Categoria = value
        End Set
    End Property

    Public Property IdDistrito As Integer
        Get
            Return _IdDistrito
        End Get
        Set(value As Integer)
            _IdDistrito = value
        End Set
    End Property

    Public Property Id As Integer
    Public Property Nombre As String
    Public Property IdPersona As Integer
        Get
            Return _idPersona
        End Get
        Set(value As Integer)
            _idPersona = value
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

    Public Property NumDocumento As String
        Get
            Return _NumDocumento
        End Get
        Set(value As String)
            _NumDocumento = value
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
    Public Property apaterno As String
        Get
            Return _apaterno
        End Get
        Set(value As String)
            _apaterno = value
        End Set
    End Property
    Public Property amaterno As String
        Get
            Return _amaterno
        End Get
        Set(value As String)
            _amaterno = value
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

    Public Property EstadoCivil As String
        Get
            Return _EstadoCivil
        End Get
        Set(value As String)
            _EstadoCivil = value
        End Set
    End Property

    Public Property FNacimiento As Date
        Get
            Return _FNacimiento
        End Get
        Set(value As Date)
            _FNacimiento = value
        End Set
    End Property

    Public Property Direccion As String
        Get
            Return _Direccion
        End Get
        Set(value As String)
            _Direccion = value
        End Set
    End Property

    Public Property Celular As String
        Get
            Return _Celular
        End Get
        Set(value As String)
            _Celular = value
        End Set
    End Property

    Public Property Correo As String
        Get
            Return _Correo
        End Get
        Set(value As String)
            _Correo = value
        End Set
    End Property

    Public Property Usuario As String
        Get
            Return _Usuario
        End Get
        Set(value As String)
            _Usuario = value
        End Set
    End Property

    Public Property Clave As String
        Get
            Return _Clave
        End Get
        Set(value As String)
            _Clave = value
        End Set
    End Property

    Public Property IdUsuario As String
        Get
            Return _IdUsuario
        End Get
        Set(value As String)
            _IdUsuario = value
        End Set
    End Property

    Public Property FRegistro As Date
        Get
            Return _FRegistro
        End Get
        Set(value As Date)
            _FRegistro = value
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

    Public Property ArchivoFoto As Byte()
        Get
            Return _ArchivoFoto
        End Get
        Set(value As Byte())
            _ArchivoFoto = value
        End Set
    End Property

    Public Property ArchivoFirma As Byte()
        Get
            Return _ArchivoFirma
        End Get
        Set(value As Byte())
            _ArchivoFirma = value
        End Set
    End Property

    Public Property IdGiroEmpresa As Integer
        Get
            Return _IdGiroEmpresa
        End Get
        Set(value As Integer)
            _IdGiroEmpresa = value
        End Set
    End Property

    Public Property IdTipoDocIdentidad As Integer
        Get
            Return _IdTipoDocIdentidad
        End Get
        Set(value As Integer)
            _IdTipoDocIdentidad = value
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

    Public Property FechaDesde As Nullable(Of Date)
        Get
            Return _FechaDesde
        End Get
        Set(value As Nullable(Of Date))
            _FechaDesde = value
        End Set
    End Property

    Public Property FechaHasta As Nullable(Of Date)
        Get
            Return _FechaHasta
        End Get
        Set(value As Nullable(Of Date))
            _FechaHasta = value
        End Set
    End Property

    Public Property IdTipoSeguroPlanilla As Integer
        Get
            Return _IdTipoSeguroPlanilla
        End Get
        Set(value As Integer)
            _IdTipoSeguroPlanilla = value
        End Set
    End Property

    Public Property Asignacionfamiliar As String
        Get
            Return _asignacionfamiliar
        End Get
        Set(value As String)
            _asignacionfamiliar = value
        End Set
    End Property

    Public Property FechaIngreso As DateTime
        Get
            Return _FechaIngreso
        End Get
        Set(value As DateTime)
            _FechaIngreso = value
        End Set
    End Property

    Public Property FechaSeguroPrivado As DateTime
        Get
            Return _FechaSeguroPrivado
        End Get
        Set(value As DateTime)
            _FechaSeguroPrivado = value
        End Set
    End Property

    Public Property FechaSeguroSocial As DateTime
        Get
            Return _FechaSeguroSocial
        End Get
        Set(value As DateTime)
            _FechaSeguroSocial = value
        End Set
    End Property

    Public Property FechaRegPensionario As DateTime
        Get
            Return _FechaRegPensionario
        End Get
        Set(value As DateTime)
            _FechaRegPensionario = value
        End Set
    End Property

    Public Property FechaBaja As DateTime
        Get
            Return _FechaBaja
        End Get
        Set(value As DateTime)
            _FechaBaja = value
        End Set
    End Property

    Public Property Remuneracion As Double
        Get
            Return _Remuneracion
        End Get
        Set(value As Double)
            _Remuneracion = value
        End Set
    End Property

    Public Property ExtraBono As Double
        Get
            Return _ExtraBono
        End Get
        Set(value As Double)
            _ExtraBono = value
        End Set
    End Property

    Public Property NroCuenta As String
        Get
            Return _NroCuenta
        End Get
        Set(value As String)
            _NroCuenta = value
        End Set
    End Property

    Public Property Lista_Cods_Sunat As String
        Get
            Return _Lista_Cods_Sunat
        End Get
        Set(value As String)
            _Lista_Cods_Sunat = value
        End Set
    End Property

    Public Property CUSSP As String
        Get
            Return _CUSSP
        End Get
        Set(value As String)
            _CUSSP = value
        End Set
    End Property
    Public Property IdCargo As Integer
        Get
            Return _IdCargo
        End Get
        Set(value As Integer)
            _IdCargo = value
        End Set
    End Property

    Public Property idFormadePago As Integer
        Get
            Return _idFormadePago
        End Get
        Set(value As Integer)
            _idFormadePago = value
        End Set
    End Property

    Public Property idBanco As Integer
        Get
            Return _idBanco
        End Get
        Set(value As Integer)
            _idBanco = value
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
    Public Property IdArea As Integer
        Get
            Return _IdArea
        End Get
        Set(value As Integer)
            _IdArea = value
        End Set
    End Property

    Public Property Dias As Integer
        Get
            Return _Dias
        End Get
        Set(value As Integer)
            _Dias = value
        End Set
    End Property
End Class
