using Inventory_Managment_System_ASPMVC.Models;
using Inventory_Managment_System_ASPMVC.ViewModel;

namespace Inventory_Managment_System_ASPMVC.Services
{
    public interface IUserManagementService
    {
        Task<bool> CreateUserAsync(UserCreatePageViewModel newUser);
        Task<List<string>> GetRolesAsync();
        Task<List<UserListViewModel>> GetAllUsersAsync();
        Task<UserEditPageViewModel?> GetUserForEditAsync(string id);
        Task<bool> UpdateUserAsync(UserEditPageViewModel userModel);
        Task<bool> DisableUserAsync(string id);
        Task<bool> EnableUserAsync(string id);
    }
}
