using System.ComponentModel.DataAnnotations;

namespace Inventory_Managment_System_ASPMVC.ViewModel
{
    public class CreateCategoryViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(150, ErrorMessage = "Name cannot be longer than 150 characters.")]
        public string Name { get; set; }
        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters.")]
        public string? Description { get; set; }
    }
}
