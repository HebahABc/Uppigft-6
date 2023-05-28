using System.ComponentModel.DataAnnotations;
using WebApplication1.Models.Entities;

namespace WebApplication1.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "You have to enter your name")]
        [RegularExpression(@"^[a-ÖA-Ö]+(?:[ é'-][a-ÖA-Ö]+)*$", ErrorMessage = "You have to enter a valid name")]
        public string FirstName { get; set; } = null!;
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "You have to enter your family name")]
        [RegularExpression(@"^[a-ÖA-Ö]+(?:[ é'-][a-ÖA-Ö]+)*$", ErrorMessage = "You have to enter a valid name")]
        public string LastName { get; set; } = null!;
        [Display(Name = "Address")]
        public string Address { get; set; } = null!;
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; } = null!;
        [Display(Name = "City")]
        public string City { get; set; } = null!;
        [Display(Name = "Phone Number")]
        [RegularExpression(@"^\s*(?:\+?(\d{1,3}))?[-. (]*(\d{3})[-. )]*(\d{3})[-. ]*(\d{4})(?: *x(\d+))?\s*$", ErrorMessage = "You have to enter a valid phone number")]
        public string? PhoneNumber { get; set; }
        [Display(Name = "Company Name")]
        public string? CompanyName { get; set; }
        [Display(Name = "E-mail Address")]
        [Required(ErrorMessage = "You have to enter your e-mail")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+.[a-zA-Z]{2}$", ErrorMessage = "You have to enter a valid e-mail address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "You have to enter a password")]
        [RegularExpression(@"^(?=.*?[A-Z])(?=(.*[a-z]){1,})(?=(.*[\d]){1,})(?=(.*[\W]){1,})(?!.*\s).{8,}$", ErrorMessage = "Password must be minimum 8 characters and contains at least one uppercase letter, one lowercase letter, one digit and one special character!")]
        public string Password { get; set; } = null!;
        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "You have to confirm your password")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "The password doesn't match")]
        public string ConfirmPassword { get; set; } = null!;
        [Display(Name = "Upload Profile Photo")]
        [DataType(DataType.Upload)]
        public IFormFile? ImgFile { get; set; }

        [Display(Name = "I have read and accepted the terms and conditions")]
        [Required(ErrorMessage = "You have to read and agree to the terms and conditions ")]
        public bool TermsAndAgreements { get; set; } = false;


        public static implicit operator UserEntity(RegisterViewModel model)
        {
            return new UserEntity
            {
                UserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                CompanyName = model.CompanyName,
            };
        }

        public static implicit operator AddressEntity(RegisterViewModel model)
        {
            return new AddressEntity
            {
                Address = model.Address,
                City = model.City,
                PostalCode = model.PostalCode
            };
        }
    }
}
