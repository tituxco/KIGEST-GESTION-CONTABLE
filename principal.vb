Public Class frmprincipal
    Public loged As Boolean
    'Public Pac As New frmaspirantes()
    Private Sub frmprincipal_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        End
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = Application.ProductName & " - V" & Application.ProductVersion

        'If (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed) Then
        'With System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion
        'Me.Text = "V" & .Major & "." & .Minor & "." & .Build
        'End With
        'End If
        Me.TopMost = False
        ToolStripProgressBar1.Visible = False
    End Sub

    Private Sub tmrcomprobarConexion_Tick(sender As Object, e As EventArgs) Handles tmrcomprobarConexion.Tick
        'chequeo cada 1 segundo el estado de conexion
        Reconectar()
        Try

            If conexionPrinc.State = ConnectionState.Broken Or conexionPrinc.State = ConnectionState.Closed Or conexionPrinc.Database = "" Then
                pntitulo.Enabled = False
            Else
                pntitulo.Enabled = True
            End If
            'compruebo las empresas
            lblstatusServer.Text = "Estado de servidor: " & conexionPrinc.State.ToString
            lblstatusBDprinc.Text = "Base de datos principal: " & conexionPrinc.Database
            'lblstatcodus.Text = "Codigo de usuario: " & codus
            'lblcolaborativocon.Text = "Colaborativo con: " & conexionColab.Database
            lblStatusEmp.Text = "Empresa en uso: " & ">>>" & conexionEmp.Database

        Catch ex As Exception
            lblstatusgral.Text = "Atencion: " & ex.Message
        End Try
    End Sub

    Private Sub CerrarConexionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CerrarConexionToolStripMenuItem.Click
        Try
            Reconectar()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ReconectarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReconectarToolStripMenuItem.Click

        Try
            Reconectar()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub frmprincipal_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        pntitulo.Width = Me.Size.Width

        ' cmdsalir.Left = Me.Size.Width - 150
        ' Label2.Top = Me.Height - 70

    End Sub
    Private Sub ToolStripSplitButton1_ButtonClick(sender As Object, e As EventArgs) Handles ToolStripSplitButton1.ButtonClick
        Reconectar()
        lblstatusServer.Text = "Estado de servidor: " & conexionPrinc.State.ToString
        lblstatusBDprinc.Text = "Base de datos principal: " & conexionPrinc.Database
        ' lblStatusEmp.Text = "Empresa Seleccionada: " & conexionEmp.State.ToString & ">>>" & conexionEmp.Database
        'Label2.Text = ""
    End Sub

    Private Sub cmdsalir_Click(sender As Object, e As EventArgs)
        End
    End Sub

    Private Sub cmdempresas_Click(sender As Object, e As EventArgs) Handles cmdempresas.Click
        Dim i As Integer
        'frmaspirantes.Show()
        For i = 0 To Me.MdiChildren.Length - 1
            If MdiChildren(i).Name = "frmabmempresa" Then
                Me.MdiChildren(i).BringToFront()
                Exit Sub
            End If
        Next

        Dim empr As New frmabmempresa
        empr.MdiParent = Me
        empr.Show()
        'cmdempresas.Enabled = False
    End Sub

    Private Sub cmdmantenimiento_Click(sender As Object, e As EventArgs) Handles cmdmantenimiento.Click
        Dim i As Integer
        'frmaspirantes.Show()
        For i = 0 To Me.MdiChildren.Length - 1
            If MdiChildren(i).Name = "mantenimiento" Then
                Me.MdiChildren(i).BringToFront()
                Exit Sub
            End If
        Next

        Dim mant As New mantenimiento
        mant.MdiParent = Me
        mant.Show()
        'cmdmantenimiento.Enabled = False
    End Sub

 
    Private Sub cmdrecibos_Click(sender As Object, e As EventArgs) Handles cmdrecibos.Click
        Dim i As Integer
        'If InStrRev(DatosAcceso.Moduloacc, 1) = 0 Then
        '    MsgBox("NO esta autorizado a ingresar al modulo de sueldos")
        '    Exit Sub
        'End If
        'frmaspirantes.Show()
        For i = 0 To Me.MdiChildren.Length - 1
            If MdiChildren(i).Name = "recibos" Then
                Me.MdiChildren(i).BringToFront()
                Exit Sub
            End If
        Next

        If conexionEmp.Database = "" Then
            MsgBox("Debe seleccionar una empresa antes de ver el personal")
        Else
            Dim rec As New recibos
            rec.MdiParent = Me
            rec.Show()
            'cmdrecibos.Enabled = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim i As Integer
        'If InStrRev(DatosAcceso.Moduloacc, 2) = 0 Then
        '    MsgBox("NO esta autorizado a ingresar al modulo iva")
        '    Exit Sub
        'End If
        'frmaspirantes.Show()
        For i = 0 To Me.MdiChildren.Length - 1
            If MdiChildren(i).Name = "iva" Then
                Me.MdiChildren(i).BringToFront()
                Exit Sub
            End If
        Next

        If conexionEmp.Database = "" Then
            MsgBox("Debe seleccionar una empresa antes de ver los libros de iva")
        Else
            Dim iva As New iva
            iva.MdiParent = Me
            iva.Show()
            'cmdrecibos.Enabled = False
        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class