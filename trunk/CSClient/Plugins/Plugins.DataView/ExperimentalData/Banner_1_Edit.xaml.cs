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

namespace Plugins.DataView.ExperimentalData
{
    /// <summary>
    /// Banner_1_Edit.xaml 的交互逻辑
    /// </summary>
    public partial class Banner_1_Edit : UserControl, IBanner
    {
        public Banner_1_Edit()
        {
            InitializeComponent();
         
        }



        public string GetValue()
        {
            string sValue = "";
         
            for (int i = 0; i < index; i++)
            {
                object o = GetObjectByName("txt" + i);
                if (o != null)
                {
                    TextBox txt =o as TextBox;
                    if (txt != null)
                    {
                        sValue += txt.Text ;
                        if (i + 1 < index)
                        {
                            sValue += "$";
                        }
                    }
                    else
                    {
                        TextBlock txt1 = o as TextBlock;
                        if (txt1 != null)
                        {
                            sValue += txt1.Text ;
                            if (i + 1 < index)
                            {
                                sValue += "$";
                            }
                        }
                    }

                
                }
            }
            return sValue;
        }

        public object GetObjectByName(string name)
        {
            foreach (FrameworkElement element in Panels.Children)
            {
                if (element.Name.Equals(name))
                {
                    return element;
                }
            }
            return null;
        }



        int index = 0;
        public void LoadTemplete(Test_Table_Templete tabletemplete )
        {
            this.MinWidth = double.Parse(tabletemplete.F_DefineWidth.Value.ToString());
            this.MinHeight = tabletemplete.F_DefineHeight.Value * 1.0 / tabletemplete.F_RowCount.Value;
      
            Panels.Children.Clear();
            string[] Inputs = tabletemplete.F_Banner.Split('$');
            index = 0;
            foreach (string input in Inputs)
            {
                if (input.StartsWith("{") && input.EndsWith("}"))
                {
                    TextBox txtbox = new TextBox();
                    txtbox.Name = "txt" + index;
                    txtbox.AcceptsReturn = true;
                    txtbox.Text = input.Replace("{","").Replace("}","");
                    txtbox.MinWidth = 60;
                    txtbox.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
                    txtbox.Margin = new Thickness(0, 10, 0, 10);
                    txtbox.VerticalContentAlignment = System.Windows.VerticalAlignment.Center;
                    txtbox.VerticalAlignment = System.Windows.VerticalAlignment.Center;

                    txtbox.FontSize = double.Parse(tabletemplete.F_DefineFontSize.Value.ToString());
                    Panels.Children.Add(txtbox);

                }
                else
                {
                    TextBlock txtbox = new TextBlock();
                    txtbox.Name = "txt" + index;
                    txtbox.Text = input;
                    txtbox.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                    txtbox.Margin = new Thickness(10, 0, 0, 0);
                    txtbox.VerticalAlignment = System.Windows.VerticalAlignment.Center;

                    txtbox.FontSize = double.Parse(tabletemplete.F_DefineFontSize.Value.ToString());
                    Panels.Children.Add(txtbox);

                }

                index++;
            }
        }

        internal void LoadData(Test_Table testTable)
        {
            string[] Inputs = testTable.F_BannerContent.Split('$');
            for (int i = 0; i < index; i++)
            {
                object o = GetObjectByName("txt" + i);
                if (o != null)
                {
                    TextBox txt = o as TextBox;
                    if (txt != null)
                    {
                        txt.Text = Inputs[i];
                    }
                }
            }
        }
    }
}
