Public Class Setting

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        My.Settings.SaveLocation = TextBox1.Text
        My.Settings.ScreenSoomRatio = TrackBar1.Value / 100
        My.Settings.Save()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        My.Settings.SaveLocation = TextBox1.Text
        My.Settings.ScreenSoomRatio = TrackBar1.Value / 100
        My.Settings.Save()
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Setting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = My.Settings.SaveLocation
        TrackBar1.Value = My.Settings.ScreenSoomRatio * 100
        Label7.Text = TrackBar1.Value & "%"
        If My.Computer.Info.OSFullName.ToString.Contains("10") = False Then
            TrackBar1.Enabled = False
            Label6.Text = "Not compatible with this OS version."
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If My.Computer.FileSystem.DirectoryExists(TextBox1.Text) And TextBox1.Text.Substring(TextBox1.Text.Length - 1, 1) = "\" Then
            Label3.Text = "Directory Exists"
            Label3.ForeColor = Color.Green
        ElseIf My.Computer.FileSystem.DirectoryExists(TextBox1.Text) And TextBox1.Text.Substring(TextBox1.Text.Length - 1, 1) <> "\" Then
            Label3.Text = "Missing the last '\'"
            Label3.ForeColor = Color.Orange
        Else
            Label3.Text = "Invaid Directory Path!"
            Label3.ForeColor = Color.Red
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim folderDlg As New FolderBrowserDialog
        folderDlg.Description = "Select the folder which you want to save your captures in"
        'folderDlg.RootFolder = Environment.SpecialFolder.MyDocuments
        folderDlg.ShowNewFolderButton = True
        If (folderDlg.ShowDialog() = DialogResult.OK) Then
            TextBox1.Text = folderDlg.SelectedPath & "\"
            Dim root As Environment.SpecialFolder = folderDlg.RootFolder
        End If
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        Label7.Text = TrackBar1.Value & "%"
    End Sub


End Class