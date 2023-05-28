namespace WebApplication1.Models.Objects
{
    public class UserObject
    {
        public string? Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public List<string> RoleName { get; set; } = new List<string>();

    }
}
