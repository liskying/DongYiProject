using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.EntityFrameworkCore
{
    /// <summary>
    /// 分页模型.
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    public class PagedList<T> : BasePagedList<T> where T : class
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="source">数据源.</param>
        /// <param name="pageIndex">页索引.</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="indexFrom">起始页索引.</param>
        internal PagedList(IEnumerable<T> source, int pageIndex, int pageSize, int indexFrom)
        {
            if (indexFrom > pageIndex)
            {
                throw new ArgumentException($"indexFrom: {indexFrom} > pageIndex: {pageIndex}, must indexFrom <= pageIndex");
            }

            PageIndex = pageIndex;
            PageSize = pageSize;
            IndexFrom = indexFrom;
            TotalCount = source.Count();
            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);

            Items = source.Skip((PageIndex - IndexFrom) * PageSize).Take(PageSize).ToList();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        internal PagedList() => Items = new T[0];
    }

    /// <summary>
    /// 分页模型.
    /// </summary>
    /// <typeparam name="TSource">源类型.</typeparam>
    /// <typeparam name="TResult">目标类型.</typeparam>
    public class PagedList<TSource, TResult> : BasePagedList<TResult>
        where TSource : class
        where TResult : class
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="source">数据源.</param>
        /// <param name="pageIndex">页索引.</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="indexFrom">起始页索引.</param>
        /// <param name="converter">源类型到目标类型转换器.</param>
        public PagedList(IEnumerable<TSource> source,
            Func<IEnumerable<TSource>, IEnumerable<TResult>> converter,
            int pageIndex,
            int pageSize,
            int indexFrom)
        {
            if (indexFrom > pageIndex)
            {
                throw new ArgumentException($"indexFrom: {indexFrom} > pageIndex: {pageIndex}, must indexFrom <= pageIndex");
            }

            PageIndex = pageIndex;
            PageSize = pageSize;
            IndexFrom = indexFrom;
            TotalCount = source.Count();
            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);

            var items = source.Skip((PageIndex - IndexFrom) * PageSize).Take(PageSize).ToArray();

            Items = new List<TResult>(converter(items));
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="source">源类型.</param>
        /// <param name="converter">类型转换器.</param>
        public PagedList(IPagedList<TSource> source,
            Func<IEnumerable<TSource>, IEnumerable<TResult>> converter)
        {
            PageIndex = source.PageIndex;
            PageSize = source.PageSize;
            IndexFrom = source.IndexFrom;
            TotalCount = source.TotalCount;
            TotalPages = source.TotalPages;

            Items = new List<TResult>(converter(source.Items));
        }
    }


    /// <summary>
    /// 分页模型抽象声明
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    public abstract class BasePagedList<T> : IPagedList<T> where T : class
    {
        /// <summary>
        /// 当前页索引
        /// </summary>
        public virtual int PageIndex { get; set; }
        /// <summary>
        /// 页大小
        /// </summary>
        public virtual int PageSize { get; set; }
        /// <summary>
        /// 总条数
        /// </summary>
        public virtual int TotalCount { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public virtual int TotalPages { get; set; }
        /// <summary>
        /// 起始页索引
        /// </summary>
        public virtual int IndexFrom { get; set; }
        /// <summary>
        /// 当前页项
        /// </summary>
        public virtual IList<T> Items { get; set; }
        /// <summary>
        /// 是否有上页
        /// </summary>
        public virtual bool HasPreviousPage => PageIndex - IndexFrom > 0;
        /// <summary>
        /// 是否有下页
        /// </summary>
        public virtual bool HasNextPage => PageIndex - IndexFrom + 1 < TotalPages;
    }
}

