using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SinglePageCMS.Models
{
    public class Registery
    {
        [Key]
        public string Name { get; set; }

        [AllowHtml]
        public string Value { get; set; }

        public bool IsHtml { get; set; }
    }
}