﻿using Microsoft.EntityFrameworkCore;
using CaseMvp.Dtos;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace CaseMvp.Entity
{
    public class CaseMvpDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Skin> Skins { get; set; }
        public DbSet<Case> Cases { get; set; }
        public DbSet<CaseAndSkin> CaseAndSkins { get; set; }

        public CaseMvpDbContext(DbContextOptions<CaseMvpDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var admin = new IdentityRole("admin");
            admin.NormalizedName = "admin";

            var user = new IdentityRole("user");
            user.NormalizedName = "user";

            modelBuilder.Entity<IdentityRole>().HasData(admin, user);
            var hasher = new PasswordHasher<AppUser>();
            var adminPasswordHash = hasher.HashPassword(null, "admin123321");
            var user1 = new AppUser
            {
                Id = "1",
                Name = "admin",
                UserName = "admin@admin.pl",
                NormalizedUserName = "admin@admin.pl",
                Email = "admin@admin.pl",
                PasswordHash = adminPasswordHash,

            };
            var userRole = new IdentityUserRole<string>
            {
                UserId = user1.Id.ToString(),
                RoleId = admin.Id,
            };
            modelBuilder.Entity<AppUser>().HasData(user1);
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRole);
        }
        public DbSet<CaseMvp.Dtos.SkinDto> SkinDto { get; set; } = default!;
        public DbSet<CaseMvp.Dtos.CaseDto> CaseDto { get; set; } = default!;
    }
}
