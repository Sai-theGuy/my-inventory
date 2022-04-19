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

        public string CompanyName { get; set; }

        public string ContactPerson { get; set;}

        public string Address { get; set; }

        public SupplierType Type { get; set; }
        
        public int Active { get; set; }
    }

    public enum SupplierType
    {
        Local = 1,
        International = 2
    }


}
