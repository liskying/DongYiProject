using System;
using System.Collections.Generic;

namespace Dy.Data.Domain
{


    /// <summary>
    /// 操作日志标准定义
    /// </summary>
    public class SysLog
    {
        public SysLog()
        {
            LogDetails = new List<SysLogDetail>();
        }

        /// <summary>
        /// 日志Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 部门Id
        /// </summary>
        public string DeptId { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string DeptName { get; set; }
        /// <summary>
        /// 用户账号
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        public string EmpName { get; set; }
        /// <summary>
        /// 登录IP
        /// </summary>
        public string LogIP { get; set; }
        /// <summary>
        /// 日志类型
        /// </summary>
        public string LogType { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string LogContent { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 导航属性:日志明细
        /// </summary>
        public virtual ICollection<SysLogDetail> LogDetails { get; set; }
    }
}
