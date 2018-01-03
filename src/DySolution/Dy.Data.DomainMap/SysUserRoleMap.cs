using Dy.Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dy.Data.DomainMap
{
    /// <summary>
    /// 用户角色映射默认实现
    /// </summary>
    public partial class SysUserRoleMap : EntityBaseMap<string, SysUserRole>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="isOracleDb">是否OracleDb</param>
        public SysUserRoleMap(bool isOracleDb, bool isConverToUpper) : base(isOracleDb, isConverToUpper) { }
        public override void Configure(EntityTypeBuilder<SysUserRole> builder)
        {
            //表名
            //builder.HasBaseType("SysUserRole".ToUpper(IsOracleDb, IsConvertToUpperChar));
            // Properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasMaxLength(36);

            builder.Property(t => t.UserId)
                .IsRequired()
                .HasMaxLength(36);

            builder.Property(t => t.RoleId)
                .IsRequired()
                .HasMaxLength(36);

            builder.Property(t => t.IsMajor);

            // Table & Column Mappings
            //builder.Property(t => t.Id).HasField("Id".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.UserId).HasField("UserId".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.RoleId).HasField("RoleId".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.IsMajor).HasField("IsMajor".ToUpper(IsOracleDb, IsConvertToUpperChar));
        }
    }
}
