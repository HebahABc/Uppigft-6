using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApplication1.Contexts;
using WebApplication1.Models.Objects;
using WebApplication1.Models.Entities;
using WebApplication1.Helpers.Repositories;

namespace WebApplication1.Helpers.Services;

public class ProductServices
{
    private readonly ProductRepo _repo;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public ProductServices(ProductRepo repo, IWebHostEnvironment webHostEnvironment)
    {
        _repo = repo;
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<bool> UploadImgAsync(ProductEntity product, IFormFile img)
    {
        try
        {
            var imagePath = $"{_webHostEnvironment.WebRootPath}/ProductImages/{product.ArticleImg}";
            await img.CopyToAsync(new FileStream(imagePath, FileMode.Create));
            return true;
        }
        catch
        {
            return false;
        }

    }
    public async Task<ProductEntity> CreateAsync(ProductEntity entity)
    {
        var _entity = await _repo.GetAsync(x => x.ArticleNumber == entity.ArticleNumber);
        if (_entity == null)
        {
            _entity = await _repo.AddAsync(entity);
            if (_entity != null)
            {
                return _entity;
            }
        }
        return null!;
    }
}
