using Lms.Mvc.Models;
using Lms.Mvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lms.Mvc.Controllers
{
    public class AccountController(IAccountService accountService) : Controller
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
            var response = await accountService.GetAccountByIdAsync(model, cancellationToken);
            if (response.IsError)
            {
                ModelState.AddModelError(string.Empty, response.Message);
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Dashboard");
            }
        }
    }
}
