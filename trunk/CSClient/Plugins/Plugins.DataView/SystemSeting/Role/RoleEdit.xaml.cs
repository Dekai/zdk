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
using Library.Common;

namespace Plugins.DataView.SystemSeting.Role
{
    /// <summary>
    /// EmployeeEdit.xaml 的交互逻辑
    /// </summary>
    public partial class RoleEdit : DXWindow
    {
        public RoleEdit()
        {
            InitializeComponent();
        }

        public event Library.Controller.TempleteDelegate<Library.Model.Role> SaveComplete;

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            bool b = false;
            if (string.IsNullOrEmpty(this.txtF_Name.Text.Trim()))
            {
                this.txtF_NameTip.Text = "(必须填写！)";
                b = true;
            }
            if (!FormValidate.IsNumber(this.txtF_Order.Text.Trim()))
            {
                this.txtF_OrderTip.Text = "(排序格式不正确！)";
                b = true;
            }
            if (b)
            {
                return;
            }

            if (m_Model == null)
            {
                Library.Model.Role model = new Library.Model.Role();
                model.F_Name = this.txtF_Name.Text.Trim();
                if (!string.IsNullOrEmpty(this.txtF_Order.Text.Trim()))
                {
                    model.F_Order = int.Parse(this.txtF_Order.Text.Trim());
                }

                Library.Controller.SystemManager.Instance.Services.RoleService.Add(model);
                if (SaveComplete != null)
                {
                    SaveComplete(model);
                }
            }
            else
            {

                m_Model.F_Name = this.txtF_Name.Text.Trim();
                if (!string.IsNullOrEmpty(this.txtF_Order.Text.Trim()))
                {
                    m_Model.F_Order = int.Parse(this.txtF_Order.Text.Trim());
                }
                Library.Controller.SystemManager.Instance.Services.RoleService.Update(m_Model);
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
        private Library.Model.Role m_Model = null;
        public void LoadData(int id)
        {
            m_Model = Library.Controller.SystemManager.Instance.Services.RoleService.GetModel(id);
            this.txtF_Name.Text = m_Model.F_Name;
            if (m_Model.F_Order != null)
            {
                this.txtF_Order.Text = m_Model.F_Order.ToString();
            }
        }
    }
}
