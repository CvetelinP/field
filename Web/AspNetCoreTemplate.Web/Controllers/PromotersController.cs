using System.Threading.Tasks;
using AspNetCoreTemplate.Web.ViewModels.Project;

namespace AspNetCoreTemplate.Web.Controllers
{
    using System;
    using System.Linq;

    using AspNetCoreTemplate.Data;
    using AspNetCoreTemplate.Data.Common.Repositories;
    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Data.Models.Enum;
    using AspNetCoreTemplate.Services.Data;
    using AspNetCoreTemplate.Services.Mapping;
    using AspNetCoreTemplate.Web.ViewModels;
    using AspNetCoreTemplate.Web.ViewModels.Group;
    using AspNetCoreTemplate.Web.ViewModels.Promoter;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class PromotersController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IDeletableEntityRepository<Promoter> promoteRepository;
        private readonly IPromotersService promotersService;
        private readonly IProjectService projectService;
        private readonly IGroupService groupService;

        public PromotersController(ApplicationDbContext db, IDeletableEntityRepository<Promoter> promoteRepository, IPromotersService promotersService, IProjectService projectService)
        {
            this.db = db;
            this.promoteRepository = promoteRepository;
            this.promotersService = promotersService;
            this.projectService = projectService;
        }



        [Authorize]
        public IActionResult Add()
        {
            if (!ModelState.IsValid)
            {
                return this.View();
            }

            var projects = this.projectService.GetAll<IndexDropDownProjectViewModel>();

            var viewModel = new AddPromoterInputModel
            {
                Projects = projects,
            };

            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(AddPromoterInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.promotersService.CreateAsync(model);

            return this.Redirect("/Promoters/All");
        }

        [Authorize]
        public IActionResult All()
        {
            var viewModel = new IndexViewModel();

            var promoters = this.promoteRepository.All()
                .To<IndexPromoterViewModel>().ToList();

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
    }
}
