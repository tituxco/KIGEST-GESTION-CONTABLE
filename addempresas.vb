Public Class frmaddempresas
    Public modificar As Boolean
    Public idEmpresa As Integer
    Public tablaEmpr As String
    Dim actividad As New DataGridViewComboBoxCell

    Private Sub cmdcancelar_Click(sender As Object, e As EventArgs) Handles cmdcancelar.Click
        Me.Close()
    End Sub

    Private Sub frmaddempresas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarDatosGrales()
        If modificar = True Then
            cargarModi()
            CargarPtoVta()
            dtactividades.Enabled = True
        End If
        dtactividades.Columns(0).Visible = False
    End Sub

    Private Sub cargarDatosGrales()
        Dim arrayactiv() As String = {}
        Try
            Reconectar()
            conexionPrinc.ChangeDatabase(database)

            'cargamos provincias
            Dim tablaprov As New MySql.Data.MySqlClient.MySqlDataAdapter("select idprovincias,nombre from cm_provincias", conexionPrinc)
            Dim readp As New DataSet
            tablaprov.Fill(readp)
            cmbprovincias.DataSource = readp.Tables(0)
            cmbprovincias.ValueMember = readp.Tables(0).Columns(0).Caption.ToString
            cmbprovincias.DisplayMember = readp.Tables(0).Columns(1).Caption.ToString
            cmbprovincias.SelectedValue = -1

            'cargamos actividades de empresas en el combo
            Dim tablaact As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, nombre from cm_actividades_empresas order by nombre asc", conexionPrinc)
            Dim readac As New DataSet
            tablaact.Fill(readac)
            actividad.DataSource = readac.Tables(0)
            actividad.ValueMember = readac.Tables(0).Columns(0).Caption.ToString
            actividad.DisplayMember = readac.Tables(0).Columns(1).Caption.ToString

            Reconectar()
            If modificar = True Then
                'cargamos actividades de empresas
                Dim lector As System.Data.IDataReader
                Dim sql As New MySql.Data.MySqlClient.MySqlCommand
                sql.Connection = conexionPrinc
                sql.CommandText = "SELECT activ_emp from cm_empresas where idempresas = " & DatosEmpresa.IdEmpresa
                sql.CommandType = CommandType.Text
                lector = sql.ExecuteReader
                lector.Read()
                Dim i As Integer
                Dim consultaextr As String
                Dim acti As String
                If Not IsDBNull(lector("activ_emp")) And lector("activ_emp").ToString <> "" Then
                    acti = lector("activ_emp").ToString
                    arrayactiv = acti.Split(",")

                For i = 0 To arrayactiv.Length - 1
                    If arrayactiv(i) <> "" Then
                        If i = 0 Then

                            consultaextr = " id=" & arrayactiv(i)
                        Else
                            consultaextr &= " or id=" & arrayactiv(i)
                        End If
                    End If
                Next

                Reconectar()
                sql.Connection = conexionPrinc
                sql.CommandText = "select id, nombre, alicuota from cm_actividades_empresas where " & consultaextr
                sql.CommandType = CommandType.Text
                lector = sql.ExecuteReader
                While lector.Read()
                    dtactividades.Rows.Add(lector("id").ToString, lector("nombre").ToString, lector("alicuota").ToString)
                End While
            End If
                dtactividades.Item(1, dtactividades.RowCount - 1) = actividad.Clone
            Else
                dtactividades.Item(1, dtactividades.RowCount - 1) = actividad.Clone
            End If
            Reconectar()

            'cargamos tipo de empresa
            Dim tablatip As New MySql.Data.MySqlClient.MySqlDataAdapter("select distinct(tipo_emp) from cm_empresas", conexionPrinc)
            Dim readtip As New DataSet
            tablatip.Fill(readtip)
            cmbtipoempresas.DataSource = readtip.Tables(0)
            cmbtipoempresas.DisplayMember = readtip.Tables(0).Columns(0).Caption.ToString
            cmbtipoempresas.Text = ""

            'cargamos condicion ante el iva
            Dim tablaivt As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, nombre from cm_condicion_iva", conexionPrinc)
            Dim readivt As New DataSet
            tablaivt.Fill(readivt)
            cmbcondicionesiva.DataSource = readivt.Tables(0)
            cmbcondicionesiva.ValueMember = readivt.Tables(0).Columns(0).Caption.ToString
            cmbcondicionesiva.DisplayMember = readivt.Tables(0).Columns(1).Caption.ToString
            cmbcondicionesiva.SelectedValue = -1

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    
    Private Sub cmdaceptar_Click(sender As Object, e As EventArgs) Handles cmdaceptar.Click
            Dim razon As String
            Dim nombre As String
            Dim cuit As String
            Dim direccion As String
            Dim localidad As String
            Dim provincia As Integer
            Dim telefono As String
            Dim condicio_iva As String
            Dim ing_brutos As String
            Dim num_estab As String
            Dim tipo_emp As String
            Dim activ_emp As String
            Dim tabla As String

            Dim sqlQuery As String
        Try
            If modificar = False Then
                If crear_BD_empresa(database & "_" & reemplazar_espacios(txtrazon.Text.ToLower)) = False Then
                    lblestado.Text = "Hubo un error al crear la empresa" & vbNewLine
                    eliminarBDEMPRESA(database & "_" & reemplazar_espacios(txtrazon.Text.ToLower))
                    Exit Sub
                End If
            End If


            'asignamos los datos a las variables
            razon = txtrazon.Text.ToUpper
            nombre = txtNombre.Text.ToUpper
            cuit = txtcuit.Text
            direccion = txtdireccion.Text.ToUpper
            localidad = txtlocalidad.Text.ToUpper
            provincia = cmbprovincias.SelectedValue
            telefono = txttelefono.Text.ToUpper
            condicio_iva = cmbcondicionesiva.SelectedValue
            ing_brutos = txtingbrutos.Text.ToUpper
            num_estab = txtnumestablec.Text.ToUpper
            tipo_emp = cmbtipoempresas.Text.ToUpper
            activ_emp = cmbactividadesempresas.Text.ToUpper
            tabla = database & "_" & reemplazar_espacios(txtrazon.Text.ToLower)

            If cmbprovincias.SelectedValue = 0 Then
                comando.Connection = conexionPrinc
                comando.CommandText = "insert into cm_provincias (nombre) values('" & cmbprovincias.Text.ToUpper & "') "
                comando.ExecuteReader()
                provincia = comando.LastInsertedId
            End If

            For Each nueva As DataGridViewRow In dtactividades.Rows
                If TypeOf nueva.Cells(1) Is DataGridViewComboBoxCell Then
                    activ_emp &= nueva.Cells(1).Value & ","
                Else
                    activ_emp &= nueva.Cells(0).Value & ","
                End If
            Next
            If dtactividades.RowCount - 1 = 0 Then
                activ_emp = ""
            End If
            If modificar = True Then
                sqlQuery = "update cm_empresas set nombre=?nomb, razon=?razon, cuit=?cuit, direccion=?direc, " _
                    & "localidad=?local, provincia=?prov, telefono=?tel, condicion_iva=?cond, ing_brutos=?brutos, " _
                    & "num_estab=?numest, tipo_emp=?tipemp, activ_emp=?activ " _
                    & " where idempresas=?id"
            Else
                sqlQuery = "insert into cm_empresas (nombre, razon, cuit, direccion, localidad, provincia, telefono, condicion_iva, ing_brutos, num_estab, tipo_emp, activ_emp, tabla)" _
                    & " values(?nomb,?razon,?cuit,?direc,?local,?prov,?tel,?cond,?brutos,?numest,?tipemp,?activ,?tabla)"
            End If
            Reconectar()
            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
            With comandoadd.Parameters
                .AddWithValue("?nomb", nombre)
                .AddWithValue("?razon", razon)
                .AddWithValue("?cuit", cuit)
                .AddWithValue("?direc", direccion)
                .AddWithValue("?local", localidad)
                .AddWithValue("?prov", provincia)
                .AddWithValue("?tel", telefono)
                .AddWithValue("?cond", condicio_iva)
                .AddWithValue("?brutos", ing_brutos)
                .AddWithValue("?numest", num_estab)
                .AddWithValue("?tipemp", tipo_emp)
                .AddWithValue("?activ", activ_emp)

                If modificar = True Then
                    .AddWithValue("?id", DatosEmpresa.IdEmpresa)
                Else
                    .AddWithValue("?tabla", tabla)
                End If
            End With
            comandoadd.ExecuteNonQuery()
            MsgBox("Operacion completada")
            conexionEmp.ChangeDatabase(tabla.ToLower)
            DatosEmpresa.IdEmpresa = comandoadd.LastInsertedId
            EmpDB = tabla.ToLower
            cmbptoventa.Enabled = True
            cmdaddptoveta.Enabled = True
            CargarPtoVta()
            modificar = True
            dtactividades.Enabled = True

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdaddptoveta_Click(sender As Object, e As EventArgs) Handles cmdaddptoveta.Click
        Dim sqlQuery As String
        Reconectar()
        conexionEmp.ChangeDatabase(EmpDB.ToLower)
        If cmbptoventa.Text <> "" Then
            sqlQuery = "insert into iv_punto_venta(nombre) values ('" & cmbptoventa.Text & "')"
            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionEmp)
            comandoadd.ExecuteReader()
        End If
        CargarPtoVta()
    End Sub
    Private Sub CargarPtoVta()
        Try
            'cargamos Ptos de venta
            Reconectar()
            conexionEmp.ChangeDatabase(EmpDB)
            Dim tablaptoVta As New MySql.Data.MySqlClient.MySqlDataAdapter("select nombre from iv_punto_venta", conexionEmp)
            Dim readtablaPtoVta As New DataSet
            tablaptoVta.Fill(readtablaPtoVta)
            cmbptoventa.DataSource = readtablaPtoVta.Tables(0)
            cmbptoventa.DisplayMember = readtablaPtoVta.Tables(0).Columns(0).Caption.ToString
            cmbptoventa.Text = ""
        Catch ex As Exception
        End Try

    End Sub

    Private Sub cargarModi()
        Try
            Dim lector As System.Data.IDataReader
            Dim sql As New MySql.Data.MySqlClient.MySqlCommand
            sql.Connection = conexionPrinc
            sql.CommandText = "select nombre,razon,cuit, direccion, localidad, provincia, telefono, condicion_iva, ing_brutos, num_estab, tipo_emp, activ_emp from cm_empresas where idempresas= " & DatosEmpresa.IdEmpresa
            sql.CommandType = CommandType.Text
            lector = sql.ExecuteReader
            lector.Read()
            cmbtipoempresas.SelectedText = lector("tipo_emp").ToString
            txtrazon.Text = lector("razon").ToString
            txtNombre.Text = lector("nombre").ToString
            txtcuit.Text = lector("cuit").ToString
            txtdireccion.Text = lector("direccion").ToString
            txtlocalidad.Text = lector("localidad").ToString
            cmbprovincias.SelectedValue = lector("provincia")
            txttelefono.Text = lector("telefono").ToString
            cmbcondicionesiva.SelectedValue = lector("condicion_iva")
            txtingbrutos.Text = lector("ing_brutos").ToString
            txtnumestablec.Text = lector("num_estab").ToString
            ''  cmbactividadesempresas.SelectedText = lector("activ_emp").ToString
            cmbptoventa.Enabled = True
            cmdaddptoveta.Enabled = True
        Catch ex As Exception
        End Try

    End Sub

    Private Sub dtactividades_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dtactividades.CellValueChanged
        Try
            If e.ColumnIndex = 1 Then
                Dim col As Integer = e.ColumnIndex
                Dim fil As Integer = e.RowIndex
                Dim idactsel As String = dtactividades.Rows(fil).Cells(col).Value
                Reconectar()
                'MsgBox(col & "," & fil & vbNewLine & dtactividades.Rows(fil).Cells(col).Value)
                Dim lector As System.Data.IDataReader
                Dim sql As New MySql.Data.MySqlClient.MySqlCommand
                sql.Connection = conexionPrinc
                sql.CommandText = "SELECT alicuota from cm_actividades_empresas where id = " & idactsel
                sql.CommandType = CommandType.Text
                lector = sql.ExecuteReader
                lector.Read()
                dtactividades.Rows(fil).Cells(2).Value = lector("alicuota").ToString
                dtactividades.Item(1, dtactividades.RowCount - 1) = actividad.Clone
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Dim activ_emp As String
        For Each nueva As DataGridViewRow In dtactividades.Rows
            If TypeOf nueva.Cells(1) Is DataGridViewComboBoxCell Then
                activ_emp &= nueva.Cells(1).Value & ","
            Else
                If nueva.Cells(0).Value <> "" Then
                    activ_emp &= nueva.Cells(0).Value & ","
                End If
            End If
        Next
        MsgBox(activ_emp)
    End Sub

    Private Sub dtactividades_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtactividades.CellContentClick

    End Sub
End Class