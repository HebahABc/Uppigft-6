using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Models.Entities;


namespace WebApplication1.Models.ViewModels
{

    public class ProductViewModel
    {
        [Key]
        [Required(ErrorMessage = "You have to enter article number")]
        [Display(Name = "Article Number")]
        public string ArticleNumber { get; set; } = null!;
        [Required(ErrorMessage = "You have to enter article name")]
        [Display(Name = "Article Title")]
        public string ArticleTitle { get; set; } = null!;
        [Display(Name = "Article Description")]
        public string? Description { get; set; }
        //[RegularExpression(@"^\s*(?:\+?(\d{1,3}))?[-. (]*(\d{3})[-. )]*(\d{3})[-. ]*(\d{4})(?: *x(\d+))?\s*$", ErrorMessage = "You have to enter only Id of category")]
        [Display(Name = "Article Category")]
        [Required(ErrorMessage = "You have to enter the category of article")]
        public int ArticleCategory { get; set; }
        [Required(ErrorMessage = "You have to enter the quantity")]
        [Display(Name = "Avilable Quantity")]
        //[RegularExpression(@"^\s*(?:\+?(\d{1,3}))?[-. (]*(\d{3})[-. )]*(\d{3})[-. ]*(\d{4})(?: *x(\d+))?\s*$", ErrorMessage = "You have to enter numbers only")]
        public int AvilableQuantity { get; set; }
        [Required(ErrorMessage = "You have to article price")]
        [Display(Name = "Article Price")]
        //[RegularExpression(@"^\s*(?:\+?(\d{1,3}))?[-. (]*(\d{3})[-. )]*(\d{3})[-. ]*(\d{4})(?: *x(\d+))?\s*$", ErrorMessage = "You have to enter numbers only")]
        public double Price { get; set; }
        [Required(ErrorMessage = "You have to upload article photo")]
        [Display(Name = "Article Photo")]
        [DataType(DataType.Upload)]
        [NotMapped]
        public IFormFile ImgFile { get; set; } = null!;

        public static implicit operator ProductEntity(ProductViewModel model)
        {
            var entity = new ProductEntity
            {
                ArticleNumber = model.ArticleNumber,
                ArticleTitle = model.ArticleTitle,
                Description = model.Description,
                CategoryId = model.ArticleCategory,
                AvilableQuantity = model.AvilableQuantity,
                Price = (decimal)model.Price
            };
            if (model.ImgFile != null)
            {
                entity.ArticleImg = $"{model.ArticleNumber}_{model.ImgFile?.FileName}";
            }
            return entity;
        }
    }
}
