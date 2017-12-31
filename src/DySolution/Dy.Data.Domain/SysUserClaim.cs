using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Dy.Data.Domain
{
    /// <summary>
    /// 用户声明
    /// </summary>
    public class SysUserClaim : IdentityUserClaim<string>
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public override int Id { get; set; }
        /// <summary>
        /// 声明类型
        /// </summary>
        public override string ClaimType { get; set; }
        /// <summary>
        /// 声明值
        /// </summary>
        public override string ClaimValue { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        public override string UserId { get; set; }
        /// <summary>
        /// 用户
        /// </summary>
        public virtual SysUser User { get; set; }
    }
}
