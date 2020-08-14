using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestCenter.Data.Repository;
using TestCenter.Entity;
using TestCenter.Model.Param;
using TestCenter.Util;
using TestCenter.Util.Extension;
using TestCenter.Util.Model;

namespace TestCenter.Service
{
    /// <summary>
    /// 创 建：admin
    /// 日 期：2020-08-14 09:26
    /// 描 述：浆站服务类
    /// </summary>
    public class BankService : RepositoryFactory
    {
        #region 获取数据
        public async Task<List<BankEntity>> GetList(BankListParam param)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression);
            return list.ToList();
        }

        public async Task<List<BankEntity>> GetPageList(BankListParam param, Pagination pagination)
        {
            var expression = ListFilter(param);
            var list = await this.BaseRepository().FindList(expression, pagination);
            return list.ToList();
        }

        public async Task<BankEntity> GetEntity(long id)
        {
            return await this.BaseRepository().FindEntity<BankEntity>(id);
        }
        #endregion

        #region 提交数据
        public async Task SaveForm(BankEntity entity)
        {
            if (entity.Id.IsNullOrZero())
            {
                entity.Create();
                await this.BaseRepository().Insert(entity);
            }
            else
            {

                await this.BaseRepository().Update(entity);
            }
        }

        public async Task DeleteForm(string ids)
        {
            long[] idArr = TextHelper.SplitToArray<long>(ids, ',');
            await this.BaseRepository().Delete<BankEntity>(idArr);
        }
        #endregion

        #region 私有方法
        private Expression<Func<BankEntity, bool>> ListFilter(BankListParam param)
        {
            var expression = LinqExtensions.True<BankEntity>();
            if (param != null)
            {
            }
            return expression;
        }
        #endregion
    }
}
