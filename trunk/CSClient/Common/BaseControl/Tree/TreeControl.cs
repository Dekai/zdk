using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace BaseControl.Tree
{
       public delegate void TreeNodeDelegate(TreeNodeInfo t);
    public partial class TreeControl : XtraUserControl
    {
        public TreeControl()
        {
            InitializeComponent();
            this.treeView1.NodeMouseClick += new TreeNodeMouseClickEventHandler(treeView1_NodeMouseClick);
        }

        void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (NodeClick != null)
            {
                TreeNode node = e.Node;
                if (node.Tag != null)
                {
                    TreeNodeInfo info = node.Tag as TreeNodeInfo;
                    NodeClick(info);
                }
            }
        }
        public event TreeNodeDelegate NodeClick;

        public bool IsShowCheckBox
        {
            set
            {
                this.treeView1.CheckBoxes = value; 
            }
        }

        public List<TreeNodeInfo> Nodes { get; set; }
        public void DataBind()
        {
            this.treeView1.Nodes.Clear();

            if (Nodes == null) return;

            foreach(TreeNodeInfo nodeinfo in Nodes){

                TreeNode node = new TreeNode();
                node.Text = nodeinfo.Text;
                node.Tag = nodeinfo;
             
                this.treeView1.Nodes.Add(node);

                if (nodeinfo.Childs != null)
                {
                    CreateChild(node, nodeinfo.Childs);
                }
            }

        }
        private void CreateChild(TreeNode pnode, List<TreeNodeInfo> list)
        {
            foreach (TreeNodeInfo nodeinfo in list)
            {

                TreeNode node = new TreeNode();
                node.Text = nodeinfo.Text;
                node.Tag = nodeinfo;
                pnode.Nodes.Add(node);

                if (nodeinfo.Childs != null)
                {
                    CreateChild(node, nodeinfo.Childs);
                }
            }
        }

        public void ExpandAll()
        {
            this.treeView1.ExpandAll();
        }

        public TreeNodeInfo GetDataRow()
        {
            if (this.treeView1.SelectedNode != null)
            {
               return  this.treeView1.SelectedNode.Tag  as TreeNodeInfo;

            }
            return null;
        }


        public List<TreeNodeInfo> GetSelectNodes()
        {
            List<TreeNodeInfo> l = new List<TreeNodeInfo>();
            foreach (TreeNode node in this.treeView1.Nodes)
            {
                if (node.Checked)
                {
                    l.Add(node.Tag as TreeNodeInfo);
                }

                GetSelectChildNodes(node, l);
            }
            return l;
        
        }

        private void GetSelectChildNodes(TreeNode pnode, List<TreeNodeInfo> l)
        {
            if (pnode.Nodes == null) return;

            foreach (TreeNode node in pnode.Nodes)
            {
                if (node.Checked)
                {
                    l.Add(node.Tag as TreeNodeInfo);
                }
                GetSelectChildNodes(node,l);
            }
        }

        public void SetSelectNodes(List<string> ids)
        {
            ClearCheckBox();
            foreach (TreeNode node in this.treeView1.Nodes)
            {
                TreeNodeInfo ifo = node.Tag as TreeNodeInfo;
                if (ids.Contains(ifo.ID))
                {
                    node.Checked = true;
                }

                SetSelectChildNodes(node, ids);
            }
        }

        private void SetSelectChildNodes(TreeNode pnode, List<string> ids)
        {
            if (pnode.Nodes == null) return;

            foreach (TreeNode node in pnode.Nodes)
            {
                TreeNodeInfo ifo = node.Tag as TreeNodeInfo;
                if (ids.Contains(ifo.ID))
                {
                    node.Checked = true;
                }

                SetSelectChildNodes(node, ids);
            }
        }




        private void ClearCheckBox()
        {
            foreach (TreeNode node in this.treeView1.Nodes)
            {
                node.Checked = false;
                ClearChildCheckBox(node);
            }
        }

        private void ClearChildCheckBox(TreeNode pnode)
        {
            if (pnode.Nodes == null) return;

            foreach (TreeNode node in pnode.Nodes)
            {
                node.Checked = false;
                ClearChildCheckBox(node);
            }
        }
    }
}
