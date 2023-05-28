using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Models.Entities
{
    public class UserEntity : IdentityUser
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set;} = null!;
        public string? CompanyName { get; set; }
        public string? ProfileImgUrl { get; set; }
        public int AddressId { get; set; }
        public ICollection<UserAddressEntity> UserAddresses { get; set; } = new HashSet<UserAddressEntity>();
    }
}
