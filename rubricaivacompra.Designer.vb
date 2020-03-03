<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rubricaivacompra
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
        Me.rpthojas = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txthojas = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'rpthojas
        '
        Me.rpthojas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rpthojas.DocumentMapWidth = 19
        Me.rpthojas.LocalReport.ReportEmbeddedResource = "KIGEST___Gestión_Contable.LibroSuelEncabeza.rdlc"
        Me.rpthojas.Location = New System.Drawing.Point(0, 0)
        Me.rpthojas.Name = "rpthojas"
        Me.rpthojas.Size = New System.Drawing.Size(834, 384)
        Me.rpthojas.TabIndex = 8
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txthojas)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 384)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(834, 27)
        Me.Panel1.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(426, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(233, 27)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Cantidad de hojas a rubricar:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txthojas
        '
        Me.txthojas.Dock = System.Windows.Forms.DockStyle.Right
        Me.txthojas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txthojas.Location = New System.Drawing.Point(659, 0)
        Me.txthojas.Name = "txthojas"
        Me.txthojas.Size = New System.Drawing.Size(100, 26)
        Me.txthojas.TabIndex = 7
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button1.Location = New System.Drawing.Point(759, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 27)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Aceptar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'rubricaivacompra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(834, 411)
        Me.Controls.Add(Me.rpthojas)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "rubricaivacompra"
        Me.Text = "rubricaivacompra"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rpthojas As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txthojas As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
