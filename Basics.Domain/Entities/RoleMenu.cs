using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Basics.Domain.Entities
{
    [Table("RoleMenu")]
    public class RoleMenu
    {
        public string RoleId { get; set; }
        public Role Role { get; set; }

        public string MenuId { get; set; }
        public Menu Menu { get; set; }
    }
}
