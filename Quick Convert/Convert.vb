Imports System.Drawing.Imaging

Public Class Convert

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        'Open File Dialog to Select Image
        Dim ofd As New OpenFileDialog()
        ofd.Filter = "Image Files|*.jpg;*.png;*.bmp;*.jpeg;*.gif"
        If ofd.ShowDialog() = DialogResult.OK Then
            txtImagePath.Text = ofd.FileName
        End If
    End Sub

    Private Sub btnConvert_Click(sender As Object, e As EventArgs) Handles btnConvert.Click
        'Ensure a file has been selected
        If txtImagePath.Text = String.Empty Then
            MessageBox.Show("Please select an image file first.")
            Exit Sub
        End If

        'Determine the desired format
        Dim format As ImageFormat = Nothing
        If rdoPng.Checked Then
            format = ImageFormat.Png
        ElseIf rdoJpg.Checked Then
            format = ImageFormat.Jpeg
        ElseIf rdoBmp.Checked Then
            format = ImageFormat.Bmp
        Else
            MessageBox.Show("Please select a format to convert to.")
            Exit Sub
        End If

        'Load the image
        Dim img As Image = Image.FromFile(txtImagePath.Text)

        'Show SaveFileDialog for user to choose where to save the converted image
        Dim sfd As New SaveFileDialog()
        If rdoPng.Checked Then
            sfd.Filter = "PNG Files|*.png"
        ElseIf rdoJpg.Checked Then
            sfd.Filter = "JPG Files|*.jpg"
        ElseIf rdoBmp.Checked Then
            sfd.Filter = "BMP Files|*.bmp"
        End If

        If sfd.ShowDialog() = DialogResult.OK Then
            ProgressBar1.Value = 0
            ProgressBar1.Maximum = 100
            'Simulate progress (for simplicity)
            For i As Integer = 1 To 100
                ProgressBar1.Value = i
                Threading.Thread.Sleep(10)
            Next

            'Save the image
            img.Save(sfd.FileName, format)
            MessageBox.Show("Conversion completed successfully.")
            ProgressBar1.Value = 0
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Help.Show()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        MessageBox.Show("Quick Convert Version 1.6 By Youssef Salah For Support Contact me at youssefpro986@gmail.com", "About", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class