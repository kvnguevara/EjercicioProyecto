Public Class Form1
    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Try
            'Declaro el stilo de la letra que va a tener nuestra impresion
            Dim prfont As New Font("Arial", 15, FontStyle.Bold)
            'Le indicamos donde tiene que poner la primera letra y el tipo de letra
            e.Graphics.DrawString(TextBox1.Text & " " & TextBox2.Text, prfont, Brushes.Black, New Point(50, 200))
            'Le indicamos que no hay mas página
            e.HasMorePages = False
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Declaramos un objeto de vista previa
        Dim vistaprevia As PrintPreviewDialog = New PrintPreviewDialog
        vistaprevia.Document = PrintDocument1
        'Definicimos una variable resultado para ver si ha funcionado
        Dim resultado As DialogResult = vistaprevia.ShowDialog
        'Compruebi
        If resultado = DialogResult.OK Then
            PrintDocument1.Print()

        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Le decimos a los pictureBox que las imganes se pueden mover
        imagen1.AllowDrop = True
        imagen2.AllowDrop = True

    End Sub

    Private Sub AfterDragDrop(ByVal pic As PictureBox)
        ' pic.Image = Nothing
    End Sub
    'Programamos 
    Private Sub imagen1_MouseDown(sender As Object, e As MouseEventArgs) Handles imagen1.MouseDown
        'sender es el que controla el movimiento del raton, si arrastramos o soltamos
        If sender.DoDragDrop(sender.Image, DragDropEffects.Move) = DragDropEffects.Move Then
            AfterDragDrop(sender)
        End If
    End Sub
    'cuando soltamos la imagen 
    Private Sub imagen2_DragEnter(sender As Object, e As DragEventArgs) Handles imagen2.DragEnter
        e.Effect = DragDropEffects.Move
    End Sub

    Private Sub imagen2_DragDrop(sender As Object, e As DragEventArgs) Handles imagen2.DragDrop
        sender.image = DirectCast(e.Data.GetData(DataFormats.Bitmap), Image)
    End Sub
End Class
