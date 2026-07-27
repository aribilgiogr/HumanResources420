using Core.Abstracts.IServices;
using Core.Concretes.DTOs;
using Core.Concretes.Entities;
using Core.Concretes.Models;
using Microsoft.AspNetCore.Identity;

namespace Business.Services
{
    public class AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) : IAuthService
    {
        public async Task<Reply> LoginAsync(LoginDto dto)
        {
            var result = await signInManager.PasswordSignInAsync(dto.Email, dto.Password, dto.RememberMe, false);
            if (result.Succeeded)
            {
                return Reply.Success();
            }
            else if (result.IsLockedOut)
            {
                return Reply.Fail("User is locked out, try again later.");
            }
            else if (result.IsNotAllowed)
            {
                return Reply.Fail("Login attempt failed!");
            }
            else if (result.RequiresTwoFactor)
            {
                return Reply.Fail("We need TwoFactor validation!");
            }
            else
            {
                return Reply.Fail("Email address of Password not valid!");
            }
        }

        public async Task LogoutAsync()
        {
            await signInManager.SignOutAsync();
        }

        public async Task<Reply> RegisterAsync(RegisterDto dto)
        {
            var user = new AppUser
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                UserRole = dto.UserRole,
                Email = dto.Email,
                UserName = dto.Email
            };

            var result = await userManager.CreateAsync(user, dto.Password);
            if (result.Succeeded)
            {
                return Reply.Success();
            }
            else
            {
                return Reply.Fail(result.Errors.Select(e => e.Description));
            }
        }
    }
}
