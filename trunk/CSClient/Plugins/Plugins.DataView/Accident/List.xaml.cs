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
using BaseControl;
using Library.Model.Struct;
using Library.Controller;
using System.Data;

namespace Plugins.DataView.Accident
{
    /// <summary>
    /// List.xaml 的交互逻辑
    /// </summary>
    public partial class List : UserControl
    {
        public List()
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
                    m_GridView.GridRowClick += new GridRowClickDelegate(m_GridView_GridRowClick);
                    List<BandInfo> Bands = GetRecordBands();
                    m_GridView.InitData(Bands);
                    host1.Child = m_GridView;
                }
                return m_GridView;
            }
        }

        void m_GridView_GridRowClick(int rowIndex, string colName, DataRow Row, object CellValue)
        {
            if (rowIndex >= 0)
            {
                AccidentShow win = new AccidentShow();
                win.LoadData(Row);
                win.Show();

            }
        
        }
        private List<BandInfo> GetRecordBands()
        {
            List<BandInfo> Bands = new List<BandInfo>();
            BandInfo b0 = new BandInfo();
            b0.HanderTitle = "工程名称";
            b0.FieldName = "F_ProjectName";
            b0.Width = 200;
            Bands.Add(b0);

            BandInfo b1 = new BandInfo();
            b1.HanderTitle = "事故名称";
            b1.FieldName = "F_AccidentName";
            b1.Width = 200;
            Bands.Add(b1);

            BandInfo b2 = new BandInfo();
            b2.HanderTitle = "事故描述";
            b2.FieldName = "F_Description";
            b2.Width = 120;
            Bands.Add(b2);

            BandInfo b3 = new BandInfo();
            b3.HanderTitle = "日期";
            b3.FieldName = "F_AccidentDate";
            b3.Width = 120;
            Bands.Add(b3);

            BandInfo b4 = new BandInfo();
            b4.HanderTitle = "操作人";
            b4.FieldName = "F_OperatorName";
            b4.Width = 120;
            Bands.Add(b4);


            BandInfo b5 = new BandInfo();
            b5.HanderTitle = "操作时间";
            b5.FieldName = "F_OperateTime";
            b5.Width = 120;
            Bands.Add(b5);


            return Bands;
        }
        private BandGridView m_GridView;
        #endregion

        void Attendance_Loaded(object sender, RoutedEventArgs e)
        {
            txtStartDate.DateTime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-01"));
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
            string projectlist = "";

            List<NameValue> l = listProject.ItemsSource as List<NameValue>;
            foreach (NameValue item in l)
            {
                if (item.IsSelected)
                {
                    projectlist += item.StringValue+",";
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

            if (string.IsNullOrEmpty(projectlist.Trim()))
            {
                MessageBox.Show("请选择项目！");
                return;
            }

            DataTable dt = SystemManager.Instance.Services.AccidentService.GetTable(projectlist, startTime, endTime);

            GridView.DataSoure = dt;
        }
    }
}
