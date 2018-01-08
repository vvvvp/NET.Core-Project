using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Basics.Application.RoleApp.Dtos;
using Basics.Application.RoleApp;
using Basics.MVC.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Basics.MVC.Controllers
{
    public class RoleController : FonourControllerBase
    {
        private readonly IRoleAppService _service;
        public RoleController(IRoleAppService service)
        {
            _service = service;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 新增或编辑功能
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public IActionResult Edit(RoleDto dto)
        {
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    Result = "Faild",
                    Message = GetModelStateError()
                });
            }
            if (dto.Id.IndexOf("00000000") >= 0)
            {
                dto.Id = Guid.NewGuid().ToString("N");
            }
            if (_service.InsertOrUpdate(dto))
            {
                return Json(new { Result = "Success" });
            }
            return Json(new { Result = "Faild" });
        }

        public IActionResult GetAllPageList(int startPage, int pageSize)
        {
            int rowCount = 0;
            var result = _service.GetAllPageList(startPage, pageSize, out rowCount);
            return Json(new
            {
                rowCount = rowCount,
                pageCount = Math.Ceiling(Convert.ToDecimal(rowCount) / pageSize),
                rows = result,
            });
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

        /// <summary>
        /// 根据角色获取权限
        /// </summary>
        /// <returns></returns>
        public IActionResult GetMenusByRole(string roleId)
        {
            var dtos = _service.GetAllMenuListByRole(roleId);
            return Json(dtos);
        }

        public IActionResult SavePermission(string roleId, List<RoleMenuDto> roleMenus)
        {
            if (_service.UpdateRoleMenu(roleId, roleMenus))
            {
                return Json(new { Result = "Success" });
            }
            return Json(new { Result = "Faild" });
        }
    }
}
