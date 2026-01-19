using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MissionConfigManager.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MissionDbContext>
    {
        public MissionDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MissionDbContext>();
            optionsBuilder.UseSqlite("Data Source=mission.db");

            return new MissionDbContext(optionsBuilder.Options);
        }
    }
}
