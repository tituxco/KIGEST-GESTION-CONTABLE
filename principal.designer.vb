<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmprincipal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmprincipal))
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.CerrarConexionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReconectarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSplitButton1 = New System.Windows.Forms.ToolStripSplitButton()
        Me.lblstatusServer = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblstatusBDprinc = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblStatusEmp = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblstatusgral = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tmrcomprobarConexion = New System.Windows.Forms.Timer(Me.components)
        Me.pntitulo = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmdrecibos = New System.Windows.Forms.Button()
        Me.cmdmantenimiento = New System.Windows.Forms.Button()
        Me.cmdempresas = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.StatusStrip1.SuspendLayout()
        Me.pntitulo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Font = New System.Drawing.Font("Sansation", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripDropDownButton1, Me.ToolStripSplitButton1, Me.lblstatusServer, Me.lblstatusBDprinc, Me.lblStatusEmp, Me.ToolStripProgressBar1, Me.ToolStripStatusLabel1, Me.lblstatusgral})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 696)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1224, 24)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CerrarConexionToolStripMenuItem, Me.ReconectarToolStripMenuItem})
        Me.ToolStripDropDownButton1.Image = CType(resources.GetObject("ToolStripDropDownButton1.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(29, 22)
        Me.ToolStripDropDownButton1.Text = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.ToolTipText = "Manejar Servidor"
        '
        'CerrarConexionToolStripMenuItem
        '
        Me.CerrarConexionToolStripMenuItem.Name = "CerrarConexionToolStripMenuItem"
        Me.CerrarConexionToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.CerrarConexionToolStripMenuItem.Text = "Cerrar Conexión"
        '
        'ReconectarToolStripMenuItem
        '
        Me.ReconectarToolStripMenuItem.Name = "ReconectarToolStripMenuItem"
        Me.ReconectarToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.ReconectarToolStripMenuItem.Text = "Reconectar"
        '
        'ToolStripSplitButton1
        '
        Me.ToolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripSplitButton1.Image = CType(resources.GetObject("ToolStripSplitButton1.Image"), System.Drawing.Image)
        Me.ToolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton1.Name = "ToolStripSplitButton1"
        Me.ToolStripSplitButton1.Size = New System.Drawing.Size(32, 22)
        Me.ToolStripSplitButton1.Text = "ToolStripSplitButton1"
        Me.ToolStripSplitButton1.ToolTipText = "Reconectar servidor"
        '
        'lblstatusServer
        '
        Me.lblstatusServer.Font = New System.Drawing.Font("Sansation", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblstatusServer.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblstatusServer.Name = "lblstatusServer"
        Me.lblstatusServer.Size = New System.Drawing.Size(114, 19)
        Me.lblstatusServer.Text = "Estado del Servidor"
        Me.lblstatusServer.ToolTipText = "Estado de la conexion principal con el servidor"
        '
        'lblstatusBDprinc
        '
        Me.lblstatusBDprinc.Font = New System.Drawing.Font("Sansation", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblstatusBDprinc.ForeColor = System.Drawing.Color.Green
        Me.lblstatusBDprinc.Name = "lblstatusBDprinc"
        Me.lblstatusBDprinc.Size = New System.Drawing.Size(139, 19)
        Me.lblstatusBDprinc.Text = "Base de datos principal:"
        Me.lblstatusBDprinc.ToolTipText = "Nombre de la base de datos principal del sistema"
        '
        'lblStatusEmp
        '
        Me.lblStatusEmp.Font = New System.Drawing.Font("Sansation", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusEmp.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblStatusEmp.Name = "lblStatusEmp"
        Me.lblStatusEmp.Size = New System.Drawing.Size(0, 19)
        Me.lblStatusEmp.ToolTipText = "Empresa con la que se esta trabajando actualmente"
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(100, 18)
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left
        Me.ToolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Sansation", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(309, 19)
        Me.ToolStripStatusLabel1.Text = "KIBIT Informática - 03482-427888 - info@kibit.com.ar"
        '
        'lblstatusgral
        '
        Me.lblstatusgral.Name = "lblstatusgral"
        Me.lblstatusgral.Size = New System.Drawing.Size(0, 19)
        '
        'tmrcomprobarConexion
        '
        Me.tmrcomprobarConexion.Enabled = True
        Me.tmrcomprobarConexion.Interval = 1000
        '
        'pntitulo
        '
        Me.pntitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.pntitulo.BackgroundImage = CType(resources.GetObject("pntitulo.BackgroundImage"), System.Drawing.Image)
        Me.pntitulo.Controls.Add(Me.Label1)
        Me.pntitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pntitulo.Location = New System.Drawing.Point(0, 0)
        Me.pntitulo.Name = "pntitulo"
        Me.pntitulo.Size = New System.Drawing.Size(1224, 27)
        Me.pntitulo.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1224, 27)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "KIGEST - Gestión Contable"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.cmdrecibos)
        Me.Panel1.Controls.Add(Me.cmdmantenimiento)
        Me.Panel1.Controls.Add(Me.cmdempresas)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 27)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(87, 669)
        Me.Panel1.TabIndex = 13
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Transparent
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(4, 142)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 65)
        Me.Button1.TabIndex = 28
        Me.Button1.Text = "IVA"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button1.UseVisualStyleBackColor = False
        '
        'cmdrecibos
        '
        Me.cmdrecibos.BackColor = System.Drawing.Color.Transparent
        Me.cmdrecibos.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.cmdrecibos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdrecibos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdrecibos.ForeColor = System.Drawing.Color.Transparent
        Me.cmdrecibos.Image = CType(resources.GetObject("cmdrecibos.Image"), System.Drawing.Image)
        Me.cmdrecibos.Location = New System.Drawing.Point(4, 71)
        Me.cmdrecibos.Name = "cmdrecibos"
        Me.cmdrecibos.Size = New System.Drawing.Size(80, 65)
        Me.cmdrecibos.TabIndex = 27
        Me.cmdrecibos.Text = "Sueldos"
        Me.cmdrecibos.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdrecibos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdrecibos.UseVisualStyleBackColor = False
        '
        'cmdmantenimiento
        '
        Me.cmdmantenimiento.BackColor = System.Drawing.Color.Transparent
        Me.cmdmantenimiento.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.cmdmantenimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdmantenimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdmantenimiento.ForeColor = System.Drawing.Color.Transparent
        Me.cmdmantenimiento.Image = CType(resources.GetObject("cmdmantenimiento.Image"), System.Drawing.Image)
        Me.cmdmantenimiento.Location = New System.Drawing.Point(3, 213)
        Me.cmdmantenimiento.Name = "cmdmantenimiento"
        Me.cmdmantenimiento.Size = New System.Drawing.Size(80, 65)
        Me.cmdmantenimiento.TabIndex = 26
        Me.cmdmantenimiento.Text = "Mantenim"
        Me.cmdmantenimiento.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdmantenimiento.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdmantenimiento.UseVisualStyleBackColor = False
        '
        'cmdempresas
        '
        Me.cmdempresas.BackColor = System.Drawing.Color.Transparent
        Me.cmdempresas.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.cmdempresas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdempresas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdempresas.ForeColor = System.Drawing.Color.Transparent
        Me.cmdempresas.Image = CType(resources.GetObject("cmdempresas.Image"), System.Drawing.Image)
        Me.cmdempresas.Location = New System.Drawing.Point(4, 0)
        Me.cmdempresas.Name = "cmdempresas"
        Me.cmdempresas.Size = New System.Drawing.Size(80, 65)
        Me.cmdempresas.TabIndex = 25
        Me.cmdempresas.Text = "Empresas"
        Me.cmdempresas.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdempresas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdempresas.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Transparent
        Me.Button2.Location = New System.Drawing.Point(-170, 58)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(80, 65)
        Me.Button2.TabIndex = 24
        Me.Button2.Text = "Sincronizar"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button2.UseVisualStyleBackColor = False
        Me.Button2.Visible = False
        '
        'frmprincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(1224, 720)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pntitulo)
        Me.Controls.Add(Me.StatusStrip1)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "frmprincipal"
        Me.Text = "Principal"
        Me.TransparencyKey = System.Drawing.Color.White
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.pntitulo.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblstatusServer As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tmrcomprobarConexion As System.Windows.Forms.Timer
    Friend WithEvents lblstatusBDprinc As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblStatusEmp As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripDropDownButton1 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents CerrarConexionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReconectarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pntitulo As System.Windows.Forms.Panel
    Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ToolStripSplitButton1 As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents lblstatusgral As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents cmdempresas As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdmantenimiento As System.Windows.Forms.Button
    Friend WithEvents cmdrecibos As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button


End Class
