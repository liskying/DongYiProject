using System;
namespace Dy.Data.Domain
{
    /// <summary>
    /// 日志明细标准定义
    /// </summary>
    public class SysLogDetail
    {
        /// <summary>
        /// 日志明细Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 日志Id
        /// </summary>
        public int LogId { get; set; }
        /// <summary>
        /// 日志关联表
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// 日志关联字段
        /// </summary>
        public string FieldName { get; set; }
        /// <summary>
        /// 字段原值
        /// </summary>
        public string OriginalVal { get; set; }
        /// <summary>
        /// 字段新值
        /// </summary>
        public string NewValue { get; set; }
        /// <summary>
        /// 日志操作类型
        /// </summary>
        public string OperateType { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime? CreateTime { get; set; }

    }
}
