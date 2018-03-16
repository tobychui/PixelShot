Public Class Selector
    Dim screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
    Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
    Dim mouseSelecting As Boolean = False
    Dim mlsx As Integer = 0
    Dim mlsy As Integer = 0
    Dim mlex As Integer = 0
    Dim mley As Integer = 0
    Private Sub Selector_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Width = MainForm.getTotalWidth()
        screenWidth = Me.Width
        Me.Height = screenHeight + GetScreenOffsets()
        Me.Left = 0
        Me.Top = 0 - GetScreenOffsets()
    End Sub
    Public Function GetScreenOffsets()
        Dim GreatestHeight As Integer = MainForm.getGreatestHeight()
        If GreatestHeight <> screenHeight Then
            Return Math.Abs(GreatestHeight - screenHeight)
        Else
            Return 0
        End If
    End Function
    Private Sub Selector_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            'MainForm.Show()
            PassiveShot.Close()
            Me.Close()
        End If
    End Sub

    Private Sub Selector_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        mouseSelecting = True
        mlsx = e.X
        mlsy = e.Y
    End Sub

    Private Sub Selector_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        If mouseSelecting Then
            UpdateSelection(e.X, e.Y, mlsx, mlsy)
        End If
    End Sub
    Private Sub Selector_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp
        mouseSelecting = False
        UpdateSelection(e.X, e.Y, mlsx, mlsy)
        mlex = e.X
        mley = e.Y
        Me.TopMost = False
        ConfirmBox.Show()
        ConfirmBox.SetLocation(e.X, e.Y)
    End Sub


    Private Sub UpdateSelection(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer)
        Dim g As Graphics = Me.CreateGraphics()
        g.Clear(Me.BackColor)

        Dim blackPen As New Pen(Color.Red, 2)
        ' Create points that define line. 
        Dim point1 As New Point(x1, y1)
        Dim point2 As New Point(x2, y2)
        Dim point3 As New Point(x1, y2)
        Dim point4 As New Point(x2, y1)
        '1-4,
        ' Draw line to screen.

        g.DrawLine(blackPen, point1, point3)
        g.DrawLine(blackPen, point1, point4)
        g.DrawLine(blackPen, point2, point3)
        g.DrawLine(blackPen, point2, point4)
        blackPen.Dispose()
    End Sub

    Public Sub ClearAll()
        Dim g As Graphics = Me.CreateGraphics()
        g.Clear(Me.BackColor)
    End Sub

    Public Sub SaveCapture()
        Dim rrr As Double = My.Settings.ScreenSoomRatio
        Me.Hide()
        MainForm.ScreenCapture(Int(mlsx * rrr), Int(mlsy * rrr), Int(mlex * rrr), Int(mley * rrr))
        Me.Close()
    End Sub
End Class