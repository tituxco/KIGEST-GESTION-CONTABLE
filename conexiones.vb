'CREO LA INSTANCIA DE MYSQL
Imports MySql.Data.MySqlClient
Module Conexiones
    'CREO LAS VARIABLES GLOBALES DE CONEXION
    Public conexionPrinc As MySqlConnection
    Public conexionEmp As MySqlConnection
    Public conexionAuth As MySqlConnection
    'CREO LAS VARIABLE GLOBALES DE DATOS DE CONEXION
    Public serv As String
    Public port As String
    Public user As String
    Public pass As String
    Public clie As String
    Public clav As String
    Public codus As String
    Public database As String
    Public EmpDB As String
    Friend comando As MySqlCommand
    Friend leer As MySqlDataReader

    Public Function ConectarAuth() As Boolean

        Dim comprobarAuth As New MySqlCommand


        Try
            conexionAuth = New MySqlConnection
            conexionAuth.ConnectionString = "server=authkibit.donweb-remoteip.net; port=3306; userid=kiremoto; password=mecago;Allow Zero Datetime=True;Convert Zero Datetime=True;Persist Security Info=True"
            conexionAuth.Open()

            conexionAuth.ChangeDatabase("AuthServ")

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function ComprobarAuth() As Boolean
        Try
            Dim leerAuth As IDataReader
            Dim i As Integer

            Dim consultaauth As New MySql.Data.MySqlClient.MySqlDataAdapter("select codus, pass,cliente, usuario,autorizado, servidor, bd, puerto,modulo,servidor_resp from CliAuth where clave like '" & clav & "' and codus like '" & user & "'", conexionAuth)
            Dim tablaauth As New DataTable
            Dim infoauth() As DataRow
            consultaauth.Fill(tablaauth)
            infoauth = tablaauth.Select()
            'txtrazon.Text = infoauth(0)(0)
            If tablaauth.Rows.Count = 0 Then
                MsgBox("Sus datos de acceso son incorrectos")
                Return False
                Exit Function
            End If

            If infoauth(0)(4) = 1 Then
                serv = infoauth(0)(5)
                port = infoauth(0)(7)
                database = infoauth(0)(6)
                user = infoauth(0)(3)
                clie = infoauth(0)(2)
                pass = infoauth(0)(1)
                codus = infoauth(0)(0)
                DatosAcceso.Moduloacc = infoauth(0)(8)
                DatosAcceso.bd = infoauth(0)(6)
                DatosAcceso.Cliente = infoauth(0)(2)
                DatosAcceso.CLOUDserv = infoauth(0)(5)
                DatosAcceso.pass = infoauth(0)(1)
                DatosAcceso.puerto = infoauth(0)(7)
                DatosAcceso.RESPserv = infoauth(0)(9)
                DatosAcceso.usuario = infoauth(0)(3)

                'If conectar(serv, port, user, pass, database) = True Then
                'Return True
                'End If
                Return True
            Else
                MsgBox("El servidor de acceso indica que no tiene autorización para acceder al sistema, por favor comuniquese con el administrador")
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function conectar(ByRef Servidor As String, ByRef Puerto As String, ByRef usuario As String, ByRef contraseña As String, ByRef bd As String) As Boolean
        'REALIZO LA CONEXION CON LOS DATOS OBTENIDOS DEL FORMULARIO INICIALIZAR
        Try
            conexionPrinc = New MySqlConnection
            conexionEmp = New MySqlConnection

            conexionPrinc.ConnectionString = "server=" & Servidor & "; port=" & Puerto & "; userid=" & usuario & "; password=" & contraseña & ";"
            conexionEmp.ConnectionString = conexionPrinc.ConnectionString
            conexionPrinc.Open()
            conexionEmp.Open()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
    Public Function ConectarBDPrincipal() As Boolean
        'COMPRUEBO QUE EXISTE LA BASE DE DATOS INDICADA
        If comprobar_base_de_datos_principal() = True Then
            'conexionPrinc.ChangeDatabase(database)
            Return True
        Else
            'MsgBox("La base de datos indicada no existe")
            Return False
        End If
        'Return conexionPrinc.Database
    End Function

    Public Function ConectarEmpresa(ByRef empresa As String) As String
        conexionEmp.ChangeDatabase(empresa.ToLower)
        Return conexionEmp.Database
    End Function
End Module