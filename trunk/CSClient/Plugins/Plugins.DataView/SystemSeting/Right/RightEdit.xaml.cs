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
using System.Data;
using Library.Model.Struct;


namespace Plugins.DataView.SystemSeting.Right
{
    /// <summary>
    /// RightEdit.xaml 的交互逻辑
    /// </summary>
    public partial class RightEdit : DXWindow
    {
        public RightEdit()
        {
            InitializeComponent();
            InitData();
        }

        private void InitData()
        {
            DataTable dt = Library.Controller.SystemManager.Instance.Services.RightService.GetAllList().Tables[0];

            this.txtF_PID.Items.Clear();
            NameValue item0 = new NameValue("无",-1);
            this.txtF_PID.Items.Add(item0);
            foreach (DataRow row in dt.Rows)
            {
                NameValue item = new NameValue(row["F_Name"].ToString(),row["F_ID"]);
                this.txtF_PID.Items.Add(item);
            }
        }

        public event Library.Controller.TempleteDelegate<Library.Model.Right> SaveComplete;

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            bool b = false;
            if (string.IsNullOrEmpty(this.txtF_Name.Text.Trim()))
            {
                this.txtF_NameTip.Text = "(必须填写！)";
                b = true;
            }
            if (string.IsNullOrEmpty(this.txtF_Code.Text.Trim()))
            {
                this.txtF_CodeTip.Text = "(必须填写！)";
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
                Library.Model.Right model = new Library.Model.Right();
                model.F_Name = this.txtF_Name.Text.Trim();
                model.F_Code = this.txtF_Code.Text.Trim();
                if (this.txtF_PID.SelectedItem != null)
                {
                    NameValue nameValue   = this.txtF_PID.SelectedValue as NameValue;
                    model.F_PID = nameValue.IntValue;
                }
                if (!string.IsNullOrEmpty(this.txtF_Order.Text.Trim()))
                {
                    model.F_Order = int.Parse(this.txtF_Order.Text.Trim());
                }

                Library.Controller.SystemManager.Instance.Services.RightService.Add(model);
                if (SaveComplete != null)
                {
                    SaveComplete(model);
                }
            }
            else
            {

                m_Model.F_Name = this.txtF_Name.Text.Trim();
                m_Model.F_Code = this.txtF_Code.Text.Trim();
                if (this.txtF_PID.SelectedItem != null)
                {
                    NameValue nameValue = this.txtF_PID.SelectedValue as NameValue;
                    m_Model.F_PID = nameValue.IntValue;
                }
                if (!string.IsNullOrEmpty(this.txtF_Order.Text.Trim()))
                {
                    m_Model.F_Order = int.Parse(this.txtF_Order.Text.Trim());
                }
                Library.Controller.SystemManager.Instance.Services.RightService.Update(m_Model);
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
        private Library.Model.Right m_Model = null;
        public void LoadData(int id)
        {
            m_Model = Library.Controller.SystemManager.Instance.Services.RightService.GetModel(id);
           
            this.txtF_Name.Text = m_Model.F_Name;
           
            this.txtF_Code.Text = m_Model.F_Code;
            
   
            foreach (NameValue nameValue in this.txtF_PID.Items)
            {
                if (nameValue.IntValue.Equals(m_Model.F_PID))
                {
                    this.txtF_PID.SelectedItem = nameValue;
                    break;
                }
            }

            if (m_Model.F_Order != null)
            {
                this.txtF_Order.Text = m_Model.F_Order.ToString();
            }
        }
    }
}
