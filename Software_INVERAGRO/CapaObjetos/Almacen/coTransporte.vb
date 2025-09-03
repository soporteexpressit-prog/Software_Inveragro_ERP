Public Class coTransporte
    Private _Codigo As Integer
    Private _numplaca As String
    Private _capacidadcarga As Double
    Private _pesotara As Double
    Private _modelo As String
    Private _tipovehiculo As String
    Private _marca As String
    Private _aniofabricacion As Integer
    Private _estado As String
    Private _tipoestado As String
    Private _Descripcion As String
    Private _operacion As Integer
    Private _Coderror As Integer
    Public Property tipoestado As String
        Get
            Return _tipoestado
        End Get
        Set(value As String)
            _tipoestado = value
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
    Public Property Coderror As Integer
        Get
            Return _Coderror
        End Get
        Set(value As Integer)
            _Coderror = value
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
    Public Property estado As String
        Get
            Return _estado
        End Get
        Set(value As String)
            _estado = value
        End Set
    End Property
    Public Property capacidadcarga As Double
        Get
            Return _capacidadcarga
        End Get
        Set(value As Double)
            _capacidadcarga = value
        End Set
    End Property
    Public Property pesotara As Double
        Get
            Return _pesotara
        End Get
        Set(value As Double)
            _pesotara = value
        End Set
    End Property
    Public Property marca As String
        Get
            Return _marca
        End Get
        Set(value As String)
            _marca = value
        End Set
    End Property
    Public Property numplaca As String
        Get
            Return _numplaca
        End Get
        Set(value As String)
            _numplaca = value
        End Set
    End Property
    Public Property modelo As String
        Get
            Return _modelo
        End Get
        Set(value As String)
            _modelo = value
        End Set
    End Property
    Public Property tipovehiculo As String
        Get
            Return _tipovehiculo
        End Get
        Set(value As String)
            _tipovehiculo = value
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
    Public Property aniofabricacion As Integer
        Get
            Return _aniofabricacion
        End Get
        Set(value As Integer)
            _aniofabricacion = value
        End Set
    End Property
End Class
