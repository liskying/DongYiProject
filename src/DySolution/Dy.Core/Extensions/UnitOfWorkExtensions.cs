using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.EntityFrameworkCore
{
    /// <summary>
    /// 工作单元扩展
    /// </summary>
    public static class UnitOfWorkExtensions
    {
        /// <summary>
        /// 依赖注入:工作单元
        /// </summary>
        /// <typeparam name="TContext">Db上下文.</typeparam>
        /// <param name="services">服务集合.</param>
        /// <returns>服务集合</returns>
        /// <remarks>
        /// 对于同一个Db上下文只能被注册一次
        /// </remarks>
        public static IServiceCollection RegUnitOfWork<TContext>(this IServiceCollection services) where TContext : DbContext
        {
            services.AddScoped<IRepositoryFactory, UnitOfWork<TContext>>();
            //下面有一个问题：IUnitOfWork不能支持多个DbContext /数据库
            // 这意味着不能叫AddUnitOfWork<TContext> 多次
            // 解决方案：检查IUnitOfWork是否为空
            services.AddScoped<IUnitOfWork, UnitOfWork<TContext>>();
            services.AddScoped<IUnitOfWork<TContext>, UnitOfWork<TContext>>();
            return services;
        }

        /// <summary>
        /// 依赖注入:工作单元
        /// </summary>
        /// <typeparam name="TContext1">第一个Db上下文.</typeparam>
        /// <typeparam name="TContext2">第二个Db上下文.</typeparam>
        /// <param name="services">服务集合.</param>
        /// <returns>服务集合</returns>
        /// <remarks>
        /// 此方法只支持一个db上下文，如果多次调用，将抛出异常
        /// </remarks>
        public static IServiceCollection RegUnitOfWork<TContext1, TContext2>(this IServiceCollection services)
            where TContext1 : DbContext
            where TContext2 : DbContext
        {
            services.AddScoped<IUnitOfWork<TContext1>, UnitOfWork<TContext1>>();
            services.AddScoped<IUnitOfWork<TContext2>, UnitOfWork<TContext2>>();

            return services;
        }

        /// <summary>
        /// 依赖注入:工作单元
        /// </summary>
        /// <typeparam name="TContext1">第一个Db上下文.</typeparam>
        /// <typeparam name="TContext2">第二个Db上下文.</typeparam>
        /// <typeparam name="TContext3">第三个Db上下文.</typeparam>
        /// <param name="services">服务集合.</param>
        /// <returns>服务集合</returns>
        /// <remarks>
        /// 此方法只支持一个db上下文，如果多次调用，将抛出异常
        /// </remarks>
        public static IServiceCollection RegUnitOfWork<TContext1, TContext2, TContext3>(this IServiceCollection services)
            where TContext1 : DbContext
            where TContext2 : DbContext
            where TContext3 : DbContext
        {
            services.AddScoped<IUnitOfWork<TContext1>, UnitOfWork<TContext1>>();
            services.AddScoped<IUnitOfWork<TContext2>, UnitOfWork<TContext2>>();
            services.AddScoped<IUnitOfWork<TContext3>, UnitOfWork<TContext3>>();

            return services;
        }

        /// <summary>
        /// 依赖注入:工作单元
        /// </summary>
        /// <typeparam name="TContext1">第一个Db上下文.</typeparam>
        /// <typeparam name="TContext2">第二个Db上下文.</typeparam>
        /// <typeparam name="TContext3">第三个Db上下文.</typeparam>
        /// <param name="services">服务集合.</param>
        /// <returns>服务集合</returns>
        /// <remarks>
        /// 此方法只支持一个db上下文，如果多次调用，将抛出异常
        /// </remarks>
        public static IServiceCollection RegUnitOfWork<TContext1, TContext2, TContext3, TContext4>(this IServiceCollection services)
            where TContext1 : DbContext
            where TContext2 : DbContext
            where TContext3 : DbContext
            where TContext4 : DbContext
        {
            services.AddScoped<IUnitOfWork<TContext1>, UnitOfWork<TContext1>>();
            services.AddScoped<IUnitOfWork<TContext2>, UnitOfWork<TContext2>>();
            services.AddScoped<IUnitOfWork<TContext3>, UnitOfWork<TContext3>>();
            services.AddScoped<IUnitOfWork<TContext4>, UnitOfWork<TContext4>>();

            return services;
        }


    }
}
