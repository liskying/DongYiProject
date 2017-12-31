using Dy.Data.Domain;
using Dy.Infrs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dy.Data.DomainMap
{

    /// <summary>
    /// 角色声明映射默认实现
    /// 用于映射扩展
    /// </summary>
    public  partial class SysRoleClaimMap
        : EntityBaseMap<string, SysRoleClaim>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="isOracleDb">是否OracleDb</param>
        public SysRoleClaimMap(bool isOracleDb, bool isConverToUpper)
            : base(isOracleDb, isConverToUpper) { }

        /// <summary>
        /// 默认属性映射配置
        /// </summary>
        public override void Configure(EntityTypeBuilder<SysRoleClaim> builder)
        {
            //表名
            builder.HasBaseType("SysRoleClaim".ToUpper(IsOracleDb, IsConvertToUpperChar));
            // Primary Key
            builder.HasKey(t => t.Id);

            // Properties
            builder.Property(t => t.Id)
                  .ValueGeneratedOnAdd();

            builder.Property(t => t.RoleId)
                .IsRequired()
                .HasMaxLength(36);

            builder.Property(t => t.ClaimType).HasMaxLength(1000);

            builder.Property(t => t.ClaimValue).HasMaxLength(1000);

            // Table & Column Mappings
            builder.Property(t => t.Id).HasField("Id".ToUpper(IsOracleDb, IsConvertToUpperChar));
            builder.Property(t => t.RoleId).HasField("RoleId".ToUpper(IsOracleDb, IsConvertToUpperChar));
            builder.Property(t => t.ClaimType).HasField("ClaimType".ToUpper(IsOracleDb, IsConvertToUpperChar));
            builder.Property(t => t.ClaimValue).HasField("ClaimValue".ToUpper(IsOracleDb, IsConvertToUpperChar));

        }
        
    }

}
