Imports System.IO

Public Class iva

    Private OpcCompr As Integer
    Private IDperiodo As Integer
    Private estadoPer As String
    Private AlicuotaACT As Double

    Private Sub iva_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = "."c Then
            e.Handled = True
            SendKeys.Send(",")
        End If
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            'MsgBox("la puta que me pario que funcione")
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub iva_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.F5 Then
            CargarDtosGrales()
            cargarDtosComp()
            cargarDtosVtas()
        End If
    End Sub
    Private Sub iva_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "IVA: " & EmpDB
        lbltitulo.Text = Me.Text
        CargarPeriodos()
        CargarDtosGrales()
        'CargarActividadEmp()
        lblabrev.Text = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub CargarPeriodos()
        Try
            Reconectar()
            conexionEmp.ChangeDatabase(EmpDB)
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, concat(mes,'/', ano) as Periodo, estado as Estado from iv_periodos order by id desc", conexionEmp)
            Dim tabla2 As New DataSet
            ' Dim tabla As New DataTable
            consulta.Fill(tabla2)
            ' consulta.Fill(tabla)
            cmbperiodocarg.DataSource = tabla2.Tables(0)
            cmbperiodocarg.ValueMember = tabla2.Tables(0).Columns(0).Caption.ToString
            cmbperiodocarg.DisplayMember = tabla2.Tables(0).Columns(1).Caption.ToString
            cmbperiodocarg.SelectedValue = 0

            cmbperiodo.DataSource = tabla2.Tables(0)
            cmbperiodo.ValueMember = tabla2.Tables(0).Columns(0).Caption.ToString
            cmbperiodo.DisplayMember = tabla2.Tables(0).Columns(1).Caption.ToString
            cmbperiodo.SelectedValue = -1

            'dtperiodos.DataSource = tabla
            cmbcompperiodo.DataSource = tabla2.Tables(0)
            cmbcompperiodo.ValueMember = tabla2.Tables(0).Columns(0).Caption.ToString
            cmbcompperiodo.DisplayMember = tabla2.Tables(0).Columns(1).Caption.ToString
            cmbcompperiodo.SelectedValue = -1

            ' dtperiodos.Columns(2).Visible = False
        Catch ex As Exception
            lblestado.Text = ex.Message
        End Try
    End Sub

    Private Sub cmdnuevo_Click(sender As Object, e As EventArgs) Handles cmdnuevo.Click
        Dim mes As String
        Dim ano As String
        Dim cadena As String
        Dim mescur As Integer
        Dim anocur As Integer
        Dim sqlQuery As String
        Try
            Reconectar()
            mescur = Month(Now)
            If mescur = 1 Then
                mescur = 12
                anocur = Year(Now) - 1
            Else
                mescur = Month(Now) - 1
                anocur = Year(Now)
            End If
            cadena = InputBox("Ingrese el MES/AÑO ej: enero/2013", "Nuevo periodo", MonthName(mescur).ToUpper & "/" & anocur)
            If cadena <> "" Then
                mes = MonthName(Month(cadena)).ToUpper
                ano = Year(cadena)
            End If
            If mes <> "" And ano <> "" Then
                sqlQuery = "insert into iv_periodos(mes, ano,estado) values(?mes,?ano,?est)"
                Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionEmp)
                With comandoadd.Parameters
                    .AddWithValue("?mes", mes)
                    .AddWithValue("?ano", ano)
                    .AddWithValue("?est", "ABIERTO")
                End With
                comandoadd.ExecuteNonQuery()
                CargarPeriodos()
            End If
        Catch ex As Exception
            lblestado.Text = ex.Message
        End Try
    End Sub

    Private Sub dtpfechanac_ValueChanged(sender As Object, e As EventArgs) Handles dtpfechacomp.ValueChanged
        SendKeys.Send("/")
    End Sub
    Private Sub cargarDtosVtas()
        Reconectar()
        'cargamos provincias
        Dim tablaprov As New MySql.Data.MySqlClient.MySqlDataAdapter("select idprovincias,nombre from cm_provincias", conexionPrinc)
        Dim readp As New DataSet
        tablaprov.Fill(readp)
        cmbprovincias.DataSource = readp.Tables(0)
        cmbprovincias.ValueMember = readp.Tables(0).Columns(0).Caption.ToString
        cmbprovincias.DisplayMember = readp.Tables(0).Columns(1).Caption.ToString
        cmbprovincias.SelectedValue = -1

        'cargar tipos comprobantes ventas
        Dim tablatipovta As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, nombre from cm_iv_tipo_comprobante where aplica=2", conexionPrinc)
        Dim readtipovta As New DataSet
        tablatipovta.Fill(readtipovta)
        cmbvtatipocom.DataSource = readtipovta.Tables(0)
        cmbvtatipocom.DisplayMember = readtipovta.Tables(0).Columns(1).Caption.ToString
        cmbvtatipocom.ValueMember = readtipovta.Tables(0).Columns(0).Caption.ToString
        cmbvtatipocom.SelectedIndex = -1

        'cargar razon social clientes
        Dim tablarazoncliente As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, razon from iv_clientes", conexionEmp)
        Dim readrazoncliente As New DataSet
        tablarazoncliente.Fill(readrazoncliente)
        cmbvtarazon.DataSource = readrazoncliente.Tables(0)
        cmbvtarazon.DisplayMember = readrazoncliente.Tables(0).Columns(1).Caption.ToString
        cmbvtarazon.ValueMember = readrazoncliente.Tables(0).Columns(0).Caption.ToString
        cmbvtarazon.SelectedIndex = -1

        'cargamos Ptos de venta
        Dim tablaptoVta As New MySql.Data.MySqlClient.MySqlDataAdapter("select nombre from iv_punto_venta", conexionEmp)
        Dim readtablaPtoVta As New DataSet
        tablaptoVta.Fill(readtablaPtoVta)
        cmbptoventa.DataSource = readtablaPtoVta.Tables(0)
        cmbptoventa.DisplayMember = readtablaPtoVta.Tables(0).Columns(0).Caption.ToString
        cmbptoventa.Text = ""
    End Sub

    Private Sub cargarDtosComp()
        Reconectar()
        'cargar razon social proveedores
        Dim tablarazonSocial As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, razon from iv_proveedores", conexionEmp)
        Dim readrazonSocial As New DataSet
        tablarazonSocial.Fill(readrazonSocial)
        cmbrazonComp.DataSource = readrazonSocial.Tables(0)
        cmbrazonComp.DisplayMember = readrazonSocial.Tables(0).Columns(1).Caption.ToString
        cmbrazonComp.ValueMember = readrazonSocial.Tables(0).Columns(0).Caption.ToString
        cmbrazonComp.SelectedIndex = -1

        'cargar tipos comprobantes compras
        Dim tablatipocompr As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, nombre from cm_iv_tipo_comprobante where aplica=1", conexionPrinc)
        Dim readtipocompr As New DataSet
        tablatipocompr.Fill(readtipocompr)
        cmbtipocomComp.DataSource = readtipocompr.Tables(0)
        cmbtipocomComp.DisplayMember = readtipocompr.Tables(0).Columns(1).Caption.ToString
        cmbtipocomComp.ValueMember = readtipocompr.Tables(0).Columns(0).Caption.ToString
        cmbtipocomComp.SelectedIndex = -1


    End Sub
    Private Sub CargarDtosGrales()
        Try

            Reconectar()
            'cargar condiciones de iva
            Dim tablatipivaComp As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, nombre from cm_condicion_iva", conexionPrinc)
            Dim readtipoivacomp As New DataSet
            tablatipivaComp.Fill(readtipoivacomp)
            cmbcondivaComp.DataSource = readtipoivacomp.Tables(0)
            cmbcondivaComp.DisplayMember = readtipoivacomp.Tables(0).Columns(1).Caption.ToString
            cmbcondivaComp.ValueMember = readtipoivacomp.Tables(0).Columns(0).Caption.ToString
            cmbcondivaComp.SelectedIndex = -1
            cmbvtacond.DataSource = readtipoivacomp.Tables(0)
            cmbvtacond.DisplayMember = readtipoivacomp.Tables(0).Columns(1).Caption.ToString
            cmbvtacond.ValueMember = readtipoivacomp.Tables(0).Columns(0).Caption.ToString
            cmbvtacond.SelectedIndex = -1

            cargarDtosComp()
            cargarDtosVtas()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Sumar()
        Try
            Dim neto21 As Double = FormatNumber(txtnetoComp.Text)
            Dim neto105 As Double = FormatNumber(txtnetocom105.Text)
            Dim neto27 As Double = FormatNumber(txtnetocom27.Text)
            Dim ivatemp As Double = Math.Round(neto21 * 0.21 + neto105 * 0.105 + neto27 * 0.27, 2)
            txtivamontoComp.Text = ivatemp
            Dim ivamont As Double = FormatNumber(txtivamontoComp.Text)
            Dim monot As Double = FormatNumber(txtmontmonotComp.Text)
            Dim pagoCuenta As Double = FormatNumber(txtpagoacuentaComp.Text)
            Dim noGREX As Double = FormatNumber(txtnogrComp.Text)
            Dim percIVA As Double = FormatNumber(txtpercivComp.Text)
            Dim percIB As Double = FormatNumber(txtperibComp.Text)

            txttotalComp.Text = FormatNumber(neto21 + neto105 + neto27 + ivamont + monot + pagoCuenta + noGREX + percIVA + percIB, 2)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub SumarVentas()
        Try
            Dim netovta As Double = FormatNumber(txtvtaneto.Text)
            Dim ivavta105 As Double = FormatNumber(txtvtaiva105.Text)
            Dim ivavta21 As Double = FormatNumber(txtvtaiva21.Text)
            Dim ivavtaotro As Double = FormatNumber(txtvtaotroiva.Text)
            Dim retiva As Double = FormatNumber(txtvtaretiv.Text)
            Dim retib As Double = FormatNumber(txtvtaretib.Text)
            Dim retgan As Double = FormatNumber(txtvtaretgan.Text)
            txtvtatot.Text = FormatNumber(netovta + ivavta105 + ivavta21 + ivavtaotro - (retgan + retib + retiva), 2)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdcalcFactComb_Click(sender As Object, e As EventArgs) Handles cmdcalcFactComb.Click
        Try
            Dim combNoGr As Double = FormatNumber(txtfacCombNoGrav.Text, 2)
            Dim combLitros As Double = FormatNumber(txtLitrosComb.Text, 2)
            Dim coefComb As Double = FormatNumber(txtCoefComb.Text, 5)
            Dim TotFac As Double = FormatNumber(txttotalfac.Text, 2)
            Dim porcIvaFac As Double = FormatNumber(txtivafact.Text, 5)


            Dim pagoCuenta As Double
            Dim noGREX As Double
            Dim netofact As Double
            Dim ivafact As Double
            Dim netoGr As Double

            If TotFac <> 0 And porcIvaFac <> 0 Then
                Dim coefivafac As Double = FormatNumber((porcIvaFac + 100) / 100)

                ivafact = (TotFac * porcIvaFac) / 100
                netoGr = ivafact / 0.21
                combNoGr = TotFac - (netoGr + ivafact)
                txtnetoComp.Text = Math.Round(netoGr, 2)
                txtivamontoComp.Text = ivafact

            End If


            pagoCuenta = Math.Round(coefComb * combLitros, 2)
            'MsgBox(coefComb & "* " & combLitros & vbNewLine & pagoCuenta)
            noGREX = Math.Round(combNoGr - pagoCuenta, 2)




            txtnogrComp.Text = noGREX
            txtpagoacuentaComp.Text = pagoCuenta
            txtobservacionesComp.Text = txtLitrosComb.Text & " Litros"
            txtivamontoComp.Focus()
            gbFactComb.Visible = False
            txtfacCombNoGrav.Clear()
            txtLitrosComb.Clear()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdCalcTik_Click(sender As Object, e As EventArgs) Handles cmdCalcTik.Click
        Try
            Dim cantTik As Double = FormatNumber(txtcantTik.Text)
            Dim MontoTik As Double = FormatNumber(txtmontoTik.Text)
            Dim ivaTik As Double = (FormatNumber(txtIvaTik.Text) + 100) / 100

            Dim montoTotal As Double = MontoTik * cantTik
            Dim neto As Double = montoTotal / ivaTik

            txtnetoComp.Text = FormatNumber(neto, 2)
            txtivamontoComp.Text = FormatNumber(montoTotal - neto, 2)
            txtobservacionesComp.Text = cantTik & " Tickets"
            txtivamontoComp.Focus()
            GbTiketPeaje.Visible = False
            txtcantTik.Clear()
            txtmontoTik.Clear()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdTikExc_Click(sender As Object, e As EventArgs) Handles cmdTikExc.Click
        Dim cantTik As Double = FormatNumber(txtcantTik.Text)
        Dim MontoTik As Double = FormatNumber(txtmontoTik.Text)
        txtnogrComp.Text = FormatNumber(cantTik * MontoTik, 2)
        txtobservacionesComp.Text = cantTik & " Tickets"
        GbTiketPeaje.Visible = False
        txtcantTik.Clear()
        txtmontoTik.Clear()
    End Sub

    Private Sub cmbtipocomComp_KeyUp(sender As Object, e As KeyEventArgs) Handles cmbtipocomComp.KeyUp
        If cmbtipocomComp.SelectedValue <> 0 And cmbtipocomComp.SelectedIndex <> -1 Then
            txtfaciz.Focus()
        End If
    End Sub

    Private Sub cmbtipocomComp_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbtipocomComp.SelectedValueChanged
        Try
            Reconectar()
            Dim lector As System.Data.IDataReader
            Dim sql As New MySql.Data.MySqlClient.MySqlCommand
            If cmbtipocomComp.SelectedIndex > -1 Then
                'Dim TCOMP As String = cmbtipocomComp.SelectedValue.ToString
                sql.Connection = conexionPrinc
                sql.CommandText = "SELECT opciones, abreviatura from cm_iv_tipo_comprobante where id = " & cmbtipocomComp.SelectedValue
                sql.CommandType = CommandType.Text
                lector = sql.ExecuteReader
                lector.Read()
                lblabrev.Text = lector("abreviatura").ToString
                If Not IsDBNull(lector("opciones")) Then
                    OpcCompr = lector("opciones").ToString
                Else
                    OpcCompr = 0
                End If
            Else
                lblabrev.Text = ""
            End If
        Catch ex As Exception
            lblabrev.Text = ""
            OpcCompr = 0
        End Try
    End Sub

    Private Sub cmdcalcPagoaCuenta_Click(sender As Object, e As EventArgs) Handles cmdcalcPagoaCuenta.Click
        Try
            Reconectar()
            Select Case OpcCompr
                Case 1
                    GbTiketPeaje.Visible = True
                    txtmontoTik.Focus()
                Case 2
                    gbFactComb.Visible = True
                    txtfacCombNoGrav.Focus()
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        GbTiketPeaje.Visible = False
        txtcantTik.Clear()
        txtmontoTik.Clear()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        gbFactComb.Visible = False
        txtfacCombNoGrav.Clear()
        txtLitrosComb.Clear()
    End Sub
    Private Function comprobarComprobanteCompra(ByRef comprobante As String, ByRef contribuyente As String) As Boolean
        Try
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("select id from iv_items_compras where nufac like '" & comprobante & "' and " _
            & "replace(cuit,'-','') like '" & Replace(contribuyente, "-", "") & "'", conexionEmp)
            Dim tablacl As New DataTable
            consulta.Fill(tablacl)
            If tablacl.Rows.Count <> 0 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Sub cmdFinalizar_Click(sender As Object, e As EventArgs) Handles cmdFinalizar.Click
        Try

            Dim fecha As String = Format(dtpfechacomp.Value, "yyyy-MM-dd")
            Dim tipocomp As String = lblabrev.Text
            Dim numfac As String = txtfaciz.Text & "-" & txtfacder.Text
            Dim razon As String = cmbrazonComp.Text
            Dim cuit As String = txtcuitComp.Text
            Dim conIVA As String = cmbcondivaComp.Text
            Dim neto21 As String = txtnetoComp.Text
            Dim neto105 As String = txtnetocom105.Text
            Dim neto27 As String = txtnetocom27.Text
            Dim iva As String = txtivamontoComp.Text
            Dim monot As String = txtmontmonotComp.Text
            Dim pcuenta As String = txtpagoacuentaComp.Text
            Dim nogrex As String = txtnogrComp.Text
            Dim periv As String = txtpercivComp.Text
            Dim perib As String = txtperibComp.Text
            Dim total As String = txttotalComp.Text
            Dim observa As String = txtobservacionesComp.Text
            Dim bienuso As Integer = chkcomprabiendeuso.CheckState
            Dim sqlQuery As String

            If comprobarComprobanteCompra(numfac, cuit) = True Then
                MsgBox("el comprobante ya fue cargado, por favor verifique")
                Exit Sub
            End If

            If tipocomp = "NC" Then
                If neto21 <> 0 Then neto21 = "-" & neto21
                If neto105 <> 0 Then neto105 = "-" & neto105
                If neto27 <> 0 Then neto27 = "-" & neto27
                If iva <> 0 Then iva = "-" & iva
                If monot <> 0 Then monot = "-" & monot
                If pcuenta <> 0 Then pcuenta = "-" & pcuenta
                If nogrex <> 0 Then nogrex = "-" & nogrex
                If periv <> 0 Then periv = "-" & periv
                If perib <> 0 Then perib = "-" & perib
                If perib <> 0 Then total = "-" & total
            End If

            If cmbrazonComp.SelectedValue = 0 And cmbrazonComp.Text <> "" Then

                Reconectar()
                sqlQuery = "insert into iv_proveedores(razon, cuit,cond_iva) values(?razon,?cuit,?iva)"
                Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionEmp)
                With comandoadd.Parameters
                    .AddWithValue("?razon", cmbrazonComp.Text.ToUpper)
                    .AddWithValue("?cuit", txtcuitComp.Text.ToUpper)
                    .AddWithValue("?iva", cmbcondivaComp.SelectedValue)
                End With
                comandoadd.ExecuteNonQuery()

            End If

            Dim lector As System.Data.IDataReader
            Dim sql As New MySql.Data.MySqlClient.MySqlCommand
            sql.Connection = conexionPrinc
            sql.CommandText = "SELECT abrev from cm_condicion_iva where id = " & cmbcondivaComp.SelectedValue
            sql.CommandType = CommandType.Text
            lector = sql.ExecuteReader
            lector.Read()
            conIVA = lector("abrev").ToString
            If chkcomprabiendeuso.CheckState = 1 Then
                observa = "BIEN DE USO"
            End If
            Reconectar()
            sqlQuery = "insert into iv_items_compras(periodo, fecha,tipocom,nufac,razon,cuit,tipocontr,neto21,neto105,neto27,iva,monot," _
                & "acuenta,nogr,perciva,percib,total,obs,bien_uso) " _
                & "values(?per,?fech,?tcomp,?nfac,?raz,?cuit,?tcontr,?neto21,?neto105,?neto27,?iva,?mon,?acuenta,?nogr,?periva,?perib,?tot,?obs,?bien)"
            Dim additem As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionEmp)
            With additem.Parameters
                .AddWithValue("?per", IDperiodo)
                .AddWithValue("?fech", fecha)
                .AddWithValue("?tcomp", tipocomp)
                .AddWithValue("?nfac", numfac)
                .AddWithValue("?raz", razon)
                .AddWithValue("?cuit", cuit)
                .AddWithValue("?tcontr", conIVA)
                .AddWithValue("?neto21", neto21)
                .AddWithValue("?neto105", neto105)
                .AddWithValue("?neto27", neto27)
                .AddWithValue("?iva", iva)
                .AddWithValue("?mon", monot)
                .AddWithValue("?acuenta", pcuenta)
                .AddWithValue("?nogr", nogrex)
                .AddWithValue("?periva", periv)
                .AddWithValue("?perib", perib)
                .AddWithValue("?tot", total)
                .AddWithValue("?obs", observa.ToUpper)
                .AddWithValue("?bien", bienuso)
            End With
            additem.ExecuteNonQuery()
            dtlibrocomp.Rows.Add(fecha, tipocomp, numfac, razon, cuit, conIVA, neto21, neto105, neto27, iva, monot, pcuenta, nogrex, periv, perib, total, observa.ToUpper, additem.LastInsertedId)
            If tipocomp = "NC" Then
                dtlibrocomp.Rows(dtlibrocomp.RowCount - 1).DefaultCellStyle.BackColor = Color.Red
            End If
            CargarDtosGrales()
            'cargarDtosComp()
            VaciarControles()
            dtpfechacomp.Focus()
        Catch ex As Exception
        End Try

    End Sub
    Private Sub VaciarControles()
        cmbrazonComp.SelectedIndex = -1
        txtcuitComp.Clear()
        cmbcondivaComp.SelectedIndex = -1
        'cmbtipocomComp.SelectedIndex = -1
        txtfaciz.Clear()
        txtfacder.Clear()
        txtnetoComp.Text = 0
        txtnetocom105.Text = 0
        txtnetocom27.Text = 0
        txtivamontoComp.Text = 0
        txtmontmonotComp.Text = 0
        txtpagoacuentaComp.Text = 0
        txtnogrComp.Text = 0
        txtperibComp.Text = 0
        txtpercivComp.Text = 0
        txtobservacionesComp.Clear()

        cmbvtarazon.SelectedIndex = -1
        txtvtacuit.Clear()
        cmbvtacond.SelectedIndex = -1
        txtvtanufac.Clear()
        txtvtatot.Text = 0
        txtvtaneto.Text = 0
        txtvtaiva105.Text = 0
        txtvtaiva21.Text = 0
        txtvtaobs.Clear()
        txtvtaretgan.Text = 0
        txtvtaretib.Text = 0
        txtvtaretiv.Text = 0
        Sumar()
        SumarVentas()
    End Sub



    Private Sub CargarComprasPeriodo()
        Dim lector As System.Data.IDataReader
        Dim sql As New MySql.Data.MySqlClient.MySqlCommand
        Try
            Reconectar()
            sql.Connection = conexionEmp
            sql.CommandText = "SELECT * from iv_items_compras where periodo = " & IDperiodo
            sql.CommandType = CommandType.Text
            lector = sql.ExecuteReader
            dtlibrocomp.Rows.Clear()
            While lector.Read()
                Dim fecha As String = Format(lector("fecha"), "dd-MM-yyyy")
                Dim tipocomp As String = lector("tipocom").ToString
                Dim numfac As String = lector("nufac").ToString
                Dim razon As String = lector("razon").ToString
                Dim cuit As String = lector("cuit").ToString
                Dim conIVA As String = lector("tipocontr").ToString
                Dim neto21 As String = lector("neto21").ToString
                Dim neto105 As String = lector("neto105").ToString
                Dim neto27 As String = lector("neto27").ToString
                Dim iva As String = lector("iva").ToString
                Dim monot As String = lector("monot").ToString
                Dim pcuenta As String = lector("acuenta").ToString
                Dim nogrex As String = lector("nogr").ToString
                Dim periv As String = lector("perciva").ToString
                Dim perib As String = lector("percib").ToString
                Dim total As String = lector("total").ToString
                Dim observa As String = lector("obs").ToString
                Dim idfcomp As Integer = lector("id")

                dtlibrocomp.Rows.Add(fecha, tipocomp, numfac, razon, cuit, conIVA, neto21, neto105, neto27, iva, monot, pcuenta, nogrex, periv, perib, total, observa.ToUpper, idfcomp)
                If tipocomp = "NC" Then
                    dtlibrocomp.Rows(dtlibrocomp.RowCount - 1).DefaultCellStyle.BackColor = Color.Red
                End If
                If observa = "BIEN DE USO" Then
                    dtlibrocomp.Rows(dtlibrocomp.RowCount - 1).DefaultCellStyle.BackColor = Color.Green
                End If
            End While
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CargarVentasPeriodo()
        Dim lector As System.Data.IDataReader
        Dim sql As New MySql.Data.MySqlClient.MySqlCommand
        Try
            Reconectar()
            sql.Connection = conexionEmp
            sql.CommandText = "SELECT * from iv_items_ventas where periodo = " & IDperiodo
            sql.CommandType = CommandType.Text
            lector = sql.ExecuteReader
            dtlibrovent.Rows.Clear()
            While lector.Read()
                Dim fecha As String = Format(lector("fecha"), "dd-MM-yyyy")
                Dim tipocomp As String = lector("tipocom").ToString
                Dim numfac As String = lector("nufac").ToString
                Dim razon As String = lector("razon").ToString
                Dim cuit As String = lector("cuit").ToString
                Dim conIVA As String = lector("tipocontr").ToString
                Dim neto As String = lector("neto").ToString
                Dim iva105 As String = lector("iva105").ToString
                Dim iva21 As String = lector("iva21").ToString
                Dim otroiva As String = lector("otroiva").ToString
                Dim retIV As String = lector("ret_iva").ToString
                Dim retIB As String = lector("ret_ib").ToString
                Dim retGAN As String = lector("ret_gan").ToString
                Dim total As String = lector("total").ToString
                Dim observa As String = lector("obs").ToString
                Dim idfvent As Integer = lector("id")
                dtlibrovent.Rows.Add(fecha, tipocomp, numfac, razon, cuit, conIVA, neto, iva21, iva105, otroiva, retIV, retIB, retGAN, total, observa.ToUpper, idfvent)
                If tipocomp = "NC" Then
                    dtlibrovent.Rows(dtlibrovent.RowCount - 1).DefaultCellStyle.BackColor = Color.Red
                End If

                If observa = "BIEN DE USO" Then
                    dtlibrovent.Rows(dtlibrovent.RowCount - 1).DefaultCellStyle.BackColor = Color.Green
                End If
            End While
        Catch ex As Exception
        End Try
    End Sub

    Private Sub SumarTotales()
        Dim TOTneto21 As Double
        Dim TOTneto105 As Double
        Dim TOTneto27 As Double
        Dim TOTiva As Double
        Dim TOTmonot As Double
        Dim TOTacuenta As Double
        Dim TOTnogr As Double
        Dim TOTperib As Double
        Dim TOTperiv As Double
        Dim TOTgral As Double
        txtTotacuenta.Text = 0
        txtTotgral.Text = 0
        txtTotiva.Text = 0
        txtTotmono.Text = 0
        txtTotNeto.Text = 0
        txttotNeto105.Text = 0
        txttotNeto27.Text = 0
        txtTotNogr.Text = 0
        txtTotperib.Text = 0
        txtTotperiv.Text = 0
        For Each row As DataGridViewRow In dtlibrocomp.Rows
            If row.Cells.Item(14).Value <> "BIEN DE USO" Then
                TOTneto21 += FormatNumber(row.Cells.Item(6).Value, 2)
                TOTneto105 += FormatNumber(row.Cells.Item(7).Value, 2)
                TOTneto27 += FormatNumber(row.Cells.Item(8).Value, 2)
                TOTiva += FormatNumber(row.Cells.Item(9).Value, 2)
                TOTmonot += FormatNumber(row.Cells.Item(10).Value, 2)
                TOTacuenta += FormatNumber(row.Cells.Item(11).Value, 2)
                TOTnogr += FormatNumber(row.Cells.Item(12).Value, 2)
                TOTperib += FormatNumber(row.Cells.Item(13).Value, 2)
                TOTperiv += FormatNumber(row.Cells.Item(14).Value, 2)
                TOTgral += FormatNumber(row.Cells.Item(15).Value, 2)
            End If
        Next
        txtTotacuenta.Text = TOTacuenta
        txtTotgral.Text = TOTgral
        txtTotiva.Text = TOTiva
        txtTotmono.Text = TOTmonot
        txtTotNeto.Text = TOTneto21
        txttotNeto105.Text = TOTneto105
        txttotNeto27.Text = TOTneto27
        txtTotNogr.Text = TOTnogr
        txtTotperib.Text = TOTperib
        txtTotperiv.Text = TOTperiv
    End Sub
    Private Sub SumarTotalesvtas()
        Dim TOTmono As Double
        Dim TOTcf As Double
        Dim TOTri As Double
        Dim TOTexc As Double

        Dim TOT105 As Double
        Dim TOT21 As Double

        Dim TOTneto As Double
        Dim TOTiva As Double
        Dim TOTgral As Double

        For Each row As DataGridViewRow In dtlibrovent.Rows
            If row.Cells.Item(13).Value <> "BIEN DE USO" Then
                Select Case row.Cells.Item(5).Value
                    Case "CF"
                        TOTcf += row.Cells.Item(6).Value
                    Case "RI"
                        TOTri += row.Cells.Item(6).Value
                    Case "EX"
                        TOTexc += row.Cells.Item(6).Value
                    Case "MON"
                        TOTmono += row.Cells.Item(6).Value
                End Select
                TOT105 += row.Cells.Item(8).Value
                TOT21 += row.Cells.Item(7).Value

                TOTneto = TOTmono + TOTcf + TOTri + TOTexc

                TOTiva = TOT105 + TOT21

                TOTgral = TOTneto + TOTiva
            End If
        Next
        txtvtatotcf.Text = TOTcf
        txtvtatotexc.Text = TOTexc
        txtvtatotmono.Text = TOTmono
        txtvtatotri.Text = TOTri

        txtvtatot105.Text = TOT105
        txtvtatot21.Text = TOT21

        txtvtatotneto.Text = TOTneto
        txtvtatotiva.Text = TOTiva

        txtvtatotgral.Text = TOTgral
    End Sub


   

    
    Private Sub dtlibrocomp_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dtlibrocomp.RowsAdded
        SumarTotales()
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click

        Try
            Dim tabItmIVcomp As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim ds As New DatasetRecibos
            Dim lector As System.Data.IDataReader
            Dim sql As New MySql.Data.MySqlClient.MySqlCommand
            Reconectar()
            sql.Connection = conexionPrinc
            sql.CommandText = "SELECT concat('Empresa: ',emp.razon, '\n', 'Domicilio: ',emp.direccion,'\n','C.U.I.T.: ',emp.cuit) as empresadtos, hojacomp from cm_empresas as emp where idempresas = " & DatosEmpresa.IdEmpresa

            sql.CommandType = CommandType.Text
            lector = sql.ExecuteReader
            lector.Read()
            Dim empsel As String = lector("empresadtos").ToString
            Dim perisel As String = cmbperiodocarg.SelectedValue
            Dim hojacomp As Integer = lector("hojacomp")
            Reconectar()
            tabItmIVcomp.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select * from iv_items_compras where periodo=" & IDperiodo, conexionEmp)
            tabItmIVcomp.Fill(ds.Tables("IvaCompraItems"))

            Dim parameters As New List(Of Microsoft.Reporting.WinForms.ReportParameter)()
            parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("empresa", empsel))
            parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("ulthoja", hojacomp))
            parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("periodo", perisel))
            Dim ivshow As New ImprimirIvaCompra
            With ivshow
                .MdiParent = Me.MdiParent
                .rptivacompra.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
                .rptivacompra.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\Reportes\LibroIvaCompraDetalles.rdlc"
                .rptivacompra.LocalReport.DataSources.Clear()
                .rptivacompra.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", ds.Tables("IvaCompraItems")))
                .rptivacompra.LocalReport.SetParameters(parameters)
                .rptivacompra.DocumentMapCollapsed = True
                .rptivacompra.RefreshReport()
                .tipolibro = "compra"
                .hojasant = hojacomp
                .Show()
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtvtanufac_Leave(sender As Object, e As EventArgs) Handles txtvtanufac.Leave
        Dim i As Integer
        Dim ceros As String
        If txtvtanufac.TextLength < 8 Then
            For i = 1 To 8 - txtvtanufac.TextLength
                ceros = ceros & "0"
            Next
            txtvtanufac.Text = ceros & txtvtanufac.Text
        End If
    End Sub

    Private Sub cmbvtafinalizar_Click(sender As Object, e As EventArgs) Handles cmbvtafinalizar.Click
        Try
            Dim fecha As String = Format(dtvtafecha.Value, "yyyy-MM-dd")
            Dim tipocomp As String = cmbvtatipocom.Text
            Dim numfac As String = cmbptoventa.Text & "-" & txtvtanufac.Text
            Dim razon As String = cmbvtarazon.Text.ToUpper
            Dim cuit As String = txtvtacuit.Text
            Dim conIVA As String = cmbvtacond.Text
            Dim neto As String = txtvtaneto.Text
            Dim iva105 As String = txtvtaiva105.Text
            Dim iva21 As String = txtvtaiva21.Text
            Dim otroiva As String = txtvtaotroiva.Text
            Dim total As String = txtvtatot.Text
            Dim observa As String = txtvtaobs.Text
            Dim retIV As String = txtvtaretiv.Text
            Dim retIB As String = txtvtaretib.Text
            Dim retGAN As String = txtvtaretgan.Text
            Dim PTOventa As String = cmbptoventa.Text
            Dim Provincia As Integer = cmbprovincias.SelectedValue
            Dim bienuso As Integer = chkvtabiendeuso.CheckState
            Dim sqlQuery As String

            If tipocomp = "NC" Then
                If neto <> 0 Then neto = "-" & neto
                If iva105 <> 0 Then iva105 = "-" & iva105
                If iva21 <> 0 Then iva21 = "-" & iva21
                If otroiva <> 0 Then otroiva = "-" & otroiva
                If retIV <> 0 Then retIV = "-" & retIV
                If retIB <> 0 Then retIB = "-" & retIB
                If retGAN <> 0 Then retGAN = "-" & retGAN
                If total <> 0 Then total = "-" & total
            End If
            If cmbvtarazon.SelectedValue = 0 And cmbvtarazon.Text <> "" Then

                Reconectar()
                sqlQuery = "insert into iv_clientes(razon, cuit, cond_iva) values(?razon,?cuit,?iva)"
                Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionEmp)
                With comandoadd.Parameters
                    .AddWithValue("?razon", cmbvtarazon.Text.ToUpper)
                    .AddWithValue("?cuit", txtvtacuit.Text.ToUpper)
                    .AddWithValue("?iva", cmbvtacond.SelectedValue)
                End With
                comandoadd.ExecuteNonQuery()
            End If

            Dim lector As System.Data.IDataReader
            Dim sql As New MySql.Data.MySqlClient.MySqlCommand
            sql.Connection = conexionPrinc
            sql.CommandText = "SELECT abrev from cm_condicion_iva where id = " & cmbvtacond.SelectedValue
            sql.CommandType = CommandType.Text
            lector = sql.ExecuteReader
            lector.Read()
            conIVA = lector("abrev").ToString
            If chkvtabiendeuso.CheckState = 1 Then
                observa = "BIEN DE USO"
            End If
            Reconectar()
            sqlQuery = "insert into iv_items_ventas(periodo, fecha,tipocom,nufac,razon,cuit,tipocontr,neto,iva105, iva21,otroiva,total,obs,ret_iva,ret_ib,ret_gan,provincia,actividad,bien_uso) " _
                & "values(?per,?fech,?tcomp,?nfac,?raz,?cuit,?tcontr,?neto,?iva105,?iva21,?otroiva,?tot,?obs,?retiva,?retib,?retgan,?prov,?activ,?bien)"
            Dim additem As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionEmp)
            With additem.Parameters
                .AddWithValue("?per", IDperiodo)
                .AddWithValue("?fech", fecha)
                .AddWithValue("?tcomp", tipocomp)
                .AddWithValue("?nfac", numfac)
                .AddWithValue("?raz", razon)
                .AddWithValue("?cuit", cuit)
                .AddWithValue("?tcontr", conIVA)
                .AddWithValue("?neto", neto)
                .AddWithValue("?iva105", iva105)
                .AddWithValue("?iva21", iva21)
                .AddWithValue("?otroiva", otroiva)
                .AddWithValue("?tot", total)
                .AddWithValue("?obs", observa.ToUpper)
                .AddWithValue("?retiva", retIV)
                .AddWithValue("?retib", retIB)
                .AddWithValue("?retgan", retGAN)
                .AddWithValue("?prov", Provincia)
                .AddWithValue("?activ", cmbActivCliente.SelectedValue)
                .AddWithValue("?bien", bienuso)
            End With
            additem.ExecuteNonQuery()
            dtlibrovent.Rows.Add(fecha, tipocomp, numfac, razon, cuit, conIVA, neto, iva21, iva105, otroiva, retIV, retIB, retGAN, total, observa.ToUpper, additem.LastInsertedId)
            If tipocomp = "NC" Then
                dtlibrovent.Rows(dtlibrovent.RowCount - 1).DefaultCellStyle.BackColor = Color.Red
            End If
            If observa = "BIEN DE USO" Then
                dtlibrovent.Rows(dtlibrovent.RowCount - 1).DefaultCellStyle.BackColor = Color.Green
            End If
            CargarDtosGrales()

            'cargarDtosVtas()

            VaciarControles()
            cmbvtatipocom.SelectedText = tipocomp
            cmbptoventa.SelectedText = PTOventa
            cmbprovincias.SelectedValue = Provincia
            dtvtafecha.Focus()
        Catch ex As Exception
        End Try

    End Sub
    Private Sub dtvtafecha_ValueChanged(sender As Object, e As EventArgs) Handles dtvtafecha.ValueChanged
        SendKeys.Send("/")
    End Sub

    Private Sub dtlibrovent_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dtlibrovent.RowsAdded
        SumarTotalesvtas()
    End Sub

    Private Sub dtlibrovent_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles dtlibrovent.RowsRemoved
        SumarTotalesvtas()
    End Sub

    Private Sub CargarActividadEmp()
        Try
            'cargamos actividades de empresas
            Reconectar()
            Dim arrayactiv() As String = {}
            Dim consulta As New MySql.Data.MySqlClient.MySqlDataAdapter("SELECT activ_emp, provincia, tipo_emp from cm_empresas where idempresas = " & DatosEmpresa.IdEmpresa, conexionPrinc)
            Dim tablacl As New DataTable
            Dim infocl() As DataRow
            consulta.Fill(tablacl)
            infocl = tablacl.Select("")


            Dim i As Integer
            Dim consultaextr As String
            Dim acti As String
            If infocl(0)(2).ToString = "CONVENIO MULTILATERAL" Then
                cmbprovincias.Enabled = True
            End If
            cmbprovincias.SelectedValue = infocl(0)(1)
            If Not IsDBNull(infocl(0)(0)) And infocl(0)(0).ToString <> "" Then
                acti = infocl(0)(0).ToString
                arrayactiv = acti.Split(",")

                For i = 0 To arrayactiv.Length - 1
                    If arrayactiv(i) <> "" Then
                        If i = 0 Then

                            consultaextr = " id=" & arrayactiv(i)
                        Else
                            consultaextr &= " or id=" & arrayactiv(i)
                        End If
                    End If
                Next

                Reconectar()
                Dim tablaActivCliente As New MySql.Data.MySqlClient.MySqlDataAdapter("select id, nombre from cm_actividades_empresas where " & consultaextr, conexionPrinc)
                Dim readActivCliente As New DataSet
                tablaActivCliente.Fill(readActivCliente)
                cmbActivCliente.DataSource = readActivCliente.Tables(0)
                cmbActivCliente.DisplayMember = readActivCliente.Tables(0).Columns(1).Caption.ToString
                cmbActivCliente.ValueMember = readActivCliente.Tables(0).Columns(0).Caption.ToString
                cmbActivCliente.SelectedIndex = -1
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmbperiodo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbperiodo.SelectedValueChanged
        Try
            CargarResumenVtas(Format(dtpderesvta.Value, "yyyy-MM-dd"), Format(dtphastaresvta.Value, "yyyy-MM-dd"), cmbperiodo.SelectedValue)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CargarResumenVtas(ByRef de As String, ByRef hasta As String, ByRef periodo As String)
        Dim consultaext As String
        Dim interc As String = " from " & conexionEmp.Database & ".iv_items_ventas as iv," & conexionPrinc.Database & ".cm_actividades_empresas as ae "
        Dim princ As String = conexionPrinc.Database & ".cm_actividades_empresas"
        Dim prov As String = conexionPrinc.Database & ".cm_provincias"
        Dim emp As String = conexionEmp.Database & ".iv_items_ventas"
        dttotvtaact.Rows.Clear()
        dttotvtaprov.Rows.Clear()
        dttotvtaretprov.Rows.Clear()
        dtvtabienuso.Rows.Clear()
        Try
            Reconectar()
            If periodo > 0 Then
                consultaext = " where periodo=" & periodo
            Else
                consultaext = " where fecha between '" & de & "' and '" & hasta & "' "
            End If

            Dim lector As System.Data.IDataReader
            Dim sql As New MySql.Data.MySqlClient.MySqlCommand
            Dim lector2 As System.Data.IDataReader
            Dim sql2 As New MySql.Data.MySqlClient.MySqlCommand
            Dim ri As Double
            Dim ex As Double
            Dim mon As Double
            Dim cf As Double
            Dim totri As Double
            Dim totex As Double
            Dim totmon As Double
            Dim totcf As Double
            Dim totactagral As Double
            Dim proviva105 As Double
            Dim proviva21 As Double
            Dim totproviva105 As Double
            Dim totproviva21 As Double
            Dim neto As Double
            Dim totneto As Double
            Dim retiva As Double
            Dim retib As Double
            Dim retgan As Double
            Dim totretiva As Double
            Dim totretib As Double
            Dim totretgan As Double

            Dim filas() As DataRow
            Dim filas2() As DataRow
            Dim filas3() As DataRow
            Dim i As Integer

            sql.Connection = conexionPrinc
            sql.CommandText = "SELECT id, nombre FROM " & princ & " where id in (select actividad from " & emp & consultaext & " ) "
            sql.CommandType = CommandType.Text
            sql2.Connection = conexionPrinc
            sql2.CommandText = "SELECT idprovincias, nombre FROM " & prov & " where idprovincias in (select provincia from " & emp & consultaext & " ) "
            sql2.CommandType = CommandType.Text
            Dim tablaActivClienteVAL As New MySql.Data.MySqlClient.MySqlDataAdapter("select  * from iv_items_ventas " & consultaext, conexionEmp)
            Dim tablaac As New DataTable
            tablaActivClienteVAL.Fill(tablaac)
            lector = sql.ExecuteReader
            While lector.Read()
                Dim act As Integer = lector("id").ToString
                Dim nombAct As String = lector("nombre").ToString
                filas = tablaac.Select("actividad=" & act & " and bien_uso=0")
                For i = 0 To filas.GetUpperBound(0)
                    Select Case filas(i)(7)
                        Case "RI"
                            ri += FormatNumber(filas(i)(8), 2)
                        Case "EX"
                            ex += FormatNumber(filas(i)(11), 2)
                        Case "MON"
                            mon += FormatNumber(filas(i)(11), 2)
                        Case "CF"
                            cf += FormatNumber(filas(i)(11), 2)
                    End Select

                Next
                Dim total = FormatNumber(ri + ex + cf + mon, 2)
                dttotvtaact.Rows.Add(nombAct, ri, ex, cf, mon, total)
                totri += FormatNumber(ri, 2)
                totcf += FormatNumber(cf, 2)
                totex += FormatNumber(ex, 2)
                totmon += FormatNumber(mon, 2)

                totactagral = FormatNumber(totri + totcf + totex + totmon, 2)
                ri = 0
                ex = 0
                mon = 0
                cf = 0

            End While
            dttotvtaact.Rows.Add("TOTALES", totri, totex, totcf, totmon, totactagral)
            dttotvtaact.Rows(dttotvtaact.RowCount - 1).DefaultCellStyle.BackColor = Color.Gray

            Reconectar()
            lector2 = sql2.ExecuteReader
            While lector2.Read
                Dim proid As Integer = lector2("idprovincias").ToString
                Dim pronom As String = lector2("nombre").ToString
                filas2 = tablaac.Select("provincia=" & proid & " and bien_uso=0")
                For i = 0 To filas2.GetUpperBound(0)
                    neto += FormatNumber(filas2(i)(8), 2)
                    proviva21 += FormatNumber(filas2(i)(10), 2)
                    proviva105 += FormatNumber(filas2(i)(9), 2)
                    retgan += FormatNumber(filas2(i)(16), 2)
                    retib += FormatNumber(filas2(i)(15), 2)
                    retiva += FormatNumber(filas2(i)(14), 2)
                Next
                dttotvtaprov.Rows.Add(pronom, neto, proviva21, proviva105)
                dttotvtaretprov.Rows.Add(pronom, retib, retiva, retgan)

                totneto += FormatNumber(neto, 2)
                totproviva105 += FormatNumber(proviva105, 2)
                totproviva21 += FormatNumber(proviva21, 2)

                totretgan += FormatNumber(retgan, 2)
                totretib += FormatNumber(retib, 2)
                totretiva += FormatNumber(retiva, 2)
                retgan = 0
                retib = 0
                retiva = 0
                proviva105 = 0
                proviva21 = 0
                neto = 0
            End While

            filas3 = tablaac.Select("bien_uso=1")
            For i = 0 To filas3.GetUpperBound(0)
                Dim iv1 As Double = filas3(i)(9)
                Dim iv2 As Double = filas3(i)(10)
                dtvtabienuso.Rows.Add(filas3(i)(2), filas3(i)(4), filas3(i)(8), iv1 + iv2, filas3(i)(11))
            Next

            dttotvtaretprov.Rows.Add("TOTALES", totretib, totretiva, totretgan)
            dttotvtaprov.Rows.Add("TOTALES", totneto, totproviva21, totproviva105)
            dttotvtaprov.Rows(dttotvtaprov.RowCount - 1).DefaultCellStyle.BackColor = Color.Gray
            dttotvtaretprov.Rows(dttotvtaretprov.RowCount - 1).DefaultCellStyle.BackColor = Color.Gray
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CargarResumenCompras(ByRef de As String, ByRef hasta As String, ByRef periodo As String)
        Dim consultaext As String
        dtcompbienuso.Rows.Clear()
        dtcompnc.Rows.Clear()
        Try
            Reconectar()
            conexionEmp.ChangeDatabase(EmpDB)
            If periodo > 0 Then
                consultaext = " where periodo=" & periodo
            Else
                consultaext = " where fecha between '" & de & "' and '" & hasta & "' "
            End If

            Dim filas() As DataRow
            Dim filas2() As DataRow
            Dim i As Integer

            Dim tablancli As New MySql.Data.MySqlClient.MySqlDataAdapter("select  * from iv_items_compras " & consultaext, conexionEmp)
            Dim tablaac As New DataTable
            tablancli.Fill(tablaac)
            'lector = sql.ExecuteReader

            filas = tablaac.Select("tipocom like 'NC'")
            Dim totncneto As Double
            Dim totnciva As Double
            Dim totnctot As Double
            For i = 0 To filas.GetUpperBound(0)
                totncneto += FormatNumber(Replace(filas(i)(8), "-", ""), 2)
                totnciva += FormatNumber(Replace(filas(i)(9), "-", ""), 2)
                totnctot += FormatNumber(Replace(filas(i)(15), "-", ""), 2)

                dtcompnc.Rows.Add(filas(i)(2), filas(i)(4), Replace(filas(i)(8), "-", ""), Replace(filas(i)(9), "-", ""), Replace(filas(i)(15), "-", ""))
            Next
            dtcompnc.Rows.Add("", "TOTALES", totncneto, totnciva, totnctot)
            dtcompnc.Rows(dtcompnc.RowCount - 1).DefaultCellStyle.BackColor = Color.Gray
            totncneto = 0
            totnciva = 0
            totnctot = 0
            filas2 = tablaac.Select("bien_uso=1")
            For i = 0 To filas2.GetUpperBound(0)
                dtcompbienuso.Rows.Add(filas2(i)(2), filas2(i)(4), filas2(i)(8), filas2(i)(9), filas2(i)(15))
            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If MsgBox("ESTA SEGURO QUE DESEA DECLARAR ESTA FACTURA COMO ANULADA?", vbQuestion + vbYesNo) = vbNo Then
            Exit Sub
        End If
        Try
            Dim fecha As String = Format(dtvtafecha.Value, "yyyy-MM-dd")
            Dim tipocomp As String = cmbvtatipocom.Text
            Dim numfac As String = cmbptoventa.Text & "-" & txtvtanufac.Text
            Dim razon As String = cmbvtarazon.Text.ToUpper
            Dim cuit As String = txtvtacuit.Text
            Dim conIVA As String = cmbvtacond.Text
            Dim neto As String = txtvtaneto.Text
            Dim iva105 As String = txtvtaiva105.Text
            Dim iva21 As String = txtvtaiva21.Text
            Dim total As String = txtvtatot.Text
            Dim observa As String = txtvtaobs.Text
            Dim retIV As String = txtvtaretiv.Text
            Dim retIB As String = txtvtaretib.Text
            Dim retGAN As String = txtvtaretgan.Text
            Dim PTOventa As String = cmbptoventa.Text
            Dim Provincia As Integer = cmbprovincias.SelectedValue
            Dim sqlQuery As String


            If cmbvtarazon.SelectedValue = 0 And cmbvtarazon.Text <> "" Then

                Reconectar()
                sqlQuery = "insert into iv_clientes(razon, cuit, cond_iva) values(?razon,?cuit,?iva)"
                Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionEmp)
                With comandoadd.Parameters
                    .AddWithValue("?razon", cmbvtarazon.Text.ToUpper)
                    .AddWithValue("?cuit", txtvtacuit.Text.ToUpper)
                    .AddWithValue("?iva", cmbvtacond.SelectedValue)
                End With
                comandoadd.ExecuteNonQuery()
            End If


            Reconectar()
            sqlQuery = "insert into iv_items_ventas(periodo, fecha,tipocom,nufac,razon,cuit,tipocontr,neto,iva105, iva21,total,obs,ret_iva,ret_ib,ret_gan,provincia,actividad) " _
                    & "values(?per,?fech,?tcomp,?nfac,?raz,?cuit,?tcontr,?neto,?iva105,?iva21,?tot,?obs,?retiva,?retib,?retgan,?prov,?activ)"
            Dim additem As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionEmp)
            With additem.Parameters
                .AddWithValue("?per", IDperiodo)
                .AddWithValue("?fech", fecha)
                .AddWithValue("?tcomp", tipocomp)
                .AddWithValue("?nfac", numfac)
                .AddWithValue("?raz", "***************** FACTURA ANULADA ****************")
                .AddWithValue("?cuit", "")
                .AddWithValue("?tcontr", "")
                .AddWithValue("?neto", "0")
                .AddWithValue("?iva105", "0")
                .AddWithValue("?iva21", "0")
                .AddWithValue("?tot", "0")
                .AddWithValue("?obs", observa.ToUpper)
                .AddWithValue("?retiva", "0")
                .AddWithValue("?retib", "0")
                .AddWithValue("?retgan", "0")
                .AddWithValue("?prov", cmbprovincias.Text)
                .AddWithValue("?activ", cmbActivCliente.SelectedValue)
            End With
            additem.ExecuteNonQuery()
            dtlibrovent.Rows.Add(fecha, tipocomp, numfac, razon, cuit, conIVA, neto, iva21, iva105, retIV, retIB, retGAN, total, observa.ToUpper)
            CargarDtosGrales()
            VaciarControles()
            cmbvtatipocom.SelectedText = tipocomp
            cmbptoventa.SelectedText = PTOventa
            cmbprovincias.SelectedValue = Provincia
            dtvtafecha.Focus()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dtphastaresvta_ValueChanged(sender As Object, e As EventArgs) Handles dtphastaresvta.ValueChanged
        cmbperiodo.SelectedIndex = -1
        Try
            CargarResumenVtas(Format(dtpderesvta.Value, "yyyy-MM-dd"), Format(dtphastaresvta.Value, "yyyy-MM-dd"), cmbperiodo.SelectedValue)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub dtpderesvta_ValueChanged(sender As Object, e As EventArgs) Handles dtpderesvta.ValueChanged
        cmbperiodo.SelectedIndex = -1
        Try
            CargarResumenVtas(Format(dtpderesvta.Value, "yyyy-MM-dd"), Format(dtphastaresvta.Value, "yyyy-MM-dd"), cmbperiodo.SelectedValue)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbcompperiodo_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbcompperiodo.SelectedValueChanged
        Try
            CargarResumenCompras(Format(dtcompde.Value, "yyyy-MM-dd"), Format(dtcomphasta.Value, "yyyy-MM-dd"), cmbcompperiodo.SelectedValue)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dtcompde_ValueChanged(sender As Object, e As EventArgs) Handles dtcompde.ValueChanged
        Try
            CargarResumenCompras(Format(dtcompde.Value, "yyyy-MM-dd"), Format(dtcomphasta.Value, "yyyy-MM-dd"), cmbcompperiodo.SelectedValue)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dtcomphasta_ValueChanged(sender As Object, e As EventArgs) Handles dtcomphasta.ValueChanged
        Try
            CargarResumenCompras(Format(dtcompde.Value, "yyyy-MM-dd"), Format(dtcomphasta.Value, "yyyy-MM-dd"), cmbcompperiodo.SelectedValue)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        Try
            'Dim tabIVComp As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim tabItmIVcomp As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim tabresivvent As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim ds As New DatasetRecibos
            Dim lector As System.Data.IDataReader
            Dim sql As New MySql.Data.MySqlClient.MySqlCommand
            Reconectar()
            sql.Connection = conexionPrinc
            sql.CommandText = "SELECT concat('Empresa: ',emp.razon, '\n', 'Domicilio: ',emp.direccion,'\n','C.U.I.T.: ',emp.cuit) as empresadtos, hojavent from cm_empresas as emp where idempresas = " & DatosEmpresa.IdEmpresa

            sql.CommandType = CommandType.Text
            lector = sql.ExecuteReader
            lector.Read()
            Dim empsel As String = lector("empresadtos").ToString
            Dim perisel As String = cmbperiodocarg.Text
            Dim hojavent As Integer = lector("hojavent")
            Reconectar()
            tabItmIVcomp.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select * from iv_items_ventas where periodo=" & IDperiodo, conexionEmp)
            tabItmIVcomp.Fill(ds.Tables("IvaVentaItems"))

            Dim parameters As New List(Of Microsoft.Reporting.WinForms.ReportParameter)()
            parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("empresa", empsel))
            parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("ulthoja", hojavent))
            parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("periodo", perisel))
            Dim ivshow As New ImprimirIvaCompra
            With ivshow
                .MdiParent = Me.MdiParent
                .rptivacompra.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
                .rptivacompra.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\Reportes\LibroIvaVentaDetalles.rdlc"
                .rptivacompra.LocalReport.DataSources.Clear()
                .rptivacompra.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", ds.Tables("IvaVentaItems")))
            '    .rptivacompra.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("resumenvtas", ds.Tables("resumenvtas")))
                .rptivacompra.LocalReport.SetParameters(parameters)
                .rptivacompra.DocumentMapCollapsed = True
                .rptivacompra.RefreshReport()
                .tipolibro = "venta"
                .hojasant = hojavent
                .Show()
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dtlibrocomp_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles dtlibrocomp.UserDeletingRow
        Try
            If MsgBox("Esta seguro que desea eliminar esta factura?", vbQuestion, vbYesNo) = vbYesNo Then
                Exit Sub
            End If
            Reconectar()
            Dim sqlQuery As String
            conexionEmp.ChangeDatabase(EmpDB)
            sqlQuery = "delete from iv_items_compras where id= " & dtlibrocomp.CurrentRow.Cells(17).Value
            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionEmp)
            comandoadd.BeginExecuteReader()
            SumarTotales()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub dtlibrovent_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles dtlibrovent.UserDeletingRow
        Try
            If MsgBox("Esta seguro que desea eliminar esta factura?", vbQuestion, vbYesNo) = vbYesNo Then
                Exit Sub
            End If
            Dim sqlQuery As String
            conexionEmp.ChangeDatabase(EmpDB)
            sqlQuery = "delete from iv_items_ventas where id= " & dtlibrovent.CurrentRow.Cells(15).Value
            Dim comandoadd As New MySql.Data.MySqlClient.MySqlCommand(sqlQuery, conexionEmp)
            comandoadd.BeginExecuteReader()

            SumarTotales()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmdcerrarPer_Click(sender As Object, e As EventArgs)
        rubricaivacompra.Show()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs)
        rubricaivaventas.Show()
    End Sub

    Private Sub cmbActivCliente_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbActivCliente.SelectionChangeCommitted
        Try
            If cmbActivCliente.SelectedIndex > -1 Then
                Reconectar()
                Dim lector As System.Data.IDataReader
                Dim sql As New MySql.Data.MySqlClient.MySqlCommand
                sql.Connection = conexionPrinc
                sql.CommandText = "SELECT alicuota from cm_actividades_empresas where id = " & cmbActivCliente.SelectedValue
                sql.CommandType = CommandType.Text
                lector = sql.ExecuteReader
                lector.Read()
                AlicuotaACT = FormatNumber(lector("alicuota").ToString, 2)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmbvtarazon_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbvtarazon.Validating
        Try
            Reconectar()
            Dim lector As System.Data.IDataReader
            Dim sql As New MySql.Data.MySqlClient.MySqlCommand
            If cmbvtarazon.SelectedValue > 0 Then
                sql.Connection = conexionEmp
                sql.CommandText = "SELECT cuit, cond_iva from iv_clientes where id = " & cmbvtarazon.SelectedValue
                sql.CommandType = CommandType.Text
                lector = sql.ExecuteReader
                lector.Read()

                txtvtacuit.Text = lector("cuit").ToString
                cmbvtacond.SelectedValue = lector("cond_iva").ToString
            Else
                txtvtacuit.Text = ""
                cmbvtacond.SelectedValue = 0
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbrazonComp_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cmbrazonComp.Validating
        Try
            Reconectar()
            Dim lector As System.Data.IDataReader
            Dim sql As New MySql.Data.MySqlClient.MySqlCommand
            If cmbrazonComp.SelectedValue > 0 Then
                sql.Connection = conexionEmp
                sql.CommandText = "SELECT cuit, cond_iva from iv_proveedores where id = " & cmbrazonComp.SelectedValue

                sql.CommandType = CommandType.Text
                lector = sql.ExecuteReader
                lector.Read()

                txtcuitComp.Text = lector("cuit").ToString
                cmbcondivaComp.SelectedValue = lector("cond_iva").ToString
            Else
                txtcuitComp.Text = ""
                cmbcondivaComp.SelectedValue = 0
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtvtaneto_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtvtaneto.Validating
        Try
            Dim iva105 As Double
            Dim iva21 As Double
            Dim neto As Double
            Dim total As Double

            If cmbActivCliente.SelectedValue <= 0 Then
                MsgBox("Seleccione actividad primero")
                Exit Sub

            End If

            If chkventasnocalcular.Checked = False Then
                If cmbvtacond.SelectedValue = 1 And cmbvtatipocom.SelectedValue <> 12 Then
                    Select Case AlicuotaACT
                        Case "21"
                            neto = FormatNumber(txtvtaneto.Text)
                            iva21 = FormatNumber((AlicuotaACT + 100) / 100)
                            total = neto * iva21
                            txtvtaiva21.Text = FormatNumber(total - neto, 2)
                            txtvtatot.Text = FormatNumber(total, 2)
                        Case "10,5"
                            neto = FormatNumber(txtvtaneto.Text)
                            iva105 = FormatNumber((AlicuotaACT + 100) / 100)
                            total = neto * iva105
                            txtvtaiva105.Text = FormatNumber(total - neto, 2)
                            txtvtatot.Text = FormatNumber(total, 2)
                    End Select
                Else
                    Select Case AlicuotaACT
                        Case "21"
                            iva21 = FormatNumber((AlicuotaACT + 100) / 100)
                            neto = FormatNumber(txtvtaneto.Text) / iva21
                            total = neto * iva21
                            txtvtaneto.Text = FormatNumber(neto)
                            txtvtaiva21.Text = FormatNumber(total - neto, 2)
                            txtvtatot.Text = FormatNumber(total, 2)
                        Case "10,5"
                            neto = FormatNumber(txtvtaneto.Text)
                            iva105 = FormatNumber((AlicuotaACT + 100) / 100)
                            total = neto * iva105
                            txtvtaneto.Text = FormatNumber(neto)
                            txtvtaiva105.Text = FormatNumber(total - neto, 2)
                            txtvtatot.Text = FormatNumber(total, 2)
                    End Select
                End If
            End If
            'SumarVentas()
            'txtvtaiva21.Focus()
            'txtvtaiva21.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub txtvtaiva21_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtvtaiva21.Validating
        SumarVentas()
    End Sub

    Private Sub txtvtaiva105_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtvtaiva105.Validating
        SumarVentas()
    End Sub

    Private Sub txtperibComp_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtperibComp.Validating
        If txtperibComp.Text = "" Then txtperibComp.Text = 0
        Sumar()
    End Sub

    Private Sub txtnetoComp_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtnetoComp.Validating
        If txtnetoComp.Text = "" Then txtnetoComp.Text = 0
        Sumar()
    End Sub


    Private Sub txtpercivComp_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtpercivComp.Validating
        If txtpercivComp.Text = "" Then txtpercivComp.Text = 0
        Sumar()
    End Sub

    Private Sub txtivamontoComp_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtivamontoComp.Validating
        If txtivamontoComp.Text = "" Then txtivamontoComp.Text = 0
        Sumar()
    End Sub

    Private Sub txtmontmonotComp_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtmontmonotComp.Validating
        If txtmontmonotComp.Text = "" Then txtmontmonotComp.Text = 0
        Sumar()
    End Sub

    Private Sub txtpagoacuentaComp_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtpagoacuentaComp.Validating
        If txtpagoacuentaComp.Text = "" Then txtpagoacuentaComp.Text = 0
        Sumar()
    End Sub

    Private Sub txtnogrComp_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtnogrComp.Validating
        If txtnogrComp.Text = "" Then txtnogrComp.Text = 0
        Sumar()
    End Sub

    Private Sub txtnetocom105_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtnetocom105.Validating
        If txtnetocom105.Text = "" Then txtnetocom105.Text = 0
        Sumar()
    End Sub

    Private Sub txtnetocom27_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtnetocom27.Validating
        If txtnetocom27.Text = "" Then txtnetocom27.Text = 0
        Sumar()
    End Sub

    Private Sub txtfaciz_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtfaciz.Validating
        Dim i As Integer
        Dim ceros As String
        If txtfaciz.TextLength < 4 Then
            For i = 1 To 4 - txtfaciz.TextLength
                ceros = ceros & "0"
            Next
            txtfaciz.Text = ceros & txtfaciz.Text
        End If
    End Sub

    Private Sub txtfacder_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtfacder.Validating
        Dim i As Integer
        Dim ceros As String
        If txtfacder.TextLength < 8 Then
            For i = 1 To 8 - txtfacder.TextLength
                ceros = ceros & "0"
            Next
            txtfacder.Text = ceros & txtfacder.Text
        End If
    End Sub

    Private Sub txtvtaretiv_Validated(sender As Object, e As EventArgs) Handles txtvtaretiv.Validated
        SumarVentas()

    End Sub

    Private Sub txtvtaretib_Validated(sender As Object, e As EventArgs) Handles txtvtaretib.Validated
        SumarVentas()

    End Sub

    Private Sub txtvtaretgan_Validated(sender As Object, e As EventArgs) Handles txtvtaretgan.Validated
        SumarVentas()

    End Sub


    'Private Sub dtperiodos_UserDeletingRow(sender As Object, e As DataGridViewRowCancelEventArgs) Handles dtperiodos.UserDeletingRow
    '    Try
    '        'If e.KeyCode = Keys.Delete Then
    '        If MsgBox("esta seguro que desea eliminar el periodo completo y todo su contenido?", vbQuestion + vbYesNo) = vbNo Then
    '            e.Cancel = True
    '            Exit Sub
    '        End If
    '        Dim delcompras As String = "delete from iv_items_compras where periodo =" & cmbperiodocarg.SelectedValue
    '        Dim delventas As String = "delete from iv_items_ventas where periodo =" & cmbperiodocarg.SelectedValue
    '        Dim delper As String = "delete from iv_periodos where id=" & cmbperiodocarg.SelectedValue

    '        Reconectar()
    '        Dim comandodelcomp As New MySql.Data.MySqlClient.MySqlCommand(delcompras, conexionEmp)
    '        comandodelcomp.ExecuteNonQuery()
    '        Reconectar()
    '        Dim comandodelvent As New MySql.Data.MySqlClient.MySqlCommand(delcompras, conexionEmp)
    '        comandodelvent.ExecuteNonQuery()
    '        Reconectar()
    '        Dim comandodelper As New MySql.Data.MySqlClient.MySqlCommand(delcompras, conexionEmp)
    '        comandodelper.ExecuteNonQuery()

    '        'End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    Private Sub txtvtaotroiva_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtvtaotroiva.Validating
        SumarVentas()
    End Sub
    Private Sub cmbperiodocarg_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbperiodocarg.SelectionChangeCommitted
        Try
            IDperiodo = cmbperiodocarg.SelectedValue
            'estadoPer = dtperiodos.CurrentRow.Cells.Item(2).Value

            CargarComprasPeriodo()
            CargarVentasPeriodo()
            CargarActividadEmp()
            TabControl1.Enabled = True
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button7_Click_1(sender As Object, e As EventArgs) Handles Button7.Click
        'Dim fmt8 As String = String.Format("{0:00000000}")
        'Dim fmt20 As String = String.Format("{0:000000000000000000000}")
        Dim Comprobantes As String
        Dim Alicuotas As String
        Try
            If MsgBox("Esta seguro que desea exportar a CITI?", vbQuestion, vbYesNo) = vbYesNo Then
                Exit Sub
            End If
            For Each registro As DataGridViewRow In dtlibrovent.Rows
                Dim fcomp As String = Format(CDate(registro.Cells(0).Value), "yyyyMMdd") 'fecha del comprobante
                Dim codigoComp As String = ObternerCodigoComp(registro.Cells(1).Value) 'Tipo de comprobante
                Dim ptovta As String = Strings.Mid(registro.Cells(2).Value.ToString, 1, InStr(registro.Cells(2).Value, "-") - 1).PadLeft(5, "0") 'punto de venta

                Dim numcbte As String = Strings.Right(registro.Cells(2).Value.ToString, 8).PadLeft(20, "0") 'numero de comprobante
                Dim numcbtehasta As String = numcbte  'numero de comprobante hasta
                Dim codigodoc As String = obtenerCodigoDoc(registro.Cells(5).Value.ToString)
                Dim numidentCUIT As String = Replace(registro.Cells(4).Value.ToString, "-", "").PadLeft(20, "0")
                Dim razonsocial As String = registro.Cells(3).Value.ToString
                If razonsocial.Length > 30 Then razonsocial = razonsocial.Substring(0, 30)
                If razonsocial.Length < 30 Then razonsocial = razonsocial.PadRight(30)

                Dim formatoImporte As String = Replace(FormatNumber(registro.Cells(13).Value, 2), ",", "")
                formatoImporte = Replace(formatoImporte, ".", "")
                formatoImporte = Replace(formatoImporte, "-", "")
                Dim imptotal As String = formatoImporte.PadLeft(15, "0") 'impote total de la operacion

                Dim nogr As String = "000000000000000"
                Dim pernocateg As String = "000000000000000"
                Dim operexen As String = "000000000000000"
                Dim pagocta As String = "000000000000000"
                Dim perIIBB As String = "000000000000000"
                Dim impmuni As String = "000000000000000"
                Dim impint As String = "000000000000000"
                Dim moneda As String = "PES"
                Dim cambio As String = "0001000000"
                Dim cantali As Integer = 0
                Dim neto105 As String
                Dim liq105 As String
                Dim neto21 As String
                Dim liq21 As String
                Dim codigoali As String
                If registro.Cells(7).Value <> 0 And registro.Cells(8).Value = 0 Then
                    cantali = 1
                    neto21 = FormatNumber(registro.Cells(7).Value / 0.21, 2)
                    neto21 = Replace(neto21, ",", "")
                    neto21 = Replace(neto21, ".", "")
                    neto21 = Replace(neto21, "-", "")
                    neto21 = neto21.PadLeft(15, "0")

                    liq21 = Replace(FormatNumber(registro.Cells(7).Value, 2), ",", "")
                    liq21 = Replace(liq21, ".", "")
                    liq21 = Replace(liq21, "-", "")
                    liq21 = liq21.PadLeft(15, "0")

                    codigoali = "0005"

                    Alicuotas &= codigoComp & ptovta & numcbte & neto21 & codigoali & liq21 & vbNewLine

                ElseIf registro.Cells(7).Value = 0 And registro.Cells(8).Value <> 0 Then
                    cantali = 1
                    neto105 = FormatNumber(registro.Cells(8).Value / 0.105, 2)
                    neto105 = Replace(neto105, ",", "")
                    neto105 = Replace(neto105, ".", "")
                    neto105 = Replace(neto105, "-", "")
                    neto105 = neto105.PadLeft(15, "0")

                    liq105 = Replace(FormatNumber(registro.Cells(8).Value, 2), ",", "")
                    liq105 = Replace(liq105, ".", "")
                    liq105 = Replace(liq105, "-", "")
                    liq105 = liq105.PadLeft(15, "0")

                    codigoali = "0004"

                    Alicuotas &= codigoComp & ptovta & numcbte & neto105 & codigoali & liq105 & vbNewLine


                ElseIf registro.Cells(7).Value <> 0 And registro.Cells(8).Value <> 0 Then
                    cantali = 2

                    neto105 = FormatNumber(registro.Cells(8).Value / 0.105, 2)
                    neto105 = Replace(neto105, ",", "")
                    neto105 = Replace(neto105, ".", "")
                    neto105 = Replace(neto105, "-", "")
                    neto105 = neto105.PadLeft(15, "0")

                    liq105 = Replace(registro.Cells(8).Value, ",", "")
                    liq105 = Replace(liq105, ".", "")
                    liq105 = Replace(liq105, "-", "")
                    liq105 = liq105.PadLeft(15, "0")


                    codigoali = "0004"

                    Alicuotas &= codigoComp & ptovta & numcbte & neto105 & codigoali & liq105 & vbNewLine

                    neto21 = FormatNumber(registro.Cells(7).Value / 0.21, 2)
                    neto21 = Replace(neto21, ",", "")
                    neto21 = Replace(neto21, ".", "")
                    neto21 = Replace(neto21, "-", "")
                    neto21 = neto21.PadLeft(15, "0")

                    liq21 = Replace(FormatNumber(registro.Cells(7).Value, 2), ",", "")
                    liq21 = Replace(liq21, ".", "")
                    liq21 = Replace(liq21, "-", "")
                    liq21 = liq21.PadLeft(15, "0")

                    codigoali = "0005"

                    Alicuotas &= codigoComp & ptovta & numcbte & neto21 & codigoali & liq21 & vbNewLine

                End If
                Dim codoper As String = "0"
                Dim otrotrib As String = "000000000000000"
                Dim vtopago As String = "00000000"

                Comprobantes &= fcomp & codigoComp & ptovta & numcbte & numcbtehasta & codigodoc & numidentCUIT & razonsocial & imptotal & nogr & pernocateg & operexen & pagocta _
                & perIIBB & impmuni & impint & moneda & cambio & cantali & codoper & otrotrib & vtopago & vbNewLine
            Next


            carpetadestino.ShowDialog()
            'Dim carpeta As New IO.DirectoryInfo(carpetadestino.SelectedPath)
            Dim nombrecomprobantes = carpetadestino.SelectedPath & "\" & Replace(cmbperiodocarg.Text, "/", "") & "_VENTAScomprobantes_" & EmpDB.ToString & ".txt"
            Dim nombrealicutas = carpetadestino.SelectedPath & "\" & Replace(cmbperiodocarg.Text, "/", "") & "_VENTASalicuotas_" & EmpDB.ToString & ".txt"
            Dim strStreamW As Stream = Nothing
            Dim strStreamWriter As StreamWriter = Nothing
            Windows.Forms.Cursor.Current = Cursors.WaitCursor

            If File.Exists(nombrecomprobantes) Then
                strStreamW = File.Open(nombrecomprobantes, FileMode.Open)
            Else
                strStreamW = File.Create(nombrecomprobantes)
            End If
            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default)
            strStreamWriter.Write(Comprobantes)
            strStreamWriter.Close()
            MsgBox("archivo de comprobantes generado")

            If File.Exists(nombrealicutas) Then
                strStreamW = File.Open(nombrealicutas, FileMode.Open)
            Else
                strStreamW = File.Create(nombrealicutas)
            End If
            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default)
            strStreamWriter.Write(Alicuotas)
            strStreamWriter.Close()
            MsgBox("archivo de alicuotas generado")


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Function obtenerCodigoDoc(ByRef tipContr As String) As String
        If tipContr = "RI" Or tipContr = "MON" Or tipContr = "EX" Then
            Return 80
        Else
            Return 96

        End If
    End Function

    Private Function ObternerCodigoComp(ByRef tipoComp) As String
        If tipoComp = "FA" Then Return "001"
        If tipoComp = "ND" Then Return "002"
        If tipoComp = "NC" Then Return "003"
        If tipoComp = "FB" Then Return "006"
        If tipoComp = "FC" Then Return "011"
    End Function

    Private Function ObtenerCodigoAlicuota(ByRef tipoAlic As String) As String
        If tipoAlic = "21" Then Return "0005"
        If tipoAlic = "10.5" Then Return "0004"
        If tipoAlic = "27" Then Return "0006"
    End Function

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        'Dim fmt8 As String = String.Format("{0:00000000}")
        'Dim fmt20 As String = String.Format("{0:000000000000000000000}")
        Dim Comprobantes As String
        Dim Alicuotas As String
        Try
            If MsgBox("Esta seguro que desea exportar a CITI?", vbQuestion, vbYesNo) = vbYesNo Then
                Exit Sub
            End If
            For Each registro As DataGridViewRow In dtlibrocomp.Rows
                Dim fcomp As String = Format(CDate(registro.Cells(0).Value), "yyyyMMdd") 'fecha del comprobante
                Dim codigoComp As String = ObternerCodigoComp(registro.Cells(1).Value) 'codigo de comprobante
                Dim ptovta As String = Strings.Left(registro.Cells(2).Value.ToString, 4) 'punto de venta
                ptovta = ptovta.PadLeft(5, "0")

                Dim numcbte As String = Strings.Right(registro.Cells(2).Value.ToString, 8) 'numero de comprobante
                numcbte = numcbte.PadLeft(20, "0")

                Dim despIMp As String = " " 'Despacho de importacion
                despIMp = despIMp.PadRight(16, " ")
                Dim codigodoc As String = obtenerCodigoDoc(registro.Cells(5).Value.ToString) 'codigo documento ri / exc

                Dim numidentCUIT As String = registro.Cells(4).Value.ToString
                numidentCUIT = Replace(registro.Cells(4).Value.ToString, "-", "")
                'numidentCUIT = String.Format("{0:00000000000000000000}", numidentCUIT) 'cuit
                numidentCUIT = numidentCUIT.PadLeft(20, "0")

                Dim razonsocial As String = registro.Cells(3).Value.ToString 'razon social
                If razonsocial.Length > 30 Then razonsocial = razonsocial.Substring(0, 30)
                If razonsocial.Length < 30 Then razonsocial = razonsocial.PadRight(30)

                Dim formatoImporte As String = Replace(FormatNumber(registro.Cells(15).Value, 2), ",", "")
                formatoImporte = Replace(formatoImporte, ".", "")
                formatoImporte = Replace(formatoImporte, "-", "")
                Dim imptotal As String = formatoImporte.PadLeft(15, "0") 'impote total de la operacion

                Dim formatonogr As String = Replace(FormatNumber(registro.Cells(12).Value, 2), ",", "")
                formatonogr = Replace(formatonogr, ".", "")
                formatonogr = Replace(formatonogr, "-", "")
                Dim nogr As String = formatonogr.PadLeft(15, "0") 'impote no gravado

                Dim operexen As String = "000000000000000" 'importe excento

                Dim formatopagocta As Double = FormatNumber(registro.Cells(11).Value, 2)
                Dim formatoperiva As Double = FormatNumber(registro.Cells(13).Value, 2)
                Dim pagoctaIVA As String = Replace(FormatNumber(formatopagocta + formatoperiva, 2), ",", "")
                pagoctaIVA = Replace(pagoctaIVA, ".", "")
                pagoctaIVA = Replace(pagoctaIVA, "-", "")
                'formatopagocta = Replace(FormatNumber(, ",", "")
                'formatopagocta = Replace(formatopagocta, ".", "")
                'formatopagocta = Replace(formatopagocta, "-", "")

                pagoctaIVA = pagoctaIVA.PadLeft(15, "0") 'pagos a cuenta iva y percepciones

                Dim pagoctaNAC As String = "000000000000000" 'pago cuenta nacionales

                Dim formatoperIIBB As String = Replace(FormatNumber(registro.Cells(14).Value, 2), ",", "")
                formatoperIIBB = Replace(formatoperIIBB, ".", "")
                formatoperIIBB = Replace(formatoperIIBB, "-", "")
                Dim perIIBB As String = formatoperIIBB.PadLeft(15, "0") 'percepcion IIBB

                Dim impmuni As String = "000000000000000" 'precepc imp munic
                Dim impint As String = "000000000000000" ' impuestos internos
                Dim moneda As String = "PES" 'moneda
                Dim cambio As String = "0001000000" 'cambio

                Dim i As Integer
                Dim cantali As Integer = 0 'CALCULAMOS LA CANTIDAD DE ALICUOTAS QUE TIENE EL COMPROBANTE

                Dim CodOper = "0" 'codigo de operacion
                Dim CredFis As String = Replace(FormatNumber(registro.Cells(9).Value, 2), ",", "") 'credito fiscal (iva)
                CredFis = Replace(CredFis, ".", "")
                CredFis = Replace(CredFis, "-", "")
                CredFis = CredFis.PadLeft(15, "0")

                Dim otrotrib As String = "000000000000000"
                Dim cuitemicore As String = "00000000000"
                Dim denoemicore As String = ""
                denoemicore = denoemicore.PadRight(30, " ")
                Dim ivacomi As String = "000000000000000"

                'fin de la emision de comprobantes

                'inicio del calculo de alicuotas

                Dim neto105 As String
                Dim liq105 As String

                Dim neto21 As String
                Dim liq21 As String

                Dim neto27 As String
                Dim liq27 As String

                Dim codigoali As String


                For i = 6 To 8
                    If registro.Cells(i).Value <> 0 Then
                        cantali += 1
                        'MsgBox(registro.HeaderCell.ToolTipText)}
                        If i = 6 Then codigoali = "0005"
                        If i = 7 Then codigoali = "0004"
                        If i = 8 Then codigoali = "0006"
                        'MsgBox(codigoali)
                        If codigoali = "0004" Then
                            ' MsgBox(codigoali)
                            neto105 = FormatNumber(registro.Cells(i).Value, 2)
                            neto105 = Replace(neto105, ",", "")
                            neto105 = Replace(neto105, ".", "")
                            neto105 = Replace(neto105, "-", "")
                            neto105 = neto105.PadLeft(15, "0")

                            liq105 = Replace(FormatNumber(registro.Cells(i).Value * 0.105, 2), ",", "")
                            liq105 = Replace(liq105, ".", "")
                            liq105 = Replace(liq105, "-", "")
                            liq105 = liq105.PadLeft(15, "0")
                            Alicuotas &= codigoComp & ptovta & numcbte & codigodoc & numidentCUIT & neto105 & codigoali & liq105 & vbNewLine
                        ElseIf codigoali = "0005" Then
                            'MsgBox(codigoali)
                            neto21 = FormatNumber(registro.Cells(i).Value, 2)
                            neto21 = Replace(neto21, ",", "")
                            neto21 = Replace(neto21, ".", "")
                            neto21 = Replace(neto21, "-", "")
                            neto21 = neto21.PadLeft(15, "0")

                            liq21 = Replace(FormatNumber(registro.Cells(i).Value * 0.21, 2), ",", "")
                            liq21 = Replace(liq21, ".", "")
                            liq21 = Replace(liq21, "-", "")
                            liq21 = liq21.PadLeft(15, "0")

                            Alicuotas &= codigoComp & ptovta & numcbte & codigodoc & numidentCUIT & neto21 & codigoali & liq21 & vbNewLine
                        ElseIf codigoali = "0006" Then
                            'MsgBox(codigoali)
                            neto27 = FormatNumber(registro.Cells(i).Value, 2)
                            neto27 = Replace(neto27, ",", "")
                            neto27 = Replace(neto27, ".", "")
                            neto27 = Replace(neto27, "-", "")
                            neto27 = neto27.PadLeft(15, "0")

                            liq27 = Replace(FormatNumber(registro.Cells(i).Value * 0.27, 2), ",", "")
                            liq27 = Replace(liq27, ".", "")
                            liq27 = Replace(liq27, "-", "")
                            liq27 = liq27.PadLeft(15, "0")
                            Alicuotas &= codigoComp & ptovta & numcbte & codigodoc & numidentCUIT & neto27 & codigoali & liq27 & vbNewLine
                        End If
                    End If
                Next

                Comprobantes &= fcomp & codigoComp & ptovta & numcbte & despIMp & codigodoc & numidentCUIT & razonsocial _
                & imptotal & nogr & operexen & pagoctaIVA & pagoctaNAC & perIIBB & impmuni & impint & moneda & cambio _
                & cantali & CodOper & CredFis & otrotrib & cuitemicore & denoemicore & ivacomi & vbNewLine
            Next


            carpetadestino.ShowDialog()
            'Dim carpeta As New IO.DirectoryInfo(carpetadestino.SelectedPath)
            Dim nombrecomprobantes = carpetadestino.SelectedPath & "\" & Replace(cmbperiodocarg.Text, "/", "") & "_COMPRAScomprobantes_" & EmpDB.ToString & ".txt"
            Dim nombrealicutas = carpetadestino.SelectedPath & "\" & Replace(cmbperiodocarg.Text, "/", "") & "_COMPRASalicuotas_" & EmpDB.ToString & ".txt"
            Dim strStreamW As Stream = Nothing
            Dim strStreamWriter As StreamWriter = Nothing
            Windows.Forms.Cursor.Current = Cursors.WaitCursor

            If File.Exists(nombrecomprobantes) Then
                strStreamW = File.Open(nombrecomprobantes, FileMode.Open)
            Else
                strStreamW = File.Create(nombrecomprobantes)
            End If
            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default)
            strStreamWriter.Write(Comprobantes)
            strStreamWriter.Close()
            MsgBox("archivo de comprobantes generado")

            If File.Exists(nombrealicutas) Then
                strStreamW = File.Open(nombrealicutas, FileMode.Open)
            Else
                strStreamW = File.Create(nombrealicutas)
            End If
            strStreamWriter = New StreamWriter(strStreamW, System.Text.Encoding.Default)
            strStreamWriter.Write(Alicuotas)
            strStreamWriter.Close()
            MsgBox("archivo de alicuotas generado")


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

   
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Try
            Dim tabItmIVcomp As New MySql.Data.MySqlClient.MySqlDataAdapter
            Dim ds As New DatasetRecibos
            Dim lector As System.Data.IDataReader
            Dim sql As New MySql.Data.MySqlClient.MySqlCommand
            Reconectar()
            sql.Connection = conexionPrinc
            sql.CommandText = "SELECT concat('Empresa: ',emp.razon, '\n', 'Domicilio: ',emp.direccion,'\n','C.U.I.T.: ',emp.cuit) as empresadtos, hojacomp from cm_empresas as emp where idempresas = " & DatosEmpresa.IdEmpresa

            sql.CommandType = CommandType.Text
            lector = sql.ExecuteReader
            lector.Read()
            Dim empsel As String = lector("empresadtos").ToString
            Dim perisel As String = cmbperiodocarg.Text
            Dim hojacomp As Integer = lector("hojacomp")
            Reconectar()
            tabItmIVcomp.SelectCommand = New MySql.Data.MySqlClient.MySqlCommand("select * from iv_items_compras where periodo=" & IDperiodo, conexionEmp)
            tabItmIVcomp.Fill(ds.Tables("IvaCompraItems"))

            Dim parameters As New List(Of Microsoft.Reporting.WinForms.ReportParameter)()
            parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("empresa", empsel))
            parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("ulthoja", hojacomp))
            parameters.Add(New Microsoft.Reporting.WinForms.ReportParameter("periodo", perisel))
            Dim ivshow As New ImprimirIvaCompra
            With ivshow
                .MdiParent = Me.MdiParent
                .rptivacompra.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
                .rptivacompra.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\Reportes\LibroIvaCompraDetalles.rdlc"
                .rptivacompra.LocalReport.DataSources.Clear()
                .rptivacompra.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", ds.Tables("IvaCompraItems")))
                .rptivacompra.LocalReport.SetParameters(parameters)
                .rptivacompra.DocumentMapCollapsed = True
                .rptivacompra.RefreshReport()
                .tipolibro = "compra"
                .hojasant = hojacomp
                .Show()
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdalicalcular_Click(sender As Object, e As EventArgs) Handles cmdalicalcular.Click
        grpali.Visible = False
        txtvtaretiv.Focus()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        grpali.Visible = True
        txtalineto105.Focus()

    End Sub

    Private Sub txtalineto105_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtalineto105.Validating

        Dim iva105 As Double
        'Dim iva21 As Double
        Dim neto As Double
        Dim total As Double

        neto = FormatNumber(txtalineto105.Text)
        'iva105 = FormatNumber((AlicuotaACT + 100) / 100)
        total = neto * 1.105
        txtvtaiva105.Text = FormatNumber(total - neto, 2)
        txtvtatot.Text = FormatNumber(total, 2)
        txtvtaneto.Text = FormatNumber(CDec(txtalineto105.Text) + CDec(txtalineto21.Text), 2)
    End Sub
    Private Sub txtalineto21_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtalineto21.Validating
        'Dim iva105 As Double
        'Dim iva21 As Double
        Dim neto As Double
        Dim total As Double

        neto = FormatNumber(txtalineto21.Text)
        'iva105 = FormatNumber((AlicuotaACT + 100) / 100)
        total = neto * 1.21
        txtvtaiva21.Text = FormatNumber(total - neto, 2)
        txtvtatot.Text = FormatNumber(total, 2)
        txtvtaneto.Text = FormatNumber(CDec(txtalineto105.Text) + CDec(txtalineto21.Text), 2)
    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub cmbcondivaComp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbcondivaComp.SelectedIndexChanged

    End Sub

    Private Sub cmbrazonComp_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbrazonComp.SelectedIndexChanged

    End Sub

    Private Sub txtfaciz_TextChanged(sender As Object, e As EventArgs) Handles txtfaciz.TextChanged

    End Sub

    Private Sub txtnetoComp_TextChanged(sender As Object, e As EventArgs) Handles txtnetoComp.TextChanged

    End Sub

    Private Sub txtivamontoComp_TextChanged(sender As Object, e As EventArgs) Handles txtivamontoComp.TextChanged

    End Sub

    Private Sub txtnogrComp_TextChanged(sender As Object, e As EventArgs) Handles txtnogrComp.TextChanged

    End Sub

    Private Sub cmbperiodocarg_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbperiodocarg.SelectedIndexChanged

    End Sub
End Class