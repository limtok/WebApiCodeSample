using Microsoft.EntityFrameworkCore;

namespace Agency.EntityFramework
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Core.Agent> Agents { get; set; }
        public DbSet<Core.Agency> Agencies { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
