using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TunifyPrj.Models;
using TunifyPrj.Models.DTOs;
using TunifyPrj.Repositories.Interfaces;

namespace TunifyPrj.Repositories.Services
{
    public class AccountService : IAccount
    {
        private readonly UserManager<CustomUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountService(UserManager<CustomUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<AccountDto> Authentication(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            bool passValidation = await _userManager.CheckPasswordAsync(user, password);

            if (passValidation)
            {
                return new AccountDto()
                {
                    Id = user.Id,
                    Username = user.UserName
                };
            }

            return null;
        }

        public async Task<AccountDto> Register(RegisterDto registerdAccountDto, ModelStateDictionary modelState)
        {
            var user = new CustomUser()
            {
                UserName = registerdAccountDto.UserName,
                Email = registerdAccountDto.Email,

            };

            var result = await _userManager.CreateAsync(user, registerdAccountDto.Password);

            if (result.Succeeded)
            {
                return new AccountDto()
                {
                    Id = user.Id,
                    Username = user.UserName
                };
            }

            foreach (var error in result.Errors)
            {
                var errorCode = error.Code.Contains("Password") ? nameof(registerdAccountDto) :
                                error.Code.Contains("Email") ? nameof(registerdAccountDto) :
                                error.Code.Contains("Username") ? nameof(registerdAccountDto) : "";

                modelState.AddModelError(errorCode, error.Description);
            }
            return null;
        }
        public async Task Logout()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext != null)
            {
                await httpContext.SignOutAsync(IdentityConstants.ApplicationScheme);
            }
        }
    }

}
