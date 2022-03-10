<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImprimirRecibos
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
        Me.ReciboEncabezaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DatasetRecibos = New KIGEST___Gestion_Contable.DatasetRecibos()
        Me.cmdverrecibos = New System.Windows.Forms.Button()
        Me.cmbperiodo = New System.Windows.Forms.ComboBox()
        Me.rptrecibo = New Microsoft.Reporting.WinForms.ReportViewer()
        CType(Me.ReciboEncabezaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DatasetRecibos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReciboEncabezaBindingSource
        '
        Me.ReciboEncabezaBindingSource.DataMember = "ReciboEncabeza"
        Me.ReciboEncabezaBindingSource.DataSource = Me.DatasetRecibos
        '
        'DatasetRecibos
        '
        Me.DatasetRecibos.DataSetName = "DatasetRecibos"
        Me.DatasetRecibos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cmdverrecibos
        '
        Me.cmdverrecibos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.cmdverrecibos.Location = New System.Drawing.Point(0, 389)
        Me.cmdverrecibos.Name = "cmdverrecibos"
        Me.cmdverrecibos.Size = New System.Drawing.Size(705, 27)
        Me.cmdverrecibos.TabIndex = 1
        Me.cmdverrecibos.Text = "Ver recibos"
        Me.cmdverrecibos.UseVisualStyleBackColor = True
        '
        'cmbperiodo
        '
        Me.cmbperiodo.Dock = System.Windows.Forms.DockStyle.Top
        Me.cmbperiodo.FormattingEnabled = True
        Me.cmbperiodo.Location = New System.Drawing.Point(0, 0)
        Me.cmbperiodo.Name = "cmbperiodo"
        Me.cmbperiodo.Size = New System.Drawing.Size(705, 21)
        Me.cmbperiodo.TabIndex = 2
        '
        'rptrecibo
        '
        Me.rptrecibo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rptrecibo.LocalReport.ReportEmbeddedResource = "KIGEST___Gestion_Contable.ReciboEncabezado.rdlc"
        Me.rptrecibo.Location = New System.Drawing.Point(0, 21)
        Me.rptrecibo.Name = "rptrecibo"
        Me.rptrecibo.ServerReport.BearerToken = Nothing
        Me.rptrecibo.Size = New System.Drawing.Size(705, 368)
        Me.rptrecibo.TabIndex = 3
        '
        'ImprimirRecibos
        '
        Me.ClientSize = New System.Drawing.Size(705, 416)
        Me.Controls.Add(Me.rptrecibo)
        Me.Controls.Add(Me.cmbperiodo)
        Me.Controls.Add(Me.cmdverrecibos)
        Me.Name = "ImprimirRecibos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.ReciboEncabezaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DatasetRecibos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer

    Friend WithEvents cmdcancel As System.Windows.Forms.Button
    Friend WithEvents cmdreport As System.Windows.Forms.Button
    Friend WithEvents DataTable1BindingSource As System.Windows.Forms.BindingSource
    'Friend WithEvents datasetEmpresas As KIGEST___Gestión_Contable.datasetEmpresas
    Friend WithEvents DatasetEmpresasBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataTable1BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents cmdverrecibos As System.Windows.Forms.Button
    Friend WithEvents DatasetRecibos As KIGEST___Gestion_Contable.DatasetRecibos
    Friend WithEvents ReciboEncabezaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents cmbperiodo As System.Windows.Forms.ComboBox
    Friend WithEvents rptrecibo As Microsoft.Reporting.WinForms.ReportViewer
End Class
