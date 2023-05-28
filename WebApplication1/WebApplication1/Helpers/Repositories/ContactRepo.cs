using WebApplication1.Contexts;
using WebApplication1.Models.DataEntities;
using WebApplication1.Models.Entities;

namespace WebApplication1.Helpers.Repositories
{
    public class ContactRepo
    {
        private readonly DataContext _context;
        public ContactRepo(DataContext context)
        {
            _context = context;
        }

        public async Task<ContactEntity> AddAsync(ContactEntity entity)
        {
            _context.Set<ContactEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
