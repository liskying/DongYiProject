using Dy.Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dy.Data.DomainMap
{

    /// <summary>
    /// 用户声明映射默认实现
    /// 用于映射扩展
    /// </summary>
    public partial class SysUserTokenMap
        : EntityBaseMap<int, SysUserToken>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="isOracleDb">是否OracleDb</param>
        public SysUserTokenMap(bool isOracleDb, bool isConverToUpper)
            : base(isOracleDb, isConverToUpper) { }

        /// <summary>
        /// 默认属性映射配置
        /// </summary>
        public override void Configure(EntityTypeBuilder<SysUserToken> builder)
        {
            //表名
            //builder.HasBaseType("SysUserToken".ToUpper(IsOracleDb, IsConvertToUpperChar));

            builder.HasKey(t => t.Id);
            
            builder.Property(t => t.Id).ValueGeneratedOnAdd();
                        
            builder.Property(t => t.LoginProvider)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(t => t.Name)
                .IsRequired().HasMaxLength(200);

            builder.Property(t => t.UserId)
                .IsRequired().HasMaxLength(36);

            builder.Property(t => t.Value)
                .IsRequired()
                .HasMaxLength(1000);

            // Table & Column Mappings
            //builder.Property(t => t.LoginProvider).HasField("LoginProvider".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.Name).HasField("Name".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.UserId).HasField("UserId".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.Value).HasField("Value".ToUpper(IsOracleDb, IsConvertToUpperChar));

        }

    }

}
