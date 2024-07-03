using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Blogger.DTOs
{
    public class DashboardDTO
    {
        public int pid { get; set; }
        public int uid { get; set; }
        public string text { get; set; }
        public Nullable<System.DateTime> date { get; set; }
    }
}