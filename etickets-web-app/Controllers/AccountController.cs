using etickets_web_app.Data;
using etickets_web_app.Models;
using etickets_web_app.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace etickets_web_app.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _context;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager; 
            _context = context;
        }
        public IActionResult Login()
        {
            var response = new LoginViewModel();

            return View(response);
        }
    }
}
