using Lms.Mvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lms.Mvc.Controllers;

public class RoleController(IRolesService rolesService) : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
