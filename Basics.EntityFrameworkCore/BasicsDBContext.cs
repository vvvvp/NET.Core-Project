﻿using Basics.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Basics.EntityFrameworkCore
{
    public class BasicsDBContext: DbContext
    {
        public BasicsDBContext(DbContextOptions<BasicsDBContext> options) : base(options)
        { }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RoleMenu> RoleMenus { get; set; }

        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //UserRole关联配置
            builder.Entity<UserRole>()
              .HasKey(ur => new { ur.UserId, ur.RoleId });

            //RoleMenu关联配置
            builder.Entity<RoleMenu>()
              .HasKey(rm => new { rm.RoleId, rm.MenuId });

            //builder.Entity<RoleMenu>()
            //  .HasOne(rm => rm.Role)
            //  .WithMany(r => r.RoleMenu)
            //  .HasForeignKey(rm => rm.RoleId).HasForeignKey(rm => rm.MenuId);

            //启用string主键类型扩展
            //builder.HasPostgresExtension("uuid-ossp");

            base.OnModelCreating(builder);
        }
    }
}
