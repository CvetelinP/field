namespace FieldPlatform.Web.Controllers
{
    using System.Threading.Tasks;

    using FieldPlatform.Services.Data;
    using FieldPlatform.Web.ViewModels.Client;
    using FieldPlatformWeb.ViewModels.Client;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = "Administrator")]
    public class ClientsController : Controller
    {
        private readonly IClientsService clientsService;

        public ClientsController(IClientsService clientsService)
        {
            this.clientsService = clientsService;
        }

        public IActionResult All()
        {
            var viewModel = new IndexClientViewModel();

            var client = this.clientsService.GetAll<IndexClientsInputModel>();

            viewModel.Clients = client;
            return this.View(viewModel);
        }

        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(IndexClientsInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.clientsService.CreateAsync(model);

            return this.Redirect("/Clients/All");
        }
    }
}
