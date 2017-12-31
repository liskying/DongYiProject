using Dy.Data.Domain;
using Dy.Infrs;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dy.Data.DomainMap
{


    /// <summary>
    /// 用户映射抽象实现
    /// </summary>
    public class SysUserMap
        : EntityBaseMap<string, SysUser>
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="isOracleDb">是否OracleDb</param>
        public SysUserMap(bool isOracleDb, bool isConverToUpper) : base(isOracleDb, isConverToUpper) { }


        /// <summary>
        /// 默认属性映射配置
        /// </summary>
        public override void Configure(EntityTypeBuilder<SysUser> builder)
        {
            //表名
            builder.HasBaseType("SysUser".ToUpper(IsOracleDb, IsConvertToUpperChar));
            // Primary Key
            builder.HasKey(t => t.Id);
            builder.HasAlternateKey(t => t.UserName);

            // Properties
            builder.Property(t => t.Id)
                .IsRequired()
                .HasMaxLength(36);

            builder.Property(t => t.UserName).IsRequired().HasMaxLength(50);

            builder.Property(t => t.EmpNo).HasMaxLength(100);

            builder.Property(t => t.EmpName).HasMaxLength(50);

            builder.Property(t => t.EmpSex).HasMaxLength(2);

            builder.Property(t => t.EmpBirth).HasMaxLength(10);

            builder.Property(t => t.EmpPinyin).HasMaxLength(50);

            builder.Property(t => t.Email).HasMaxLength(250);

            builder.Property(t => t.EmailConfirmed);

            builder.Property(t => t.PasswordHash).HasMaxLength(255);

            builder.Property(t => t.SecurityStamp).HasMaxLength(36);

            builder.Property(t => t.PhoneNumber).HasMaxLength(50);

            builder.Property(t => t.PhoneNumberConfirmed);

            builder.Property(t => t.TwoFactorEnabled);

            builder.Property(t => t.LockoutEndDateUtc);

            builder.Property(t => t.LockoutEnabled);

            builder.Property(t => t.AccessFailedCount);

            builder.Property(t => t.LastLoginDate);

            builder.Property(t => t.SortId);

            builder.Property(t => t.Discriminator).HasMaxLength(200);

            builder.Property(t => t.IsSupper);

            builder.Property(t => t.Creator).HasMaxLength(200);

            // Table & Column Mappings
            builder.Property(t => t.Id).HasField("Id".ToUpper(IsOracleDb, IsConvertToUpperChar));
            builder.Property(t => t.UserName).HasField("UserName".ToUpper(IsOracleDb, IsConvertToUpperChar));
            builder.Property(t => t.EmpNo).HasField("EmpNo".ToUpper(IsOracleDb, IsConvertToUpperChar));
            builder.Property(t => t.EmpName).HasField("EmpName".ToUpper(IsOracleDb, IsConvertToUpperChar));
            builder.Property(t => t.EmpSex).HasField("EmpSex".ToUpper(IsOracleDb, IsConvertToUpperChar));
            builder.Property(t => t.EmpBirth).HasField("EmpBirth".ToUpper(IsOracleDb, IsConvertToUpperChar));
            builder.Property(t => t.EmpPinyin).HasField("EmpPinyin".ToUpper(IsOracleDb, IsConvertToUpperChar));
            builder.Property(t => t.Email).HasField("Email".ToUpper(IsOracleDb, IsConvertToUpperChar));
            builder.Property(t => t.EmailConfirmed).HasField("EmailConfirmed".ToUpper(IsOracleDb, IsConvertToUpperChar));
            builder.Property(t => t.PasswordHash).HasField("PasswordHash".ToUpper(IsOracleDb, IsConvertToUpperChar));
            builder.Property(t => t.SecurityStamp).HasField("SecurityStamp".ToUpper(IsOracleDb, IsConvertToUpperChar));
            builder.Property(t => t.PhoneNumber).HasField("PhoneNumber".ToUpper(IsOracleDb, IsConvertToUpperChar));
            builder.Property(t => t.PhoneNumberConfirmed).HasField("PhoneNumberConfirmed".ToUpper(IsOracleDb, IsConvertToUpperChar));
            builder.Property(t => t.TwoFactorEnabled).HasField("TwoFactorEnabled".ToUpper(IsOracleDb, IsConvertToUpperChar));
            builder.Property(t => t.LockoutEndDateUtc).HasField("LockoutEndDateUtc".ToUpper(IsOracleDb, IsConvertToUpperChar));
            builder.Property(t => t.LockoutEnabled).HasField("LockoutEnabled".ToUpper(IsOracleDb, IsConvertToUpperChar));
            builder.Property(t => t.AccessFailedCount).HasField("AccessFailedCount".ToUpper(IsOracleDb, IsConvertToUpperChar));
            builder.Property(t => t.LastLoginDate).HasField("LastLoginDate".ToUpper(IsOracleDb, IsConvertToUpperChar));
            builder.Property(t => t.SortId).HasField("SortId".ToUpper(IsOracleDb, IsConvertToUpperChar));
            builder.Property(t => t.Discriminator).HasField("Discriminator".ToUpper(IsOracleDb, IsConvertToUpperChar));
            builder.Property(t => t.IsSupper).HasField("IsSupper".ToUpper(IsOracleDb, IsConvertToUpperChar));
            builder.Property(t => t.Creator).HasField("Creator".ToUpper(IsOracleDb, IsConvertToUpperChar));

            builder.HasMany(u => u.UserRoles).WithOne(u => u.User).HasForeignKey(u => u.UserId);
            builder.HasMany(u => u.UserClaims).WithOne(u => u.User).HasForeignKey(u => u.UserId);
            builder.HasMany(u => u.UserDepts).WithOne(u => u.User).HasForeignKey(u => u.UserId);
            builder.HasMany(u => u.UserLogins).WithOne(u => u.User).HasForeignKey(u => u.UserId);
            builder.HasMany(u => u.UserTokens).WithOne(u => u.User).HasForeignKey(u => u.UserId);

            //builder.Property(u => u.UserName)
            //    .HasAnnotation("Index",
            //    new IndexAnnotation(new IndexAttribute("SysUserNameIndex") { IsUnique = true }));

        }

    }

}


