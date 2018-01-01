using Dy.Core;
using Dy.Data.Domain;
using Dy.Infrs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dy.Data.DomainMap
{
    /// <summary>
    /// 角色映射默认实现
    /// 用于映射扩展
    /// </summary>
    public partial class SysRoleMap : EntityBaseMap<string, SysRole>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="isOracleDb">是否OracleDb</param>
        public SysRoleMap(bool isOracleDb, bool isConverToUpper) : base(isOracleDb, isConverToUpper) { }
        /// <summary>
        /// 默认属性映射配置
        /// </summary>
        public override void Configure(EntityTypeBuilder<SysRole> builder)
        {
            //表名
            //builder.HasBaseType("SysRole".ToUpper(IsOracleDb, IsConvertToUpperChar));
            // Primary Key
            builder.HasKey(t => t.Id);

            //角色名唯一
            builder.HasAlternateKey(u => u.Name);

            // Properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasMaxLength(36);

            builder.Property(t => t.Name).IsRequired().HasMaxLength(50);
            builder.Property(t => t.NormalizedName).IsRequired().HasMaxLength(50);

            builder.Property(t => t.IsSystem);

            builder.Property(t => t.ModuleRight);

            builder.Property(t => t.MobileRight);

            builder.Property(t => t.Creator).HasMaxLength(200);

            // Table & Column Mappings
            //builder.Property(t => t.Id).HasField("Id".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.Name).HasField("Name".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.NormalizedName).HasField("NormalizedName".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.IsSystem).HasField("IsSystem".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.ModuleRight).HasField("ModuleRight".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.MobileRight).HasField("MobileRight".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.SortId).HasField("SortId".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.Creator).HasField("Creator".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.HasMany(u => u.UserRoles).WithOne().HasForeignKey(u => u.RoleId);

            //builder.Property(t => t.CreateTime).HasField("CreateTime".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.UpdateTime).HasField("UpdateTime".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.DeleteState).HasField("DeleteState".ToUpper(IsOracleDb, IsConvertToUpperChar));
            builder.Property(t => t.RowVersion).IsConcurrencyToken().ValueGeneratedOnAddOrUpdate();

            builder.HasMany(u => u.RoleClaims).WithOne(u => u.Role).HasForeignKey(u => u.RoleId);
            builder.HasMany(u => u.UserRoles).WithOne(u => u.Role).HasForeignKey(u => u.RoleId);
        }


    }

}
