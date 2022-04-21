using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace LifeLine.Models
{
    public class Suppliers
    {
        [Key]
        public int SupplierID { get; set; }

        [Required, Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Required, Display(Name = "Contact Person")]
        public string ContactPerson { get; set;}

        [Required]
        public string Address { get; set; }

        [Required, Display(Name = "Supplier Type")]
        public SupplierType Type { get; set; }

        [Required, Display(Name = "Status")]
        public SupplierStatus Active { get; set; }
    }

    public enum SupplierType
    {
        Local = 1,
        International = 2
    }

    public enum SupplierStatus
    {
        Active = 1,
        Inactive = 2
    }


}
