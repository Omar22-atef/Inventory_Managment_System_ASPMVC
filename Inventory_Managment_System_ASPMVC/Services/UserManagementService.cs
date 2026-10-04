using Inventory_Managment_System_ASPMVC.Models;
using Inventory_Managment_System_ASPMVC.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Inventory_Managment_System_ASPMVC.Services
{
    public class UserManagementService : IUserManagementService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserManagementService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<bool> CreateUserAsync(UserCreatePageViewModel newUser)
        { 
            if (! await _roleManager.RoleExistsAsync(newUser.Role))
            {
                return false;
            }

            ApplicationUser user = new ApplicationUser()
            {
                FullName = newUser.FullName,
                Email = newUser.Email,
                UserName = newUser.Email
            };

            var result = await _userManager.CreateAsync(user, newUser.Password);
            if (!result.Succeeded)
            {
                return false;
            }

            var roleResult = await _userManager.AddToRoleAsync(user, newUser.Role);
            if (!roleResult.Succeeded) return false;
            return true;
        }

        public async Task<List<string>> GetRolesAsync()
        {
            return await _roleManager.Roles.Select(r => r.Name).ToListAsync();            
        }

        public async Task<List<UserListViewModel>> GetAllUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();

            var result = new List<UserListViewModel>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);

                result.Add(new UserListViewModel
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    Email = user.Email,
                    Roles = roles.ToList(),
                    IsDisabled = user.LockoutEnd.HasValue &&
                    user.LockoutEnd > DateTimeOffset.UtcNow
                });
            }

            return result;
        }

        public async Task<UserEditPageViewModel>? GetUserForEditAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return null;
            }
            var role = (await _userManager.GetRolesAsync(user)).FirstOrDefault();

            var roles = await GetRolesAsync();

            return new UserEditPageViewModel
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Role = role,
                Roles = roles.ToList()
            };
        }
        public async Task<bool> UpdateUserAsync(UserEditPageViewModel userModel)
        {
            var user = await _userManager.FindByIdAsync(userModel.Id);

            if (user == null)
            {
                return false;
            }

            if (!await _roleManager.RoleExistsAsync(userModel.Role))
            {
                return false;
            }

            user.FullName = userModel.FullName;
            user.Email = userModel.Email;
            user.UserName = userModel.Email;

            var updateResult = await _userManager.UpdateAsync(user);

            if (!updateResult.Succeeded)
            {
                return false;
            }

            var currentRoles = await _userManager.GetRolesAsync(user);

            if (currentRoles.Any())
            {
                var removeRolesResult = await _userManager.RemoveFromRolesAsync(
                    user,
                    currentRoles);

                if (!removeRolesResult.Succeeded)
                {
                    return false;
                }
            }

            var addRoleResult = await _userManager.AddToRoleAsync(
                user,
                userModel.Role);

            if (!addRoleResult.Succeeded)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> DisableUserAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return false;
            }

            user.LockoutEnabled = true;
            user.LockoutEnd = DateTimeOffset.MaxValue;

            var result = await _userManager.UpdateAsync(user);

            return result.Succeeded;
        }

        public async Task<bool> EnableUserAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return false;
            }

            user.LockoutEnd = null;

            var result = await _userManager.UpdateAsync(user);

            return result.Succeeded;
        }
    }
}
