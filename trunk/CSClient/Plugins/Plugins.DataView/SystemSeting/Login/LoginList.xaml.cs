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
using BaseControl;
using Library.Controller;
using System.Data;

namespace Plugins.DataView.SystemSeting.Login
{
    /// <summary>
    /// LoginList.xaml 的交互逻辑
    /// </summary>
    public partial class LoginList : UserControl
    {
        public LoginList()
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
            b0.HanderTitle = "登陆名";
            b0.FieldName = "F_LoginName";
            b0.Width = 200;
            Bands.Add(b0);

            BandInfo b1 = new BandInfo();
            b1.HanderTitle = "用户姓名";
            b1.FieldName = "UserName";
            b1.Width = 200;
            Bands.Add(b1);


            BandInfo b2 = new BandInfo();
            b2.HanderTitle = "角色名称";
            b2.FieldName = "RoleName";
            b2.Width = 200;
            Bands.Add(b2);


            BandInfo b3 = new BandInfo();
            b3.HanderTitle = "是否启用";
            b3.FieldName = "IsActive";
            b3.Width = 50;
            Bands.Add(b3);

            return Bands;
        }
        private BandGridView m_GridView;
        #endregion


        private void BandGridData()
        {
            DataTable dt = SystemManager.Instance.Services.LoginUserService.GetAllLinkList();
            this.GridView.DataSoure = dt;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            LoginEdit win = new LoginEdit();
            win.SaveComplete += (model) =>
            {
                BandGridData();
                MessageBox.Show("保存" + model.F_LoginName + "成功！");
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
                LoginEdit win = new LoginEdit();
                win.LoadData(id);
                win.SaveComplete += (model) =>
                {
                    BandGridData();
                    MessageBox.Show("保存" + model.F_LoginName + "成功！");
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
                    Library.Controller.SystemManager.Instance.Services.LoginUserService.Delete(id);
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
