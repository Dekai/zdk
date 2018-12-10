using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BaseControl.Tree;
using Library.Controller;
using System.Data;
using Plugins.DataView.SystemSeting.Role;

namespace Plugins.DataView.ExperimentalData
{
    /// <summary>
    /// DataInput.xaml 的交互逻辑
    /// </summary>
    public partial class DataInput : UserControl
    {
        public DataInput()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(DataInput_Loaded);
        }

        #region 表格
        public TreeControl TreeControl
        {
            get
            {
                if (m_TreeControl == null)
                {
                    m_TreeControl = new TreeControl();
                    m_TreeControl.IsShowCheckBox = false;
                    m_TreeControl.NodeClick += new TreeNodeDelegate(m_TreeControl_NodeClick);
                    List<TreeNodeInfo> Nodes = new List<TreeNodeInfo>();
                    DataTable dt = SystemManager.Instance.Services.DataDicInfoService.GetList("F_TypeCode='T_Test_Table_Type' order by F_Order").Tables[0];
                    foreach (DataRow row in dt.Rows)
                    {
                        TreeNodeInfo pinfo = new TreeNodeInfo();
                        pinfo.ID = row["F_ID"].ToString();
                        pinfo.Text = row["F_Name"].ToString();
                        pinfo.Childs = new List<TreeNodeInfo>();
                        Nodes.Add(pinfo);
                        DataTable sdt = SystemManager.Instance.Services.Test_Table_TempleteService.GetList("F_TypeID='" + pinfo.ID + "' order by F_Order").Tables[0];
                        foreach (DataRow srow in sdt.Rows)
                        {
                            TreeNodeInfo info = new TreeNodeInfo();
                            info.ID = srow["F_ID"].ToString();
                            info.Text = srow["F_Name"].ToString();
                            info.Tag = srow;
                            pinfo.Childs.Add(info);
                        }
                    }
                    TreeControl.Nodes = Nodes;
                    TreeControl.DataBind();
                    TreeControl.ExpandAll();
                }
                return m_TreeControl;
            }
        }

        private TreeControl m_TreeControl;
        #endregion
        void DataInput_Loaded(object sender, RoutedEventArgs e)
        {
            host1.Child = TreeControl;
        }


        void m_TreeControl_NodeClick(TreeNodeInfo t)
        {
            if (t.Tag != null)
            {
                DataInputGrid eidt = new DataInputGrid();
                eidt.LayoutTable(t.ID);
                Frame1.Source = eidt;
            }
        }

        private void btnSplit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (colLeft.Width.Value == 0)
            {
                colLeft.Width =  new GridLength(180);
                host1.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                colLeft.Width = new GridLength(0);
                host1.Visibility = System.Windows.Visibility.Collapsed;
            }
        }
    }
}
