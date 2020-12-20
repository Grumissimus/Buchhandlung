using Microsoft.AspNetCore.Identity;

namespace Buchhandlung.Auth
{
    public class AppRole : IdentityRole<string>
    {
        public AppRole() : base() { }
        public AppRole(string name) : base(name) { }
    }
}
