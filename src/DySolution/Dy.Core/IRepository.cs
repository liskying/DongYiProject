using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;

namespace Microsoft.EntityFrameworkCore
{
    /// <summary>
    /// 仓储接口声明.
    /// </summary>
    /// <typeparam name="TEntity">实体类型.</typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// 更改表名
        /// 常用语分表.
        /// </summary>
        /// <param name="table">表名</param>
        /// <remarks>
        /// 这只用于支持同一模型中的多个表,要求表位于同一库中
        /// </remarks>
        void ChangeTable(string table);

        /// <summary>
        /// 同步方式分页查询
        /// </summary>
        /// <param name="predicate">过滤器.</param>
        /// <param name="orderBy">排序器.</param>
        /// <param name="include">导航属性包含器</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">页大小.</param>
        /// <param name="disableTracking">
        /// <c>true</c>禁用对象状态跟踪
        /// <c>false</c>启用对象状态跟踪</param>
        /// <returns>分页查询结果</returns>
        /// <remarks>默认没有启用跟踪查询.</remarks>
        IPagedList<TEntity> GetPagedList(Expression<Func<TEntity, bool>> predicate = null,
                                         Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                         Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                         int pageIndex = 0,
                                         int pageSize = 20,
                                         bool disableTracking = true);

        /// <summary>
        /// 异步方式分页查询
        /// </summary>
        /// <param name="predicate">过滤器.</param>
        /// <param name="orderBy">排序器.</param>
        /// <param name="include">导航属性包含器</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">页大小.</param>
        /// <param name="disableTracking">
        /// <c>true</c>禁用对象状态跟踪
        /// <c>false</c>启用对象状态跟踪</param>
        /// <param name="cancellationToken">在等待任务完成时观察</param>
        /// <returns>返回包含查询结果的Task<{T}></returns>
        /// <remarks>默认没启用跟踪.</remarks>
        Task<IPagedList<TEntity>> GetPagedListAsync(Expression<Func<TEntity, bool>> predicate = null,
                                                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                    Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                                    int pageIndex = 0,
                                                    int pageSize = 20,
                                                    bool disableTracking = true,
                                                    CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 同步方式分页查询
        /// </summary>
        /// <param name="selector">选择器.</param>
        /// <param name="predicate">过滤器.</param>
        /// <param name="orderBy">排序器.</param>
        /// <param name="include">导航属性包含器</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">页大小.</param>
        /// <param name="disableTracking">
        /// <c>true</c>禁用对象状态跟踪
        /// <c>false</c>启用对象状态跟踪</param>
        /// <returns>返回查询结果</returns>
        /// <remarks>默认没启用跟踪.</remarks>
        IPagedList<TResult> GetPagedList<TResult>(Expression<Func<TEntity, TResult>> selector,
                                                  Expression<Func<TEntity, bool>> predicate = null,
                                                  Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                  Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                                  int pageIndex = 0,
                                                  int pageSize = 20,
                                                  bool disableTracking = true) where TResult : class;

        /// <summary>
        /// 异步方式分页查询
        /// </summary>
        /// <param name="selector">选择器.</param>
        /// <param name="predicate">过滤器.</param>
        /// <param name="orderBy">排序器.</param>
        /// <param name="include">导航属性包含器</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">页大小.</param>
        /// <param name="disableTracking">
        /// <c>true</c>禁用对象状态跟踪
        /// <c>false</c>启用对象状态跟踪</param>
        /// <param name="cancellationToken">在等待任务完成时观察</param>
        /// <returns>返回包含查询结果的Task<{T}></returns>
        /// <remarks>默认没启用跟踪.</remarks>
        Task<IPagedList<TResult>> GetPagedListAsync<TResult>(Expression<Func<TEntity, TResult>> selector,
                                                             Expression<Func<TEntity, bool>> predicate = null,
                                                             Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                             Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                                             int pageIndex = 0,
                                                             int pageSize = 20,
                                                             bool disableTracking = true,
                                                             CancellationToken cancellationToken = default(CancellationToken)) where TResult : class;

        /// <summary>
        /// 查询默认第一条实体对象
        /// </summary>
        /// <param name="predicate">过滤器.</param>
        /// <param name="orderBy">排序器.</param>
        /// <param name="include">导航属性包含器</param>
        /// <param name="disableTracking">
        /// <c>true</c>禁用对象状态跟踪
        /// <c>false</c>启用对象状态跟踪</param>
        /// <returns>默认第一条实体对象</returns>
        /// <remarks>默认没启用跟踪</remarks>
        TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate = null,
                                  Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                  Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                  bool disableTracking = true);

        /// <summary>
        /// 查询默认第一条实体对象
        /// </summary>
        /// <param name="selector">选择器.</param>
        /// <param name="predicate">过滤器.</param>
        /// <param name="orderBy">排序器.</param>
        /// <param name="include">导航属性包含器</param>
        /// <param name="disableTracking">
        /// <c>true</c>禁用对象状态跟踪
        /// <c>false</c>启用对象状态跟踪</param>
        /// <returns>默认第一条实体对象</returns>
        /// <remarks>默认没启用跟踪</remarks>
        TResult GetFirstOrDefault<TResult>(Expression<Func<TEntity, TResult>> selector,
                                           Expression<Func<TEntity, bool>> predicate = null,
                                           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                           bool disableTracking = true);

        /// <summary>
        /// 查询默认第一条实体对象
        /// </summary>
        /// <param name="selector">选择器.</param>
        /// <param name="predicate">过滤器.</param>
        /// <param name="orderBy">排序器.</param>
        /// <param name="include">导航属性包含器</param>
        /// <param name="disableTracking">
        /// <c>true</c>禁用对象状态跟踪
        /// <c>false</c>启用对象状态跟踪</param>
        /// <returns>默认带有第一条实体对象的Task<{TResult}></returns>
        /// <remarks>默认没启用跟踪</remarks>
        Task<TResult> GetFirstOrDefaultAsync<TResult>(Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true);

        /// <summary>
        /// 查询默认第一条实体对象
        /// </summary>
        /// <param name="predicate">过滤器.</param>
        /// <param name="orderBy">排序器.</param>
        /// <param name="include">导航属性包含器</param>
        /// <param name="disableTracking">
        /// <c>true</c>禁用对象状态跟踪
        /// <c>false</c>启用对象状态跟踪</param>
        /// <returns>默认带有第一条实体对象的Task<{TResult}></returns>
        /// <remarks>默认没启用跟踪</remarks>
        Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true);

        /// <summary>
        /// SQL查询
        /// </summary>
        /// <param name="sql">SQL语句.</param>
        /// <param name="parameters">SQL条件.</param>
        /// <returns>返回IQueryable{TEntity}"对象</returns>
        IQueryable<TEntity> FromSql(string sql, params object[] parameters);

        /// <summary>
        /// 查询第一条实体对象
        /// </summary>
        /// <param name="keyValues">主键</param>
        /// <returns>第一条实体对象.</returns>
        TEntity Find(params object[] keyValues);

        /// <summary>
        /// 查询若干实体对象
        /// </summary>
        /// <param name="keyValues">主键数组</param>
        /// <returns>若干实体对象.</returns>
        Task<TEntity> FindAsync(params object[] keyValues);

        /// <summary>
        /// 查询若干实体对象
        /// </summary>
        /// <param name="keyValues">主键数组</param>
        /// <returns>若干实体对象.</returns>
        /// <param name="cancellationToken">在等待任务完成时观察</param>
        Task<TEntity> FindAsync(object[] keyValues, CancellationToken cancellationToken);

        /// <summary>
        /// 获取IQueryable{TEntity}对象
        /// </summary>
        /// <returns>IQueryable{TEntity}对象</returns>
        IQueryable<TEntity> Queryable { get; }

        /// <summary>
        /// 获取满足指定条件的实体对象数目.
        /// </summary>
        /// <param name="predicate">过滤器</param>
        /// <returns></returns>
        int Count(Expression<Func<TEntity, bool>> predicate = null);

        /// <summary>
        /// 插入单条实体对象
        /// </summary>
        /// <param name="entity">单条实体对象</param>
        void Insert(TEntity entity);

        /// <summary>
        /// 插入若干实体对象
        /// </summary>
        /// <param name="entities">若干实体对象.</param>
        void Insert(params TEntity[] entities);

        /// <summary>
        /// 插入若干实体对象
        /// </summary>
        /// <param name="entities">若干实体对象</param>
        void Insert(IEnumerable<TEntity> entities);

        /// <summary>
        /// 异步方式插入若干实体对象
        /// </summary>
        /// <param name="entities">若干实体对象</param>
        /// <param name="cancellationToken">在等待任务完成时观察</param>
        /// <returns>返回任务信息</returns>
        Task InsertAsync(TEntity entity,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 异步方式插入若干实体对象
        /// </summary>
        /// <param name="entities">若干实体对象</param>
        /// <returns>返回任务信息</returns>
        Task InsertAsync(params TEntity[] entities);

        /// <summary>
        /// 异步方式插入若干实体对象
        /// </summary>
        /// <param name="entities">若干实体对象</param>
        /// <param name="cancellationToken">在等待任务完成时观察</param>
        /// <returns>返回任务信息</returns>
        Task InsertAsync(IEnumerable<TEntity> entities,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// 更新单条实体对象
        /// </summary>
        /// <param name="entity">单条实体对象.</param>
        void Update(TEntity entity);

        /// <summary>
        /// 更新若干实体对象
        /// </summary>
        /// <param name="entities">若干实体对象</param>
        void Update(params TEntity[] entities);

        /// <summary>
        /// 更新若干实体对象
        /// </summary>
        /// <param name="entities">若干实体对象</param>
        void Update(IEnumerable<TEntity> entities);

        /// <summary>
        /// 删除实体对象
        /// </summary>
        /// <param name="entities">实体对象主键</param>
        void Delete(object id);

        /// <summary>
        /// 删除实体对象
        /// </summary>
        /// <param name="entities">实体对象</param>
        void Delete(TEntity entity);

        /// <summary>
        /// 删除若干实体对象
        /// </summary>
        /// <param name="entities">实体对象</param>
        void Delete(params TEntity[] entities);

        /// <summary>
        /// 删除若干实体对象
        /// </summary>
        /// <param name="entities">实体对象</param>
        void Delete(IEnumerable<TEntity> entities);
    }
}
