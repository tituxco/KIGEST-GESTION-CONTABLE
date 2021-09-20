Imports System.IO

Public Class exportacionLSD
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
                ConceptosAExportar &= " " 'LIBRE
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

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try
            If txtperiodo.Text = "" Then
                MsgBox("Debe ingresar un periodo liquidado previamente")
            End If
            Reconectar()
            Dim consultaRegistro02 As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT '02' as CodRegistro,rec.cuil,rec.idpersonal as legajo,'' as dependencia,  if(lsd.forma_pago=3,per.sueldocuenta,'') as CBU,
            '0' as DiasTope,rec.fecha_pago,'' as fechaRubrica,lsd.forma_pago
            FROM 
            sdo_recibos as rec, sdo_personal as per, sdo_personal_infoLSD as lsd where
            rec.idpersonal=per.idpersonal and rec.idpersonal=lsd.idpersonal and
            rec.fecha_pago like '%%-" & txtperiodo.Text & "'	
            ", conexionEmp)
            Dim tablaRegistro02 As New DataTable
            consultaRegistro02.Fill(tablaRegistro02)
            dgvregistro02.DataSource = tablaRegistro02
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
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
                registros02 &= vbNewLine
            Next

            carpetadestino.ShowDialog()
            'Dim carpeta As New IO.DirectoryInfo(carpetadestino.SelectedPath)
            Dim textoExportar = carpetadestino.SelectedPath & "\registros02_" & txtperiodo.Text & ".txt"
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
            strStreamWriter.Write(registros02)
            strStreamWriter.Close()
            MsgBox("archivo de registros tipo (02) exportado")


        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Try
            If txtperiodo.Text = "" Then
                MsgBox("Debe ingresar un periodo liquidado previamente")
            End If
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
            itm.idrecibo=rec.id and
            rec.fecha_pago like '%%-" & txtperiodo.Text & "'", conexionEmp)
            Dim tablaRegistro03 As New DataTable
            consultaRegistro03.Fill(tablaRegistro03)
            dgvRegistro03.DataSource = tablaRegistro03
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Try
            Dim registros03 As String = ""
            For Each reg03 As DataGridViewRow In dgvRegistro03.Rows
                registros03 &= reg03.Cells("CodRegistro").Value
                registros03 &= parametrizarCampo(reg03.Cells("cuil").Value.ToString.Replace("-", ""), 11, "0", True)
                registros03 &= parametrizarCampo(reg03.Cells("codigo").Value, 10, " ", False)
                registros03 &= parametrizarCampo(reg03.Cells("cantidad").Value.ToString.Replace(".", ""), 5, "0", True)
                registros03 &= parametrizarCampo(reg03.Cells("unidad").Value, 1, " ", False)
                registros03 &= parametrizarCampo(reg03.Cells("importe").Value.ToString.Replace(".", ""), 15, "0", True)
                registros03 &= parametrizarCampo(reg03.Cells("deb_cred").Value, 1, " ", False)
                registros03 &= parametrizarCampo(reg03.Cells("per_ajuste").Value, 6, " ", False)
                registros03 &= vbNewLine
            Next

            carpetadestino.ShowDialog()
            'Dim carpeta As New IO.DirectoryInfo(carpetadestino.SelectedPath)
            Dim textoExportar = carpetadestino.SelectedPath & "\registros03_" & txtperiodo.Text & ".txt"
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
            strStreamWriter.Write(registros03)
            strStreamWriter.Close()
            MsgBox("archivo de registros tipo (03) exportado")

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Try
            If txtperiodo.Text = "" Then
                MsgBox("Debe ingresar un periodo liquidado previamente")
            End If
            Reconectar()
            Dim consultaRegistro04 As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT '04' AS CodRegistro, per.cuil, lsd.conyuge,lsd.cant_hijos, 
lsd.adherido_cct as marcaCCT,lsd.cobertura_scvo as marcaSCVO,
lsd.corresponde_reduccion as marcaReduccion,lsd.tipo_empresa, '0' as codOperacion,lsd.situacion_revista, lsd.cod_condicion,
lsd.activ_empleado, lsd.modalidad_contratacion, lsd.cod_siniestrado, lsd.cod_localidad,'0' as revista1, '0' as diaRevista1,
'0' as revista2, '0' as diaRevista2,'0' as revista3, '0' as diaRevista3, '30' as diasTrab, '0' as horasTrab, 
'0' as PorcApAdic,'0' as contrTareaDif,
lsd.cod_obraSocial, lsd.cant_adherentes,
'0' as aporteAdicOS,
'0' as contribAdicOS,
'0' as baseCalcDiferencialAporteOSyFSR,
'0' as baseCalcDiferencialContribOSyFSR,
'0' as baseCalcDiferencialContribLRT,
'0' as RemMaternidadANSES,
(select sum(replace(replace(remunerativo,'.',''),',','.'))+sum(replace(replace(noremunerativo,'.',''),',','.')) from sdo_items_recibos as itm where itm.idrecibo=rec.id) as remBruta,
(SELECT sum(case
when length(itm.remunerativo)<>0 then replace(replace(remunerativo,'.',''),',','.')
when length(itm.noremunerativo)<>0 then replace(replace(noremunerativo,'.',''),',','.')
when length(itm.deducciones)<>0 then replace(replace(deducciones,'.',''),',','.')
end )
FROM sdo_items_recibos as itm, " & conexionPrinc.Database & ".cm_sdo_infoExtraLSD where 
" & conexionPrinc.Database & ".cm_sdo_infoExtraLSD.codInt=itm.codigo and " & conexionPrinc.Database & ".cm_sdo_infoExtraLSD.BImp1=1 and
rec.id=itm.idrecibo
) as BImp1,
(SELECT sum(case
when length(itm.remunerativo)<>0 then replace(replace(remunerativo,'.',''),',','.')
when length(itm.noremunerativo)<>0 then replace(replace(noremunerativo,'.',''),',','.')
when length(itm.deducciones)<>0 then replace(replace(deducciones,'.',''),',','.')
end )
FROM sdo_items_recibos as itm, " & conexionPrinc.Database & ".cm_sdo_infoExtraLSD where 
" & conexionPrinc.Database & ".cm_sdo_infoExtraLSD.codInt=itm.codigo and " & conexionPrinc.Database & ".cm_sdo_infoExtraLSD.BImp2=1 and
rec.id=itm.idrecibo
) as BImp2,
(SELECT sum(case
when length(itm.remunerativo)<>0 then replace(replace(remunerativo,'.',''),',','.')
when length(itm.noremunerativo)<>0 then replace(replace(noremunerativo,'.',''),',','.')
when length(itm.deducciones)<>0 then replace(replace(deducciones,'.',''),',','.')
end )
FROM sdo_items_recibos as itm, " & conexionPrinc.Database & ".cm_sdo_infoExtraLSD where 
" & conexionPrinc.Database & ".cm_sdo_infoExtraLSD.codInt=itm.codigo and " & conexionPrinc.Database & ".cm_sdo_infoExtraLSD.BImp3=1 and
rec.id=itm.idrecibo
) as BImp3,
(SELECT sum(case
when length(itm.remunerativo)<>0 then replace(replace(remunerativo,'.',''),',','.')
when length(itm.noremunerativo)<>0 then replace(replace(noremunerativo,'.',''),',','.')
when length(itm.deducciones)<>0 then replace(replace(deducciones,'.',''),',','.')
end )
FROM sdo_items_recibos as itm, " & conexionPrinc.Database & ".cm_sdo_infoExtraLSD where 
" & conexionPrinc.Database & ".cm_sdo_infoExtraLSD.codInt=itm.codigo and " & conexionPrinc.Database & ".cm_sdo_infoExtraLSD.BImp4=1 and
rec.id=itm.idrecibo
) as BImp4,
(SELECT sum(case
when length(itm.remunerativo)<>0 then replace(replace(remunerativo,'.',''),',','.')
when length(itm.noremunerativo)<>0 then replace(replace(noremunerativo,'.',''),',','.')
when length(itm.deducciones)<>0 then replace(replace(deducciones,'.',''),',','.')
end )
FROM sdo_items_recibos as itm, " & conexionPrinc.Database & ".cm_sdo_infoExtraLSD where 
" & conexionPrinc.Database & ".cm_sdo_infoExtraLSD.codInt=itm.codigo and " & conexionPrinc.Database & ".cm_sdo_infoExtraLSD.BImp5=1 and
rec.id=itm.idrecibo
) as BImp5,
ifnull(0,(SELECT sum(case
when length(itm.remunerativo)<>0 then replace(replace(remunerativo,'.',''),',','.')
when length(itm.noremunerativo)<>0 then replace(replace(noremunerativo,'.',''),',','.')
when length(itm.deducciones)<>0 then replace(replace(deducciones,'.',''),',','.')
end )
FROM sdo_items_recibos as itm, " & conexionPrinc.Database & ".cm_sdo_infoExtraLSD where 
" & conexionPrinc.Database & ".cm_sdo_infoExtraLSD.codInt=itm.codigo and " & conexionPrinc.Database & ".cm_sdo_infoExtraLSD.BImp6=1 and
rec.id=itm.idrecibo
)) as BImp6,
ifnull(0,(SELECT sum(case
when length(itm.remunerativo)<>0 then replace(replace(remunerativo,'.',''),',','.')
when length(itm.noremunerativo)<>0 then replace(replace(noremunerativo,'.',''),',','.')
when length(itm.deducciones)<>0 then replace(replace(deducciones,'.',''),',','.')
end )
FROM sdo_items_recibos as itm, " & conexionPrinc.Database & ".cm_sdo_infoExtraLSD where 
" & conexionPrinc.Database & ".cm_sdo_infoExtraLSD.codInt=itm.codigo and " & conexionPrinc.Database & ".cm_sdo_infoExtraLSD.BImp7=1 and
rec.id=itm.idrecibo
)) as BImp7,
(SELECT sum(case
when length(itm.remunerativo)<>0 then replace(replace(remunerativo,'.',''),',','.')
when length(itm.noremunerativo)<>0 then replace(replace(noremunerativo,'.',''),',','.')
when length(itm.deducciones)<>0 then replace(replace(deducciones,'.',''),',','.')
end )
FROM sdo_items_recibos as itm, " & conexionPrinc.Database & ".cm_sdo_infoExtraLSD where 
" & conexionPrinc.Database & ".cm_sdo_infoExtraLSD.codInt=itm.codigo and " & conexionPrinc.Database & ".cm_sdo_infoExtraLSD.BImp8=1 and
rec.id=itm.idrecibo
) as BImp8,
(SELECT sum(case
when length(itm.remunerativo)<>0 then replace(replace(remunerativo,'.',''),',','.')
when length(itm.noremunerativo)<>0 then replace(replace(noremunerativo,'.',''),',','.')
when length(itm.deducciones)<>0 then replace(replace(deducciones,'.',''),',','.')
end )
FROM sdo_items_recibos as itm, " & conexionPrinc.Database & ".cm_sdo_infoExtraLSD where 
" & conexionPrinc.Database & ".cm_sdo_infoExtraLSD.codInt=itm.codigo and " & conexionPrinc.Database & ".cm_sdo_infoExtraLSD.BImp9=1 and
rec.id=itm.idrecibo
) as BImp9,
ifnull(0,(SELECT sum(case
when length(itm.remunerativo)<>0 then replace(replace(remunerativo,'.',''),',','.')
when length(itm.noremunerativo)<>0 then replace(replace(noremunerativo,'.',''),',','.')
when length(itm.deducciones)<>0 then replace(replace(deducciones,'.',''),',','.')
end )
FROM sdo_items_recibos as itm, " & conexionPrinc.Database & ".cm_sdo_infoExtraLSD where 
" & conexionPrinc.Database & ".cm_sdo_infoExtraLSD.codInt=itm.codigo and " & conexionPrinc.Database & ".cm_sdo_infoExtraLSD.BaseAporteSegSoc=1 and
rec.id=itm.idrecibo
)) as BaseCalcDifAporteSegSoc,
ifnull(0,(SELECT sum(case
when length(itm.remunerativo)<>0 then replace(replace(remunerativo,'.',''),',','.')
when length(itm.noremunerativo)<>0 then replace(replace(noremunerativo,'.',''),',','.')
when length(itm.deducciones)<>0 then replace(replace(deducciones,'.',''),',','.')
end )
FROM sdo_items_recibos as itm, " & conexionPrinc.Database & ".cm_sdo_infoExtraLSD where 
" & conexionPrinc.Database & ".cm_sdo_infoExtraLSD.codInt=itm.codigo and " & conexionPrinc.Database & ".cm_sdo_infoExtraLSD.BaseContribSegSoc=1 and
rec.id=itm.idrecibo
)) as BaseCalcDifContribSegSoc,
(SELECT sum(case
when length(itm.remunerativo)<>0 then replace(replace(remunerativo,'.',''),',','.')
when length(itm.noremunerativo)<>0 then replace(replace(noremunerativo,'.',''),',','.')
when length(itm.deducciones)<>0 then replace(replace(deducciones,'.',''),',','.')
end )
FROM sdo_items_recibos as itm, " & conexionPrinc.Database & ".cm_sdo_infoExtraLSD where 
" & conexionPrinc.Database & ".cm_sdo_infoExtraLSD.codInt=itm.codigo and " & conexionPrinc.Database & ".cm_sdo_infoExtraLSD.BImp10=1 and
rec.id=itm.idrecibo
) as BImp10,
'0' as ImporteADetraer
from
sdo_recibos as rec, sdo_personal as per, sdo_personal_infoLSD as lsd where
rec.idpersonal=per.idpersonal and per.idpersonal=lsd.idpersonal
and rec.fecha_pago like '%%-" & txtperiodo.Text & "'", conexionEmp)
            Dim tablaRegistro04 As New DataTable
            consultaRegistro04.Fill(tablaRegistro04)
            dgvRegistro04.DataSource = tablaRegistro04
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Try
            Dim registros04 As String = ""
            For Each reg04 As DataGridViewRow In dgvRegistro04.Rows
                registros04 &= reg04.Cells("CodRegistro").Value
                registros04 &= parametrizarCampo(reg04.Cells("cuil").Value.ToString.Replace("-", ""), 11, "0", True)
                registros04 &= parametrizarCampo(reg04.Cells("conyuge").Value, 1, "0", False)
                registros04 &= parametrizarCampo(reg04.Cells("cant_hijos").Value, 2, "0", False)
                registros04 &= parametrizarCampo(reg04.Cells("marcaCCT").Value, 1, "0", False)
                registros04 &= parametrizarCampo(reg04.Cells("marcaSCVO").Value, 1, "0", False)
                registros04 &= parametrizarCampo(reg04.Cells("marcaReduccion").Value, 1, "0", False)
                registros04 &= parametrizarCampo(reg04.Cells("tipo_empresa").Value, 1, "1", False)
                registros04 &= parametrizarCampo(reg04.Cells("codOperacion").Value, 1, "0", False)
                registros04 &= parametrizarCampo(reg04.Cells("situacion_revista").Value, 2, "0", False)
                registros04 &= parametrizarCampo(reg04.Cells("cod_condicion").Value, 2, "0", False)
                registros04 &= parametrizarCampo(reg04.Cells("activ_empleado").Value, 3, "0", False)
                registros04 &= parametrizarCampo(reg04.Cells("modalidad_contratacion").Value, 3, "0", False)
                registros04 &= parametrizarCampo(reg04.Cells("cod_siniestrado").Value, 2, "0", False)
                registros04 &= parametrizarCampo(reg04.Cells("cod_localidad").Value, 2, "0", False)
                registros04 &= parametrizarCampo(reg04.Cells("revista1").Value, 2, "0", False)
                registros04 &= parametrizarCampo(reg04.Cells("diaRevista1").Value, 2, "0", False)
                registros04 &= parametrizarCampo(reg04.Cells("revista2").Value, 2, "0", False)
                registros04 &= parametrizarCampo(reg04.Cells("diaRevista2").Value, 2, "0", False)
                registros04 &= parametrizarCampo(reg04.Cells("revista3").Value, 2, "0", False)
                registros04 &= parametrizarCampo(reg04.Cells("diaRevista3").Value, 2, "0", False)
                registros04 &= parametrizarCampo(reg04.Cells("diasTrab").Value, 2, "0", True)
                registros04 &= parametrizarCampo(reg04.Cells("horasTrab").Value, 3, "0", True)
                'registros04 &= parametrizarCampo(reg04.Cells("diaRevista1").Value, 2, "0", False)
                registros04 &= parametrizarCampo(reg04.Cells("PorcApAdic").Value, 5, "0", True)
                registros04 &= parametrizarCampo(reg04.Cells("contrTareaDif").Value, 5, "0", False)
                registros04 &= parametrizarCampo(reg04.Cells("cod_obraSocial").Value, 6, " ", False)
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
                registros04 &= vbNewLine
            Next

            carpetadestino.ShowDialog()
            'Dim carpeta As New IO.DirectoryInfo(carpetadestino.SelectedPath)
            Dim textoExportar = carpetadestino.SelectedPath & "\registros04_" & txtperiodo.Text & ".txt"
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
            strStreamWriter.Write(registros04)
            strStreamWriter.Close()
            MsgBox("archivo de registros tipo (04) exportado")

        Catch ex As Exception

        End Try
    End Sub
End Class