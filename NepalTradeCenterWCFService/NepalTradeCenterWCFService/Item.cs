using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NepalTradeCenterWCFService
{
    public class Item
    {
        public int itemId { get; set; }
        public Product product { get; set; }
        public int quantity { get; set; }
    }
}