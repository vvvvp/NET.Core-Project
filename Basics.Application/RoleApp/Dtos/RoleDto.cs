using Basics.Application.ADtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Basics.Application.RoleApp.Dtos
{
    public class RoleDto : BaseDtos
    {
        public string Code { get; set; }

        [Required(ErrorMessage = "角色名称不能为空。")]
        public string Name { get; set; }

        public string CreateUserId { get; set; }

        public string Remarks { get; set; }
    }
}
