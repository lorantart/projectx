using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectX.Models;

namespace ProjectX.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : 
            base(new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(Startup.ConnectionString).Options)
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Image> Images { get; set; }
        public DbSet<ImageProfile> ImageProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().ToTable("Users", "dbo");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "dbo");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "dbo");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "dbo");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "dbo");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "dbo");
            builder.Entity<IdentityRole>().ToTable("Roles", "dbo");
        }
    }
}
