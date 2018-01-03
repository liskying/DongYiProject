using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.EntityFrameworkCore
{
    /// <summary>
    /// 分页扩展
    /// </summary>
    public static class PagedExtensions
    {
        /// <summary>
        /// 把源数据转换分页对象
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="source">数据源.</param>
        /// <param name="pageIndex">页索引.</param>
        /// <param name="pageSize">页大小.</param>
        /// <param name="indexFrom">起始页索引.</param>
        /// <returns>分页对象</returns>
        public static IPagedList<T> ToPagedList<T>(this IEnumerable<T> source,
            int pageIndex,
            int pageSize,
            int indexFrom = 0)
            where T : class
        {
            return new PagedList<T>(source, pageIndex, pageSize, indexFrom);
        }

        /// <summary>
        /// 把源数据转换为具有目标类型的分页对象
        /// </summary>
        /// <typeparam name="TSource">源数据类型.</typeparam>
        /// <typeparam name="TResult">目标数据类型</typeparam>
        /// <param name="source">数据源.</param>
        /// <param name="converter">对象转换器</param>
        /// <param name="pageIndex">页索引.</param>
        /// <param name="pageSize">页大小.</param>
        /// <param name="indexFrom">起始页索引.</param>
        /// <returns>目标类型的分页对象</returns>
        public static IPagedList<TResult> ToPagedList<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<IEnumerable<TSource>, IEnumerable<TResult>> converter,
            int pageIndex,
            int pageSize,
            int indexFrom = 0)
            where TResult : class
            where TSource : class
        {
            return new PagedList<TSource, TResult>(source, converter, pageIndex, pageSize, indexFrom)
             ;
        }

        /// <summary>
        /// 对象转换
        /// </summary>
        /// <typeparam name="TEntity">对象类型.</typeparam>
        /// <param name="source">数据源.</param>
        /// <param name="pageIndex">页索引.</param>
        /// <param name="pageSize">页大小.</param>
        /// <param name="cancellationToken">在等待任务完成时观察</param>
        /// <param name="indexFrom">起始页索引.</param>
        /// <returns>带有分页对象的任务对象</returns>
        public static async Task<IPagedList<TEntity>> ToPagedListAsync<TEntity>(this IQueryable<TEntity> source,
            int pageIndex,
            int pageSize,
            int indexFrom = 0,
            CancellationToken cancellationToken = default(CancellationToken))
            where TEntity : class
        {
            if (indexFrom > pageIndex)
            {
                throw new ArgumentException($"indexFrom: {indexFrom} > pageIndex: {pageIndex}, must indexFrom <= pageIndex");
            }

            var count = await source.CountAsync(cancellationToken).ConfigureAwait(false);
            var items = await source.Skip((pageIndex - indexFrom) * pageSize)
                                    .Take(pageSize).ToListAsync(cancellationToken).ConfigureAwait(false);

            var pagedList = new PagedList<TEntity>()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                IndexFrom = indexFrom,
                TotalCount = count,
                Items = items,
                TotalPages = (int)Math.Ceiling(count / (double)pageSize)
            };

            return pagedList;
        }
    }
}
