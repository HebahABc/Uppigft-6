using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models.Entities
{
    [PrimaryKey(nameof(UserId), nameof(AddressId))]
    public class UserAddressEntity
    {
        public string UserId { set; get; } = null!;
        public UserEntity User { get; set; } = null!;
        public int AddressId { set; get; }
        public AddressEntity Address { set; get; } = null!;

    }
}
