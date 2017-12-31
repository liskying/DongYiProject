

using Dy.Data.Domain;
using Dy.Infrs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dy.Data.DomainMap
{
    /// <summary>
    /// 字典映射默认实现
    /// 用于扩展
    /// </summary>
    public partial class SysDictionaryMap : EntityBaseMap<string, SysDictionary>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="isOracleDb">是否OracleDb</param>
        public SysDictionaryMap(bool isOracleDb, bool isConverToUpper) : base(isOracleDb, isConverToUpper) { }

        /// <summary>
        /// 默认属性映射配置
        /// </summary>
        public override void Configure(EntityTypeBuilder<SysDictionary> builder)
        {

            //表名
            builder.HasBaseType("SysDictionary".ToUpper(IsOracleDb, IsConvertToUpperChar));
            // Primary Key
            builder.HasKey(t => t.Id);

            //分类+Key需有唯一
            builder.HasAlternateKey(u => new { u.DicType, u.DicKey });

            // Properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasMaxLength(36);

            builder.Property(t => t.ParentId).HasMaxLength(30);

            builder.Property(t => t.DicKey).HasMaxLength(200);

            builder.Property(t => t.DicType).HasMaxLength(200);

            builder.Property(t => t.DicValue).HasMaxLength(200);

            builder.Property(t => t.DisName).HasMaxLength(200);

            builder.Property(t => t.Creator).HasMaxLength(200);


            builder.Property(t => t.Id).HasField("Id".ToUpper(IsOracleDb, IsConvertToUpperChar));
            builder.Property(t => t.ParentId).HasField("ParentId".ToUpper(IsOracleDb, IsConvertToUpperChar));
            builder.Property(t => t.DicKey).HasField("DicKey".ToUpper(IsOracleDb, IsConvertToUpperChar));
            builder.Property(t => t.DicType).HasField("DicType".ToUpper(IsOracleDb, IsConvertToUpperChar));
            builder.Property(t => t.DicValue).HasField("DicValue".ToUpper(IsOracleDb, IsConvertToUpperChar));
            builder.Property(t => t.DicLevel).HasField("DicLevel".ToUpper(IsOracleDb, IsConvertToUpperChar));
            builder.Property(t => t.DisName).HasField("DisName".ToUpper(IsOracleDb, IsConvertToUpperChar));
            builder.Property(t => t.SortId).HasField("SortId".ToUpper(IsOracleDb, IsConvertToUpperChar));
            builder.Property(t => t.IsEnabled).HasField("IsEnabled".ToUpper(IsOracleDb, IsConvertToUpperChar));
            builder.Property(t => t.Creator).HasField("Creator".ToUpper(IsOracleDb, IsConvertToUpperChar));

            builder.Property(t => t.CreateTime).HasField("CreateTime".ToUpper(IsOracleDb, IsConvertToUpperChar));
            builder.Property(t => t.UpdateTime).HasField("UpdateTime".ToUpper(IsOracleDb, IsConvertToUpperChar));
            builder.Property(t => t.DeleteState).HasField("DeleteState".ToUpper(IsOracleDb, IsConvertToUpperChar));
            builder.Property(t => t.RowVersion).IsConcurrencyToken().ValueGeneratedOnAddOrUpdate();
        }


    }



}
