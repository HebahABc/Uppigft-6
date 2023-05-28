namespace WebApplication1.Models.Entities
{
    public class AddressEntity
    {
        public int Id { get; set; }
        public string Address { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string City { get; set; } = null!;

        public ICollection<UserAddressEntity> UserAddresses  { get; set; } = new HashSet<UserAddressEntity>();
    }
}
