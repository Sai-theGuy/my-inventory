﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace LifeLine.Models
{
    public class ProductListings

    {
        [Key]
        public int ListingID { get; set; }

        [Required]
        public string ProductName { get; set; } 

        public string Description { get; set; }
    
        public decimal Price { get; set; }    

        public int SupplierID { get; set; }

        public ItemType Type { get; set; }

        public int StocksLeft { get; set; }

        public string UnitMeasurement { get; set; }
    }

    public enum ItemType
    {
        Tablet = 1,
        Liquid = 2,
        Capsules = 3,
        Topical = 4,
        Suppositories = 5,
        Drops = 6,
        Inhalers = 7,
        Injections = 8,
        Implants = 9,
        Buccal = 10

    }
}
