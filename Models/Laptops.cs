using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopping.Models
{
    [Table("Tbllaptops")]
    public class Laptops
    {
        [Key]
        public int serialNo { get; set; }
        public string Image { get; set; }
        public string ModelName { get; set; }
        public string specification { get; set; }
        public string Colour { get; set; }       
        public double Price { get; set; }
    }
}
