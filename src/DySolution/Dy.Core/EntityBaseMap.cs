using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Dy.Core
{
    /// <summary>
    /// 实体映射抽象标准定义
    /// </summary>
    /// <typeparam name="TKey">主键类型</typeparam>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public abstract class EntityBaseMap<TKey, TEntity> : IEntityTypeConfiguration<TEntity>
       where TEntity : class
    {
        /// <summary>
        /// true:oracle数据库,表名以及字段名自动转换为大写
        /// false:大小写不做变化
        /// </summary>
        public bool IsOracleDb { get; set; }
        /// <summary>
        /// 是否把关键字转大写
        /// </summary>
        public bool IsConvertToUpperChar { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public EntityBaseMap(bool isOracleDb, bool isConverToUpperer)
        {
            this.IsOracleDb = isOracleDb;
            this.IsConvertToUpperChar = isConverToUpperer;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            throw new NotImplementedException();
        }
    }
}
