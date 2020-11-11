namespace AspNetCoreTemplate.Web.ViewComponents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AspNetCoreTemplate.Data;
    using AspNetCoreTemplate.Web.ViewModels.ViewModelComponents;
    using EllipticCurve;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;

    public class RegisteredUsersViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext dbContext;

        public RegisteredUsersViewComponent(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IViewComponentResult Invoke(string title)
        {
            var users = this.dbContext.Users.Count();
            var viewModel = new RegisteredUserViewModel
            {
                Title = title,
                Users = users,
            };
            return this.View(viewModel);
        }
    }
}

