using Core.Concretes.Enums;
using System.ComponentModel.DataAnnotations;

namespace Core.Concretes.DTOs
{
    public class RegisterDto
    {
        [Display(Name = "İsim", Prompt = "İsim"), Required]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Soyisim", Prompt = "Soyisim"), Required]
        public string LastName { get; set; } = null!;

        [Required]
        public UserType UserRole { get; set; }

        [Display(Name = "Eposta Adresi", Prompt = "Eposta Adresi"), EmailAddress, Required]
        public string Email { get; set; } = null!;

        [Display(Name = "Parola", Prompt = "Parola"), DataType(DataType.Password), Required]
        public string Password { get; set; } = null!;

        [Display(Name = "Parola Onayla", Prompt = "Parola Onayla"), DataType(DataType.Password), Required, Compare("Password")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
