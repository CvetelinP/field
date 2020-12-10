namespace FieldPlatform.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using FieldPlatform.Data;
    using FieldPlatform.Data.Common.Repositories;
    using FieldPlatform.Data.Models;
    using FieldPlatform.Services.Data;
    using FieldPlatform.Services.Mapping;
    using FieldPlatform.Web.ViewModels.Promoter;
    using FieldPlatformWeb.ViewModels.Project;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = "Administrator")]
    public class ProjectsController : Controller
    {
        private readonly IProjectService projectsService;
        private readonly IClientsService clientsService;
        private readonly IDeletableEntityRepository<Promoter> promoteRepository;
        private readonly ApplicationDbContext db;
        private readonly IDeletableEntityRepository<Project> projectRepository;

        public ProjectsController(IProjectService projectsService, IClientsService clientsService, IDeletableEntityRepository<Promoter> promoteRepository, ApplicationDbContext db, IDeletableEntityRepository<Project> projectRepository)
        {
            this.projectsService = projectsService;
            this.clientsService = clientsService;
            this.promoteRepository = promoteRepository;
            this.db = db;
            this.projectRepository = projectRepository;
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
        public async Task<IActionResult> Add(IndexProjectsInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                model.ClientsItems = this.clientsService.GetAllAsKeyValuePair();
                return this.View(model);
            }

            var modelName = this.projectRepository.All().FirstOrDefault(x => x.Name == model.Name);
            if (modelName != null)
            {
                return this.View("name is already exist");
            }
            await this.projectsService.CreateAsync(model);

            return this.Redirect("/Projects/All");

        }

        [Authorize]
        public IActionResult All(string searchStringFirstName, int id = 1)
        {
            const int itemsPerPage = 10;

            var viewModel = new IndexProjectViewModel
            {
                ItemsPerPage = itemsPerPage,
                PromotersCount = this.projectsService.GetCount(),
                PageNumber = id,
                Projects = this.projectsService.GetAll<IndexProjectsInputModel>(id, itemsPerPage),
            };
            var projects = this.projectsService.GetAll<IndexProjectsInputModel>(id,itemsPerPage);
            this.ViewData["CurrentFilter"] = searchStringFirstName;
            if (!string.IsNullOrEmpty(searchStringFirstName))
            {
                viewModel.Projects = projects.Where(x =>
                    x.Name.ToLower().Contains(searchStringFirstName));

                return this.View(viewModel);
            }

            return this.View(viewModel);
        }

        public IActionResult GetPromoters(int id)
        {
            var viewModel = new IndexViewModel();
            if (this.db != null)
            {
                var promoter = this.db.Promoters.Where(x => x.ProjectId == id).To<IndexPromoterViewModel>().ToList();

                viewModel.Promoters = promoter;
            }

            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult Remove(int id)
        {
            var project = this.db.Projects.FirstOrDefault(x => x.Id == id);

            this.db.Projects.Remove(project);
            this.db.SaveChanges();

            return this.Redirect("/Projects/All");
        }
    }
}
