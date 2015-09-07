using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SinglePageCMS.Models
{
    public class Slider
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string Title { get; set; }

        public string CaptionImg { get; set; }

        public string LinkUrl { get; set; }
    }

    public class IndexContent
    {
        [Key]
        public int Id { get; set; }

        public string Identifier { get; set; }

        public string Slug { get; set; }

        [Required]
        [AllowHtml]
        public string Content { get; set; }

        public bool HasBackground { get; set; }

        public string BackgroundImageUrl { get; set; }
    }

    public class IndexAbout
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Position { get; set; }

        public string ShortDescribtion { get; set; }

        [Required]
        public string LongDescribtion { get; set; }

        [DataType(DataType.ImageUrl)]
        public string UserImageUrl { get; set; }

        [DataType(DataType.ImageUrl)]
        public string RightImageUrl { get; set; }
    }

    public class ContactUs
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }

        public bool Read { get; set; }

        public DateTime? Time { get; set; }
    }
}