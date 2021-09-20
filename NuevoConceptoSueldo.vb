Public Class NuevoConceptoSueldo
    Public modificarConcepto As Boolean
    Public IDconceptoSueldoMod As Integer
    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub NuevoConceptoSueldo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Reconectar()
        conexionPrinc.ChangeDatabase(database)
        'conexionEmp.ChangeDatabase(EmpDB)

        'cargar tipos conceptos
        Dim tablatipCons As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from cm_sdo_tipos_conceptos_sueldo", conexionPrinc)
        Dim readtipocons As New DataSet
        tablatipCons.Fill(readtipocons)
        cmbtipo.DataSource = readtipocons.Tables(0)
        cmbtipo.DisplayMember = readtipocons.Tables(0).Columns(1).Caption.ToString
        cmbtipo.ValueMember = readtipocons.Tables(0).Columns(0).Caption.ToString
        ''cmbtipo.SelectedIndex = -1

        'cargar unidades
        Dim tablaUnidad As New MySql.Data.MySqlClient.MySqlDataAdapter("select * from cm_sdo_unidades_calculo", conexionPrinc)
        Dim readunidad As New DataSet
        tablaUnidad.Fill(readunidad)
        cmbunidad.DataSource = readunidad.Tables(0)
        cmbunidad.DisplayMember = readunidad.Tables(0).Columns(1).Caption.ToString
        cmbunidad.ValueMember = readunidad.Tables(0).Columns(0).Caption.ToString
        cmbunidad.SelectedIndex = -1

        If modificarConcepto = True Then
            lbltitulo.Text = "MODIFICAR CONCEPTO"
            Me.Text = "Modificar Concepto"

            Reconectar()
            conexionPrinc.ChangeDatabase(database)
            Dim consultaConcepto As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT * FROM tortul_petean.cm_sdo_conceptos_sueldo where idconceptos_sueldo=" & IDconceptoSueldoMod, conexionPrinc)
            Dim tablaConc As New DataTable
            consultaConcepto.Fill(tablaConc)

            Reconectar()
            Dim consultaInfoExtraConc As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT * FROM tortul_petean.cm_sdo_infoExtraLSD where id=" & IDconceptoSueldoMod, conexionPrinc)
            Dim tablaInfoExtraConc As New DataTable
            consultaInfoExtraConc.Fill(tablaInfoExtraConc)
            'MsgBox(tablaConc.Rows(0).Item("tipo"))
            cmbtipo.SelectedValue = tablaConc.Rows(0).Item("tipo")
            txtcodigo.Text = tablaConc.Rows(0).Item("codigo")
            txtmonto.Text = tablaConc.Rows(0).Item("monto")
            cmbunidad.SelectedValue = tablaConc.Rows(0).Item("unidad")
            txtcantidad.Text = tablaConc.Rows(0).Item("cantidad").ToString
            chkbasico.CheckState = tablaConc.Rows(0).Item("usar_sueldo")
            txtconcepto.Text = tablaConc.Rows(0).Item("concepto")
            txtformula.Text = tablaConc.Rows(0).Item("formula")
            If tablaInfoExtraConc.Rows.Count = 0 Then
                Exit Sub
            End If

            cmbCodigoAfip.SelectedValue = tablaInfoExtraConc.Rows(0).Item("codigoAfip")
            chkAporteSIPA.CheckState = tablaInfoExtraConc.Rows(0).Item("aporteSIPA")
            chkAporteINSSJyP.CheckState = tablaInfoExtraConc.Rows(0).Item("aporteINSSJyP")
            chkAporteOSocial.CheckState = tablaInfoExtraConc.Rows(0).Item("aporteOS")
            chkAporteFSR.CheckState = tablaInfoExtraConc.Rows(0).Item("aporteFSR")
            chkAporteRENATEA.CheckState = tablaInfoExtraConc.Rows(0).Item("aporteRENATEA")
            chkAporteAAFF.CheckState = tablaInfoExtraConc.Rows(0).Item("aporteAAFF")
            chkAporteFNE.CheckState = tablaInfoExtraConc.Rows(0).Item("aporteFNE")
            chkAporteDiferenciales.CheckState = tablaInfoExtraConc.Rows(0).Item("aporteDIF")
            chkAporteRegEspeciales.CheckState = tablaInfoExtraConc.Rows(0).Item("aporteREGEsp")
            chkContribucionesSIPA.CheckState = tablaInfoExtraConc.Rows(0).Item("contribSIPA")
            chkContribucionesINSSJyP.CheckState = tablaInfoExtraConc.Rows(0).Item("contribINSSJyP")
            chkContribucionesOSocial.CheckState = tablaInfoExtraConc.Rows(0).Item("contribOS")
            chkContribucionesFSR.CheckState = tablaInfoExtraConc.Rows(0).Item("contribFSR")
            chkContribucionesRENATEA.CheckState = tablaInfoExtraConc.Rows(0).Item("contribRENATEA")
            chkContribucionesAAFF.CheckState = tablaInfoExtraConc.Rows(0).Item("contribAAFF")
            chkContribucionesFNE.CheckState = tablaInfoExtraConc.Rows(0).Item("contribFNE")
            chkContribucionesDiferenciales.CheckState = tablaInfoExtraConc.Rows(0).Item("contribDIF")
            chkContribucionesRegEspeciales.CheckState = tablaInfoExtraConc.Rows(0).Item("contribREGEsp")
            chkBaseImponible01.CheckState = tablaInfoExtraConc.Rows(0).Item("Bimp1")
            chkBaseImponible02.CheckState = tablaInfoExtraConc.Rows(0).Item("Bimp2")
            chkBaseImponible03.CheckState = tablaInfoExtraConc.Rows(0).Item("Bimp3")
            chkBaseImponible04.CheckState = tablaInfoExtraConc.Rows(0).Item("Bimp4")
            chkBaseImponible05.CheckState = tablaInfoExtraConc.Rows(0).Item("Bimp5")
            chkBaseImponible06.CheckState = tablaInfoExtraConc.Rows(0).Item("Bimp6")
            chkBaseImponible07.CheckState = tablaInfoExtraConc.Rows(0).Item("Bimp7")
            chkBaseImponible08.CheckState = tablaInfoExtraConc.Rows(0).Item("Bimp8")
            chkBaseImponible09.CheckState = tablaInfoExtraConc.Rows(0).Item("Bimp9")
            chkBaseImponible10.CheckState = tablaInfoExtraConc.Rows(0).Item("Bimp10")
            chkMaternidadAnses.CheckState = tablaInfoExtraConc.Rows(0).Item("MaternidadAnses")
            chkBaseCalculoART.CheckState = tablaInfoExtraConc.Rows(0).Item("BaseART")
            chkAporteDifSegSocial.CheckState = tablaInfoExtraConc.Rows(0).Item("BaseAporteSegSoc")
            chkContribucionDifSegSocial.CheckState = tablaInfoExtraConc.Rows(0).Item("BaseContribSegSoc")
            chkAporteDifOSyFSR.CheckState = tablaInfoExtraConc.Rows(0).Item("BaseAporteOSyFSR")
            chkContribDifOSyFSR.CheckState = tablaInfoExtraConc.Rows(0).Item("BaseContribOSyFSR")
            chkContribucionLeyRiesgoTrabajo.CheckState = tablaInfoExtraConc.Rows(0).Item("ContribLeyRT")










        End If





    End Sub

    Private Sub cmdaddconcepto_Click(sender As Object, e As EventArgs) Handles cmdaddconcepto.Click
        Dim codigo As String
        Dim concepto As String
        Dim tipo As Integer
        Dim monto As String
        Dim unida As Integer
        Dim formula As String
        Dim sqlQuery As String
        Dim cantidad As String
        Dim SqlQueryLSD As String
        Try
            Reconectar()
            conexionPrinc.ChangeDatabase(database)

            codigo = txtcodigo.Text.ToUpper
            concepto = txtconcepto.Text.ToUpper
            tipo = cmbtipo.SelectedValue
            monto = txtmonto.Text
            unida = cmbunidad.SelectedValue
            formula = txtformula.Text
            cantidad = txtcantidad.Text
            Dim idCodigo As Integer
            If modificarConcepto = False Then
                sqlQuery = "insert into cm_sdo_conceptos_sueldo (codigo, concepto, tipo, monto, unidad, formula, cantidad, usar_sueldo) 
            values ('" & codigo & "','" & concepto & "','" & tipo & "','" & monto & "','" & unida & "','" & formula & "','" & cantidad & "','" & chkbasico.CheckState & "')"
                Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
                comandoadd.ExecuteNonQuery()
                idCodigo = comandoadd.LastInsertedId
            Else
                sqlQuery = "UPDATE cm_sdo_conceptos_sueldo
                SET
                codigo ='" & codigo & "',
                concepto = '" & concepto & "',
                tipo = '" & tipo & "',
                monto = '" & monto & "',
                unidad = '" & unida & "',
                formula = '" & formula & "',
                cantidad = '" & cantidad & "',
                usar_sueldo = '" & chkbasico.CheckState & "'
                WHERE idconceptos_sueldo = " & IDconceptoSueldoMod
                idCodigo = IDconceptoSueldoMod
            End If

            Dim CodigoAFIP As Integer = cmbCodigoAfip.SelectedValue

            If CodigoAFIP = 0 Then
                Dim comandoaddCodigoAFIP As New MySql.Data.MySqlClient.MySqlCommand("insert into cm_sdo_conceptosSueldoAFIP 
                values ('" & cmbtipo.SelectedValue & "','" & cmbCodigoAfip.Text & "','" & txtconcepto.Text.ToUpper & "')", conexionPrinc)
                comandoaddCodigoAFIP.ExecuteNonQuery()
                CodigoAFIP = cmbCodigoAfip.Text
            End If

            SqlQueryLSD = "insert into cm_sdo_infoExtraLSD 
            (id,codigoAfip,codInt,aporteSIPA,aporteINSSJyP,aporteOS,aporteFSR,aporteRENATEA,aporteAAFF,aporteFNE,aporteDIF,aporteREGEsp,contribSIPA,
            contribINSSJyP,contribOS,contribFSR,contribRENATEA,contribAAFF,contribFNE,contribDIF,contribREGEsp,BImp1,BImp2,BImp3,BImp4,BImp5,BImp6,
            BImp7,BImp8,BImp9,BImp10,MaternidadAnses,BaseART,BaseAporteSegSoc,BaseContribSegSoc,BaseAporteOSyFSR,BaseContribOSyFSR,ContribLeyRT,MarcaRepeticion)
            VALUES ('" & idCodigo & "','" & cmbCodigoAfip.SelectedValue & "','" & codigo & "','" & chkAporteSIPA.CheckState & "','" & chkAporteINSSJyP.CheckState & "',
            '" & chkAporteOSocial.CheckState & "',
            '" & chkAporteFSR.CheckState & "','" & chkAporteRENATEA.CheckState & "','" & chkAporteAAFF.CheckState & "','" & chkAporteFNE.CheckState & "',
            '" & chkAporteDiferenciales.CheckState & "','" & chkAporteRegEspeciales.CheckState & "',
            '" & chkContribucionesSIPA.CheckState & "','" & chkContribucionesINSSJyP.CheckState & "','" & chkContribucionesOSocial.CheckState & "',
            '" & chkContribucionesFSR.CheckState & "','" & chkAporteRENATEA.CheckState & "','" & chkContribucionesAAFF.CheckState & "',
            '" & chkContribucionesFNE.CheckState & "', '" & chkContribucionesDiferenciales.CheckState & "','" & chkContribucionesRegEspeciales.CheckState & "',
            '" & chkBaseImponible01.CheckState & "','" & chkBaseImponible02.CheckState & "','" & chkBaseImponible03.CheckState & "',
            '" & chkBaseImponible04.CheckState & "','" & chkBaseImponible05.CheckState & "','" & chkBaseImponible06.CheckState & "',
            '" & chkBaseImponible07.CheckState & "','" & chkBaseImponible08.CheckState & "','" & chkBaseImponible09.CheckState & "',
            '" & chkBaseImponible10.CheckState & "',
            '" & chkMaternidadAnses.CheckState & "','" & chkBaseCalculoART.CheckState & "','" & chkAporteDifSegSocial.CheckState & "',
            '" & chkContribucionDifSegSocial.CheckState & "','" & chkAporteDifOSyFSR.CheckState & "','" & chkContribDifOSyFSR.CheckState & "',
            '" & chkContribucionLeyRiesgoTrabajo.CheckState & "','" & chkMarcaRepeticion.CheckState & "') ON DUPLICATE KEY UPDATE 
            codigoAfip = '" & cmbCodigoAfip.SelectedValue & "',
            codInt = '" & codigo & "',
            aporteSIPA = '" & chkAporteSIPA.CheckState & "',
            aporteINSSJyP ='" & chkAporteINSSJyP.CheckState & "',
            aporteOS = '" & chkAporteOSocial.CheckState & "',
            aporteFSR = '" & chkAporteFSR.CheckState & "',
            aporteRENATEA = '" & chkAporteRENATEA.CheckState & "',
            aporteAAFF = '" & chkAporteAAFF.CheckState & "',
            aporteFNE = '" & chkAporteFNE.CheckState & "',
            aporteDIF = '" & chkAporteDiferenciales.CheckState & "',
            aporteREGEsp = '" & chkAporteRegEspeciales.CheckState & "',
            contribSIPA = '" & chkContribucionesSIPA.CheckState & "',
            contribINSSJyP = '" & chkContribucionesINSSJyP.CheckState & "',
            contribOS = '" & chkContribucionesOSocial.CheckState & "',
            contribFSR = '" & chkContribucionesFSR.CheckState & "',
            contribRENATEA = '" & chkContribucionesRENATEA.CheckState & "',
            contribAAFF = '" & chkContribucionesAAFF.CheckState & "',
            contribFNE = '" & chkContribucionesFNE.CheckState & "',
            contribDIF = '" & chkContribucionesDiferenciales.CheckState & "',
            contribREGEsp = '" & chkContribucionesRegEspeciales.CheckState & "',
            BImp1 = '" & chkBaseImponible01.CheckState & "',
            BImp2 = '" & chkBaseImponible02.CheckState & "',
            BImp3 = '" & chkBaseImponible03.CheckState & "',
            BImp4 = '" & chkBaseImponible04.CheckState & "',
            BImp5 = '" & chkBaseImponible05.CheckState & "',
            BImp6 = '" & chkBaseImponible06.CheckState & "',
            BImp7 = '" & chkBaseImponible07.CheckState & "',
            BImp8 = '" & chkBaseImponible08.CheckState & "',
            BImp9 = '" & chkBaseImponible09.CheckState & "',
            BImp10 = '" & chkBaseImponible10.CheckState & "',
            MaternidadAnses = '" & chkMaternidadAnses.CheckState & "',
            BaseART = '" & chkBaseCalculoART.CheckState & "',
            BaseAporteSegSoc = '" & chkAporteDifSegSocial.CheckState & "',
            BaseContribSegSoc = '" & chkContribucionDifSegSocial.CheckState & "',
            BaseAporteOSyFSR = '" & chkAporteDifOSyFSR.CheckState & "',
            BaseContribOSyFSR = '" & chkContribDifOSyFSR.CheckState & "',
            ContribLeyRT = '" & chkContribucionLeyRiesgoTrabajo.CheckState & "',
            MarcaRepeticion='" & chkMarcaRepeticion.CheckState & "'"

            Dim comandoaddLSD As New MySql.Data.MySqlClient.MySqlCommand(SqlQueryLSD, conexionPrinc)
            comandoaddLSD.ExecuteNonQuery()

            mantenimiento.cargarCostos()
            MsgBox("Operacion completada correctamente")
            Me.Close()
            'txtcodigo.Clear()
            'txtconcepto.Clear()
            'cmbtipo.SelectedIndex = -1
            'cmbunidad.SelectedIndex = -1
            'txtcantidad.Clear()
            'txtformula.Clear()
            'chkbasico.Checked = False
            ''CargarConceptos()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CargarConceptosAFIP()
        Try
            Dim tablatipCons As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT codigo, concat(codigo ,' - ', descripcion ) FROM cm_sdo_conceptosSueldoAFIP where tipo=" & cmbtipo.SelectedValue, conexionPrinc)
            Dim readtipocons As New DataSet
            tablatipCons.Fill(readtipocons)
            cmbCodigoAfip.DataSource = readtipocons.Tables(0)
            cmbCodigoAfip.DisplayMember = readtipocons.Tables(0).Columns(1).Caption.ToString
            cmbCodigoAfip.ValueMember = readtipocons.Tables(0).Columns(0).Caption.ToString
            '            cmbCodigoAfip.SelectedIndex = -1
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbtipo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbtipo.SelectedValueChanged
        CargarConceptosAFIP()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class