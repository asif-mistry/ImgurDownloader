using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImgFav2
{
    public partial class ImageSelector : Form
    {
        public List<ImgLink> Links { get; set; }

        public ImageSelector()
        {
            InitializeComponent();
        }

        public ImageSelector(List<ImgLink> imgLinks, string path)
        {
            InitializeComponent();
            Links = imgLinks;
            var client = new WebClient();
            string myUrl = imgLinks[0].ThumbnailUrl;
            myUrl = myUrl.Replace("\"", "");
            string name = imgLinks[0].Title.Replace("\\", "").Replace("/", "").Replace(":", "").Replace("*", "").Replace("?", "").Replace("<", "").Replace(">", "").Replace("\"", "").Replace("|", "");

            //GetImage(myUrl, str[4]);
            
            client.DownloadFile(myUrl, path + name + System.IO.Path.GetExtension(myUrl));

        }

        private void ImageSelector_Load(object sender, EventArgs e)
        {

        }
    }
}
