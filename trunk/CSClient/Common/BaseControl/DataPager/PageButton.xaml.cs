﻿using System;
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

namespace BaseControl.DataPager
{
    /// <summary>
    /// PageButton.xaml 的交互逻辑
    /// </summary>
    public partial class PageButton : UserControl
    {
        public PageButton()
        {
            InitializeComponent();
        }

        public string PageIndex
        {
            set
            {
                this.txtName.Text = value;
            }

        }

        public object Obj
        {

            get;
            set;
        }
    }
}
