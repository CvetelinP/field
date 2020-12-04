namespace FieldPlatform.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;

    using FieldPlatform.Data.Common.Repositories;
    using FieldPlatform.Data.Models;
    using FieldPlatform.Services.Mapping;
    using FieldPlatform.Web.ViewModels;
    using FieldPlatform.Web.ViewModels.Promoter;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IDeletableEntityRepository<Promoter> promoteRepository;

        public HomeController(IDeletableEntityRepository<Promoter> promoteRepository)
        {
            this.promoteRepository = promoteRepository;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel();

            var promoters = this.promoteRepository.All()
                .To<IndexPromoterViewModel>().ToList();

            viewModel.Promoters = promoters;

            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
