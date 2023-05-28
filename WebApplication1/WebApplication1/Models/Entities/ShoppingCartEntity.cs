using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models.Entities
{
    [PrimaryKey(nameof(UserId), nameof(ProductId))]
    public class ShoppingCartEntity
    {
        public string UserId { set; get; } = null!;
        public UserEntity User { get; set; } = null!;
        public string ProductId { set; get; } = null!;
        public ProductEntity Product { set; get; } = null!;
        public int Quantity { set; get; }
    }
}
