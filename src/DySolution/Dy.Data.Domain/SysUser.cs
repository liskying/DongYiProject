using Dy.Core.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Dy.Data.Domain
{
    /// <summary>
    /// 用户信息
    /// </summary>
    public class SysUser : IdentityUser<string>, IBaseEntity
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public SysUser()
        {
            UserClaims = new List<SysUserClaim>();
            UserRoles = new List<SysUserRole>();
            UserLogins = new List<SysUserLogin>();
            UserDepts = new List<SysUserDept>();
            UserTokens = new List<SysUserToken>();
        }
        public SysUser(string userName) : base(userName)
        {
            UserClaims = new List<SysUserClaim>();
            UserRoles = new List<SysUserRole>();
            UserLogins = new List<SysUserLogin>();
            UserDepts = new List<SysUserDept>();
            UserTokens = new List<SysUserToken>();
        }

        /// <summary>
        /// 用户Id
        /// </summary>
        public new string Id { get; set; }

        /// <summary>
        /// 登录账号
        /// </summary>
        public new string UserName { get; set; }

        /// <summary>
        /// 用户工号(方便单点登录)
        /// </summary>
        public string EmpNo { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string EmpName { get; set; }

        /// <summary>
        /// 用户性别
        /// </summary>
        public string EmpSex { get; set; }

        /// <summary>
        /// 用户生日
        /// </summary>
        public string EmpBirth { get; set; }

        /// <summary>
        /// 姓名拼音
        /// </summary>
        public string EmpPinyin { get; set; }

        /// <summary>
        /// 电子邮件
        /// </summary>
        public new string Email { get; set; }

        /// <summary>
        /// 电子邮件是否已验证
        /// </summary>
        public new bool? EmailConfirmed { get; set; }

        /// <summary>
        /// 哈希密码
        /// </summary>
        public new string PasswordHash { get; set; }

        /// <summary>
        /// 安全快照
        /// 一个随机值，每当用户凭据发生更改（密码更改、登录删除）时，该值将发生更改
        /// </summary>
        public new string SecurityStamp { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public new string PhoneNumber { get; set; }

        /// <summary>
        /// 手机验证是否已验证
        /// </summary>
        public new bool? PhoneNumberConfirmed { get; set; }

        /// <summary>
        /// 是否启用双因素认证
        /// </summary>
        public new bool? TwoFactorEnabled { get; set; }

        /// <summary>
        /// 锁定时间.
        /// </summary>
        public DateTime? LockoutEndDateUtc { get; set; }

        /// <summary>
        /// 是否启用锁定
        /// </summary>
        public new bool? LockoutEnabled { get; set; }

        /// <summary>
        /// 登录失败次数
        /// </summary>
        public new int? AccessFailedCount { get; set; }

        /// <summary>
        /// 最后登录时间
        /// </summary>
        public DateTime? LastLoginDate { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int? SortId { get; set; }

        /// <summary>
        /// 是否超级管理员
        /// </summary>
        public bool? IsSupper { get; set; }

        /// <summary>
        /// 用户区分标识
        /// </summary>
        public string Discriminator { get; set; }

        /// <summary>
        /// 创建者
        /// </summary>
        public string Creator { get; set; }


        /// <summary>
        /// 版本号
        /// </summary>
        public byte[] RowVersion { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }
        /// <summary>
        /// 删除标识
        /// </summary>
        public DeleteState? DeleteState { get; set; }
        /// <summary>
        /// 用户所属角色
        /// </summary>
        public virtual ICollection<SysUserRole> UserRoles { get; private set; }

        /// <summary>
        /// 用户登录声明
        /// </summary>
        public virtual ICollection<SysUserClaim> UserClaims { get; private set; }

        /// <summary>
        /// 用户登录信息
        /// </summary>
        public virtual ICollection<SysUserLogin> UserLogins { get; private set; }
        /// <summary>
        /// 用户所在部门
        /// </summary>
        public virtual ICollection<SysUserDept> UserDepts { get; set; }
        public virtual ICollection<SysUserToken> UserTokens { get; set; }
    }
}
