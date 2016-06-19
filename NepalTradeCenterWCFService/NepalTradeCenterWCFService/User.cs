using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace NepalTradeCenterWCFService
{
    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userId { get; set; }

        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int status { get; set; }
        public int active { get; set; }
    }
}