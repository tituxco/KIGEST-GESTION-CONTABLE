Imports System.IO

Public Class exportacionLSD
    Public RegistroGeneralLSD As String = ""
    Dim Bimp10TEMPORAL As String()
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Reconectar()
            Dim consultaConceptosLSD As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT lsd.codigoAfip,lsd.codInt,conc.concepto,lsd.MarcaRepeticion, lsd.aporteSIPA,lsd.contribSIPA,
            lsd.aporteINSSJyP,lsd.contribINSSJyP,lsd.aporteOS, lsd.contribOS,lsd.aporteFSR,lsd.contribFSR, lsd.aporteRENATEA,lsd.contribRENATEA,
            lsd.contribAAFF,lsd.contribFNE,lsd.ContribLeyRT,lsd.aporteDIF,lsd.contribDIF  
            FROM cm_sdo_infoExtraLSD as lsd, cm_sdo_conceptos_sueldo as conc where
            conc.idconceptos_sueldo=lsd.id", conexionPrinc)
            Dim tablaConceptosLSD As New DataTable
            consultaConceptosLSD.Fill(tablaConceptosLSD)
            dgvConceptosLSD.DataSource = tablaConceptosLSD
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim ConceptosAExportar As String = ""

            For Each concepto As DataGridViewRow In dgvConceptosLSD.Rows
                ConceptosAExportar &= parametrizarCampo(concepto.Cells("codigoAfip").Value.ToString, 6, "0", True)
                ConceptosAExportar &= parametrizarCampo(concepto.Cells("codInt").Value.ToString, 10, "0", True)
                ConceptosAExportar &= parametrizarCampo(concepto.Cells("concepto").Value.ToString, 150, " ", False)
                ConceptosAExportar &= parametrizarCampo(concepto.Cells("MarcaRepeticion").Value.ToString, 1, "0", True)
                ConceptosAExportar &= parametrizarCampo(concepto.Cells("aporteSIPA").Value.ToString, 1, "0", True)
                ConceptosAExportar &= parametrizarCampo(concepto.Cells("contribSIPA").Value.ToString, 1, "0", True)
                ConceptosAExportar &= parametrizarCampo(concepto.Cells("aporteINSSJyP").Value.ToString, 1, "0", True)
                ConceptosAExportar &= parametrizarCampo(concepto.Cells("contribINSSJyP").Value.ToString, 1, "0", True)
                ConceptosAExportar &= parametrizarCampo(concepto.Cells("aporteOS").Value.ToString, 1, "0", True)
                ConceptosAExportar &= parametrizarCampo(concepto.Cells("contribOS").Value.ToString, 1, "0", True)
                ConceptosAExportar &= parametrizarCampo(concepto.Cells("aporteFSR").Value.ToString, 1, "0", True)
                ConceptosAExportar &= parametrizarCampo(concepto.Cells("contribFSR").Value.ToString, 1, "0", True)
                ConceptosAExportar &= parametrizarCampo(concepto.Cells("aporteRENATEA").Value.ToString, 1, "0", True)
                ConceptosAExportar &= parametrizarCampo(concepto.Cells("contribRENATEA").Value.ToString, 1, "0", True)
                ConceptosAExportar &= " " 'libre
                ConceptosAExportar &= parametrizarCampo(concepto.Cells("contribAAFF").Value.ToString, 1, "0", True)
                ConceptosAExportar &= " " 'libre
                ConceptosAExportar &= parametrizarCampo(concepto.Cells("contribFNE").Value.ToString, 1, "0", True)
                ConceptosAExportar &= " " 'libre
                ConceptosAExportar &= parametrizarCampo(concepto.Cells("contribLeyRT").Value.ToString, 1, "0", True)
                ConceptosAExportar &= parametrizarCampo(concepto.Cells("aporteDIF").Value.ToString, 1, "0", True)
                ConceptosAExportar &= " " 'libre
                ConceptosAExportar &= parametrizarCampo(concepto.Cells("contribDIF").Value.ToString, 1, "0", True)
                ConceptosAExportar &= parametrizarCampo(" ", 9, " ", True) 'LIBRE
                ConceptosAExportar &= vbNewLine
            Next
            carpetadestino.ShowDialog()
            'Dim carpeta As New IO.DirectoryInfo(carpetadestino.SelectedPath)
            Dim nombreconceptosExportar = carpetadestino.SelectedPath & "\parametrizacionConceptos.txt"
            'Dim nombrealicutas = carpetadestino.SelectedPath & "\" & Replace(cmbperiodocarg.Text, "/", "") & "_COMPRASalicuotas_" & EmpDB.ToString & ".txt"
            Dim strStreamW As Stream = Nothing
            Dim strStreamWriter As StreamWriter = Nothing
            Windows.Forms.Cursor.Current = Cursors.WaitCursor

            If File.Exists(nombreconceptosExportar) Then
                strStreamW = File.Open(nombreconceptosExportar, FileMode.Open)
            Else
                strStreamW = File.Create(nombreconceptosExportar)
            End If
            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default)
            strStreamWriter.Write(ConceptosAExportar)
            strStreamWriter.Close()
            MsgBox("archivo de parametrizacion de conceptos exportado")

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)
        Try
            If cmbperiodo.Text = "" Then
                MsgBox("Debe ingresar un periodo liquidado previamente")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs)
        Try
            If cmbperiodo.Text = "" Then
                MsgBox("Debe ingresar un periodo liquidado previamente")
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs)
        Try


        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs)
        Try
            If cmbperiodo.Text = "" Then
                MsgBox("Debe ingresar un periodo liquidado previamente")
            End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs)
        Try


        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        CargarRegistrosLSD()

    End Sub

    Private Sub CargarRegistrosLSD()
        Try


            If cmbperiodo.Text = "" Then
                MsgBox("Debe ingresar un periodo liquidado previamente")
            End If
            'Dim itemchequed As Object ' As Integer
            Dim busquPeriodo As String = ""
            Dim numLiq As Integer = 0
            For Each itemChecked As Object In CheckedListBox1.CheckedItems
                numLiq += 1
                Dim row As DataRowView = TryCast(itemChecked, DataRowView)
                If busquPeriodo = "" Then
                    busquPeriodo = " rec.periodoconcat like '" & row("periodoconcat") & "'"
                Else
                    busquPeriodo &= " or rec.periodoconcat like  '" & row("periodoconcat") & "'"
                End If
            Next

            Reconectar()
            Dim consultaRegistro04 As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT '04' AS CodRegistro, per.cuil, lsd.conyuge,lsd.cant_hijos, 
lsd.adherido_cct as marcaCCT,lsd.cobertura_scvo as marcaSCVO,
lsd.corresponde_reduccion as marcaReduccion,lsd.tipo_empresa, '0' as codOperacion,lsd.situacion_revista, lsd.cod_condicion,
lsd.activ_empleado, lsd.modalidad_contratacion, lsd.cod_siniestrado, lsd.cod_localidad,lsd.situacion_revista as revista1, '1' as diaRevista1,
'0' as revista2, '0' as diaRevista2,'0' as revista3, '0' as diaRevista3, '30' as diasTrab, '0' as horasTrab, 
'0' as PorcApAdic,'0' as contrTareaDif,
lsd.cod_obraSocial, lsd.cant_adherentes,
'0' as aporteAdicOS,
'0' as contribAdicOS,
'0' as baseCalcDiferencialAporteOSyFSR,
'0' as baseCalcDiferencialContribOSyFSR,
'0' as baseCalcDiferencialContribLRT,
'0' as RemMaternidadANSES,
format(sum((select sum(replace(replace(remunerativo,'.',''),',','.'))+sum(replace(replace(noremunerativo,'.',''),',','.')) 
from sdo_items_recibos as itm where itm.idrecibo=rec.id)),2,'es_AR') as remBruta,
format(sum((SELECT sum(case
when length(itm.remunerativo)<>0 then replace(replace(remunerativo,'.',''),',','.')
when length(itm.noremunerativo)<>0 then replace(replace(noremunerativo,'.',''),',','.')
when length(itm.deducciones)<>0 then replace(replace(deducciones,'.',''),',','.')
end )
FROM sdo_items_recibos as itm, " & conexionPrinc.Database & ".cm_sdo_infoExtraLSD where 
" & conexionPrinc.Database & ".cm_sdo_infoExtraLSD.codInt=itm.codigo and " & conexionPrinc.Database & ".cm_sdo_infoExtraLSD.BImp1=1 and
rec.id=itm.idrecibo
)),2,'es_AR') as BImp1,
format(sum((SELECT sum(case
when length(itm.remunerativo)<>0 then replace(replace(remunerativo,'.',''),',','.')
when length(itm.noremunerativo)<>0 then replace(replace(noremunerativo,'.',''),',','.')
when length(itm.deducciones)<>0 then replace(replace(deducciones,'.',''),',','.')
end )
FROM sdo_items_recibos as itm, " & conexionPrinc.Database & ".cm_sdo_infoExtraLSD where 
" & conexionPrinc.Database & ".cm_sdo_infoExtraLSD.codInt=itm.codigo and " & conexionPrinc.Database & ".cm_sdo_infoExtraLSD.BImp2=1 and
rec.id=itm.idrecibo
)),2,'es_AR') as BImp2,
format(sum((SELECT sum(case
when length(itm.remunerativo)<>0 then replace(replace(remunerativo,'.',''),',','.')
when length(itm.noremunerativo)<>0 then replace(replace(noremunerativo,'.',''),',','.')
when length(itm.deducciones)<>0 then replace(replace(deducciones,'.',''),',','.')
end )
FROM sdo_items_recibos as itm, " & conexionPrinc.Database & ".cm_sdo_infoExtraLSD where 
" & conexionPrinc.Database & ".cm_sdo_infoExtraLSD.codInt=itm.codigo and " & conexionPrinc.Database & ".cm_sdo_infoExtraLSD.BImp3=1 and
rec.id=itm.idrecibo
)),2,'es_AR') as BImp3,
format(sum((SELECT sum(case
when length(itm.remunerativo)<>0 then replace(replace(remunerativo,'.',''),',','.')
when length(itm.noremunerativo)<>0 then replace(replace(noremunerativo,'.',''),',','.')
when length(itm.deducciones)<>0 then replace(replace(deducciones,'.',''),',','.')
end )
FROM sdo_items_recibos as itm, " & conexionPrinc.Database & ".cm_sdo_infoExtraLSD where 
" & conexionPrinc.Database & ".cm_sdo_infoExtraLSD.codInt=itm.codigo and " & conexionPrinc.Database & ".cm_sdo_infoExtraLSD.BImp4=1 and
rec.id=itm.idrecibo
)),2,'es_AR') as BImp4,
format(sum((SELECT sum(case
when length(itm.remunerativo)<>0 then replace(replace(remunerativo,'.',''),',','.')
when length(itm.noremunerativo)<>0 then replace(replace(noremunerativo,'.',''),',','.')
when length(itm.deducciones)<>0 then replace(replace(deducciones,'.',''),',','.')
end )
FROM sdo_items_recibos as itm, " & conexionPrinc.Database & ".cm_sdo_infoExtraLSD where 
" & conexionPrinc.Database & ".cm_sdo_infoExtraLSD.codInt=itm.codigo and " & conexionPrinc.Database & ".cm_sdo_infoExtraLSD.BImp5=1 and
rec.id=itm.idrecibo
)),2,'es_AR') as BImp5,
ifnull(0,format(sum((SELECT sum(case
when length(itm.remunerativo)<>0 then replace(replace(remunerativo,'.',''),',','.')
when length(itm.noremunerativo)<>0 then replace(replace(noremunerativo,'.',''),',','.')
when length(itm.deducciones)<>0 then replace(replace(deducciones,'.',''),',','.')
end )
FROM sdo_items_recibos as itm, " & conexionPrinc.Database & ".cm_sdo_infoExtraLSD where 
" & conexionPrinc.Database & ".cm_sdo_infoExtraLSD.codInt=itm.codigo and " & conexionPrinc.Database & ".cm_sdo_infoExtraLSD.BImp6=1 and
rec.id=itm.idrecibo
)),2,'es_AR')) as BImp6,
ifnull(0,format(sum((SELECT sum(case
when length(itm.remunerativo)<>0 then replace(replace(remunerativo,'.',''),',','.')
when length(itm.noremunerativo)<>0 then replace(replace(noremunerativo,'.',''),',','.')
when length(itm.deducciones)<>0 then replace(replace(deducciones,'.',''),',','.')
end )
FROM sdo_items_recibos as itm, " & conexionPrinc.Database & ".cm_sdo_infoExtraLSD where 
" & conexionPrinc.Database & ".cm_sdo_infoExtraLSD.codInt=itm.codigo and " & conexionPrinc.Database & ".cm_sdo_infoExtraLSD.BImp7=1 and
rec.id=itm.idrecibo
)),2,'es_AR')) as BImp7,
format(sum((SELECT sum(case
when length(itm.remunerativo)<>0 then replace(replace(remunerativo,'.',''),',','.')
when length(itm.noremunerativo)<>0 then replace(replace(noremunerativo,'.',''),',','.')
when length(itm.deducciones)<>0 then replace(replace(deducciones,'.',''),',','.')
end )
FROM sdo_items_recibos as itm, " & conexionPrinc.Database & ".cm_sdo_infoExtraLSD where 
" & conexionPrinc.Database & ".cm_sdo_infoExtraLSD.codInt=itm.codigo and " & conexionPrinc.Database & ".cm_sdo_infoExtraLSD.BImp8=1 and
rec.id=itm.idrecibo
)),2,'es_AR') as BImp8,
format(sum((SELECT sum(case
when length(itm.remunerativo)<>0 then replace(replace(remunerativo,'.',''),',','.')
when length(itm.noremunerativo)<>0 then replace(replace(noremunerativo,'.',''),',','.')
when length(itm.deducciones)<>0 then replace(replace(deducciones,'.',''),',','.')
end )
FROM sdo_items_recibos as itm, " & conexionPrinc.Database & ".cm_sdo_infoExtraLSD where 
" & conexionPrinc.Database & ".cm_sdo_infoExtraLSD.codInt=itm.codigo and " & conexionPrinc.Database & ".cm_sdo_infoExtraLSD.BImp9=1 and
rec.id=itm.idrecibo
)),2,'es_AR') as BImp9,
ifnull(0,format(sum((SELECT sum(case
when length(itm.remunerativo)<>0 then replace(replace(remunerativo,'.',''),',','.')
when length(itm.noremunerativo)<>0 then replace(replace(noremunerativo,'.',''),',','.')
when length(itm.deducciones)<>0 then replace(replace(deducciones,'.',''),',','.')
end )
FROM sdo_items_recibos as itm, " & conexionPrinc.Database & ".cm_sdo_infoExtraLSD where 
" & conexionPrinc.Database & ".cm_sdo_infoExtraLSD.codInt=itm.codigo and " & conexionPrinc.Database & ".cm_sdo_infoExtraLSD.BaseAporteSegSoc=1 and
rec.id=itm.idrecibo
)),2,'es_AR')) as BaseCalcDifAporteSegSoc,
ifnull(0,format(sum((SELECT sum(case
when length(itm.remunerativo)<>0 then replace(replace(remunerativo,'.',''),',','.')
when length(itm.noremunerativo)<>0 then replace(replace(noremunerativo,'.',''),',','.')
when length(itm.deducciones)<>0 then replace(replace(deducciones,'.',''),',','.')
end )
FROM sdo_items_recibos as itm, " & conexionPrinc.Database & ".cm_sdo_infoExtraLSD where 
" & conexionPrinc.Database & ".cm_sdo_infoExtraLSD.codInt=itm.codigo and " & conexionPrinc.Database & ".cm_sdo_infoExtraLSD.BaseContribSegSoc=1 and
rec.id=itm.idrecibo
)),2,'es_AR')) as BaseCalcDifContribSegSoc,
format(sum((SELECT sum(case
when length(itm.remunerativo)<>0 then replace(replace(remunerativo,'.',''),',','.')
when length(itm.noremunerativo)<>0 then replace(replace(noremunerativo,'.',''),',','.')
when length(itm.deducciones)<>0 then replace(replace(deducciones,'.',''),',','.')
end )
FROM sdo_items_recibos as itm, " & conexionPrinc.Database & ".cm_sdo_infoExtraLSD where 
" & conexionPrinc.Database & ".cm_sdo_infoExtraLSD.codInt=itm.codigo and " & conexionPrinc.Database & ".cm_sdo_infoExtraLSD.BImp10=1 and
rec.id=itm.idrecibo
)),2,'es_AR') as BImp10,
'0' as ImporteADetraer,
(select count(*) 
FROM sdo_recibos as rec where rec.cuil=per.cuil and 
(" & busquPeriodo & ")) as cant 
from
sdo_recibos as rec, sdo_personal as per, sdo_personal_infoLSD as lsd where
rec.idpersonal=per.idpersonal and per.idpersonal=lsd.idpersonal
and (" & busquPeriodo & ")  
group by per.cuil having cant =  " & numLiq, conexionEmp)
            'MsgBox(busquPeriodo)
            Dim tablaRegistro04 As New DataTable
            consultaRegistro04.Fill(tablaRegistro04)
            dgvRegistro04.DataSource = tablaRegistro04
            MsgBox(consultaRegistro04.SelectCommand.CommandText)

            Reconectar()
            Dim consultaRegistro02 As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT '02' as CodRegistro,rec.cuil,rec.idpersonal as legajo,'' as dependencia,  if(lsd.forma_pago=3,per.sueldocuenta,'') as CBU,
            '0' as DiasTope,rec.fecha_pago,'' as fechaRubrica,lsd.forma_pago
            FROM 
            sdo_recibos as rec, sdo_personal as per, sdo_personal_infoLSD as lsd where
            rec.idpersonal=per.idpersonal and rec.idpersonal=lsd.idpersonal and rec.periodoconcat like '" & cmbperiodo.Text & "'", conexionEmp)
            Dim tablaRegistro02 As New DataTable
            consultaRegistro02.Fill(tablaRegistro02)
            dgvregistro02.DataSource = tablaRegistro02

            Reconectar()
            Dim consultaRegistro03 As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT '03' AS CodRegistro,rec.cuil,itm.codigo, 
            format(left(itm.unidades,length(itm.unidades)-1),2,'en_EU') as cantidad, 
            right(itm.unidades,1) as unidad, 
            replace(replace(case
            when length(itm.remunerativo)<>0 then itm.remunerativo
            when length(itm.noremunerativo)<>0 then itm.noremunerativo
            when length(itm.deducciones)<>0 then itm.deducciones
            end,'.',''),',','.') as importe,
            case
            when length(itm.remunerativo)<>0 then 'C'
            when length(itm.noremunerativo)<>0 then 'C'
            when length(itm.deducciones)<>0 then 'D'
            end as deb_cred,'' as per_ajuste
            from
            sdo_items_recibos as itm, sdo_recibos as rec where
            itm.idrecibo=rec.id  and 
            rec.periodoconcat like '" & cmbperiodo.Text & "'", conexionEmp)
            Dim tablaRegistro03 As New DataTable
            consultaRegistro03.Fill(tablaRegistro03)
            dgvRegistro03.DataSource = tablaRegistro03

            Reconectar()
            Dim consultaRegistro01 As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT '01' as CodRegistro, '" & DatosEmpresa.Cuit & "' as cuit, 'SJ' as idEnvio, 
            concat(mes,'-',ano) as periodo, 'M' as tipoLiq, '1' AS numLiqu, '30' as DiasBase, '" & dgvRegistro04.Rows.Count & "' as CantReg04 
            from sdo_recibos as rec where rec.periodoconcat like '" & cmbperiodo.Text & "' limit 1", conexionEmp)
            Dim tablaRegistro01 As New DataTable
            consultaRegistro01.Fill(tablaRegistro01)
            dgvRegistro01.DataSource = tablaRegistro01
        Catch ex As Exception

        End Try



    End Sub

    Private Sub ExportarRegistros()


        Try


            Dim registro01 As String = ""
            registro01 &= "01"
            registro01 &= parametrizarCampo(dgvRegistro01.Rows(0).Cells("cuit").Value.ToString.Replace("-", ""), 11, "", True)
            registro01 &= parametrizarCampo(dgvRegistro01.Rows(0).Cells("idEnvio").Value, 2, "SJ", True)
            registro01 &= Format(CDate(dgvRegistro01.Rows(0).Cells("periodo").Value.ToString.Replace("MES", "").Replace("SETIEMBRE", "SEPTIEMBRE").Replace("AGUINALDO", "")), "yyyyMM")
            registro01 &= parametrizarCampo(dgvRegistro01.Rows(0).Cells("tipoLiq").Value, 1, "M", True)
            registro01 &= parametrizarCampo(dgvRegistro01.Rows(0).Cells("numLiqu").Value, 5, "0", True)
            registro01 &= parametrizarCampo(dgvRegistro01.Rows(0).Cells("DiasBase").Value, 2, "0", True)
            registro01 &= parametrizarCampo(dgvRegistro01.Rows(0).Cells("CantReg04").Value, 6, "0", True)


            Dim registros03 As String = ""
            For Each reg03 As DataGridViewRow In dgvRegistro03.Rows
                registros03 &= reg03.Cells("CodRegistro").Value
                registros03 &= parametrizarCampo(reg03.Cells("cuil").Value.ToString.Replace("-", ""), 11, "0", True)
                registros03 &= parametrizarCampo(reg03.Cells("codigo").Value, 10, "0", True)
                registros03 &= parametrizarCampo(reg03.Cells("cantidad").Value.ToString.Replace(".", ""), 5, "0", True)
                registros03 &= parametrizarCampo(reg03.Cells("unidad").Value.ToString.Replace("O", "$").Replace(" ", "$").Replace("0", "$"), 1, "$", False)
                registros03 &= parametrizarCampo(reg03.Cells("importe").Value.ToString.Replace(".", ""), 15, "0", True)
                registros03 &= parametrizarCampo(reg03.Cells("deb_cred").Value, 1, " ", False)
                registros03 &= parametrizarCampo(reg03.Cells("per_ajuste").Value, 6, " ", False)
                If reg03.Index <> dgvRegistro03.Rows.Count - 1 Then
                    registros03 &= vbNewLine
                End If
            Next

            Dim registros02 As String = ""
            For Each reg02 As DataGridViewRow In dgvregistro02.Rows
                registros02 &= reg02.Cells("CodRegistro").Value
                registros02 &= reg02.Cells("cuil").Value.ToString.Replace("-", "")
                registros02 &= parametrizarCampo(reg02.Cells("CodRegistro").Value, 10, " ", False)
                registros02 &= parametrizarCampo(reg02.Cells("dependencia").Value, 50, " ", False)
                registros02 &= parametrizarCampo(reg02.Cells("CBU").Value, 22, " ", False)
                registros02 &= parametrizarCampo(reg02.Cells("DiasTope").Value, 3, "0", True)
                registros02 &= Format(CDate(reg02.Cells("fecha_pago").Value), "yyyyMMdd")
                registros02 &= parametrizarCampo(reg02.Cells("fechaRubrica").Value, 8, " ", False)
                registros02 &= parametrizarCampo(reg02.Cells("forma_pago").Value, 1, "1", False)
                If reg02.Index <> dgvregistro02.Rows.Count - 1 Then
                    registros02 &= vbNewLine
                End If
            Next

            Dim registros04 As String = ""
            For Each reg04 As DataGridViewRow In dgvRegistro04.Rows
                'MsgBox(parametrizarCampo(reg04.Cells("remBruta").Value.ToString.Replace(",", "").Replace(".", ""), 15, "0", True))
                registros04 &= reg04.Cells("CodRegistro").Value
                registros04 &= parametrizarCampo(reg04.Cells("cuil").Value.ToString.Replace("-", ""), 11, "0", True)
                registros04 &= parametrizarCampo(reg04.Cells("conyuge").Value, 1, "0", False)
                registros04 &= parametrizarCampo(reg04.Cells("cant_hijos").Value, 2, "0", True)
                registros04 &= parametrizarCampo(reg04.Cells("marcaCCT").Value, 1, "0", False)
                registros04 &= parametrizarCampo(reg04.Cells("marcaSCVO").Value, 1, "0", False)
                registros04 &= parametrizarCampo(reg04.Cells("marcaReduccion").Value, 1, "0", False)
                registros04 &= parametrizarCampo(reg04.Cells("tipo_empresa").Value, 1, "1", False)
                registros04 &= parametrizarCampo(reg04.Cells("codOperacion").Value, 1, "0", False)
                registros04 &= parametrizarCampo(reg04.Cells("situacion_revista").Value, 2, "0", True)
                registros04 &= parametrizarCampo(reg04.Cells("cod_condicion").Value, 2, "0", True)
                registros04 &= parametrizarCampo(reg04.Cells("activ_empleado").Value, 3, "0", True)
                registros04 &= parametrizarCampo(reg04.Cells("modalidad_contratacion").Value, 3, "0", True)
                registros04 &= parametrizarCampo(reg04.Cells("cod_siniestrado").Value, 2, "0", True)
                registros04 &= parametrizarCampo(reg04.Cells("cod_localidad").Value, 2, "0", True)
                registros04 &= parametrizarCampo(reg04.Cells("revista1").Value, 2, "0", True)
                registros04 &= parametrizarCampo(reg04.Cells("diaRevista1").Value, 2, "0", True)
                registros04 &= parametrizarCampo(reg04.Cells("revista2").Value, 2, "0", True)
                registros04 &= parametrizarCampo(reg04.Cells("diaRevista2").Value, 2, "0", True)
                registros04 &= parametrizarCampo(reg04.Cells("revista3").Value, 2, "0", True)
                registros04 &= parametrizarCampo(reg04.Cells("diaRevista3").Value, 2, "0", True)
                registros04 &= parametrizarCampo(reg04.Cells("diasTrab").Value, 2, "0", True)
                registros04 &= parametrizarCampo(reg04.Cells("horasTrab").Value, 3, "0", True)
                registros04 &= parametrizarCampo(reg04.Cells("PorcApAdic").Value.ToString.Replace(",", "").Replace(".", ""), 5, "0", True)
                registros04 &= parametrizarCampo(reg04.Cells("contrTareaDif").Value.ToString.Replace(",", "").Replace(".", ""), 5, "0", True)
                registros04 &= parametrizarCampo(reg04.Cells("cod_obraSocial").Value, 6, "0", True)
                registros04 &= parametrizarCampo(reg04.Cells("cant_Adherentes").Value, 2, "0", True)
                registros04 &= parametrizarCampo(reg04.Cells("aporteAdicOS").Value.ToString.Replace(",", "").Replace(".", ""), 15, "0", True)
                registros04 &= parametrizarCampo(reg04.Cells("contribAdicOS").Value.ToString.Replace(",", "").Replace(".", ""), 15, "0", True)
                registros04 &= parametrizarCampo(reg04.Cells("baseCalcDiferencialAporteOSyFSR").Value.ToString.Replace(",", "").Replace(".", ""), 15, "0", True)
                registros04 &= parametrizarCampo(reg04.Cells("baseCalcDiferencialContribOSyFSR").Value.ToString.Replace(",", "").Replace(".", ""), 15, "0", True)
                registros04 &= parametrizarCampo(reg04.Cells("baseCalcDiferencialContribLRT").Value.ToString.Replace(",", "").Replace(".", ""), 15, "0", True)
                registros04 &= parametrizarCampo(reg04.Cells("RemMaternidadANSES").Value.ToString.Replace(",", "").Replace(".", ""), 15, "0", True)
                registros04 &= parametrizarCampo(reg04.Cells("remBruta").Value.ToString.Replace(",", "").Replace(".", ""), 15, "0", True)
                registros04 &= parametrizarCampo(reg04.Cells("Bimp1").Value.ToString.Replace(",", "").Replace(".", ""), 15, "0", True)
                registros04 &= parametrizarCampo(reg04.Cells("Bimp2").Value.ToString.Replace(",", "").Replace(".", ""), 15, "0", True)
                registros04 &= parametrizarCampo(reg04.Cells("Bimp3").Value.ToString.Replace(",", "").Replace(".", ""), 15, "0", True)
                registros04 &= parametrizarCampo(reg04.Cells("Bimp4").Value.ToString.Replace(",", "").Replace(".", ""), 15, "0", True)
                registros04 &= parametrizarCampo(reg04.Cells("Bimp5").Value.ToString.Replace(",", "").Replace(".", ""), 15, "0", True)
                registros04 &= parametrizarCampo(reg04.Cells("Bimp6").Value.ToString.Replace(",", "").Replace(".", ""), 15, "0", True)
                registros04 &= parametrizarCampo(reg04.Cells("Bimp7").Value.ToString.Replace(",", "").Replace(".", ""), 15, "0", True)
                registros04 &= parametrizarCampo(reg04.Cells("Bimp8").Value.ToString.Replace(",", "").Replace(".", ""), 15, "0", True)
                registros04 &= parametrizarCampo(reg04.Cells("Bimp9").Value.ToString.Replace(",", "").Replace(".", ""), 15, "0", True)
                registros04 &= parametrizarCampo(reg04.Cells("BaseCalcDifAporteSegSoc").Value.ToString.Replace(",", "").Replace(".", ""), 15, "0", True)
                registros04 &= parametrizarCampo(reg04.Cells("BaseCalcDifContribSegSoc").Value.ToString.Replace(",", "").Replace(".", ""), 15, "0", True)
                registros04 &= parametrizarCampo(reg04.Cells("Bimp10").Value.ToString.Replace(",", "").Replace(".", ""), 15, "0", True)
                registros04 &= parametrizarCampo(reg04.Cells("ImporteADetraer").Value.ToString.Replace(",", "").Replace(".", ""), 15, "0", True)
                If reg04.Index <> dgvRegistro04.Rows.Count - 1 Then
                    registros04 &= vbNewLine
                End If
            Next

            RegistroGeneralLSD = registro01 & vbNewLine & registros03 & vbNewLine & registros02 & vbNewLine & registros04
            'MsgBox(RegistroGeneralLSD)

        Catch ex As Exception

        End Try
    End Sub
    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Try
            ExportarRegistros()

            'Dim busquPeriodo As String = ""
            'For Each itemChecked As Object In CheckedListBox1.CheckedItems
            '    Dim row As DataRowView = TryCast(itemChecked, DataRowView)
            '    If busquPeriodo = "" Then
            '        busquPeriodo = row("periodoconcat").ToString
            '    Else
            '        busquPeriodo &= row("periodoconcat").ToString ()
            '    End If
            'Next
            carpetadestino.ShowDialog()
            'Dim carpeta As New IO.DirectoryInfo(carpetadestino.SelectedPath)
            Dim textoExportar = carpetadestino.SelectedPath & "\" & DatosEmpresa.Razon & "_LiquidacionSueldos_" & cmbperiodo.Text & ".txt"
            'Dim nombrealicutas = carpetadestino.SelectedPath & "\" & Replace(cmbperiodocarg.Text, "/", "") & "_COMPRASalicuotas_" & EmpDB.ToString & ".txt"
            Dim strStreamW As Stream = Nothing
            Dim strStreamWriter As StreamWriter = Nothing
            Windows.Forms.Cursor.Current = Cursors.WaitCursor

            If File.Exists(textoExportar) Then
                strStreamW = File.Open(textoExportar, FileMode.Open)
            Else
                strStreamW = File.Create(textoExportar)
            End If
            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default)
            strStreamWriter.Write(RegistroGeneralLSD)
            strStreamWriter.Close()
            MsgBox("Liquidacion de sueldos exportada")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub exportacionLSD_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Reconectar()

        Dim tablaperiodo As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT distinct(concat(periodo_pago,' ', mes, ' ', ano)) as periodo 
        from sdo_recibos order by id desc", conexionEmp)
        Dim readperiodo As New DataSet
        tablaperiodo.Fill(readperiodo)
        cmbperiodo.DataSource = readperiodo.Tables(0)
        cmbperiodo.DisplayMember = readperiodo.Tables(0).Columns(0).Caption.ToString
        'cmbperiodo.ValueMember = readperiodo.Tables(0).Columns(0).Caption.ToString
        cmbperiodo.SelectedIndex = -1
    End Sub

    Private Sub dgvRegistro04_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRegistro04.CellContentClick

    End Sub

    Private Sub dgvRegistro04_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRegistro04.CellEndEdit
        Try
            If e.ColumnIndex = 46 Then
                If IsNothing(Bimp10TEMPORAL) Then
                    ReDim Bimp10TEMPORAL(dgvRegistro04.Rows.Count)
                End If
                If dgvRegistro04.CurrentRow.Cells("ImporteADetraer").Value = "" Then
                    dgvRegistro04.CurrentRow.Cells("ImporteADetraer").Value = 0
                End If
                If Bimp10TEMPORAL(e.RowIndex) = "0" Or Bimp10TEMPORAL(e.RowIndex) = "" Then
                    Bimp10TEMPORAL(e.RowIndex) = dgvRegistro04.CurrentRow.Cells("BImp10").Value
                    dgvRegistro04.CurrentRow.Cells("BImp10").Value = FormatNumber(Bimp10TEMPORAL(e.RowIndex) - FormatNumber(dgvRegistro04.CurrentRow.Cells("ImporteADetraer").Value), 2)
                Else
                    dgvRegistro04.CurrentRow.Cells("BImp10").Value = FormatNumber(Bimp10TEMPORAL(e.RowIndex) - FormatNumber(dgvRegistro04.CurrentRow.Cells("ImporteADetraer").Value), 2)
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub exportacionLSD_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = "."c Then
            e.Handled = True
            SendKeys.Send(",")
        End If
    End Sub

    Private Sub txtImporteDetraer_TextChanged(sender As Object, e As EventArgs) Handles txtImporteDetraer.TextChanged

    End Sub

    Private Sub txtImporteDetraer_KeyUp(sender As Object, e As KeyEventArgs) Handles txtImporteDetraer.KeyUp
        Try

            If e.KeyCode = Keys.Enter Then
                If IsNothing(Bimp10TEMPORAL) Then
                    ReDim Bimp10TEMPORAL(dgvRegistro04.Rows.Count)
                End If
                If txtImporteDetraer.Text = "" Then
                        txtImporteDetraer.Text = 0
                    End If
                    For Each reg4 As DataGridViewRow In dgvRegistro04.Rows
                        If Bimp10TEMPORAL(reg4.Index) = "0" Or Bimp10TEMPORAL(reg4.Index) = "" Then
                            Bimp10TEMPORAL(reg4.Index) = reg4.Cells("BImp10").Value
                            reg4.Cells("ImporteADetraer").Value = FormatNumber(txtImporteDetraer.Text)
                            reg4.Cells("BImp10").Value = FormatNumber(Bimp10TEMPORAL(reg4.Index) - reg4.Cells("ImporteADetraer").Value, 2)
                        Else
                            reg4.Cells("ImporteADetraer").Value = FormatNumber(txtImporteDetraer.Text)
                            reg4.Cells("BImp10").Value = FormatNumber(Bimp10TEMPORAL(reg4.Index) - reg4.Cells("ImporteADetraer").Value, 2)
                        End If
                    Next
                End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtPorcTareaDif_TextChanged(sender As Object, e As EventArgs) Handles txtPorcTareaDif.TextChanged

    End Sub

    Private Sub txtPorcTareaDif_KeyUp(sender As Object, e As KeyEventArgs) Handles txtPorcTareaDif.KeyUp
        Try
            If e.KeyCode = Keys.Enter Then
                If txtPorcTareaDif.Text = "" Then
                    txtPorcTareaDif.Text = 0
                End If
                For Each reg4 As DataGridViewRow In dgvRegistro04.Rows
                    If reg4.Cells("cod_condicion").Value = 5 Then
                        reg4.Cells("contrTareaDif").Value = FormatNumber(txtPorcTareaDif.Text, 2)
                        'reg4.Cells("BImp10").Value = FormatNumber(reg4.Cells("BImp10").Value - reg4.Cells("ImporteADetraer").Value, 2)
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbperiodo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbperiodo.SelectedIndexChanged

    End Sub

    Private Sub cmbperiodo_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbperiodo.SelectionChangeCommitted


    End Sub

    Private Sub cmbperiodo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbperiodo.SelectedValueChanged
        Reconectar()
        Dim consultaliquidaciones As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT distinct(periodoconcat) from sdo_recibos where mes like (select mes from sdo_recibos where periodoConcat like '" & cmbperiodo.Text & "' limit 1) 
	    AND ano like (select ano from sdo_recibos where periodoConcat like '" & cmbperiodo.Text & "' limit 1)", conexionEmp)
        Dim tablaliquidaciones As New DataTable
        consultaliquidaciones.Fill(tablaliquidaciones)
        CheckedListBox1.DataSource = tablaliquidaciones
        CheckedListBox1.DisplayMember = "periodoconcat"
    End Sub
End Class