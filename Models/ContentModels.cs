using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SinglePageCMS.Models
{
    public class Content
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[a-z0-9- ]+$")]
        [Display(Name = "SEO friendly url: only lowercase, number and dash (-) character allowed")]
        public string Slug { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Html)]
        [AllowHtml]
        public string ContentData { get; set; }

        [DataType(DataType.Html)]
        [AllowHtml]
        public string BackGroundContent { get; set; }

        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        [Required]
        public string Summery { get; set; }

        public string GooglePlusId { get; set; }

        public string Author { get; set; }

        public string Keywords { get; set; }

        public DateTime Modified { get; set; }

        public DateTime CreateTime { get; set; }

        public int CategoryId { get; set; }
 
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }

    public class Blog
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[a-z0-9-]+$")]
        [Display(Name = "SEO friendly url: only lowercase, number and dash (-) character allowed")]
        public string Slug { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [AllowHtml]
        [DataType(DataType.Html)]
        public string ContentData { get; set; }

        [Required]
        public string Summery { get; set; }

        public string GooglePlusId { get; set; }

        public string Author { get; set; }

        public string UserName { get; set; }

        public string UserId { get; set; }

        [Required]
        public string Keywords { get; set; }

        public DateTime Modified { get; set; }

        public DateTime CreateTime { get; set; }
    }
}