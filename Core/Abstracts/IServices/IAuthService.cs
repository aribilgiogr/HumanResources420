using Core.Concretes.DTOs;
using Core.Concretes.Models;

namespace Core.Abstracts.IServices
{
    public interface IAuthService
    {
        Task<Reply> LoginAsync(LoginDto dto);
        Task LogoutAsync();
        Task<Reply> RegisterAsync(RegisterDto dto, CompanyCreateDto? companyDto = null);
    }
}
