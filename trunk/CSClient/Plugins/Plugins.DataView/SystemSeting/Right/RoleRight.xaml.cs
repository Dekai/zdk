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
using BaseControl.Tree;
using System.Data;

namespace Plugins.DataView.SystemSeting.Right
{
    /// <summary>
    /// RoleRight.xaml 的交互逻辑
    /// </summary>
    public partial class RoleRight : UserControl
    {
        public RoleRight()
        {
            InitializeComponent();

         

            this.Loaded += new RoutedEventHandler(RoleRight_Loaded);
        }

        void RoleRight_Loaded(object sender, RoutedEventArgs e)
        {
            BandGridData();
            BandTreeData();
            BandWFData();
        }

      

        #region 表格
        public BandGridView GridView
        {
            get
            {
                if (m_GridView == null)
                {
                    m_GridView = new BandGridView();
                    m_GridView.GridRowClick += new GridRowClickDelegate(m_GridView_GridRowClick);
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
            b0.HanderTitle = "角色";
            b0.FieldName = "F_Name";
            b0.Width = 200;
            Bands.Add(b0);



            return Bands;
        }
        private BandGridView m_GridView;

        private void BandGridData()
        {
            DataTable dt = SystemManager.Instance.Services.RoleService.GetAllList().Tables[0];
            this.GridView.DataSoure = dt;
        }


        #endregion


        #region 树
        public TreeControl TreeControl
        {
            get
            {
                if (m_TreeControl == null)
                {
                    m_TreeControl = new TreeControl();
                    host2.Child = m_TreeControl;
                }
                return m_TreeControl;
            }
        }
        private TreeControl m_TreeControl;

        private void BandTreeData()
        {
            TreeControl.Nodes = SystemManager.Instance.Services.RightService.GetNodes();
            TreeControl.DataBind();
            TreeControl.ExpandAll();
        }

        public TreeControl TreeControl1
        {
            get
            {
                if (m_TreeControl1 == null)
                {
                    m_TreeControl1 = new TreeControl();
                    host3.Child = m_TreeControl1;
                }
                return m_TreeControl1;
            }
        }
        private TreeControl m_TreeControl1;


        private void BandWFData()
        {
            TreeControl1.Nodes = SystemManager.Instance.Services.WorkFlow_TempleteService.GetNodes();
            TreeControl1.DataBind();
            TreeControl1.ExpandAll();
        }



        #endregion

        void m_GridView_GridRowClick(int rowIndex, string colName, DataRow Row, object CellValue)
        {
            if (Row != null)
            {
                string F_RoleID = Row["F_ID"].ToString();
                DataTable dt = SystemManager.Instance.Services.Role_Right_RelationService.GetList("F_RoleID=" + F_RoleID).Tables[0];
                List<string> l = new List<string>();
                foreach (DataRow row in dt.Rows)
                {
                    l.Add(row[1].ToString());
                }

                TreeControl.SetSelectNodes(l);


                dt = SystemManager.Instance.Services.Role_WorkflowService.GetList("F_RoleID=" + F_RoleID).Tables[0];
                List<string> l1 = new List<string>();
                foreach (DataRow row in dt.Rows)
                {
                    l1.Add(row[1].ToString());
                }

                TreeControl1.SetSelectNodes(l1);

            }
        }


        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            DataRow row = this.GridView.GetFocusedDataRow();
            if (row != null)
            {
                int F_RoleID = int.Parse(row["F_ID"].ToString());
                List<TreeNodeInfo> l = TreeControl.GetSelectNodes();
                SystemManager.Instance.Services.Role_Right_RelationService.Delete(F_RoleID);
                foreach (TreeNodeInfo info in l)
                {
                    Library.Model.Role_Right_Relation relation = new Library.Model.Role_Right_Relation();
                    relation.F_RoleID = F_RoleID;
                    relation.F_RightID = int.Parse(info.ID);
                    SystemManager.Instance.Services.Role_Right_RelationService.Add(relation);
                }


                List<TreeNodeInfo> l1 = TreeControl1.GetSelectNodes();
                SystemManager.Instance.Services.Role_WorkflowService.Delete(F_RoleID);
                foreach (TreeNodeInfo info in l1)
                {
                    if (!string.IsNullOrEmpty(info.ID))
                    {
                        Library.Model.Role_Workflow relation = new Library.Model.Role_Workflow();
                        relation.F_RoleID = F_RoleID;
                        relation.F_WFID = int.Parse(info.ID);
                        SystemManager.Instance.Services.Role_WorkflowService.Add(relation);
                    }
                }



                MessageBox.Show("保存成功！");
            }
        }
    }
}
