using InternWork.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternWork.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signManager)
        {
            this.userManager = userManager;
            this.signManager = signManager;
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterUser user)
        {

            if (ModelState.IsValid)
            {
                var emp = new IdentityUser { UserName = user.Username };
                var result = await userManager.CreateAsync(emp, user.Password);

                if (result.Succeeded)
                {
                    await signManager.SignInAsync(emp, isPersistent: false);
                    return RedirectToAction("ViewEmployee", "Employee");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(" ", error.Description);
                }
            }

            return View(user);
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login user, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await signManager.PasswordSignInAsync(user.Username, user.password, user.Rememberme, false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return (LocalRedirect(returnUrl));
                    }
                    else
                    {
                        return (RedirectToAction("Option", "Employee",user));

                    }

                }
                ModelState.AddModelError(string.Empty, "invalid username or password");
            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signManager.SignOutAsync();
            return RedirectToAction("index", "Home");
        }
    }
}
