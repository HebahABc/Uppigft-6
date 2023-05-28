using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Helpers.Repositories;
using WebApplication1.Models.Entities;

namespace WebApplication1.Helpers.Services
{
    public class TagServices
    {
        private readonly TagRepo _tagRepo;
        private readonly ProductTagRepo _productTagRepo;

        public TagServices(TagRepo tagRepo, ProductTagRepo productTagRepo )
        {
            _tagRepo = tagRepo;
            _productTagRepo = productTagRepo;
        }

        public async Task<List<SelectListItem>> GetTagAsync()
        {
            var tags = new List<SelectListItem>(); 
            foreach (var tag in await _tagRepo.GetAllAsync() )
            {
                tags.Add(new SelectListItem
                {
                    Value = tag.Id.ToString(),
                    Text = tag.Title
                });
            }
            return tags;
        }

        public async Task<List<SelectListItem>> SetTagAsync(string[] selectedTags)
        {
            var tags = new List<SelectListItem>();
            foreach (var tag in await _tagRepo.GetAllAsync())
            {
                tags.Add(new SelectListItem
                {
                    Value = tag.Id.ToString(),
                    Text = tag.Title,
                    Selected = selectedTags.Contains(tag.Id.ToString())
                });
            }
            return tags;
        }

        public async Task AddProductTagAsync(string Id, string[] tags )
        {
            foreach (var tag in tags)
            {
                await _productTagRepo.AddAsync(new ProductTagEntity
                {
                    ProductId = Id,
                    TagId = int.Parse(tag)
                });
            }
        }
    }
}
