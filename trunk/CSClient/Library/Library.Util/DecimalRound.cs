using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Common
{
    public static class DecimalRoundUtil
    {
        /// <summary>
        /// 格式化字符串数字精度
        /// </summary>
        /// <param name="str"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string FormatDecimal(this string str, int len)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }

            double d;
            if (double.TryParse(str, out d))
            {
                if (double.NaN.Equals(d))
                {
                    return str;
                }
                return Math.Round(d, len, MidpointRounding.AwayFromZero).ToString();

            }
            return d.ToString();
        }


        /// <summary>
        /// 四舍五入
        /// </summary>
        /// <param name="d"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static double Round(this double d, int len)
        {
            return Math.Round(d, len, MidpointRounding.AwayFromZero);
        }

    
    }
}
