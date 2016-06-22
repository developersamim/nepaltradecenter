using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NepalTradeCenterWebAPI.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int productId { get; set; }
        public string productCode { get; set; }
        public String productName { get; set; }
        public int quantity { get; set; }
        public double initialCost { get; set; }
        public double sellingPrice { get; set; }
        public double profitPercentage { get; set; }
        public string color { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime modifiedDate { get; set; }
        public string modifier { get; set; }
        public bool staus { get; set; }
        public bool isAvailabe { get; set; }
        //public string size { get; set; }
        //public int sizeQty { get; set; }
       
        public int sizeID { get; set; }
        public Size size { get; set; }

        public int categoryID { get; set; }
        public Category category { get; set; }
        public string testfield { get; set; }




    }
}