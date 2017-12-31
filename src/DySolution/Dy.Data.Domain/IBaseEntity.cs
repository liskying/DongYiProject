using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Dy.Data.Domain
{
    /// <summary>
    /// 表公共属性
    /// </summary>
    public interface IBaseEntity
    {

        /// <summary>
        /// 时间戳
        /// </summary>
        [Timestamp]
        byte[] RowVersion { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DataMember]
        DateTime? CreateTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [DataMember]
        DateTime? UpdateTime { get; set; }

        /// <summary>
        /// 删除标识
        /// </summary>
        [DataMember]
        DeleteState? DeleteState { get; set; }
    }
}
