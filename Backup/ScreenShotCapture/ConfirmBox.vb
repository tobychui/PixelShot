Public Class ConfirmBox
    Dim screenWidth As Integer = MainForm.getTotalWidth()
    Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
    Private Sub ConfirmBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Hide()
        Selector.TopMost = True
        Selector.SaveCapture()
        MainForm.savednotice()
        'MainForm.Show()
        Me.Close()
        PassiveShot.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Hide()
        Selector.TopMost = True
        Selector.ClearAll()
        Me.Close()
    End Sub
    Public Sub SetLocation(ByVal x, ByVal y)
        If x > screenWidth - 140 Then
            x = screenWidth - 140
        End If
        Me.Left = x
        If y > screenHeight - 36 Then
            y = screenHeight - 36
        End If
        Me.Top = y
        Me.Width = 150
        Me.Height = 40
    End Sub
End Class