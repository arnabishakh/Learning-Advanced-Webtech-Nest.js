using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.DTOs
{
    public class LoginDTO
    {
        public int uid { get; set; }
        public string username { get; set; }
        public string utype { get; set; }
        public string password { get; set; }
    }
}