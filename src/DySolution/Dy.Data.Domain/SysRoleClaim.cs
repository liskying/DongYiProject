using Microsoft.AspNetCore.Identity;

namespace Dy.Data.Domain
{
    /// <summary>
    /// 角色声明
    /// </summary>
    public class SysRoleClaim : IdentityRoleClaim<string>
    {
        /// <summary>
        /// 角色声明Id
        /// </summary>
        public override int Id { get; set; }
        /// <summary>
        /// 角色声明类型
        /// </summary>
        public override string ClaimType { get; set; }
        /// <summary>
        /// 角色声明值
        /// </summary>
        public override string ClaimValue { get; set; }
        /// <summary>
        /// 角色Id
        /// </summary>
        public override string RoleId { get; set; }
        /// <summary>
        /// 角色
        /// </summary>
        public virtual SysRole Role { get; set; }
    }
}
