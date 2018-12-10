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

namespace BaseControl.GridAuto
{
    /// <summary>
    /// GridAutoItemValue.xaml 的交互逻辑
    /// </summary>
    public partial class GridAutoItemValue : UserControl
    {
        public GridAutoItemValue()
        {
            InitializeComponent();
        }

        public void LayoutField(Library.Model.Test_Table_Templete table, Library.Model.Test_Field_Templete field)
        {
            this.SetValue(System.Windows.Controls.Grid.RowProperty, field.F_RowIndex.Value);
            this.SetValue(System.Windows.Controls.Grid.RowSpanProperty, field.F_RowSpan.Value);
            this.SetValue(System.Windows.Controls.Grid.ColumnProperty, field.F_ColIndex.Value);
            this.SetValue(System.Windows.Controls.Grid.ColumnSpanProperty, field.F_ColSpan.Value);
            txtValue.FontSize = double.Parse(table.F_DefineFontSize.ToString());
            txtValue.Text = field.F_Value;
        }

        public string ReadValue()
        {
            return txtValue.Text;
        }

        internal void SetText(string p)
        {
            txtValue.Text = p;
        }
    }
}
