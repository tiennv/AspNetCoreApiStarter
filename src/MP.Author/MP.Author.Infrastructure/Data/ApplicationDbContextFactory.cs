

using Microsoft.EntityFrameworkCore;
using MP.Author.Infrastructure.Shared;

namespace MP.Author.Infrastructure.Data
{
    public class ApplicationDbContextFactory : DesignTimeDbContextFactoryBase<ApplicationDbContext>
    {
        protected override ApplicationDbContext CreateNewInstance(DbContextOptions<ApplicationDbContext> options)
        {
            return new ApplicationDbContext(options);
        }

        
    }
}
