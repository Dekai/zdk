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
using System.Windows.Shapes;
using DevExpress.Xpf.Core;
using BaseControl;
using System.Reflection;
using DevExpress.Xpf.Bars;
using Library.Controller;

namespace Client
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : DXWindow
    {
        public MainWindow()
        {

            Login form = new Login();
            var result= form.ShowDialog();
            if (result.HasValue && result.Value)
            {
                InitializeComponent();
                NavigationFrame1.Source = new Content();

               barStaticItem1.Content="日期："+DateTime.Now.ToString("yyy-MM-dd") ;
               barStaticItem2.Content = "当前登录人：" + SystemManager.Instance.Services.EmployeeService.GetModel(SystemManager.Instance.CurrentUser.F_UserID).F_Name;

               foreach (KeyValuePair<BarItem, string> keyvalue in RightListView)
               {
                   if (!SystemManager.Instance.RightCodeList.Contains(keyvalue.Value))
                   {
                      keyvalue.Key.IsVisible = false;
                   }
               }
               foreach (KeyValuePair<Bar, string> keyvalue in RightBarListView)
               {
                   if (!SystemManager.Instance.RightCodeList.Contains(keyvalue.Value))
                   {
                       keyvalue.Key.Visible = false;
                   }
               }
             
            }
            else
            {
                Application.Current.Shutdown();
            }
        }

        public List<KeyValuePair<BarItem, string>> RightListView
        {
            get
            {
                if (m_RightListView == null)
                {
                    m_RightListView = new List<KeyValuePair<BarItem, string>>();
                    m_RightListView.Add(new KeyValuePair<BarItem, string>(this.barButtonItem16, "FirstPage"));
                    m_RightListView.Add(new KeyValuePair<BarItem, string>(this.barSubItem8, "Summary"));
                    m_RightListView.Add(new KeyValuePair<BarItem, string>(this.barButtonItem4, "Summary.Attendance"));
                    m_RightListView.Add(new KeyValuePair<BarItem, string>(this.barButtonItem5, "Summary.Equipment"));
                    m_RightListView.Add(new KeyValuePair<BarItem, string>(this.barButtonItem6, "Summary.Cost"));
                    m_RightListView.Add(new KeyValuePair<BarItem, string>(this.barSubItem1, "Notice"));
                    m_RightListView.Add(new KeyValuePair<BarItem, string>(this.barButtonItem7, "Notice.DataInput"));
                    m_RightListView.Add(new KeyValuePair<BarItem, string>(this.barButtonItem8, "Notice.Manager"));
                    m_RightListView.Add(new KeyValuePair<BarItem, string>(this.barButtonItem9, "Notice.Setting"));
                    m_RightListView.Add(new KeyValuePair<BarItem, string>(this.barButtonItem10, "Notice.Show"));
                    m_RightListView.Add(new KeyValuePair<BarItem, string>(this.barSubItem2, "Accident"));
                    m_RightListView.Add(new KeyValuePair<BarItem, string>(this.barButtonItem11, "Accident"));
                    m_RightListView.Add(new KeyValuePair<BarItem, string>(this.barSubItem3, "Cost"));
                    m_RightListView.Add(new KeyValuePair<BarItem, string>(this.barButtonItem12, "Cost.BaseProduct"));
                    m_RightListView.Add(new KeyValuePair<BarItem, string>(this.barButtonItem13, "Cost.BaseFare"));
                    m_RightListView.Add(new KeyValuePair<BarItem, string>(this.barButtonItem14, "Cost.BasePayment"));
                    m_RightListView.Add(new KeyValuePair<BarItem, string>(this.barSubItem6, "BaseData"));
                    m_RightListView.Add(new KeyValuePair<BarItem, string>(this.barButtonItem1, "BaseData.Employee"));
                    m_RightListView.Add(new KeyValuePair<BarItem, string>(this.barButtonItem15, "BaseData.Equipment"));
                    m_RightListView.Add(new KeyValuePair<BarItem, string>(this.barSubItem7, "SystemSeting"));
                    m_RightListView.Add(new KeyValuePair<BarItem, string>(this.barButtonItem2, "SystemSeting.Login"));
                    m_RightListView.Add(new KeyValuePair<BarItem, string>(this.barButtonItem3, "SystemSeting.Role"));
                    m_RightListView.Add(new KeyValuePair<BarItem, string>(this.barMenu, "SystemSeting.Right"));
                    m_RightListView.Add(new KeyValuePair<BarItem, string>(this.barRight, "SystemSeting.RoleRight"));
                    m_RightListView.Add(new KeyValuePair<BarItem, string>(this.barButtonItem17, "ExpenseAccount"));

                    m_RightListView.Add(new KeyValuePair<BarItem, string>(this.barButtonItem16, "FirstPage"));
                    m_RightListView.Add(new KeyValuePair<BarItem, string>(this.barSubItem8, "Summary"));
                    m_RightListView.Add(new KeyValuePair<BarItem, string>(this.barSubItem1, "Notice"));
                    m_RightListView.Add(new KeyValuePair<BarItem, string>(this.barSubItem12, "ExpenseAccount"));
                    m_RightListView.Add(new KeyValuePair<BarItem, string>(this.barSubItem2, "Accident"));
                    m_RightListView.Add(new KeyValuePair<BarItem, string>(this.barSubItem3, "Cost"));
                    m_RightListView.Add(new KeyValuePair<BarItem, string>(this.barSubItem6, "BaseData"));
                    m_RightListView.Add(new KeyValuePair<BarItem, string>(this.barSubItem7, "SystemSeting"));



                    
                }
                return m_RightListView;
            }
        }
        private List<KeyValuePair<BarItem,string>> m_RightListView;


        public List<KeyValuePair<Bar, string>> RightBarListView
        {
            get
            {
                if (m_RightBarListView == null)
                {
                    m_RightBarListView = new List<KeyValuePair<Bar, string>>();
                    m_RightBarListView.Add(new KeyValuePair<Bar, string>(this.bar1, "Summary"));
                    m_RightBarListView.Add(new KeyValuePair<Bar, string>(this.bar2, "Notice"));
                    m_RightBarListView.Add(new KeyValuePair<Bar, string>(this.bar7, "ExpenseAccount"));
                    m_RightBarListView.Add(new KeyValuePair<Bar, string>(this.bar3, "Accident"));
                    m_RightBarListView.Add(new KeyValuePair<Bar, string>(this.bar6, "Cost"));
                    m_RightBarListView.Add(new KeyValuePair<Bar, string>(this.bar4, "BaseData"));
                    m_RightBarListView.Add(new KeyValuePair<Bar, string>(this.bar5, "SystemSeting"));

                }
                return m_RightBarListView;
            }
        }
        private List<KeyValuePair<Bar, string>> m_RightBarListView;

        private void barButtonItem1_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            BarItem baritem = sender as BarItem;
            string funstr = baritem.Tag.ToString();
            DataBind(funstr);
        }

        private void DataBind(string funstr)
        {
            try
            {
                SplashScreenHelper.Instance.ShowSplashScreen();


                if (m_Dic.ContainsKey(funstr))
                {
                    object obj = m_Dic[funstr];
                    NavigationFrame1.Source = obj;

                }
                else
                {
                    string[] namespages = funstr.Split('@');
                    object obj = Assembly.Load(namespages[1]).CreateInstance(namespages[0], false);
                    NavigationFrame1.Source = obj;
                    m_Dic.Add(funstr, obj);
                }
            }
            catch (Exception ex)
            {
                NavigationFrame1.Source = new Error(ex);
            }
            finally
            {
                SplashScreenHelper.Instance.HideSplashScreen();
            }
        }

        IDictionary<string, object> m_Dic = new Dictionary<string, object>();


    }
}
