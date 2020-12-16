namespace FieldPlatform.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using FieldPlatform.Data;
    using FieldPlatform.Data.Models;
    using FieldPlatform.Services.Data;
    using FieldPlatform.Web.ViewModels.Promoter;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    [Authorize(Roles = "Administrator")]
    public class PromotersController : Controller
    {
        private readonly ApplicationDbContext db;

        private readonly IPromotersService promotersService;
        private readonly IProjectService projectService;
        private readonly IGroupService groupService;
        private readonly IWebHostEnvironment environment;

        public PromotersController(ApplicationDbContext db, IPromotersService promotersService, IProjectService projectService, IGroupService groupService, IWebHostEnvironment environment)
        {
            this.db = db; // TODO:Use Service
            this.promotersService = promotersService;
            this.projectService = projectService;
            this.groupService = groupService;
            this.environment = environment;
        }

        [Authorize]
        public IActionResult Add()
        {
            var viewModel = new IndexPromoterViewModel
            {
                ProjectsItems = this.projectService.GetAllAsKeyValuePair(),
                GroupsItems = this.groupService.GetAllAsKeyValuePair(),
            };
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

            await this.promotersService.CreateAsync(model);

            return this.Redirect("/Promoters/All");
        }

        [Authorize]
        public IActionResult All(string searchStringFirstName, int id = 1)
        {
            const int itemsPerPage = 10;

            var viewModel = new IndexViewModel
            {
                ItemsPerPage = itemsPerPage,
                PromotersCount = this.promotersService.GetCount(),
                PageNumber = id,
                Promoters = this.promotersService.GetAll<IndexPromoterViewModel>(id, itemsPerPage),
            };
            this.ViewData["CurrentFilter"] = searchStringFirstName;
            var promoters = this.promotersService.GetAll<IndexPromoterViewModel>(id, itemsPerPage);

            if (!string.IsNullOrEmpty(searchStringFirstName))
            {
                viewModel.Promoters = promoters.Where(x =>
                    x.FirstName.ToLower().Contains(searchStringFirstName) || x.LastName.ToLower().Contains(searchStringFirstName));

                return this.View(viewModel);
            }

            return this.View(viewModel);
        }

        [Authorize]
        [IgnoreAntiforgeryToken]
        public ActionResult Profiles(int id)
        {
            var viewModel = this.promotersService.GetById(id);

            if (viewModel == null)
            {
                this.Response.StatusCode = 404;
                return this.View("ErrorPromoterId");
            }

            return this.View(viewModel);
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
            var viewModel = this.promotersService.GetById(id);
            viewModel.ProjectsItems = this.projectService.GetAllAsKeyValuePair();
            viewModel.GroupsItems = this.groupService.GetAllAsKeyValuePair();
            return this.View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(IndexPromoterViewModel model)
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
            this.db.Promoters.Remove(promoter!);

            await this.promotersService.CreateAsyncEdit(model);
            await this.db.SaveChangesAsync();
            return this.Redirect("/Promoters/All");
        }

        public IActionResult EditPromoter(int id)
        {
            List<Project> projects = this.db.Projects.ToList();
            this.ViewBag.ProjectList = new SelectList(projects, "Id", "Name");
            var viewModel = this.promotersService.GetById(id);
            viewModel.ProjectsItems = this.projectService.GetAllAsKeyValuePair();
            viewModel.GroupsItems = this.groupService.GetAllAsKeyValuePair();

            return this.PartialView($"_EditPromoter", viewModel);
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
