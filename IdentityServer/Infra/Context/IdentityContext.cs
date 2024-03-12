using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CodeChallenge.IdentityServer.Infra.Context
{
    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options)
            : base(options)
        {
        }
    }
}