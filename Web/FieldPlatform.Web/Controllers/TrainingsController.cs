namespace FieldPlatform.Web.Controllers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using FieldPlatform.Data;
    using FieldPlatform.Services.Data;
    using FieldPlatformWeb.ViewModels.Training;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class TrainingsController : Controller
    {
        private readonly IProjectService projectService;
        private readonly ITrainingService trainingService;
        private readonly ApplicationDbContext db;
        private readonly IWebHostEnvironment webHostEnvironment;

        public TrainingsController(
            IProjectService projectService,
            ITrainingService trainingService, ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            this.projectService = projectService;
            this.trainingService = trainingService;
            this.db = db;
            this.webHostEnvironment = webHostEnvironment;
        }

        [Authorize(Roles = "Administrator")]
        [Authorize]
        public IActionResult Add()
        {
            var viewModel = new IndexTrainingInputModel();
            viewModel.ProjectsItems = this.projectService.GetAllAsKeyValuePair();
            return this.View(viewModel);

        }

        [Authorize(Roles = "Administrator")]
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(IndexTrainingInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                model.ProjectsItems = this.projectService.GetAllAsKeyValuePair();
                return this.View(model);
            }

            if (model.TrainingPdf != null)
            {
                string folder = "trainings/pdf/";
                model.TrainingPdfUrl = await this.UploadImage(folder, model.TrainingPdf);
            }

            await this.trainingService.CreateAsync(model);
            return this.Redirect("/Trainings/All");
        }

        [Authorize]
        public IActionResult All(string searchStringFirstName, int id = 1)
        {
            const int itemsPerPage = 10;

            var viewModel = new IndexTrainingViewModel
            {
                ItemsPerPage = itemsPerPage,
                PromotersCount = this.trainingService.GetCount(),
                PageNumber = id,
                Trainings = this.trainingService.GetAll<IndexTrainingInputModel>(id, itemsPerPage),
            };
            this.ViewData["CurrentFilter"] = searchStringFirstName;

            var trainings = this.trainingService.GetAll<IndexTrainingInputModel>();
            if (!string.IsNullOrEmpty(searchStringFirstName))
            {
                viewModel.Trainings = trainings.Where(x =>
                    x.Name.ToLower().Contains(searchStringFirstName));

                return this.View(viewModel);
            }

            viewModel.Trainings = trainings;
            return this.View(viewModel);
        }

        [Authorize(Roles = "Administrator")]
        [Authorize]
        public IActionResult Remove(int id)
        {
            var training = this.db.Trainings.FirstOrDefault(x => x.Id == id);

            this.db.Trainings.Remove(training);
            this.db.SaveChanges();

            return this.Redirect("/Trainings/All");
        }

        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {
            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;
            string serverFolder = Path.Combine(this.webHostEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }
    }
}
