﻿namespace FieldPlatform.Web.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using FieldPlatform.Data.Models;
    using FieldPlatform.Web.Views.Administrations;
    using FieldPlatformWeb.ViewModels.Admin;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    //[Authorize(Roles = "Administrator")]
    public class AdministrationsController : Controller
    {
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public AdministrationsController(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                ApplicationRole applicationRole = new ApplicationRole()
                {
                    Name = model.RoleName,
                };

                IdentityResult result = await this.roleManager.CreateAsync(applicationRole);

                if (result.Succeeded)
                {
                    return this.Redirect("Index");
                }

                foreach (IdentityError error in result.Errors)
                {
                    this.ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return this.View(model);
        }

        [Authorize]
        [HttpGet]
        public IActionResult ListRoles()
        {
            var roles = this.roleManager.Roles;
            return this.View(roles);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            var role = await this.roleManager.FindByIdAsync(id);

            if (role == null)
            {
                this.ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found";
                return this.NotFound();
            }

            var model = new EditRoleViewModel
            {
                Id = role.Id,
                RoleName = role.Name,
            };

            foreach (var user in this.userManager.Users)
            {
                if (await this.userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName);
                }
            }

            return this.View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            var role = await this.roleManager.FindByIdAsync(model.Id);

            if (role == null)
            {
                this.ViewBag.ErrorMessage = $"Role with Id = {model.Id} cannot be found";
                return this.NotFound();
            }
            else
            {
                role.Name = model.RoleName;

                var result = await this.roleManager.UpdateAsync(role);

                if (result.Succeeded)
                {
                    return this.RedirectToAction("ListRoles");
                }

                foreach (var error in result.Errors)
                {
                    this.ModelState.AddModelError(string.Empty, error.Description);
                }

                return this.View(model);
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(string roleId)
        {
            this.ViewBag.roleId = roleId;

            var role = await this.roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                this.ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";
                return this.NotFound();
            }

            var model = new List<UserRoleViewModel>();

            foreach (var user in this.userManager.Users)
            {
                var userRoleViewModel = new UserRoleViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                };

                if (await this.userManager.IsInRoleAsync(user, role.Name))
                {
                    userRoleViewModel.IsSelected = true;
                }
                else
                {
                    userRoleViewModel.IsSelected = false;
                }

                model.Add(userRoleViewModel);
            }

            return this.View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(List<UserRoleViewModel> model, string roleId)
        {
            var role = await this.roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                this.ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";
                return this.NotFound();
            }

            for (int i = 0; i < model.Count; i++)
            {
                var user = await this.userManager.FindByIdAsync(model[i].UserId);

                IdentityResult result = null;

                if (model[i].IsSelected && !(await this.userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await this.userManager.AddToRoleAsync(user, role.Name);
                }
                else if (!model[i].IsSelected && await this.userManager.IsInRoleAsync(user, role.Name))
                {
                    result = await this.userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }

                if (result.Succeeded)
                {
                    if (i < (model.Count - 1))
                    {
                        continue;
                    }
                    else
                    {
                        return this.RedirectToAction("EditRole", new { Id = roleId });
                    }
                }
            }

            return this.RedirectToAction("EditRole", new { Id = roleId });
        }
    }
}
