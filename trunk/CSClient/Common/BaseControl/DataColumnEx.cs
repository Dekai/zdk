using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BaseControl
{
    public  class DataColumnEx : DataColumn
    {
        public DataColumnEx(string name, Type t)
            : base(name, t)
        {
            ExPropertys = new Dictionary<string, string>();
        }

        public DataColumnEx()
        {
            ExPropertys = new Dictionary<string, string>();
        }
        public Dictionary<string, string> ExPropertys { get; set; }
    }
}
