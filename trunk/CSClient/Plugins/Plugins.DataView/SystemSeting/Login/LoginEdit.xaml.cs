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
using Library.Common;
using Library.Model.Struct;
using System.Data;
using Library.Controller;

namespace Plugins.DataView.SystemSeting.Login
{
    /// <summary>
    /// LoginEdit.xaml 的交互逻辑
    /// </summary>
    public partial class LoginEdit : DevExpress.Xpf.Core.DXWindow
    {
        public LoginEdit()
        {
            InitializeComponent();
            txtF_IsActive.IsChecked = true;
            InitData();
        }

        private void InitData()
        {
            DataTable dt = Library.Controller.SystemManager.Instance.Services.RoleService.GetAllList().Tables[0];
            this.txtF_RoleID.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                NameValue item = new NameValue(row["F_Name"].ToString(), row["F_ID"]);
                this.txtF_RoleID.Items.Add(item);
            }


             dt = Library.Controller.SystemManager.Instance.Services.EmployeeService.GetAllList().Tables[0];
             this.txtF_UserID.Items.Clear();
            foreach (DataRow row in dt.Rows)
            {
                NameValue item = new NameValue(row["F_Name"].ToString(), row["F_ID"]);
                this.txtF_UserID.Items.Add(item);
            }
        }

        public event Library.Controller.TempleteDelegate<Library.Model.LoginUser> SaveComplete;

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            bool b = false;
            if (string.IsNullOrEmpty(this.txtF_LoginName.Text.Trim()))
            {
                this.txtF_LoginNameTip.Text = "(必须填写！)";
                b = true;
            }
            if (string.IsNullOrEmpty(this.txtF_PassWord.Password.Trim()))
            {
                this.txtF_PassWordTip.Text = "(必须填写！)";
                b = true;
            }

            if (txtF_UserID.SelectedItem == null)
            {
                this.txtF_UserIDTip.Text = "(必须选择！)";
                b = true;
            }

            if (txtF_RoleID.SelectedItem == null)
            {
                this.txtF_RoleIDTip.Text = "(必须选择！)";
                b = true;
            }

            if (b)
            {
                return;
            }

            if (m_Model == null)
            {
                Library.Model.LoginUser model = new Library.Model.LoginUser();
                model.F_LoginName = this.txtF_LoginName.Text.Trim();
                model.F_PassWord = this.txtF_PassWord.Password.Trim();
                model.F_UserID = (txtF_UserID.SelectedItem as NameValue).IntValue.Value;
                model.F_RoleID = (txtF_RoleID.SelectedItem as NameValue).IntValue.Value;
                model.F_IsActive = txtF_IsActive.IsChecked==true ? 1 : 0;

                if (SystemManager.Instance.Services.LoginUserService.GetList("F_UserID =" + model.F_UserID).Tables[0].Rows.Count > 0)
                {
                    this.txtF_UserIDTip.Text = "(用户已经存在！)";
                    return;
                }

                Library.Controller.SystemManager.Instance.Services.LoginUserService.Add(model);
                if (SaveComplete != null)
                {
                    SaveComplete(model);
                }
            }
            else
            {

                m_Model.F_LoginName = this.txtF_LoginName.Text.Trim();
                m_Model.F_PassWord = this.txtF_PassWord.Password.Trim();
                m_Model.F_UserID = (txtF_UserID.SelectedItem as NameValue).IntValue.Value;
                m_Model.F_RoleID = (txtF_RoleID.SelectedItem as NameValue).IntValue.Value;
                m_Model.F_IsActive = txtF_IsActive.IsChecked == true ? 1 : 0;

                if (SystemManager.Instance.Services.LoginUserService.GetList("F_UserID =" + m_Model.F_UserID + " and F_ID !=" + m_Model.F_ID).Tables[0].Rows.Count > 0)
                {
                    this.txtF_UserIDTip.Text = "(用户已经存在！)";
                    return;
                }

                Library.Controller.SystemManager.Instance.Services.LoginUserService.Update(m_Model);
                if (SaveComplete != null)
                {
                    SaveComplete(m_Model);
                }
            }


            this.Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private Library.Model.LoginUser m_Model = null;
        public void LoadData(int id)
        {
            m_Model = Library.Controller.SystemManager.Instance.Services.LoginUserService.GetModel(id);
            this.txtF_LoginName.Text = m_Model.F_LoginName;
            this.txtF_PassWord.Password = m_Model.F_PassWord;

            foreach (NameValue nameValue in this.txtF_UserID.Items)
            {
                if (nameValue.IntValue.Equals(m_Model.F_UserID))
                {
                    this.txtF_UserID.SelectedItem = nameValue;
                    break;
                }
            }

            foreach (NameValue nameValue in this.txtF_RoleID.Items)
            {
                if (nameValue.IntValue.Equals(m_Model.F_RoleID))
                {
                    this.txtF_RoleID.SelectedItem = nameValue;
                    break;
                }
            }

            if (m_Model.F_IsActive ==1)
            {

                txtF_IsActive.IsChecked = true;
            }
            else
            {
                txtF_IsActive.IsChecked = false;
            }
        }
    }
}
