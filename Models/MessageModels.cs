using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SinglePageCMS.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        public string UserName { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Priority { get; set; }

        public DateTime Date { get; set; }

        public bool Read { get; set; }

        public bool Show { get; set; }
    }
}