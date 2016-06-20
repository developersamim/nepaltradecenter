using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NepalTradeCenter.Models
{
    public abstract class User
    {
        public int userId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}