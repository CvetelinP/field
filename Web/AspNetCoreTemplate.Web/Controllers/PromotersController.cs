using AspNetCoreTemplate.Services.Data;

namespace AspNetCoreTemplate.Web.Controllers
{
    using System;
    using System.Linq;

    using AspNetCoreTemplate.Data;
    using AspNetCoreTemplate.Data.Common.Repositories;
    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Data.Models.Enum;
    using AspNetCoreTemplate.Services.Mapping;
    using AspNetCoreTemplate.Web.ViewModels;
    using AspNetCoreTemplate.Web.ViewModels.Promoter;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class PromotersController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IDeletableEntityRepository<Promoter> promoteRepository;
        private readonly IPromotersService promotersService;

        public PromotersController(ApplicationDbContext db, IDeletableEntityRepository<Promoter> promoteRepository, IPromotersService promotersService)
        {
            this.db = db;
            this.promoteRepository = promoteRepository;
            this.promotersService = promotersService;
        }

        public ApplicationDbContext Db { get; }

        [Authorize]
        public IActionResult Add()
        {
            return this.View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add(AddPromoterInputModel model)
        {

            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var genderEnum = Enum.Parse<Gender>(model.Gender);
            var promoter = new Promoter
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Description = model.Description,
                Email = model.Email,
                Gender = genderEnum,
                Skills = model.Skills,
                Mobile = model.Mobile,
                Age = model.Age,
                Language = model.Language,
                ImageUrl = model.ImageUrl,
                City = model.City,

            };
            this.db.Promoters.Add(promoter);
            this.db.SaveChanges();
            return this.Redirect("/Promoters/All");
        }

        [Authorize]
        public IActionResult All()
        {
            var viewModel = new IndexViewModel();

            var promoters = this.promoteRepository.All()
                .To<IndexPromoterViewModel>().ToList();

            viewModel.Promoters = promoters;

            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult Profiles(int id)
        {
            var viewModel = this.promotersService.GetById<PromoterProfileViewModel>(id);
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
    }
}
