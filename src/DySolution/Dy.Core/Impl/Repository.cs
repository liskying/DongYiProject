using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.EntityFrameworkCore
{
    /// <summary>
    /// 仓储接口默认实现.
    /// </summary>
    /// <typeparam name="TEntity">实体类型.</typeparam>
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbContext">Db上下文</param>
        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _dbSet = _dbContext.Set<TEntity>();
        }

        /// <summary>
        /// 更改表名
        /// 常用语分表.
        /// </summary>
        /// <param name="table">表名</param>
        /// <remarks>
        /// 这只用于支持同一模型中的多个表,要求表位于同一库中
        /// </remarks>
        public void ChangeTable(string table)
        {
            if (_dbContext.Model.FindEntityType(typeof(TEntity)).Relational() is RelationalEntityTypeAnnotations relational)
            {
                relational.TableName = table;
            }
        }


        /// <summary>
        /// 获取实体IQueryable<{T}>对象
        /// </summary>
        /// <returns>实体类型</returns>
        public IQueryable<TEntity> Queryable
        {
            get
            {
                return _dbSet;
            }
        }


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
        public IPagedList<TEntity> GetPagedList(Expression<Func<TEntity, bool>> predicate = null,
                                                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                                int pageIndex = 0,
                                                int pageSize = 20,
                                                bool disableTracking = true)
        {
            IQueryable<TEntity> query = _dbSet;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToPagedList(pageIndex, pageSize);
            }
            else
            {
                return query.ToPagedList(pageIndex, pageSize);
            }
        }

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
        public Task<IPagedList<TEntity>> GetPagedListAsync(Expression<Func<TEntity, bool>> predicate = null,
                                                           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                                           int pageIndex = 0,
                                                           int pageSize = 20,
                                                           bool disableTracking = true,
                                                           CancellationToken cancellationToken = default(CancellationToken))
        {
            IQueryable<TEntity> query = _dbSet;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToPagedListAsync(pageIndex, pageSize, 0, cancellationToken);
            }
            else
            {
                return query.ToPagedListAsync(pageIndex, pageSize, 0, cancellationToken);
            }
        }


        /// <summary>
        /// 同步方式查询
        /// </summary>
        /// <param name="predicate">过滤器.</param>
        /// <param name="orderBy">排序器.</param>
        /// <param name="include">导航属性包含器</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">页大小.</param>
        /// <param name="disableTracking">
        /// <c>true</c>禁用对象状态跟踪
        /// <c>false</c>启用对象状态跟踪</param>
        /// <returns>返回包含查询结果的Task<{T}></returns>
        /// <remarks>默认没启用跟踪.</remarks>
        public IPagedList<TResult> GetPagedList<TResult>(Expression<Func<TEntity, TResult>> selector,
                                                         Expression<Func<TEntity, bool>> predicate = null,
                                                         Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                         Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                                         int pageIndex = 0,
                                                         int pageSize = 20,
                                                         bool disableTracking = true)
            where TResult : class
        {
            IQueryable<TEntity> query = _dbSet;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                return orderBy(query).Select(selector).ToPagedList(pageIndex, pageSize);
            }
            else
            {
                return query.Select(selector).ToPagedList(pageIndex, pageSize);
            }
        }


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
        public Task<IPagedList<TResult>> GetPagedListAsync<TResult>(Expression<Func<TEntity, TResult>> selector,
                                                                    Expression<Func<TEntity, bool>> predicate = null,
                                                                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                                    Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                                                    int pageIndex = 0,
                                                                    int pageSize = 20,
                                                                    bool disableTracking = true,
                                                                    CancellationToken cancellationToken = default(CancellationToken))
            where TResult : class
        {
            IQueryable<TEntity> query = _dbSet;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                return orderBy(query).Select(selector).ToPagedListAsync(pageIndex, pageSize, 0, cancellationToken);
            }
            else
            {
                return query.Select(selector).ToPagedListAsync(pageIndex, pageSize, 0, cancellationToken);
            }
        }

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
        public TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate = null,
                                         Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                         Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                         bool disableTracking = true)
        {
            IQueryable<TEntity> query = _dbSet;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                return orderBy(query).FirstOrDefault();
            }
            else
            {
                return query.FirstOrDefault();
            }
        }


        /// <inheritdoc />
        public async Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool disableTracking = true)
        {
            IQueryable<TEntity> query = _dbSet;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                return await orderBy(query).FirstOrDefaultAsync();
            }
            else
            {
                return await query.FirstOrDefaultAsync();
            }
        }

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
        public TResult GetFirstOrDefault<TResult>(Expression<Func<TEntity, TResult>> selector,
                                                  Expression<Func<TEntity, bool>> predicate = null,
                                                  Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                  Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                                  bool disableTracking = true)
        {
            IQueryable<TEntity> query = _dbSet;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                return orderBy(query).Select(selector).FirstOrDefault();
            }
            else
            {
                return query.Select(selector).FirstOrDefault();
            }
        }

        /// <inheritdoc />
        public async Task<TResult> GetFirstOrDefaultAsync<TResult>(Expression<Func<TEntity, TResult>> selector,
                                                  Expression<Func<TEntity, bool>> predicate = null,
                                                  Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                  Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                                                  bool disableTracking = true)
        {
            IQueryable<TEntity> query = _dbSet;
            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                return await orderBy(query).Select(selector).FirstOrDefaultAsync();
            }
            else
            {
                return await query.Select(selector).FirstOrDefaultAsync();
            }
        }

        /// <summary>
        /// SQL查询
        /// </summary>
        /// <param name="sql">SQL语句.</param>
        /// <param name="parameters">SQL条件.</param>
        /// <returns>返回IQueryable{TEntity}"对象</returns>
        public IQueryable<TEntity> FromSql(string sql, params object[] parameters) => _dbSet.FromSql(sql, parameters);

        /// <summary>
        /// 查询第一条实体对象
        /// </summary>
        /// <param name="keyValues">主键</param>
        /// <returns>第一条实体对象.</returns>
        public TEntity Find(params object[] keyValues) => _dbSet.Find(keyValues);

        /// <summary>
        /// 查询若干实体对象
        /// </summary>
        /// <param name="keyValues">主键数组</param>
        /// <returns>若干实体对象.</returns>
        public Task<TEntity> FindAsync(params object[] keyValues) => _dbSet.FindAsync(keyValues);

        /// <summary>
        /// 查询若干实体对象
        /// </summary>
        /// <param name="keyValues">主键数组</param>
        /// <returns>若干实体对象.</returns>
        /// <param name="cancellationToken">在等待任务完成时观察</param>
        public Task<TEntity> FindAsync(object[] keyValues, CancellationToken cancellationToken) => _dbSet.FindAsync(keyValues, cancellationToken);

        /// <summary>
        /// 获取满足指定条件的实体对象数目.
        /// </summary>
        /// <param name="predicate">过滤器</param>
        /// <returns>体对象数目</returns>
        public int Count(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return _dbSet.Count();
            }
            else
            {
                return _dbSet.Count(predicate);
            }
        }

        /// <summary>
        /// 插入单条实体对象
        /// </summary>
        /// <param name="entity">单条实体对象</param>
        public void Insert(TEntity entity)
        {
            var entry = _dbSet.Add(entity);
        }

        /// <summary>
        /// 插入若干实体对象
        /// </summary>
        /// <param name="entities">若干实体对象.</param>
        public void Insert(params TEntity[] entities) => _dbSet.AddRange(entities);

        /// <summary>
        /// 插入若干实体对象
        /// </summary>
        /// <param name="entities">若干实体对象</param>
        public void Insert(IEnumerable<TEntity> entities) => _dbSet.AddRange(entities);

        /// <summary>
        /// 异步方式插入若干实体对象
        /// </summary>
        /// <param name="entities">若干实体对象</param>
        /// <param name="cancellationToken">在等待任务完成时观察</param>
        /// <returns>返回任务信息</returns>
        public Task InsertAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _dbSet.AddAsync(entity, cancellationToken);

            // Shadow properties?
            //var property = _dbContext.Entry(entity).Property("Created");
            //if (property != null) {
            //property.CurrentValue = DateTime.Now;
            //}
        }

        /// <summary>
        /// 异步方式插入若干实体对象
        /// </summary>
        /// <param name="entities">若干实体对象</param>
        /// <returns>返回任务信息</returns>
        public Task InsertAsync(params TEntity[] entities) => _dbSet.AddRangeAsync(entities);

        /// <summary>
        /// 异步方式插入若干实体对象
        /// </summary>
        /// <param name="entities">若干实体对象</param>
        /// <param name="cancellationToken">在等待任务完成时观察</param>
        /// <returns>返回任务信息</returns>
        public Task InsertAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _dbSet.AddRangeAsync(entities, cancellationToken);
        }

        /// <summary>
        /// 更新单条实体对象
        /// </summary>
        /// <param name="entity">单条实体对象.</param>
        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);

        }

        /// <summary>
        /// 更新若干实体对象
        /// </summary>
        /// <param name="entities">若干实体对象</param>
        public void Update(params TEntity[] entities) => _dbSet.UpdateRange(entities);

        /// <summary>
        /// 更新若干实体对象
        /// </summary>
        /// <param name="entities">若干实体对象</param>
        public void Update(IEnumerable<TEntity> entities) => _dbSet.UpdateRange(entities);

        /// <summary>
        /// 删除实体对象
        /// </summary>
        /// <param name="entities">删除实体对象</param>
        public void Delete(TEntity entity) => _dbSet.Remove(entity);

        /// <summary>
        /// 删除实体对象
        /// </summary>
        /// <param name="entities">实体对象主键</param>
        public void Delete(object id)
        {
            //使用存根实体标记删除
            var typeInfo = typeof(TEntity).GetTypeInfo();
            var key = _dbContext.Model.FindEntityType(typeInfo).FindPrimaryKey().Properties.FirstOrDefault();
            var property = typeInfo.GetProperty(key?.Name);
            if (property != null)
            {
                var entity = Activator.CreateInstance<TEntity>();
                property.SetValue(entity, id);
                _dbContext.Entry(entity).State = EntityState.Deleted;
            }
            else
            {
                var entity = _dbSet.Find(id);
                if (entity != null)
                {
                    Delete(entity);
                }
            }
        }

        /// <summary>
        /// 删除若干实体对象
        /// </summary>
        /// <param name="entities">实体对象</param>
        public void Delete(params TEntity[] entities) => _dbSet.RemoveRange(entities);

        /// <summary>
        /// 删除若干实体对象
        /// </summary>
        /// <param name="entities">实体对象</param>
        public void Delete(IEnumerable<TEntity> entities) => _dbSet.RemoveRange(entities);
    }
}
