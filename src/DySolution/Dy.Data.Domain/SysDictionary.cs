using Dy.Core.Enums;
using System;
using System.Collections.Generic;

namespace Dy.Data.Domain
{


    /// <summary>
    /// 字典标准定义
    /// </summary>
    public class SysDictionary : IBaseEntity
    {
        public SysDictionary()
        {
        }

        /// <summary>
        /// 字典Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 上级字典Id
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        /// 字典类型(开发用)
        /// </summary>
        public string DicType { get; set; }

        /// <summary>
        /// 字典Key(开发用)
        /// </summary>
        public string DicKey { get; set; }

        /// <summary>
        /// 字典Value(开发用)
        /// </summary>
        public string DicValue { get; set; }

        /// <summary>
        /// 显示名称(显示用)
        /// </summary>
        public string DisName { get; set; }

        /// <summary>
        /// 字典层级,数字越大层级越低
        /// </summary>
        public int? DicLevel { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool? IsEnabed { get; set; }

        /// <summary>
        /// 字典排序
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
        /// 是否启用
        /// </summary>
        public bool? IsEnabled { get; set; }
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
