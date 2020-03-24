﻿using Microsoft.EntityFrameworkCore;
using AIC.Author.Infrastructure.Shared;

namespace AIC.Author.Infrastructure.Identity
{
    public class AppIdentityDbContextFactory : DesignTimeDbContextFactoryBase<AppIdentityDbContext>
    {
        protected override AppIdentityDbContext CreateNewInstance(DbContextOptions<AppIdentityDbContext> options)
        {
            return new AppIdentityDbContext(options);
        }
    }
}
