namespace FieldPlatform.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;

    using FieldPlatform.Data.Common.Repositories;
    using FieldPlatform.Data.Models;
    using FieldPlatform.Services.Data;
    using FieldPlatform.Web.ViewModels.Report;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ReportsController : Controller
    {
        private readonly IWebHostEnvironment environment;
        private readonly IReportService reportService;
        private readonly ITrainingService trainingService;
        private readonly IDeletableEntityRepository<Report> reportRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public ReportsController(IWebHostEnvironment environment, IReportService reportService, ITrainingService trainingService, IDeletableEntityRepository<Report> reportRepository, UserManager<ApplicationUser> userManager)
        {
            this.environment = environment;
            this.reportService = reportService;
            this.trainingService = trainingService;
            this.reportRepository = reportRepository;
            this.userManager = userManager;
        }

        public IActionResult Create()
        {
            var viewModel = new ReportViewModel();
            viewModel.TrainingItems = this.trainingService.GetAllAsKeyValuePair();
            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(ReportViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                model.TrainingItems = this.trainingService.GetAllAsKeyValuePair();
                return this.View(model);
            }

            if (model.ReportFile != null)
            {
                string folder = "Reports/file/";
                model.ReportUrl = await this.UploadImage(folder, model.ReportFile);
            }

            if (model.GalleryFiles != null)
            {
                string folder = "Reports/gallery/";
                model.Gallery = new List<GalleryReportViewModel>();
                foreach (var file in model.GalleryFiles)
                {
                    var gallery = new GalleryReportViewModel()
                    {
                        Name = file.FileName,
                        Url = await this.UploadImage(folder, file),
                    };
                    model.Gallery.Add(gallery);
                }
            }

            var user = await this.userManager.GetUserAsync(this.User);
            var currentUsername = await this.userManager.GetUserNameAsync(user);
            var report = new Report
            {
                ReportUrl = model.ReportUrl,
                TrainingId = model.TrainingId,
                UserId = user.Id,
            };

            foreach (var file in model.Gallery)
            {
                report.ReportGalleries.Add(new ReportGallery
                {
                    Name = file.Name,
                    Url = file.Url,
                });
            }

            await this.reportRepository.AddAsync(report);
            await this.reportRepository.SaveChangesAsync();
            this.ViewData["message"] = true;
            return this.Redirect("Thank");
        }

        [Authorize]
        public IActionResult Thank()
        {

            return this.View();
        }

        public IActionResult GetReport(int id)
        {
            var viewModel = this.reportService.GetById(id);

            if (viewModel == null)
            {
                this.Response.StatusCode = 404;
                return this.NotFound();
            }

            return this.View(viewModel);
        }

        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {
            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;
            string serverFolder = Path.Combine(this.environment.WebRootPath, folderPath);
            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }
    }
}
