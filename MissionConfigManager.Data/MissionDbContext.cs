using Microsoft.EntityFrameworkCore;
using MissionConfigManager.Core;

namespace MissionConfigManager.Data
{
    public class MissionDbContext : DbContext
    {
        public MissionDbContext(DbContextOptions<MissionDbContext> options)
            : base(options)
        {
        }

        public DbSet<MissionModule> Modules { get; set; }
        public DbSet<MissionParameter> Parameters { get; set; }
    }
}
