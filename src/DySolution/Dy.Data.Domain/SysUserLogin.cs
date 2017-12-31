using Microsoft.AspNetCore.Identity;

namespace Dy.Data.Domain
{
    /// <summary>
    /// 用户登录
    /// </summary>
    public class SysUserLogin : IdentityUserLogin<string>
    {

        /// <summary>
        /// 主键Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        public override string UserId { get; set; }

        /// <summary>
        /// 提供登录的登录提供程序标识
        /// </summary>
        public override string LoginProvider { get; set; }

        /// <summary>
        /// 提供登录的登录提供程序Key
        /// </summary>
        public override string ProviderKey { get; set; }
        /// <summary>
        /// 用户
        /// </summary>
        public virtual SysUser User { get; set; }
    }
}
