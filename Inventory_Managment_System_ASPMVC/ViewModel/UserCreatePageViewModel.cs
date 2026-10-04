using System.ComponentModel.DataAnnotations;

namespace Inventory_Managment_System_ASPMVC.ViewModel
{
    public class UserCreatePageViewModel
    {
        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Role { get; set; }

        public List<string> Roles { get; set; } = new();
    }
}