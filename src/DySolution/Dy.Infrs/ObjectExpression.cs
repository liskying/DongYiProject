using System;
using System.Collections.Generic;
using System.Text;

namespace Dy.Infrs
{
    /// <summary>
    /// 对象扩展
    /// </summary>
    public static class ObjectExpression
    {
        /// <summary>
        /// Entity关键字转大写
        /// </summary>
        /// <param name="old">源字符串</param>
        /// <param name="isOrable">是否Orable</param>
        /// <param name="IsConvertToUpperChar">是否需要转为大写</param>
        /// <returns></returns>
        public static string ToUpper(this string old, bool isOrable, bool IsConvertToUpperChar)
        {
            if (isOrable && IsConvertToUpperChar)
            {
                return old.ToUpper();
            }
            return old;
        }
    }
}
