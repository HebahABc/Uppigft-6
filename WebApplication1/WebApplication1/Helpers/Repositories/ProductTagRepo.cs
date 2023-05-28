using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApplication1.Contexts;
using WebApplication1.Models.Entities;

namespace WebApplication1.Helpers.Repositories
{
    public class ProductTagRepo
    {
        private readonly DataContext _context;
        public ProductTagRepo(DataContext context)
        {
            _context = context;
        }


        public async Task<ProductTagEntity> AddAsync(ProductTagEntity entity)
        {
            _context.Set<ProductTagEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

       public async Task<IEnumerable<ProductTagEntity>> GetAllAsync()
        {
            return await _context.Set<ProductTagEntity>().ToListAsync();
        }

        public async Task<IEnumerable<ProductTagEntity>> GetAllAsync(Expression<Func<ProductTagEntity, bool>> expression)
        {
            return await _context.Set<ProductTagEntity>().Where(expression).ToListAsync();
        }

    }
}

