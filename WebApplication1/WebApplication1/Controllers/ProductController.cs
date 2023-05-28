using Microsoft.AspNetCore.Mvc;
using WebApplication1.Helpers.Repositories;
using WebApplication1.Helpers.Services;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductServices _services;
        private readonly TagServices _tagService;
        private readonly ProductRepo _repo;

        public ProductController(ProductServices services, TagServices tagRepo, ProductRepo productRepo)
        {
            _services = services;
            _tagService = tagRepo;
            _repo = productRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(string Id)
        {
            return View(Id);
        }
        public async Task<IActionResult> AddProduct()
        {
            ViewBag.Tags = await _tagService.GetTagAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductViewModel model, string[] tags)
        {
            if (ModelState.IsValid)
            {
                //Create a product
                var product = await _services.CreateAsync(model);
                if (product != null)
                {
                    if (model.ImgFile != null)
                    {
                        await _services.UploadImgAsync(product, model.ImgFile);
                    }
                    //Add tags to ProductTags
                    await _tagService.AddProductTagAsync(model.ArticleNumber, tags);
                   
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Something went wrong");
            }
            ViewBag.Tags = await _tagService.SetTagAsync(tags);
            return View(model);
        }
    }
}
