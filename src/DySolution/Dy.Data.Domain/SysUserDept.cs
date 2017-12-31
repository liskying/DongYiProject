using System;

namespace Dy.Data.Domain
{
    /// <summary>
    /// 用户部门
    /// </summary>
    public class SysUserDept : IBaseEntity
    {
        /// <summary>
        /// 用户-部门Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///  用户Id
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 部门Id
        /// </summary>
        public string DeptId { get; set; }

        /// <summary>
        /// 是否主部门
        /// </summary>
        public bool? IsMajor { get; set; }

        /// <summary>
        /// 任职状态
        /// </summary>
        public bool? JobState { get; set; }
        /// <summary>
        /// 任职时间
        /// </summary>
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// 离职时间
        /// </summary>
        public DateTime? EndDate { get; set; }

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
        /// 部门
        /// </summary>
        public virtual SysDept Dept { get; set; }
        /// <summary>
        /// 用户
        /// </summary>
        public virtual SysUser User { get; set; }
    }
}
