using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApplication1.Contexts;
using WebApplication1.Models.Entities;
using WebApplication1.Models.Objects;

namespace WebApplication1.Helpers.Repositories
{
    public class ProductRepo
    {
        private readonly DataContext _context;

        public ProductRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<ProductEntity> AddAsync(ProductEntity entity)
        {
            _context.Set<ProductEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<IEnumerable<ProductEntity>> GetAllAsync()
        {
            var products = await _context.Products.Include(x => x.ProductTags).ThenInclude(x => x.Tag).ToListAsync();
            return products;
        }
        public async Task<ProductEntity> GetAsync(Expression<Func<ProductEntity, bool>> expression)
        {
            var product = await _context.Products.Include(x => x.ProductTags).ThenInclude(x => x.Tag).FirstOrDefaultAsync(expression);
            if (product != null)
            {
                return product;
            }
            return null!;
        }
    }
}
