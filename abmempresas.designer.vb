<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmabmempresa
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmabmempresa))
        Me.pntitulo = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnnavegacion = New System.Windows.Forms.Panel()
        Me.cmdmodificar = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmdempresas = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtbuscaemp = New System.Windows.Forms.TextBox()
        Me.dtempresas = New System.Windows.Forms.DataGridView()
        Me.txtsentencias = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.pntitulo.SuspendLayout()
        Me.pnnavegacion.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dtempresas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pntitulo
        '
        Me.pntitulo.AutoScroll = True
        Me.pntitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pntitulo.Controls.Add(Me.Label1)
        Me.pntitulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pntitulo.Location = New System.Drawing.Point(0, 0)
        Me.pntitulo.Name = "pntitulo"
        Me.pntitulo.Size = New System.Drawing.Size(1001, 40)
        Me.pntitulo.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Sansation", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(205, 39)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "EMPRESAS"
        '
        'pnnavegacion
        '
        Me.pnnavegacion.AutoScroll = True
        Me.pnnavegacion.BackColor = System.Drawing.Color.Gray
        Me.pnnavegacion.Controls.Add(Me.cmdmodificar)
        Me.pnnavegacion.Controls.Add(Me.Button3)
        Me.pnnavegacion.Controls.Add(Me.Button2)
        Me.pnnavegacion.Controls.Add(Me.Button1)
        Me.pnnavegacion.Controls.Add(Me.cmdempresas)
        Me.pnnavegacion.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnnavegacion.Location = New System.Drawing.Point(0, 40)
        Me.pnnavegacion.Name = "pnnavegacion"
        Me.pnnavegacion.Size = New System.Drawing.Size(1001, 73)
        Me.pnnavegacion.TabIndex = 4
        '
        'cmdmodificar
        '
        Me.cmdmodificar.Dock = System.Windows.Forms.DockStyle.Left
        Me.cmdmodificar.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.cmdmodificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdmodificar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdmodificar.ForeColor = System.Drawing.Color.White
        Me.cmdmodificar.Image = CType(resources.GetObject("cmdmodificar.Image"), System.Drawing.Image)
        Me.cmdmodificar.Location = New System.Drawing.Point(140, 0)
        Me.cmdmodificar.Name = "cmdmodificar"
        Me.cmdmodificar.Size = New System.Drawing.Size(70, 73)
        Me.cmdmodificar.TabIndex = 6
        Me.cmdmodificar.Text = "Modificar"
        Me.cmdmodificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdmodificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdmodificar.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button3.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(861, 0)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(70, 73)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "Activar"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(70, 0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(70, 73)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Eliminar"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(931, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(70, 73)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Salir"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmdempresas
        '
        Me.cmdempresas.Dock = System.Windows.Forms.DockStyle.Left
        Me.cmdempresas.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.cmdempresas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdempresas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdempresas.ForeColor = System.Drawing.Color.White
        Me.cmdempresas.Image = CType(resources.GetObject("cmdempresas.Image"), System.Drawing.Image)
        Me.cmdempresas.Location = New System.Drawing.Point(0, 0)
        Me.cmdempresas.Name = "cmdempresas"
        Me.cmdempresas.Size = New System.Drawing.Size(70, 73)
        Me.cmdempresas.TabIndex = 2
        Me.cmdempresas.Text = "Agregar"
        Me.cmdempresas.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdempresas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdempresas.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.txtbuscaemp)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 113)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1001, 25)
        Me.Panel1.TabIndex = 6
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(3, 3)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(50, 13)
        Me.Label17.TabIndex = 61
        Me.Label17.Text = "Buscar:"
        '
        'txtbuscaemp
        '
        Me.txtbuscaemp.Location = New System.Drawing.Point(59, 0)
        Me.txtbuscaemp.Name = "txtbuscaemp"
        Me.txtbuscaemp.Size = New System.Drawing.Size(624, 20)
        Me.txtbuscaemp.TabIndex = 60
        '
        'dtempresas
        '
        Me.dtempresas.AllowUserToAddRows = False
        Me.dtempresas.AllowUserToOrderColumns = True
        Me.dtempresas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dtempresas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dtempresas.BackgroundColor = System.Drawing.Color.White
        Me.dtempresas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtempresas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dtempresas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtempresas.Location = New System.Drawing.Point(0, 138)
        Me.dtempresas.Name = "dtempresas"
        Me.dtempresas.Size = New System.Drawing.Size(1001, 451)
        Me.dtempresas.TabIndex = 7
        '
        'txtsentencias
        '
        Me.txtsentencias.Location = New System.Drawing.Point(6, 19)
        Me.txtsentencias.Multiline = True
        Me.txtsentencias.Name = "txtsentencias"
        Me.txtsentencias.Size = New System.Drawing.Size(394, 292)
        Me.txtsentencias.TabIndex = 8
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button4)
        Me.GroupBox1.Controls.Add(Me.txtsentencias)
        Me.GroupBox1.Location = New System.Drawing.Point(59, 192)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(556, 323)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        Me.GroupBox1.Visible = False
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(406, 288)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 9
        Me.Button4.Text = "Button4"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'frmabmempresa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1001, 589)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dtempresas)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnnavegacion)
        Me.Controls.Add(Me.pntitulo)
        Me.KeyPreview = True
        Me.Name = "frmabmempresa"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Listado de empresas"
        Me.TopMost = True
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pntitulo.ResumeLayout(False)
        Me.pntitulo.PerformLayout()
        Me.pnnavegacion.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dtempresas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pntitulo As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnnavegacion As System.Windows.Forms.Panel
    Friend WithEvents cmdempresas As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmdmodificar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtbuscaemp As System.Windows.Forms.TextBox
    Friend WithEvents dtempresas As System.Windows.Forms.DataGridView
    Friend WithEvents txtsentencias As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
End Class
