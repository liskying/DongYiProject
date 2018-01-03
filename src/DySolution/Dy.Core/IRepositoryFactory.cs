namespace Microsoft.EntityFrameworkCore
{
    /// <summary>
    /// 仓储工厂
    /// </summary>
    public interface IRepositoryFactory
    {
        /// <summary>
        /// 获取实体仓储.
        /// </summary>
        /// <typeparam name="TEntity">实体类型.</typeparam>
        /// <returns>实体仓储.</returns>
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
    }
}
