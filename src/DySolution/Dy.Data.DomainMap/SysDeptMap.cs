using Dy.Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dy.Data.DomainMap
{
    /// <summary>
    /// 部门映射默认实现
    /// </summary>
    public partial class SysDeptMap : EntityBaseMap<string, SysDept>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="isOracleDb">是否OracleDb</param>
        public SysDeptMap(bool isOracleDb, bool isConverToUpper) : base(isOracleDb, isConverToUpper)
        { }

        public override void Configure(EntityTypeBuilder<SysDept> builder)
        {
            //表名
            //builder.HasBaseType("SysDept".ToUpper(IsOracleDb, IsConvertToUpperChar));
            // Primary Key
            builder.HasKey(t => t.Id);

            // Properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasMaxLength(36);

            builder.Property(t => t.DeptName).IsRequired().HasMaxLength(50);

            builder.Property(t => t.DeptCode).HasMaxLength(50);

            builder.Property(t => t.DeptType).HasMaxLength(50);

            builder.Property(t => t.DeptLevel);

            builder.Property(t => t.Address).HasMaxLength(200);

            builder.Property(t => t.Tel).HasMaxLength(50);

            builder.Property(t => t.Creator).HasMaxLength(200);

            // Table & Column Mappings
            //builder.Property(t => t.Id).HasField("Id".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.DeptName).HasField("DeptName".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.DeptCode).HasField("DeptCode".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.DeptType).HasField("DeptType".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.DeptLevel).HasField("DeptLevel".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.Address).HasField("Address".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.Tel).HasField("Tel".ToUpper(IsOracleDb, IsConvertToUpperChar));

            //builder.Property(t => t.SortId).HasField("SortId".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.Creator).HasField("Creator".ToUpper(IsOracleDb, IsConvertToUpperChar));

            //builder.Property(t => t.CreateTime).HasField("CreateTime".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.UpdateTime).HasField("UpdateTime".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.DeleteState).HasField("DeleteState".ToUpper(IsOracleDb, IsConvertToUpperChar));

            builder.Property(t => t.RowVersion).IsConcurrencyToken().ValueGeneratedOnAddOrUpdate();


            builder.HasMany(u => u.Users).WithOne(u => u.Dept).HasForeignKey(u => u.DeptId);
        }

    }

}
