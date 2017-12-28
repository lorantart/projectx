using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectX.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ProjectX.Data
{
    public class UploadDbContext : IdentityDbContext<ApplicationUser>
    {
        public UploadDbContext() : 
            base(new DbContextOptionsBuilder<UploadDbContext>().UseSqlServer(Startup.ConnectionString).Options)
        {

        }
        public UploadDbContext(DbContextOptions<UploadDbContext> options) : base(options)
        {

        }

        public DbSet<Image> Uploads { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Image>().ToTable("Upload");
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
