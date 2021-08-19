using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrigamiEdu.Models;

namespace OrigamiEdu.Areas.Administrator.Controllers
{
    // [Authorize(Roles = "Developer Master")]
    [Area("Administrator")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<AppUser> userManager;

        [TempData]
        public string message { get; set; }

        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult tambah()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> tambah([Bind("RoleName")] createRole _createRole)
        {
            if(ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole{
                    Name = _createRole.RoleName
                };

                IdentityResult identityResult =  await roleManager.CreateAsync(identityRole);

                if(identityResult.Succeeded)
                {
                    message = "Role berhasil disimpan";
                    return RedirectToAction("index");
                }

                foreach (IdentityError err in identityResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, err.Description);
                }
            }
            return View(_createRole);
        }

        [HttpGet]
        public IActionResult index(){
            IOrderedQueryable roles = roleManager.Roles.OrderBy(r => r.Name);
            
            return View(roles);
        }

        public async Task<IActionResult> CariUserYangRolenyaApa(string NamaRole){

            var ambilRole = await roleManager.FindByNameAsync(NamaRole);

            if(ambilRole is null){
                return null;
            }

            var IniNihListUsernya = await userManager.GetUsersInRoleAsync(ambilRole.Name);
            return View(IniNihListUsernya);

        }

        [HttpGet]
        public async Task<IActionResult> edit(string ID)
        {
            var result = await roleManager.FindByIdAsync(ID);

            if(result == null)
            {
                return NotFound($"Role dengan key {ID} tidak dapat ditemukan");
            }

            var model = new editRole{
                idRole = result.Id,
                RoleName = result.Name
            };

            foreach (var user in await userManager.GetUsersInRoleAsync(result.Name))
            {
                model.users.Add(user.UserName);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> edit([Bind("idRole", "RoleName")] editRole _edit)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var role = await roleManager.FindByIdAsync(_edit.idRole);
                    if(role == null)
                    {
                        return NotFound($"ID Not Found");
                    }

                    role.Name = _edit.RoleName;
                    var result = await roleManager.UpdateAsync(role);

                    if(result.Succeeded)
                    {
                        message = $"Role {_edit.RoleName} berhasil disimpan";
                        return RedirectToAction(nameof(index));
                    }
                }
                catch (Exception e)
                {
                    message = $"Role gagal disimpan: {e.Message}";
                    return View(_edit);
                }
            }
            return View(_edit);
        }

        [HttpGet]
        public async Task<IActionResult> manageUserInRole(string roleID)
        {
            try
            {
                ViewBag.roleID = roleID;

                var role = await roleManager.FindByIdAsync(roleID);

                ViewBag.roleName = role.Name;

                if(role == null) return NotFound($"Data {roleID} tidak dapat ditemukan");

                var model = new List<userRoles>();

                foreach (var user in await userManager.Users.ToListAsync())
                {
                    var roleModel = new userRoles{
                        userID = user.Id,
                        username = user.UserName
                    };

                    if(await userManager.IsInRoleAsync(user, role.Name))
                    {
                        roleModel.isSelected = true;
                    }else{
                        roleModel.isSelected = false;
                    }
                    model.Add(roleModel);
                }

                return View(model);
            }
            catch (Exception e)
            {
                message = e.Message;
                return RedirectToAction(nameof(index));
            }
        } 

        [HttpPost]
        public async Task<IActionResult> manageUserInRole([Bind("userID", "username", "isSelected")]List<userRoles> model, string roleID)
        {
            try
            {
                
                var role = await roleManager.FindByIdAsync(roleID);
                if(role == null)
                {
                    return NotFound($"Role {roleID} tidak ditemukan");
                }

                for (int i = 0; i < model.Count; i++)
                {
                    var user = await userManager.FindByIdAsync(model[i].userID);

                    IdentityResult result = null;

                    if(model[i].isSelected && !(await userManager.IsInRoleAsync(user, role.Name)))
                    {
                        result = await userManager.AddToRoleAsync(user, role.Name);
                    }
                    else if(!(model[i].isSelected) && await userManager.IsInRoleAsync(user, role.Name))
                    {
                        result = await userManager.RemoveFromRoleAsync(user, role.Name);
                    }
                    else
                    {
                        continue;
                    }
                }
                return RedirectToAction("edit", new{ ID = roleID});
            }
            catch (Exception e)
            {
                message = e.Message;
                return View(model);
            }
        }

    }
}