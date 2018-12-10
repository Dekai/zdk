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
    /// DataEditGrid.xaml 的交互逻辑
    /// </summary>
    public partial class DataEditGrid : DXWindow
    {
        public DataEditGrid()
        {
            InitializeComponent();
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.WindowState = System.Windows.WindowState.Maximized;
        }

        public void LayoutTable(string id,string tableid)
        {
            m_TableID = tableid;
            m_TempleteID = id;
            Test_Table_Templete tabletemplete = SystemManager.Instance.Services.Test_Table_TempleteService.GetModel(int.Parse(id));
            List<Test_Field_Templete> Fieldtempletelist = SystemManager.Instance.Services.Test_Field_TempleteService.GetModelList("F_PID=" + id);


            Test_Table testTable = SystemManager.Instance.Services.Test_TableService.GetModel(int.Parse(tableid));
            List<Library.Model.Test_Field> testFields = SystemManager.Instance.Services.Test_FieldService.GetModelList("F_PID=" + tableid);

            if (!string.IsNullOrEmpty(tabletemplete.F_Banner))
            {
                Banner_1_Edit bannerEdit = new Banner_1_Edit();
                bannerEdit.LoadTemplete(tabletemplete);
                bannerEdit.LoadData(testTable);
                XGrid.Children.Add(bannerEdit);
                m_BannerEdit = bannerEdit;
            }

            m_Control = new GridAutoControl();
            m_Control.LayoutEditGrid(tabletemplete, Fieldtempletelist);
            m_Control.LoadData(testFields);
            XGrid.Children.Add(m_Control);
        }

        string m_TableID;
        string m_TempleteID;
        IBanner m_BannerEdit;
        GridAutoControl m_Control;

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            SystemManager.Instance.Services.Test_TableService.Delete(int.Parse(m_TableID));
            SystemManager.Instance.Services.Test_FieldService.DeleteByPid(int.Parse(m_TableID));

            string sTitile = m_BannerEdit.GetValue();
            List<Test_Field> l = m_Control.GetFields();

            Test_Table table = new Test_Table();
            table.F_TempleteID = int.Parse(m_TempleteID);
            table.F_Time = DateTime.Now;
            table.F_BannerContent = sTitile;
            table.F_IsShow = 1;
            int tableid = SystemManager.Instance.Services.Test_TableService.Add(table);
            foreach (Test_Field f in l)
            {
                f.F_PID = tableid;
                SystemManager.Instance.Services.Test_FieldService.Add(f);
            }

            MessageBox.Show("添加成功！");
        }
    }
}
