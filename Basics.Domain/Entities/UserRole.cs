using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Basics.Domain.Entities
{
    [Table("UserRoles")]
    public class UserRole
    {
        public string UserId { get; set; }
        public User User { get; set; }

        public string RoleId { get; set; }
        public Role Role { get; set; }

    }
}
