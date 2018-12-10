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
using Library.Controller;
using System.Data;
using BaseControl;
using BaseControl.Tree;

namespace Plugins.DataView.SystemSeting.Right
{
    /// <summary>
    /// RightList.xaml 的交互逻辑
    /// </summary>
    public partial class RightList : UserControl
    {
        public RightList()
        {
            InitializeComponent();
            BandGridData();
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
                    host1.Child = m_TreeControl;
                }
                return m_TreeControl;
            }
        }
        private TreeControl m_TreeControl;
        #endregion


        private void BandGridData()
        {
          
            TreeControl.Nodes = SystemManager.Instance.Services.RightService.GetNodes();
            TreeControl.DataBind();
            TreeControl.ExpandAll();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            RightEdit win = new RightEdit();
            win.SaveComplete += (model) =>
            {
                BandGridData();
                MessageBox.Show("保存" + model.F_Name + "成功！");
            };
            win.ShowDialog();
        }

   

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            DataRow row = (this.TreeControl.GetDataRow() as TreeNodeInfo).Tag as DataRow;
            if (row != null)
            {
                int id = int.Parse(row["F_ID"].ToString());
                RightEdit win = new RightEdit();
                win.LoadData(id);
                win.SaveComplete += (model) =>
                {
                    BandGridData();
                    MessageBox.Show("保存" + model.F_Name + "成功！");
                };
                win.ShowDialog();
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            DataRow row = (this.TreeControl.GetDataRow() as TreeNodeInfo).Tag as DataRow;
            if (row != null)
            {
                if (MessageBox.Show("是否确认删除？", "提示", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    int id = int.Parse(row["F_ID"].ToString());
                    Library.Controller.SystemManager.Instance.Services.RightService.Delete(id);
                    BandGridData();
                }
            }
            else
            {
                MessageBox.Show("请选择一行数据！");
            }
        }
    }
}
