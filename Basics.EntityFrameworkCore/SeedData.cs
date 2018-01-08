using Basics.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Basics.EntityFrameworkCore
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BasicsDBContext(serviceProvider.GetRequiredService<DbContextOptions<BasicsDBContext>>()))
            {
                string departmentId = Guid.NewGuid().ToString("N");
                if (context.Users.Any())
                {
                    return;   // 已经初始化过数据，直接返回
                }
                //增加一个部门
                context.Departments.Add(
                   new Department
                   {
                       Id = departmentId,
                       Name = "集团总部",
                       ParentId = string.Empty
                   }
                );
                //增加一个超级管理员用户
                context.Users.Add(
                     new User
                     {
                         Id= departmentId,
                         UserName = "admin",
                         Password = "123456", //暂不进行加密
                         Name = "超级管理员",
                         DepartmentId = departmentId
                     }
                );
                //增加四个基本功能菜单
                context.Menus.AddRange(
                   new Menu
                   {
                       Id = Guid.NewGuid().ToString("N"),
                       Name = "组织机构管理",
                       Code = "Department",
                       SerialNumber = 0,
                       ParentId = string.Empty,
                       Icon = "fa fa-link"
                   },
                   new Menu
                   {
                       Id = Guid.NewGuid().ToString("N"),
                       Name = "角色管理",
                       Code = "Role",
                       SerialNumber = 1,
                       ParentId = string.Empty,
                       Icon = "fa fa-link"
                   },
                   new Menu
                   {
                       Id = Guid.NewGuid().ToString("N"),
                       Name = "用户管理",
                       Code = "User",
                       SerialNumber = 2,
                       ParentId = string.Empty,
                       Icon = "fa fa-link"
                   },
                   new Menu
                   {
                       Id = Guid.NewGuid().ToString("N"),
                       Name = "功能管理",
                       Code = "Department",
                       SerialNumber = 3,
                       ParentId = string.Empty,
                       Icon = "fa fa-link"
                   }
                );
                context.SaveChanges();
            }
        }
    }
}
