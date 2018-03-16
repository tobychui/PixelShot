Public Class DisplayMode
    Dim screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
    Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
    Private Sub DisplayMode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
       
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.Hide()
        Timer1.Enabled = False
        MainForm.Timer1.Enabled = True
    End Sub

    Public Sub DisplayModeNotification()
        
        If My.Settings.Activemode = True Then
            Label1.Text = "Active Mode"
            Label1.ForeColor = Color.Green
        Else
            Label1.Text = "Passive Mode"
            Label1.ForeColor = Color.Red
        End If
        Timer1.Enabled = True
        Me.Show()
        Me.Left = screenWidth - Me.Width
        Me.Top = screenHeight - Me.Height
    End Sub
End Class