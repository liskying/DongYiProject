using System;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.EntityFrameworkCore
{
    /// <summary>
    /// 工作单元通用接口.
    /// </summary>
    public interface IUnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        /// <summary>
        /// 获取Db上下文.
        /// </summary>
        /// <returns><typeparamref name="TContext"/>实例.</returns>
        TContext DbContext { get; }

        /// <summary>
        /// 异步保存数据.
        /// </summary>
        /// <param name="ensureAutoHistory">是否记录变化历史.</param>
        /// <param name="unitOfWorks"><see cref="IUnitOfWork"/>(数组)实例.</param>
        /// <returns>受影响的行数.</returns>
        Task<int> SaveChangesAsync(bool ensureAutoHistory = false, params IUnitOfWork[] unitOfWorks);
    }
    /// <summary>
    /// 工作单元通用接口
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// 切换数据库(暂时适用于MYSQL)
        /// </summary>
        /// <param name="database">数据库名.</param>
        /// <remarks>
        /// 这只用于支持同一模型中的多个数据库。这需要在同一机器上的数据库
        /// </remarks>
        void ChangeDatabase(string database);

        /// <summary>
        /// 获取实体仓储
        /// </summary>
        /// <typeparam name="TEntity">实体类型.</typeparam>
        /// <returns>实体仓储类型.</returns>
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

        /// <summary>
        /// 保存数据库到数据库.
        /// </summary>
        /// <param name="ensureAutoHistory">是否记录变化历史.</param>
        /// <returns>写入数据库的状态条目数.</returns>
        int SaveChanges(bool ensureAutoHistory = false);

        /// <summary>
        /// 异步地将工作单元中的所有更改保存到数据库中
        /// </summary>
        /// <param name="ensureAutoHistory">是否记录变化历史.</param>
        /// <returns>表示异步保存操作,返回写入数据库的状态实体的数量.</returns>
        Task<int> SaveChangesAsync(bool ensureAutoHistory = false);

        /// <summary>
        /// 执行指定的原始SQL命令.
        /// </summary>
        /// <param name="sql">SQL命令.</param>
        /// <param name="parameters">SQL参数.</param>
        /// <returns>写入数据库的状态条目数.</returns>
        int ExecuteSqlCommand(string sql, params object[] parameters);

        /// <summary>
        /// 使用原始的SQL查询来指定<typeparamref name="TEntity"/>数据.
        /// </summary>
        /// <typeparam name="TEntity">实体类型.</typeparam>
        /// <param name="sql">SQL命令.</param>
        /// <param name="parameters">SQL参数.</param>
        /// <returns>An <see cref="IQueryable{T}"/> 返回IQueryable{T}对象.</returns>
        IQueryable<TEntity> FromSql<TEntity>(string sql, params object[] parameters) where TEntity : class;
    }
}
