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
using BaseControl.Tree;
using Library.Controller;
using System.Data;
using Library.Model;
using Library.Common;

namespace Plugins.DataView.ExperimentalData
{
    /// <summary>
    /// DataGridStyleSetting.xaml 的交互逻辑
    /// </summary>
    public partial class DataGridStyleSetting : UserControl
    {
        public DataGridStyleSetting()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(DataInput_Loaded);
        }

        #region 表格
        public TreeControl TreeControl
        {
            get
            {
                if (m_TreeControl == null)
                {
                    m_TreeControl = new TreeControl();
                    m_TreeControl.IsShowCheckBox = false;
                    m_TreeControl.NodeClick += new TreeNodeDelegate(m_TreeControl_NodeClick);
                    List<TreeNodeInfo> Nodes = new List<TreeNodeInfo>();
                    DataTable dt = SystemManager.Instance.Services.DataDicInfoService.GetList("F_TypeCode='T_Test_Table_Type' order by F_Order").Tables[0];
                    foreach (DataRow row in dt.Rows)
                    {
                        TreeNodeInfo pinfo = new TreeNodeInfo();
                        pinfo.ID = row["F_ID"].ToString();
                        pinfo.Text = row["F_Name"].ToString();
                        pinfo.Childs = new List<TreeNodeInfo>();
                        Nodes.Add(pinfo);
                        DataTable sdt = SystemManager.Instance.Services.Test_Table_TempleteService.GetList("F_TypeID='" + pinfo.ID + "' order by F_Order").Tables[0];
                        foreach (DataRow srow in sdt.Rows)
                        {
                            TreeNodeInfo info = new TreeNodeInfo();
                            info.ID = srow["F_ID"].ToString();
                            info.Text = srow["F_Name"].ToString();
                            info.Tag = srow;
                            pinfo.Childs.Add(info);
                        }
                    }
                    TreeControl.Nodes = Nodes;
                    TreeControl.DataBind();
                    TreeControl.ExpandAll();
                }
                return m_TreeControl;
            }
        }

        private TreeControl m_TreeControl;
        #endregion
        void DataInput_Loaded(object sender, RoutedEventArgs e)
        {
            host1.Child = TreeControl;
        }

        Test_Table_Templete tmepmodel;
        void m_TreeControl_NodeClick(TreeNodeInfo t)
        {
            if (t.Tag != null)
            {
                tmepmodel = SystemManager.Instance.Services.Test_Table_TempleteService.GetModel(int.Parse(t.ID));
                F_ShowWidth.Text = tmepmodel.F_ShowWidth.Value.ToString();
                F_ShowHeight.Text = tmepmodel.F_ShowHeight.Value.ToString();
                F_ShowFontSize.Text = tmepmodel.F_ShowFontSize.Value.ToString();
                F_ShowBorderColor.Text = tmepmodel.F_ShowBorderColor;
                F_ShowFontColor.Text = tmepmodel.F_ShowFontColor;
                F_ShowBackColor.Text = tmepmodel.F_ShowBackColor;
            }
        }

        private void btnSplit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (colLeft.Width.Value == 0)
            {
                colLeft.Width = new GridLength(180);
                host1.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                colLeft.Width = new GridLength(0);
                host1.Visibility = System.Windows.Visibility.Collapsed;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (tmepmodel == null)
            {
                MessageBox.Show("请选择树节点");
                return;
            }
            bool b = false;
         
            if (!FormValidate.IsNumber(this.F_ShowWidth.Text.Trim(),false))
            {
                this.F_ShowWidthTip.Text = "(请填写正整数！)";
                b = true;
            }
            if (!FormValidate.IsNumber(this.F_ShowHeight.Text.Trim(), false))
            {
                this.F_ShowHeightTip.Text = "(请填写正整数！)";
                b = true;
            }
            if (!FormValidate.IsNumber(this.F_ShowFontSize.Text.Trim(), false))
            {
                this.F_ShowFontSizeTip.Text = "(请填写正整数！)";
                b = true;
            }
            if (!FormValidate.IsColor(F_ShowBorderColor.Text.Trim()))
            {
                this.F_ShowBorderColorTip.Text = "(颜色格式不正确！)";
                b = true;
            }
            if (!FormValidate.IsColor(F_ShowFontColor.Text.Trim()))
            {
                this.F_ShowFontColorTip.Text = "(颜色格式不正确！)";
                b = true;
            }
            if (!FormValidate.IsColor(F_ShowBackColor.Text.Trim()))
            {
                this.F_ShowBackColorTip.Text = "(颜色格式不正确！)";
                b = true;
            }

            if (b)
            {
                return;
            }



            if (tmepmodel != null)
            {
                tmepmodel.F_ShowWidth = int.Parse(F_ShowWidth.Text.Trim());
                tmepmodel.F_ShowHeight = int.Parse(F_ShowHeight.Text.Trim());
                tmepmodel.F_ShowFontSize = int.Parse(F_ShowFontSize.Text.Trim());
                tmepmodel.F_ShowBorderColor = F_ShowBorderColor.Text;
                tmepmodel.F_ShowFontColor = F_ShowFontColor.Text;
                tmepmodel.F_ShowBackColor = F_ShowBackColor.Text;
                SystemManager.Instance.Services.Test_Table_TempleteService.Update(tmepmodel);
                MessageBox.Show("更新成功！");

            }
        }
    }
}
