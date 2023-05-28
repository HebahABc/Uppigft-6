using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Models.Entities;

namespace WebApplication1.Models.DataEntities
{
    public class ContactEntity
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        //public string? UserId { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; } = null!;
        public string? Company { get; set; }
        public string Message { get; set; } = null!;
        public DateTime DateTime { get; set; }
        public bool SaveMe { get; set; } = true;


        

    }
}

