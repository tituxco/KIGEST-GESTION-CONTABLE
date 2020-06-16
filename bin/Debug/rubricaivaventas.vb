Imports Microsoft.Reporting.WinForms
Public Class rubricaivaventas

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim pie As String
            Dim encabezado As String
            Reconectar()
            conexionPrinc.ChangeDatabase(database)

            ' Dim cadenaBD As String = EmpDB & ".sdo_personal as per," & database & ".cm_empresas as emp, " & EmpDB & ".sdo_recibos as rec"
            'Dim tabRecibos As New MySql.Data.MySqlClient.MySqlDataAdapter
            ' Dim ds As New DatasetRecibos
            'tabRecibos.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select concat('Empleador: ',emp.razon, '\n', 'Domicilio: ',emp.direccion,'\n','C.U.I.T.: ',emp.cuit) as empresadtos where idempresas=" & DatosEmpresa.IdEmpresa, conexionPrinc)
            Dim lector As System.Data.IDataReader
            Dim sql As New MySql.Data.MySqlClient.MySqlCommand
            sql.Connection = conexionPrinc
            sql.CommandText = "select concat('Empresa: ',emp.razon, '\n', 'Domicilio: ',emp.direccion,'\n','C.U.I.T.: ',emp.cuit) as empresadtos from cm_empresas as emp where idempresas=" & DatosEmpresa.IdEmpresa
            sql.CommandType = CommandType.Text
            lector = sql.ExecuteReader
            lector.Read()
            encabezado = lector("empresadtos").ToString


            Dim parameters As New List(Of Microsoft.Reporting.WinForms.ReportParameter)()

            Dim i As Integer

            For i = 1 To Val(txthojas.Text) * 45
                pie = pie & i & vbNewLine
            Next
            parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("pie", pie))
            parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("empresa", encabezado))

            rpthojas.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\RubricaIvaVentas.rdlc"
            rpthojas.LocalReport.DataSources.Clear()

            rpthojas.LocalReport.SetParameters(parameters)
            rpthojas.DocumentMapCollapsed = True
            Me.rpthojas.RefreshReport()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class