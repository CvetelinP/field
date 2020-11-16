namespace AspNetCoreTemplate.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using AspNetCoreTemplate.Data;
    using AspNetCoreTemplate.Data.Models.Enum;
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
            this.db = db;

            this.promotersService = promotersService;
            this.projectService = projectService;
            this.groupService = groupService;
        }


        [Authorize]
        public IActionResult Add()
        {
            var viewModel = new AddPromoterInputModel();
            viewModel.ProjectsItems = this.projectService.GetAllAsKeyValuePair();
            viewModel.GroupsItems = this.groupService.GetAllAsKeyValuePair();
            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(AddPromoterInputModel model)
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
            this.ViewData["CurrentFilter1"] = searchStringLastName;
            var viewModel = new IndexViewModel();

            var promoters = this.promotersService.GetAll<IndexPromoterViewModel>();

            //TODO:Make Search work properly;

            if (!string.IsNullOrEmpty(searchStringFirstName) && !string.IsNullOrEmpty(searchStringLastName))
            {
                viewModel.Promoters = promoters.Where(x =>
                        x.FirstName.Contains(searchStringFirstName) || x.LastName.Contains(searchStringLastName));

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

        public IActionResult Edit()
        {
            var viewModel = new EditPromoterViewModel();
            viewModel.ProjectsItems = this.projectService.GetAllAsKeyValuePair();
            viewModel.GroupsItems = this.groupService.GetAllAsKeyValuePair();
            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(int id)
        {
            var model = this.promotersService.GetById<AddPromoterInputModel>(id);          
            var viewModel = new EditPromoterViewModel
            {
                GroupId = model.GroupId,
                ProjectId = model.ProjectId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Description = model.Description,
                Email = model.Email,
                Gender = model.Gender,
                Skills = model.Skills,
                Mobile = model.Mobile,
                Age = model.Age,
                Language = model.Language,
                ExistingPhotoPath = model.ImageUrl,
                City = model.City,
                District = model.District,
            };

            return this.View(viewModel);
        }
    }
}
