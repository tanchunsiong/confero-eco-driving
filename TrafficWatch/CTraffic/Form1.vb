Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Net
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports System.Collections

Public Class Form1

  
    'Dim newGreenlist As ArrayList
    'Dim newDarkGreenlist As ArrayList
    'Dim newYellowlist As ArrayList
    'Dim newRedlist As ArrayList
    'Dim newGreyList As ArrayList
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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

                    finalImage.Save("finalimage.png")
                    ProcessedImage.Save("processed" & j & i & ".png")

                Next
            Next

        Catch ex As Exception
            ex.ToString()


        End Try

    End Sub



End Class
