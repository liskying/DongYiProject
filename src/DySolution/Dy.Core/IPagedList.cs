using System.Collections.Generic;

namespace Microsoft.EntityFrameworkCore
{
    /// <summary>
    /// 分页通用接口.
    /// </summary>
    /// <typeparam name="T">查询对象类型/实体类型.</typeparam>
    public interface IPagedList<T>
    {
        /// <summary>
        /// 起始页索引
        /// </summary>
        int IndexFrom { get; }
        /// <summary>
        /// 当前页索引
        /// </summary>
        int PageIndex { get; }
        /// <summary>
        /// 页大小
        /// </summary>
        int PageSize { get; }
        /// <summary>
        /// 总条数
        /// </summary>
        int TotalCount { get; }
        /// <summary>
        /// 总页数
        /// </summary>
        int TotalPages { get; }
        /// <summary>
        /// 当前页项
        /// </summary>
        IList<T> Items { get; }
        /// <summary>
        /// 是否有上页
        /// </summary>
        bool HasPreviousPage { get; }

        /// <summary>
        /// 是否有下页
        /// </summary>
        bool HasNextPage { get; }
    }
}
