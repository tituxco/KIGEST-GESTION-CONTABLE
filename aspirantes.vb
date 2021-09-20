
Public Class frmaspirantes
    Dim Idpersonal As String
    Dim modificarPers As Boolean
    Dim agregarPers As Boolean

    Dim pag As Integer
    Private BindingSource1 As Windows.Forms.BindingSource = New BindingSource
    Dim idsub As String

    Dim Printenca As Boolean = True
    Dim printExp As Boolean = True
    Dim printForm As Boolean = True
    Dim printCurs As Boolean = True
    Dim printExtra As Boolean = True

    Dim ValorPosicionTab As Integer = 0
    Private Sub frmpersonal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbltitulo.Text = "PERSONAL: " & EmpDB
        cargarDtosGrales()
        CargarPersonal()
        deshabilitarControles(Me)
    End Sub
    Private Sub dtpersonal_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dtpersonal.CellEnter
        vaciarControles()
        Idpersonal = dtpersonal.CurrentRow.Cells.Item(0).Value
        CargarInfoPers()
    End Sub
    Public Sub CargarPersonal()
        pbprogresocons.Visible = True

        Try
            Reconectar()

            conexionEmp.ChangeDatabase(EmpDB)
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select idpersonal as CodINT, concat(apellidos,',  ', nombre) as Nombre from sdo_personal", conexionEmp)
            Dim tablaPers As New DataTable
            'Dim ds As New DataSet

            Dim comando As New MySql.Data.MySqlClient.MySqlCommandBuilder(consulta)
            consulta.Fill(tablaPers)
            BindingSource1.DataSource = tablaPers
            dtpersonal.DataSource = BindingSource1.DataSource
            ' For i = 0 To tabla.Rows.Count - 1
            '     With lstempresas
            ' .Items.Add(tabla.Rows(i)("idempresas"))
            ' With .Items(.Items.Count - 1).SubItems
            ' .Add(tabla.Rows(i)("nombre"))
            ' .Add(tabla.Rows(i)("cuit"))
            ' End With
            '     End With
            ' Next

            pbprogresocons.Visible = False
        Catch ex As Exception
            pbprogresocons.Visible = False
            lblestado.ForeColor = Color.Red
            lblestado.Text = "Atención: " & ex.Message
        End Try
    End Sub

    Private Sub CargarInfoPers()
        Dim imag As Byte()
        Dim idcat As String
        pbprogresocons.Visible = True
        lblestado.Text = ""
        Try
            Reconectar()
            conexionPrinc.ChangeDatabase(database)
            conexionEmp.ChangeDatabase(EmpDB)
            Dim consultainfoPers As New MySql.Data.MySqlClient.MySqlDataAdapter("select legajo, nombre, apellidos,doc_tipo, doc_num, fecha_nac, genero,nacionalidad, num_telefono, " _
            & "num_emergencia, num_celular, email, domicilio, localidad, provincia, estado_civil, categoria, calif_categoria, " _
            & "cuil,fecha_ingreso, fecha_baja, direccion_alt, cuil, modo_contr, jornada, convenio, aportebanco, aportefecha, aporteperiodo, " _
            & "sueldobanco, sueldocuenta, lugarpago from sdo_personal where idpersonal=" & Idpersonal, conexionEmp)
            Dim tablaInfoPers As New DataTable
            consultainfoPers.Fill(tablaInfoPers)


            '***********************************DATOS PERSONALES*********************************************

            txtnombres.Text = tablaInfoPers.Rows(0).Item("nombre").ToString
            txtapellido.Text = tablaInfoPers.Rows(0).Item("apellidos").ToString
            cmbtipodoc.SelectedValue = tablaInfoPers.Rows(0).Item("doc_tipo").ToString
            txtdocumento.Text = tablaInfoPers.Rows(0).Item("doc_num").ToString
            dtpfechanac.Value = tablaInfoPers.Rows(0).Item("fecha_nac").ToString
            cmbnacionalidad.SelectedValue = tablaInfoPers.Rows(0).Item("nacionalidad").ToString
            txttelefono.Text = tablaInfoPers.Rows(0).Item("num_telefono").ToString
            txtcelular.Text = tablaInfoPers.Rows(0).Item("num_celular").ToString
            txtmail.Text = tablaInfoPers.Rows(0).Item("email").ToString
            txtdomicilio.Text = tablaInfoPers.Rows(0).Item("domicilio").ToString
            cmbestadocivil.SelectedValue = tablaInfoPers.Rows(0).Item("estado_civil").ToString
            cmbgenero.SelectedValue = tablaInfoPers.Rows(0).Item("genero").ToString
            cmblocalidad.SelectedValue = tablaInfoPers.Rows(0).Item("localidad").ToString
            cmbprovincia.SelectedValue = tablaInfoPers.Rows(0).Item("provincia").ToString
            dtpaltacurr.Value = tablaInfoPers.Rows(0).Item("fecha_ingreso").ToString
            lbledad.Text = DateDiff(DateInterval.Year, dtpfechanac.Value, Date.Today) & " años"
            'txtobservaciones.Text = lector("observaciones").ToString
            txtdiralt.Text = tablaInfoPers.Rows(0).Item("direccion_alt").ToString
            txtcuil.Text = tablaInfoPers.Rows(0).Item("cuil").ToString
            'txtsueldoacord.Text = lector("sueldo_acord").ToString
            cmbcentro_costos.SelectedValue = tablaInfoPers.Rows(0).Item("convenio").ToString
            cmbjornada.SelectedValue = tablaInfoPers.Rows(0).Item("jornada").ToString
            cmbmodocontratacion.SelectedValue = tablaInfoPers.Rows(0).Item("modo_contr").ToString
            cmbcategoria.SelectedValue = tablaInfoPers.Rows(0).Item("categoria").ToString
            txtbancoaportes.Text = tablaInfoPers.Rows(0).Item("aportebanco").ToString
            txtbancohaberes.Text = tablaInfoPers.Rows(0).Item("sueldobanco").ToString
            txtcuentahaberes.Text = tablaInfoPers.Rows(0).Item("sueldocuenta").ToString
            txtperiodoaportes.Text = tablaInfoPers.Rows(0).Item("aporteperiodo").ToString
            txtfechaAportes.Text = tablaInfoPers.Rows(0).Item("aportefecha").ToString
            txtlugarpago.Text = tablaInfoPers.Rows(0).Item ("lugarpago").ToString
            pbprogresocons.Visible = False

            '**************************INFO EXTRA PARA SUELDO DIGITAL********************************

            Reconectar 
            conexionPrinc.ChangeDatabase(database)
            conexionEmp.ChangeDatabase(EmpDB)
            'sql.Connection = conexionEmp

            'sql.CommandText = "SELECT * FROM sdo_personal_infoLSD where idpersonal=" & Idpersonal

            'sql.CommandType = CommandType.Text
            'lector = sql.ExecuteReader
            'lector.Read()

            Dim consultainfoExtra As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT * FROM sdo_personal_infoLSD where idpersonal=" & Idpersonal, conexionEmp)
            Dim tablaInfoExtra As New DataTable
            consultainfoExtra.Fill(tablaInfoExtra)

            If tablaInfoExtra.Rows.Count = 0 Then
                Exit Sub
            End If
            'MsgBox(tablaInfoExtra.Rows(0).Item("cod_localidad"))
            chkLSDConvColectTrab.CheckState = tablaInfoExtra.Rows(0).Item("adherido_cct").ToString
            chkLSDReduccion.CheckState = tablaInfoExtra.Rows(0).Item("corresponde_reduccion").ToString
            chkLSDSegVidaOblig.CheckState = tablaInfoExtra.Rows(0).Item("cobertura_scvo").ToString
            cmbLSDActividadEmpleado.SelectedValue = tablaInfoExtra.Rows(0).Item("activ_empleado").ToString
            cmbLSDCodigoLocalidades.SelectedValue = tablaInfoExtra.Rows(0).Item("cod_localidad").ToString
            cmbLSDCodigoObraSocial.SelectedValue = tablaInfoExtra.Rows(0).Item("cod_obraSocial").ToString
            cmbLSDCodigosCondicion.SelectedValue = tablaInfoExtra.Rows(0).Item("cod_condicion").ToString
            cmbLSDConyuge.SelectedValue = tablaInfoExtra.Rows(0).Item("conyuge").ToString
            cmbLSDFormaPago.SelectedValue = tablaInfoExtra.Rows(0).Item("forma_pago").ToString
            cmbLSDModoContratacion.SelectedValue = tablaInfoExtra.Rows(0).Item("modalidad_contratacion").ToString
            cmbLSDSituacionRevista.SelectedValue = tablaInfoExtra.Rows(0).Item("situacion_revista").ToString
            cmbLSDTipoEmpresa.SelectedValue = tablaInfoExtra.Rows(0).Item("tipo_empresa").ToString
            txtLSDAdherentes.Text = tablaInfoExtra.Rows(0).Item("cant_adherentes").ToString
            txtLSDCantHijos.Text = tablaInfoExtra.Rows(0).Item("cant_hijos").ToString

        Catch ex As Exception
            pbprogresocons.Visible = False
            lblestado.ForeColor = Color.Red
            lblestado.Text = "Atención: " & ex.Message
        End Try

    End Sub
    Private Sub cargarDtosGrales()
        pbprogresocons.Visible = True
        Try
            Reconectar()
            conexionPrinc.ChangeDatabase(database)
            conexionEmp.ChangeDatabase(EmpDB)
            Dim tablaestadoC As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from cm_estado_civil order by nombre asc", conexionPrinc)
            Dim tablatipoDoc As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from cm_doc_tipo order by nombre asc", conexionPrinc)
            Dim tablagenero As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from cm_genero order by nombre asc", conexionPrinc)
            Dim tablanacionalidad As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from cm_nacionalidad order by nombre asc", conexionPrinc)
            Dim tablalocalidad As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from cm_localidad order by nombre asc", conexionPrinc)
            Dim tablaprovincia As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from cm_provincias order by nombre asc", conexionPrinc)
            Dim tablaCARNET As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from cm_tipo_carnet order by nombre asc", conexionPrinc)
            Dim tablaGrsang As New MySql.Data.MySqlClient.MySqlDataAdapter("select distinct(gr_sang) from sdo_personal", conexionPrinc)
            Dim tablaCatTra As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from cm_sdo_categoria_personal", conexionPrinc)
            Dim tablaModocontr As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from cm_sdo_modo_contratacion", conexionPrinc)
            Dim tablaJornada As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from cm_sdo_jornada", conexionPrinc)
            Dim tablacostos As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, nombre from cm_sdo_convenios", conexionPrinc)
            Dim readcostos As New DataSet
            Dim readjornada As New DataSet
            Dim readmodoContr As New DataSet
            Dim readcatTR As New DataSet
            Dim readGS As New DataSet
            Dim reades As New DataSet
            Dim readtd As New DataSet
            Dim readg As New DataSet
            Dim readn As New DataSet
            Dim readloc As New DataSet
            Dim readpro As New DataSet
            Dim readcar As New DataSet


            'cargamos estado civil
            tablaestadoC.Fill(reades)
            cmbestadocivil.DataSource = reades.Tables(0)
            cmbestadocivil.DisplayMember = reades.Tables(0).Columns(1).Caption.ToString
            cmbestadocivil.ValueMember = reades.Tables(0).Columns(0).Caption.ToString
            cmbestadocivil.SelectedIndex = -1

            'cargamos tipos de documentos
            tablatipoDoc.Fill(readtd)
            cmbtipodoc.DataSource = readtd.Tables(0)
            cmbtipodoc.DisplayMember = readtd.Tables(0).Columns(1).Caption.ToString
            cmbtipodoc.ValueMember = readtd.Tables(0).Columns(0).Caption.ToString
            cmbtipodoc.SelectedIndex = -1

            'cargamos generos
            tablagenero.Fill(readg)
            cmbgenero.DataSource = readg.Tables(0)
            cmbgenero.DisplayMember = readg.Tables(0).Columns(1).Caption.ToString
            cmbgenero.ValueMember = readg.Tables(0).Columns(0).Caption.ToString
            cmbgenero.SelectedIndex = -1

            'cargamos nacionalidad
            tablanacionalidad.Fill(readn)
            cmbnacionalidad.DataSource = readn.Tables(0)
            cmbnacionalidad.DisplayMember = readn.Tables(0).Columns(1).Caption.ToString
            cmbnacionalidad.ValueMember = readn.Tables(0).Columns(0).Caption.ToString
            cmbnacionalidad.SelectedIndex = -1

            'cargamos localidades
            tablalocalidad.Fill(readloc)
            cmblocalidad.DataSource = readloc.Tables(0)
            cmblocalidad.DisplayMember = readloc.Tables(0).Columns(1).Caption.ToString
            cmblocalidad.ValueMember = readloc.Tables(0).Columns(0).Caption.ToString
            cmblocalidad.SelectedIndex = -1

            'cargamos provincias
            tablaprovincia.Fill(readpro)
            cmbprovincia.DataSource = readpro.Tables(0)
            cmbprovincia.DisplayMember = readpro.Tables(0).Columns(1).Caption.ToString
            cmbprovincia.ValueMember = readpro.Tables(0).Columns(0).Caption.ToString
            cmbprovincia.SelectedIndex = -1
            pbprogresocons.Visible = False



            'cargamos modo de contratacion o periodo de pago
            tablaModocontr.Fill(readmodoContr)
            cmbmodocontratacion.DataSource = readmodoContr.Tables(0)
            cmbmodocontratacion.DisplayMember = readmodoContr.Tables(0).Columns(1).Caption.ToString
            cmbmodocontratacion.ValueMember = readmodoContr.Tables(0).Columns(0).Caption.ToString
            cmbmodocontratacion.SelectedIndex = -1

            'cargamos jornada contratada
            tablaJornada.Fill(readjornada)
            cmbjornada.DataSource = readjornada.Tables(0)
            cmbjornada.DisplayMember = readjornada.Tables(0).Columns(1).Caption.ToString
            cmbjornada.ValueMember = readjornada.Tables(0).Columns(0).Caption.ToString
            cmbjornada.SelectedIndex = -1

            'cargamos centro de costos
            tablacostos.Fill(readcostos)
            cmbcentro_costos.DataSource = readcostos.Tables(0)
            cmbcentro_costos.DisplayMember = readcostos.Tables(0).Columns(1).Caption.ToString
            cmbcentro_costos.ValueMember = readcostos.Tables(0).Columns(0).Caption.ToString
            cmbcentro_costos.SelectedIndex = -1


            cmbLSDTipoEmpresa.DataSource = tiposEmpresa
            cmbLSDTipoEmpresa.DisplayMember = "Descripcion"
            cmbLSDTipoEmpresa.ValueMember = "Codigo"


            cmbLSDSituacionRevista.DataSource = situacionRevista
            cmbLSDSituacionRevista.DisplayMember = "Descripcion"
            cmbLSDSituacionRevista.ValueMember = "Codigo"


            cmbLSDCodigosCondicion.DataSource = codCondicion
            cmbLSDCodigosCondicion.DisplayMember = "Descripcion"
            cmbLSDCodigosCondicion.ValueMember = "Codigo"


            cmbLSDActividadEmpleado.DataSource = actividadesEmpleados
            cmbLSDActividadEmpleado.DisplayMember = "Descripcion"
            cmbLSDActividadEmpleado.ValueMember = "Codigo"


            cmbLSDModoContratacion.DataSource = modoContratacion
            cmbLSDModoContratacion.DisplayMember = "Descripcion"
            cmbLSDModoContratacion.ValueMember = "Codigo"


            cmbLSDCodigoSiniestrado.DataSource = codSiniestrados
            cmbLSDCodigoSiniestrado.DisplayMember = "Descripcion"
            cmbLSDCodigoSiniestrado.ValueMember = "Codigo"


            cmbLSDCodigoLocalidades.DataSource = codLocalidades
            cmbLSDCodigoLocalidades.DisplayMember = "Descripcion"
            cmbLSDCodigoLocalidades.ValueMember = "Codigo"


            cmbLSDCodigoObraSocial.DataSource = codObrasSociales
            cmbLSDCodigoObraSocial.DisplayMember = "Descripcion"
            cmbLSDCodigoObraSocial.ValueMember = "Codigo"


            cmbLSDFormaPago.DataSource = formasDePago
            cmbLSDFormaPago.DisplayMember = "Descripcion"
            cmbLSDFormaPago.ValueMember = "Codigo"

            cmbLSDConyuge.DataSource = afirmativoNegativo
            cmbLSDConyuge.DisplayMember = "Descripcion"
            cmbLSDConyuge.ValueMember = "Codigo"

            pbprogresocons.Visible = False
        Catch ex As Exception
            pbprogresocons.Visible = False
            lblestado.ForeColor = Color.Red
            lblestado.Text = "Atención: " & ex.Message
        End Try

    End Sub
    Private Sub deshabilitarControles(ByVal thisform As System.Windows.Forms.Form)
        For Each Cont As Control In TabPage1.Controls
            If TypeOf Cont Is TextBox Then
                Dim tex As TextBox
                tex = Cont
                If tex.ReadOnly = True Then
                    tex.ReadOnly = False
                Else
                    tex.ReadOnly = True
                End If

            ElseIf TypeOf Cont Is ComboBox Then
                Dim cbo As ComboBox
                cbo = Cont
                If cbo.Enabled = False Then
                    cbo.Enabled = True
                Else
                    cbo.Enabled = False
                End If
            End If
        Next
        For Each Cont As Control In TabPage2.Controls
            If TypeOf Cont Is TextBox Then
                Dim tex As TextBox
                tex = Cont
                If tex.ReadOnly = True Then
                    tex.ReadOnly = False
                Else
                    tex.ReadOnly = True
                End If

            ElseIf TypeOf Cont Is ComboBox Then
                Dim cbo As ComboBox
                cbo = Cont
                If cbo.Enabled = False Then
                    cbo.Enabled = True
                Else
                    cbo.Enabled = False
                End If
            End If
        Next
        For Each Cont As Control In TabPage3.Controls
            If TypeOf Cont Is TextBox Then
                Dim tex As TextBox
                tex = Cont
                If tex.ReadOnly = True Then
                    tex.ReadOnly = False
                Else
                    tex.ReadOnly = True
                End If

            ElseIf TypeOf Cont Is ComboBox Then
                Dim cbo As ComboBox
                cbo = Cont
                If cbo.Enabled = False Then
                    cbo.Enabled = True
                Else
                    cbo.Enabled = False
                End If
            End If
        Next
    End Sub

    Private Function Buscar(
            ByVal Columna As String,
            ByVal texto As String,
            ByVal BindingSource As BindingSource) As Integer

        Try
            ' si está vacio salir y no retornar nada  
            If BindingSource1.DataSource Is Nothing Then
                Return -1
            End If

            ' Ejecutar el método Find pasándole los datos  
            Dim fila As Integer = BindingSource.Find(Columna.Trim, texto)

            ' Mover el cursor a la fila obtenida  
            BindingSource.Position = fila

            ' retornar el valor  
            Return fila

            ' errores  
        Catch ex As Exception
            pbprogresocons.Visible = False
            lblestado.ForeColor = Color.Red
            lblestado.Text = "Atención: " & ex.Message
        End Try
        ' no retornar nada  
        Return -1

    End Function

    Private Sub cmdeliminar_Click(sender As Object, e As EventArgs) Handles cmdmodificar.Click
        pbprogresocons.Visible = True
        modificarPers = True
        cmdmodificar.Enabled = False
        cmdnuevapers.Enabled = False
        cmdaceptar.Enabled = True
        deshabilitarControles(Me)
        dtpersonal.Enabled = False
        pbprogresocons.Visible = False
        CargarDatosMODADD()
        'dtexperiencialab.Height = 260
    End Sub

    Private Sub cmdcancelar_Click(sender As Object, e As EventArgs) Handles cmdcancelar.Click
        Me.Close()
    End Sub

    Private Sub CargarDatosMODADD()
        pbprogresocons.Visible = True
        Reconectar()
        Try
            pbprogresocons.Visible = False
        Catch ex As Exception
            pbprogresocons.Visible = False
            lblestado.ForeColor = Color.Red
            lblestado.Text = "Atención: " & ex.Message
        End Try
    End Sub


    Private Sub cmdaceptar_Click(sender As Object, e As EventArgs) Handles cmdaceptar.Click
        Dim sqlQuery As String
        Dim nombres As String
        Dim apellido As String
        Dim tipodoc As Integer
        Dim nodocumento As String
        Dim fechanac As String
        Dim genero As Integer
        Dim nacionalidad As String
        Dim telefono As String
        Dim celular As String
        Dim fcurriculum As String
        Dim mail As String
        Dim domicilio As String
        Dim localidad As Integer
        Dim provincia As Integer
        Dim convenio As Integer
        Dim estadocivil As Integer

        Dim dir_alt As String
        Dim cuil As String
        Dim categoria As Integer
        Dim sueldoBase As String
        Dim modo_contratacion As Integer
        Dim jornada As Integer
        Dim sueldoAcord As String
        Dim foto As Byte()
        Dim aportebanco As String
        Dim aportefecha As String
        Dim aporteperiodo As String
        Dim sueldobanco As String
        Dim sueldocuenta As String
        Dim lugarpago As String
        pbprogresocons.Visible = True

        Reconectar()

        Try
            foto = Imagen_Bytes(pctfoto.Image)
            nombres = txtnombres.Text.ToUpper
            apellido = txtapellido.Text.ToUpper
            tipodoc = cmbtipodoc.SelectedValue
            nodocumento = txtdocumento.Text
            fechanac = Format(dtpfechanac.Value, "yyyy-MM-dd")
            If cmbgenero.SelectedValue = 0 Then
                MsgBox("debe seleccionar un genero")
                Exit Sub
            End If
            genero = cmbgenero.SelectedValue
            nacionalidad = cmbnacionalidad.SelectedValue
            telefono = txttelefono.Text
            celular = txtcelular.Text
            fcurriculum = Format(dtpaltacurr.Value, "yyyy-MM-dd")
            mail = txtmail.Text.ToLower
            domicilio = txtdomicilio.Text.ToUpper
            localidad = cmblocalidad.SelectedValue
            If cmbprovincia.SelectedValue = 0 Then
                MsgBox("Debe seleccionar una provincia")
                Exit Sub
            End If
            provincia = cmbprovincia.SelectedValue

            If cmbestadocivil.SelectedValue = 0 Then
                MsgBox("debe seleccionar un estado civil")
                Exit Sub
            End If
            estadocivil = cmbestadocivil.SelectedValue

            dir_alt = txtdiralt.Text.ToUpper
            cuil = txtcuil.Text

            categoria = cmbcategoria.SelectedValue
            sueldoBase = txtsueldoBase.Text
            modo_contratacion = cmbmodocontratacion.SelectedValue
            jornada = cmbjornada.SelectedValue
            convenio = cmbcentro_costos.SelectedValue
            aportebanco = txtbancoaportes.Text.ToUpper
            aportefecha = txtfechaAportes.Text
            aporteperiodo = txtperiodoaportes.Text.ToUpper
            sueldobanco = txtbancohaberes.Text.ToUpper
            sueldocuenta = txtcuentahaberes.Text.ToUpper
            lugarpago = txtlugarpago.Text.ToUpper
            'sueldoAcord = txtsueldoacord.Text
            If comprobarCamposObligatorios() = True Then
                MsgBox("Hay campos obligatorios que no fueron completados, por favor verifique")
                Exit Sub
            End If
            Reconectar()

            'verificamos los combos seleccionados, si no se selecciono ninguno, lo agregamos

            If nacionalidad = 0 Then
                'MsgBox("no se selecciono nacionalidad, se agregara")
                comando.Connection = conexionPrinc
                comando.CommandText = "insert into cm_nacionalidad (nombre) values('" & cmbnacionalidad.Text.ToUpper & "')"
                comando.ExecuteReader()
                nacionalidad = comando.LastInsertedId
            End If
            Reconectar()

            If localidad = 0 Then
                'MsgBox("no se selecciono localidad, se agregara")
                comando.Connection = conexionPrinc
                comando.CommandText = "insert into cm_localidad (nombre) values('" & cmblocalidad.Text.ToUpper & "')"
                comando.ExecuteReader()
                localidad = comando.LastInsertedId
            End If
            Reconectar()

            If estadocivil = 0 Then
                'MsgBox("No se selecciono estado civil")
                comando.Connection = conexionPrinc
                comando.CommandText = "insert into cm_estado_civil(nombre) values ('" & cmbestadocivil.Text.ToUpper & "')"
                comando.ExecuteReader(3)
                estadocivil = comando.LastInsertedId
            End If
            Reconectar()

            If cmbcentro_costos.Text = "" And cmbcategoria.Text = "" Then
                MsgBox("debe ingresar o seleccionar un convenio y una categoria")
                Exit Sub
            ElseIf cmbcentro_costos.Text = "" And cmbcategoria.Text <> "" Then
                MsgBox("debe ingresar o seleccionar un convenio")
                Exit Sub
            ElseIf cmbcentro_costos.Text <> "" And cmbcategoria.Text = "" Then
                MsgBox("debe ingresar o seleccionar una categoria")
                Exit Sub
            ElseIf convenio = 0 And categoria = 0 Then
                'msgbox("No se selecciono categoria")
                comando.Connection = conexionPrinc
                comando.CommandText = "insert into cm_sdo_convenios(nombre) values ('" & cmbcentro_costos.Text.ToUpper & "')"
                comando.ExecuteReader()
                convenio = comando.LastInsertedId

                Reconectar()

                comando.Connection = conexionPrinc
                comando.CommandText = "insert into cm_sdo_categoria_personal(nombre,idconvenio) values ('" & cmbcategoria.Text.ToUpper & "','" & convenio & "')"
                comando.ExecuteReader()
                categoria = comando.LastInsertedId
            ElseIf convenio <> 0 And categoria = 0 Then

                comando.Connection = conexionPrinc
                comando.CommandText = "insert into cm_sdo_categoria_personal(nombre,idconvenio) values ('" & cmbcategoria.Text.ToUpper & "','" & convenio & "')"
                comando.ExecuteReader()
                categoria = comando.LastInsertedId
            End If
            If categoria = 0 Or convenio = 0 Then
                MsgBox("No hay categoria o convenio seleccionado o ingresado")
                Exit Sub
            End If

            If modificarPers = False Then
                If ComprobarAspirante(nodocumento) = False Then
                    MsgBox("Ya existe un aspirante con este numero de documento, por favor verifique")
                    Exit Sub
                End If
                sqlQuery = "insert into sdo_personal " _
                & "(nombre, apellidos, genero, doc_tipo, doc_num, fecha_nac, nacionalidad, num_telefono, num_celular, email, domicilio, localidad, " _
                & "provincia, estado_civil, fecha_ingreso,direccion_alt, cuil, categoria, modo_contr, jornada,convenio,empresa, aportebanco, " _
                & "aportefecha, aporteperiodo,sueldobanco, sueldocuenta, lugarpago) values " _
                & "(?nomb, ?ape, ?gen,?dt,?dn,?fn,?nac,?nt,?nc,?mail,?dom,?loc,?pro,?ec,?ac,?dalt,?cuil,?categ,?modocont,?jornada,?convenio, " _
                & "?empresa,?apbanco, ?apfecha, ?apperiodo, ?sdobanco, ?sdocuenta,?lugarpago)"
            ElseIf modificarPers = True Then
                sqlQuery = "update sdo_personal set nombre=?nomb, apellidos=?ape, genero=?gen, doc_tipo=?dt, doc_num=?dn, fecha_nac=?fn, " _
                    & "nacionalidad=?nac, num_telefono=?nt, num_celular=?nc, email=?mail, domicilio=?dom, localidad=?loc, provincia=?pro," _
                    & "estado_civil=?ec, fecha_ingreso=?ac, direccion_alt=?dalt, cuil=?cuil, categoria=?categ, " _
                    & "jornada=?jornada,modo_contr=?modocont, convenio=?convenio,  " _
                    & "aportebanco=?apbanco, aportefecha=?apfecha, aporteperiodo=?apperiodo, sueldobanco=?sdobanco, sueldocuenta=?sdocuenta,  " _
                    & "lugarpago=?lugarpago where idpersonal=?idp"
            End If
            Reconectar()

            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionEmp)

            With comandoadd.Parameters
                .AddWithValue("?nomb", nombres)
                .AddWithValue("?ape", apellido)
                .AddWithValue("?gen", genero)
                .AddWithValue("?dt", tipodoc)
                .AddWithValue("?dn", nodocumento)
                .AddWithValue("?fn", fechanac)
                .AddWithValue("?nac", nacionalidad)
                .AddWithValue("?nt", telefono)
                .AddWithValue("?nc", celular)
                .AddWithValue("?mail", mail)
                .AddWithValue("?dom", domicilio)
                .AddWithValue("?loc", localidad)
                .AddWithValue("?pro", provincia)
                .AddWithValue("?ec", estadocivil)
                .AddWithValue("?cuil", cuil)
                .AddWithValue("?ac", fcurriculum)
                .AddWithValue("?categ", categoria)
                .AddWithValue("?modocont", modo_contratacion)
                .AddWithValue("?dalt", dir_alt)
                .AddWithValue("?jornada", jornada)
                .AddWithValue("?convenio", convenio)
                .AddWithValue("?empresa", DatosEmpresa.IdEmpresa)
                .AddWithValue("?apbanco", aportebanco)
                .AddWithValue("?apfecha", aportefecha)
                .AddWithValue("?apperiodo", aporteperiodo)
                .AddWithValue("?sdobanco", sueldobanco)
                .AddWithValue("?sdocuenta", sueldocuenta)
                .AddWithValue("?lugarpago", lugarpago)
                If modificarPers = True Then
                    .AddWithValue("?idp", Idpersonal)
                End If
            End With
            comandoadd.ExecuteNonQuery()
            Dim IdPersInfoExtra As Integer
            If modificarPers = True Then
                IdPersInfoExtra = Idpersonal
            Else
                IdPersInfoExtra = comandoadd.LastInsertedId
            End If
            Reconectar()
            'Dim IDPersonal = comandoadd.LastInsertedId
            Dim SqlQueryInfoLSD As String = "INSERT INTO sdo_personal_infoLSD
            (idpersonal,conyuge,cant_hijos,cant_adherentes,forma_pago,adherido_cct,cobertura_scvo,corresponde_reduccion,tipo_empresa,
            situacion_revista,cod_condicion,activ_empleado,modalidad_contratacion,cod_siniestrado,cod_localidad,cod_obraSocial)
            VALUES('" & IdPersInfoExtra & "','" & cmbLSDConyuge.SelectedValue & "','" & txtLSDCantHijos.Text & "','" & txtLSDAdherentes.Text & "',
            '" & cmbLSDFormaPago.SelectedValue & "','" & chkLSDConvColectTrab.CheckState & "','" & chkLSDSegVidaOblig.CheckState & "',
            '" & chkLSDReduccion.CheckState & "','" & cmbLSDTipoEmpresa.SelectedValue & "','" & cmbLSDSituacionRevista.SelectedValue & "',
            '" & cmbLSDCodigosCondicion.SelectedValue & "','" & cmbLSDActividadEmpleado.SelectedValue & "', '" & cmbLSDModoContratacion.SelectedValue & "',
            '" & cmbLSDCodigoSiniestrado.SelectedValue & "','" & cmbLSDCodigoLocalidades.SelectedValue & "','" & cmbLSDCodigoObraSocial.SelectedValue & "')
            ON DUPLICATE KEY UPDATE
            conyuge ='" & cmbLSDConyuge.SelectedValue & "',
            cant_hijos = '" & txtLSDCantHijos.Text & "',
            cant_adherentes = '" & txtLSDAdherentes.Text & "',
            forma_pago = '" & cmbLSDFormaPago.SelectedValue & "',
            adherido_cct = '" & chkLSDConvColectTrab.CheckState & "',
            cobertura_scvo = '" & chkLSDSegVidaOblig.CheckState & "',
            corresponde_reduccion = '" & chkLSDReduccion.CheckState & "',
            tipo_empresa = '" & cmbLSDTipoEmpresa.SelectedValue & "',
            situacion_revista = '" & cmbLSDSituacionRevista.SelectedValue & "',
            cod_condicion = '" & cmbLSDCodigosCondicion.SelectedValue & "',
            activ_empleado = '" & cmbLSDActividadEmpleado.SelectedValue & "',
            modalidad_contratacion = '" & cmbLSDModoContratacion.SelectedValue & "',
            cod_siniestrado = '" & cmbLSDCodigoSiniestrado.SelectedValue & "',
            cod_localidad = '" & cmbLSDCodigoLocalidades.SelectedValue & "',
            cod_obraSocial = '" & cmbLSDCodigoObraSocial.SelectedValue & "'"

            Dim comandoaddInfoLSD As New MySql.Data.MySqlClient.MySqlCommand(SqlQueryInfoLSD, conexionEmp)
            comandoaddInfoLSD.ExecuteNonQuery()
            If modificarPers = True Then
                lblestado.ForeColor = Color.GreenYellow
                lblestado.Text = "Personal Modificado correctamente"
                TabControl1.SelectedTab = TabPage1
                dtpersonal.Enabled = False
            ElseIf modificarPers = False Then
                lblestado.ForeColor = Color.GreenYellow
                lblestado.Text = "Personal agregado correctamente"
                CargarPersonal()
                Idpersonal = comandoadd.LastInsertedId
                Dim i As Integer
                For i = 0 To dtpersonal.Rows.Count - 1
                    If dtpersonal.Item(0, i).Value = Idpersonal Then
                        dtpersonal.Rows(i).Selected = True
                    End If
                Next
                CargarInfoPers()
                dtpersonal.Enabled = False
            End If
            pbprogresocons.Visible = False
        Catch ex As Exception
            pbprogresocons.Visible = False
            lblestado.ForeColor = Color.Red
            lblestado.Text = "Atención: " & ex.Message
        End Try
        cargarDtosGrales()
        modificarPers = False
        cmdmodificar.Enabled = True
        cmdnuevapers.Enabled = True
        cmdaceptar.Enabled = False
        dtpersonal.Enabled = True
        lblestado.Text = ""
        deshabilitarControles(Me)
    End Sub

    Private Sub vaciarControles()

        For Each Cont As Control In TabPage1.Controls
            If TypeOf Cont Is TextBox Then
                Dim tex As TextBox
                tex = Cont
                tex.Text = ""

            ElseIf TypeOf Cont Is ComboBox Then
                Dim cbo As ComboBox
                cbo = Cont
                cbo.SelectedIndex = -1

            ElseIf TypeOf Cont Is CheckBox Then
            Dim chk As CheckBox
            chk = Cont
            chk.Checked = False
            End If
        Next
        For Each Cont As Control In TabPage2.Controls
            If TypeOf Cont Is TextBox Then
                Dim tex As TextBox
                tex = Cont
                tex.Text = ""

            ElseIf TypeOf Cont Is ComboBox Then
                Dim cbo As ComboBox
                cbo = Cont
                cbo.SelectedIndex = -1
            ElseIf TypeOf Cont Is CheckBox Then
                Dim chk As CheckBox
                chk = Cont
                chk.Checked = False
            End If
        Next
        For Each Cont As Control In TabPage3.Controls
            If TypeOf Cont Is TextBox Then
                Dim tex As TextBox
                tex = Cont
                tex.Text = ""

            ElseIf TypeOf Cont Is ComboBox Then
                Dim cbo As ComboBox
                cbo = Cont
                cbo.SelectedIndex = -1
            ElseIf TypeOf Cont Is CheckBox Then
                Dim chk As CheckBox
                chk = Cont
                chk.Checked = False
            End If
        Next


        'txtdiralt.Text = ""
        'txtnombres.Text = ""
        'txtapellido.Text = ""
        'txtdocumento.Text = ""
        'txtdomicilio.Text = ""
        'txtmail.Text = ""
        'txttelefono.Text = ""

        'txtcelular.Text = ""
        'cmbestadocivil.SelectedIndex = -1
        'cmbgenero.SelectedIndex = -1
        'cmblocalidad.SelectedIndex = -1
        'cmbnacionalidad.SelectedIndex = -1
        'cmbprovincia.SelectedIndex = -1
        'cmbtipodoc.SelectedIndex = -1
        dtpfechanac.Value = Now
        dtpaltacurr.Value = Now
    End Sub

    Private Sub cmdadddpers_Click(sender As Object, e As EventArgs)



    End Sub

    Private Sub abrir_imagen()
        Dim filename As String
        Dim openfiler As New OpenFileDialog
        'Definiendo propiedades al openfiledialog
        With openfiler
            'directorio inicial
            .InitialDirectory = "C:\"
            'archivos que se pueden abrir
            .Filter = "Archivos de imágen(*.jpg)|*.jpg|All Files (*.*)|*.*"
            'indice del archivo de lectura por defecto
            .FilterIndex = 1
            'restaurar el directorio al cerrar el dialogo
            .RestoreDirectory = True
        End With
        'Evalua si el usuario hace click en el boton abrir
        If openfiler.ShowDialog = Windows.Forms.DialogResult.OK Then
            'Obteniendo la ruta completa del archivo xml
            filename = openfiler.FileName
            Me.pctfoto.Image = Image.FromFile(filename)
        End If
    End Sub

    Private Sub cmdimagen_Click(sender As Object, e As EventArgs) Handles cmdimagen.Click
        abrir_imagen()
    End Sub

    Private Sub dtpfechanac_ValueChanged(sender As Object, e As EventArgs) Handles dtpfechanac.ValueChanged
        lbledad.Text = DateDiff(DateInterval.Year, dtpfechanac.Value, Date.Today) & " años"
    End Sub


    Private Function ComprobarAspirante(ByRef dni As String) As Boolean
        pbprogresocons.Visible = True
        Try
            Reconectar()
            Dim lector As System.Data.IDataReader
            Dim sql As New MySql.Data.MySqlClient.MySqlCommand
            Dim i As Integer = 0

            sql.Connection = conexionEmp
            sql.CommandText = "select * from sdo_personal where doc_num like '" & dni & "'"
            sql.CommandType = CommandType.Text
            lector = sql.ExecuteReader
            While lector.Read()
                i += 1
            End While
            If i <> 0 Then
                Return False
            Else
                Return True
            End If
            pbprogresocons.Visible = False
        Catch ex As Exception
            pbprogresocons.Visible = False
            lblestado.ForeColor = Color.Red
            lblestado.Text = "Atención: " & ex.Message
        End Try

    End Function

    Private Sub txtbuscar_KeyUp(sender As Object, e As KeyEventArgs) Handles txtbuscar.KeyUp
        'BindingSource1.Filter = "Nombre LIKE " & txtbuscar.Text
        'BindingSource1.Filter = "Nombre Like '%" & txtbuscar.Text & "%'"
    End Sub
    Private Function comprobarCamposObligatorios() As Boolean
        If txtnombres.Text = "" Then Return True
        If txtapellido.Text = "" Then Return True
        If cmbtipodoc.Text = "" Then Return True
        If txtdocumento.Text = "" Then Return True
        If cmbgenero.Text = "" Then Return True
        If cmbestadocivil.Text = "" Then Return True
        If cmbnacionalidad.Text = "" Then Return True
        If txtdomicilio.Text = "" Then Return True
        If cmblocalidad.Text = "" Then Return True
        If cmbprovincia.Text = "" Then Return True
    End Function
    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Reconectar()
            If MsgBox("Esta seguro que desea eliminar este Empleado?, se borraran todos los datos asociados a él?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Eliminar Aspirante") = MsgBoxResult.Ok Then
                comando.Connection = conexionEmp
                comando.CommandText = "DELETE from sdo_personal where idpersonal=" & Idpersonal
                comando.ExecuteReader()
                CargarPersonal()
                lblestado.ForeColor = Color.GreenYellow
                lblestado.Text = "Se elimino correctamente"
            End If

        Catch ex As Exception
            pbprogresocons.Visible = False
            lblestado.ForeColor = Color.Red
            lblestado.Text = "Atención: " & ex.Message
        End Try
    End Sub

    Private Sub cmdnuevapers_Click(sender As Object, e As EventArgs) Handles cmdnuevapers.Click
        deshabilitarControles(Me)
        modificarPers = False
        cmdmodificar.Enabled = False
        cmdnuevapers.Enabled = False
        cmdaceptar.Enabled = True
        dtpersonal.Enabled = False
        pctfoto.ImageLocation = Application.StartupPath & "\noimagen.jpg"
        vaciarControles()
        txtnombres.Focus()
    End Sub

    Private Sub cmbcategoria_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbcategoria.SelectedValueChanged
        'Dim lector As System.Data.IDataReader
        'Dim sql As New MySql.Data.MySqlClient.MySqlCommand
        'Try
        'If cmbcategoria.SelectedValue <> 0 Then
        'Reconectar()

        'conexionEmp.ChangeDatabase(EmpDB)
        'Sql.Connection = conexionEmp

        'Sql.CommandText = "select sueldo_base from sdo_categoria_personal where idcategoria_personal=" & cmbcategoria.SelectedValue
        'Sql.CommandType = CommandType.Text
        'lector = Sql.ExecuteReader
        'lector.Read()
        'txtsueldoBase.Text = lector("sueldo_base").ToString
        'End If
        'Catch ex As Exception
        'MsgBox(ex.Message)
        'End Try

    End Sub

    Private Sub dtpaltacurr_ValueChanged(sender As Object, e As EventArgs) Handles dtpaltacurr.ValueChanged
        lblantiguedad.Text = DateDiff(DateInterval.Year, dtpaltacurr.Value, Date.Today) & " años"
    End Sub


    Private Sub cmbcentro_costos_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbcentro_costos.SelectionChangeCommitted

    End Sub

    Private Sub TabPage3_Enter(sender As Object, e As EventArgs) Handles TabPage3.Enter




    End Sub

    Private Sub TabPage3_Click(sender As Object, e As EventArgs) Handles TabPage3.Click

    End Sub

    Private Sub cmbLSDSituacionRevista_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLSDSituacionRevista.SelectedIndexChanged

    End Sub

    Private Sub dtpersonal_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtpersonal.CellContentClick

    End Sub

    Private Sub cmbcentro_costos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbcentro_costos.SelectedIndexChanged

    End Sub

    Private Sub cmbcentro_costos_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbcentro_costos.SelectedValueChanged
        Try
            Dim idcentro As Integer = Val(cmbcentro_costos.SelectedValue)
            'MsgBox()
            If IsNumeric(idcentro) Then
                Dim tablaCatTra As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from cm_sdo_categoria_personal where idconvenio = " & cmbcentro_costos.SelectedValue, conexionPrinc)
                Dim readcatTR As New DataSet
                'cargamos categorias de trabajo
                tablaCatTra.Fill(readcatTR)
                cmbcategoria.DataSource = readcatTR.Tables(0)
                cmbcategoria.DisplayMember = readcatTR.Tables(0).Columns(1).Caption.ToString
                cmbcategoria.ValueMember = readcatTR.Tables(0).Columns(0).Caption.ToString
                cmbcategoria.SelectedIndex = -1
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class