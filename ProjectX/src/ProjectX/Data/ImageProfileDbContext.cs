using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectX.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ProjectX.Data
{
    public class ImageProfileDbContext : IdentityDbContext<ApplicationUser>
    {
        public ImageProfileDbContext() : 
            base(new DbContextOptionsBuilder<ImageProfileDbContext>().UseSqlServer(Startup.ConnectionString).Options)
        {

        }
        public ImageProfileDbContext(DbContextOptions<ImageProfileDbContext> options) : base(options)
        {

        }

        public DbSet<ImageProfile> ImageProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ImageProfile>().ToTable("ImageProfile");
            modelBuilder.Entity<ApplicationUser>().ToTable("Users", "dbo");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "dbo");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "dbo");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "dbo");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "dbo");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "dbo");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles", "dbo");
        }
    }
}
