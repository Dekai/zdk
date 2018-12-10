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
using DevExpress.Xpf.Core;

using System.Configuration;
using System.Text.RegularExpressions;
using Library.Controller;
using System.Data;

namespace Client
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : DXWindow
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public Login()
        {
            InitializeComponent();
            this.Width = 400;
            this.ShowInTaskbar = false;
            this.ResizeMode = System.Windows.ResizeMode.NoResize;
            this.WindowStyle = System.Windows.WindowStyle.ToolWindow;
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.Loaded += new RoutedEventHandler(Login_Loaded);

        }

        void Login_Loaded(object sender, RoutedEventArgs e)
        {
            txtUserCode.Focus();    
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserCode.Text.Trim()) || string.IsNullOrEmpty(txtPassWord.Password.Trim()))
            {
                MessageBox.Show("用户名和密码不能为空！");
                return;
            }

            string sWere = "F_LoginName='"+this.txtUserCode.Text.Trim()+"' and F_PassWord='"+this.txtPassWord.Password.Trim()+"'";
             DataTable dt=  SystemManager.Instance.Services.LoginUserService.GetList(sWere).Tables[0];
             if (dt.Rows.Count > 0)
             {
                 int nFID = int.Parse(dt.Rows[0]["F_ID"].ToString());
                 int nRoleID = int.Parse(dt.Rows[0]["F_RoleID"].ToString());
                 SystemManager.Instance.CurrentUser = SystemManager.Instance.Services.LoginUserService.GetModel(nFID);
                 SystemManager.Instance.RightCodeList = SystemManager.Instance.Services.RightService.GetCodeList(nRoleID);

                 this.DialogResult = true;
                 this.Close();
             }
             else
             {
                 MessageBox.Show("用户名或密码错误！");
             }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void txtPassWord_KeyUp(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUserCode.Text.Trim()) && !string.IsNullOrEmpty(txtPassWord.Password.Trim()))
            {
                if (e.Key == Key.Enter)
                {
                    btnLogin_Click(sender, e);
                }

            }
        }

    

    }
}
