using HanHe.IDAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using EntityFramework.Extensions;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace HanHe.DAL
{
    /// <summary>
    /// 仓储基类
    /// <remarks>
    /// 创建：2016.01.08
    /// 修改：2016.01.08
    /// </remarks>
    /// </summary>
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected HanHeDbContext nContext = ContextFactory.GetCurrentContext();

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <param name="isSave">是否保存</param>
        /// <returns>添加后的数据实体</returns>
        public T Add(T entity, bool isSave = true)
        {
            nContext.Set<T>().Add(entity);
            if (isSave) nContext.SaveChanges();
            return entity;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sql">存储过程</param>
        /// <param name="param">存储过程参数</param>
        /// <returns>添加后的数据实体</returns>
        public T Add(string sql, params SqlParameter[] param)
        {
            var entity = nContext.Database.SqlQuery<T>(sql, param).FirstOrDefault();
            return entity;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <param name="isSave">是否保存</param>
        /// <returns>是否成功</returns>
        public bool Delete(T entity, bool isSave = true)
        {
            nContext.Set<T>().Attach(entity);
            nContext.Entry<T>(entity).State = EntityState.Deleted;
            return isSave ? nContext.SaveChanges() > 0 : true;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sql">存储过程</param>
        /// <param name="param">存储过程参数</param>
        /// <returns>是否成功</returns>
        public bool Delete(string sql, params SqlParameter[] param)
        {
            var entity = nContext.Database.SqlQuery<int>(sql, param).FirstOrDefault();
            return entity > 0;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">查询表达式</param>
        /// <param name="isSave">是否保存</param>
        /// <returns>是否成功</returns>
        public bool Delete(Expression<Func<T, bool>> filterExpression, bool isSave = true)
        {
            return isSave ? Entities.Where(filterExpression).Delete() > 0 : true;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">实体列表</param>
        /// <param name="isSave">是否保存</param>
        /// <returns>是否成功</returns>
        public bool Delete(IQueryable<T> query, bool isSave = true)
        {
            int result = Entities.Delete(query);
            return isSave ? result > 0 : true;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <param name="isSave">是否保存</param>
        /// <returns>是否成功</returns>
        public bool Update(T entity, bool isSave = true)
        {
            nContext.Set<T>().Attach(entity);
            nContext.Entry<T>(entity).State = EntityState.Modified;
            return isSave ? nContext.SaveChanges() > 0 : true;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="filterExpression">查询表达式</param>
        /// <param name="updateExpression">过滤表达式</param>
        /// <param name="isSave">是否保存</param>
        /// <returns>是否成功</returns>
        public bool Update(Expression<Func<T, bool>> filterExpression, Expression<Func<T, T>> updateExpression, bool isSave = true)
        {
            return isSave ? Entities.Where(filterExpression).Update(updateExpression) > 0 : true;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="query">实体列表</param>
        /// <param name="updateExpression">过滤表达式</param>
        /// <param name="isSave">是否保存</param>
        /// <returns>是否成功</returns>
        public bool Update(IQueryable<T> query, Expression<Func<T, T>> updateExpression, bool isSave = true)
        {
            return isSave ? Entities.Update(query, updateExpression) > 0 : true;
        }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <param name="isSave">是否保存</param>
        /// <returns>数据实体</returns>
        public T UpdateEntity(T entity)
        {
            nContext.Set<T>().Attach(entity);
            nContext.Entry<T>(entity).State = EntityState.Modified;
            nContext.SaveChanges();
            return entity;
        }
        /// <summary>
        /// 数据实体列表
        /// </summary>
        public IQueryable<T> Entities
        {
            get { return nContext.Set<T>(); }
        }
        /// <summary>
        /// 查找数据【优先使用】
        /// </summary>
        /// <param name="ID">主键</param>
        /// <returns>实体</returns>
        public T Find(long ID)
        {
            return nContext.Set<T>().Find(ID);
        }
        /// <summary>
        /// 查询数据【请优先使用Find(int ID)】
        /// </summary>
        /// <param name="whereLambda">查询表达式</param>
        /// <returns>实体</returns>
        public T Find(Expression<Func<T, bool>> whereLambda)
        {
            T _entity = nContext.Set<T>().FirstOrDefault<T>(whereLambda);
            return _entity;
        }
        /// <summary>
        /// 查询记录数
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        /// <returns>记录数</returns>
        public int Count(Expression<Func<T, bool>> predicate)
        {
            return nContext.Set<T>().Count(predicate);
        }
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="anyLambda">查询表达式</param>
        /// <returns>布尔值</returns>
        public bool Exist(System.Linq.Expressions.Expression<Func<T, bool>> anyLambda)
        {
            return nContext.Set<T>().Any(anyLambda);
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns>影响的记录数目</returns>
        public int Save()
        {
            return nContext.SaveChanges();
        }
    }
}
