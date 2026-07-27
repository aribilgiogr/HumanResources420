using System.ComponentModel.DataAnnotations;

namespace Core.Concretes.DTOs
{
    public class LoginDto
    {
        [Display(Name = "Eposta Adresi", Prompt = "Eposta Adresi"), EmailAddress, Required]
        public string Email { get; set; } = null!;

        [Display(Name = "Parola", Prompt = "Parola"), DataType(DataType.Password), Required]
        public string Password { get; set; } = null!;

        [Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}
