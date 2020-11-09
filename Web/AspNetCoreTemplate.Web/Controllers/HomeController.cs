using System.Linq;
using AspNetCoreTemplate.Data.Common.Repositories;
using AspNetCoreTemplate.Data.Models;
using AspNetCoreTemplate.Services.Mapping;
using AspNetCoreTemplate.Web.ViewModels.Promoter;

namespace AspNetCoreTemplate.Web.Controllers
{
    using System.Diagnostics;

    using AspNetCoreTemplate.Web.ViewModels;

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
            return this.View();
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
