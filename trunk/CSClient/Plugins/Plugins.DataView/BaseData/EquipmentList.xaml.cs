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
using System.Data;
using BaseControl;
using Library.Controller;


namespace Plugins.DataView.BaseData
{
    /// <summary>
    /// EmployeeList.xaml 的交互逻辑
    /// </summary>
    public partial class EquipmentList : UserControl
    {
        public EquipmentList()
        {
            InitializeComponent();

            BandGridData();
        }

        #region 表格
        public BandGridView GridView
        {
            get
            {
                if (m_GridView == null)
                {
                    m_GridView = new BandGridView();
                    List<BandInfo> Bands = GetRecordBands();
                    m_GridView.InitData(Bands);
                    host1.Child = m_GridView;
                }
                return m_GridView;
            }
        }
        private List<BandInfo> GetRecordBands()
        {
            List<BandInfo> Bands = new List<BandInfo>();
            BandInfo b0 = new BandInfo();
            b0.HanderTitle = "设备名称";
            b0.FieldName = "F_Name";
            b0.Width = 60;
            Bands.Add(b0);

            BandInfo b1 = new BandInfo();
            b1.HanderTitle = "设备描述";
            b1.FieldName = "F_Decs";
            b1.Width = 200;
            Bands.Add(b1);

            BandInfo b2 = new BandInfo();
            b2.HanderTitle = "排序";
            b2.FieldName = "F_Order";
            b2.Width = 100;
            Bands.Add(b2);


            return Bands;
        }
        private BandGridView m_GridView;
        #endregion


        private void BandGridData()
        {
            DataTable dt = SystemManager.Instance.Services.EquipmentService.GetList("F_IsDelete =0 ").Tables[0];
            this.GridView.DataSoure = dt;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            EquipmentEdit win = new EquipmentEdit();
            win.SaveComplete += (model) =>
            {
                BandGridData();
                MessageBox.Show("保存" + model.F_Name + "成功！");
            };
            win.ShowDialog();
        }

        private void btnQuery_Click(object sender, RoutedEventArgs e)
        {
            this.GridView.Filter(this.txtKey.Text.Trim());
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            DataRow row = this.GridView.GetFocusedDataRow();
            if (row != null)
            {
                int id = int.Parse(row["F_ID"].ToString());
                EquipmentEdit win = new EquipmentEdit();
                win.LoadData(id);
                win.SaveComplete += (model) =>
                {
                    BandGridData();
                    MessageBox.Show("保存" + model.F_Name + "成功！");
                };
                win.ShowDialog();
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            DataRow row = this.GridView.GetFocusedDataRow();
            if (row != null)
            {
                if (MessageBox.Show("是否确认删除？", "提示", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    int id = int.Parse(row["F_ID"].ToString());
                    Library.Model.Equipment model = Library.Controller.SystemManager.Instance.Services.EquipmentService.GetModel(id);
                    model.F_IsDelete = 1;
                    Library.Controller.SystemManager.Instance.Services.EquipmentService.Update(model);
                    BandGridData();
                }
            }
            else
            {
                MessageBox.Show("请选择一行数据！");

            }
        }
    }
}
