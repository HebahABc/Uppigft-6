using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Helpers.Services;
using WebApplication1.Models.Entities;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly AccountServices _accountServices;
        private readonly SignInManager<UserEntity> _signInManager;

        public AccountController(UserManager<UserEntity> userManager, AccountServices accountServices, SignInManager<UserEntity> signInManager)
        {
            _userManager = userManager;
            _accountServices = accountServices;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await _userManager.Users.AnyAsync(x => x.Email == model.Email))
                {
                    ModelState.AddModelError("", "There is already an account with the same email address");
                    return View(model);
                }
                else
                {
                    if (await _accountServices.SignUpAsync(model))
                        return RedirectToAction("SignIn", "Account");
                    ModelState.AddModelError("", "Something went error, please try again");
                }
            }
            return View(model);
        }


        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (await _accountServices.SignInAsync(model))
                    return LocalRedirect(model.ReturnUrl);
                ModelState.AddModelError("", "E-mail address or password wasn't correct");
            }
            return View(model);
        }


        [Authorize]
        public async Task<IActionResult> SignOutAccount()
        {
            if (_signInManager.IsSignedIn(User))
            {
                await _signInManager.SignOutAsync();
            }
            return RedirectToAction("Index", "Home");
        }

    }
}
