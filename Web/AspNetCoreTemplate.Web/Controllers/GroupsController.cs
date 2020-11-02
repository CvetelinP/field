namespace AspNetCoreTemplate.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class GroupsController : Controller
    {

        public IActionResult Add()
        {
            return this.View();
        }
    }
}
