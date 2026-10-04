using Microsoft.AspNetCore.Identity;

namespace Inventory_Managment_System_ASPMVC.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
