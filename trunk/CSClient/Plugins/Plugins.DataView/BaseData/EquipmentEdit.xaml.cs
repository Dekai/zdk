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
    public partial class EquipmentEdit : DXWindow
    {
        public EquipmentEdit()
        {
            InitializeComponent();
        }

        public event Library.Controller.TempleteDelegate<Library.Model.Equipment> SaveComplete;

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            bool b = false;
            if (string.IsNullOrEmpty(this.txtName.Text.Trim()))
            {
                this.txtNameTip.Text = "(必须填写！)";
                b = true;
            }
            if (!FormValidate.IsNumber(this.txtF_Order.Text.Trim()))
            {
                this.txtF_OrderTip.Text = "排序格式不正确！";
                b = true;
            }
            if (b)
            {
                return;
            }



            if (m_Model == null)
            {
                Library.Model.Equipment model = new Equipment();
                model.F_Name = this.txtName.Text.Trim();
                model.F_Decs = this.txtF_Decs.Text.Trim();
                if (!string.IsNullOrEmpty(this.txtF_Order.Text.Trim()))
                {
                    model.F_Order = int.Parse(this.txtF_Order.Text.Trim());
                }
                Library.Controller.SystemManager.Instance.Services.EquipmentService.Add(model);
                if (SaveComplete != null)
                {
                    SaveComplete(model);
                }
            }
            else
            {

                m_Model.F_Name = this.txtName.Text.Trim();
                m_Model.F_Decs = this.txtF_Decs.Text.Trim();
                if (!string.IsNullOrEmpty(this.txtF_Order.Text.Trim()))
                {
                    m_Model.F_Order = int.Parse(this.txtF_Order.Text.Trim());
                }
                Library.Controller.SystemManager.Instance.Services.EquipmentService.Update(m_Model);
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
        private Library.Model.Equipment m_Model = null;
        public void LoadData(int id)
        {
            m_Model = Library.Controller.SystemManager.Instance.Services.EquipmentService.GetModel(id);
            this.txtName.Text = m_Model.F_Name;
            this.txtF_Decs.Text = m_Model.F_Decs;
            if (m_Model.F_Order != null)
            {
                this.txtF_Order.Text = m_Model.F_Order.Value.ToString();
            }
        }

    }
}
