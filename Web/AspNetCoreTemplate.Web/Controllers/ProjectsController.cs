namespace AspNetCoreTemplate.Web.Controllers
{
    using AspNetCoreTemplate.Data;
    using AspNetCoreTemplate.Services.Data;
    using AspNetCoreTemplate.Web.ViewModels.Client;
    using AspNetCoreTemplate.Web.ViewModels.Project;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class ProjectsController : Controller
    {
        private readonly IProjectService projectsService;
        private readonly IClientsService clientsService;

        public ProjectsController(IProjectService projectsService, IClientsService clientsService)
        {
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
    }
}
