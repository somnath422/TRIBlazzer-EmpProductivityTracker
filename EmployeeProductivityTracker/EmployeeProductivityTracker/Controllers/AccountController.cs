using EmployeeProductivityTracker.Controllers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

public class AccountController : Controller
{
    // GET: Account/Login
    public IActionResult Login(string returnUrl = null)
    {
        if (User.Identity.IsAuthenticated)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        ViewData["ReturnUrl"] = returnUrl;
        return View();
    }

    // POST: Account/Login
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;
        if (!ModelState.IsValid)
        {
            // Placeholder code for user authentication, replace with your auth logic
            var userIsValid = /* your user validation logic here, e.g. */ model.UsernameOrEmail == "user" && model.Password == "pass";

            if (userIsValid)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.UsernameOrEmail),
                    // Add other required claims as needed
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties { IsPersistent = model.RememberMe };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                // Redirect to the original URL or to the home page if returnUrl is null
                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                return RedirectToAction("Index", "Home");
            }

            // If we reach here, user validation failed
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        }

        // Something failed, redisplay the form
        return View(model);
    }

    // GET: Account/Logout
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Login", "Account");
    }
}