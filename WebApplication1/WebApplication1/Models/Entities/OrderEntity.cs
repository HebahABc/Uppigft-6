using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models.Entities
{
    public class OrderEntity
    {
        [Key]
        public string OrderId { get; set; } = null!;
        [ForeignKey(nameof(User))]
        public string CustomerId { get; set; } = null!;
        [ForeignKey(nameof(Status))]
        public int StatusId { get; set; }
        public string InvoiceId { get; set; } = null!;

        public UserEntity User { get; set; } = null!;
        public OrderStatus Status { get; set; } = null!;


        public ICollection<OrderDetailsEntity> Orders { get; set; } = new HashSet<OrderDetailsEntity>();
    }
}
