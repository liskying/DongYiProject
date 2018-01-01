
using Dy.Core;
using Dy.Data.Domain;
using Dy.Infrs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dy.Data.DomainMap
{

    /// <summary>
    /// 菜单映射默认实现
    /// 用于扩展
    /// </summary>
    public class SysMenuMap : EntityBaseMap<string, SysMenu>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="isOracleDb">是否OracleDb</param>
        public SysMenuMap(bool isOracleDb, bool isConverToUpper) : base(isOracleDb, isConverToUpper) { }
        /// <summary>
        /// 默认属性映射配置
        /// </summary>
        public override void Configure(EntityTypeBuilder<SysMenu> builder)
        {
            //表名
            //builder.HasBaseType("SysMenu".ToUpper(IsOracleDb, IsConvertToUpperChar));
            // Primary Key
            builder.HasKey(t => t.Id);
            builder.HasAlternateKey(u => u.MenuCode);

            // Properties
            builder.Property(t => t.Id).IsRequired().HasMaxLength(36);

            builder.Property(t => t.MenuCode).IsRequired().HasMaxLength(50);
            builder.Property(t => t.MenuName).IsRequired().HasMaxLength(50);

            builder.Property(t => t.MenuType).IsRequired();

            builder.Property(t => t.MenuState).IsRequired();

            builder.Property(t => t.ParentId).HasMaxLength(36);

            builder.Property(t => t.Url).HasMaxLength(100);

            builder.Property(t => t.Icon).HasMaxLength(100);

            builder.Property(t => t.Creator).HasMaxLength(200);

            // Table & Column Mappings
            //builder.Property(t => t.Id).HasField("Id".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.MenuName).HasField("MenuCode".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.MenuName).HasField("MenuName".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.MenuType).HasField("MenuType".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.MenuState).HasField("MenuState".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.ParentId).HasField("ParentId".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.Url).HasField("Url".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.Icon).HasField("Icon".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.SortId).HasField("SortId".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.Creator).HasField("Creator".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.Creator).HasField("Creator".ToUpper(IsOracleDb, IsConvertToUpperChar));

            //builder.Property(t => t.CreateTime).HasField("CreateTime".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.UpdateTime).HasField("UpdateTime".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.DeleteState).HasField("DeleteState".ToUpper(IsOracleDb, IsConvertToUpperChar));

            builder.Property(t => t.RowVersion).IsConcurrencyToken().ValueGeneratedOnAddOrUpdate();
        }

    }

}
