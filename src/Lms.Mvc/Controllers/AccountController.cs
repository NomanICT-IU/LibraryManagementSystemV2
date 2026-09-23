using Lms.Mvc.Models;
using Lms.Mvc.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lms.Mvc.Controllers
{

    public class AccountController(IAccountService accountService, ITokenCookieService tokenCookieService, IClaimsProvider claimsProvider) : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
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
                tokenCookieService.RemoveTokens();
                tokenCookieService.AddTokens(response.Data.AccessToken, response.Data.AccessTokenExpiresOnUtc, response.Data.RefreshToken);

                var principal = claimsProvider.CreatePrincipal(response.Data.UserId, response.Data.Email, response.Data.AccessToken);

                var authProperties = new AuthenticationProperties
                {
                    ExpiresUtc = response.Data.AccessTokenExpiresOnUtc
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authProperties);

                return RedirectToAction("Index", "Dashboard");
            }
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpGet]
        [ActionName("SignOut")]
        public IActionResult SignOutPage()
        {
            return View("SignOut");
        }

        [HttpPost]
        [ActionName("SignOut")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignOutConfirmed()
        {
            tokenCookieService.RemoveTokens();
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            TempData["Message"] = "You have been signed out.";
            return RedirectToAction(nameof(Login));
        }
    }
}
