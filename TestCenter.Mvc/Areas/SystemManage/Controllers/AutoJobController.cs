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
    public class AutoJobController : BaseController
    {
        private AutoJobBLL autoJobBLL = new AutoJobBLL();

        #region 视图功能
        [AuthorizeFilter("system:autojob:view")]
        public IActionResult AutoJobIndex()
        {
            return View();
        }
        public IActionResult AutoJobForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("system:autojob:search")]
        public async Task<IActionResult> GetListJson(AutoJobListParam param)
        {
            TData<List<AutoJobEntity>> obj = await autoJobBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("system:autojob:search")]
        public async Task<IActionResult> GetPageListJson(AutoJobListParam param, Pagination pagination)
        {
            TData<List<AutoJobEntity>> obj = await autoJobBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<IActionResult> GetFormJson(long id)
        {
            TData<AutoJobEntity> obj = await autoJobBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("system:autojob:add,ystem:autojob:edit")]
        public async Task<IActionResult> SaveFormJson(AutoJobEntity entity)
        {
            TData<string> obj = await autoJobBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("system:autojob:delete")]
        public async Task<IActionResult> DeleteFormJson(string ids)
        {
            TData obj = await autoJobBLL.DeleteForm(ids);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("system:autojob:pause")]
        public async Task<IActionResult> ChangeJobStatusJson(AutoJobEntity entity)
        {
            TData obj = await autoJobBLL.ChangeJobStatus(entity);
            return Json(obj);
        }
        #endregion
    }
}
