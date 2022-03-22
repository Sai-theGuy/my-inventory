using Microsoft.AspNetCore.Identity;

namespace LifeLine.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
