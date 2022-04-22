using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace LifeLine.Models
{
    public class OrderItems
    {   
        [Key]
        public int Id { get; set; }
        [Required, Display(Name = "Listing ID")]
        public int ListingID { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int OrderID { get; set; }

    }
}
