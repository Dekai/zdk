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
using Library.Model;
using BaseControl.GridAuto;
using Library.Controller;
using DevExpress.Xpf.Core;

namespace Plugins.DataView.ExperimentalData
{
    /// <summary>
    /// DataShow.xaml 的交互逻辑
    /// </summary>
    public partial class DataShow : DXWindow
    {
        public DataShow()
        {
            InitializeComponent();
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.WindowState = System.Windows.WindowState.Maximized;
            this.Title = "大屏显示";
        }

        public void LoadData(int templeteid, int id)
        {
            Test_Table_Templete tabletemplete = SystemManager.Instance.Services.Test_Table_TempleteService.GetModel(templeteid);
            scrolls.Background = new SolidColorBrush(tabletemplete.ShowBackColor);

            DataGridShow grid = new DataGridShow();
            grid.LoadData(templeteid, id);
            scrolls.Content = grid;

        
        }
      
         
    }
}
