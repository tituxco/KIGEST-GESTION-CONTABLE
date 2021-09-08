<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImprimirLibroSueldo
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
        Me.cmbperiodo = New System.Windows.Forms.ComboBox()
        Me.cmdverlibros = New System.Windows.Forms.Button()
        Me.rptlibro = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.SuspendLayout()
        '
        'cmbperiodo
        '
        Me.cmbperiodo.Dock = System.Windows.Forms.DockStyle.Top
        Me.cmbperiodo.FormattingEnabled = True
        Me.cmbperiodo.Location = New System.Drawing.Point(0, 0)
        Me.cmbperiodo.Name = "cmbperiodo"
        Me.cmbperiodo.Size = New System.Drawing.Size(840, 21)
        Me.cmbperiodo.TabIndex = 0
        '
        'cmdverlibros
        '
        Me.cmdverlibros.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.cmdverlibros.Location = New System.Drawing.Point(0, 411)
        Me.cmdverlibros.Name = "cmdverlibros"
        Me.cmdverlibros.Size = New System.Drawing.Size(840, 23)
        Me.cmdverlibros.TabIndex = 1
        Me.cmdverlibros.Text = "Ver libro"
        Me.cmdverlibros.UseVisualStyleBackColor = True
        '
        'rptlibro
        '
        Me.rptlibro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rptlibro.DocumentMapWidth = 19
        Me.rptlibro.LocalReport.ReportEmbeddedResource = "KIGEST___Gestión_Contable.LibroSuelEncabeza.rdlc"
        Me.rptlibro.Location = New System.Drawing.Point(0, 21)
        Me.rptlibro.Name = "rptlibro"
        Me.rptlibro.Size = New System.Drawing.Size(840, 390)
        Me.rptlibro.TabIndex = 2
        '
        'ImprimirLibroSueldo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(840, 434)
        Me.Controls.Add(Me.rptlibro)
        Me.Controls.Add(Me.cmdverlibros)
        Me.Controls.Add(Me.cmbperiodo)
        Me.Name = "ImprimirLibroSueldo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ImprimirLibroSueldo"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmbperiodo As System.Windows.Forms.ComboBox
    Friend WithEvents cmdverlibros As System.Windows.Forms.Button
    Friend WithEvents rptlibro As Microsoft.Reporting.WinForms.ReportViewer

End Class
