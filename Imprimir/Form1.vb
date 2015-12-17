Public Class Form1
    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Try
            Dim prfont As New Font("Arial", 15, FontStyle.Bold)

        Catch ex As Exception

        End Try
    End Sub
End Class
