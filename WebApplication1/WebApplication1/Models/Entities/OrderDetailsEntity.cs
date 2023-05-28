using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models.Entities
{
    [PrimaryKey(nameof(OrderId), nameof(ProductId))]
    public class OrderDetailsEntity
    {

        public string OrderId { set; get; } = null!;
        public OrderEntity Order { get; set; } = null!;
        public string ProductId { set; get; } = null!;
        public ProductEntity Product { set; get; } = null!;
        public int Quantity { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        [Column(TypeName = "DateTime2")]
        public DateTime DateTime { get; set; }
    }
}
