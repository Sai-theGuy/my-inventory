using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace LifeLine.Models
{
    public class PurchaseOrders
    {
        [Key]
        public int OrderID { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public DateTime DateCreate { get; set; }
    }
}
