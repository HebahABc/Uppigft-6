using Microsoft.EntityFrameworkCore;


namespace WebApplication1.Models.Entities
{
    [PrimaryKey(nameof(ProductId), nameof(TagId))]
    public class ProductTagEntity
    {
        public string ProductId { set; get; } = null!;
        public ProductEntity Product { get; set; } = null!;
        public int TagId { set; get; }
        public TagEntity Tag { set; get; } = null!;
    }
}
