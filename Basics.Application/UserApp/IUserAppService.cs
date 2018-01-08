using Basics.Application.UserApp.Dtos;
using Basics.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basics.Application.UserApp
{
    public interface IUserAppService
    {
        User CheckUser(string userName, string password);

        List<UserDto> GetUserByDepartment(string departmentId, int startPage, int pageSize, out int rowCount);

        UserDto InsertOrUpdate(UserDto dto);

        /// <summary>
        /// 根据Id集合批量删除
        /// </summary>
        /// <param name="ids">Id集合</param>
        void DeleteBatch(List<string> ids);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">Id</param>
        void Delete(string id);

        /// <summary>
        /// 根据Id获取实体
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        UserDto Get(string id);
    }
}
