using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Basics.Application.DepartmentApp;
using Basics.MVC.Models;
using Basics.Application.DepartmentApp.Dtos;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Basics.MVC.Controllers
{
    public class DepartmentController : FonourControllerBase
    {
        private readonly IDepartmentAppService _service;
        public DepartmentController(IDepartmentAppService service)
        {
            _service = service;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 获取功能树JSON数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetTreeData()
        {
            var dtos = _service.GetAllList();
            List<TreeModel> treeModels = new List<TreeModel>();
            foreach (var dto in dtos)
            {
                treeModels.Add(new TreeModel() { Id = dto.Id.ToString(), Text = dto.Name, Parent = dto.ParentId == string.Empty ? "#" : dto.ParentId.ToString() });
            }
            return Json(treeModels);
        }
        /// <summary>
        /// 获取子级列表
        /// </summary>
        /// <returns></returns>
        public IActionResult GetChildrenByParent(string parentId, int startPage, int pageSize)
        {
            int rowCount = 0;
            if (parentId.IndexOf("00000000") >= 0)
            {
                parentId = string.Empty;
            }
            var result = _service.GetChildrenByParent(parentId, startPage, pageSize, out rowCount);
            return Json(new
            {
                rowCount = rowCount,
                pageCount = Math.Ceiling(Convert.ToDecimal(rowCount) / pageSize),
                rows = result,
            });
        }
        /// <summary>
        /// 新增或编辑功能
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public IActionResult Edit(DepartmentDto dto)
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
            if (dto.ParentId.IndexOf("00000000") >= 0)
            {
                dto.ParentId = string.Empty;
            }
            if (_service.InsertOrUpdate(dto))
            {
                return Json(new { Result = "Success" });
            }
            return Json(new { Result = "Faild" });
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
