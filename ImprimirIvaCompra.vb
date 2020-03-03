Imports Microsoft.Reporting.WinForms
Public Class ImprimirIvaCompra
    Public tipolibro As String
    Public hojasant As Integer
    Private Sub ImprimirIvaCompra_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.rptivacompra.RefreshReport()
    End Sub

    Private Sub rptivacompra_PrintingBegin(sender As Object, e As ReportPrintEventArgs) Handles rptivacompra.PrintingBegin
        Try
            Reconectar()
            Dim sql As String
            If tipolibro = "compra" Then
                sql = "update cm_empresas set hojacomp=" & hojasant + rptivacompra.GetTotalPages & " where idempresas=" & DatosEmpresa.IdEmpresa
            ElseIf tipolibro = "venta" Then
                sql = "update cm_empresas set hojavent=" & hojasant + rptivacompra.GetTotalPages & " where idempresas=" & DatosEmpresa.IdEmpresa
            Else
                MsgBox("No se pudo identifical el tipo de libro a imprimir")
                e.Cancel = True
                Exit Sub
            End If
            Dim comandoupd As New MySql.Data.MySqlClient.MySqlCommand(sql, conexionPrinc)
            comandoupd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
            e.Cancel = True
        End Try
        'Me.Close()
    End Sub
End Class