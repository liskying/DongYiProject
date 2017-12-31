using Dy.Data.Domain;
using Dy.Infrs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dy.Data.DomainMap
{

    /// <summary>
    /// 用户声明映射默认实现
    /// 用于映射扩展
    /// </summary>
    public  partial class SysUserClaimMap
        : EntityBaseMap<string, SysUserClaim>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="isOracleDb">是否OracleDb</param>
        public SysUserClaimMap(bool isOracleDb, bool isConverToUpper)
            : base(isOracleDb, isConverToUpper) { }

        /// <summary>
        /// 默认属性映射配置
        /// </summary>
        public override void Configure(EntityTypeBuilder<SysUserClaim> builder)
        {
            //表名
            builder.HasBaseType("SysUserClaim".ToUpper(IsOracleDb, IsConvertToUpperChar));
            // Primary Key
            builder.HasKey(t => t.Id);

            // Properties
            builder.Property(t => t.Id)
                  .ValueGeneratedOnAdd();

            builder.Property(t => t.UserId)
                .IsRequired()
                .HasMaxLength(36);

            builder.Property(t => t.ClaimType).HasMaxLength(1000);

            builder.Property(t => t.ClaimValue).HasMaxLength(1000);

            // Table & Column Mappings
            builder.Property(t => t.Id).HasField("Id".ToUpper(IsOracleDb, IsConvertToUpperChar));
            builder.Property(t => t.UserId).HasField("UserId".ToUpper(IsOracleDb, IsConvertToUpperChar));
            builder.Property(t => t.ClaimType).HasField("ClaimType".ToUpper(IsOracleDb, IsConvertToUpperChar));
            builder.Property(t => t.ClaimValue).HasField("ClaimValue".ToUpper(IsOracleDb, IsConvertToUpperChar));

        }
        
    }

}
