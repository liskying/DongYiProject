namespace Dy.Data.Domain
{
    /// <summary>
    /// 按钮类标准定义
    /// </summary>
    public class SysOperate
    {
        /// <summary>
        /// 操作Code
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 操作项Code
        /// </summary>
        public string OptionCode { get; set; }
        /// <summary>
        /// 操作名称
        /// </summary>
        public string OptionName { get; set; }
        /// <summary>
        /// 按钮样式
        /// </summary>
        public string Style { get; set; }
        /// <summary>
        /// 按钮图标
        /// </summary>
        public string Icon { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int? SortId { get; set; }
    }
}
