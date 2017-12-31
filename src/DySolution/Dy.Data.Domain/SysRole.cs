using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Dy.Data.Domain
{
    /// <summary>
    /// 角色信息
    /// </summary>
    public class SysRole : IdentityRole<string>, IBaseEntity
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public SysRole()
        {
            UserRoles = new List<SysUserRole>();
            RoleClaims = new List<SysRoleClaim>();
        }

        /// <summary>
        /// 角色Id
        /// </summary>
        public new string Id { get; set; }

        /// <summary>
        /// 角色名
        /// </summary>
        public new string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public new string NormalizedName { get; set; }

        
        /// <summary>
        /// 是否内置管理角色
        /// </summary>
        public bool? IsSystem { get; set; }

        /// <summary>
        /// 模块权限
        /// </summary>
        public string ModuleRight { get; set; }

        /// <summary>
        /// 移动端权限
        /// </summary>
        public string MobileRight { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int? SortId { get; set; }

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
        /// 角色所属用户
        /// </summary>
        public virtual ICollection<SysUserRole> UserRoles { get; private set; }
        public virtual ICollection<SysRoleClaim> RoleClaims { get; set; }
    }
}
