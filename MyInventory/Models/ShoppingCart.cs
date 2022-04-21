using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LifeLine.Models
{
    public class ShoppingCart
    {
        [Key]
        public int ShoppingCartID { get; set; }

        [Display(Name = "Listing ID")]
        public int ListingID { get; set; } 

        [Required, Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }
    }

}
