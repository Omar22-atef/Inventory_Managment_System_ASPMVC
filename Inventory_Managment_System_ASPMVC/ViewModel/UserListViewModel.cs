namespace Inventory_Managment_System_ASPMVC.ViewModel
{
    public class UserListViewModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; } = new List<string>();
        public bool IsDisabled { get; set; }
    }
}
