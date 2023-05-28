using System.ComponentModel.DataAnnotations;
using WebApplication1.Models.DataEntities;

namespace WebApplication1.Models.ViewModels
{
    public class ContactViewModel
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Display(Name = "Name*")]
        //[Required(ErrorMessage = "You have to enter your name")]
        //[RegularExpression(@"^[a-ÖA-Ö]+(?:[ é'-][a-ÖA-Ö]+)*$", ErrorMessage = "You have to enter a valid name")]
        public string Name { get; set; } = null!;
        [Display(Name = "Email*")]
        //[Required(ErrorMessage = "You have to enter your e-mail!")]
        //[DataType(DataType.EmailAddress)]
        //[RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+.[a-zA-Z]{2}$", ErrorMessage = "You have to enter a valid e-mail address")]
        public string Email { get; set; } = null!;
        [Display(Name = "Phone Number*")]
        //[Required(ErrorMessage = "You have to enter your phone number")]
        //[RegularExpression(@"^\s*(?:\+?(\d{1,3}))?[-. (]*(\d{3})[-. )]*(\d{3})[-. ]*(\d{4})(?: *x(\d+))?\s*$", ErrorMessage = "You have to enter a valid phone number")]
        public string? PhoneNumber { get; set; }
        [Display(Name = "Company")]
        public string? Company { get; set; }
        [Display(Name = "Message*")]
        //[Required(ErrorMessage = "You have to enter your message")]
        //[RegularExpression(@"^{5,}$", ErrorMessage = "Your message must be at least 5 characters long")]
        public string Message { get; set; } = null!;
        public DateTime DateTime { get; set; }
        public bool SaveMe { get; set; } = true;


        public static implicit operator ContactEntity(ContactViewModel model)
        {
            var entity = new ContactEntity
            {
                //Id = model.Id,
                Name = model.Name,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Company = model.Company,
                Message = model.Message,
                DateTime = DateTime.Now,
                SaveMe = model.SaveMe
            };
            return entity;
        }
    }
}
