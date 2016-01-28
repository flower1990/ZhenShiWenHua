using HanHe.IBLL;
using HanHe.IDAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HanHe.BLL
{
    /// <summary>
    /// 服务基类
    /// <remarks>
    /// 创建：2016.01.08
    /// 修改：2016.01.08
    /// </remarks>
    /// </summary>
    public abstract class BaseService<T> : IBaseService<T> where T : class
    {
        protected IBaseRepository<T> CurrentRepository { get; set; }
        public BaseService(IBaseRepository<T> currentRepository) { CurrentRepository = currentRepository; }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>添加后的数据实体</returns>
        public T Add(T entity) { return CurrentRepository.Add(entity); }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sql">存储过程</param>
        /// <param name="param">存储过程参数</param>
        /// <returns>添加后的数据实体</returns>
        public T Add(string sql, params SqlParameter[] param) { return CurrentRepository.Add(sql, param); }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>是否成功</returns>
        public bool Delete(T entity) { return CurrentRepository.Delete(entity); }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sql">存储过程</param>
        /// <param name="param">存储过程参数</param>
        /// <returns>是否成功</returns>
        public bool Delete(string sql, params SqlParameter[] param) { return CurrentRepository.Delete(sql, param); }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">查询表达式</param>
        /// <param name="isSave">是否保存</param>
        /// <returns>是否成功</returns>
        public bool Delete(Expression<Func<T, bool>> filterExpression) { return CurrentRepository.Delete(filterExpression); }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">实体列表</param>
        /// <param name="isSave">是否保存</param>
        /// <returns>是否成功</returns>
        public bool Delete(IQueryable<T> query) { return CurrentRepository.Delete(query); }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>是否成功</returns>
        public bool Update(T entity) { return CurrentRepository.Update(entity); }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="filterExpression">查询表达式</param>
        /// <param name="updateExpression">过滤表达式</param>
        /// <returns>是否成功</returns>
        public bool Update(Expression<Func<T, bool>> filterExpression, Expression<Func<T, T>> updateExpression) { return CurrentRepository.Update(filterExpression, updateExpression); }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="query">实体列表</param>
        /// <param name="updateExpression">过滤表达式</param>
        /// <param name="isSave">是否保存</param>
        /// <returns>是否成功</returns>
        public bool Update(IQueryable<T> query, Expression<Func<T, T>> updateExpression, bool isSave = true) { return CurrentRepository.Update(query, updateExpression); }
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>数据实体</returns>
        public T UpdateEntity(T entity) { return CurrentRepository.UpdateEntity(entity); }
        /// <summary>
        /// 数据实体列表
        /// </summary>
        public IQueryable<T> Entities { get { return CurrentRepository.Entities; } }
        /// <summary>
        /// 查找数据
        /// </summary>
        /// <param name="ID">主键</param>
        /// <returns>实体</returns>
        public T Find(long ID) { return CurrentRepository.Find(ID); }
        /// <summary>
        /// 查询数据【请优先使用Find(int ID)】
        /// </summary>
        /// <param name="whereLambda">查询表达式</param>
        /// <returns>实体</returns>
        public T Find(Expression<Func<T, bool>> whereLambda) { return CurrentRepository.Find(whereLambda); }
        /// <summary>
        /// 查询记录数
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        /// <returns>记录数</returns>
        public int Count(Expression<Func<T, bool>> predicate) { return CurrentRepository.Count(predicate); }
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="anyLambda">查询表达式</param>
        /// <returns>布尔值</returns>
        public bool Exist(Expression<Func<T, bool>> anyLambda) { return CurrentRepository.Exist(anyLambda); }
        /// <summary>
        /// 获取指定页数据
        /// </summary>
        /// <param name="entitys">数据实体集</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页记录数</param>
        /// <returns></returns>
        public IQueryable<T> PageList(IQueryable<T> entitys, int pageIndex, int pageSize) { return entitys.Skip((pageIndex - 1) * pageSize).Take(pageSize); }
    }
}
