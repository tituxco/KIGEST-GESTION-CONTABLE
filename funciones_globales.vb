Imports System.Data
Imports System.IO
Imports System.IO.Compression
Module funciones_Globales
    'Public EmpresaSeleccionada As Integer
    Public Function parametrizarCampo(dato As String, longitud As Integer, caracter As String, izquierda As Boolean) As String
        Try
            Dim texto As String = dato
            If izquierda = True Then
                texto = texto.PadLeft(longitud, caracter)
            Else
                texto = texto.PadRight(longitud, caracter)
            End If
            Return texto
        Catch ex As Exception

        End Try

    End Function
    Public Structure DatosEmp
        Public Property Razon As String
        Public Property Fantasia As String
        Public Property Domicilio As String
        Public Property Cuit As String

        Public Property IdEmpresa As String
    End Structure

    Public DatosEmpresa As DatosEmp
    Public Sub cerrar_Conexiones()
        Try
            'conexionEmp.Close()
            conexionPrinc.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Public Sub abrir_Conexiones()
        Try
            'conexionEmp.Open()
            conexionPrinc.Open()
            conexionPrinc.ChangeDatabase(database)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Sub Reconectar()
        Try
            conexionPrinc.Close()
            conexionPrinc.Open()
            conexionPrinc.ChangeDatabase(database)
            conexionEmp.Close()
            conexionEmp.Open()
        Catch ex As Exception

        End Try
    End Sub

    Public Function reemplazar_espacios(ByRef texto As String) As String
        Dim reemplazo As String
        Try
            reemplazo = Replace(texto, " ", "_").ToUpper
            Return reemplazo
        Catch ex As Exception
            Return "error"
        End Try
    End Function
    Public Function ValidaControles(ByVal ctrlContenedor As Form) As Boolean
        'Recorre todos y cada uno de los controles contenidos en el contenedor
        For Each Control As Control In ctrlContenedor.Controls
            'Si el control que se esta revisando es un textbox
            If TypeOf Control Is TextBox Then
                'Verificamos que tenga informacion
                If Trim(Control.Text) = "" Then
                    'Si no tiene informacion mandamos un MSGBOX con el mensaje apropiado el cual se encuentra en el tag del control
                    MsgBox(Control.Tag, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Application.ProductName)
                    'Pone el foco en el control
                    Control.BackColor = Color.Salmon
                    Control.Focus()
                    'Regresa un falso indicando que los controles no estan llenados correctamente

                    Exit For
                    Return False
                End If
                'Si el control que se esta revisando es un ComboBox   
            ElseIf TypeOf Control Is ComboBox Then
                'Hago un tipo cast para convertirlo a ComboBOx porque por alguna extraña razon no puedo ingresar a sus propiedades correctamente     
                Dim aux As ComboBox = Control
                'Si no tienen ningun elemento seleccionado el combobox mandamos un MSGBOX con el mensaje apropiado el cual se encuentra en el tag del control
                If aux.SelectedValue = Nothing Then
                    MsgBox(Control.Tag, MsgBoxStyle.OkOnly + MsgBoxStyle.Information, Application.ProductName)
                    'Pone el foco en el control 
                    Control.Focus()
                    'Regresa un falso indicando que los controles no estan llenados correctamente
                    Return False
                    Exit For
                End If
            End If
        Next
        'Si no hubo ningun problema con los controles regresamos un true indicando que los controles estan llenados correctamente
        Return True
    End Function
    'convertir binario a imágen
    Public Function Bytes_Imagen(ByVal Imagen As Byte()) As Image
        Try
            'si hay imagen
            If Not Imagen Is Nothing Then
                'caturar array con memorystream hacia Bin
                Dim Bin As New MemoryStream(Imagen)
                'con el método FroStream de Image obtenemos imagen
                Dim Resultado As Image = Image.FromStream(Bin)
                'y la retornamos
                Return Resultado
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    'convertir imagen a binario
    Public Function Imagen_Bytes(ByVal Imagen As Image) As Byte()
        'si hay imagen
        If Not Imagen Is Nothing Then
            'variable de datos binarios en stream(flujo)
            Dim Bin As New MemoryStream
            'convertir a bytes
            Imagen.Save(Bin, Imaging.ImageFormat.Jpeg)
            'retorna binario
            Return Bin.GetBuffer
        Else
            Return Nothing
        End If
    End Function

    Public Function remplazarcoma(ByVal cadena As String) As String
        Dim pos As Integer
        pos = InStr(cadena, ".")
        If pos <> 0 Then
            Mid(cadena, pos, pos + 1) = ","
            remplazarcoma = cadena

        Else : remplazarcoma = cadena
        End If

    End Function

    Public Function remplazarPunto(ByVal cadena As String) As String
        Dim pos As Integer
        pos = InStr(cadena, ",")
        If pos <> 0 Then
            Mid(cadena, pos, pos + 1) = "."
            remplazarPunto = cadena

        Else : remplazarPunto = cadena
        End If

    End Function

    Public Function PonerComodinSQL(ByVal cadena As String) As String
        Dim pos As Integer
        pos = InStr(cadena, " ")
        If pos <> 0 Then
            Mid(cadena, pos, pos + 1) = "%"
            PonerComodinSQL = cadena

        Else : PonerComodinSQL = cadena
        End If

    End Function

    Public Function EnLetras(numero As String) As String
        Dim b, paso As Integer
        Dim expresion, entero, deci, flag As String
        numero = Replace(numero, ".", "")
        'numero = remplazarPunto(numero)
        flag = "N"
        For paso = 1 To Len(numero)
            If Mid(numero, paso, 1) = "," Then
                flag = "S"
            Else
                If flag = "N" Then
                    entero = entero + Mid(numero, paso, 1) 'Extae la parte entera del numero
                Else
                    deci = deci + Mid(numero, paso, 1) 'Extrae la parte decimal del numero
                End If
            End If
        Next paso

        If Len(deci) = 1 Then
            deci = deci & "0"
        End If

        flag = "N"
        If Val(numero) >= -999999999 And Val(numero) <= 999999999 Then 'si el numero esta dentro de 0 a 999.999.999
            For paso = Len(entero) To 1 Step -1
                b = Len(entero) - (paso - 1)
                Select Case paso
                    Case 3, 6, 9
                        Select Case Mid(entero, b, 1)
                            Case "1"
                                If Mid(entero, b + 1, 1) = "0" And Mid(entero, b + 2, 1) = "0" Then
                                    expresion = expresion & "cien "
                                Else
                                    expresion = expresion & "ciento "
                                End If
                            Case "2"
                                expresion = expresion & "doscientos "
                            Case "3"
                                expresion = expresion & "trescientos "
                            Case "4"
                                expresion = expresion & "cuatrocientos "
                            Case "5"
                                expresion = expresion & "quinientos "
                            Case "6"
                                expresion = expresion & "seiscientos "
                            Case "7"
                                expresion = expresion & "setecientos "
                            Case "8"
                                expresion = expresion & "ochocientos "
                            Case "9"
                                expresion = expresion & "novecientos "
                        End Select

                    Case 2, 5, 8
                        Select Case Mid(entero, b, 1)
                            Case "1"
                                If Mid(entero, b + 1, 1) = "0" Then
                                    flag = "S"
                                    expresion = expresion & "diez "
                                End If
                                If Mid(entero, b + 1, 1) = "1" Then
                                    flag = "S"
                                    expresion = expresion & "once "
                                End If
                                If Mid(entero, b + 1, 1) = "2" Then
                                    flag = "S"
                                    expresion = expresion & "doce "
                                End If
                                If Mid(entero, b + 1, 1) = "3" Then
                                    flag = "S"
                                    expresion = expresion & "trece "
                                End If
                                If Mid(entero, b + 1, 1) = "4" Then
                                    flag = "S"
                                    expresion = expresion & "catorce "
                                End If
                                If Mid(entero, b + 1, 1) = "5" Then
                                    flag = "S"
                                    expresion = expresion & "quince "
                                End If
                                If Mid(entero, b + 1, 1) > "5" Then
                                    flag = "N"
                                    expresion = expresion & "dieci"
                                End If

                            Case "2"
                                If Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "veinte "
                                    flag = "S"
                                Else
                                    expresion = expresion & "veinti"
                                    flag = "N"
                                End If

                            Case "3"
                                If Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "treinta "
                                    flag = "S"
                                Else
                                    expresion = expresion & "treinta y "
                                    flag = "N"
                                End If

                            Case "4"
                                If Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "cuarenta "
                                    flag = "S"
                                Else
                                    expresion = expresion & "cuarenta y "
                                    flag = "N"
                                End If

                            Case "5"
                                If Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "cincuenta "
                                    flag = "S"
                                Else
                                    expresion = expresion & "cincuenta y "
                                    flag = "N"
                                End If

                            Case "6"
                                If Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "sesenta "
                                    flag = "S"
                                Else
                                    expresion = expresion & "sesenta y "
                                    flag = "N"
                                End If

                            Case "7"
                                If Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "setenta "
                                    flag = "S"
                                Else
                                    expresion = expresion & "setenta y "
                                    flag = "N"
                                End If

                            Case "8"
                                If Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "ochenta "
                                    flag = "S"
                                Else
                                    expresion = expresion & "ochenta y "
                                    flag = "N"
                                End If

                            Case "9"
                                If Mid(entero, b + 1, 1) = "0" Then
                                    expresion = expresion & "noventa "
                                    flag = "S"
                                Else
                                    expresion = expresion & "noventa y "
                                    flag = "N"
                                End If
                        End Select

                    Case 1, 4, 7
                        Select Case Mid(entero, b, 1)
                            Case "1"
                                If flag = "N" Then
                                    If paso = 1 Then
                                        expresion = expresion & "uno "
                                    Else
                                        expresion = expresion & "un "
                                    End If
                                End If
                            Case "2"
                                If flag = "N" Then
                                    expresion = expresion & "dos "
                                End If
                            Case "3"
                                If flag = "N" Then
                                    expresion = expresion & "tres "
                                End If
                            Case "4"
                                If flag = "N" Then
                                    expresion = expresion & "cuatro "
                                End If
                            Case "5"
                                If flag = "N" Then
                                    expresion = expresion & "cinco "
                                End If
                            Case "6"
                                If flag = "N" Then
                                    expresion = expresion & "seis "
                                End If
                            Case "7"
                                If flag = "N" Then
                                    expresion = expresion & "siete "
                                End If
                            Case "8"
                                If flag = "N" Then
                                    expresion = expresion & "ocho "
                                End If
                            Case "9"
                                If flag = "N" Then
                                    expresion = expresion & "nueve "
                                End If
                        End Select
                End Select
                If paso = 4 Then
                    If Mid(entero, 6, 1) <> "0" Or Mid(entero, 5, 1) <> "0" Or Mid(entero, 4, 1) <> "0" Or _
                      (Mid(entero, 6, 1) = "0" And Mid(entero, 5, 1) = "0" And Mid(entero, 4, 1) = "0" And _
                       Len(entero) <= 6) Then
                        expresion = expresion & "mil "
                    End If
                End If
                'If paso = 7 Then
                'If Len(entero) = 7 And Mid(entero, 1, 1) = "1" Then
                'expresion = expresion & "millón "
                'Else
                'expresion = expresion & "millones "
                'End If
                'End If
            Next paso

            If deci <> "" Then
                If Mid(entero, 1, 1) = "-" Then 'si el numero es negativo
                    EnLetras = "menos " & expresion & "con " & deci & "/100"
                Else
                    EnLetras = expresion & "con " & deci & "/100"
                End If
            Else
                If Mid(entero, 1, 1) = "-" Then 'si el numero es negativo
                    EnLetras = "menos " & expresion
                Else
                    EnLetras = expresion
                End If
            End If
        Else 'si el numero a convertir esta fuera del rango superior e inferior
            EnLetras = ""
        End If
    End Function

    Public Sub Comprimir(ByVal fi As FileInfo)
        ' Get the stream of the source file.
        Using inFile As FileStream = fi.OpenRead()
            ' Compressing:
            ' Prevent compressing hidden and already compressed files.

            If (File.GetAttributes(fi.FullName) And FileAttributes.Hidden) _
                <> FileAttributes.Hidden And fi.Extension <> ".gz" Then
                ' Create the compressed file.
                Using outFile As FileStream = File.Create(fi.FullName + ".gz")
                    Using Compress As GZipStream =
                        New GZipStream(outFile, CompressionMode.Compress)

                        ' Copy the source file into the compression stream.
                        inFile.CopyTo(Compress)

                    End Using
                End Using
            End If
        End Using
    End Sub
End Module