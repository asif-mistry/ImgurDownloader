using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

namespace ImgFav2
{
    public partial class frmMain : Form
    {
        public bool IsNavigated { get; set; }
        public PageType PageType { get; set; }

        public List<ImgLink> Links { get; set; }

        private string _path = "";

        public frmMain()
        {
            InitializeComponent();
            Links = new List<ImgLink>();
            PageType = PageType.Gallery;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (!IsNavigated)
                return;
            
            
        }
        private void txtUrl_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string url = txtUrl.Text;

            PageType = PageType.Gallery;
            if (url.Contains("favorite"))
                PageType = PageType.Favorite;

            webBrowser1.Navigate(url);
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

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void btnGO_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            bool correctFolder = false;
            while (!correctFolder)
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    correctFolder = true;
                }
                else
                {
                    MessageBox.Show("Choose a correct folder.");
                }
            }

            _path = fbd.SelectedPath;
            switch (PageType)
            {
                case PageType.Favorite:
                    getFavList();
                    break;

                case PageType.Gallery:
                    break;
                    
            }

            ImageSelector selector = new ImageSelector(Links, _path);
            selector.Show();
            this.Hide();
        }

        private void getFavList()
        {
            Links = new List<ImgLink>();

            HtmlElement temp = webBrowser1.Document.GetElementById("content");

            HtmlElement content = temp.Children[0].Children[0].Children[0];//.Children[1];

            if (content == null)
                return;

            foreach (HtmlElement thumb in content.Children)
            {
                string attr = thumb.GetAttribute("className");
                if (String.Equals(attr, "thumbs", StringComparison.OrdinalIgnoreCase))
                {

                    foreach (HtmlElement obj in thumb.Children)
                    {
                        if (String.Equals(obj.TagName, "a", StringComparison.OrdinalIgnoreCase))//if its link
                        {
                            string url = obj.GetAttribute("href");
                            HtmlElement imgElement = obj.FirstChild;

                            string title = imgElement.GetAttribute("title");
                            string src = imgElement.GetAttribute("src");

                            Links.Add(new ImgLink()
                            {
                                GalleryUrl = url,
                                Title = title,
                                ThumbnailUrl = src
                            });                            //Console.WriteLine(s);
                        }
                    }
                }

            }

        }
    }
}
