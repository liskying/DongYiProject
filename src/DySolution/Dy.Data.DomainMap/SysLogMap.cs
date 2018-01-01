
using Dy.Core;
using Dy.Data.Domain;
using Dy.Infrs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dy.Data.DomainMap
{

    /// <summary>
    /// 日志映射默认实现
    /// </summary>
    public partial class SysLogMap : EntityBaseMap<int, SysLog>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="isOracleDb">是否OracleDb</param>
        public SysLogMap(bool isOracleDb, bool isConverToUpper) : base(isOracleDb, isConverToUpper) { }
        public override void Configure(EntityTypeBuilder<SysLog> builder)
        {
            //表名
            //builder.HasBaseType("SysLog".ToUpper(IsOracleDb, IsConvertToUpperChar));

            // Primary Key
            builder.HasKey(t => t.Id);

            // Properties
            builder.Property(t => t.Id)
               .ValueGeneratedOnAdd();

            builder.Property(t => t.UserId).IsRequired().HasMaxLength(36);

            builder.Property(t => t.DeptId).IsRequired().HasMaxLength(36);

            builder.Property(t => t.DeptName).HasMaxLength(50);

            builder.Property(t => t.UserName).HasMaxLength(50);

            builder.Property(t => t.EmpName).HasMaxLength(50);

            builder.Property(t => t.LogIP).HasMaxLength(50);

            builder.Property(t => t.LogType).HasMaxLength(50);

            builder.Property(t => t.LogContent).HasMaxLength(4000);

            // Table & Column Mappings
            //builder.Property(t => t.Id).HasField("Id".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.UserId).HasField("UserId".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.DeptId).HasField("DeptId".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.DeptName).HasField("DeptName".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.UserName).HasField("UserName".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.EmpName).HasField("EmpName".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.LogIP).HasField("LogIP".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.LogType).HasField("LogType".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.LogContent).HasField("LogContent".ToUpper(IsOracleDb, IsConvertToUpperChar));


            //builder.Property(t => t.CreateTime).HasField("CreateTime".ToUpper(IsOracleDb, IsConvertToUpperChar));


            builder.HasMany(u => u.LogDetails).WithOne().HasForeignKey(u => u.LogId);
        }


    }
}
