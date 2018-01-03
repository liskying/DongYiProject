using Dy.Core.Enums;
using System;
using System.Collections.Generic;

namespace Dy.Data.Domain
{
    public class SysDept : IBaseEntity
    {
        /// <summary>
        /// 部门Id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 部门名
        /// </summary>
        public string DeptName { get; set; }

        /// <summary>
        /// 上级部门Id
        /// </summary>
        public string ParentId { get; set; }
        /// <summary>
        /// 部门Code
        /// </summary>
        public string DeptCode { get; set; }
        /// <summary>
        /// 部门类型
        /// </summary>
        public string DeptType { get; set; }

        /// <summary>
        /// 部门层级
        /// </summary>
        public int? DeptLevel { get; set; }

        /// <summary>
        /// 部门地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 部门电话
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// 部门排序
        /// </summary>
        public int? SortId { get; set; }

        /// <summary>
        /// 创建者
        /// </summary>
        public string Creator { get; set; }

        /// <summary>
        /// 部门用户
        /// </summary>
        public ICollection<SysUserDept> Users { get; set; }

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
    }
}
