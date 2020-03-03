
Public Class frmInicializar
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'cargo los datos guardados del conexion
        txtServidor.Text = My.Settings.servidor
        txtPuerto.Text = My.Settings.puerto
        txtBaseDatos.Text = My.Settings.bd
        txtUsuario.Text = My.Settings.usuario
        lblEstado.TextAlign = ContentAlignment.MiddleCenter
        Me.AcceptButton = cmdAceptar
        If My.Settings.servidor <> "" Then
            chkGuardarDatos.Checked = True
            txtContraseña.Focus()
        Else
            chkGuardarDatos.Checked = False
        End If
    End Sub

    Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
        'guardo los datos de conexion en el caso de que hayan tildado la opcion
        pbprogresocons.Visible = True
        Try

        
        If chkGuardarDatos.Checked = True Then
            My.Settings.servidor = txtServidor.Text
            My.Settings.puerto = txtPuerto.Text
            My.Settings.bd = txtBaseDatos.Text
            My.Settings.usuario = txtUsuario.Text
            My.Settings.Save()
            My.Settings.Reload()
        Else
            My.Settings.servidor = ""
            My.Settings.puerto = ""
            My.Settings.bd = ""
            My.Settings.usuario = ""
            My.Settings.Save()
            My.Settings.Reload()
        End If
        serv = txtServidor.Text
        port = txtPuerto.Text
        user = txtUsuario.Text
        database = txtBaseDatos.Text
        pass = txtContraseña.Text
        If serv = "" Or port = "" Or user = "" Or database = "" Or pass = "" Then
            lblEstado.Text = "Datos incorrectos o faltantes"
            Exit Sub
        End If
        'compruebo la conexion
        If conectar(txtServidor.Text, txtPuerto.Text, txtUsuario.Text, txtContraseña.Text, txtBaseDatos.Text) = True Then
            lblEstado.Text = "Conectado"
            'abro el formulario principal
            'compruebo que la base de datos principal exista
            If comprobar_base_de_datos_principal() = True Then
                'compruebo que las tablas de la base de datos principal esten correctas
                    If comprobar_tablas_princ() = True Then
                        frmprincipal.Show()
                        Me.Close()
                    Else
                        lblEstado.Text = "error en las tablas"
                    End If
                Else
                    lblEstado.Text = "error en la base de datos principal"
                End If

                Else
                    'en el caso de que no pueda conectar muestro una advertencia
                    lblEstado.Text = "No se pudo conectar al servidor"
                End If
            pbprogresocons.Visible = False
        Catch ex As Exception
            pbprogresocons.Visible = False
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        End
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        grserver.Visible = False
        grusuario.Visible = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        grserver.Visible = True
        grusuario.Visible = False
    End Sub

    Private Sub frmInicializar_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Dim keyCTRL As Boolean
        Dim keyALT As Boolean
        Dim keyF As Boolean
        Try
            If e.Control And e.Alt And e.KeyCode = Keys.N Then
                frmInicializar2.Visible = True
                Me.Visible = False
                Show(frmInicializar2)
                Me.Close()
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class