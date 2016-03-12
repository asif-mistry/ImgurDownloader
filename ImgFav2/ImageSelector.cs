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
    public partial class ImageSelector : Form
    {
        public ImageSelector()
        {
            InitializeComponent();
        }

        public ImageSelector(List<ImgLink> imgLinks)
        {
            InitializeComponent();
        }

        private void ImageSelector_Load(object sender, EventArgs e)
        {

        }
    }
}
