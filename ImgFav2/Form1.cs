using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImgFav2
{
    public partial class frmMain : Form
    {
        public bool IsNavigated { get; set; }

        public frmMain()
        {
            InitializeComponent();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (!IsNavigated)
                return;

            //get page element with id
           HtmlElementCollection elements =  webBrowser1.Document.GetElementsByTagName("img");
            if (elements.Count == 0)
                return;

            foreach(HtmlElement obj in elements)
            {
                string s = obj.GetAttribute("src");
                Console.WriteLine(s);
            }

            
        }
        private void txtUrl_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(txtUrl.Text);
        }

        private void ImgDownloader_Load(object sender, EventArgs e)
        {
        }

        private void txtUrl_TextChanged(object sender, EventArgs e)
        {

        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            IsNavigated = false;
            frmMain.ActiveForm.Text = "Loading";
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            IsNavigated = true;
            frmMain.ActiveForm.Text = "Loading Complete";
        }
    }
}
