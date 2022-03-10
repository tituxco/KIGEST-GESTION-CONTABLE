Imports System.IO
Imports System.IO.Compression.GZipStream


Public Class mantenimiento
    Public centroSel As Integer
    Private BindingSourcenomencla As Windows.Forms.BindingSource = New BindingSource
    Private Sub mantenimiento_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        frmprincipal.cmdmantenimiento.Enabled = True
    End Sub

    Private Sub mantenimiento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarDtosGrales()
        CargarConceptos()
    End Sub

    Private Sub cargarDtosGrales()
        Try


            'cargamos centros de costo
            Dim tablaCentro As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from cm_sdo_convenios", conexionPrinc)
            Dim readcentro As New DataSet
            tablaCentro.Fill(readcentro)
            cmbconvenio.DataSource = readcentro.Tables(0)
            cmbconvenio.DisplayMember = readcentro.Tables(0).Columns(1).Caption.ToString
            cmbconvenio.ValueMember = readcentro.Tables(0).Columns(0).Caption.ToString
            cmbconvenio.SelectedIndex = -1

            'cargamos categorias de trabajo
            'Dim tablaCatTra As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from cm_sdo_categoria_personal order by nombre asc", conexionPrinc)
            'Dim readcatTR As New DataSet
            'tablaCatTra.Fill(readcatTR)
            'cmbcategoria.DataSource = readcatTR.Tables(0)
            'cmbcategoria.DisplayMember = readcatTR.Tables(0).Columns(1).Caption.ToString
            'cmbcategoria.ValueMember = readcatTR.Tables(0).Columns(0).Caption.ToString
            'cmbcategoria.SelectedIndex = -1

            'cargamos nomenclador de actividades
            Dim tablanomenclador As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from cm_actividades_empresas order by nombre asc", conexionPrinc)
            Dim readnomenc As New DataTable
            tablanomenclador.Fill(readnomenc)
            BindingSourcenomencla.DataSource = readnomenc
            dtnomenclador.DataSource = BindingSourcenomencla
            dtnomenclador.Columns(0).Visible = False
            'dtnomenclador.Columns(1).Width = 500
            'dtnomenclador.Columns(2).Width = 50


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CargarConceptos()
        Try
            Reconectar()
            conexionPrinc.ChangeDatabase(database)
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT cs.idconceptos_sueldo, cs.codigo as Codigo, cs.concepto as Concepto, ti.nombre as Tipo, cs.cantidad as cnt, uni.nombre as Unidades, cs.formula as Formula 
            FROM cm_sdo_conceptos_sueldo as cs, cm_sdo_tipos_conceptos_sueldo as ti,cm_sdo_unidades_calculo as uni 
            where cs.tipo=ti.id and cs.unidad=uni.id order by cs.codigo asc", conexionPrinc)
            Dim tablaConc As New DataTable
            Dim comando As New MySql.Data.MySqlClient.MySqlCommandBuilder(consulta)
            consulta.Fill(tablaConc)
            dtconceptos.DataSource = tablaConc
            dtconceptos.Columns(1).Visible = False
            dtconceptos.Columns(2).ReadOnly = True
            dtconceptos.Columns(3).ReadOnly = True
            dtconceptos.Columns(4).ReadOnly = True
            dtconceptos.Columns(5).ReadOnly = True
            dtconceptos.Columns(6).ReadOnly = True
            dtconceptos.Columns(7).ReadOnly = True



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub cmdaddconcepto_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub cmdguardar_Click(sender As Object, e As EventArgs) Handles cmdguardar.Click
        'MsgBox(centroSel)
        'Exit Sub
        Try
            Reconectar()
            'If cmbcentro.SelectedValue = 0 Then
            Dim convenio As Integer
            Dim antig As String
            Dim sueldo As String
            Dim sqlQuery As String
            Dim cadenaCONC As String
            Dim categoria As Integer

            'Dim centrosel As Integer = cmbconvenio.SelectedValue
            Dim i As Integer
            'MsgBox(centrosel)
            For i = 0 To dtconceptos.RowCount - 1
                If dtconceptos.Rows.Item(i).Cells(0).Value = True Then
                    cadenaCONC &= "," & dtconceptos.Item(2, i).Value.ToString
                End If
            Next

            convenio = cmbconvenio.SelectedValue
            categoria = cmbcategoria.SelectedValue
            antig = txtporcant.Text
            sueldo = txtsueldo.Text

            If cmbconvenio.Text = "" And cmbcategoria.Text = "" Then
                MsgBox("debe ingresar o seleccionar un convenio y una categoria")
                Exit Sub
            ElseIf cmbconvenio.Text = "" And cmbcategoria.Text <> "" Then
                MsgBox("debe ingresar o seleccionar un convenio")
                Exit Sub
            ElseIf cmbconvenio.Text <> "" And cmbcategoria.Text = "" Then
                MsgBox("debe ingresar o seleccionar una categoria")
                Exit Sub
            ElseIf convenio = 0 And categoria = 0 Then
                'msgbox("No se selecciono categoria")
                comando.Connection = conexionPrinc
                comando.CommandText = "insert into cm_sdo_convenios(nombre) values ('" & cmbconvenio.Text.ToUpper & "')"
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
            If centroSel = 0 Then
                sqlQuery = "insert into cm_sdo_centro_costos (convenio, conceptos, antiguedad, sueldo, categoria_personal) values (?conv,?conc,?antig,?sueldo,?cat)"
            Else
                sqlQuery = "update cm_sdo_centro_costos set conceptos=?conc, antiguedad=?antig, sueldo=?sueldo where id=?centrosel"
            End If
            'MsgBox(cadenaCONC & "----" & centrosel)
            Reconectar()
            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
            With comandoadd.Parameters
                .AddWithValue("?conv", convenio)
                .AddWithValue("?conc", cadenaCONC)
                .AddWithValue("?antig", antig)
                .AddWithValue("?sueldo", sueldo)
                .AddWithValue("?cat", categoria)
                If centroSel <> 0 Then
                    .AddWithValue("?centrosel", centroSel)
                End If
            End With
            comandoadd.ExecuteNonQuery()
            MsgBox("Convenio guardado")
            'End If
            'cargarDtosGrales()
            'CargarConceptos()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbcentro_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbconvenio.SelectedValueChanged
        cargarCostos()
    End Sub
    Public Sub cargarCostos()
        Dim lector As System.Data.IDataReader
        Dim sql As New MySql.Data.MySqlClient.MySqlCommand
        Try
            DestildarConc()
            Reconectar()
            txtporcant.Text = ""
            txtsueldo.Text = ""
            If cmbconvenio.SelectedValue <> 0 And cmbcategoria.SelectedValue <> 0 Then

                conexionPrinc.ChangeDatabase(database)
                sql.Connection = conexionPrinc
                sql.CommandText = "SELECT * from cm_sdo_centro_costos where categoria_personal = " & cmbcategoria.SelectedValue & " and convenio=" & cmbconvenio.SelectedValue

                sql.CommandType = CommandType.Text
                lector = sql.ExecuteReader
                lector.Read()

                txtporcant.Text = lector("antiguedad").ToString
                txtsueldo.Text = lector("sueldo").ToString
                resaltarActivos(lector("conceptos").ToString)
                centroSel = lector("id").ToString
            End If
        Catch ex As Exception
            centroSel = 0

        End Try
    End Sub
    Private Sub resaltarActivos(ByRef sel As String)
        Dim i As Integer
        For i = 0 To dtconceptos.Rows.Count - 1
            If InStr(sel, dtconceptos.Item(2, i).Value.ToString) <> 0 Then
                dtconceptos.Rows(i).Cells(0).Value = True
            Else
                dtconceptos.Rows(i).Cells(0).Value = False
            End If
        Next
    End Sub
    Private Sub DestildarConc()
        Dim i As Integer
        For i = 0 To dtconceptos.Rows.Count - 1
            dtconceptos.Rows(i).Cells(0).Value = False
        Next
    End Sub

    Private Sub dtconceptos_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dtconceptos.CellEndEdit
        Dim sqlQuery As String
        Try
            Reconectar()
            Select Case dtconceptos.CurrentCellAddress.X
                Case 6
                    'se edito la formula
                    sqlQuery = "update cm_sdo_conceptos_sueldo set formula='" & dtconceptos.CurrentCell.Value.ToString.ToUpper & "' where codigo=" & dtconceptos.Rows(dtconceptos.CurrentCellAddress.Y).Cells(1).Value
                    comando.Connection = conexionPrinc
                    comando.CommandText = sqlQuery
                    comando.ExecuteReader()
                    'CargarConceptos()
                    MsgBox("Formula Actualizada")

            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub cmbcategoria_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbcategoria.SelectedValueChanged
        cargarCostos()

    End Sub

    Private Sub dtnomenclador_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dtnomenclador.CellEndEdit
        Dim sqlQuery As String
        Try
            Reconectar()
            Select Case dtnomenclador.CurrentCellAddress.X
                Case 2
                    'se edito la formula
                    sqlQuery = "update cm_actividades_empresas set alicuota='" & dtnomenclador.CurrentCell.Value.ToString.ToUpper & "' where id=" & dtnomenclador.Rows(dtnomenclador.CurrentCellAddress.Y).Cells(0).Value
                    comando.Connection = conexionPrinc
                    comando.CommandText = sqlQuery
                    comando.ExecuteReader()
                    'CargarConceptos()
                    MsgBox("Alicuota actualizada")

            End Select
        Catch ex As Exception

        End Try
        'Try
        'Dim colEx As String
        'Dim cons As String
        'Dim idEX As Integer
        'Reconectar()
        'idEX = dtnomenclador.Rows(dtnomenclador.CurrentCellAddress.Y).Cells(0).Value
        'comando.Connection = conexionEmp
        'conexionEmp.ChangeDatabase(EmpDB)
        'Select Case dtnomenclador.CurrentCellAddress.X
        '   Case 2
        'colEx = "categoria"
        '      cons = 
        'End Select
        'comando.CommandText = cons
        'comando.CommandType = CommandType.Text
        ''comando.ExecuteReader()
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub txtbuscacti_KeyUp(sender As Object, e As KeyEventArgs) Handles txtbuscacti.KeyUp
        BindingSourcenomencla.Filter = "nombre Like '%" & txtbuscacti.Text & "%'"
    End Sub

    Private Sub cmbconvenio_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbconvenio.SelectionChangeCommitted
        Dim idconvenio = cmbconvenio.SelectedValue
        Dim tablaCatTra As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from cm_sdo_categoria_personal where idconvenio=" & idconvenio & " order by nombre asc", conexionPrinc)
        Dim readcatTR As New DataSet
        tablaCatTra.Fill(readcatTR)
        cmbcategoria.DataSource = readcatTR.Tables(0)
        cmbcategoria.DisplayMember = readcatTR.Tables(0).Columns(1).Caption.ToString
        cmbcategoria.ValueMember = readcatTR.Tables(0).Columns(0).Caption.ToString
        cmbcategoria.SelectedIndex = -1
    End Sub

    Private Sub TabPage5_Click(sender As Object, e As EventArgs) Handles TabPage5.Click

    End Sub

    Private Sub TabPage5_Enter(sender As Object, e As EventArgs) Handles TabPage5.Enter
        Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("Show databases like '%" & conexionPrinc.Database.ToString & "%' ", conexionPrinc)
        Dim tablacl As New DataTable
        Dim infocl() As DataRow
        consulta.Fill(tablacl)
        dtdbresguardo.DataSource = tablacl
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        With fldbrwrutaresguardo
            .RootFolder = Environment.SpecialFolder.MyComputer
            .Description = "Seleccione una carpeta para el resguardo"
            .ShowNewFolderButton = True
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                lbldestino.Text = .SelectedPath
            End If
        End With
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim i As Integer
        Dim db As String
        Dim nombrearchivo As String
        Dim directorio As String = lbldestino.Text & "\" & Format(Now(), "dd-MM-yyyy")

        If lbldestino.Text = "" Then
            MsgBox("no selecciono un destino para el resguardo")
            Exit Sub
        End If
        Directory.CreateDirectory(directorio)
        For i = 0 To dtdbresguardo.RowCount - 1
            If dtdbresguardo.Rows(i).Selected = True Then
                db = dtdbresguardo.Rows(i).Cells(0).Value.ToString

                nombrearchivo = "\" & Format(Now(), "dd-M-yyyy_HH-mm-ss") & "_" & db & ".sql"
                'MsgBox(db & " - " & nombrearchivo)
                Dim proceso As New Process
                proceso.StartInfo.FileName = "mysqldump"
                Dim ruta As String = Application.StartupPath & "\mysqldump.exe"
                Dim opciones As String = "--opt --password=democontable --user=democontable " & db & " -r " & directorio & nombrearchivo
                proceso.Start(ruta, opciones)
            End If
        Next
        'MsgBox(directorio)
        'Dim dirinfo As DirectoryInfo = New DirectoryInfo(directorio)
        'For Each fi As FileInfo In dirinfo.GetFiles()
        '    Comprimir(fi)
        'Next
        MsgBox("El resguardo se realizo con exito!")
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        Dim i As Integer
        If CheckBox1.Checked = True Then
            For i = 0 To dtdbresguardo.RowCount - 1
                dtdbresguardo.Rows(i).Selected = True
            Next
        ElseIf CheckBox1.Checked = False Then
            For i = 0 To dtdbresguardo.RowCount - 1
                dtdbresguardo.Rows(i).Selected = False
            Next
        End If
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub dtnomenclador_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtnomenclador.CellContentClick

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        NuevoConceptoSueldo.Show()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        NuevoConceptoSueldo.modificarConcepto = True
        NuevoConceptoSueldo.IDconceptoSueldoMod = dtconceptos.CurrentRow.Cells(1).Value
        'MsgBox(dtconceptos.CurrentRow.Cells(0).Value)
        NuevoConceptoSueldo.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try
            If MsgBox("Esta seguro que desea eliminar los conceptos seleccionados? las formulas automaticas que poseian este concepto dejaran de funcionar", vbYesNo + vbQuestion) = vbNo Then
                Exit Sub
            End If

            For Each concepto As DataGridViewRow In dtconceptos.Rows
                If concepto.Cells(0).Value=True Then
                    Reconectar()

                    Dim comandoDel As New MySql.Data.MySqlClient.MySqlCommand("delete from cm_sdo_conceptos_sueldo 
                    where idconceptos_sueldo=" & concepto.Cells("idconceptos_sueldo").Value, conexionPrinc)

                    comandoDel.ExecuteNonQuery()
                End If

            Next
            CargarConceptos()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Try
            If MsgBox("Esta seguro que desea eliminar este convenio? con el se eliminaran todas las categorias asociadas", vbYesNo + vbQuestion) = vbNo Then
                Exit Sub
            End If
            Dim comandoDelConv As New MySql.Data.MySqlClient.MySqlCommand("delete from cm_sdo_convenios where id=" & cmbconvenio.SelectedValue, conexionPrinc)
            comandoDelConv.ExecuteNonQuery()
            Dim comandoDelCat As New MySql.Data.MySqlClient.MySqlCommand("delete from cm_sdo_categoria_personal where idconvenio=" & cmbconvenio.SelectedValue, conexionPrinc)
            comandoDelCat.ExecuteNonQuery()
            Dim comandoDelCtro As New MySql.Data.MySqlClient.MySqlCommand("delete from cm_sdo_centro_costos where convenio=" & cmbconvenio.SelectedValue, conexionPrinc)
            comandoDelCtro.ExecuteNonQuery()

            cargarDtosGrales()
            MsgBox("Convenio eliminado!")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

        Try
                If MsgBox("Esta seguro que desea eliminar esta categoria?", vbYesNo + vbQuestion) = vbNo Then
                    Exit Sub
                End If
            Dim comandoDelCat As New MySql.Data.MySqlClient.MySqlCommand("delete from cm_sdo_categoria_personal where idcategoria_personal=" & cmbcategoria.SelectedValue, conexionPrinc)
            comandoDelCat.ExecuteNonQuery()
            Dim comandoDelCtro As New MySql.Data.MySqlClient.MySqlCommand("delete from cm_sdo_centro_costos where categoria_personal=" & cmbcategoria.SelectedValue, conexionPrinc)
            comandoDelCtro.ExecuteNonQuery()

            Dim tablaCatTra As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from cm_sdo_categoria_personal where idconvenio=" & cmbconvenio.SelectedValue & " order by nombre asc", conexionPrinc)
            Dim readcatTR As New DataSet
            tablaCatTra.Fill(readcatTR)
            cmbcategoria.DataSource = readcatTR.Tables(0)
            cmbcategoria.DisplayMember = readcatTR.Tables(0).Columns(1).Caption.ToString
            cmbcategoria.ValueMember = readcatTR.Tables(0).Columns(0).Caption.ToString
            cmbcategoria.SelectedIndex = -1
            MsgBox("Categoria Eliminada!")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Try
            Dim NvoConvenio As String = ""
            NvoConvenio = InputBox("ingrese el nombre del nuevo convenio", "Nuevo convenio")
            If NvoConvenio = "" Then
                Exit Sub
            End If

            Dim comandoaddConv As New MySql.Data.MySqlClient.MySqlCommand("insert into cm_sdo_convenios (nombre) values ('" & NvoConvenio & "')", conexionPrinc)
            comandoaddConv.ExecuteNonQuery()
            cargarDtosGrales()
            cmbconvenio.SelectedValue = comandoaddConv.LastInsertedId

            MsgBox("Convenio agregado!")

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Try
            If cmbconvenio.SelectedValue = 0 Or cmbconvenio.SelectedIndex = -1 Then
                MsgBox("seleccione primero un convenio!")
                Exit Sub
            End If
            Dim idConvenio As Integer = cmbconvenio.SelectedValue
            Dim nvaCategoria As String = ""
            nvaCategoria = InputBox("Ingrese el nuevo nombre de la categoria", "nueva categoria")
            If nvaCategoria = "" Then
                Exit Sub
            End If
            Dim comandoaddcat As New MySql.Data.MySqlClient.MySqlCommand("insert into cm_sdo_categoria_personal (nombre,idconvenio) 
            values ('" & nvaCategoria & "','" & idConvenio & "')", conexionPrinc)
            comandoaddcat.ExecuteNonQuery()

            'Dim idconvenio = cmbconvenio.SelectedValue
            Dim tablaCatTra As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from cm_sdo_categoria_personal where idconvenio=" & idConvenio & " order by nombre asc", conexionPrinc)
            Dim readcatTR As New DataSet
            tablaCatTra.Fill(readcatTR)
            cmbcategoria.DataSource = readcatTR.Tables(0)
            cmbcategoria.DisplayMember = readcatTR.Tables(0).Columns(1).Caption.ToString
            cmbcategoria.ValueMember = readcatTR.Tables(0).Columns(0).Caption.ToString
            'cmbcategoria.SelectedIndex = -1

            cmbcategoria.SelectedValue = comandoaddcat.LastInsertedId

            MsgBox("Convenio agregado!")
        Catch ex As Exception

        End Try
    End Sub

End Class