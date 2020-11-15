namespace AspNetCoreTemplate.Web.Controllers
{
    using System.Threading.Tasks;

    using AspNetCoreTemplate.Services.Data;
    using AspNetCoreTemplate.Web.ViewModels.Training;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class TrainingsController : Controller
    {
        private readonly IProjectService projectService;
        private readonly ITrainingService trainingService;


        public TrainingsController(IProjectService projectService, ITrainingService trainingService)
        {
            this.projectService = projectService;
            this.trainingService = trainingService;
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

        public IActionResult All()
        {
            var viewModel = new IndexTrainingViewModel();

            var trainings = this.trainingService.GetAll<IndexTrainingInputModel>();
            viewModel.Trainings = trainings;
            return this.View(viewModel);
        }
    }
}
