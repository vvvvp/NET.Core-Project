using Basics.Application.MenuApp.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basics.Application.RoleApp.Dtos
{
    public class RoleMenuDto
    {
        public string RoleId { get; set; }
        public RoleDto Role { get; set; }

        public string MenuId { get; set; }
        public MenuDto Menu { get; set; }
    }
}
