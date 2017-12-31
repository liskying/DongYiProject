using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dy.Data.Domain
{
    /// <summary>
    /// 用户令牌
    /// </summary>
    public class SysUserToken : IdentityUserToken<string>
    {
        /// <summary>
        /// 登录提供者
        /// </summary>
        public override string LoginProvider { get; set; }

        /// <summary>
        /// 令牌名称
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        public override string UserId { get; set; }

        /// <summary>
        /// 令牌信息
        /// </summary>
        public override string Value { get; set; }
        /// <summary>
        /// 用户
        /// </summary>
        public virtual SysUser User { get; set; }
    }
}
