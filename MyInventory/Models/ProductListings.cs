using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LifeLine.Models
{
    public class ProductListings
    {
        [Key, Display(Name = "Listing ID")]
        public int ListingID { get; set; }

        [Required, Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        // must fix retreiving supplierID from suppliers then display to view
        //[Required, Display(Name = "Supplier ID"), ForeignKey("Suppliers,Supplier ID")]
        [Required, Display(Name = "Supplier ID")]
        public int SupplierID { get; set; }

        [Required]
        public ItemType Type { get; set; }

        [Required, Display(Name = "Stocks Left")]
        public int StocksLeft { get; set; }

        [Required, Display(Name = "Measurement Unit")]
        public string UnitMeasurement { get; set; }

        [Required, Display(Name = "Image Path")]
        public string ImagePath { get; set; }

        public static implicit operator List<object>(ProductListings v)
        {
            throw new NotImplementedException();
        }
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
