Module comprobar_tablas
    'compruebo que exista la base de datos indicada al inicio del sistema
    Public Function comprobar_base_de_datos_principal() As Boolean
        Try
            conexionPrinc.ChangeDatabase(database)
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Public Function comprobar_tablas_princ() As Boolean
        comando = New MySql.Data.MySqlClient.MySqlCommand
        Dim encontrado As Integer
        Try
            Reconectar()
            comando.Connection = conexionPrinc
            comando.CommandText = "show tables;"
            leer = comando.ExecuteReader
            While leer.Read
                Select Case leer(0)
                    Case "cm_actividades_empresas"
                        encontrado = encontrado + 1
                    Case "cm_condicion_iva"
                        encontrado = encontrado + 1
                    Case "cm_doc_tipo"
                        encontrado = encontrado + 1
                    Case "cm_empresas"
                        encontrado = encontrado + 1
                    Case "cm_estado_civil"
                        encontrado = encontrado + 1
                    Case "cm_genero"
                        encontrado = encontrado + 1
                    Case "cm_iv_tipo_comprobante"
                        encontrado = encontrado + 1
                    Case "cm_localidad"
                        encontrado = encontrado + 1
                    Case "cm_nacionalidad"
                        encontrado = encontrado + 1
                    Case "cm_provincias"
                        encontrado = encontrado + 1
                    Case "cm_sdo_categoria_personal"
                        encontrado = encontrado + 1
                    Case "cm_sdo_centro_costos"
                        encontrado = encontrado + 1
                    Case "cm_sdo_conceptos_sueldo"
                        encontrado = encontrado + 1
                    Case "cm_sdo_conceptosSueldoAFIP"
                        encontrado = encontrado + 1
                    Case "cm_sdo_convenios"
                        encontrado = encontrado + 1
                    Case "cm_sdo_infoExtraLSD"
                        encontrado = encontrado + 1
                    Case "cm_sdo_jornada"
                        encontrado = encontrado + 1
                    Case "cm_sdo_modo_contratacion"
                        encontrado = encontrado + 1
                    Case "cm_sdo_modo_pago"
                        encontrado = encontrado + 1
                    Case "cm_sdo_periodos_pago"
                        encontrado = encontrado + 1
                    Case "cm_sdo_tipos_conceptos_sueldo"
                        encontrado = encontrado + 1
                    Case "cm_sdo_unidades_calculo"
                        encontrado = encontrado + 1
                End Select
            End While
            leer.Close()
            'MsgBox(encontrado)
            If encontrado = 22 Or encontrado = 20 Then
                '                MsgBox("Las tablas basicas estan correctas")

                Return True
            Else
                'MsgBox("se han encontrado solamente " & encontrado & " tablas")

                Return False

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False

        End Try
    End Function

    Public Function comprobar_tablas_Empresa() As Boolean
        comando = New MySql.Data.MySqlClient.MySqlCommand
        Dim encontrado As Integer
        Try
            Reconectar()
            comando.Connection = conexionEmp
            comando.CommandText = "show tables;"
            leer = comando.ExecuteReader
            While leer.Read
                Select Case leer(0)
                    Case "iv_clientes"
                        encontrado = encontrado + 1
                    Case "iv_items_compras"
                        encontrado = encontrado + 1
                    Case "iv_items_ventas"
                        encontrado = encontrado + 1
                    Case "iv_periodos"
                        encontrado = encontrado + 1
                    Case "iv_proveedores"
                        encontrado = encontrado + 1
                    Case "iv_punto_venta"
                        encontrado = encontrado + 1
                    Case "sdo_antiguedad_personal"
                        encontrado = encontrado + 1
                    Case "sdo_items_recibos"
                        encontrado = encontrado + 1
                    Case "sdo_personal"
                        encontrado = encontrado + 1
                    Case "sdo_personal_infoLSD"
                        encontrado = encontrado + 1
                    Case "sdo_recibos"
                        encontrado = encontrado + 1
                End Select
            End While
            leer.Close()
            'MsgBox(encontrado)
            If encontrado = 11 Then
                '                MsgBox("Las tablas basicas estan correctas")

                Return True
            Else
                'MsgBox("se han encontrado solamente " & encontrado & " tablas")

                Return False

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False

        End Try
    End Function

    Public Function Comprobar_tablas_IVA() As Boolean
        comando = New MySql.Data.MySqlClient.MySqlCommand
        Dim encontrado As Integer
        Try
            Reconectar()
            conexionPrinc.ChangeDatabase(database)
            comando.Connection = conexionPrinc
            comando.CommandText = "show tables;"
            leer = comando.ExecuteReader
            While leer.Read
                Select Case leer(0)
                    Case "cm_iv_tipo_comprobante"
                        encontrado = encontrado + 1
                End Select
            End While
            leer.Close()
            If encontrado = 1 Then
                MsgBox("Las tablas de iva estan correctas")
                '  moduloIVA_Act = True
                Return True
            Else
                MsgBox("se han encontrado solamente " & encontrado & " tablas")
                '   moduloIVA_Act = False
                Return False

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            'moduloIVA_Act = False
            Return False

        End Try
    End Function

    Public Function Comprobar_tablas_SUELDO() As Boolean
        comando = New MySql.Data.MySqlClient.MySqlCommand
        Dim encontrado As Integer
        Try
            Reconectar()
            conexionPrinc.ChangeDatabase(database)
            comando.Connection = conexionPrinc
            comando.CommandText = "show tables;"
            leer = comando.ExecuteReader
            While leer.Read
                Select Case leer(0)
                    Case "cm_sdo_categoria_personal"
                        encontrado = encontrado + 1
                    Case "cm_sdo_centro_costos"
                        encontrado = encontrado + 1
                    Case "cm_sdo_conceptos_sueldo"
                        encontrado = encontrado + 1
                    Case "cm_sdo_conceptosSueldoAFIP"
                        encontrado = encontrado + 1
                    Case "cm_sdo_convenios"
                        encontrado = encontrado + 1
                    Case "cm_sdo_infoExtraLSD"
                        encontrado = encontrado + 1
                    Case "cm_sdo_jornada"
                        encontrado = encontrado + 1
                    Case "cm_sdo_modo_contratacion"
                        encontrado = encontrado + 1
                    Case "cm_sdo_modo_pago"
                        encontrado = encontrado + 1
                    Case "cm_sdo_periodos_pago"
                        encontrado = encontrado + 1
                    Case "cm_sdo_tipos_conceptos_sueldo"
                        encontrado = encontrado + 1
                    Case "cm_sdo_unidades_calculo"
                        encontrado = encontrado + 1
                End Select
            End While
            leer.Close()
            If encontrado = 12 Then
                'MsgBox("Las tablas de sueldo estan correctas")
                'moduloSUELDO_Act = True
                Return True

            Else
                MsgBox("se han encontrado solamente " & encontrado & " tablas")
                '    moduloSUELDO_Act = False
                Return False

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            ' moduloSUELDO_Act = False
            Return False
        End Try
    End Function
End Module
