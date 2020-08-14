using System.Collections.Generic;
using System.Threading.Tasks;
using TestCenter.Entity;
using TestCenter.Model.Param;
using TestCenter.Service;
using TestCenter.Util.Extension;
using TestCenter.Util.Model;

namespace TestCenter.Business.TestManage
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-08-14 09:26
    /// 描 述：浆站业务类
    /// </summary>
    public class BankBLL
    {
        private BankService bankService = new BankService();

        #region 获取数据
        public async Task<TData<List<BankEntity>>> GetList(BankListParam param)
        {
            TData<List<BankEntity>> obj = new TData<List<BankEntity>>();
            obj.Data = await bankService.GetList(param);
            obj.Total = obj.Data.Count;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<List<BankEntity>>> GetPageList(BankListParam param, Pagination pagination)
        {
            TData<List<BankEntity>> obj = new TData<List<BankEntity>>();
            obj.Data = await bankService.GetPageList(param, pagination);
            obj.Total = pagination.TotalCount;
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData<BankEntity>> GetEntity(long id)
        {
            TData<BankEntity> obj = new TData<BankEntity>();
            obj.Data = await bankService.GetEntity(id);
            if (obj.Data != null)
            {
                obj.Tag = 1;
            }
            return obj;
        }
        #endregion

        #region 提交数据
        public async Task<TData<string>> SaveForm(BankEntity entity)
        {
            TData<string> obj = new TData<string>();
            await bankService.SaveForm(entity);
            obj.Data = entity.Id.ParseToString();
            obj.Tag = 1;
            return obj;
        }

        public async Task<TData> DeleteForm(string ids)
        {
            TData obj = new TData();
            await bankService.DeleteForm(ids);
            obj.Tag = 1;
            return obj;
        }
        #endregion

        #region 私有方法
        #endregion
    }
}
