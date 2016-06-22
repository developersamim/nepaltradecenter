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
        public string firstname { get; set; }
        public string lastname { get; set; }
        public DateTime created { get; set; }
        public DateTime modified { get; set; }
        public string modifier { get; set; }
    }
}