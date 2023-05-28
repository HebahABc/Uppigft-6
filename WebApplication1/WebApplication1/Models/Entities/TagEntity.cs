namespace WebApplication1.Models.Entities
{
    public class TagEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;


        public ICollection<ProductTagEntity> ProductTags { get; set; } = new HashSet<ProductTagEntity>();
    }
}
