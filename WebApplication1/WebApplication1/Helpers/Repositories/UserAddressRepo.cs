using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApplication1.Contexts;
using WebApplication1.Models.Entities;

namespace WebApplication1.Helpers.Repositories
{
    public class UserAddressRepo
    {
        private readonly DataContext _context;
        public UserAddressRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<UserAddressEntity> AddAsync(UserAddressEntity entity)
        {
            _context.Set<UserAddressEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<UserAddressEntity> GetAsync(Expression<Func<UserAddressEntity, bool>> expression)
        {
            var entity = await _context.Set<UserAddressEntity>().FirstOrDefaultAsync(expression);
            if (entity != null)
            {
                return entity;
            }
            return null!;
        }

        public async Task<IEnumerable<UserAddressEntity>> GetAllAsync()
        {
            return await _context.Set<UserAddressEntity>().ToListAsync();
        }

        public async Task<IEnumerable<UserAddressEntity>> GetAllAsync(Expression<Func<UserAddressEntity, bool>> expression)
        {
            return await _context.Set<UserAddressEntity>().Where(expression).ToListAsync();
        }

    }
}
