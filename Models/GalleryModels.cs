using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SinglePageCMS.Models
{
    public class Gallery
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Describtion { get; set; }

        public virtual ICollection<GalleryItem> GalleryItems { get; set; }
    }

    public class GalleryItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Describtion { get; set; }

        public string MediaUrl { get; set; }

        public string LinkUrl { get; set; }

        public DateTime DateTime { get; set; }

        public virtual Gallery Gallery { get; set; }

        public virtual int GalleryId { get; set; }
    }
}