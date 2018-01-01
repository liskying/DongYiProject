using Dy.Data.Domain;
using Dy.Data.DomainMap;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Dy.Data
{
    /// <summary>
    /// 数据库上下文
    /// </summary>
    public class DyDbContext : IdentityDbContext<SysUser, SysRole, string, SysUserClaim, SysUserRole, SysUserLogin, SysRoleClaim, SysUserToken>
    {
        /// <summary>
        /// Oracle数据库标识
        /// </summary>
        /// <remarks>
        /// true:oracle数据库
        /// false:其他数据库
        /// </remarks>
        private bool _oracleFlag;
        /// <summary>
        /// Db=Oracle时，是否把关键字转大写
        /// </summary>
        private bool _isConverToUpper;

        /// <summary>
        /// 是否Oracle数据库
        /// </summary>
        public bool IsOracleDb { get { return _oracleFlag; } }
        /// <summary>
        /// Oracle数据库时，内置表表名以及字段是否转换为大写形式
        /// </summary>
        public bool IsConverToUpperWhenOrable { get { return _isConverToUpper; } }

        /// <summary>
        /// 用户邮箱是否唯一
        /// </summary>
        public bool RequireUniqueEmail { get; set; }

        public DyDbContext(DbContextOptions<DyDbContext> options) : base(options)
        {
            _oracleFlag = false;
            _isConverToUpper = false;
        }
        /// <summary>
        /// 菜单
        /// </summary>
        public DbSet<SysMenu> SysMenu { get; set; }
        /// <summary>
        /// 操作按钮
        /// </summary>
        public DbSet<SysOperate> SysOperate { get; set; }
        /// <summary>
        /// 日志
        /// </summary>
        public DbSet<SysLog> SysLog { get; set; }
        /// <summary>
        /// 日志明细
        /// </summary>
        public DbSet<SysLogDetail> SysLogDetail { get; set; }
        /// <summary>
        /// 字典
        /// </summary>
        public DbSet<SysDictionary> SysDictionary { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        public DbSet<SysDept> SysDept { get; set; }
        /// <summary>
        /// 用户
        /// </summary>
        public DbSet<SysUser> SysUser { get; set; }
        /// <summary>
        /// 角色
        /// </summary>
        public DbSet<SysRole> SysRole { get; set; }
        /// <summary>
        /// 用户权限
        /// </summary>
        public DbSet<SysRight> SysRight { get; set; }
        /// <summary>
        /// 用户部门
        /// </summary>
        public DbSet<SysUserDept> SysUserDept { get; set; }
        /// <summary>
        /// 用户角色
        /// </summary>
        public DbSet<SysUserRole> SysUserRole { get; set; }
        /// <summary>
        /// 用户声明
        /// </summary>
        public DbSet<SysUserClaim> SysUserClaim { get; set; }
        /// <summary>
        /// 用户登录
        /// </summary>
        public DbSet<SysUserLogin> SysUserLogin { get; set; }
        /// <summary>
        /// 角色声明
        /// </summary>
        public DbSet<SysRoleClaim> SysRoleClaim { get; set; }
        /// <summary>
        /// 用户令牌
        /// </summary>
        public DbSet<SysUserToken> SysUserToken { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            new SysDeptMap(_oracleFlag, _isConverToUpper).Configure(builder.Entity<SysDept>());
            new SysDictionaryMap(_oracleFlag, _isConverToUpper).Configure(builder.Entity<SysDictionary>());
            new SysLogMap(_oracleFlag, _isConverToUpper).Configure(builder.Entity<SysLog>());
            new SysLogDetailMap(_oracleFlag, _isConverToUpper).Configure(builder.Entity<SysLogDetail>());
            new SysMenuMap(_oracleFlag, _isConverToUpper).Configure(builder.Entity<SysMenu>());

            new SysOperateMap(_oracleFlag, _isConverToUpper).Configure(builder.Entity<SysOperate>());
            new SysRightMap(_oracleFlag, _isConverToUpper).Configure(builder.Entity<SysRight>());
            new SysRoleMap(_oracleFlag, _isConverToUpper).Configure(builder.Entity<SysRole>());
            new SysRoleClaimMap(_oracleFlag, _isConverToUpper).Configure(builder.Entity<SysRoleClaim>());
            new SysUserMap(_oracleFlag, _isConverToUpper).Configure(builder.Entity<SysUser>());

            new SysUserClaimMap(_oracleFlag, _isConverToUpper).Configure(builder.Entity<SysUserClaim>());
            new SysUserDeptMap(_oracleFlag, _isConverToUpper).Configure(builder.Entity<SysUserDept>());
            new SysUserLoginMap(_oracleFlag, _isConverToUpper).Configure(builder.Entity<SysUserLogin>());
            new SysUserRoleMap(_oracleFlag, _isConverToUpper).Configure(builder.Entity<SysUserRole>()); ;
            new SysUserTokenMap(_oracleFlag, _isConverToUpper).Configure(builder.Entity<SysUserToken>());

            #region 其他设置


            #endregion


            //base.OnModelCreating(builder);
        }



    }
}
