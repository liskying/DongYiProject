using Dy.Data.Domain;
using System;

namespace Dy.Data.Domain
{


    /// <summary>
    /// 权限标准定义
    /// </summary>
    public class SysRight : IBaseEntity
    {
        public string Id { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 模块权限
        /// </summary>
        public string ModuleRight { get; set; }
        /// <summary>
        /// 业务权限范围
        /// </summary>
        public string BizScope { get; set; }
        /// <summary>
        /// 管理权限范围
        /// </summary>
        public string ManagerScope { get; set; }
        /// <summary>
        /// 移动端权限
        /// </summary>
        public string MobileRight { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public  string Creator { get; set; }


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
