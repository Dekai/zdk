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
using Library.Model;
using Library.Common;

namespace Plugins.DataView.BaseData
{
    /// <summary>
    /// EmployeeEdit.xaml 的交互逻辑
    /// </summary>
    public partial class EmployeeEdit : DXWindow
    {
        public EmployeeEdit()
        {
            InitializeComponent();
        }

        public event Library.Controller.TempleteDelegate<Library.Model.Employee> SaveComplete;

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            bool b = false;
            if (string.IsNullOrEmpty(this.txtName.Text.Trim()))
            {
                this.txtNameTip.Text = "(必须填写！)";
                b = true;
            }
            if (!FormValidate.IsPhone(this.txtMobile.Text.Trim()))
            {
                this.txtMobileTip.Text = "(手机号格式不正确！)";
                b = true;
            }
            if (b)
            {
                return;
            }



            if (m_Model == null)
            {
                Library.Model.Employee model = new Employee();
                model.F_Name = this.txtName.Text.Trim();
                model.F_Mobile = this.txtMobile.Text.Trim();
                Library.Controller.SystemManager.Instance.Services.EmployeeService.Add(model);
                if (SaveComplete != null)
                {
                    SaveComplete(model);
                }
            }
            else
            {

                m_Model.F_Name = this.txtName.Text.Trim();
                m_Model.F_Mobile = this.txtMobile.Text.Trim();
                Library.Controller.SystemManager.Instance.Services.EmployeeService.Update(m_Model);
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
        private Library.Model.Employee m_Model = null;
        public void LoadData(int id)
        {
            m_Model = Library.Controller.SystemManager.Instance.Services.EmployeeService.GetModel(id);
            this.txtName.Text = m_Model.F_Name;
            this.txtMobile.Text = m_Model.F_Mobile;
        }

    }
}
