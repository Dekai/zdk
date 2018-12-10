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
using System.Data;
using Library.Controller;
using BaseControl;
using Library.Model;

namespace Plugins.DataView.ExperimentalData
{
    /// <summary>
    /// DataHistory.xaml 的交互逻辑
    /// </summary>
    public partial class DataHistory : UserControl
    {
        public DataHistory()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(DataInput_Loaded);
        }

        private void btnSplit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (colLeft.Width.Value == 0)
            {
                colLeft.Width = new GridLength(180);
                host1.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                colLeft.Width = new GridLength(0);
                host1.Visibility = System.Windows.Visibility.Collapsed;
            }
        }



        #region 树
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

        #region 表格
        public BandGridView GridView
        {
            get
            {
                if (m_GridView == null)
                {
                    m_GridView = new BandGridView();
                    List<BandInfo> Bands = GetRecordBands();
                    m_GridView.InitData(Bands);
                    host2.Child = GridView;
                    DataPager.Visibility = System.Windows.Visibility.Visible;
                    toolbox.Visibility = System.Windows.Visibility.Visible;
                }
                return m_GridView;
            }
        }
        private List<BandInfo> GetRecordBands()
        {
            List<BandInfo> Bands = new List<BandInfo>();
            BandInfo b0 = new BandInfo();
            b0.HanderTitle = "标题";
            b0.FieldName = "F_BannerContent";
            b0.Width = 800;
            Bands.Add(b0);

            BandInfo b1 = new BandInfo();
            b1.HanderTitle = "录入时间";
            b1.FieldName = "F_Time";
            b1.Width = 100;
            Bands.Add(b1);

            BandInfo b2 = new BandInfo();
            b2.HanderTitle = "是否在大屏中显示";
            b2.FieldName = "Show";
            b2.Width = 120;
            Bands.Add(b2);
            

            return Bands;
        }
        private BandGridView m_GridView;
        private string m_TempleteId;
        #endregion

        void DataInput_Loaded(object sender, RoutedEventArgs e)
        {
            host1.Child = TreeControl;
            BandGridData();
        }

        void m_TreeControl_NodeClick(TreeNodeInfo t)
        {
            if (t.Tag != null)
            {
                m_TempleteId = t.ID;
                this.DataPager.PageIndex = 1;
                BandGridData();
            }
        }

        private void BandGridData()
        {
            if (!string.IsNullOrEmpty(m_TempleteId))
            {
                string sWhere = "F_TempleteID=" + m_TempleteId;

                if (!string.IsNullOrEmpty(txtKey.Text.Trim()))
                {
                    sWhere += " and F_BannerContent like '%" + txtKey.Text.Trim() + "%'";
                }

                PagerTable pt = SystemManager.Instance.Services.Test_TableService.GetPagerList(sWhere, "F_Time DESC", DataPager.PageSize * (DataPager.PageIndex - 1), DataPager.PageSize);
                DataPager.TotalCount = pt.TotalCount;
                this.GridView.DataSoure = pt.DataSource;
            }
        }
        private void btnQuery_Click(object sender, RoutedEventArgs e)
        {
            this.DataPager.PageIndex = 1;
            BandGridData();
        }

        private void DataPager_PageChanging(object sender, Framework.Common.Controls.PageChangingEventArgs e)
        {
            this.DataPager.PageIndex = e.NewPageIndex;
            BandGridData();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            DataRow row = this.GridView.GetFocusedDataRow();
            if (row != null)
            {
                if (MessageBox.Show("是否确认删除？", "提示", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    int id = int.Parse(row["F_ID"].ToString());
                    Library.Controller.SystemManager.Instance.Services.Test_TableService.Delete(id);
                    BandGridData();
                }
            }
            else
            {
                MessageBox.Show("请选择一行数据！");

            }
        }

  
        private void BtnShow_Click(object sender, RoutedEventArgs e)
        {
            DataRow row = this.GridView.GetFocusedDataRow();
            if (row != null)
            {
                int templeteid = int.Parse(row["F_TempleteID"].ToString());
                int id = int.Parse(row["F_ID"].ToString());

                DataShow win = new DataShow();
                win.LoadData(templeteid, id);
                win.Show();
            }
            else
            {
                MessageBox.Show("请选择一行数据！");

            }
        }

        private void BtnClearIsShow_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(m_TempleteId))
            {
                if (MessageBox.Show("是否确认清楚该试验数据的大屏显示？", "提示", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Library.Controller.SystemManager.Instance.Services.Test_TableService.UpdateClearShow(int.Parse(m_TempleteId));
                    BandGridData();
                }
            }
        }

        private void BtnSetIsShow_Click(object sender, RoutedEventArgs e)
        {
            DataRow row = this.GridView.GetFocusedDataRow();
            if (row != null)
            {
                int id = int.Parse(row["F_ID"].ToString());
                Test_Table tb = Library.Controller.SystemManager.Instance.Services.Test_TableService.GetModel(id);
                tb.F_IsShow = 1;
                Library.Controller.SystemManager.Instance.Services.Test_TableService.Update(tb);
                BandGridData();
            }
            else
            {
                MessageBox.Show("请选择一行数据！");

            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
               DataRow row = this.GridView.GetFocusedDataRow();
               if (row != null)
               {
                   DataEditGrid win = new DataEditGrid();
                   win.LayoutTable(row["F_TempleteID"].ToString(), row["F_ID"].ToString());
                   win.ShowDialog(); 
               }
               else
               {
                   MessageBox.Show("请选择一行数据！");
               }
        }

     
      
    }
}


