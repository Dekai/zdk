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

namespace Plugins.DataView.Summary
{
    /// <summary>
    /// Attendance.xaml 的交互逻辑
    /// </summary>
    public partial class Attendance : UserControl
    {
        public Attendance()
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
            BandInfo b0 = new BandInfo();
            b0.HanderTitle = "工程名称";
            b0.FieldName = "F_Name";
            b0.Width = 300;
            Bands.Add(b0);

            BandInfo b1 = new BandInfo();
            b1.HanderTitle = "工程所干天数";
            b1.FieldName = "daycount";
            b1.Width = 120;
            Bands.Add(b1);

            BandInfo b2 = new BandInfo();
            b2.HanderTitle = "本公司人员出勤人次";
            b2.FieldName = "empcount";
            b2.Width = 120;
            Bands.Add(b2);

            BandInfo b3 = new BandInfo();
            b3.HanderTitle = "外雇耙工总人数";
            b3.FieldName = "PaGong";
            b3.Width = 120;
            Bands.Add(b3);

            BandInfo b4 = new BandInfo();
            b4.HanderTitle = "外雇普通工人总人数";
            b4.FieldName = "Worker";
            b4.Width = 120;
            Bands.Add(b4);


            BandInfo b5 = new BandInfo();
            b5.HanderTitle = "外雇工头总人数";
            b5.FieldName = "GongTou";
            b5.Width = 120;
            Bands.Add(b5);


            return Bands;
        }
        private BandGridView m_GridView;
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
            if (string.IsNullOrEmpty(projectlist.Trim()))
            {
                MessageBox.Show("请选择项目！");
                return;
            }
            GridView.DataSoure = SystemManager.Instance.Services.EmployeeAttendaceService.GetSummer(projectlist, startTime, endTime);
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
