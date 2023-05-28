using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Entities
{
    public class PaymentMethod
    {
        [Key]
        public int Id { get; set; }
        public string Method { get; set; } = null!;
    }
}
