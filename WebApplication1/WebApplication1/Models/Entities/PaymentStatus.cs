using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Entities
{
    public class PaymentStatus
    {
        [Key]
        public int Id { get; set; }
        public string Status { get; set; } = null!;
    }
}
