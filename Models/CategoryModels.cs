using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SinglePageCMS.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<Content> Contents { get; set; }
    }
}