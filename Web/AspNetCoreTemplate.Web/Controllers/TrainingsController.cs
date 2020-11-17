namespace AspNetCoreTemplate.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using AspNetCoreTemplate.Data;
    using AspNetCoreTemplate.Services.Data;
    using AspNetCoreTemplate.Web.ViewModels.Training;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class TrainingsController : Controller
    {
        private readonly IProjectService projectService;
        private readonly ITrainingService trainingService;
        private readonly ApplicationDbContext db;

        public TrainingsController(IProjectService projectService, ITrainingService trainingService,ApplicationDbContext db)
        {
            this.projectService = projectService;
            this.trainingService = trainingService;
            this.db = db;
        }

        [Authorize]
        public IActionResult Add()
        {
            var viewModel = new IndexTrainingInputModel();
            viewModel.ProjectsItems = this.projectService.GetAllAsKeyValuePair();
            return this.View(viewModel);

        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(IndexTrainingInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                model.ProjectsItems = this.projectService.GetAllAsKeyValuePair();
                return this.View(model);
            }

            await this.trainingService.CreateAsync(model);

            return this.Redirect("/Trainings/All");
        }
        [Authorize]
        public IActionResult All(string searchStringFirstName)
        {
            this.ViewData["CurrentFilter"] = searchStringFirstName;

            var viewModel = new IndexTrainingViewModel();
            var trainings = this.trainingService.GetAll<IndexTrainingInputModel>();
            if (!string.IsNullOrEmpty(searchStringFirstName))
            {
                viewModel.Trainings = trainings.Where(x =>
                    x.Name.Contains(searchStringFirstName));

                return this.View(viewModel);
            }
            viewModel.Trainings = trainings;
            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult Remove(int id)
        {
            var training = this.db.Projects.FirstOrDefault(x => x.Id == id);

            this.db.Projects.Remove(training);
            this.db.SaveChanges();

            return this.Redirect("/Trainings/All");
        }
    }
}
