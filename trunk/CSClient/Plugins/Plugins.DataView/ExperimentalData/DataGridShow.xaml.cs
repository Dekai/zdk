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
using Library.Model;
using Library.Controller;
using BaseControl.GridAuto;

namespace Plugins.DataView.ExperimentalData
{
    /// <summary>
    /// DataGridShow.xaml 的交互逻辑
    /// </summary>
    public partial class DataGridShow : UserControl
    {
        public DataGridShow()
        {
            InitializeComponent();
        }

        public void LoadData(int templeteid, int id)
        {

            Test_Table_Templete tabletemplete = SystemManager.Instance.Services.Test_Table_TempleteService.GetModel(templeteid);
            List<Test_Field_Templete> Fieldtempletelist = SystemManager.Instance.Services.Test_Field_TempleteService.GetModelList("F_PID=" + templeteid);


            Test_Table testTable = SystemManager.Instance.Services.Test_TableService.GetModel(id);
            List<Library.Model.Test_Field> testFields = SystemManager.Instance.Services.Test_FieldService.GetModelList("F_PID=" + id);

        
            TextBlock txtBander = new TextBlock();
            string[] values =testTable.F_BannerContent.Split('$');
            txtBander.FontSize = double.Parse(tabletemplete.F_ShowFontSize.ToString());
            txtBander.Foreground = new SolidColorBrush(tabletemplete.ShowFontColor);
            txtBander.Margin = new Thickness(0, 10, 0, 10);
            foreach (string value in values)
            {
                if (string.IsNullOrEmpty(value))
                {
                    txtBander.Text += "--- ";
                }
                else
                {
                    txtBander.Text += value+" ";
                }
            }

            XGrid.Children.Add(txtBander);
            GridAutoControl m_Control = new GridAutoControl();
            m_Control.LayoutShowGrid(tabletemplete, Fieldtempletelist, testFields);
            XGrid.Children.Add(m_Control);
        }
    }
}
