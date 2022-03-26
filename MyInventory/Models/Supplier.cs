using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace LifeLine.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierID { get; set; }

        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set;}

        [Required(ErrorMessage = "Required")]
        public string Code { get; set; }

        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Date Modified")]
        public DateTime? DateModified { get; set; }

        [Required(ErrorMessage = "Required")]
        public SupplierType Type { get; set; }
        
        public SupplierStatus Status { get; set; }
    }

    public enum SupplierType
    {
        Local = 1,
        International = 2
    }

    public enum SupplierStatus
    {
        Inactive = 0,
        Active = 1
    }
}
