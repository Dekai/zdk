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
using Library.Model.Struct;
using BaseControl;
using Library.Controller;
using System.Data;

namespace Plugins.DataView.Summary
{
    /// <summary>
    /// Attendance.xaml 的交互逻辑
    /// </summary>
    public partial class Cost : UserControl
    {
        public Cost()
        {
            InitializeComponent();
    
            this.Loaded += new RoutedEventHandler(Attendance_Loaded);
        }

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

            BandInfo b = new BandInfo();
            b.HanderTitle = "工程名称";
            b.FieldName = "F_Name";
            b.Width = 300;
            Bands.Add(b);

       
            foreach (NameValue item in CostType)
            {
                if (item.IsSelected)
                {
                    BandInfo b7 = new BandInfo();
                    b7.HanderTitle = item.Name;
                    b7.FieldName = "CostType_" + item.Value;
                    b7.Width = 80;
                    Bands.Add(b7);
                }
            }
          

            BandInfo b8 = new BandInfo();
            b8.HanderTitle = "合计";
            b8.FieldName = "CostType_Count";
            b8.Width = 80;
            Bands.Add(b8);


            return Bands;
        }
        private BandGridView m_GridView;


        public List<NameValue> CostType
        {
            get
            {
                if (m_CostType == null)
                {
                    m_CostType = new List<NameValue>();
                    //F_ID,F_Name,F_TypeCode,F_Order
                    DataTable dt = SystemManager.Instance.Services.DataDicInfoService.GetList("F_TypeCode='Cost_Type' order by F_Order").Tables[0];
                    foreach (DataRow row in dt.Rows)
                    {
                        NameValue nameValue = new NameValue();
                        nameValue.Value = row["F_ID"].ToString();
                        nameValue.Name = row["F_Name"].ToString();
                        nameValue.IsSelected = true;
                        m_CostType.Add(nameValue);
                    }
                }

                return m_CostType;
            }
        }
        private List<NameValue> m_CostType;
        #endregion

        void Attendance_Loaded(object sender, RoutedEventArgs e)
        {
            txtStartDate.DateTime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-01"));
            txtStartDate.Text = "";
            txtEndDate.DateTime = DateTime.Now;
            List<NameValue> l = SystemManager.Instance.Services.ProjectService.GetNameViewList("");
            listProject.ItemsSource = l;
            BindDataList();
        }
        private void btnSelectAll_Click(object sender, RoutedEventArgs e)
        {


            List<NameValue> l = listProject.ItemsSource as List<NameValue>;
            foreach (NameValue item in l)
            {
                item.IsSelected = true;
            }
            listProject.ItemsSource = l;

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            List<NameValue> l = listProject.ItemsSource as List<NameValue>;
            foreach (NameValue item in l)
            {
                item.IsSelected = false;
            }
            listProject.ItemsSource = l;

        }

        private void btnQuery_Click(object sender, RoutedEventArgs e)
        {
            BindDataList();
        }


            
            
            
      


        private void BindDataList()
        {

            List<string> CostTypelist = new List<string>();

            foreach (NameValue item in CostType)
            {
                if (item.IsSelected)
                {
                    CostTypelist.Add(item.Value.ToString());
                }
            }

            string projectlist = "";

            List<NameValue> l = listProject.ItemsSource as List<NameValue>;
            foreach (NameValue item in l)
            {
                if (item.IsSelected)
                {
                    projectlist += item.StringValue + ",";
                }
            }
            projectlist = projectlist.TrimEnd(',');
            string startTime = "", endTime = "";
            if (!string.IsNullOrEmpty(txtStartDate.Text.Trim()))
            {
                startTime = txtStartDate.DateTime.ToString("yyyy-MM-dd");
            }
            if (!string.IsNullOrEmpty(txtEndDate.Text.Trim()))
            {
                endTime = txtEndDate.DateTime.ToString("yyyy-MM-dd");
            }

            string wfstate = (cmbWFState.SelectedItem as ComboBoxItem).Tag.ToString();
            if (string.IsNullOrEmpty(projectlist.Trim()))
            {
                MessageBox.Show("请选择项目！");
                return;
            }
            GridView.DataSoure = SystemManager.Instance.Services.ProjectCostService.GetSummer(projectlist, CostTypelist, startTime, endTime,wfstate); 
        }

        private void btnExcel_Click(object sender, RoutedEventArgs e)
        {
            GridView.Excel();
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            GridView.Print();
        }
    }
}
