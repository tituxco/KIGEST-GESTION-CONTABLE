Public Class CodigosSiniestrados
    Dim m_Codigo As Integer
    Dim m_Descripcion As String

    Public ReadOnly Property Codigo() As String
        Get
            Return Me.m_Codigo
        End Get
    End Property
    Public ReadOnly Property Descripcion() As String
        Get
            Return Me.m_Descripcion
        End Get
    End Property

    Sub New(ByVal Codigo As Integer, ByVal Descripcion As String)
        Me.m_Codigo = Codigo
        Me.m_Descripcion = Descripcion
    End Sub
End Class

Public Class CodigosAfirmativoNegativo
    Dim m_Codigo As Integer
    Dim m_Descripcion As String

    Public ReadOnly Property Codigo() As String
        Get
            Return Me.m_Codigo
        End Get
    End Property
    Public ReadOnly Property Descripcion() As String
        Get
            Return Me.m_Descripcion
        End Get
    End Property

    Sub New(ByVal Codigo As Integer, ByVal Descripcion As String)
        Me.m_Codigo = Codigo
        Me.m_Descripcion = Descripcion
    End Sub
End Class

Public Class CodigosTiposConceptosSueldos
    Dim m_Codigo As Integer
    Dim m_Descripcion As String

    Public ReadOnly Property Codigo() As String
        Get
            Return Me.m_Codigo
        End Get
    End Property
    Public ReadOnly Property Descripcion() As String
        Get
            Return Me.m_Descripcion
        End Get
    End Property

    Sub New(ByVal Codigo As Integer, ByVal Descripcion As String)
        Me.m_Codigo = Codigo
        Me.m_Descripcion = Descripcion
    End Sub
End Class

Public Class CodigoFormasdePago
    Dim m_Codigo As Integer
    Dim m_Descripcion As String

    Public ReadOnly Property Codigo() As String
        Get
            Return Me.m_Codigo
        End Get
    End Property
    Public ReadOnly Property Descripcion() As String
        Get
            Return Me.m_Descripcion
        End Get
    End Property

    Sub New(ByVal Codigo As Integer, ByVal Descripcion As String)
        Me.m_Codigo = Codigo
        Me.m_Descripcion = Descripcion
    End Sub
End Class

Public Class CodigosObrasSociales
    Dim m_Codigo As Integer
    Dim m_Descripcion As String

    Public ReadOnly Property Codigo() As String
        Get
            Return Me.m_Codigo
        End Get
    End Property
    Public ReadOnly Property Descripcion() As String
        Get
            Return Me.m_Descripcion
        End Get
    End Property

    Sub New(ByVal Codigo As Integer, ByVal Descripcion As String)
        Me.m_Codigo = Codigo
        Me.m_Descripcion = Descripcion
    End Sub
End Class

Public Class CodigosLocalidades
    Dim m_Codigo As Integer
    Dim m_Descripcion As String

    Public ReadOnly Property Codigo() As String
        Get
            Return Me.m_Codigo
        End Get
    End Property
    Public ReadOnly Property Descripcion() As String
        Get
            Return Me.m_Descripcion
        End Get
    End Property

    Sub New(ByVal Codigo As Integer, ByVal Descripcion As String)
        Me.m_Codigo = Codigo
        Me.m_Descripcion = Descripcion
    End Sub
End Class

Public Class CodigosTiposEmpresa
    Dim m_Codigo As Integer
    Dim m_Descripcion As String

    Public ReadOnly Property Codigo() As String
        Get
            Return Me.m_Codigo
        End Get
    End Property
    Public ReadOnly Property Descripcion() As String
        Get
            Return Me.m_Descripcion
        End Get
    End Property

    Sub New(ByVal Codigo As Integer, ByVal Descripcion As String)
        Me.m_Codigo = Codigo
        Me.m_Descripcion = Descripcion
    End Sub
End Class

Public Class CodigosModosContratacion
    Dim m_Codigo As Integer
    Dim m_Descripcion As String

    Public ReadOnly Property Codigo() As String
        Get
            Return Me.m_Codigo
        End Get
    End Property
    Public ReadOnly Property Descripcion() As String
        Get
            Return Me.m_Descripcion
        End Get
    End Property

    Sub New(ByVal Codigo As Integer, ByVal Descripcion As String)
        Me.m_Codigo = Codigo
        Me.m_Descripcion = Descripcion
    End Sub
End Class

Public Class CodigosActividadEmpleados
    Dim m_Codigo As Integer
    Dim m_Descripcion As String

    Public ReadOnly Property Codigo() As String
        Get
            Return Me.m_Codigo
        End Get
    End Property
    Public ReadOnly Property Descripcion() As String
        Get
            Return Me.m_Descripcion
        End Get
    End Property

    Sub New(ByVal Codigo As Integer, ByVal Descripcion As String)
        Me.m_Codigo = Codigo
        Me.m_Descripcion = Descripcion
    End Sub
End Class

Public Class CodigosCondicion
    Dim m_Codigo As Integer
    Dim m_Descripcion As String

    Public ReadOnly Property Codigo() As String
        Get
            Return Me.m_Codigo
        End Get
    End Property
    Public ReadOnly Property Descripcion() As String
        Get
            Return Me.m_Descripcion
        End Get
    End Property

    Sub New(ByVal Codigo As Integer, ByVal Descripcion As String)
        Me.m_Codigo = Codigo
        Me.m_Descripcion = Descripcion
    End Sub
End Class

Public Class CodigoSituacionRevista
    Dim m_Codigo As Integer
    Dim m_Descripcion As String

    Public ReadOnly Property Codigo() As String
        Get
            Return Me.m_Codigo
        End Get
    End Property
    Public ReadOnly Property Descripcion() As String
        Get
            Return Me.m_Descripcion
        End Get
    End Property

    Sub New(ByVal Codigo As Integer, ByVal Descripcion As String)
        Me.m_Codigo = Codigo
        Me.m_Descripcion = Descripcion
    End Sub
End Class

Public Class RegistrarTiposConceptosSueldos
    Inherits CollectionBase
    Default Public ReadOnly Property Item(ByVal Indice As Integer) As CodigosTiposConceptosSueldos
        Get
            Return CType(List.Item(Indice), CodigosTiposConceptosSueldos)
        End Get
    End Property

    Sub Add(ByVal Nuevo As CodigosTiposConceptosSueldos)
        List.Add(Nuevo)
    End Sub
    Sub New()
        MyBase.New()
    End Sub
End Class

Public Class RegistrarCodigosCondicion
    Inherits CollectionBase
    Default Public ReadOnly Property Item(ByVal Indice As Integer) As CodigosCondicion
        Get
            Return CType(List.Item(Indice), CodigosCondicion)
        End Get
    End Property

    Sub Add(ByVal Nuevo As CodigosCondicion)
        List.Add(Nuevo)
    End Sub
    Sub New()
        MyBase.New()
    End Sub
End Class

Public Class RegistrarFormasdePago
    Inherits CollectionBase
    Default Public ReadOnly Property Item(ByVal Indice As Integer) As CodigoFormasdePago
        Get
            Return CType(List.Item(Indice), CodigoFormasdePago)
        End Get
    End Property

    Sub Add(ByVal Nuevo As CodigoFormasdePago)
        List.Add(Nuevo)
    End Sub
    Sub New()
        MyBase.New()
    End Sub
End Class

Public Class RegistrarCodigosObrasSociales
    Inherits CollectionBase
    Default Public ReadOnly Property Item(ByVal Indice As Integer) As CodigosObrasSociales
        Get
            Return CType(List.Item(Indice), CodigosObrasSociales)
        End Get
    End Property

    Sub Add(ByVal Nuevo As CodigosObrasSociales)
        List.Add(Nuevo)
    End Sub
    Sub New()
        MyBase.New()
    End Sub
End Class

Public Class RegistrarCodigosLocalidades
    Inherits CollectionBase
    Default Public ReadOnly Property Item(ByVal Indice As Integer) As CodigosLocalidades
        Get
            Return CType(List.Item(Indice), CodigosLocalidades)
        End Get
    End Property

    Sub Add(ByVal Nuevo As CodigosLocalidades)
        List.Add(Nuevo)
    End Sub
    Sub New()
        MyBase.New()
    End Sub
End Class

Public Class RegistrarSituacionRevista
    Inherits CollectionBase
    Default Public ReadOnly Property Item(ByVal Indice As Integer) As CodigoSituacionRevista
        Get
            Return CType(List.Item(Indice), CodigoSituacionRevista)
        End Get
    End Property

    Sub Add(ByVal Nuevo As CodigoSituacionRevista)
        List.Add(Nuevo)
    End Sub
    Sub New()
        MyBase.New()
    End Sub
End Class

Public Class RegistrarCodigosActividadEmpleados
    Inherits CollectionBase
    Default Public ReadOnly Property Item(ByVal Indice As Integer) As CodigosActividadEmpleados
        Get
            Return CType(List.Item(Indice), CodigosActividadEmpleados)
        End Get
    End Property

    Sub Add(ByVal Nuevo As CodigosActividadEmpleados)
        List.Add(Nuevo)
    End Sub
    Sub New()
        MyBase.New()
    End Sub
End Class

Public Class RegistrarCodigosSiniestrados
    Inherits CollectionBase
    Default Public ReadOnly Property Item(ByVal Indice As Integer) As CodigosSiniestrados
        Get
            Return CType(List.Item(Indice), CodigosSiniestrados)
        End Get
    End Property

    Sub Add(ByVal Nuevo As CodigosSiniestrados)
        List.Add(Nuevo)
    End Sub
    Sub New()
        MyBase.New()
    End Sub
End Class

Public Class RegistrarModosContratacion
    Inherits CollectionBase
    Default Public ReadOnly Property Item(ByVal Indice As Integer) As CodigosModosContratacion
        Get
            Return CType(List.Item(Indice), CodigosModosContratacion)
        End Get
    End Property

    Sub Add(ByVal Nuevo As CodigosModosContratacion)
        List.Add(Nuevo)
    End Sub
    Sub New()
        MyBase.New()
    End Sub
End Class

Public Class RegistrarTiposEmpresa
    Inherits CollectionBase
    Default Public ReadOnly Property Item(ByVal Indice As Integer) As CodigosTiposEmpresa
        Get
            Return CType(List.Item(Indice), CodigosTiposEmpresa)
        End Get
    End Property

    Sub Add(ByVal Nuevo As CodigosTiposEmpresa)
        List.Add(Nuevo)
    End Sub
    Sub New()
        MyBase.New()
    End Sub
End Class
Public Class RegistrarAfirmativoNegativo
    Inherits CollectionBase
    Default Public ReadOnly Property Item(ByVal Indice As Integer) As CodigosAfirmativoNegativo
        Get
            Return CType(List.Item(Indice), CodigosAfirmativoNegativo)
        End Get
    End Property

    Sub Add(ByVal Nuevo As CodigosAfirmativoNegativo)
        List.Add(Nuevo)
    End Sub
    Sub New()
        MyBase.New()
    End Sub
End Class

'*******************************************************************************************************************************************




