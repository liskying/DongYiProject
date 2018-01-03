using Dy.Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dy.Data.DomainMap
{
    /// <summary>
    /// 用户登录映射默认实现
    /// </summary>
    public partial class SysUserLoginMap
        : EntityBaseMap<int, SysUserLogin>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="isOracleDb">是否OracleDb</param>
        public SysUserLoginMap(bool isOracleDb, bool isConverToUpper) : base(isOracleDb, isConverToUpper) { }
        public override void Configure(EntityTypeBuilder<SysUserLogin> builder)
        {
            //表名
            //builder.HasBaseType("SysUserLogin".ToUpper(IsOracleDb, IsConvertToUpperChar));
            // Primary Key
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id).ValueGeneratedOnAdd();


            builder.Property(t => t.UserId)
                .IsRequired()
                .HasMaxLength(36);

            builder.Property(t => t.LoginProvider)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(t => t.ProviderKey)
                .IsRequired()
                .HasMaxLength(250);

            //builder.Property(t => t.Id).HasField("Id".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.UserId).HasField("UserId".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.LoginProvider).HasField("LoginProvider".ToUpper(IsOracleDb, IsConvertToUpperChar));
            //builder.Property(t => t.ProviderKey).HasField("ProviderKey".ToUpper(IsOracleDb, IsConvertToUpperChar));

        }


    }

}
