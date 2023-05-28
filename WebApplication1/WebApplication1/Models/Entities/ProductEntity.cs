using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Models.DataEntities;

namespace WebApplication1.Models.Entities;

public class ProductEntity
{
    [Key]
    public string ArticleNumber { get; set; } = null!;
    public string ArticleTitle { get; set; } = null!;
    public string? Description { get; set; }
    public int AvilableQuantity { get; set; }
    [Column(TypeName ="money")]
    public decimal Price { get; set; }
    [ForeignKey(nameof(Category))]
    public int CategoryId { get; set; }
    public string ArticleImg { get; set; } = null!;

    public CategoryEntity Category { get; set; } = null!;

    public ICollection<ProductTagEntity> ProductTags { get; set; } = new HashSet<ProductTagEntity>();

}
