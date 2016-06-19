using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NepalTradeCenterWebAPI.Models
{
    public class Admin : User
    {
        public string firstname { get; set; }
        public string lastname { get; set; }


    }
}