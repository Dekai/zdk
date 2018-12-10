using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Library.Model
{
    public class PagerTable
    {
        public int TotalCount{get;set;}

        public DataTable DataSource { get; set; }
    }
}
