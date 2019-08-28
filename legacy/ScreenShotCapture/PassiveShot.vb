Public Class PassiveShot
    Dim screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
    Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
    Private Sub PassiveShot_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Width = screenWidth
        Me.Height = screenHeight
        Me.Left = 0
        Me.Top = 0
    End Sub

    Public Sub LoadScreenShot(ByVal shot As Bitmap)
        Me.BackgroundImage = shot
        Me.Show()
        Selector.Show()

    End Sub
End Class