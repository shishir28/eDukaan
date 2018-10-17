using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Monad.EDukaan.Service.Identity.Domain.Entities.Identity;
using Monad.EDukaan.Service.Identity.Domain.Entities;
using System;

namespace Monad.EDukaan.Service.Identity.Infrastructure.Data
{
   public class ApplicationDBContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ResourceType>(b =>
            {
                b.HasKey(u => u.Id);
            });

            modelBuilder.Entity<ApplicationResource>(b =>
            {
                b.HasKey(u => u.Id);
            });

            modelBuilder.Entity<Activity>(b =>
            {
                b.HasKey(u => u.Id);
            });

            modelBuilder.Entity<RoleRight>(b =>
            {
                b.HasKey(u => u.Id);
            });

            modelBuilder.Entity<ApplicationRole>(b =>
            {
                b.ToTable("ApplicationRole");
                b.HasKey(uc => uc.Id);
            });

            modelBuilder.Entity<ApplicationUser>(b =>
            {
                b.ToTable("ApplicationUser");
                b.HasKey(u => u.Id);                
            });

            modelBuilder.Entity<IdentityUserClaim<string>>(b =>
            {
                b.ToTable("UserClaim");
                b.HasKey(uc => uc.Id);
            });

            modelBuilder.Entity<IdentityUserRole<string>>(b =>
            {
                b.ToTable("UserRole");
                b.HasKey(r => new { r.UserId, r.RoleId });
                
            });
        }
    }
}