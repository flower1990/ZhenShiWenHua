using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HanHe.IDAL
{
    /// <summary>
    /// 接口基类
    /// <remarks>
    /// 创建：2016.01.08
    /// 修改：2016.01.08
    /// </remarks>
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public interface IBaseRepository<T>
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <param name="isSave">是否保存</param>
        /// <returns>添加后的数据实体</returns>
        T Add(T entity, bool isSave = true);
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sql">存储过程</param>
        /// <param name="param">存储过程参数</param>
        /// <returns>添加后的数据实体</returns>
        T Add(string sql, params SqlParameter[] param);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <param name="isSave">是否保存</param>
        /// <returns>是否成功</returns>
        bool Delete(T entity, bool isSave = true);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sql">存储过程</param>
        /// <param name="param">存储过程参数</param>
        /// <returns>是否成功</returns>
        bool Delete(string sql, params SqlParameter[] param);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">查询表达式</param>
        /// <param name="isSave">是否保存</param>
        /// <returns>是否成功</returns>
        bool Delete(Expression<Func<T, bool>> filterExpression, bool isSave = true);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">实体列表</param>
        /// <param name="isSave">是否保存</param>
        /// <returns>是否成功</returns>
        bool Delete(IQueryable<T> query, bool isSave = true);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <param name="isSave">是否保存</param>
        /// <returns>是否成功</returns>
        bool Update(T entity, bool isSave = true);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="query">实体列表</param>
        /// <param name="updateExpression">过滤表达式</param>
        /// <param name="isSave">是否保存</param>
        /// <returns>是否成功</returns>
        bool Update(IQueryable<T> query, Expression<Func<T, T>> updateExpression, bool isSave = true);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="filterExpression">查询表达式</param>
        /// <param name="updateExpression">过滤表达式</param>
        /// <param name="isSave">是否保存</param>
        /// <returns>是否成功</returns>
        bool Update(Expression<Func<T, bool>> filterExpression, Expression<Func<T, T>> updateExpression, bool isSave = true);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <param name="isSave">是否保存</param>
        /// <returns>数据实体</returns>
        T UpdateEntity(T entity);
        /// <summary>
        /// 数据实体列表
        /// </summary>
        IQueryable<T> Entities { get; }
        /// <summary>
        /// 查找数据【优先使用】
        /// </summary>
        /// <param name="ID">主键</param>
        /// <returns>实体</returns>
        T Find(long ID);
        /// <summary>
        /// 查询数据【请优先使用Find(int ID)】
        /// </summary>
        /// <param name="whereLambda">查询表达式</param>
        /// <returns>实体</returns>
        T Find(Expression<Func<T, bool>> whereLambda);
        /// <summary>
        /// 查询记录数
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        /// <returns>记录数</returns>
        int Count(Expression<Func<T, bool>> predicate);
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="anyLambda">查询表达式</param>
        /// <returns>布尔值</returns>
        bool Exist(Expression<Func<T, bool>> anyLambda);
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns>影响的记录数目</returns>
        int Save();
    }
}
