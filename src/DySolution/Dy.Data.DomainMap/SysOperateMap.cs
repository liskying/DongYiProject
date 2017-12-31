using Dy.Data.Domain;
using Dy.Infrs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dy.Data.DomainMap
{
    /// <summary>
    /// 操作项映射默认实现
    /// </summary>
    public partial class SysOperateMap : EntityBaseMap<string, SysOperate>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="isOracleDb">是否OracleDb</param>
        public SysOperateMap(bool isOracleDb, bool isConverToUpper) : base(isOracleDb, isConverToUpper) { }
        /// <summary>
        /// 默认属性映射配置
        /// </summary>
        public override void Configure(EntityTypeBuilder<SysOperate> builder)
        {
            //表名
            builder.HasBaseType("SysOperate".ToUpper(IsOracleDb, IsConvertToUpperChar));
            // Primary Key
            builder.HasKey(t => t.Id);
            //操作按钮Code需唯一
            builder.HasAlternateKey(u => u.OptionCode);
            //操作按钮名需唯一
            builder.HasAlternateKey(u => u.OptionName);

            // Properties
            builder.Property(t => t.Id).IsRequired().HasMaxLength(36);

            builder.Property(t => t.OptionCode).IsRequired().HasMaxLength(50);
            builder.Property(t => t.OptionName).IsRequired().HasMaxLength(50);

            builder.Property(t => t.Style).HasMaxLength(50);

            builder.Property(t => t.Icon).HasMaxLength(50);

            builder.Property(t => t.SortId);

            // Table & Column Mappings
            builder.Property(t => t.Id).HasField("Id".ToUpper(IsOracleDb, IsConvertToUpperChar));
            builder.Property(t => t.OptionCode).HasField("OptionCode".ToUpper(IsOracleDb, IsConvertToUpperChar));
            builder.Property(t => t.OptionName).HasField("OptionName".ToUpper(IsOracleDb, IsConvertToUpperChar));
            builder.Property(t => t.Style).HasField("Style".ToUpper(IsOracleDb, IsConvertToUpperChar));
            builder.Property(t => t.Icon).HasField("Icon".ToUpper(IsOracleDb, IsConvertToUpperChar));
            builder.Property(t => t.SortId).HasField("SortId".ToUpper(IsOracleDb, IsConvertToUpperChar));
        }
    }


}
