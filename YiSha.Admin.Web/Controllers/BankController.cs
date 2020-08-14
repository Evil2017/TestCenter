using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestCenter.Business.TestManage;
using TestCenter.Entity;
using TestCenter.Model.Param;
using TestCenter.Util.Model;

namespace TestCenter.Admin.Web.Controllers
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-08-14 09:26
    /// 描 述：浆站控制器类
    /// </summary>
   
    public class BankController : BaseController
    {
        private BankBLL bankBLL = new BankBLL();

        #region 视图功能
        [AuthorizeFilter("bank:view")]
        public ActionResult BankIndex()
        {
            return View();
        }

        public ActionResult BankForm()
        {
            return View();
        }
        #endregion

        #region 获取数据
        [HttpGet]
        [AuthorizeFilter("bank:search")]
        public async Task<ActionResult> GetListJson(BankListParam param)
        {
            TData<List<BankEntity>> obj = await bankBLL.GetList(param);
            return Json(obj);
        }

        [HttpGet]
        [AuthorizeFilter("bank:search")]
        public async Task<ActionResult> GetPageListJson(BankListParam param, Pagination pagination)
        {
            TData<List<BankEntity>> obj = await bankBLL.GetPageList(param, pagination);
            return Json(obj);
        }

        [HttpGet]
        public async Task<ActionResult> GetFormJson(long id)
        {
            TData<BankEntity> obj = await bankBLL.GetEntity(id);
            return Json(obj);
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [AuthorizeFilter("bank:add,bank:edit")]
        public async Task<ActionResult> SaveFormJson(BankEntity entity)
        {
            TData<string> obj = await bankBLL.SaveForm(entity);
            return Json(obj);
        }

        [HttpPost]
        [AuthorizeFilter("bank:delete")]
        public async Task<ActionResult> DeleteFormJson(string ids)
        {
            TData obj = await bankBLL.DeleteForm(ids);
            return Json(obj);
        }
        #endregion
    }
}
