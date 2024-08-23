using Microsoft.AspNetCore.Mvc.ModelBinding;
using TunifyPrj.Models.DTOs;

namespace TunifyPrj.Repositories.Interfaces
{
    public interface IAccount
    {
        // Add register
        public Task<AccountDto> Register(RegisterDto registerdAccountDto, ModelStateDictionary modelState);


        // Add login 
        public Task<AccountDto> Authentication(string username, string password);
        public Task Logout();
    }
}
