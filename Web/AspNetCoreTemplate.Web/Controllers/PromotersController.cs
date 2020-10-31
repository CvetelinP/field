namespace AspNetCoreTemplate.Web.Controllers
{
    using System;

    using AspNetCoreTemplate.Data;
    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Data.Models.Enum;
    using AspNetCoreTemplate.Web.ViewModels.Promoter;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class PromotersController : Controller
    {
        private readonly ApplicationDbContext db;

        public PromotersController(ApplicationDbContext db)
        {
            this.Db = db;
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
            var genderEnum = Enum.Parse<Gender>(model.Gender);
            var promoter = new Promoter
            {
                Name = model.Name,
                Description = model.Description,
                Email = model.Email,
                Gender = genderEnum,
                Ability = model.Ability,
                Mobile = model.Mobile,
                Age = model.Age,
                Language = model.Language,
                ImageUrl = model.ImageUrl,
            };
            return this.Redirect("/");
            db.Promoters.Add(promoter);
            db.SaveChanges(); 
        }
    }
}
