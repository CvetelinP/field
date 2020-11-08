namespace AspNetCoreTemplate.Web.Controllers
{
    using AspNetCoreTemplate.Data;
    using AspNetCoreTemplate.Web.ViewModels.Project;
    using Microsoft.AspNetCore.Mvc;

    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext db;

        public ProjectsController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Add(IndexProjectsViewModel model)
        {
            var project = new Data.Models.Project()
            {
                Name = model.Name,
                Year = model.Year,

            };
            this.db.Projects.Add(project);
            this.db.SaveChanges();

            return this.Redirect("/");
        }
    }
}
