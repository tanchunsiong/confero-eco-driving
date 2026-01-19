
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Net
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports System.Collections
Public Class frmTrafficWatch
    Dim counter1 As Integer = 1
    Dim counter2 As Integer = 1
    Dim i, j As Integer
    Dim buttonwait As Integer = 2000


    Private Sub writeFinalImage()

        Dim Originalmage As Bitmap
        Dim ProcessedImage As Bitmap
        Dim croppedImage As Bitmap
        Dim finalImage As Bitmap
        finalImage = New Bitmap(3000, 1800)

        Dim lastheight As Integer = 0
        Dim lastwidth As Integer = 0

        Try
            'newGreenlist = New ArrayList()
            'newDarkGreenlist = New ArrayList()
            'newYellowlist = New ArrayList()
            'newRedlist = New ArrayList()
            'newGreylist = New ArrayList()

            For i = 1 To 4
                For j = 1 To 5

                    Originalmage = New Bitmap("capture" & j & i & ".jpg", True)
                    ProcessedImage = New Bitmap(Originalmage.Width, Originalmage.Height)



                    Dim x As Integer, y As Integer


                    For x = 10 To 745

                        ' Loop through the images pixels to reset color.
                        For y = 102 To 431


                            If (Originalmage.GetPixel(x, y).G = 192 AndAlso (Originalmage.GetPixel(x, y)).R = 96) Then
                                Dim coordinates As Integer() = {x, y}
                                'newGreenlist.Add(coordinates)
                                ProcessedImage.SetPixel(x, y, Color.FromArgb(100, 96, 192, 0))
                                ProcessedImage.SetPixel(x - 1, y, Color.FromArgb(100, 96, 192, 0))
                                ProcessedImage.SetPixel(x, y - 1, Color.FromArgb(100, 96, 192, 0))
                                ProcessedImage.SetPixel(x + 1, y, Color.FromArgb(100, 96, 192, 0))
                                ProcessedImage.SetPixel(x, y + 1, Color.FromArgb(100, 96, 192, 0))

                            ElseIf (Originalmage.GetPixel(x, y)).G = 122 AndAlso (Originalmage.GetPixel(x, y)).R = 61 Then
                                Dim coordinates As Integer() = {x, y}
                                'newDarkGreenlist.Add(coordinates)
                                ProcessedImage.SetPixel(x, y, Color.FromArgb(100, 61, 122, 0))
                                ProcessedImage.SetPixel(x - 1, y, Color.FromArgb(100, 61, 122, 0))
                                ProcessedImage.SetPixel(x, y - 1, Color.FromArgb(100, 61, 122, 0))
                                ProcessedImage.SetPixel(x + 1, y, Color.FromArgb(100, 61, 122, 0))
                                ProcessedImage.SetPixel(x, y + 1, Color.FromArgb(100, 61, 122, 0))

                            ElseIf (Originalmage.GetPixel(x, y).G = 0 AndAlso Originalmage.GetPixel(x, y).R = 255 AndAlso Originalmage.GetPixel(x, y).B = 0) Or (Originalmage.GetPixel(x, y).G = 65 AndAlso Originalmage.GetPixel(x, y).R = 255 AndAlso Originalmage.GetPixel(x, y).B = 65) Then
                                Dim coordinates As Integer() = {x, y}
                                'newRedlist.Add(coordinates)
                                ProcessedImage.SetPixel(x, y, Color.FromArgb(100, 255, 65, 65))
                                ProcessedImage.SetPixel(x - 1, y, Color.FromArgb(100, 255, 65, 65))
                                ProcessedImage.SetPixel(x, y - 1, Color.FromArgb(100, 255, 65, 65))
                                ProcessedImage.SetPixel(x + 1, y, Color.FromArgb(100, 255, 65, 65))
                                ProcessedImage.SetPixel(x, y + 1, Color.FromArgb(100, 255, 65, 65))

                            ElseIf (Originalmage.GetPixel(x, y).G = 178 AndAlso Originalmage.GetPixel(x, y).R = 255 AndAlso Originalmage.GetPixel(x, y).B = 65) Or (Originalmage.GetPixel(x, y).G = 150 AndAlso Originalmage.GetPixel(x, y).R = 252) Then
                                Dim coordinates As Integer() = {x, y}
                                'newYellowlist.Add(coordinates)
                                ProcessedImage.SetPixel(x, y, Color.FromArgb(100, 255, 178, 65))
                                ProcessedImage.SetPixel(x - 1, y, Color.FromArgb(100, 255, 178, 65))
                                ProcessedImage.SetPixel(x, y - 1, Color.FromArgb(100, 255, 178, 65))
                                ProcessedImage.SetPixel(x + 1, y, Color.FromArgb(100, 255, 178, 65))
                                ProcessedImage.SetPixel(x, y + 1, Color.FromArgb(100, 255, 178, 65))

                            ElseIf (Originalmage.GetPixel(x, y)).G = 128 AndAlso (Originalmage.GetPixel(x, y)).R = 128 AndAlso (Originalmage.GetPixel(x, y)).B = 128 Then
                                Dim coordinates As Integer() = {x, y}
                                'newGreyList.Add(coordinates)
                                ProcessedImage.SetPixel(x, y, Color.FromArgb(100, 128, 128, 128))
                                ProcessedImage.SetPixel(x - 1, y, Color.FromArgb(100, 128, 128, 128))
                                ProcessedImage.SetPixel(x, y - 1, Color.FromArgb(100, 128, 128, 128))
                                ProcessedImage.SetPixel(x + 1, y, Color.FromArgb(100, 128, 128, 128))
                                ProcessedImage.SetPixel(x, y + 1, Color.FromArgb(100, 128, 128, 128))
                            Else
                                ProcessedImage.SetPixel(x, y, Color.FromArgb(0, 0, 0, 0))

                            End If



                        Next
                    Next
                    'first row
                    If j = 1 Then
                        If i = 1 Then
                            'don't crop
                            croppedImage = New Bitmap(736, 329)
                            Dim gfx As Graphics = Graphics.FromImage(croppedImage)
                            gfx.DrawImage(ProcessedImage, New Rectangle(0, 0, 736, 329), 10, 102, 736, 329, _
                              GraphicsUnit.Pixel)
                            croppedImage.Save("cropped" & j & i & ".png")
                        Else
                            'crop front
                            croppedImage = New Bitmap(591, 329)
                            Dim gfx As Graphics = Graphics.FromImage(croppedImage)
                            gfx.DrawImage(ProcessedImage, New Rectangle(0, 0, 591, 329), 155, 102, 591, 329, _
                              GraphicsUnit.Pixel)
                            croppedImage.Save("cropped" & j & i & ".png")
                        End If
                    Else
                        'row 2,3,4,5
                        If i = 1 Then
                            'don't crop
                            croppedImage = New Bitmap(736, 266)
                            Dim gfx As Graphics = Graphics.FromImage(croppedImage)
                            gfx.DrawImage(ProcessedImage, New Rectangle(0, 0, 736, 266), 10, 165, 736, 266, _
                              GraphicsUnit.Pixel)
                            croppedImage.Save("cropped" & j & i & ".png")
                        Else
                            'crop front
                            croppedImage = New Bitmap(591, 266)
                            Dim gfx As Graphics = Graphics.FromImage(croppedImage)
                            gfx.DrawImage(ProcessedImage, New Rectangle(0, 0, 591, 266), 155, 165, 591, 266, _
                              GraphicsUnit.Pixel)
                            croppedImage.Save("cropped" & j & i & ".png")
                        End If

                    End If


                    If i = 1 Then
                        lastwidth = 0
                    ElseIf i = 2 Then
                        lastwidth = 736
                    ElseIf i = 3 Then
                        lastwidth = 736 + 591
                    ElseIf i = 4 Then
                        lastwidth = 736 + 591 + 591

                    End If
                    If j = 1 Then
                        lastheight = 0
                    ElseIf j = 2 Then
                        lastheight = 329
                    ElseIf j = 3 Then
                        lastheight = 329 + 266
                    ElseIf j = 4 Then
                        lastheight = 329 + 266 + 266
                    ElseIf j = 5 Then
                        lastheight = 329 + 266 + 266 + 266
                    End If

                    For x = 0 To croppedImage.Width - 1

                        ' Loop through the images pixels to reset color.
                        For y = 0 To croppedImage.Height - 1
                            If croppedImage.GetPixel(x, y).R = 0 And croppedImage.GetPixel(x, y).G = 0 And croppedImage.GetPixel(x, y).B = 0 Then

                                finalImage.SetPixel(x + lastwidth, y + lastheight, Color.FromArgb(0, 0, 0, 0))

                            Else

                                finalImage.SetPixel(x + lastwidth, y + lastheight, Color.FromArgb(200, croppedImage.GetPixel(x, y).R, croppedImage.GetPixel(x, y).G, croppedImage.GetPixel(x, y).B))

                            End If



                        Next
                    Next

                    finalImage.Save(FolderBrowserDialog1.SelectedPath & "\finalimage.png")
                    ProcessedImage.Save("processed" & j & i & ".png")

                Next
            Next

        Catch ex As Exception
            ex.ToString()


        End Try



    End Sub
    Private Sub DisableDisplay()
        Windows.Forms.Cursor.Position = New System.Drawing.Point(575, 75) ' click on Settings
        Threading.Thread.Sleep(10000)
        mouse_event(MOUSEEVENTF_LEFTDOWN, 575, 75, 0, 2) 'clicking mouse down
        mouse_event(MOUSEEVENTF_LEFTUP, 575, 75, 0, 2) 'clicking mouse up
        Threading.Thread.Sleep(buttonwait)

        Windows.Forms.Cursor.Position = New System.Drawing.Point(137, 445) 'disable alerts
        mouse_event(MOUSEEVENTF_LEFTDOWN, 157, 445, 0, 1) 'clicking mouse down
        Threading.Thread.Sleep(buttonwait)
        mouse_event(MOUSEEVENTF_LEFTUP, 157, 445, 0, 1) 'clicking mouse up
        Threading.Thread.Sleep(buttonwait)

        Windows.Forms.Cursor.Position = New System.Drawing.Point(295, 445) 'disable road names
        mouse_event(MOUSEEVENTF_LEFTDOWN, 315, 445, 0, 1) 'clicking mouse down
        Threading.Thread.Sleep(buttonwait)
        mouse_event(MOUSEEVENTF_LEFTUP, 315, 445, 0, 1) 'clicking mouse up
        Threading.Thread.Sleep(buttonwait)

        Windows.Forms.Cursor.Position = New System.Drawing.Point(395, 445) 'disable building names
        mouse_event(MOUSEEVENTF_LEFTDOWN, 415, 445, 0, 1) 'clicking mouse down
        Threading.Thread.Sleep(buttonwait)
        mouse_event(MOUSEEVENTF_LEFTUP, 415, 445, 0, 1) 'clicking mouse up
        Threading.Thread.Sleep(buttonwait)
    End Sub

    Private Sub ZoomIn()
        Windows.Forms.Cursor.Position = New System.Drawing.Point(200, 80)
        mouse_event(MOUSEEVENTF_LEFTDOWN, 200, 80, 0, 1)
        mouse_event(MOUSEEVENTF_LEFTUP, 200, 80, 0, 1)
        Threading.Thread.Sleep(buttonwait)
    End Sub

    Private Sub initialise()

        System.Diagnostics.Process.Start("http://www.onemotoring.com.sg/publish/onemotoring/en/on_the_roads/interactive_map.html")
        Windows.Forms.Cursor.Position = New System.Drawing.Point(500, 390)

        Threading.Thread.Sleep(10000)

        mouse_event(MOUSEEVENTF_LEFTDOWN, 500, 390, 0, 1)
        mouse_event(MOUSEEVENTF_LEFTUP, 500, 390, 0, 1)

        Threading.Thread.Sleep(30000)

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FolderBrowserDialog1.ShowDialog()
        initialise()
        DisableDisplay()

        ZoomIn()
        ZoomIn()
        ZoomIn()
        ZoomIn()




        moveleft()
        moveleft()
        moveleft()
        moveleft()
        moveleft()
        moveleft()
        moveleft()

        moveup()
        moveup()
        moveup()
        moveup()
        moveup()
        moveup()
        moveup()
        moveup()
        moveup()
        moveup()

        'disable displays

       
        timerTrafficWatch.Start()


    End Sub


    Declare Sub mouse_event Lib "user32" Alias "mouse_event" (ByVal dwFlags As Integer, ByVal dx As Integer, ByVal dy As Integer, ByVal cButtons As Integer, ByVal dwExtraInfo As Integer)
    Private Const MOUSEEVENTF_ABSOLUTE = &H8000 ' absolute move
    Private Const MOUSEEVENTF_LEFTDOWN = &H2 ' left button down
    Private Const MOUSEEVENTF_LEFTUP = &H4 ' left button up
    Private Const MOUSEEVENTF_MOVE = &H1 ' mouse move
    Private Const MOUSEEVENTF_MIDDLEDOWN = &H20
    Private Const MOUSEEVENTF_MIDDLEUP = &H40
    Private Const MOUSEEVENTF_RIGHTDOWN = &H8
    Private Const MOUSEEVENTF_RIGHTUP = &H10

    Private Declare Function CreateDC Lib "gdi32" Alias "CreateDCA" (ByVal lpDriverName As String, ByVal lpDeviceName As String, ByVal lpOutput As String, ByVal lpInitData As String) As Integer
    Private Declare Function CreateCompatibleDC Lib "GDI32" (ByVal hDC As Integer) As Integer
    Private Declare Function CreateCompatibleBitmap Lib "GDI32" (ByVal hDC As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer) As Integer
    Private Declare Function GetDeviceCaps Lib "gdi32" Alias "GetDeviceCaps" (ByVal hdc As Integer, ByVal nIndex As Integer) As Integer
    Private Declare Function SelectObject Lib "GDI32" (ByVal hDC As Integer, ByVal hObject As Integer) As Integer
    Private Declare Function BitBlt Lib "GDI32" (ByVal srchDC As Integer, ByVal srcX As Integer, ByVal srcY As Integer, ByVal srcW As Integer, ByVal srcH As Integer, ByVal desthDC As Integer, ByVal destX As Integer, ByVal destY As Integer, ByVal op As Integer) As Integer
    Private Declare Function DeleteDC Lib "GDI32" (ByVal hDC As Integer) As Integer
    Private Declare Function DeleteObject Lib "GDI32" (ByVal hObj As Integer) As Integer

    Const SRCCOPY As Integer = &HCC0020
    Private Background As Bitmap
    Private fw, fh As Integer

    Protected Sub CaptureScreen()
        Dim hsdc, hmdc As Integer
        Dim hbmp, hbmpold As Integer
        Dim r As Integer
        hsdc = CreateDC("DISPLAY", "", "", "")
        hmdc = CreateCompatibleDC(hsdc)
        fw = GetDeviceCaps(hsdc, 8)
        fh = GetDeviceCaps(hsdc, 10)
        hbmp = CreateCompatibleBitmap(hsdc, fw, fh)
        hbmpold = SelectObject(hmdc, hbmp)
        r = BitBlt(hmdc, 0, 0, fw, fh, hsdc, 0, 0, 13369376)
        hbmp = SelectObject(hmdc, hbmpold)
        r = DeleteDC(hsdc)
        r = DeleteDC(hmdc)
        Background = Image.FromHbitmap(New IntPtr(hbmp))
        DeleteObject(hbmp)
    End Sub
    Public Sub moveup()
        Windows.Forms.Cursor.Position = New System.Drawing.Point(130, 60) 'move to position
        mouse_event(MOUSEEVENTF_LEFTDOWN, 130, 60, 0, 1) 'clicking mouse down
        mouse_event(MOUSEEVENTF_LEFTUP, 130, 60, 0, 1) 'clicking mouse up
        Threading.Thread.Sleep(buttonwait)
    End Sub

    Public Sub moveleft()
        Windows.Forms.Cursor.Position = New System.Drawing.Point(110, 75) 'move to position
        mouse_event(MOUSEEVENTF_LEFTDOWN, 110, 70, 0, 1) 'clicking mouse down
        mouse_event(MOUSEEVENTF_LEFTUP, 110, 70, 0, 1) 'clicking mouse up
        Threading.Thread.Sleep(buttonwait)
    End Sub


    Public Sub movedown()

        Windows.Forms.Cursor.Position = New System.Drawing.Point(130, 90) 'move to position
        mouse_event(MOUSEEVENTF_LEFTDOWN, 130, 95, 0, 1) 'clicking mouse down
        mouse_event(MOUSEEVENTF_LEFTUP, 130, 95, 0, 1) 'clicking mouse up
        Threading.Thread.Sleep(buttonwait)

    End Sub
    Public Sub moveright()
        Windows.Forms.Cursor.Position = New System.Drawing.Point(150, 75) 'move to position
        mouse_event(MOUSEEVENTF_LEFTDOWN, 150, 70, 0, 1) 'clicking mouse down
        mouse_event(MOUSEEVENTF_LEFTUP, 150, 70, 0, 1) ' clicking mouse up
        Threading.Thread.Sleep(buttonwait)

    End Sub


    Private Sub timerTrafficWatch_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerTrafficWatch.Tick

        'if it is not the last square, run the loop
        If counter1 = 4 And counter2 = 5 Then
            CaptureScreen()
            PictureBox1.Image = Background
            PictureBox1.Image.Save("Capture" & counter2 & counter1 & ".jpg")
            counter1 = 1
            counter2 = 1
            moveleft()
            moveleft()
            moveleft()
            moveleft()
            moveleft()
            moveleft()
            moveleft()
            moveleft()
            moveleft()
            moveleft()
            moveleft()
            moveleft()

            moveup()
            moveup()
            moveup()
            moveup()
            moveup()
            moveup()
            moveup()
            moveup()
            moveup()
            moveup()
            moveup()
            moveup()
            moveup()
            moveup()
            moveup()
            moveup()
            writeFinalImage()
            System.Threading.Thread.Sleep(50000)
        End If

        'end of row only
        If counter1 = 4 Then
            CaptureScreen()
            Background.Save("Capture" & counter2 & counter1 & ".jpg")

            moveleft()
            moveleft()
            moveleft()
            moveleft()
            moveleft()
            moveleft()
            moveleft()
            moveleft()
            moveleft()
            moveleft()
            moveleft()
            moveleft()

            movedown()
            movedown()
            movedown()
            movedown()

            counter1 = 1
            counter2 += 1
        Else
            CaptureScreen()
            Background.Save("Capture" & counter2 & counter1 & ".jpg")
            moveright()
            moveright()
            moveright()
            moveright()
            counter1 += 1
        End If

    End Sub

    Private Sub FolderBrowserDialog1_HelpRequest(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FolderBrowserDialog1.HelpRequest

    End Sub
End Class
