Module Variables_Globales
    Public moduloIVA_Act As Boolean = False
    Public moduloSUELDO_Act As Boolean = False
    Public UltimoPathIMG As String = "c:\"

    Public Structure Encuesta
        Public Property Pregunta As String
        Public Property Respuesta As String
    End Structure

    Public Structure DatosUsuario
        Public Property Moduloacc As String
        Public Property Cliente As String

        Public Property usuario As String
        Public Property pass As String
        Public Property bd As String
        Public Property puerto As String
        Public Property calculoutili As Double

        Public Property CLOUDserv As String
        Public Property RESPserv As String
    End Structure

    Public DatosAcceso As DatosUsuario
End Module
