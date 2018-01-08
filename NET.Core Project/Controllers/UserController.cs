using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Basics.Application.UserApp;
using Basics.Application.RoleApp;
using Basics.Application.UserApp.Dtos;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Basics.MVC.Controllers
{
    public class UserController : FonourControllerBase
    {
        private readonly IUserAppService _service;
        private readonly IRoleAppService _roleService;
        public UserController(IUserAppService service, IRoleAppService roleService)
        {
            _service = service;
            _roleService = roleService;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetUserByDepartment(string departmentId, int startPage, int pageSize)
        {
            int rowCount = 0;
            var result = _service.GetUserByDepartment(departmentId, startPage, pageSize, out rowCount);
            var roles = _roleService.GetAllList();
            return Json(new
            {
                rowCount = rowCount,
                pageCount = Math.Ceiling(Convert.ToDecimal(rowCount) / pageSize),
                rows = result,
                roles = roles
            });
        }

        public IActionResult Edit(UserDto dto, string roles)
        {
            try
            {
                if (dto.Id.IndexOf("00000000") >= 0)
                {
                    dto.Id = Guid.NewGuid().ToString("N");
                }
                var userRoles = new List<UserRoleDto>();
                foreach (var role in roles.Split(','))
                {
                    userRoles.Add(new UserRoleDto() { UserId = dto.Id, RoleId = role });
                }
                dto.UserRoles = userRoles;
                var user = _service.InsertOrUpdate(dto);
                return Json(new { Result = "Success" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "Faild", Message = ex.Message });

            }
        }

        public IActionResult DeleteMuti(string ids)
        {
            try
            {
                string[] idArray = ids.Split(',');
                List<string> delIds = new List<string>();
                foreach (string id in idArray)
                {
                    delIds.Add(id);
                }
                _service.DeleteBatch(delIds);
                return Json(new
                {
                    Result = "Success"
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    Result = "Faild",
                    Message = ex.Message
                });
            }
        }
        public IActionResult Delete(string id)
        {
            try
            {
                _service.Delete(id);
                return Json(new
                {
                    Result = "Success"
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    Result = "Faild",
                    Message = ex.Message
                });
            }
        }
        public IActionResult Get(string id)
        {
            var dto = _service.Get(id);
            return Json(dto);
        }
    }
}
