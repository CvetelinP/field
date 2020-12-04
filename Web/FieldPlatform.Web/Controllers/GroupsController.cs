namespace FieldPlatform.Web.Controllers
{
    using System.Linq;

    using FieldPlatform.Data;
    using FieldPlatform.Data.Models;
    using FieldPlatform.Services.Data;
    using FieldPlatform.Services.Mapping;
    using FieldPlatform.Web.ViewModels.Promoter;
    using FieldPlatformWeb.ViewModels.Group;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = "Administrator")]
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
        public IActionResult All(string searchStringFirstName, int id = 1)
        {
            const int itemsPerPage = 10;

            var viewModel = new GroupViewModel()
            {
                ItemsPerPage = itemsPerPage,
                GroupsCount = this.groupService.GetCount(),
                PageNumber = id,
                Groups = this.groupService.GetAll<IndexGroupViewModel>(id, itemsPerPage),
            };
            var group = this.groupService.GetAll<IndexGroupViewModel>();
            this.ViewData["CurrentFilter"] = searchStringFirstName;
            if (!string.IsNullOrEmpty(searchStringFirstName))
            {
                viewModel.Groups = group.Where(x =>
                    x.Name.ToLower().Contains(searchStringFirstName));

                return this.View(viewModel);
            }

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

        public IActionResult GetPromoters(int id)
        {
            var viewModel = new ViewModels.Promoter.IndexViewModel();
            var promoter = this.db.Promoters.Where(x => x.GroupId == id).To<IndexPromoterViewModel>().ToList();

            viewModel.Promoters = promoter;

            return this.View(viewModel);
        }
    }
}
