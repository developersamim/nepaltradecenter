using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NepalTradeCenterWCFService
{
    [Table("Category")]
    public class Category
    {
        [Key]
        [Range(0, int.MaxValue)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int categoryId { get; set; }

        [StringLength(255)]
        public string name { get; set; }

        [Range(0, int.MaxValue)]
        public int parent { get; set; }

        public DateTime created { get; set; }

        [Range(0, int.MaxValue)]
        public int status { get; set; }

        [Range(0, int.MaxValue)]
        public int active { get; set; }
    }
}