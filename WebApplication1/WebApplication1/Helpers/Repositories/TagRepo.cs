using Microsoft.EntityFrameworkCore;
using WebApplication1.Contexts;
using WebApplication1.Models.Entities;

namespace WebApplication1.Helpers.Repositories
{
    public class TagRepo
    {
        private readonly DataContext _dataContext;

        public TagRepo(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<TagEntity>> GetAllAsync()
        {
            try
            {
                var entities = await _dataContext.Set<TagEntity>().ToListAsync();
                if (entities != null)
                    return entities;
                return null!;
            }
            catch
            {
                return null!;
            }
        }
    }
}
