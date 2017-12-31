using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dy.Data.Domain
{
    /// <summary>
    /// 用户角色
    /// </summary>
    public class SysUserRole : IdentityUserRole<string>, IBaseEntity
    {

        /// <summary>
        /// 用户-角色Id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        ///  用户Id
        /// </summary>
        public new string UserId { get; set; }

        /// <summary>
        /// 角色Id
        /// </summary>
        public new string RoleId { get; set; }

        /// <summary>
        /// 是否主角色
        /// </summary>
        public bool? IsMajor { get; set; }

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
        /// 用户
        /// </summary>
        public virtual SysUser User { get; set; }
        /// <summary>
        /// 角色
        /// </summary>
        public virtual SysRole Role { get; set; }
    }
}
