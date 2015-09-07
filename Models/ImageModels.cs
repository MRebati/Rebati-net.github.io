using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SinglePageCMS.Models
{
    public class Image
    {
        [Key]
        public long Id { get; set; }

        [Display(Name = "نام عکس")]
        public string ImageName { get; set; }

        [Display(Name = "مسیر")]
        public string Path { get; set; }

        [Display(Name = "فولدر")]
        public string ImageCategoryId { get; set; }

        [ForeignKey("ImageCategoryId")]
        public ImageCategory ImageCategory { get; set; }
    }

    public class ImageCategory
    {
        [Key]
        public string Id { get; set; }

        [Display(Name ="نام فایل" )]
        public string Name { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime Modified { get; set; }

        public ICollection<Image> Images { get; set; }
    }
}