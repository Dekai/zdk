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

namespace BaseControl.GridAuto
{
    /// <summary>
    /// GridAutoControl.xaml 的交互逻辑
    /// </summary>
    public partial class GridAutoControl : UserControl
    {
        public GridAutoControl()
        {
            InitializeComponent();
          
        }


     
        public void LayoutEditGrid(Test_Table_Templete tabletemplete,List<Test_Field_Templete> Fieldtempletelist)
        {
            m_Fields = new List<GridAutoItemValue>();

            if (tabletemplete.F_DefineWidth != null)
            {
                GridFrame.MinWidth = double.Parse(tabletemplete.F_DefineWidth.Value.ToString());
            }
            if (tabletemplete.F_DefineHeight != null)
            {
                GridFrame.MinHeight = double.Parse(tabletemplete.F_DefineHeight.Value.ToString());
            }


            for (int r = 0; r < tabletemplete.F_RowCount; r++)
            {
                RowDefinition rowdef = new RowDefinition();
                rowdef.Height = new GridLength(1, GridUnitType.Star);
                GridAuto.RowDefinitions.Add(rowdef);
            }
            for (int c = 0; c < tabletemplete.F_ColunmCount; c++)
            {
                ColumnDefinition coldef = new ColumnDefinition();
                coldef.Width = new GridLength(1, GridUnitType.Star);
                GridAuto.ColumnDefinitions.Add(coldef);
            }

            foreach (Test_Field_Templete field in Fieldtempletelist)
            {
                if (field.F_Type.Equals(0))
                {
                    GridAutoItemText item = new GridAutoItemText();
                    item.LayoutEditField(tabletemplete, field);
                    GridAuto.Children.Add(item);
                }
                else
                {
                    GridAutoItemValue item = new GridAutoItemValue();
                    item.LayoutField(tabletemplete, field);
                    GridAuto.Children.Add(item);
                    item.Tag = field;
                    m_Fields.Add(item);
                }

            }
        }

        List<GridAutoItemValue> m_Fields;
        public List<Test_Field> GetFields()
        {
            List<Test_Field> l = new List<Test_Field>();
            foreach (GridAutoItemValue item in m_Fields)
            {
                Test_Field_Templete t = item.Tag as Test_Field_Templete;
                Test_Field field = new Test_Field();
                field.F_ColIndex = t.F_ColIndex.Value;
                field.F_RowIndex = t.F_RowIndex.Value;
                field.F_Value = item.ReadValue();
                l.Add(field);
            }
            return l;
        }

        public void LoadData(List<Library.Model.Test_Field> testFields)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            foreach (Library.Model.Test_Field f in testFields)
            {
                dic.Add(f.F_RowIndex + "_" + f.F_ColIndex, f.F_Value);
            }

            foreach (GridAutoItemValue field in m_Fields)
            {
                if (field.Tag != null)
                {
                    Test_Field_Templete f = field.Tag as Test_Field_Templete;

                    string sKey = f.F_RowIndex + "_" + f.F_ColIndex;
                    if (dic.ContainsKey(sKey))
                    {
                        field.SetText(dic[sKey]);
                    }
                }

            }
        }



        public void LayoutShowGrid(Test_Table_Templete tabletemplete, List<Test_Field_Templete> Fieldtempletelist,List<Library.Model.Test_Field> testFields)
        {
            GridFrame.BorderBrush = new SolidColorBrush(tabletemplete.ShowBorderColor);

            if (tabletemplete.F_ShowWidth != null)
            {
                GridFrame.MinWidth = double.Parse(tabletemplete.F_ShowWidth.Value.ToString());
            }
            if (tabletemplete.F_ShowHeight != null)
            {
                GridFrame.MinHeight = double.Parse(tabletemplete.F_ShowHeight.Value.ToString());
            }

            for (int r = 0; r < tabletemplete.F_RowCount; r++)
            {
                RowDefinition rowdef = new RowDefinition();
                rowdef.Height = new GridLength(1, GridUnitType.Star);
                GridAuto.RowDefinitions.Add(rowdef);
            }
            for (int c = 0; c < tabletemplete.F_ColunmCount; c++)
            {
                ColumnDefinition coldef = new ColumnDefinition();
                coldef.Width = new GridLength(1, GridUnitType.Star);
                GridAuto.ColumnDefinitions.Add(coldef);
            }

            Dictionary<string, string> dic = new Dictionary<string, string>();
            foreach (Library.Model.Test_Field f in testFields)
            {
                dic.Add(f.F_RowIndex + "_" + f.F_ColIndex, f.F_Value);
            }

            foreach (Test_Field_Templete field in Fieldtempletelist)
            {
                string sKey = field.F_RowIndex + "_" + field.F_ColIndex;
                if (dic.ContainsKey(sKey))
                {
                    field.F_Value = dic[sKey];
                }

                GridAutoItemText item = new GridAutoItemText();
                item.LayoutShowField(tabletemplete, field);
                GridAuto.Children.Add(item);
            }
        }
    }
}
