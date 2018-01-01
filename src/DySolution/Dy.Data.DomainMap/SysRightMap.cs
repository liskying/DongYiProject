using Dy.Core;
using Dy.Data.Domain;
using Dy.Infrs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dy.Data.DomainMap
{
    /// <summary>
    /// 权限映射默认实现
    /// </summary>
    public class SysRightMap : EntityBaseMap<string, SysRight>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="isOracleDb">是否OracleDb</param>
        public SysRightMap(bool isOracleDb, bool isConverToUpper) : base(isOracleDb, isConverToUpper) { }
        public override void Configure(EntityTypeBuilder<SysRight> builder)
        {
            //表名
            //builder.HasBaseType("SysRight".ToUpper(IsOracleDb, IsConvertToUpperChar));
            // Primary Key
            builder.HasKey(t => t.Id);

            // Properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasMaxLength(36);

            builder.Property(u => u.UserId)
                .IsRequired()
                .HasMaxLength(36);

            builder.Property(t => t.ModuleRight);

            builder.Property(t => t.BizScope);

            builder.Property(t => t.ManagerScope);

            builder.Property(t => t.MobileRight);


            builder.Property(t => t.Creator).HasMaxLength(200);

            // Table & Column Mappings
            //builder.Property(t => t.Id).HasField("Id".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.UserId).HasField("UserId".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.ModuleRight).HasField("ModuleRight".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.BizScope).HasField("BizScope".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.ManagerScope).HasField("ManagerScope".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.MobileRight).HasField("MobileRight".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.Creator).HasField("Creator".ToUpper(IsOracleDb, IsConvertToUpperChar));

            //builder.Property(t => t.CreateTime).HasField("CreateTime".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.UpdateTime).HasField("UpdateTime".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.DeleteState).HasField("DeleteState".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.RowVersion).IsConcurrencyToken().ValueGeneratedOnAddOrUpdate();
        }
    }

}
