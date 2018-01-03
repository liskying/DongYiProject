using Dy.Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dy.Data.DomainMap
{
    /// <summary>
    /// 日志明细默认实现
    /// </summary>
    public partial class SysLogDetailMap : EntityBaseMap<string, SysLogDetail>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="isOracleDb">是否OracleDb</param>
        public SysLogDetailMap(bool isOracleDb, bool isConverToUpper) : base(isOracleDb, isConverToUpper) { }
        public override void Configure(EntityTypeBuilder<SysLogDetail> builder)
        {
            //表名
            //builder.HasBaseType("SysLogDetail".ToUpper(IsOracleDb, IsConvertToUpperChar));
            // Primary Key
            builder.HasKey(t => t.Id);

            // Properties
            builder.Property(t => t.Id)
               .ValueGeneratedOnAdd();

            builder.Property(t => t.LogId).IsRequired();

            builder.Property(t => t.TableName).IsRequired().HasMaxLength(56);

            builder.Property(t => t.FieldName).HasMaxLength(50);

            builder.Property(t => t.OriginalVal).HasMaxLength(4000);

            builder.Property(t => t.NewValue).HasMaxLength(4000);

            builder.Property(t => t.OperateType).HasMaxLength(50);
            


            // Table & Column Mappings
            //builder.Property(t => t.Id).HasField("Id".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.LogId).HasField("LogId".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.TableName).HasField("TableName".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.FieldName).HasField("FieldName".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.OriginalVal).HasField("OriginalVal".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.NewValue).HasField("NewValue".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.OperateType).HasField("OperateType".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.CreateTime).HasField("CreateTime".ToUpper(IsOracleDb, IsConvertToUpperChar));

        }


    }
    

}
