using AutoMapper;
using Basics.Application.DepartmentApp.Dtos;
using Basics.Application.MenuApp.Dtos;
using Basics.Application.RoleApp.Dtos;
using Basics.Application.UserApp.Dtos;
using Basics.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basics.Application
{
    /// <summary>
    /// Enity与Dto映射
    /// </summary>
    public class BasicsMapper
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Menu, MenuDto>();
                cfg.CreateMap<MenuDto, Menu>();
                cfg.CreateMap<Department, DepartmentDto>();
                cfg.CreateMap<DepartmentDto, Department>();
                cfg.CreateMap<RoleDto, Role>();
                cfg.CreateMap<Role, RoleDto>();
                cfg.CreateMap<RoleMenuDto, RoleMenu>();
                cfg.CreateMap<RoleMenu, RoleMenuDto>();
                cfg.CreateMap<UserDto, User>();
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<UserRoleDto, UserRole>();
                cfg.CreateMap<UserRole, UserRoleDto>();
            });
        }
    }
}
