using FieldPlatformWeb.ViewModels.ViewModelComponents;

namespace FieldPlatform.Web.ViewComponents
{
    using System.Linq;

    using FieldPlatform.Data;
    using Microsoft.AspNetCore.Mvc;

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
