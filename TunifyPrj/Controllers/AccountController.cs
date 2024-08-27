using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TunifyPrj.Models.DTOs;
using TunifyPrj.Repositories.Interfaces;
using TunifyPrj.Repositories.Services;

namespace TunifyPrj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccount accountService;

        public AccountController(IAccount _context)
        {
            accountService = _context;
        }


        [HttpPost("Register")]
        public async Task<ActionResult<AccountDto>> Register(RegisterDto registerdUserDto)
        {


            var user = await accountService.Register(registerdUserDto, this.ModelState);


            if (ModelState.IsValid)
            {
                return user;
            }


            if (user == null)
            {
                return Unauthorized();
            }

            return BadRequest();
        }


        // login 
        [HttpPost("Login")]
        public async Task<ActionResult<AccountDto>> Login(LoginDto loginDto)
        {
            var user = await accountService.Authentication(loginDto.Username, loginDto.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            return user;
        }

        [Authorize]
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await accountService.Logout();
            return Ok(new { message = "Logged out successfully." });
        }
    }
}
