using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.VisionAuditiva.Data
{
    public class ApplicationContext : IdentityDbContext<IdentityUser>
    {

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            :base(options) { }
    }
}
