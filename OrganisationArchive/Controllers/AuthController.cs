using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.DataTransfer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OrganisationArchive.DAL.Models;
using SharpDX;

namespace OrganisationArchive.Controllers
{
    public class AuthController : Controller
    {

        
        private UserManager<AppUser> userManager;
        private SignInManager<AppUser> signManager;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signManager)
        {
            this.userManager = userManager;
            this.signManager = signManager;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Login userLogin)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await userManager.FindByEmailAsync(userLogin.Email);
                if (user != null)
                {
                    Microsoft.AspNetCore.Identity.SignInResult result = await signManager.PasswordSignInAsync(user.UserName, userLogin.Password, false,false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("People", "Person");
                    }
                }
                ModelState.AddModelError(nameof(Login), "Invalid Email or Password");
                
            }
           
            return View(userLogin);
        }
        public async Task<IActionResult> Logout()
        {
            await signManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}