using Lms.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lms.Mvc.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserModel model, CancellationToken cancellationToken)
        {
            return View();
        }
    }
}
