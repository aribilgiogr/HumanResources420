using Core.Concretes.DTOs;

namespace Web.UI.Models
{
    public class RegisterCompanyViewModel
    {
        public RegisterDto UserInfo { get; set; } = null!;
        public CompanyCreateDto CompanyInfo { get; set; } = null!;

    }
}
