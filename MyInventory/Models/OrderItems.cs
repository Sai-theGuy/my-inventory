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
        public int ListingID { get; set; }

        public int Quantity { get; set; }

        public decimal Amount { get; set; }

        public int OrderID { get; set; }

    }


}
