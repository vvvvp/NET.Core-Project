using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Basics.Domain.Entities
{
    [Table("Role")]
    public class Role : Entity
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string CreateUserId { get; set; }

        public DateTime? CreateTime { get; set; }

        public string Remarks { get; set; }

        public virtual ICollection<RoleMenu> RoleMenu { get; set; }
    }
}
