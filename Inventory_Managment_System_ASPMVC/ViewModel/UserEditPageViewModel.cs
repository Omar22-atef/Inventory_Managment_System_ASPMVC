namespace Inventory_Managment_System_ASPMVC.ViewModel
{
    public class UserEditPageViewModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public List<string> Roles { get; set; } = new();
    }
}
