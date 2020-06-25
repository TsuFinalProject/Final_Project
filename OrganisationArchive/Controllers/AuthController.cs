using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OrganisationArchive.DAL.Models;

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



        public IActionResult Login()
        {
            return View();
        }
    }
}