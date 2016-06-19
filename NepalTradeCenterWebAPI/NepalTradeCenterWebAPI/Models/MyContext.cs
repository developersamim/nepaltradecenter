using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NepalTradeCenterWebAPI.Models
{
    public class MyContext : DbContext
    {
        public MyContext() : base("name=defaultConnection")
        {

        }

        public virtual DbSet<Product> Products { get; set; }
    }
}