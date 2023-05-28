using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class DeniedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
