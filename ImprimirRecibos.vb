Imports Microsoft.Reporting.WinForms
Public Class ImprimirRecibos
    Public idEmpresa As Integer
    Private Sub cmdverrecibos_Click(sender As Object, e As EventArgs) Handles cmdverrecibos.Click
        Try
            If cmbperiodo.Text = "" Then
                MsgBox("No selecciono un periodo")
                Exit Sub
            End If
            Reconectar()
            conexionPrinc.ChangeDatabase(database)
            conexionEmp.ChangeDatabase(EmpDB)

            Dim cadenaBD As String = EmpDB & ".sdo_personal as per," & database & ".cm_empresas as emp, " & EmpDB & ".sdo_recibos as rec"
            Dim tabRecibos As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim tabItems As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim ds As New DatasetRecibos
            tabRecibos.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select rec.idpersonal, concat(per.apellidos,', ', per.nombre) as nombreapellido, " _
            & "rec.dni as documento, rec.cuil,  rec.fecha_ingreso as fechaingreso, rec.antiguedad, rec.convenio, rec.categoria, concat(rec.periodo_pago,' ', rec.mes,' ', rec.ano) as periodoliquidado, " _
            & "rec.fecha_pago as fechapago, rec.basico as sueldobasico, concat('Empleador: ',emp.razon, '\n', 'Domicilio: ',emp.direccion,'\n','C.U.I.T.: ',emp.cuit) as empresadtos, rec.id as id, rec.total_remunerativo as totrem, rec.total_noremunerativo as totnorem, rec.total_descuentos as totdedu, " _
            & "rec.total_neto as totneto, enletras as letras, sueldobanco, sueldocuenta,aportebanco,aportefecha,aporteperiodo, lugarpago from " & cadenaBD & " where periodoConcat like '%" & cmbperiodo.Text & "%' and rec.idpersonal=per.idpersonal and per.empresa=emp.idempresas", conexionEmp)
            tabItems.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select codigo, concepto, unidades, remunerativo, noremunerativo, deducciones, idrecibo from sdo_items_recibos order by id asc", conexionEmp)

            tabRecibos.Fill(ds.Tables("ReciboEncabeza"))
            tabItems.Fill(ds.Tables("ReciboItems"))
            rptrecibo.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
            rptrecibo.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\ReciboEncabezado.rdlc"
            rptrecibo.LocalReport.DataSources.Clear()
            rptrecibo.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("EncabezaRecibo", ds.Tables("ReciboEncabeza")))

            AddHandler rptrecibo.LocalReport.SubreportProcessing, AddressOf Me.SubreportProcessingEventHandler

            rptrecibo.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("ItemsRecibos", ds.Tables("ReciboItems")))
            rptrecibo.DocumentMapCollapsed = True
            Me.rptrecibo.RefreshReport()
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
            tabItems.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select codigo, concepto, unidades, remunerativo, noremunerativo, deducciones, idrecibo from sdo_items_recibos order by codigo asc", conexionEmp)
            tabItems.Fill(ds.Tables("ReciboItems"))
            e.DataSources.Add(New ReportDataSource("ItemsRecibos", ds.Tables("ReciboItems")))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ImprimirRecibos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conexionEmp.ChangeDatabase(EmpDB)

        Dim tablaperiodo As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT distinct(concat(periodo_pago,' ', mes, ' ', ano)) as periodo from sdo_recibos order by mes desc", conexionEmp)
        Dim readperiodo As New DataSet
        tablaperiodo.Fill(readperiodo)
        cmbperiodo.DataSource = readperiodo.Tables(0)
        cmbperiodo.DisplayMember = readperiodo.Tables(0).Columns(0).Caption.ToString
        'cmbperiodo.ValueMember = readperiodo.Tables(0).Columns(0).Caption.ToString
        cmbperiodo.SelectedIndex = -1
    End Sub

End Class