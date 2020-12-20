using Microsoft.AspNetCore.Identity;

namespace Buchhandlung.Auth
{
    public class AppUser : IdentityUser
    {
        public AppUser() : base() { }
        public AppUser(string username) : base(username) { }
    }
}
