using System;
using System.Collections.Generic;

namespace Microsoft.EntityFrameworkCore
{
    /// <summary>
    /// 帮助助手
    /// </summary>
    public class CoreHelper
    {
        /// <summary>
        /// 创建分页对象.
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <returns>分页包装器实例</returns>
        public static IPagedList<T> Empty<T>()
            where T : class
        {
            return new PagedList<T>();
        }

        /// <summary>
        /// 创建分页对象
        /// </summary>
        /// <typeparam name="TResult">目标类型.</typeparam>
        /// <typeparam name="TSource">源类型.</typeparam>
        /// <param name="source">数据源.</param>
        /// <param name="converter">转换器.</param>
        /// <returns>目标分页对象</returns>
        public static IPagedList<TResult> From<TResult, TSource>(IPagedList<TSource> source,
            Func<IEnumerable<TSource>, IEnumerable<TResult>> converter)
            where TSource : class
            where TResult : class
        {
            return new PagedList<TSource, TResult>(source, converter);
        }
    }
}
