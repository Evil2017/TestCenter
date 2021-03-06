﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestCenter.Admin.Web.Controllers;
using TestCenter.Business.SystemManage;
using TestCenter.Entity.SystemManage;
using TestCenter.Model.Param.SystemManage;
using TestCenter.Util.Model;

namespace TestCenter.Admin.Web.Areas.SystemManage.Controllers
{
    [Area("SystemManage")]
    public class LogOperateController : BaseController
    {
        private LogOperateBLL logOperateBLL = new LogOperateBLL();

        #region 视图功能
        [AuthorizeFilter("system:logoperate:view")]
        public IActionResult LogOperateIndex()
        {
            return View();
        }

        public IActionResult LogOperateDetail()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("system:logoperate:search")]
        public async Task<IActionResult> GetListJson(LogOperateListParam param)
        {
            TData<List<LogOperateEntity>> obj = await logOperateBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("system:logoperate:search")]
        public async Task<IActionResult> GetPageListJson(LogOperateListParam param, Pagination pagination)
        {
            TData<List<LogOperateEntity>> obj = await logOperateBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<IActionResult> GetFormJson(long id)
        {
            TData<LogOperateEntity> obj = await logOperateBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("system:logoperate:delete")]
        public async Task<IActionResult> DeleteFormJson(string ids)
        {
            TData obj = await logOperateBLL.DeleteForm(ids);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("system:logoperate:delete")]
        public async Task<IActionResult> RemoveAllFormJson()
        {
            TData obj = await logOperateBLL.RemoveAllForm();
            return Json(obj);
        }
        #endregion
    }
}