using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MP.Author.Core.Domain.Entities;
using MP.Author.Core.Shared;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MP.Author.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(ConfigureUser);
            modelBuilder.Entity<Objects>();
        }

        public void ConfigureUser(EntityTypeBuilder<User> builder)
        {
            var navigation = builder.Metadata.FindNavigation(nameof(User.RefreshTokens));
            //EF access the RefreshTokens collection property through its backing field
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Ignore(b => b.Email);
            builder.Ignore(b => b.PasswordHash);
        }

        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Objects> Objects { get; set; }
        public DbSet<Operations> Operations { get; set; }
        public DbSet<Permissions> Permissions { get; set; }
        public DbSet<Role_Permission> Role_Permission { get; set; }

        public override int SaveChanges()
        {
            AddAuitInfo();
            return base.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            AddAuitInfo();
            return await base.SaveChangesAsync();
        }

        private void AddAuitInfo()
        {
            var entries = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
            /*
            TODO: Remove date
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    ((BaseEntity)entry.Entity).Created = DateTime.UtcNow;
                }
                ((BaseEntity)entry.Entity).Modified = DateTime.UtcNow;
            }*/
        }
    }
}
