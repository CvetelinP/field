namespace FieldPlatform.Web.Areas.Administration.Controllers
{
    using FieldPlatform.Common;
    using FieldPlatform.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
