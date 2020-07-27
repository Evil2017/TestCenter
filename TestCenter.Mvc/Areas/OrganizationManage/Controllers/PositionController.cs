﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCenter.Admin.Web.Controllers;
using TestCenter.Business.OrganizationManage;
using TestCenter.Entity.OrganizationManage;
using TestCenter.Model.Param.OrganizationManage;
using TestCenter.Util.Model;

namespace TestCenter.Admin.Web.Areas.OrganizationManage.Controllers
{
    [Area("OrganizationManage")]
    public class PositionController : BaseController
    {
        private PositionBLL positionBLL = new PositionBLL();

        #region 视图功能
        [AuthorizeFilter("organization:position:view")]
        public IActionResult PositionIndex()
        {
            return View();
        }

        public IActionResult PositionForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("organization:position:search,organization:user:view")]
        public async Task<IActionResult> GetListJson(PositionListParam param)
        {
            TData<List<PositionEntity>> obj = await positionBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("organization:position:search,organization:user:view")]
        public async Task<IActionResult> GetPageListJson(PositionListParam param, Pagination pagination)
        {
            TData<List<PositionEntity>> obj = await positionBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<IActionResult> GetFormJson(long id)
        {
            TData<PositionEntity> obj = await positionBLL.GetEntity(id);
            return Json(obj);
        }

        [HttpGet]
        public async Task<IActionResult> GetMaxSortJson()
        {
            TData<int> obj = await positionBLL.GetMaxSort();
            return Json(obj);
        }

        [HttpGet]
        public async Task<IActionResult> GetPositionName(PositionListParam param)
        {
            TData<string> obj = new TData<string>();
            var list = await positionBLL.GetList(param);
            if (list.Tag == 1)
            {
                obj.Data = string.Join(",", list.Data.Select(p => p.PositionName));
                obj.Tag = 1;
            }
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("organization:position:add,organization:position:edit")]
        public async Task<IActionResult> SaveFormJson(PositionEntity entity)
        {
            TData<string> obj = await positionBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("organization:position:delete")]
        public async Task<IActionResult> DeleteFormJson(string ids)
        {
            TData obj = await positionBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}