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
using BaseControl.GridAuto;
using Library.Model;
using Library.Controller;

namespace Plugins.DataView.ExperimentalData
{
    /// <summary>
    /// DataShow.xaml 的交互逻辑
    /// </summary>
    public partial class DataInputGrid : UserControl
    {
        public DataInputGrid()
        {
            InitializeComponent();
        }

        public void LayoutTable(string id)
        {
            m_TempleteID = id;
            Test_Table_Templete tabletemplete = SystemManager.Instance.Services.Test_Table_TempleteService.GetModel(int.Parse(id));
            List<Test_Field_Templete> Fieldtempletelist = SystemManager.Instance.Services.Test_Field_TempleteService.GetModelList("F_PID=" + id);

            if (!string.IsNullOrEmpty(tabletemplete.F_Banner))
            {
                Banner_1_Edit bannerEdit = new Banner_1_Edit();
                bannerEdit.LoadTemplete(tabletemplete);
      
                XGrid.Children.Add(bannerEdit);
                m_BannerEdit = bannerEdit;
            }

            m_Control = new GridAutoControl();
            m_Control.LayoutEditGrid(tabletemplete, Fieldtempletelist);
            XGrid.Children.Add(m_Control);
        }

        string m_TempleteID;
        IBanner m_BannerEdit;
        GridAutoControl m_Control;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string sTitile = m_BannerEdit.GetValue();
            List<Test_Field> l = m_Control.GetFields();

            Test_Table table = new Test_Table();
            table.F_TempleteID = int.Parse(m_TempleteID);
            table.F_Time = DateTime.Now;
            table.F_BannerContent = sTitile;
            table.F_IsShow = 1;

            SystemManager.Instance.Services.Test_TableService.UpdateClearShow(table.F_TempleteID.Value);
            int tableid= SystemManager.Instance.Services.Test_TableService.Add(table);
            foreach (Test_Field f in l)
            {
                f.F_PID = tableid;
                SystemManager.Instance.Services.Test_FieldService.Add(f);
            }

            MessageBox.Show("添加成功！");
        }
    }
}
