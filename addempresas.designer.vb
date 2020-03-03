<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmaddempresas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmaddempresas))
        Me.pntitulo = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnnavegacion = New System.Windows.Forms.Panel()
        Me.lblestado = New System.Windows.Forms.Label()
        Me.cmdcancelar = New System.Windows.Forms.Button()
        Me.cmdaceptar = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.txtrazon = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtcuit = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtdireccion = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtlocalidad = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbprovincias = New System.Windows.Forms.ComboBox()
        Me.txttelefono = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtingbrutos = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtnumestablec = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtnlibro = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtnhojaventas = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtholacompras = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cmbcondicionesiva = New System.Windows.Forms.ComboBox()
        Me.cmbactividadesempresas = New System.Windows.Forms.ComboBox()
        Me.cmbtipoempresas = New System.Windows.Forms.ComboBox()
        Me.cmbptoventa = New System.Windows.Forms.ComboBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.cmdaddptoveta = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.dtactividades = New System.Windows.Forms.DataGridView()
        Me.idacti = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.activtxt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.alicuotatxt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pntitulo.SuspendLayout()
        Me.pnnavegacion.SuspendLayout()
        CType(Me.dtactividades, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.pntitulo.Size = New System.Drawing.Size(713, 40)
        Me.pntitulo.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Sansation", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(312, 39)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Agregar Empresas"
        '
        'pnnavegacion
        '
        Me.pnnavegacion.AutoScroll = True
        Me.pnnavegacion.BackColor = System.Drawing.Color.Gray
        Me.pnnavegacion.Controls.Add(Me.lblestado)
        Me.pnnavegacion.Controls.Add(Me.cmdcancelar)
        Me.pnnavegacion.Controls.Add(Me.cmdaceptar)
        Me.pnnavegacion.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnnavegacion.Location = New System.Drawing.Point(0, 40)
        Me.pnnavegacion.Name = "pnnavegacion"
        Me.pnnavegacion.Size = New System.Drawing.Size(713, 73)
        Me.pnnavegacion.TabIndex = 5
        '
        'lblestado
        '
        Me.lblestado.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblestado.Font = New System.Drawing.Font("Sansation", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblestado.ForeColor = System.Drawing.Color.Red
        Me.lblestado.Location = New System.Drawing.Point(10, 0)
        Me.lblestado.Name = "lblestado"
        Me.lblestado.Size = New System.Drawing.Size(563, 73)
        Me.lblestado.TabIndex = 38
        Me.lblestado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdcancelar
        '
        Me.cmdcancelar.Dock = System.Windows.Forms.DockStyle.Right
        Me.cmdcancelar.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.cmdcancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdcancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdcancelar.ForeColor = System.Drawing.Color.White
        Me.cmdcancelar.Image = CType(resources.GetObject("cmdcancelar.Image"), System.Drawing.Image)
        Me.cmdcancelar.Location = New System.Drawing.Point(573, 0)
        Me.cmdcancelar.Name = "cmdcancelar"
        Me.cmdcancelar.Size = New System.Drawing.Size(70, 73)
        Me.cmdcancelar.TabIndex = 17
        Me.cmdcancelar.Text = "Salir"
        Me.cmdcancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdcancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdcancelar.UseVisualStyleBackColor = True
        '
        'cmdaceptar
        '
        Me.cmdaceptar.Dock = System.Windows.Forms.DockStyle.Right
        Me.cmdaceptar.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.cmdaceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdaceptar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdaceptar.ForeColor = System.Drawing.Color.White
        Me.cmdaceptar.Image = CType(resources.GetObject("cmdaceptar.Image"), System.Drawing.Image)
        Me.cmdaceptar.Location = New System.Drawing.Point(643, 0)
        Me.cmdaceptar.Name = "cmdaceptar"
        Me.cmdaceptar.Size = New System.Drawing.Size(70, 73)
        Me.cmdaceptar.TabIndex = 16
        Me.cmdaceptar.Text = "Aceptar"
        Me.cmdaceptar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdaceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.cmdaceptar.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(1, 155)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(126, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Nombre de Fantasía:"
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(4, 171)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(408, 20)
        Me.txtNombre.TabIndex = 1
        '
        'txtrazon
        '
        Me.txtrazon.Location = New System.Drawing.Point(4, 132)
        Me.txtrazon.Name = "txtrazon"
        Me.txtrazon.Size = New System.Drawing.Size(703, 20)
        Me.txtrazon.TabIndex = 0
        Me.txtrazon.Tag = ""
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(1, 116)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Razón Social:"
        '
        'txtcuit
        '
        Me.txtcuit.Location = New System.Drawing.Point(419, 171)
        Me.txtcuit.Name = "txtcuit"
        Me.txtcuit.Size = New System.Drawing.Size(288, 20)
        Me.txtcuit.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(416, 155)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "CUIT:"
        '
        'txtdireccion
        '
        Me.txtdireccion.Location = New System.Drawing.Point(4, 210)
        Me.txtdireccion.Name = "txtdireccion"
        Me.txtdireccion.Size = New System.Drawing.Size(408, 20)
        Me.txtdireccion.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(1, 194)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Dirección:"
        '
        'txtlocalidad
        '
        Me.txtlocalidad.Location = New System.Drawing.Point(421, 210)
        Me.txtlocalidad.Name = "txtlocalidad"
        Me.txtlocalidad.Size = New System.Drawing.Size(286, 20)
        Me.txtlocalidad.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(418, 194)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Localidad:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(1, 233)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Provincia"
        '
        'cmbprovincias
        '
        Me.cmbprovincias.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbprovincias.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbprovincias.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbprovincias.FormattingEnabled = True
        Me.cmbprovincias.Location = New System.Drawing.Point(4, 249)
        Me.cmbprovincias.Name = "cmbprovincias"
        Me.cmbprovincias.Size = New System.Drawing.Size(408, 23)
        Me.cmbprovincias.TabIndex = 5
        '
        'txttelefono
        '
        Me.txttelefono.Location = New System.Drawing.Point(421, 249)
        Me.txttelefono.Name = "txttelefono"
        Me.txttelefono.Size = New System.Drawing.Size(286, 20)
        Me.txttelefono.TabIndex = 6
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(418, 233)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 13)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Teléfono:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(1, 275)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(109, 13)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "Condicion de IVA:"
        '
        'txtingbrutos
        '
        Me.txtingbrutos.Location = New System.Drawing.Point(312, 291)
        Me.txtingbrutos.Name = "txtingbrutos"
        Me.txtingbrutos.Size = New System.Drawing.Size(395, 20)
        Me.txtingbrutos.TabIndex = 8
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(309, 275)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 13)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "Ing. Brutos num:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(393, 616)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(117, 13)
        Me.Label12.TabIndex = 26
        Me.Label12.Text = "Nº establecimiento:"
        Me.Label12.Visible = False
        '
        'txtnumestablec
        '
        Me.txtnumestablec.Location = New System.Drawing.Point(396, 632)
        Me.txtnumestablec.Name = "txtnumestablec"
        Me.txtnumestablec.Size = New System.Drawing.Size(109, 20)
        Me.txtnumestablec.TabIndex = 10
        Me.txtnumestablec.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(146, 317)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(101, 13)
        Me.Label13.TabIndex = 29
        Me.Label13.Text = "Tipo de empresa"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(1, 366)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(250, 13)
        Me.Label14.TabIndex = 31
        Me.Label14.Text = "Actividad de empresa (codigo/descripcion)"
        '
        'txtnlibro
        '
        Me.txtnlibro.Location = New System.Drawing.Point(14, 632)
        Me.txtnlibro.Name = "txtnlibro"
        Me.txtnlibro.Size = New System.Drawing.Size(109, 20)
        Me.txtnlibro.TabIndex = 13
        Me.txtnlibro.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(11, 616)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(93, 13)
        Me.Label15.TabIndex = 32
        Me.Label15.Text = "Nº Libro de Iva"
        Me.Label15.Visible = False
        '
        'txtnhojaventas
        '
        Me.txtnhojaventas.Location = New System.Drawing.Point(128, 506)
        Me.txtnhojaventas.Name = "txtnhojaventas"
        Me.txtnhojaventas.Size = New System.Drawing.Size(109, 20)
        Me.txtnhojaventas.TabIndex = 14
        Me.txtnhojaventas.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(1, 509)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(121, 13)
        Me.Label16.TabIndex = 34
        Me.Label16.Text = "Nº Hoja libro ventas"
        Me.Label16.Visible = False
        '
        'txtholacompras
        '
        Me.txtholacompras.Location = New System.Drawing.Point(418, 506)
        Me.txtholacompras.Name = "txtholacompras"
        Me.txtholacompras.Size = New System.Drawing.Size(109, 20)
        Me.txtholacompras.TabIndex = 15
        Me.txtholacompras.Visible = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(282, 509)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(130, 13)
        Me.Label17.TabIndex = 36
        Me.Label17.Text = "Nº Hoja libro compras"
        Me.Label17.Visible = False
        '
        'cmbcondicionesiva
        '
        Me.cmbcondicionesiva.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbcondicionesiva.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbcondicionesiva.FormattingEnabled = True
        Me.cmbcondicionesiva.Location = New System.Drawing.Point(4, 290)
        Me.cmbcondicionesiva.Name = "cmbcondicionesiva"
        Me.cmbcondicionesiva.Size = New System.Drawing.Size(302, 21)
        Me.cmbcondicionesiva.TabIndex = 37
        '
        'cmbactividadesempresas
        '
        Me.cmbactividadesempresas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbactividadesempresas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbactividadesempresas.FormattingEnabled = True
        Me.cmbactividadesempresas.Location = New System.Drawing.Point(4, 584)
        Me.cmbactividadesempresas.Name = "cmbactividadesempresas"
        Me.cmbactividadesempresas.Size = New System.Drawing.Size(588, 21)
        Me.cmbactividadesempresas.TabIndex = 38
        Me.cmbactividadesempresas.Visible = False
        '
        'cmbtipoempresas
        '
        Me.cmbtipoempresas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbtipoempresas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbtipoempresas.FormattingEnabled = True
        Me.cmbtipoempresas.Location = New System.Drawing.Point(149, 333)
        Me.cmbtipoempresas.Name = "cmbtipoempresas"
        Me.cmbtipoempresas.Size = New System.Drawing.Size(557, 21)
        Me.cmbtipoempresas.TabIndex = 39
        '
        'cmbptoventa
        '
        Me.cmbptoventa.Enabled = False
        Me.cmbptoventa.FormattingEnabled = True
        Me.cmbptoventa.Location = New System.Drawing.Point(4, 333)
        Me.cmbptoventa.Name = "cmbptoventa"
        Me.cmbptoventa.Size = New System.Drawing.Size(109, 21)
        Me.cmbptoventa.TabIndex = 124
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(1, 317)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(74, 13)
        Me.Label42.TabIndex = 123
        Me.Label42.Text = "Ptos ventas"
        '
        'cmdaddptoveta
        '
        Me.cmdaddptoveta.Enabled = False
        Me.cmdaddptoveta.Image = CType(resources.GetObject("cmdaddptoveta.Image"), System.Drawing.Image)
        Me.cmdaddptoveta.Location = New System.Drawing.Point(119, 333)
        Me.cmdaddptoveta.Name = "cmdaddptoveta"
        Me.cmdaddptoveta.Size = New System.Drawing.Size(24, 21)
        Me.cmdaddptoveta.TabIndex = 125
        Me.cmdaddptoveta.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Enabled = False
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(384, 571)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(24, 21)
        Me.Button1.TabIndex = 128
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(595, 568)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(59, 13)
        Me.Label11.TabIndex = 126
        Me.Label11.Text = "Alicuotas"
        Me.Label11.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(598, 585)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(108, 20)
        Me.TextBox1.TabIndex = 131
        Me.TextBox1.Visible = False
        '
        'dtactividades
        '
        Me.dtactividades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dtactividades.BackgroundColor = System.Drawing.Color.White
        Me.dtactividades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtactividades.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.idacti, Me.activtxt, Me.alicuotatxt})
        Me.dtactividades.Enabled = False
        Me.dtactividades.Location = New System.Drawing.Point(4, 382)
        Me.dtactividades.Name = "dtactividades"
        Me.dtactividades.Size = New System.Drawing.Size(702, 92)
        Me.dtactividades.TabIndex = 132
        '
        'idacti
        '
        Me.idacti.FillWeight = 65.36974!
        Me.idacti.HeaderText = "ID"
        Me.idacti.Name = "idacti"
        '
        'activtxt
        '
        Me.activtxt.FillWeight = 188.945!
        Me.activtxt.HeaderText = "Actividad"
        Me.activtxt.Name = "activtxt"
        '
        'alicuotatxt
        '
        Me.alicuotatxt.FillWeight = 45.68528!
        Me.alicuotatxt.HeaderText = "Alicuota"
        Me.alicuotatxt.Name = "alicuotatxt"
        '
        'frmaddempresas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(713, 483)
        Me.Controls.Add(Me.dtactividades)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.cmdaddptoveta)
        Me.Controls.Add(Me.cmbptoventa)
        Me.Controls.Add(Me.Label42)
        Me.Controls.Add(Me.cmbtipoempresas)
        Me.Controls.Add(Me.cmbactividadesempresas)
        Me.Controls.Add(Me.cmbcondicionesiva)
        Me.Controls.Add(Me.txtholacompras)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtnhojaventas)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtnlibro)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtnumestablec)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtingbrutos)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txttelefono)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cmbprovincias)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtlocalidad)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtdireccion)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtcuit)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtrazon)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtNombre)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.pnnavegacion)
        Me.Controls.Add(Me.pntitulo)
        Me.Name = "frmaddempresas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Agregar Empresas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pntitulo.ResumeLayout(False)
        Me.pntitulo.PerformLayout()
        Me.pnnavegacion.ResumeLayout(False)
        CType(Me.dtactividades, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pntitulo As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnnavegacion As System.Windows.Forms.Panel
    Friend WithEvents cmdcancelar As System.Windows.Forms.Button
    Friend WithEvents cmdaceptar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtrazon As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtcuit As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtdireccion As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtlocalidad As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbprovincias As System.Windows.Forms.ComboBox
    Friend WithEvents txttelefono As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtingbrutos As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtnumestablec As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtnlibro As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtnhojaventas As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtholacompras As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblestado As System.Windows.Forms.Label
    Friend WithEvents cmbcondicionesiva As System.Windows.Forms.ComboBox
    Friend WithEvents cmbactividadesempresas As System.Windows.Forms.ComboBox
    Friend WithEvents cmbtipoempresas As System.Windows.Forms.ComboBox
    Friend WithEvents cmbptoventa As System.Windows.Forms.ComboBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents cmdaddptoveta As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents dtactividades As System.Windows.Forms.DataGridView
    Friend WithEvents idacti As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents activtxt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents alicuotatxt As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
