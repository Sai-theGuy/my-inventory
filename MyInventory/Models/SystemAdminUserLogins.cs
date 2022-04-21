using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace LifeLine.Models
{
    public class SystemAdminUserLogins
    {
        [Key]
        public int LoginID { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}