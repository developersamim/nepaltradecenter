﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NepalTradeCenterWCFService
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [Range(0, int.MaxValue)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int productId { get; set; }

        [Required(ErrorMessage = "Product Code is required")]
        [StringLength(255, ErrorMessage = "Maximum length is 255")]
        public string productCode { get; set; }

        [StringLength(255, ErrorMessage = "Maximum length is 255")]
        public string name { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(0, int.MaxValue)]
        public int quantity { get; set; }

        [Required(ErrorMessage = "Cost is required")]
        [Range(0, 9999999999999999.99)]
        public decimal cost { get; set; }

        [Required(ErrorMessage = "Selling Price is required")]
        [Range(0, 9999999999999999.99)]
        public decimal sellingPrice { get; set; }

        public DateTime productCreated { get; set; }

        [Range(0, int.MaxValue)]
        public int categoryId { get; set; }

        [Range(0, int.MaxValue)]
        public int status { get; set; }

        public int active { get; set; }

        [StringLength(255)]
        public string imageAddress { get; set; }
    }
}