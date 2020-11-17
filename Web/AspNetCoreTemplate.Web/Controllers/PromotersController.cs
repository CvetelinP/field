namespace AspNetCoreTemplate.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using AspNetCoreTemplate.Data;
    using AspNetCoreTemplate.Services.Data;
    using AspNetCoreTemplate.Web.ViewModels.Promoter;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class PromotersController : Controller
    {
        private readonly ApplicationDbContext db;

        private readonly IPromotersService promotersService;
        private readonly IProjectService projectService;
        private readonly IGroupService groupService;

        public PromotersController(ApplicationDbContext db, IPromotersService promotersService, IProjectService projectService, IGroupService groupService)
        {
            this.db = db; //TODO:Use Service
            this.promotersService = promotersService;
            this.projectService = projectService;
            this.groupService = groupService;
        }

        [Authorize]
        public IActionResult Add()
        {
            var viewModel = new IndexPromoterViewModel();
            viewModel.ProjectsItems = this.projectService.GetAllAsKeyValuePair();
            viewModel.GroupsItems = this.groupService.GetAllAsKeyValuePair();
            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(IndexPromoterViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                model.ProjectsItems = this.projectService.GetAllAsKeyValuePair();
                model.GroupsItems = this.groupService.GetAllAsKeyValuePair();
                return this.View(model);
            }

            await this.promotersService.CreateAsync(model);

            return this.Redirect("/Promoters/All");
        }

        [Authorize]
        public IActionResult All(string searchStringFirstName, string searchStringLastName)
        {
            this.ViewData["CurrentFilter"] = searchStringFirstName;
            var viewModel = new IndexViewModel();

            var promoters = this.promotersService.GetAll<IndexPromoterViewModel>();

            if (!string.IsNullOrEmpty(searchStringFirstName))
            {
                viewModel.Promoters = promoters.Where(x =>
                        x.FirstName.Contains(searchStringFirstName) || x.LastName.Contains(searchStringFirstName));

                return this.View(viewModel);
            }

            viewModel.Promoters = promoters;
            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult Profiles(int id)
        {
            var viewModel = this.promotersService.GetById<PromoterProfileViewModel>(id);

            if (viewModel == null)
            {
                this.NotFound();
            }

            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult Remove(int id)
        {

            var promoter = this.db.Promoters.FirstOrDefault(x => x.Id == id);

            this.db.Promoters.Remove(promoter!);
            this.db.SaveChanges();

            return this.Redirect("/Promoters/All");
        }

        [Authorize]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = this.promotersService.GetById<EditPromoterViewModel>(id);
            viewModel.ProjectsItems = this.projectService.GetAllAsKeyValuePair();
            viewModel.GroupsItems = this.groupService.GetAllAsKeyValuePair();
            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(EditPromoterViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                model.ProjectsItems = this.projectService.GetAllAsKeyValuePair();
                model.GroupsItems = this.groupService.GetAllAsKeyValuePair();
                return this.View(model);
            }

            var promoter = this.db.Promoters.FirstOrDefault(x => x.Id == model.Id);
            this.db.Promoters.Remove(promoter);
            await this.promotersService.CreateAsync(model);
            await this.db.SaveChangesAsync();
            return this.Redirect("/Promoters/All");
        }
    }
}
