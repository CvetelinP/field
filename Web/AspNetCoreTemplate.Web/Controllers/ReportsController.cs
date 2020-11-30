﻿namespace AspNetCoreTemplate.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;

    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Services.Data;
    using AspNetCoreTemplate.Web.ViewModels.Report;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ReportsController : Controller
    {
        private readonly IWebHostEnvironment environment;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IReportService reportService;
        private readonly ITrainingService trainingService;

        public ReportsController(IWebHostEnvironment environment, UserManager<ApplicationUser> userManager, IReportService reportService,ITrainingService trainingService)
        {
            this.environment = environment;
            this.userManager = userManager;
            this.reportService = reportService;
            this.trainingService = trainingService;
        }


        public IActionResult Create()
        {
            var viewModel = new ReportViewModel();
            viewModel.TrainingItems = this.trainingService.GetAllAsKeyValuePair();
            return this.View(viewModel);
        }

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
            await this.reportService.CreateAsync(model);
            ViewBag.message = "Success";
            return this.RedirectToAction("Create");
        }

        public IActionResult GetReport(int id)
        {
            var viewModel = this.reportService.GetById(id);

            if (viewModel == null)
            {
                this.Response.StatusCode = 404;
                return NotFound();
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
