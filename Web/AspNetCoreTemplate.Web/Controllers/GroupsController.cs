﻿using System.ComponentModel;
using System.Linq;
using AspNetCoreTemplate.Data;
using AspNetCoreTemplate.Data.Common.Repositories;
using AspNetCoreTemplate.Data.Models;
using AspNetCoreTemplate.Services.Data;
using AspNetCoreTemplate.Services.Mapping;
using AspNetCoreTemplate.Web.ViewModels;
using AspNetCoreTemplate.Web.ViewModels.Group;

namespace AspNetCoreTemplate.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class GroupsController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IGroupService groupService;


        public GroupsController(ApplicationDbContext db, IGroupService groupService)
        {
            this.db = db;
            this.groupService = groupService;
        }

        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Add(IndexGroupViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }
            var group = new Group
            {
                Name = model.Name,
            };

            this.db.Groups.Add(group);
            this.db.SaveChanges();
            return this.Redirect("/Groups/All");
        }

        public IActionResult All()
        {
           
            var viewModel = new GroupViewModel();

            var group = this.groupService.GetAll<IndexGroupViewModel>();

            viewModel.Groups = group;
            return this.View(viewModel);
        }

        public IActionResult Remove(int id)
        {
            var group = this.db.Groups.FirstOrDefault(x => x.Id == id);

            this.db.Groups.Remove(group);
            this.db.SaveChanges();

            return this.Redirect("/Groups/All");
        }

    }
}
