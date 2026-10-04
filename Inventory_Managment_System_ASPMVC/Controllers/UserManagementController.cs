using System.Data;
using System.Threading.Tasks;
using Inventory_Managment_System_ASPMVC.Services;
using Inventory_Managment_System_ASPMVC.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_Managment_System_ASPMVC.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class UserManagementController : Controller
    {
        private readonly IUserManagementService _userManagementService;

        public UserManagementController(IUserManagementService userManagementService)
        {
            _userManagementService = userManagementService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var roles = await _userManagementService.GetRolesAsync();

            var model = new UserCreatePageViewModel
            {
                Roles = roles
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserCreatePageViewModel newUser)
        {
            if (!ModelState.IsValid)
            {
                var roles = await _userManagementService.GetRolesAsync();

                var model = new UserCreatePageViewModel
                {
                    FullName = newUser.FullName,
                    Email = newUser.Email,
                    Password = newUser.Password,
                    ConfirmPassword = newUser.ConfirmPassword,
                    Role = newUser.Role,
                    Roles = roles
                };

                return View(model);
            }

            var userCreated = await _userManagementService.CreateUserAsync(newUser);

            if (userCreated)
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Failed To Create User");

            var availableRoles = await _userManagementService.GetRolesAsync();

            var pageModel = new UserCreatePageViewModel
            {
                FullName = newUser.FullName,
                Email = newUser.Email,
                Password = newUser.Password,
                ConfirmPassword = newUser.ConfirmPassword,
                Role = newUser.Role,
                Roles = availableRoles
            };

            return View(pageModel);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await _userManagementService.GetAllUsersAsync();
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userManagementService.GetUserForEditAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var roles = await _userManagementService.GetRolesAsync();
            user.Roles = roles;
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserEditPageViewModel userModel)
        {
            if (!ModelState.IsValid)
            {
                var roles = await _userManagementService.GetRolesAsync();
                userModel.Roles = roles;
                return View(userModel);
            }
            var updateResult = await _userManagementService.UpdateUserAsync(userModel);
            if (updateResult)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Failed To Update User");
            var availableRoles = await _userManagementService.GetRolesAsync();
            userModel.Roles = availableRoles;
            return View(userModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Disable(string id)
        {
            var result = await _userManagementService.DisableUserAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Enable(string id)
        {
            var result = await _userManagementService.EnableUserAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return RedirectToAction("Index");
        }
    }
}
