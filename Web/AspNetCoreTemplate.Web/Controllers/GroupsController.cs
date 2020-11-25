namespace AspNetCoreTemplate.Web.Controllers
{
    using System.Linq;

    using AspNetCoreTemplate.Data;
    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Services.Data;
    using AspNetCoreTemplate.Services.Mapping;
    using AspNetCoreTemplate.Web.ViewModels.Administration.Dashboard;
    using AspNetCoreTemplate.Web.ViewModels.Group;
    using AspNetCoreTemplate.Web.ViewModels.Promoter;
    using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
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

        [Authorize]
        public IActionResult All(int pageNumber = 1, int pageSize = 10)
        {
            int records = (pageSize * pageNumber) - pageSize;
            var viewModel = new GroupViewModel();

            var group = this.groupService.GetAll<IndexGroupViewModel>();

            viewModel.Groups = group.Skip(records).Take(pageSize);
            return this.View(viewModel);
        }

        public IActionResult Remove(int id)
        {
            var group = this.db.Groups.FirstOrDefault(x => x.Id == id);

            this.db.Groups.Remove(group);
            this.db.SaveChanges();

            return this.Redirect("/Groups/All");
        }

        public IActionResult GetPromoters(int id)
        {
            var viewModel = new ViewModels.Promoter.IndexViewModel();
            var promoter = db.Promoters.Where(x => x.GroupId == id).To<IndexPromoterViewModel>().ToList();

            viewModel.Promoters = promoter;

            return this.View(viewModel);
        }
    }
}
