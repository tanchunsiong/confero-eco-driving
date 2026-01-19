using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Net;
using System.IO;

using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Collections;


namespace CWeatherWatch
{
    public partial class frmWeatherWatch : Form
    {
       


        public frmWeatherWatch()
        {
            InitializeComponent();
        }

  

        private void Form1_Load(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            timerWeatherWatch.Start();
        }

        

        private void timer1_Tick_1(object sender, EventArgs e)
        {
           try
            {

                SaveFileFromURL("http://www.nea.gov.sg/cms/mss/gif/rainloc0.gif", "weather.jpg", 30);

                //System.Net.WebClient wc = new System.Net.WebClient();
              //  wc.DownloadFile("http://www.nea.gov.sg/cms/mss/gif/rainloc0.gif", "weather.jpg"); 

                Bitmap Originalmage = new Bitmap(@"weather.jpg");
                Bitmap ProcessedImage = new Bitmap(Originalmage.Width, Originalmage.Height);

                int x, y;
                
                

                // Loop through the images pixels to reset color.
                for (x = 0; x < Originalmage.Width; x++)
                {
                    for (y = 0; y < Originalmage.Height; y++)
                    {

                        if ((Originalmage.GetPixel(x, y)).G == 245 && (Originalmage.GetPixel(x, y)).B == 7)
                        {
                            int[] coordinates = { x, y };

                            ProcessedImage.SetPixel(x, y, Color.FromArgb(100, 0, 245, 7));
                            ProcessedImage.SetPixel(x - 1, y, Color.FromArgb(100, 0, 245, 7));
                            ProcessedImage.SetPixel(x, y - 1, Color.FromArgb(100, 0, 245, 7));
                            ProcessedImage.SetPixel(x + 1, y, Color.FromArgb(100, 0, 245, 7));
                            ProcessedImage.SetPixel(x, y + 1, Color.FromArgb(100, 0, 245, 7));

                        }
                        else if ((Originalmage.GetPixel(x, y)).G == 73 && (Originalmage.GetPixel(x, y)).R == 255)
                        {
                            int[] coordinates = { x, y };

                            ProcessedImage.SetPixel(x, y, Color.FromArgb(100, 255, 73, 0));
                            ProcessedImage.SetPixel(x - 1, y, Color.FromArgb(100, 255, 73, 0));
                            ProcessedImage.SetPixel(x, y - 1, Color.FromArgb(100, 255, 73, 0));
                            ProcessedImage.SetPixel(x + 1, y, Color.FromArgb(100, 255, 73, 0));
                            ProcessedImage.SetPixel(x, y + 1, Color.FromArgb(100, 255, 73, 0));
                        }
                        else if ((Originalmage.GetPixel(x, y)).G == 255 && (Originalmage.GetPixel(x, y)).R == 255)
                        {
                            int[] coordinates = { x, y };

                            ProcessedImage.SetPixel(x, y, Color.FromArgb(100, 255, 255, 0));
                            ProcessedImage.SetPixel(x - 1, y, Color.FromArgb(100, 255, 255, 0));
                            ProcessedImage.SetPixel(x, y - 1, Color.FromArgb(100, 255, 255, 0));
                            ProcessedImage.SetPixel(x + 1, y, Color.FromArgb(100, 255, 255, 0));
                            ProcessedImage.SetPixel(x, y + 1, Color.FromArgb(100, 255, 255, 0));
                        }
                        else
                        {
                            ProcessedImage.SetPixel(x, y, Color.FromArgb(0, 0, 0, 0));
                        }

                    }
                }



                // Set the PictureBox to display the image.
                ProcessedImage.Save(folderBrowserDialog1.SelectedPath + @"\weather.png");
                pictureBox1.Image = ProcessedImage;
                Originalmage.Dispose();
                


            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public static bool SaveFileFromURL(string url, string destinationFileName, int timeoutInSeconds)
        {


            // Create a web request to the URL  
            HttpWebRequest MyRequest = (HttpWebRequest)WebRequest.Create(url);
            MyRequest.Timeout = timeoutInSeconds * 1000;
            try
            {
                // Get the web response  
                HttpWebResponse MyResponse = (HttpWebResponse)MyRequest.GetResponse();

                // Make sure the response is valid  
                if (HttpStatusCode.OK == MyResponse.StatusCode)
                {
                    Stream MyResponseStream = MyResponse.GetResponseStream();
                    FileStream MyFileStream = new FileStream(destinationFileName, FileMode.OpenOrCreate, FileAccess.Write);
                    byte[] MyBuffer = new byte[4096];
                    int BytesRead;
                    while (0 < (BytesRead = MyResponseStream.Read(MyBuffer, 0, MyBuffer.Length)))
                    {
                        // Write the chunk from the buffer to the file  
                        MyFileStream.Write(MyBuffer, 0, BytesRead);
                    }

                    MyFileStream.Flush();
                    MyFileStream.Close();
                    MyFileStream.Dispose();

                    MyResponseStream.Flush();
                    MyResponseStream.Close();
                    MyResponseStream.Dispose();

                    MyResponse.Close();
                    MyRequest.Abort();

                  


                    // Open the response stream  
                    //using (Stream MyResponseStream = MyResponse.GetResponseStream())
                    //{
                    //    // Open the destination file  
                    //    using (FileStream MyFileStream = new FileStream(destinationFileName, FileMode.OpenOrCreate, FileAccess.Write))
                    //    {
                    //        // Create a 4K buffer to chunk the file  
                    //        byte[] MyBuffer = new byte[4096];
                    //        int BytesRead;
                    //        // Read the chunk of the web response into the buffer  
                    //        while (0 < (BytesRead = MyResponseStream.Read(MyBuffer, 0, MyBuffer.Length)))
                    //        {
                    //            // Write the chunk from the buffer to the file  
                    //            MyFileStream.Write(MyBuffer, 0, BytesRead);
                    //        }
                    //        MyFileStream.Close();

                    //    } MyResponseStream.Close();

                    //} MyResponse.Close();
                }
            }
            catch (Exception err)
            {
                throw new Exception("Error saving file from URL:" + err.Message, err);
            }

            return true;
        }
        }



    }

