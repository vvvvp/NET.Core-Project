using Basics.Domain.Entities;
using Basics.Domain.IRepositories;

namespace Basics.EntityFrameworkCore.Repositories
{
    public class DepartmentRepository : BasicsRepositoryBase<Department>, IDepartmentRepository
    {
        public DepartmentRepository(BasicsDBContext dbcontext) : base(dbcontext)
        {

        }
    }
}
