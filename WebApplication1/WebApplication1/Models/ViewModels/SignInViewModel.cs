using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.ViewModels;

    public class SignInViewModel
{
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "You have to enter your e-mail")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "You have to enter a password")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        [Display(Name = "Keep me logged in")]
        public bool RememberMe { get; set; } = false;
        public string ReturnUrl { get; set; } = "/";

    }