using Dy.Data.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace Dy.IService
{
    /// <summary>
    /// 测试服务
    /// </summary>
    public interface ITestService
    {
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="pgIndex"></param>
        /// <param name="pgSize"></param>
        /// <returns></returns>
        IPagedList<SysDept> GetDept(Expression<Func<SysDept, bool>> filter, int pgIndex = 1, int pgSize = 20);
    }

}