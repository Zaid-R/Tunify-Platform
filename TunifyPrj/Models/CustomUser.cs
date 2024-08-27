using Microsoft.AspNetCore.Identity;

namespace TunifyPrj.Models
{
    //NOTE: You can use IdentityUser directly in the project
    //in case you don't need properties more than the provided in IdentityUser
    public class CustomUser : IdentityUser
    {
        public string? Token { get; set; }
    }
}
