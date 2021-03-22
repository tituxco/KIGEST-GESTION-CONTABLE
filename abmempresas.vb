Public Class frmabmempresa
    Private BindingSourceemp As Windows.Forms.BindingSource = New BindingSource
    Private Sub frmabmempresa_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        frmprincipal.cmdempresas.Enabled = True
    End Sub

    Private Sub frmabmempresa_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.F12 Then
            If GroupBox1.Visible = False Then
                GroupBox1.Visible = True
            Else
                GroupBox1.Visible = True
            End If
        End If
    End Sub

    Private Sub frmabmempresa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargar_empresas()
        marcar()
        'Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub cmdempresas_Click(sender As Object, e As EventArgs) Handles cmdempresas.Click
        Dim addemp As New frmaddempresas
        addemp.MdiParent = Me.MdiParent
        addemp.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Public Sub cargar_empresas()
        Dim i As Integer
        Try
            Reconectar()
            conexionPrinc.ChangeDatabase(database)
            Dim mm As New MySql.Data.MySqlClient.MySqlDataAdapter("select idempresas as Codigo, razon as RazonSocial, nombre as NombreFantasia, cuit as CUIT, lower(tabla) as TablaDatos, hojacomp, hojavent from cm_empresas", conexionPrinc)
            Dim tabla As New DataTable
            Dim ds As New DataSet
            mm.Fill(tabla)
            BindingSourceemp.DataSource = tabla
            dtempresas.DataSource = BindingSourceemp
            'marcar()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub marcar()
        For i = 0 To dtempresas.RowCount - 1
            If dtempresas.Rows(i).Cells(0).Value = DatosEmpresa.IdEmpresa Then
                'MsgBox(dtempresas.Rows(i).Cells(4).Value)
                dtempresas.Rows(i).DefaultCellStyle.BackColor = Color.Gold
                'MsgBox("ok" & i)
            Else
                'MsgBox("no" & i)
                dtempresas.Rows(i).DefaultCellStyle.BackColor = Color.White
            End If
        Next i
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Reconectar()
        EmpDB = dtempresas.CurrentRow.Cells.Item(4).Value.ToString
        ConectarEmpresa(dtempresas.CurrentRow.Cells.Item(4).Value.ToString)
        'dtempresas.CurrentRow.DefaultCellStyle.BackColor = Color.Gold
        DatosEmpresa.IdEmpresa = dtempresas.CurrentRow.Cells.Item(0).Value
        marcar()

    End Sub

    Private Sub dtempresas_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dtempresas.CellEndEdit
        Dim sqlQuery As String
        Select Case e.ColumnIndex
            Case 5
                sqlQuery = "update cm_empresas set hojacomp='" & dtempresas.CurrentCell.Value & "' where idempresas=" & dtempresas.CurrentRow.Cells(0).Value
            Case 6
                sqlQuery = "update cm_empresas set hojavent='" & dtempresas.CurrentCell.Value & "' where idempresas=" & dtempresas.CurrentRow.Cells(0).Value
        End Select
        Dim comandoupd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionPrinc)
        comandoupd.ExecuteNonQuery()
        MsgBox("datos actualizados")
    End Sub

    Private Sub dtempresas_Paint(sender As Object, e As PaintEventArgs) Handles dtempresas.Paint
        marcar()
    End Sub

    Private Sub cmdmodificar_Click(sender As Object, e As EventArgs) Handles cmdmodificar.Click
        Dim addemp As New frmaddempresas
        Reconectar()
        addemp.MdiParent = Me.MdiParent
        addemp.modificar = True
        addemp.Show()
        EmpDB = dtempresas.CurrentRow.Cells.Item(4).Value.ToString
        ConectarEmpresa(dtempresas.CurrentRow.Cells.Item(4).Value.ToString)
        'dtempresas.CurrentRow.DefaultCellStyle.BackColor = Color.Gold
        DatosEmpresa.IdEmpresa = dtempresas.CurrentRow.Cells.Item(0).Value
        marcar()
    End Sub

    Private Sub txtbuscaemp_TextChanged(sender As Object, e As EventArgs) Handles txtbuscaemp.TextChanged
        BindingSourceemp.Filter = "RazonSocial Like '%" & txtbuscaemp.Text & "%'"
    End Sub


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try

            Dim sqlquery As String
            sqlquery = txtsentencias.Text
            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlquery, conexionEmp)
            comandoadd.ExecuteNonQuery()
            MsgBox("ejecutado")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        cargar_empresas()
        marcar()
    End Sub

    Private Sub Label17_Click(sender As Object, e As EventArgs) Handles Label17.Click

    End Sub
End Class