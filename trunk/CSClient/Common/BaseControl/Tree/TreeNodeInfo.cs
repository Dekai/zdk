using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaseControl.Tree
{
    public class TreeNodeInfo
    {
        public string ID { get; set; }
        public string Text { get; set; }
        public object Tag { get; set; }
        public TreeNodeInfo ParentNodeInfo { get; set; }
        public List<TreeNodeInfo> Childs { get; set; }

        
    }
}
