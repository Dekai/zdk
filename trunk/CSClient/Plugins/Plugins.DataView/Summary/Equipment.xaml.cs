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
    public partial class Equipment : UserControl
    {
        public Equipment()
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
            b1.Width = 80;
            Bands.Add(b1);
            /*
            BandInfo b2 = new BandInfo();
            b2.HanderTitle = "摊出机";
            b2.FieldName = "F_Money";
            b2.Width = 80;
            Bands.Add(b2);

            BandInfo b3 = new BandInfo();
            b3.HanderTitle = "压路机1#";
            b3.FieldName = "F_Time";
            b3.Width = 80;
            Bands.Add(b3);

            BandInfo b4 = new BandInfo();
            b4.HanderTitle = "压路机2#";
            b4.FieldName = "F_StateName";
            b4.Width = 80;
            Bands.Add(b4);


            BandInfo b5 = new BandInfo();
            b5.HanderTitle = "小压路机";
            b5.FieldName = "UserName";
            b5.Width = 80;
            Bands.Add(b5);

            BandInfo b6 = new BandInfo();
            b6.HanderTitle = "脚轮压路机";
            b6.FieldName = "UserName";
            b6.Width = 80;
            Bands.Add(b6);


            BandInfo b7 = new BandInfo();
            b7.HanderTitle = "外租设备出场天数";
            b7.FieldName = "UserName";
            b7.Width = 120;
            Bands.Add(b7);
             */

            List<NameValue> le = listEquipment.ItemsSource as List<NameValue>;
            foreach (NameValue item in le)
            {
                if (item.IsSelected)
                {
                    BandInfo b7 = new BandInfo();
                    b7.HanderTitle = item.Name;
                    b7.FieldName = "EquimentID_" + item.Value;
                    b7.Width = 120;
                    Bands.Add(b7);
                }
            }

            return Bands;
        }
        private BandGridView m_GridView;
        #endregion

        void Attendance_Loaded(object sender, RoutedEventArgs e)
        {
            txtStartDate.DateTime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-01"));
            txtStartDate.Text = "";
            txtEndDate.DateTime = DateTime.Now;

            //F_ID,F_Name,F_TypeCode,F_Order
            DataTable dt = SystemManager.Instance.Services.EquipmentService.GetList("F_IsDelete='0' order by F_Order").Tables[0];
            List<NameValue> l1 = new List<NameValue>();
            foreach (DataRow row in dt.Rows)
            {
                NameValue nameValue = new NameValue();
                nameValue.Value = row["F_ID"].ToString();
                nameValue.Name = row["F_Name"].ToString();
                nameValue.IsSelected = true;
                l1.Add(nameValue);
            }
            NameValue nameValue1 = new NameValue();
            nameValue1.Value = "0";
            nameValue1.Name = "外租设备出场天数";
            nameValue1.IsSelected = true;
            l1.Add(nameValue1);
            listEquipment.ItemsSource = l1;


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
            List<BandInfo> Bands = GetRecordBands();
            GridView.InitData(Bands);

            List<string> equipmentlist = new List<string>();
            List<NameValue> le = listEquipment.ItemsSource as List<NameValue>;
            foreach (NameValue item in le)
            {
                if (item.IsSelected)
                {
                   equipmentlist.Add(item.Value.ToString());
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
            if (string.IsNullOrEmpty(projectlist.Trim()))
            {
                MessageBox.Show("请选择项目！");
                return;
            }
            GridView.DataSoure = SystemManager.Instance.Services.EquimentAttendaceService.GetSummer(projectlist, equipmentlist, startTime, endTime);
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
