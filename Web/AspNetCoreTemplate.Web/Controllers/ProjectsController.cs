using System.Data;
using System.Linq;
using AspNetCoreTemplate.Data.Common.Repositories;
using AspNetCoreTemplate.Data.Models;
using AspNetCoreTemplate.Services.Mapping;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreTemplate.Web.Controllers
{
    using AspNetCoreTemplate.Data;
    using AspNetCoreTemplate.Services.Data;
    using AspNetCoreTemplate.Web.ViewModels.Client;
    using AspNetCoreTemplate.Web.ViewModels.Project;
    using AspNetCoreTemplate.Web.ViewModels.Promoter;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class ProjectsController : Controller
    {
        private readonly IProjectService projectsService;
        private readonly IClientsService clientsService;
        private readonly IDeletableEntityRepository<Promoter> promoteRepository;
        private readonly ApplicationDbContext db;

        public ProjectsController(IProjectService projectsService, IClientsService clientsService,IDeletableEntityRepository<Promoter> promoteRepository,ApplicationDbContext db)
        {
            this.projectsService = projectsService;
            this.clientsService = clientsService;
            this.promoteRepository = promoteRepository;
            this.db = db;
        }

        [Authorize]
        public IActionResult Add()
        {
            var viewModel = new IndexProjectsInputModel();
            viewModel.ClientsItems = this.clientsService.GetAllAsKeyValuePair();
            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task <IActionResult> Add(IndexProjectsInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                model.ClientsItems = this.clientsService.GetAllAsKeyValuePair();
                return this.View(model);
            }

           await this.projectsService.CreateAsync(model);

            return this.Redirect("/Projects/All");

        }

        public IActionResult All()
        {
            var viewModel = new IndexProjectViewModel();

            var projects = this.projectsService.GetAll<IndexProjectsInputModel>();

            viewModel.Projects = projects;
            return this.View(viewModel);
        }

        public IActionResult GetPromoters(int id)
        {
            var viewModel = new IndexViewModel();
            var promoter = db.Promoters.Where(x => x.ProjectId == id).To<IndexPromoterViewModel>().ToList();
            

            viewModel.Promoters = promoter;

            return this.View(viewModel);
        }
    }
}
