using Basics.Domain.Entities;
using Basics.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basics.EntityFrameworkCore.Repositories
{
    public class MenuRepository : BasicsRepositoryBase<Menu>, IMenuRepository
    {
        public MenuRepository(BasicsDBContext dbcontext) : base(dbcontext)
        {

        }
    }
}
