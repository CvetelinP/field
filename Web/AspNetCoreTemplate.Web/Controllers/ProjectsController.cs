using Microsoft.AspNetCore.Authorization;

namespace AspNetCoreTemplate.Web.Controllers
{
    using AspNetCoreTemplate.Data;
    using AspNetCoreTemplate.Services.Data;
    using AspNetCoreTemplate.Web.ViewModels.Client;
    using AspNetCoreTemplate.Web.ViewModels.Project;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IProjectService projectsService;
        private readonly IClientsService clientsService;

        public ProjectsController(ApplicationDbContext db, IProjectService projectsService, IClientsService clientsService)
        {
            this.db = db;
            this.projectsService = projectsService;
            this.clientsService = clientsService;
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
        public IActionResult Add(IndexProjectsInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                model.ClientsItems = this.clientsService.GetAllAsKeyValuePair();
                return this.View(model);
            }

            var project = new Data.Models.Project()
            {

                Name = model.Name,
                Year = model.Year,
                Description = model.Description,
                ClientId = model.ClientId,

            };
            this.db.Projects.Add(project);
            this.db.SaveChanges();

            return this.View();
        }

        public IActionResult All()
        {
            var viewModel = new IndexProjectViewModel();

            var projects = this.projectsService.GetAll<IndexProjectsInputModel>();

            viewModel.Projects = projects;
            return this.View(viewModel);
        }
    }
}
