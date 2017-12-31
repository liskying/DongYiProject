
using Dy.Data.Domain.Enums;
using System;

namespace Dy.Data.Domain
{
    /// <summary>
    /// 菜单标准定义
    /// </summary>
    public class SysMenu : IBaseEntity
    {
        /// <summary>
        /// 菜单编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 菜单Code
        /// </summary>
        public string MenuCode { get; set; }
        /// <summary>
        /// 菜单名
        /// </summary>
        public string MenuName { get; set; }
        /// <summary>
        /// 父菜单编号
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        /// 菜单类型:1Web,2Android,3Apple,4WinPhone
        /// </summary>
        /// <remarks>
        /// </remarks>
        public DeviceMenuType? MenuType { get; set; }

        /// <summary>
        /// 菜单状态
        /// </summary>
        /// <remarks>
        /// true:打开
        /// false:关闭
        /// </remarks>
        public bool? MenuState { get; set; }

        /// <summary>
        /// 菜单地址
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 图标样式或地址
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int? SortId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }

        /// <summary>
        /// 创建者
        /// </summary>
        public string Creator { get; set; }
        /// <summary>
        /// 版本号
        /// </summary>
        public byte[] RowVersion { get; set; }
        /// <summary>
        /// 删除标识
        /// </summary>
        public DeleteState? DeleteState { get; set; }
    }
}
