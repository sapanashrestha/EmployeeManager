using System.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Mvc;

namespace EmployeeManager.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ApplicationRoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public ApplicationRoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var role = _roleManager.Roles;
            return View(role);

        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(IdentityRole roles)
        {
            if (!_roleManager.RoleExistsAsync(roles.Name).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(roles.Name)).GetAwaiter().GetResult();
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }

        [HttpPost, ActionName("DeleteRole")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRoleConfirmed(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                var result = await _roleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            else
            {
                ModelState.AddModelError("", "The specified role does not exist.");
            }

            return View(role);
        }
    }
}
