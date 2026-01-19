using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WebBrowser
{
   
    public partial class WebBrowserControlForm : UserControl
    {

       
        public WebBrowserControlForm()
        {
            InitializeComponent();
         
        }


        public System.Windows.Forms.WebBrowser getWebBrowserControl()
        {

            return webBrowser1;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        

    }


}
