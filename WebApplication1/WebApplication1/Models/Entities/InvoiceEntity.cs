using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models.Entities
{
    public class InvoiceEntity
    {
        public string Id { get; set; } = null!;
        [Column(TypeName = "DateTime2")]
        public DateTime DateTime { get; set; }
        [ForeignKey(nameof(Method))]
        public int PaymentMethod { get; set; }
        [ForeignKey(nameof(Status))]
        public int PaymentStatus { get; set; }

        public PaymentMethod Method { get; set; } = null!;
        public PaymentStatus Status { get; set; } = null!;
    }
}
