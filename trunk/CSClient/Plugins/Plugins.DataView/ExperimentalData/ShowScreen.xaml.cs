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
using Library.Controller;
using Library.Model;
using System.Windows.Threading;

namespace Plugins.DataView.ExperimentalData
{
    /// <summary>
    /// ShowScreen.xaml 的交互逻辑
    /// </summary>
    public partial class ShowScreen : Window
    {
        public ShowScreen()
        {
            InitializeComponent();

            ContextMenu Menu1 = new ContextMenu();

            MenuItem menuItem = new MenuItem();
            menuItem.Header = "屏幕最大化";
            menuItem.Click += new RoutedEventHandler(menuItem_Click);
            Menu1.Items.Add(menuItem);

            MenuItem menuItem0 = new MenuItem();
            menuItem0.Header = "恢复屏幕尺寸";
            menuItem0.Click += new RoutedEventHandler(menuItem0_Click);
            Menu1.Items.Add(menuItem0);

            MenuItem menuItem1 = new MenuItem();
            menuItem1.Header = "关闭屏幕";
            menuItem1.Click += new RoutedEventHandler(menuItem1_Click);
            Menu1.Items.Add(menuItem1);

            MenuItem menuItem2 = new MenuItem();
            menuItem2.Header = "停止滚动";
            menuItem2.Click += new RoutedEventHandler(menuItem2_Click);
            Menu1.Items.Add(menuItem2);


            MenuItem menuItem3 = new MenuItem();
            menuItem3.Header = "开始滚动";
            menuItem3.Click += new RoutedEventHandler(menuItem3_Click);
            Menu1.Items.Add(menuItem3);

            this.ContextMenu = Menu1;

        }

        void menuItem3_Click(object sender, RoutedEventArgs e)
        {
            this.Timer.Start();
        }

        void menuItem2_Click(object sender, RoutedEventArgs e)
        {
            this.Timer.Stop();
        }

        void menuItem1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        void menuItem0_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Normal;
        }


        void menuItem_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Maximized;
        }

        List<Color> lc = new List<Color>();
        List<DataGridShow> lg = new List<DataGridShow>();
        DispatcherTimer Timer = new DispatcherTimer();
        double ntime = 40;
        int Index = 0;
        internal  void LoadData(List<Library.Model.Test_Table> tables,double time)
        {
            Index = 0;
            lc.Clear();
            lg.Clear();
            ntime = time;
            foreach (Library.Model.Test_Table t in tables)
            {
                Test_Table_Templete tabletemplete = SystemManager.Instance.Services.Test_Table_TempleteService.GetModel(t.F_TempleteID.Value);
                Color c = tabletemplete.ShowBackColor;
                DataGridShow grid = new DataGridShow();
                grid.MouseLeftButtonDown += new MouseButtonEventHandler(grid_MouseLeftButtonDown);
                grid.LoadData(t.F_TempleteID.Value, t.F_ID);

                lc.Add(c);
                lg.Add(grid);
            }

            Timer.Interval = TimeSpan.FromSeconds(time);
            Timer.Tick += new EventHandler(Timer_Tick);
            Timer.Start();

            this.Frame1.Source = lg[Index];
            this.Background = new SolidColorBrush(lc[Index]);
            Index++;
        }

        void grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
        
        }

        void Timer_Tick(object sender, EventArgs e)
        {
            this.Frame1.Source = lg[Index];
            this.Background = new SolidColorBrush(lc[Index]);
            Index++;

            if (Index == lg.Count())
            {
                Index = 0;
            }
        }

        private void Frame1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
    }
}
