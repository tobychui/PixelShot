Imports System.Drawing.Drawing2D

Public Class DisplayMode
    Dim screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
    Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
    Private Sub DisplayMode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim path As GraphicsPath = GetRoundedRectPath(Me.ClientRectangle, 20)
        Me.Region = New Region(path)
    End Sub
    Private Function GetRoundedRectPath(ByVal Rectangle As Rectangle, ByVal r As Integer) As GraphicsPath
        Rectangle.Offset(-1, -1)
        Dim RoundRect As New Rectangle(Rectangle.Location, New Size(r - 1, r - 1))
        Dim path As New System.Drawing.Drawing2D.GraphicsPath
        path.AddArc(RoundRect, 180, 90)     '左上角

        RoundRect.X = Rectangle.Right - r   '右上角
        path.AddArc(RoundRect, 270, 90)

        RoundRect.Y = Rectangle.Bottom - r  '右下角
        path.AddArc(RoundRect, 0, 90)

        RoundRect.X = Rectangle.Left             '左下角
        path.AddArc(RoundRect, 90, 90)
        path.CloseFigure()

        Return path
    End Function
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