using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Microsoft.EntityFrameworkCore
{
    /// <summary>
    /// 工作单元接口默认实现
    /// </summary>
    /// <typeparam name="TContext">Db上下文类型</typeparam>
    public class UnitOfWork<TContext> :
        IRepositoryFactory,
        IUnitOfWork<TContext>,
        IUnitOfWork
        where TContext : DbContext
    {
        private readonly TContext _context;
        private bool disposed = false;
        private Dictionary<Type, object> repositories;

        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="context">Db上下文实例</param>
        public UnitOfWork(TContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>
        /// 获取Db上下文实例
        /// </summary>
        public TContext DbContext
        {
            get
            {
                return _context;
            }
        }

        /// <summary>
        /// 切换数据库(暂时适用于MYSQL)
        /// </summary>
        /// <param name="database">数据库名.</param>
        /// <remarks>
        /// 这只用于支持同一模型中的多个数据库。这需要在同一机器上的数据库
        /// </remarks>
        public void ChangeDatabase(string database)
        {
            var connection = _context.Database.GetDbConnection();
            if (connection.State.HasFlag(ConnectionState.Open))
            {
                connection.ChangeDatabase(database);
            }
            else
            {
                var connectionString = Regex.Replace(connection.ConnectionString.Replace(" ", ""), @"(?<=[Dd]atabase=)\w+(?=;)", database, RegexOptions.Singleline);
                connection.ConnectionString = connectionString;
            }

            //以下代码只适用于MYSQL
            var items = _context.Model.GetEntityTypes();
            foreach (var item in items)
            {
                if (item.Relational() is RelationalEntityTypeAnnotations extensions)
                {
                    extensions.Schema = database;
                }
            }
        }

        /// <summary>
        /// 获取实体仓储
        /// </summary>
        /// <typeparam name="TEntity">实体类型.</typeparam>
        /// <returns>实体仓储类型.</returns>
        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (repositories == null)
            {
                repositories = new Dictionary<Type, object>();
            }

            var type = typeof(TEntity);
            if (!repositories.ContainsKey(type))
            {
                repositories[type] = new Repository<TEntity>(_context);
            }

            return (IRepository<TEntity>)repositories[type];
        }

        /// <summary>
        /// 执行指定的原始SQL命令.
        /// </summary>
        /// <param name="sql">SQL命令.</param>
        /// <param name="parameters">SQL参数.</param>
        /// <returns>写入数据库的状态条目数.</returns>
        public int ExecuteSqlCommand(string sql, params object[] parameters) => _context.Database.ExecuteSqlCommand(sql, parameters);
        
        /// <summary>
        /// 使用原始的SQL查询来指定<typeparamref name="TEntity"/>数据.
        /// </summary>
        /// <typeparam name="TEntity">实体类型.</typeparam>
        /// <param name="sql">SQL命令.</param>
        /// <param name="parameters">SQL参数.</param>
        /// <returns>An <see cref="IQueryable{T}"/> 返回IQueryable{T}对象.</returns>
        public IQueryable<TEntity> FromSql<TEntity>(string sql, params object[] parameters) where TEntity : class => _context.Set<TEntity>().FromSql(sql, parameters);

        /// <summary>
        /// 同步保存数据.
        /// </summary>
        /// <param name="ensureAutoHistory">是否记录变化历史.</param>
        /// <param name="unitOfWorks"><see cref="IUnitOfWork"/>(数组)实例.</param>
        /// <returns>受影响的行数.</returns>
        public int SaveChanges(bool ensureAutoHistory = false)
        {
            if (ensureAutoHistory)
            {
               // _context.EnsureAutoHistory();
            }

            return _context.SaveChanges();
        }

        /// <summary>
        /// 异步保存数据.
        /// </summary>
        /// <param name="ensureAutoHistory">是否记录变化历史.</param>
        /// <param name="unitOfWorks"><see cref="IUnitOfWork"/>(数组)实例.</param>
        /// <returns>受影响的行数.</returns>
        public async Task<int> SaveChangesAsync(bool ensureAutoHistory = false)
        {
            if (ensureAutoHistory)
            {
                //_context.EnsureAutoHistory();
            }

            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// 异步保存数据.
        /// </summary>
        /// <param name="ensureAutoHistory">是否记录变化历史.</param>
        /// <param name="unitOfWorks"><see cref="IUnitOfWork"/>(数组)实例.</param>
        /// <returns>受影响的行数.</returns>
        public async Task<int> SaveChangesAsync(bool ensureAutoHistory = false, params IUnitOfWork[] unitOfWorks)
        {
            // TransactionScope will be included in .NET Core v2.0
            //以下代码用于.NetCore v2.0以下，2.0以上也适用
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var count = 0;
                    foreach (var unitOfWork in unitOfWorks)
                    {
                        var uow = unitOfWork as UnitOfWork<DbContext>;
                        uow.DbContext.Database.UseTransaction(transaction.GetDbTransaction());
                        count += await uow.SaveChangesAsync(ensureAutoHistory);
                    }

                    count += await SaveChangesAsync(ensureAutoHistory);

                    transaction.Commit();

                    return count;
                }
                catch (Exception ex)
                {

                    transaction.Rollback();

                    throw ex;
                }
            }
        }

        /// <summary>
        /// 释放资源,垃圾回收
        /// </summary>
        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 释放资源,垃圾回收
        /// </summary>
        /// <param name="disposing">释放已释放标识</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // clear repositories
                    if (repositories != null)
                    {
                        repositories.Clear();
                    }

                    // dispose the db context.
                    _context.Dispose();
                }
            }

            disposed = true;
        }
    }
}
