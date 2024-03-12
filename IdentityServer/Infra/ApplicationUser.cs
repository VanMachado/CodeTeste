using Microsoft.AspNetCore.Identity;

namespace CodeChallenge.IdentityServer.Infra
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}