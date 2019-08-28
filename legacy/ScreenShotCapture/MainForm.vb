Imports System.Drawing.Imaging

Public Class MainForm
    Private Declare Function GetAsyncKeyState Lib "user32" (ByVal vkey As Int32) As Int16
    Dim desktop As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
    Dim screenWidth As Integer = Screen.PrimaryScreen.Bounds.Width
    Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
    Private Sub main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ScreenCapture(50, 50, 1000, 1000)
        Me.Top = 0
        Me.Left = 0
        If My.Settings.SaveLocation = Nothing Then
            My.Settings.SaveLocation = desktop & "\"
            My.Settings.Save()
        End If
        If My.Settings.Activemode = True Then
            Label1.Text = "Active Mode"
            Label1.ForeColor = Color.Green
        Else
            Label1.Text = "Passive Mode"
            Label1.ForeColor = Color.Red
        End If
        NotifyIcon1.ShowBalloonTip(5)

    End Sub

    Public Sub ScreenCapture(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer)
        If x2 > getTotalWidth() Then
            x2 = getTotalWidth()
        End If
        If y2 > getTotalWidth() Then
            y2 = getTotalWidth()
        End If
        Dim corner As New Point(0, 0)
        Dim ss As New Size(getTotalWidth(), screenHeight)
        Dim bounds As New Rectangle(corner, ss)
        Dim screenshot As System.Drawing.Bitmap
        Dim graph As Graphics
        'bounds = Screen.PrimaryScreen.Bounds
        Dim w As Integer = x2 - x1
        If w < 0 Then
            w = w * -1
        End If
        Dim h As Integer = y2 - y1
        If h < 0 Then
            h = h * -1
        End If
        screenshot = New System.Drawing.Bitmap(w, h, System.Drawing.Imaging.PixelFormat.Format32bppRgb)
        graph = Graphics.FromImage(screenshot)
        Dim s, t As Integer
        If x1 < x2 Then
            s = x1
        Else
            s = x2
        End If
        If y1 < y2 Then
            t = y1
        Else
            t = y2
        End If
        graph.CopyFromScreen(0, 0, 0 - s, 0 - t, bounds.Size, CopyPixelOperation.SourceCopy)
        If My.Settings.SaveLocation = Nothing Then
            My.Settings.SaveLocation = desktop & "\"
            My.Settings.Save()
        End If
        screenshot.Save(My.Settings.SaveLocation & GetFileName(), Imaging.ImageFormat.Png)
    End Sub

    Public Function PassiveScreenShot(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer)

        If x2 > getTotalWidth() Then
            x2 = getTotalWidth()
        End If
        If y2 > getTotalWidth() Then
            y2 = getTotalWidth()
        End If
        Dim corner As New Point(0, 0)
        Dim ss As New Size(getTotalWidth(), screenHeight)
        Dim bounds As New Rectangle(corner, ss)
        Dim screenshot As System.Drawing.Bitmap
        Dim graph As Graphics
        'bounds = Screen.PrimaryScreen.Bounds
        Dim w As Integer = x2 - x1
        If w < 0 Then
            w = w * -1
        End If
        Dim h As Integer = y2 - y1
        If h < 0 Then
            h = h * -1
        End If
        screenshot = New System.Drawing.Bitmap(w, h, System.Drawing.Imaging.PixelFormat.Format32bppRgb)
        graph = Graphics.FromImage(screenshot)
        Dim s, t As Integer
        If x1 < x2 Then
            s = x1
        Else
            s = x2
        End If
        If y1 < y2 Then
            t = y1
        Else
            t = y2
        End If
        graph.CopyFromScreen(0, 0, 0 - s, 0 - t, bounds.Size, CopyPixelOperation.SourceCopy)
        Return screenshot
    End Function
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If My.Settings.Activemode = True Then
            Selector.Show()
            Me.Hide()
        Else
            PassiveShot.LoadScreenShot(PassiveScreenShot(0, 0, screenWidth, screenHeight))


        End If

    End Sub
    Private Function GetFileName()
        Dim time As String = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") & ".png"
        Return time
    End Function

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim ps As Boolean
        Dim shiftkey As Boolean
        Dim Ctrlkey As Boolean
        ps = GetAsyncKeyState(Keys.PrintScreen)
        shiftkey = GetAsyncKeyState(Keys.ShiftKey)
        Ctrlkey = GetAsyncKeyState(Keys.ControlKey)
        If ps And shiftkey = True Then
            If My.Settings.Activemode = True Then
                Selector.Show()
                Me.Hide()
            Else
                PassiveShot.LoadScreenShot(PassiveScreenShot(0, 0, screenWidth, screenHeight))


            End If
        ElseIf ps And Ctrlkey = True Then
            'MsgBox("Haha")
            Timer1.Enabled = False
            If My.Settings.Activemode = True Then
                Label1.Text = "Passive Mode"
                Label1.ForeColor = Color.Red
                My.Settings.Activemode = False
                My.Settings.Save()
                DisplayMode.Close()
                DisplayMode.DisplayModeNotification()


            Else
                Label1.Text = "Active Mode"
                Label1.ForeColor = Color.Green
                My.Settings.Activemode = True
                My.Settings.Save()
                DisplayMode.Close()
                DisplayMode.DisplayModeNotification()


            End If
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Process.Start(My.Settings.SaveLocation)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try


    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Setting.Show()
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Me.Hide()
        Timer2.Enabled = False
    End Sub



    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Timer2.Enabled = True
    End Sub

    Private Sub NotifyIcon1_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseClick
        Me.Show()
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        If My.Settings.Activemode = True Then
            Selector.Show()
            Me.Hide()
        Else
            PassiveShot.LoadScreenShot(PassiveScreenShot(0, 0, screenWidth, screenHeight))


        End If
    End Sub
    Public Function getTotalWidth()
        Dim totalwidth As Integer = 1
        Dim numberofmonitors As Integer = Screen.AllScreens.Length
        If numberofmonitors > 1 Then
            totalwidth = screenWidth * numberofmonitors
        Else
            totalwidth = screenWidth
        End If

        Return totalwidth
    End Function

    Public Sub savednotice()
        NotifyIcon1.BalloonTipTitle = "Your Screenshot have been saved"
        NotifyIcon1.BalloonTipText = "Screenshot saved as :" & GetFileName()
        NotifyIcon1.ShowBalloonTip(3)

    End Sub
    Public Sub ConvertImage(ByVal name As String, ByVal curBitmap As Bitmap)
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If My.Settings.Activemode = True Then
            Label1.Text = "Passive Mode"
            Label1.ForeColor = Color.Red
            My.Settings.Activemode = False
            My.Settings.Save()
        Else
            Label1.Text = "Active Mode"
            Label1.ForeColor = Color.Green
            My.Settings.Activemode = True
            My.Settings.Save()
        End If
    End Sub
End Class
