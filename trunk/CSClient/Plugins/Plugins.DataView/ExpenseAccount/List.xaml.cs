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
using Library.Controller;
using System.Data;
using BaseControl;
using Library.DataDictionary;

namespace Plugins.DataView.ExpenseAccount
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
            b.Width = 220;
            Bands.Add(b);

            BandInfo b1 = new BandInfo();
            b1.HanderTitle = "单据名称";
            b1.FieldName = "F_ApplyTitle";
            b1.Width = 200;
            Bands.Add(b1);

            BandInfo b2 = new BandInfo();
            b2.HanderTitle = "单据类型";
            b2.FieldName = "ApplyTypeName";
            b2.Width = 120;
            Bands.Add(b2);

            BandInfo b3 = new BandInfo();
            b3.HanderTitle = "金额总计";
            b3.FieldName = "F_ApplyAmount";
            b3.Width = 120;
            Bands.Add(b3);

            BandInfo b4 = new BandInfo();
            b4.HanderTitle = "报销日期";
            b4.FieldName = "F_ApplyDate";
            b4.Width = 120;
            Bands.Add(b4);


            BandInfo b5 = new BandInfo();
            b5.HanderTitle = "描述";
            b5.FieldName = "F_ApplyDescription";
            b5.Width = 120;
            Bands.Add(b5);


            BandInfo b8 = new BandInfo();
            b8.HanderTitle = "状态";
            b8.FieldName = "StateName";
            b8.Width = 80;
            Bands.Add(b8);


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

            string wfstate = (cmbWFState.SelectedItem as ComboBoxItem).Tag.ToString();
            if ("5".Equals(wfstate))
            {
                bYes = true;
            }
            else
            {
                bYes = false;
            }
            if (string.IsNullOrEmpty(projectlist.Trim()))
            {
                MessageBox.Show("请选择项目！");
                return;
            }
            GridView.DataSoure = SystemManager.Instance.Services.CostApplyService.GetViewList(projectlist, wfstate, startTime, endTime);
        }

        bool bYes = false;
        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            DataRow row = GridView.GetFocusedDataRow();
            if (row != null)
            {
                string id = row["F_ID"].ToString();
                string F_StateID = row["F_StateID"].ToString();

                if ("5".Equals(F_StateID))
                {
                  Library.Model.CostApply model=  SystemManager.Instance.Services.CostApplyService.GetModel(int.Parse(id));
                  Library.Model.WorkFlow_Templete wfnode=  SystemManager.Instance.Services.WorkFlow_TempleteService.GetCurrentModel(WorkFlowLinkTable.BaseFare,F_StateID);
                  if (wfnode.F_StateType == 2 || wfnode.F_StateType == 1) // 当前节点时 判断或者普通节点
                  {
                      if (MessageBox.Show("是否确认\"" + row["F_ApplyTitle"] + "\"通过?", "提示", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                      {
                          model.F_WF_StateID = int.Parse(wfnode.F_Next_StateID);
                          SystemManager.Instance.Services.CostApplyService.Update(model);
                          BindDataList();
                      }
                  }
                  else
                  {
                      MessageBox.Show("当前节点不在审批范围！");
                  }
                }
                else
                {
                    MessageBox.Show("请选择单据状态为\"财务确认\"的记录！");
                }
            }
            else
            {
                MessageBox.Show("请选择单据记录");
            }
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            DataRow row = GridView.GetFocusedDataRow();
            if (row != null)
            {
                string id = row["F_ID"].ToString();
                string F_StateID = row["F_StateID"].ToString();

                if ("5".Equals(F_StateID))
                {
                    Library.Model.CostApply model = SystemManager.Instance.Services.CostApplyService.GetModel(int.Parse(id));
                    Library.Model.WorkFlow_Templete wfnode = SystemManager.Instance.Services.WorkFlow_TempleteService.GetCurrentModel(WorkFlowLinkTable.BaseFare, F_StateID);
                    if (wfnode.F_StateType == 2 || wfnode.F_StateType == 1) // 当前节点时 判断或者普通节点
                    {
                        if (MessageBox.Show("是否确认驳回\"" + row["F_ApplyTitle"] + "\"?", "提示", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            model.F_WF_StateID = int.Parse(wfnode.F_Back_StateID);
                            SystemManager.Instance.Services.CostApplyService.Update(model);
                            BindDataList();
                        }
                    }
                    else
                    {
                        MessageBox.Show("当前节点不在审批范围！");
                    }
                }
                else
                {
                    MessageBox.Show("请选择单据状态为\"财务确认\"的记录！");
                }
            }
            else
            {
                MessageBox.Show("请选择单据记录");
            }
        }

        private void btnShow_Click(object sender, RoutedEventArgs e)
        {
              DataRow row = GridView.GetFocusedDataRow();
              if (row != null)
              {
                  Show win = new Show();
                  win.LoadData(row);
                  win.Show();
              }
        }
    }
}
