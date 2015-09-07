using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace SinglePageCMS.Models
{
    public class Insight
    {
        public Guid Id { get; set; }

        public string Url { get; set; }

        public string Ip { get; set; }

        public string Browser { get; set; }

        public string UserAgent { get; set; }

        public string LastVisited { get; set; }

        public bool IsUser { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public string PageName { get; set; }

        public DateTime DateTime { get; set; }
    }
}