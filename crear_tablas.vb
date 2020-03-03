Module crear_tablas
    Public Function crear_TB_iva() As Boolean
        Dim leerSQL As New System.IO.StreamReader(Application.StartupPath & "\archivosinst\tablas_comunes_iva.txt")
        cerrar_Conexiones()
        Try
            abrir_Conexiones()
            ConectarBDPrincipal()
            comando.Connection = conexionPrinc
            comando.CommandText = leerSQL.ReadToEnd
            leerSQL.Close()
            comando.ExecuteReader()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function crear_TB_sueldos() As Boolean
        Dim leerSQL As New System.IO.StreamReader(Application.StartupPath & "\archivosinst\tablas_comunes_sueldos.txt")
        cerrar_Conexiones()
        Try
            abrir_Conexiones()
            ConectarBDPrincipal()
            comando.Connection = conexionPrinc
            comando.CommandText = leerSQL.ReadToEnd
            leerSQL.Close()
            comando.ExecuteReader()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False

        End Try
    End Function

    Public Function crear_BD_empresa(ByRef empresa As String) As Boolean
        Reconectar()
        comando = New MySql.Data.MySqlClient.MySqlCommand
        Try
            comando.Connection = conexionPrinc
            comando.CommandText = "create database " & empresa.ToLower
            comando.ExecuteReader()

            If CrearTablasIVA(empresa) = True And CrearTablasSUELDO(empresa) = True Then
                Return True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
    Private Function CrearTablasIVA(ByRef empresa As String) As Boolean
        Try
            If Comprobar_tablas_IVA() = True Then
                Dim leerSQL As New System.IO.StreamReader(Application.StartupPath & "\archivosinst\tablas_iva.txt")
                Try
                    Reconectar()
                    ConectarEmpresa(empresa)
                    comando.Connection = conexionEmp
                    comando.CommandText = leerSQL.ReadToEnd
                    leerSQL.Close()
                    comando.ExecuteReader()
                    Return True
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Return False
                End Try
            Else
                MsgBox("Error en comprobacion de tablas de IVA")
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Private Function CrearTablasSUELDO(ByRef empresa As String) As Boolean
        Try
            If Comprobar_tablas_SUELDO() = True Then
                Dim leerSQL As New System.IO.StreamReader(Application.StartupPath & "\archivosinst\tablas_sueldos.txt")

                Try
                    Reconectar()
                    ConectarEmpresa(empresa)
                    comando.Connection = conexionEmp
                    comando.CommandText = leerSQL.ReadToEnd
                    leerSQL.Close()
                    comando.ExecuteReader()
                    Return True
                Catch ex As Exception
                    MsgBox(ex.Message)
                    Return False

                End Try
            Else
                MsgBox("Error en comprobacion de tablas de sueldo")
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
    Public Sub eliminarBDEMPRESA(ByRef empresa As String)

        Reconectar()
        comando = New MySql.Data.MySqlClient.MySqlCommand
        Try
            comando.Connection = conexionEmp
            comando.CommandText = "drop database " & empresa
            comando.ExecuteReader()

            
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Module