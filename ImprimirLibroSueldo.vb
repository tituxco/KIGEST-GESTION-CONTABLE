Imports Microsoft.Reporting.WinForms
Public Class ImprimirLibroSueldo
    Public idEmpresa As Integer
    Public periodoSelecc As String = ""
    Private Sub cmdverlibros_Click(sender As Object, e As EventArgs) Handles cmdverlibros.Click
        Try
            If cmbperiodo.Text = "" Then
                MsgBox("No selecciono un periodo")
                Exit Sub
            End If
            periodoSelecc = cmbperiodo.Text
            Reconectar()
            conexionPrinc.ChangeDatabase(database)
            conexionEmp.ChangeDatabase(EmpDB)

            Dim cadenaBD As String = EmpDB & ".sdo_personal as per," & database & ".cm_empresas as emp, " & EmpDB & ".sdo_recibos as rec"
            Dim tabRecibos As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim tabItems As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim ds As New DatasetRecibos
            tabRecibos.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select rec.idpersonal, 
            concat(per.apellidos,', ', per.nombre) as nombreapellido, 
            rec.dni as documento, rec.cuil,  rec.fecha_ingreso as fechaingreso, rec.antiguedad, rec.convenio, rec.categoria, 
            concat(rec.periodo_pago,' ', rec.mes,' ', rec.ano) as periodoliquidado, 
            rec.fecha_pago as fechapago, rec.basico as sueldobasico, concat('Empresa: ',emp.razon, '\n', 'Domicilio: ',emp.direccion,'\n','Actividad: ',emp.activ_emp,'\n','C.U.I.T.: ',emp.cuit) as empresadtos, 
            rec.id as id, rec.total_remunerativo as totrem, rec.total_noremunerativo as totnorem, rec.total_descuentos as totdedu,
            rec.total_neto as totneto, enletras as letras 
            from " & cadenaBD & " 
            where periodoConcat like '" & periodoSelecc & "' and rec.idpersonal=per.idpersonal and per.empresa=emp.idempresas", conexionEmp)
            ' MsgBox(tabRecibos.SelectCommand.CommandText)

            tabItems.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select itm.codigo, itm.concepto, itm.unidades, itm.remunerativo, 
            itm.noremunerativo, itm.deducciones, itm.idrecibo 
            from sdo_items_recibos as itm, sdo_recibos as re 
            where itm.idrecibo= re.id and 
            re.periodoConcat like '" & periodoSelecc & "' order by itm.id asc", conexionEmp)

            tabRecibos.Fill(ds.Tables("ReciboEncabeza"))
            tabItems.Fill(ds.Tables("ReciboItems"))
            rptlibro.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
            rptlibro.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\Reportes\LibroSuelEncabeza.rdlc"
            rptlibro.LocalReport.DataSources.Clear()
            rptlibro.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("EncabezaRecibo", ds.Tables("ReciboEncabeza")))

            AddHandler rptlibro.LocalReport.SubreportProcessing, AddressOf Me.SubreportProcessingEventHandler
            rptlibro.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("ItemsRecibos", ds.Tables("ReciboItems")))
            rptlibro.DocumentMapCollapsed = True
            Me.rptlibro.RefreshReport()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub SubreportProcessingEventHandler(ByVal sender As Object, ByVal e As SubreportProcessingEventArgs)
        Try
            Reconectar()
            conexionEmp.ChangeDatabase(EmpDB)
            Dim ds As New DatasetRecibos
            Dim tabItems As New MySql.Data.MySqlClient.MySqlDataAdapter
            tabItems.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select itm.codigo, itm.concepto, itm.unidades, itm.remunerativo, 
            itm.noremunerativo, itm.deducciones, itm.idrecibo 
            from sdo_items_recibos as itm, sdo_recibos as re 
            where itm.idrecibo= re.id and 
            re.periodoConcat like '" & periodoSelecc & "' order by itm.id asc", conexionEmp)
            tabItems.Fill(ds.Tables("ReciboItems"))
            e.DataSources.Add(New ReportDataSource("ItemsRecibos", ds.Tables("ReciboItems")))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ImprimirLibroSueldo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Reconectar()
            conexionEmp.ChangeDatabase(EmpDB)
            Dim tablaperiodo As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT distinct(concat(periodo_pago,' ', mes, ' ', ano)) as periodo from sdo_recibos order by id desc", conexionEmp)
            Dim readperiodo As New DataSet
            tablaperiodo.Fill(readperiodo)
            cmbperiodo.DataSource = readperiodo.Tables(0)
            cmbperiodo.DisplayMember = readperiodo.Tables(0).Columns(0).Caption.ToString
            'cmbperiodo.ValueMember = readperiodo.Tables(0).Columns(0).Caption.ToString
            cmbperiodo.SelectedIndex = -1
        Catch ex As Exception

        End Try
    End Sub
End Class