<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NuevoConceptoSueldo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NuevoConceptoSueldo))
        Me.lbltitulo = New System.Windows.Forms.Label()
        Me.chkbasico = New System.Windows.Forms.CheckBox()
        Me.txtformula = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtcantidad = New System.Windows.Forms.TextBox()
        Me.cmdaddconcepto = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbunidad = New System.Windows.Forms.ComboBox()
        Me.txtcodigo = New System.Windows.Forms.TextBox()
        Me.txtconcepto = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtmonto = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkContribucionLeyRiesgoTrabajo = New System.Windows.Forms.CheckBox()
        Me.chkContribucionesRegEspeciales = New System.Windows.Forms.CheckBox()
        Me.chkContribucionesDiferenciales = New System.Windows.Forms.CheckBox()
        Me.chkContribucionesFNE = New System.Windows.Forms.CheckBox()
        Me.chkContribucionesAAFF = New System.Windows.Forms.CheckBox()
        Me.chkContribucionesRENATEA = New System.Windows.Forms.CheckBox()
        Me.chkContribucionesFSR = New System.Windows.Forms.CheckBox()
        Me.chkContribucionesOSocial = New System.Windows.Forms.CheckBox()
        Me.chkContribucionesINSSJyP = New System.Windows.Forms.CheckBox()
        Me.chkContribucionesSIPA = New System.Windows.Forms.CheckBox()
        Me.chkAporteRegEspeciales = New System.Windows.Forms.CheckBox()
        Me.chkAporteDiferenciales = New System.Windows.Forms.CheckBox()
        Me.chkAporteFNE = New System.Windows.Forms.CheckBox()
        Me.chkAporteAAFF = New System.Windows.Forms.CheckBox()
        Me.chkAporteRENATEA = New System.Windows.Forms.CheckBox()
        Me.chkAporteFSR = New System.Windows.Forms.CheckBox()
        Me.chkAporteOSocial = New System.Windows.Forms.CheckBox()
        Me.chkAporteINSSJyP = New System.Windows.Forms.CheckBox()
        Me.chkAporteSIPA = New System.Windows.Forms.CheckBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkMaternidadAnses = New System.Windows.Forms.CheckBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.chkContribucionDifSegSocial = New System.Windows.Forms.CheckBox()
        Me.chkContribDifOSyFSR = New System.Windows.Forms.CheckBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.chkBaseImponible10 = New System.Windows.Forms.CheckBox()
        Me.chkBaseImponible09 = New System.Windows.Forms.CheckBox()
        Me.chkBaseImponible08 = New System.Windows.Forms.CheckBox()
        Me.chkBaseImponible07 = New System.Windows.Forms.CheckBox()
        Me.chkBaseImponible06 = New System.Windows.Forms.CheckBox()
        Me.chkBaseImponible05 = New System.Windows.Forms.CheckBox()
        Me.chkBaseImponible04 = New System.Windows.Forms.CheckBox()
        Me.chkBaseImponible03 = New System.Windows.Forms.CheckBox()
        Me.chkBaseImponible02 = New System.Windows.Forms.CheckBox()
        Me.chkBaseCalculoART = New System.Windows.Forms.CheckBox()
        Me.chkAporteDifSegSocial = New System.Windows.Forms.CheckBox()
        Me.chkAporteDifOSyFSR = New System.Windows.Forms.CheckBox()
        Me.chkBaseImponible01 = New System.Windows.Forms.CheckBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.cmbCodigoAfip = New System.Windows.Forms.ComboBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmbtipo = New System.Windows.Forms.ComboBox()
        Me.chkMarcaRepeticion = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbltitulo
        '
        Me.lbltitulo.AutoSize = True
        Me.lbltitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltitulo.ForeColor = System.Drawing.Color.Red
        Me.lbltitulo.Location = New System.Drawing.Point(7, 9)
        Me.lbltitulo.Name = "lbltitulo"
        Me.lbltitulo.Size = New System.Drawing.Size(113, 13)
        Me.lbltitulo.TabIndex = 78
        Me.lbltitulo.Text = "Agregar Concepto:"
        '
        'chkbasico
        '
        Me.chkbasico.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkbasico.Location = New System.Drawing.Point(117, 42)
        Me.chkbasico.Name = "chkbasico"
        Me.chkbasico.Size = New System.Drawing.Size(128, 33)
        Me.chkbasico.TabIndex = 77
        Me.chkbasico.Text = "Sumar al basico"
        Me.chkbasico.UseVisualStyleBackColor = True
        '
        'txtformula
        '
        Me.txtformula.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtformula.Location = New System.Drawing.Point(471, 59)
        Me.txtformula.Multiline = True
        Me.txtformula.Name = "txtformula"
        Me.txtformula.Size = New System.Drawing.Size(202, 61)
        Me.txtformula.TabIndex = 67
        Me.txtformula.Tag = ""
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(468, 43)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 13)
        Me.Label7.TabIndex = 74
        Me.Label7.Text = "Formula"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(7, 43)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 13)
        Me.Label6.TabIndex = 73
        Me.Label6.Text = "Tipo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(359, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 72
        Me.Label3.Text = "Cantidad"
        '
        'txtcantidad
        '
        Me.txtcantidad.Location = New System.Drawing.Point(362, 99)
        Me.txtcantidad.Name = "txtcantidad"
        Me.txtcantidad.Size = New System.Drawing.Size(49, 20)
        Me.txtcantidad.TabIndex = 64
        Me.txtcantidad.Tag = ""
        '
        'cmdaddconcepto
        '
        Me.cmdaddconcepto.Location = New System.Drawing.Point(594, 423)
        Me.cmdaddconcepto.Name = "cmdaddconcepto"
        Me.cmdaddconcepto.Size = New System.Drawing.Size(75, 23)
        Me.cmdaddconcepto.TabIndex = 68
        Me.cmdaddconcepto.Text = "ACEPTAR"
        Me.cmdaddconcepto.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(244, 83)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 13)
        Me.Label5.TabIndex = 71
        Me.Label5.Text = "Unidad"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(7, 83)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 13)
        Me.Label4.TabIndex = 70
        Me.Label4.Text = "Concepto:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(159, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 69
        Me.Label2.Text = "Codigo Int"
        '
        'cmbunidad
        '
        Me.cmbunidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbunidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbunidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbunidad.FormattingEnabled = True
        Me.cmbunidad.Location = New System.Drawing.Point(247, 99)
        Me.cmbunidad.Name = "cmbunidad"
        Me.cmbunidad.Size = New System.Drawing.Size(109, 21)
        Me.cmbunidad.TabIndex = 65
        '
        'txtcodigo
        '
        Me.txtcodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtcodigo.Location = New System.Drawing.Point(158, 59)
        Me.txtcodigo.Name = "txtcodigo"
        Me.txtcodigo.Size = New System.Drawing.Size(86, 20)
        Me.txtcodigo.TabIndex = 62
        Me.txtcodigo.Tag = ""
        '
        'txtconcepto
        '
        Me.txtconcepto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtconcepto.Location = New System.Drawing.Point(6, 100)
        Me.txtconcepto.Name = "txtconcepto"
        Me.txtconcepto.Size = New System.Drawing.Size(235, 20)
        Me.txtconcepto.TabIndex = 66
        Me.txtconcepto.Tag = ""
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(417, 83)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 13)
        Me.Label10.TabIndex = 76
        Me.Label10.Text = "Monto"
        Me.Label10.Visible = False
        '
        'txtmonto
        '
        Me.txtmonto.Location = New System.Drawing.Point(420, 99)
        Me.txtmonto.Name = "txtmonto"
        Me.txtmonto.Size = New System.Drawing.Size(49, 20)
        Me.txtmonto.TabIndex = 75
        Me.txtmonto.Tag = ""
        Me.txtmonto.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkContribucionLeyRiesgoTrabajo)
        Me.GroupBox1.Controls.Add(Me.chkContribucionesRegEspeciales)
        Me.GroupBox1.Controls.Add(Me.chkContribucionesDiferenciales)
        Me.GroupBox1.Controls.Add(Me.chkContribucionesFNE)
        Me.GroupBox1.Controls.Add(Me.chkContribucionesAAFF)
        Me.GroupBox1.Controls.Add(Me.chkContribucionesRENATEA)
        Me.GroupBox1.Controls.Add(Me.chkContribucionesFSR)
        Me.GroupBox1.Controls.Add(Me.chkContribucionesOSocial)
        Me.GroupBox1.Controls.Add(Me.chkContribucionesINSSJyP)
        Me.GroupBox1.Controls.Add(Me.chkContribucionesSIPA)
        Me.GroupBox1.Controls.Add(Me.chkAporteRegEspeciales)
        Me.GroupBox1.Controls.Add(Me.chkAporteDiferenciales)
        Me.GroupBox1.Controls.Add(Me.chkAporteRENATEA)
        Me.GroupBox1.Controls.Add(Me.chkAporteFSR)
        Me.GroupBox1.Controls.Add(Me.chkAporteOSocial)
        Me.GroupBox1.Controls.Add(Me.chkAporteINSSJyP)
        Me.GroupBox1.Controls.Add(Me.chkAporteSIPA)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Location = New System.Drawing.Point(6, 126)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(667, 134)
        Me.GroupBox1.TabIndex = 79
        Me.GroupBox1.TabStop = False
        '
        'chkContribucionLeyRiesgoTrabajo
        '
        Me.chkContribucionLeyRiesgoTrabajo.AutoSize = True
        Me.chkContribucionLeyRiesgoTrabajo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkContribucionLeyRiesgoTrabajo.Location = New System.Drawing.Point(124, 95)
        Me.chkContribucionLeyRiesgoTrabajo.Name = "chkContribucionLeyRiesgoTrabajo"
        Me.chkContribucionLeyRiesgoTrabajo.Size = New System.Drawing.Size(271, 17)
        Me.chkContribucionLeyRiesgoTrabajo.TabIndex = 103
        Me.chkContribucionLeyRiesgoTrabajo.Text = "Contribucion Ley de Riesgo de trabajo LRT"
        Me.chkContribucionLeyRiesgoTrabajo.UseVisualStyleBackColor = True
        '
        'chkContribucionesRegEspeciales
        '
        Me.chkContribucionesRegEspeciales.AutoSize = True
        Me.chkContribucionesRegEspeciales.Location = New System.Drawing.Point(592, 71)
        Me.chkContribucionesRegEspeciales.Name = "chkContribucionesRegEspeciales"
        Me.chkContribucionesRegEspeciales.Size = New System.Drawing.Size(15, 14)
        Me.chkContribucionesRegEspeciales.TabIndex = 102
        Me.chkContribucionesRegEspeciales.UseVisualStyleBackColor = True
        '
        'chkContribucionesDiferenciales
        '
        Me.chkContribucionesDiferenciales.AutoSize = True
        Me.chkContribucionesDiferenciales.Location = New System.Drawing.Point(503, 71)
        Me.chkContribucionesDiferenciales.Name = "chkContribucionesDiferenciales"
        Me.chkContribucionesDiferenciales.Size = New System.Drawing.Size(15, 14)
        Me.chkContribucionesDiferenciales.TabIndex = 101
        Me.chkContribucionesDiferenciales.UseVisualStyleBackColor = True
        '
        'chkContribucionesFNE
        '
        Me.chkContribucionesFNE.AutoSize = True
        Me.chkContribucionesFNE.Location = New System.Drawing.Point(448, 71)
        Me.chkContribucionesFNE.Name = "chkContribucionesFNE"
        Me.chkContribucionesFNE.Size = New System.Drawing.Size(15, 14)
        Me.chkContribucionesFNE.TabIndex = 100
        Me.chkContribucionesFNE.UseVisualStyleBackColor = True
        '
        'chkContribucionesAAFF
        '
        Me.chkContribucionesAAFF.AutoSize = True
        Me.chkContribucionesAAFF.Location = New System.Drawing.Point(407, 71)
        Me.chkContribucionesAAFF.Name = "chkContribucionesAAFF"
        Me.chkContribucionesAAFF.Size = New System.Drawing.Size(15, 14)
        Me.chkContribucionesAAFF.TabIndex = 99
        Me.chkContribucionesAAFF.UseVisualStyleBackColor = True
        '
        'chkContribucionesRENATEA
        '
        Me.chkContribucionesRENATEA.AutoSize = True
        Me.chkContribucionesRENATEA.Location = New System.Drawing.Point(356, 71)
        Me.chkContribucionesRENATEA.Name = "chkContribucionesRENATEA"
        Me.chkContribucionesRENATEA.Size = New System.Drawing.Size(15, 14)
        Me.chkContribucionesRENATEA.TabIndex = 98
        Me.chkContribucionesRENATEA.UseVisualStyleBackColor = True
        '
        'chkContribucionesFSR
        '
        Me.chkContribucionesFSR.AutoSize = True
        Me.chkContribucionesFSR.Location = New System.Drawing.Point(298, 71)
        Me.chkContribucionesFSR.Name = "chkContribucionesFSR"
        Me.chkContribucionesFSR.Size = New System.Drawing.Size(15, 14)
        Me.chkContribucionesFSR.TabIndex = 97
        Me.chkContribucionesFSR.UseVisualStyleBackColor = True
        '
        'chkContribucionesOSocial
        '
        Me.chkContribucionesOSocial.AutoSize = True
        Me.chkContribucionesOSocial.Location = New System.Drawing.Point(241, 71)
        Me.chkContribucionesOSocial.Name = "chkContribucionesOSocial"
        Me.chkContribucionesOSocial.Size = New System.Drawing.Size(15, 14)
        Me.chkContribucionesOSocial.TabIndex = 96
        Me.chkContribucionesOSocial.UseVisualStyleBackColor = True
        '
        'chkContribucionesINSSJyP
        '
        Me.chkContribucionesINSSJyP.AutoSize = True
        Me.chkContribucionesINSSJyP.Location = New System.Drawing.Point(171, 71)
        Me.chkContribucionesINSSJyP.Name = "chkContribucionesINSSJyP"
        Me.chkContribucionesINSSJyP.Size = New System.Drawing.Size(15, 14)
        Me.chkContribucionesINSSJyP.TabIndex = 95
        Me.chkContribucionesINSSJyP.UseVisualStyleBackColor = True
        '
        'chkContribucionesSIPA
        '
        Me.chkContribucionesSIPA.AutoSize = True
        Me.chkContribucionesSIPA.Location = New System.Drawing.Point(124, 71)
        Me.chkContribucionesSIPA.Name = "chkContribucionesSIPA"
        Me.chkContribucionesSIPA.Size = New System.Drawing.Size(15, 14)
        Me.chkContribucionesSIPA.TabIndex = 94
        Me.chkContribucionesSIPA.UseVisualStyleBackColor = True
        '
        'chkAporteRegEspeciales
        '
        Me.chkAporteRegEspeciales.AutoSize = True
        Me.chkAporteRegEspeciales.Location = New System.Drawing.Point(592, 46)
        Me.chkAporteRegEspeciales.Name = "chkAporteRegEspeciales"
        Me.chkAporteRegEspeciales.Size = New System.Drawing.Size(15, 14)
        Me.chkAporteRegEspeciales.TabIndex = 93
        Me.chkAporteRegEspeciales.UseVisualStyleBackColor = True
        '
        'chkAporteDiferenciales
        '
        Me.chkAporteDiferenciales.AutoSize = True
        Me.chkAporteDiferenciales.Location = New System.Drawing.Point(503, 46)
        Me.chkAporteDiferenciales.Name = "chkAporteDiferenciales"
        Me.chkAporteDiferenciales.Size = New System.Drawing.Size(15, 14)
        Me.chkAporteDiferenciales.TabIndex = 92
        Me.chkAporteDiferenciales.UseVisualStyleBackColor = True
        '
        'chkAporteFNE
        '
        Me.chkAporteFNE.AutoSize = True
        Me.chkAporteFNE.Location = New System.Drawing.Point(267, 454)
        Me.chkAporteFNE.Name = "chkAporteFNE"
        Me.chkAporteFNE.Size = New System.Drawing.Size(15, 14)
        Me.chkAporteFNE.TabIndex = 91
        Me.chkAporteFNE.UseVisualStyleBackColor = True
        Me.chkAporteFNE.Visible = False
        '
        'chkAporteAAFF
        '
        Me.chkAporteAAFF.AutoSize = True
        Me.chkAporteAAFF.Location = New System.Drawing.Point(226, 454)
        Me.chkAporteAAFF.Name = "chkAporteAAFF"
        Me.chkAporteAAFF.Size = New System.Drawing.Size(15, 14)
        Me.chkAporteAAFF.TabIndex = 90
        Me.chkAporteAAFF.UseVisualStyleBackColor = True
        Me.chkAporteAAFF.Visible = False
        '
        'chkAporteRENATEA
        '
        Me.chkAporteRENATEA.AutoSize = True
        Me.chkAporteRENATEA.Location = New System.Drawing.Point(356, 46)
        Me.chkAporteRENATEA.Name = "chkAporteRENATEA"
        Me.chkAporteRENATEA.Size = New System.Drawing.Size(15, 14)
        Me.chkAporteRENATEA.TabIndex = 89
        Me.chkAporteRENATEA.UseVisualStyleBackColor = True
        '
        'chkAporteFSR
        '
        Me.chkAporteFSR.AutoSize = True
        Me.chkAporteFSR.Location = New System.Drawing.Point(298, 46)
        Me.chkAporteFSR.Name = "chkAporteFSR"
        Me.chkAporteFSR.Size = New System.Drawing.Size(15, 14)
        Me.chkAporteFSR.TabIndex = 88
        Me.chkAporteFSR.UseVisualStyleBackColor = True
        '
        'chkAporteOSocial
        '
        Me.chkAporteOSocial.AutoSize = True
        Me.chkAporteOSocial.Location = New System.Drawing.Point(241, 46)
        Me.chkAporteOSocial.Name = "chkAporteOSocial"
        Me.chkAporteOSocial.Size = New System.Drawing.Size(15, 14)
        Me.chkAporteOSocial.TabIndex = 87
        Me.chkAporteOSocial.UseVisualStyleBackColor = True
        '
        'chkAporteINSSJyP
        '
        Me.chkAporteINSSJyP.AutoSize = True
        Me.chkAporteINSSJyP.Location = New System.Drawing.Point(171, 46)
        Me.chkAporteINSSJyP.Name = "chkAporteINSSJyP"
        Me.chkAporteINSSJyP.Size = New System.Drawing.Size(15, 14)
        Me.chkAporteINSSJyP.TabIndex = 86
        Me.chkAporteINSSJyP.UseVisualStyleBackColor = True
        '
        'chkAporteSIPA
        '
        Me.chkAporteSIPA.AutoSize = True
        Me.chkAporteSIPA.Location = New System.Drawing.Point(124, 46)
        Me.chkAporteSIPA.Name = "chkAporteSIPA"
        Me.chkAporteSIPA.Size = New System.Drawing.Size(15, 14)
        Me.chkAporteSIPA.TabIndex = 85
        Me.chkAporteSIPA.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(6, 72)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(91, 13)
        Me.Label19.TabIndex = 84
        Me.Label19.Text = "Contribuciones"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(6, 46)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(50, 13)
        Me.Label18.TabIndex = 83
        Me.Label18.Text = "Aportes"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(564, 16)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(99, 13)
        Me.Label17.TabIndex = 82
        Me.Label17.Text = "Reg. Especiales"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(477, 16)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(81, 13)
        Me.Label16.TabIndex = 81
        Me.Label16.Text = "Diferenciales"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(440, 16)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(31, 13)
        Me.Label15.TabIndex = 80
        Me.Label15.Text = "FNE"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(397, 16)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(37, 13)
        Me.Label14.TabIndex = 79
        Me.Label14.Text = "AAFF"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(326, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(65, 13)
        Me.Label12.TabIndex = 78
        Me.Label12.Text = "RENATEA"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(289, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(31, 13)
        Me.Label11.TabIndex = 77
        Me.Label11.Text = "FSR"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(215, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 13)
        Me.Label9.TabIndex = 76
        Me.Label9.Text = "O. SOCIAL"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(153, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 13)
        Me.Label8.TabIndex = 75
        Me.Label8.Text = "INSSJyP"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(114, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 74
        Me.Label1.Text = "SIPA"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkMaternidadAnses)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.chkContribucionDifSegSocial)
        Me.GroupBox2.Controls.Add(Me.chkContribDifOSyFSR)
        Me.GroupBox2.Controls.Add(Me.chkbasico)
        Me.GroupBox2.Controls.Add(Me.Label22)
        Me.GroupBox2.Controls.Add(Me.chkBaseImponible10)
        Me.GroupBox2.Controls.Add(Me.chkBaseImponible09)
        Me.GroupBox2.Controls.Add(Me.chkBaseImponible08)
        Me.GroupBox2.Controls.Add(Me.chkBaseImponible07)
        Me.GroupBox2.Controls.Add(Me.chkBaseImponible06)
        Me.GroupBox2.Controls.Add(Me.chkBaseImponible05)
        Me.GroupBox2.Controls.Add(Me.chkBaseImponible04)
        Me.GroupBox2.Controls.Add(Me.chkBaseImponible03)
        Me.GroupBox2.Controls.Add(Me.chkBaseImponible02)
        Me.GroupBox2.Controls.Add(Me.chkBaseCalculoART)
        Me.GroupBox2.Controls.Add(Me.chkAporteDifSegSocial)
        Me.GroupBox2.Controls.Add(Me.chkAporteDifOSyFSR)
        Me.GroupBox2.Controls.Add(Me.chkBaseImponible01)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox2.Location = New System.Drawing.Point(6, 266)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(667, 138)
        Me.GroupBox2.TabIndex = 104
        Me.GroupBox2.TabStop = False
        '
        'chkMaternidadAnses
        '
        Me.chkMaternidadAnses.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMaternidadAnses.Location = New System.Drawing.Point(243, 42)
        Me.chkMaternidadAnses.Name = "chkMaternidadAnses"
        Me.chkMaternidadAnses.Size = New System.Drawing.Size(141, 33)
        Me.chkMaternidadAnses.TabIndex = 117
        Me.chkMaternidadAnses.Text = "Maternidad ANSes"
        Me.chkMaternidadAnses.UseVisualStyleBackColor = True
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(7, 48)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(88, 13)
        Me.Label23.TabIndex = 116
        Me.Label23.Text = "Remuneración"
        '
        'chkContribucionDifSegSocial
        '
        Me.chkContribucionDifSegSocial.AutoSize = True
        Me.chkContribucionDifSegSocial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkContribucionDifSegSocial.Location = New System.Drawing.Point(390, 81)
        Me.chkContribucionDifSegSocial.Name = "chkContribucionDifSegSocial"
        Me.chkContribucionDifSegSocial.Size = New System.Drawing.Size(97, 17)
        Me.chkContribucionDifSegSocial.TabIndex = 115
        Me.chkContribucionDifSegSocial.Text = "Contribucion"
        Me.chkContribucionDifSegSocial.UseVisualStyleBackColor = True
        '
        'chkContribDifOSyFSR
        '
        Me.chkContribDifOSyFSR.AutoSize = True
        Me.chkContribDifOSyFSR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkContribDifOSyFSR.Location = New System.Drawing.Point(390, 112)
        Me.chkContribDifOSyFSR.Name = "chkContribDifOSyFSR"
        Me.chkContribDifOSyFSR.Size = New System.Drawing.Size(97, 17)
        Me.chkContribDifOSyFSR.TabIndex = 114
        Me.chkContribDifOSyFSR.Text = "Contribucion"
        Me.chkContribDifOSyFSR.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(7, 113)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(220, 13)
        Me.Label22.TabIndex = 113
        Me.Label22.Text = "Base de calculo diferencial OS y FSR"
        '
        'chkBaseImponible10
        '
        Me.chkBaseImponible10.AutoSize = True
        Me.chkBaseImponible10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkBaseImponible10.Location = New System.Drawing.Point(468, 16)
        Me.chkBaseImponible10.Name = "chkBaseImponible10"
        Me.chkBaseImponible10.Size = New System.Drawing.Size(40, 17)
        Me.chkBaseImponible10.TabIndex = 112
        Me.chkBaseImponible10.Text = "10"
        Me.chkBaseImponible10.UseVisualStyleBackColor = True
        '
        'chkBaseImponible09
        '
        Me.chkBaseImponible09.AutoSize = True
        Me.chkBaseImponible09.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkBaseImponible09.Location = New System.Drawing.Point(429, 16)
        Me.chkBaseImponible09.Name = "chkBaseImponible09"
        Me.chkBaseImponible09.Size = New System.Drawing.Size(33, 17)
        Me.chkBaseImponible09.TabIndex = 111
        Me.chkBaseImponible09.Text = "9"
        Me.chkBaseImponible09.UseVisualStyleBackColor = True
        '
        'chkBaseImponible08
        '
        Me.chkBaseImponible08.AutoSize = True
        Me.chkBaseImponible08.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkBaseImponible08.Location = New System.Drawing.Point(390, 16)
        Me.chkBaseImponible08.Name = "chkBaseImponible08"
        Me.chkBaseImponible08.Size = New System.Drawing.Size(33, 17)
        Me.chkBaseImponible08.TabIndex = 110
        Me.chkBaseImponible08.Text = "8"
        Me.chkBaseImponible08.UseVisualStyleBackColor = True
        '
        'chkBaseImponible07
        '
        Me.chkBaseImponible07.AutoSize = True
        Me.chkBaseImponible07.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkBaseImponible07.Location = New System.Drawing.Point(351, 16)
        Me.chkBaseImponible07.Name = "chkBaseImponible07"
        Me.chkBaseImponible07.Size = New System.Drawing.Size(33, 17)
        Me.chkBaseImponible07.TabIndex = 109
        Me.chkBaseImponible07.Text = "7"
        Me.chkBaseImponible07.UseVisualStyleBackColor = True
        '
        'chkBaseImponible06
        '
        Me.chkBaseImponible06.AutoSize = True
        Me.chkBaseImponible06.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkBaseImponible06.Location = New System.Drawing.Point(312, 16)
        Me.chkBaseImponible06.Name = "chkBaseImponible06"
        Me.chkBaseImponible06.Size = New System.Drawing.Size(33, 17)
        Me.chkBaseImponible06.TabIndex = 108
        Me.chkBaseImponible06.Text = "6"
        Me.chkBaseImponible06.UseVisualStyleBackColor = True
        '
        'chkBaseImponible05
        '
        Me.chkBaseImponible05.AutoSize = True
        Me.chkBaseImponible05.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkBaseImponible05.Location = New System.Drawing.Point(273, 16)
        Me.chkBaseImponible05.Name = "chkBaseImponible05"
        Me.chkBaseImponible05.Size = New System.Drawing.Size(33, 17)
        Me.chkBaseImponible05.TabIndex = 107
        Me.chkBaseImponible05.Text = "5"
        Me.chkBaseImponible05.UseVisualStyleBackColor = True
        '
        'chkBaseImponible04
        '
        Me.chkBaseImponible04.AutoSize = True
        Me.chkBaseImponible04.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkBaseImponible04.Location = New System.Drawing.Point(234, 16)
        Me.chkBaseImponible04.Name = "chkBaseImponible04"
        Me.chkBaseImponible04.Size = New System.Drawing.Size(33, 17)
        Me.chkBaseImponible04.TabIndex = 106
        Me.chkBaseImponible04.Text = "4"
        Me.chkBaseImponible04.UseVisualStyleBackColor = True
        '
        'chkBaseImponible03
        '
        Me.chkBaseImponible03.AutoSize = True
        Me.chkBaseImponible03.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkBaseImponible03.Location = New System.Drawing.Point(195, 16)
        Me.chkBaseImponible03.Name = "chkBaseImponible03"
        Me.chkBaseImponible03.Size = New System.Drawing.Size(33, 17)
        Me.chkBaseImponible03.TabIndex = 105
        Me.chkBaseImponible03.Text = "3"
        Me.chkBaseImponible03.UseVisualStyleBackColor = True
        '
        'chkBaseImponible02
        '
        Me.chkBaseImponible02.AutoSize = True
        Me.chkBaseImponible02.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkBaseImponible02.Location = New System.Drawing.Point(156, 16)
        Me.chkBaseImponible02.Name = "chkBaseImponible02"
        Me.chkBaseImponible02.Size = New System.Drawing.Size(33, 17)
        Me.chkBaseImponible02.TabIndex = 104
        Me.chkBaseImponible02.Text = "2"
        Me.chkBaseImponible02.UseVisualStyleBackColor = True
        '
        'chkBaseCalculoART
        '
        Me.chkBaseCalculoART.AutoSize = True
        Me.chkBaseCalculoART.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkBaseCalculoART.Location = New System.Drawing.Point(390, 50)
        Me.chkBaseCalculoART.Name = "chkBaseCalculoART"
        Me.chkBaseCalculoART.Size = New System.Drawing.Size(245, 17)
        Me.chkBaseCalculoART.TabIndex = 103
        Me.chkBaseCalculoART.Text = "Base cálculo Ley de Riesgo de trabajo"
        Me.chkBaseCalculoART.UseVisualStyleBackColor = True
        '
        'chkAporteDifSegSocial
        '
        Me.chkAporteDifSegSocial.AutoSize = True
        Me.chkAporteDifSegSocial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAporteDifSegSocial.Location = New System.Drawing.Point(273, 81)
        Me.chkAporteDifSegSocial.Name = "chkAporteDifSegSocial"
        Me.chkAporteDifSegSocial.Size = New System.Drawing.Size(63, 17)
        Me.chkAporteDifSegSocial.TabIndex = 97
        Me.chkAporteDifSegSocial.Text = "Aporte"
        Me.chkAporteDifSegSocial.UseVisualStyleBackColor = True
        '
        'chkAporteDifOSyFSR
        '
        Me.chkAporteDifOSyFSR.AutoSize = True
        Me.chkAporteDifOSyFSR.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAporteDifOSyFSR.Location = New System.Drawing.Point(273, 112)
        Me.chkAporteDifOSyFSR.Name = "chkAporteDifOSyFSR"
        Me.chkAporteDifOSyFSR.Size = New System.Drawing.Size(63, 17)
        Me.chkAporteDifOSyFSR.TabIndex = 94
        Me.chkAporteDifOSyFSR.Text = "Aporte"
        Me.chkAporteDifOSyFSR.UseVisualStyleBackColor = True
        '
        'chkBaseImponible01
        '
        Me.chkBaseImponible01.AutoSize = True
        Me.chkBaseImponible01.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkBaseImponible01.Location = New System.Drawing.Point(117, 16)
        Me.chkBaseImponible01.Name = "chkBaseImponible01"
        Me.chkBaseImponible01.Size = New System.Drawing.Size(33, 17)
        Me.chkBaseImponible01.TabIndex = 85
        Me.chkBaseImponible01.Text = "1"
        Me.chkBaseImponible01.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(7, 81)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(228, 13)
        Me.Label20.TabIndex = 84
        Me.Label20.Text = "Base de calculo diferencial seg. Social"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(6, 16)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(93, 13)
        Me.Label21.TabIndex = 83
        Me.Label21.Text = "Base Imponible"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(249, 43)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(77, 13)
        Me.Label24.TabIndex = 106
        Me.Label24.Text = "Codigo AFIP"
        '
        'cmbCodigoAfip
        '
        Me.cmbCodigoAfip.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbCodigoAfip.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCodigoAfip.FormattingEnabled = True
        Me.cmbCodigoAfip.Location = New System.Drawing.Point(245, 59)
        Me.cmbCodigoAfip.Name = "cmbCodigoAfip"
        Me.cmbCodigoAfip.Size = New System.Drawing.Size(223, 21)
        Me.cmbCodigoAfip.TabIndex = 107
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Red
        Me.Label25.Location = New System.Drawing.Point(3, 415)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(120, 13)
        Me.Label25.TabIndex = 108
        Me.Label25.Text = "Variables para usar:"
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(3, 428)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(466, 121)
        Me.Label26.TabIndex = 109
        Me.Label26.Text = resources.GetString("Label26.Text")
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(509, 423)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 110
        Me.Button1.Text = "CANCELAR"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmbtipo
        '
        Me.cmbtipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbtipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbtipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbtipo.FormattingEnabled = True
        Me.cmbtipo.Location = New System.Drawing.Point(6, 58)
        Me.cmbtipo.Name = "cmbtipo"
        Me.cmbtipo.Size = New System.Drawing.Size(149, 21)
        Me.cmbtipo.TabIndex = 111
        '
        'chkMarcaRepeticion
        '
        Me.chkMarcaRepeticion.AutoSize = True
        Me.chkMarcaRepeticion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMarcaRepeticion.Location = New System.Drawing.Point(388, 42)
        Me.chkMarcaRepeticion.Name = "chkMarcaRepeticion"
        Me.chkMarcaRepeticion.Size = New System.Drawing.Size(80, 17)
        Me.chkMarcaRepeticion.TabIndex = 115
        Me.chkMarcaRepeticion.Text = "Repetible"
        Me.chkMarcaRepeticion.UseVisualStyleBackColor = True
        '
        'NuevoConceptoSueldo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(678, 550)
        Me.Controls.Add(Me.chkMarcaRepeticion)
        Me.Controls.Add(Me.cmbtipo)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.cmbCodigoAfip)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lbltitulo)
        Me.Controls.Add(Me.txtformula)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.chkAporteFNE)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.chkAporteAAFF)
        Me.Controls.Add(Me.txtcantidad)
        Me.Controls.Add(Me.cmdaddconcepto)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbunidad)
        Me.Controls.Add(Me.txtcodigo)
        Me.Controls.Add(Me.txtconcepto)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtmonto)
        Me.Name = "NuevoConceptoSueldo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NuevoConceptoSueldo"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbltitulo As Label
    Friend WithEvents chkbasico As CheckBox
    Friend WithEvents txtformula As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtcantidad As TextBox
    Friend WithEvents cmdaddconcepto As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbunidad As ComboBox
    Friend WithEvents txtcodigo As TextBox
    Friend WithEvents txtconcepto As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtmonto As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents chkContribucionLeyRiesgoTrabajo As CheckBox
    Friend WithEvents chkContribucionesRegEspeciales As CheckBox
    Friend WithEvents chkContribucionesDiferenciales As CheckBox
    Friend WithEvents chkContribucionesFNE As CheckBox
    Friend WithEvents chkContribucionesAAFF As CheckBox
    Friend WithEvents chkContribucionesRENATEA As CheckBox
    Friend WithEvents chkContribucionesFSR As CheckBox
    Friend WithEvents chkContribucionesOSocial As CheckBox
    Friend WithEvents chkContribucionesINSSJyP As CheckBox
    Friend WithEvents chkContribucionesSIPA As CheckBox
    Friend WithEvents chkAporteRegEspeciales As CheckBox
    Friend WithEvents chkAporteDiferenciales As CheckBox
    Friend WithEvents chkAporteFNE As CheckBox
    Friend WithEvents chkAporteAAFF As CheckBox
    Friend WithEvents chkAporteRENATEA As CheckBox
    Friend WithEvents chkAporteFSR As CheckBox
    Friend WithEvents chkAporteOSocial As CheckBox
    Friend WithEvents chkAporteINSSJyP As CheckBox
    Friend WithEvents chkAporteSIPA As CheckBox
    Friend WithEvents Label19 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents chkBaseImponible06 As CheckBox
    Friend WithEvents chkBaseImponible05 As CheckBox
    Friend WithEvents chkBaseImponible04 As CheckBox
    Friend WithEvents chkBaseImponible03 As CheckBox
    Friend WithEvents chkBaseImponible02 As CheckBox
    Friend WithEvents chkBaseCalculoART As CheckBox
    Friend WithEvents chkAporteDifSegSocial As CheckBox
    Friend WithEvents chkAporteDifOSyFSR As CheckBox
    Friend WithEvents chkBaseImponible01 As CheckBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents chkBaseImponible10 As CheckBox
    Friend WithEvents chkBaseImponible09 As CheckBox
    Friend WithEvents chkBaseImponible08 As CheckBox
    Friend WithEvents chkBaseImponible07 As CheckBox
    Friend WithEvents chkMaternidadAnses As CheckBox
    Friend WithEvents Label23 As Label
    Friend WithEvents chkContribucionDifSegSocial As CheckBox
    Friend WithEvents chkContribDifOSyFSR As CheckBox
    Friend WithEvents Label24 As Label
    Friend WithEvents cmbCodigoAfip As ComboBox
    Friend WithEvents Label25 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents cmbtipo As ComboBox
    Friend WithEvents chkMarcaRepeticion As CheckBox
End Class
