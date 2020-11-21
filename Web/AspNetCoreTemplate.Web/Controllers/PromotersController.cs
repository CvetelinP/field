namespace AspNetCoreTemplate.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using AspNetCoreTemplate.Data;
    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Services.Data;
    using AspNetCoreTemplate.Web.ViewModels.Promoter;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class PromotersController : Controller
    {
        private readonly ApplicationDbContext db;

        private readonly IPromotersService promotersService;
        private readonly IProjectService projectService;
        private readonly IGroupService groupService;
        private readonly IWebHostEnvironment environment;

        public PromotersController(ApplicationDbContext db, IPromotersService promotersService, IProjectService projectService, IGroupService groupService, IWebHostEnvironment environment)
        {
            this.db = db; //TODO:Use Service
            this.promotersService = promotersService;
            this.projectService = projectService;
            this.groupService = groupService;
            this.environment = environment;
        }

        [Authorize]
        public IActionResult Add()
        {
            var viewModel = new IndexPromoterViewModel();
            viewModel.ProjectsItems = this.projectService.GetAllAsKeyValuePair();
            viewModel.GroupsItems = this.groupService.GetAllAsKeyValuePair();
            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(IndexPromoterViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                model.ProjectsItems = this.projectService.GetAllAsKeyValuePair();
                model.GroupsItems = this.groupService.GetAllAsKeyValuePair();
                return this.View(model);
            }

            if (model.ImagePhoto != null)
            {
                string folder = "Promoters/images";
                model.Gallery = new List<GalleryPromoterViewModel>();
                model.ImageUrl = await this.UploadImage(folder, model.ImagePhoto);
            }

            if (model.GalleryFiles != null)
            {
                string folder = "Promoters/gallery/";
                foreach (var file in model.GalleryFiles)
                {
                    var gallery = new GalleryPromoterViewModel()
                    {
                        Name = file.FileName,
                        Url = await this.UploadImage(folder, file),
                    };
                    model.Gallery.Add(gallery);
                }
            }

            await this.promotersService.CreateAsync(model);

            return this.Redirect("/Promoters/All");
        }

        [Authorize]
        public IActionResult All(string searchStringFirstName, int pageNumber = 1, int pageSize = 10)
        {
            int records = (pageSize * pageNumber) - pageSize;
            this.ViewData["CurrentFilter"] = searchStringFirstName;
            var viewModel = new IndexViewModel();

            var promoters = this.promotersService.GetAll<IndexPromoterViewModel>();

            if (!string.IsNullOrEmpty(searchStringFirstName))
            {
                viewModel.Promoters = promoters.Where(x =>
                    x.FirstName.Contains(searchStringFirstName) || x.LastName.Contains(searchStringFirstName));

                return this.View(viewModel);
            }

            viewModel.Promoters = promoters.Skip(records).Take(pageSize);
            return this.View(viewModel);
        }

        [Authorize]
        [IgnoreAntiforgeryToken]
        public ActionResult Profiles(int id)
        {
            var promoter = db.Promoters.Where(x => x.Id == id)
                .Select(model => new IndexPromoterViewModel
                {
                    Id = model.Id,
                    GroupId = model.GroupId,
                    ProjectId = model.ProjectId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Description = model.Description,
                    Email = model.Email,
                    Gender = model.Gender,
                    Skills = model.Skills,
                    Mobile = model.Mobile,
                    Age = model.Age,
                    Language = model.Language,
                    ImageUrl = model.ImageUrl,
                    City = model.City,
                    District = model.District,
                    Gallery = model.PromoterGalleries.Select(g => new GalleryPromoterViewModel
                    {
                        Id = g.Id,
                        Name = g.Name,
                        Url = g.Url,

                    }).ToList(),
                }).FirstOrDefault();

            if (promoter == null)
            {
                this.NotFound();
            }

            return this.View(promoter);
        }

        [Authorize]
        public IActionResult Remove(int id)
        {

            var promoter = this.db.Promoters.FirstOrDefault(x => x.Id == id);

            this.db.Promoters.Remove(promoter);
            this.db.SaveChanges();

            return this.Redirect("/Promoters/All");
        }

        [Authorize]
        [HttpGet]
        public IActionResult Edit(int id)
        {

            var viewModel = this.promotersService.GetById<EditPromoterViewModel>(id);
            viewModel.ProjectsItems = this.projectService.GetAllAsKeyValuePair();
            viewModel.GroupsItems = this.groupService.GetAllAsKeyValuePair();
            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(EditPromoterViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                model.ProjectsItems = this.projectService.GetAllAsKeyValuePair();
                model.GroupsItems = this.groupService.GetAllAsKeyValuePair();

                return this.View(model);
            }
            if (model.ImagePhoto != null)
            {
                string folder = "Promoters/images/";
                model.Gallery = new List<GalleryPromoterViewModel>();
                model.ImageUrl = await this.UploadImage(folder, model.ImagePhoto);
            }

            if (model.GalleryFiles != null)
            {
                string folder = "Promoters/gallery/";
                foreach (var file in model.GalleryFiles)
                {
                    var gallery = new GalleryPromoterViewModel()
                    {
                        Name = file.FileName,
                        Url = await this.UploadImage(folder, file),
                    };
                    model.Gallery.Add(gallery);
                }
            }
            var promoter = this.db.Promoters.FirstOrDefault(x => x.Id == model.Id);
            this.db.Promoters.Remove(promoter);

            await this.promotersService.CreateAsync(model);
            await this.db.SaveChangesAsync();
            return this.Redirect("/Promoters/All");
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
