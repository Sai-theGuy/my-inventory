using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace LifeLine.Models
{
    public class Item
    {
        [Key]
        public int ItemID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Code { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Required")]
        public decimal Price { get; set; }

        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Date Modified")]
        public DateTime? DateModified { get; set; }

        [Display(Name = "Item Type")]
        public ItemType Type { get; set; }
    }

    public enum ItemType
    {
        RawMaterials = 1,
        Intermediate = 2
    }
}
