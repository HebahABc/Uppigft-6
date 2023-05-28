using Microsoft.AspNetCore.Mvc;
using WebApplication1.Helpers.Repositories;
using WebApplication1.Helpers.Services;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Controllers
{
    public class ContactController : Controller
    {
        //private readonly ContactServices _contactServices;
        private readonly ContactRepo _contactRepo;

        public ContactController(/*ContactServices contactServices*/ ContactRepo contactRepo)
        {
           // _contactServices = contactServices;
           _contactRepo = contactRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public  async Task<IActionResult> Index(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _contactRepo.AddAsync(model);
                    return RedirectToAction("Index","Home");
                //ModelState.AddModelError("", "Something went wrong");
            }
            return View(model);
        }
    }
}
