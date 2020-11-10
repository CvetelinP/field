namespace AspNetCoreTemplate.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AspNetCoreTemplate.Services.Data;
    using AspNetCoreTemplate.Web.ViewModels.Client;
    using Microsoft.AspNetCore.Mvc;

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
