using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgFav2
{
    public class Model
    {

    }

    enum PageType
    {
        None=1,
        Favorite,
        Gallery
    }

    public class ImgLink
    {
        public string Title { get; set; }

        public string ThumbnailUrl { get; set; }

        public string GalleryUrl { get; set; }
    }
}
