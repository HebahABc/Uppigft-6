using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApplication1.Contexts;
using WebApplication1.Models.Entities;

namespace WebApplication1.Helpers.Repositories
{
    public class AddressRepo
    {
        private readonly DataContext _context;
        public AddressRepo (DataContext context)
        {
            _context = context;
        }

        public async Task<AddressEntity> AddAsync(AddressEntity entity)
        {
            _context.Set<AddressEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<AddressEntity> GetAsync(Expression<Func<AddressEntity, bool>> expression)
        {
            var entity = await _context.Set<AddressEntity>().FirstOrDefaultAsync(expression);
            if (entity != null)
            {
                return entity;
            }
            return null!;
        }

        public async Task<IEnumerable<AddressEntity>> GetAllAsync()
        {
            return await _context.Set<AddressEntity>().ToListAsync();
        }

        public async Task<IEnumerable<AddressEntity>> GetAllAsync(Expression<Func<AddressEntity, bool>> expression)
        {
            return await _context.Set<AddressEntity>().Where(expression).ToListAsync();
        }

    }
}
