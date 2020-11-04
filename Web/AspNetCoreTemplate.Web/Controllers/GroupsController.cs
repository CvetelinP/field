using System.ComponentModel;
using System.Linq;
using AspNetCoreTemplate.Data;
using AspNetCoreTemplate.Data.Common.Repositories;
using AspNetCoreTemplate.Data.Models;
using AspNetCoreTemplate.Services.Mapping;
using AspNetCoreTemplate.Web.ViewModels;

namespace AspNetCoreTemplate.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class GroupsController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IDeletableEntityRepository<Group> groupRepository;

        public GroupsController(ApplicationDbContext db, IDeletableEntityRepository<Group> groupRepository)
        {
            this.db = db;
            this.groupRepository = groupRepository;
        }

        public IActionResult Add()
        {
            return this.View();
        }
     
        [HttpPost]
        public IActionResult Add(IndexGroupViewModel model)
        {

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

            var group = this.groupRepository.All()
                .To<IndexGroupViewModel>().ToList();

            viewModel.Groups = group;
            return this.View(viewModel);
        }


    }
}
