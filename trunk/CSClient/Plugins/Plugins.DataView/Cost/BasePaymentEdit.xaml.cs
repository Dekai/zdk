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
using Library.Controller;

namespace Plugins.DataView.BaseData
{
    /// <summary>
    /// EmployeeEdit.xaml 的交互逻辑
    /// </summary>
    public partial class BasePaymentEdit : DXWindow
    {
        public BasePaymentEdit()
        {
            InitializeComponent();
        }

        public event Library.Controller.TempleteDelegate<Library.Model.Audit> SaveComplete;

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            bool b = false;
            if (string.IsNullOrEmpty(this.txtF_Name.Text.Trim()))
            {
                this.txtF_NameTip.Text = "(必须填写！)";
                b = true;
            }
            if (!FormValidate.IsPlusDecimal(this.txtF_Money.Text.Trim()))
            {
                this.txtF_MoneyTip.Text = "(必须填写[数字]！)";
                b = true;
            }
            if (b)
            {
                return;
            }



            if (m_Model == null)
            {
                Library.Model.Audit model = new Audit();
                model.F_Name = this.txtF_Name.Text.Trim();
                model.F_Content = this.txtF_Content.Text.Trim();
                model.F_Money = decimal.Parse(this.txtF_Money.Text.Trim());
                model.F_Time = DateTime.Now;
                model.F_UserID = SystemManager.Instance.CurrentUser.F_UserID;
                model.F_WF_StateID = SystemManager.Instance.Services.WorkFlow_TempleteService.GetNextState(Library.DataDictionary.WorkFlowLinkTable.Audit);
                model.F_Date = DateTime.Now;
                model.F_IsDelete = false;
                model.F_Type = 1;
                Library.Controller.SystemManager.Instance.Services.AuditService.Add(model);
                if (SaveComplete != null)
                {
                    SaveComplete(model);
                }
            }
            else
            {

                m_Model.F_Name = this.txtF_Name.Text.Trim();
                m_Model.F_Content = this.txtF_Content.Text.Trim();
                m_Model.F_Money = decimal.Parse(this.txtF_Money.Text.Trim());
                m_Model.F_Time = DateTime.Now;
                m_Model.F_UserID = SystemManager.Instance.CurrentUser.F_UserID;
                Library.Controller.SystemManager.Instance.Services.AuditService.Update(m_Model);
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
        private Library.Model.Audit m_Model = null;
        public void LoadData(int id)
        {
            m_Model = Library.Controller.SystemManager.Instance.Services.AuditService.GetModel(id);
            this.txtF_Name.Text = m_Model.F_Name;
            this.txtF_Content.Text = m_Model.F_Content;
            this.txtF_Money.Text = m_Model.F_Money.ToString();
        }
    }
}
