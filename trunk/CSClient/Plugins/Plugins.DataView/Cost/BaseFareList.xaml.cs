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
using System.Data;
using BaseControl;
using Library.Controller;
using Library.Model;


namespace Plugins.DataView.BaseData
{
    /// <summary>
    /// EmployeeList.xaml 的交互逻辑
    /// </summary>
    public partial class BaseFareList : UserControl
    {
        public BaseFareList()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(BaseFareList_Loaded);
        }
      
//成品 = 0
//付款=1
//运费=2 
   

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
                    host1.Child = m_GridView;
                }
                return m_GridView;
            }
        }
        private List<BandInfo> GetRecordBands()
        {
            List<BandInfo> Bands = new List<BandInfo>();
            BandInfo b0 = new BandInfo();
            b0.HanderTitle = "标题";
            b0.FieldName = "F_Name";
            b0.Width = 200;
            Bands.Add(b0);

            BandInfo b1 = new BandInfo();
            b1.HanderTitle = "描述";
            b1.FieldName = "F_Content";
            b1.Width = 300;
            Bands.Add(b1);

            BandInfo b2 = new BandInfo();
            b2.HanderTitle = "价格";
            b2.FieldName = "F_Money";
            b2.Width = 100;
            Bands.Add(b2);

            BandInfo b3 = new BandInfo();
            b3.HanderTitle = "日期";
            b3.FieldName = "F_Date";
            b3.Width = 100;
            Bands.Add(b3);

            BandInfo b4= new BandInfo();
            b4.HanderTitle = "状态";
            b4.FieldName = "F_StateName";
            b4.Width = 100;
            Bands.Add(b4);


            BandInfo b5 = new BandInfo();
            b5.HanderTitle = "录入人员";
            b5.FieldName = "UserName";
            b5.Width = 100;
            Bands.Add(b5);


            return Bands;
        }
        private BandGridView m_GridView;
        #endregion


        void BaseFareList_Loaded(object sender, RoutedEventArgs e)
        {
            BandGridData();
        }

        private void BandGridData()
        {
            string sWhere = "b.F_IsDelete=0 and b.F_Type = 2 ";
            if (!string.IsNullOrEmpty(this.txtKey.Text.Trim()))
            {
                sWhere += " and b.F_Name like '%" + this.txtKey.Text.Trim() + "%'";
            }
            string sOrder = "b.F_Time";
            PagerTable pt = SystemManager.Instance.Services.AuditService.GetPagerList(sWhere, sOrder, DataPager.PageSize * (DataPager.PageIndex - 1), DataPager.PageSize);
            DataPager.TotalCount = pt.TotalCount;
            this.GridView.DataSoure = pt.DataSource;
        }

        private void DataPager_PageChanging(object sender, Framework.Common.Controls.PageChangingEventArgs e)
        {
            this.DataPager.PageIndex = e.NewPageIndex;
            BandGridData();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            BaseFareEdit win = new BaseFareEdit();
            win.SaveComplete += (model) =>
            {
                BandGridData();
                MessageBox.Show("保存" + model.F_Name + "成功！");
            };
            win.ShowDialog();
        }

        private void btnQuery_Click(object sender, RoutedEventArgs e)
        {
            BandGridData();
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            DataRow row = this.GridView.GetFocusedDataRow();
            if (row != null)
            {
                int id = int.Parse(row["F_ID"].ToString());
                BaseFareEdit win = new BaseFareEdit();
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
            DataRow row = this.GridView.GetFocusedDataRow();
            if (row != null)
            {
                if (MessageBox.Show("是否确认删除？", "提示", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    int id = int.Parse(row["F_ID"].ToString());
                    Library.Controller.SystemManager.Instance.Services.AuditService.Delete(id);
                    BandGridData();
                }
            }
            else
            {
                MessageBox.Show("请选择一行数据！");

            }
        }

        private void BtnExcel_Click(object sender, RoutedEventArgs e)
        {
            GridView.Excel();
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            GridView.Print();

        }

   
      
    }
}
