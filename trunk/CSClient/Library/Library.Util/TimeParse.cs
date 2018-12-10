using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Common
{
    public class TimeParse
    {
        public static string GetTwoChar(string value)
        {
            if (value.Trim().Length == 1)
            {
                return "0" + value;
            }
            return value;
        }
    }
}
