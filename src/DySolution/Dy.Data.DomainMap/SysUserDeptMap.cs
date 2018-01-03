using Dy.Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dy.Data.DomainMap
{

    /// <summary>
    /// 用户部门映射默认实现
    /// </summary>
    public partial class SysUserDeptMap : EntityBaseMap<string, SysUserDept>
    {
        public SysUserDeptMap(bool isOracleDb, bool isConverToUpperer) : base(isOracleDb, isConverToUpperer) { }
        /// <summary>
        /// 默认属性映射配置
        /// </summary>
        public override void Configure(EntityTypeBuilder<SysUserDept> builder)
        {
            //表名
            //builder.HasBaseType("SysUserDept".ToUpper(IsOracleDb, IsConvertToUpperChar));
            // Primary Key
            builder.HasKey(t => t.Id);

            // Properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasMaxLength(36);

            builder.Property(t => t.UserId)
                .IsRequired()
                .HasMaxLength(36);

            builder.Property(t => t.DeptId)
                .IsRequired()
                .HasMaxLength(36);

            builder.Property(t => t.IsMajor);

            // Table & Column Mappings
            //builder.Property(t => t.Id).HasField("Id".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.UserId).HasField("UserId".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.DeptId).HasField("DeptId".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.IsMajor).HasField("IsMajor".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.JobState).HasField("JobState".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.StartDate).HasField("StartDate".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.EndDate).HasField("EndDate".ToUpper(IsOracleDb, IsConvertToUpperChar));
        }
    }
}