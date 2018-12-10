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
using Library.Common;

namespace Plugins.DataView.ExperimentalData
{
    /// <summary>
    /// StartShow.xaml 的交互逻辑
    /// </summary>
    public partial class StartShow : UserControl
    {
        public StartShow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<Library.Model.Test_Table> tables = SystemManager.Instance.Services.Test_TableService.GetModelList("F_IsShow=1");

            if (tables.Count == 0)
            {
                MessageBox.Show("请在实验数据管理中，设置要显示的数据！");
                return;
            }

            if (!FormValidate.IsNumber(this.txtTime.Text.Trim(), false))
            {
                MessageBox.Show("请填写正整数！");
                return;
            }


            ShowScreen win = new ShowScreen();
            win.LoadData(tables, double.Parse(this.txtTime.Text));
            win.Show();
        }
    }
}
