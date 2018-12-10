using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.BandedGrid.ViewInfo;
using DevExpress.LookAndFeel;
using DevExpress.XtraPrinting;
using DevExpress.XtraGrid;
using DevExpress.Data;


namespace BaseControl
{
    public class BandInfo
    {
        public BandInfo()
        {
            Width = 120;

            HanderTitle = "默认";

            SummaryType = SummaryItemType.None;
        }

        public DevExpress.Data.SummaryItemType SummaryType {get;set;}
        public string DisplayFormat{get;set;}

         public  List<DevExpress.Data.SummaryItemType> SummaryTypeList {get;set;}
         public List<string> DisplayFormatList { get; set; }
       


        public bool IsFix { get; set; }

        public string HanderTitle { get; set; }
        public string FieldName { get { return m_FieldName; } set { if (!string.IsNullOrEmpty(value)) m_FieldName = value; } }

        private string m_FieldName = string.Empty;
        public int Width { get; set; }
        public bool IsAutoWidth { get; set; }
        public List<BandInfo> Bands { get; set; }

    }
    /// <summary>
    /// 行头双击的委托
    /// </summary>
    /// <param name="rowIndex"></param>
    public delegate void RowHeaderDoublick(int rowIndex);
    public delegate void RowHeaderClick(string field);
    public delegate void GridRowClickDelegate(int rowIndex,string colName,DataRow Row,object CellValue);

    public partial class BandGridView : XtraUserControl
    {
        public BandGridView()
        {

            InitializeComponent();
            this.bandedGridView1.OptionsView.ColumnAutoWidth = false;
            this.bandedGridView1.OptionsView.ShowColumnHeaders = false;
            this.bandedGridView1.OptionsView.AllowCellMerge = true;
            this.bandedGridView1.OptionsView.ShowGroupPanel = false;
            this.bandedGridView1.OptionsPrint.PrintHeader = false;
            this.bandedGridView1.OptionsPrint.AutoWidth = true;
       
            this.bandedGridView1.AppearancePrint.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridView1.AppearancePrint.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            this.bandedGridView1.Images = this.imageList1;
            this.bandedGridView1.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            bandedGridView1.OptionsSelection.MultiSelect = true;
            bandedGridView1.OptionsCustomization.AllowColumnMoving = false;
            bandedGridView1.OptionsCustomization.AllowBandMoving = false;

      

            bandedGridView1.Click += new EventHandler(m_GridView_Click);
            bandedGridView1.DoubleClick += new EventHandler(m_GridView_DoubleClick);


            bandedGridView1.IndicatorWidth = 55;
            bandedGridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(GridView_CustomDrawRowIndicator);
            bandedGridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(MainView_RowCellClick);
            MainView = this.bandedGridView1;

           // Schame();
        }

        public event GridRowClickDelegate GridRowClick;
    
        void MainView_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            System.Data.DataRowView row = MainView.GetRow(e.RowHandle) as System.Data.DataRowView;
            if (row != null)
            {
                if (GridRowClick != null)
                {
                    GridRowClick(e.RowHandle, e.Column.FieldName, row.Row, e.CellValue);
                }
            }
        }

        #region 属性

        public DataRow GetFocusedDataRow()
        {
            return this.bandedGridView1.GetFocusedDataRow();
        }

        public object DataSoure
        {
            get
            {
                return this.gridControl1.DataSource;
            }
            set
            {
                this.gridControl1.DataSource = value;
            }
        }

        public bool PrintAutoWidth
        {
            set
            {
                this.bandedGridView1.OptionsPrint.AutoWidth = value;

            }
        }

        public void BigFont()
        {
            Font font = new System.Drawing.Font("", 12, FontStyle.Regular);
            MainView.Appearance.Row.Font = font;
            MainView.BandPanelRowHeight = 24;

          

            Font bfont = new System.Drawing.Font("", 12, FontStyle.Bold);
            foreach (GridBand band in MainView.Bands)
            {
                band.AppearanceHeader.Font = bfont;
                foreach (GridBand b in band.Children)
                {
                    b.AppearanceHeader.Font = bfont;
                }
            }
        }

        public void SetBackColor(string fieldname)
        {
            Color c = Color.FromArgb(70,240, 246, 252);
            foreach (BandedGridColumn col in MainView.Columns)
            {
                if (col.FieldName.Trim() == fieldname)
                {
                    col.AppearanceCell.BackColor = c;
                }
            }

        }

        public void SetMerage(string fieldname)
        {
            foreach (BandedGridColumn col in MainView.Columns)
            {
                if (col.FieldName.Trim() == fieldname)
                {
                    col.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
                }
            }
        }


        public void SetColor()
        {
            Color c = Color.FromArgb(70, 104, 165);
            Color bc = Color.FromArgb(70, 104, 165);

            MainView.Appearance.Row.ForeColor = c;
            MainView.Appearance.FocusedRow.ForeColor = c;
            MainView.Appearance.FocusedCell.ForeColor = c;
            MainView.Appearance.SelectedRow.ForeColor = c;

            

     
            foreach (GridBand band in MainView.Bands)
            {
                band.AppearanceHeader.ForeColor = bc;
                foreach (GridBand b in band.Children)
                {
                    b.AppearanceHeader.ForeColor = bc;
                }
            }
        }

        public void Filter(string value)
        {
            MainView.ApplyFindFilter(value);
        }

        public BandedGridView MainView { get; set; }
        private bool m_IsFiler = false;
        public bool IsFirstColnum
        {
            get
            {
                return m_IsFirstColnum;
            }
            set
            {
                m_IsFirstColnum = value;
                if (!value)
                {
                    bandedGridView1.IndicatorWidth = 10;
              
                }
            }

        }
        private bool m_IsFirstColnum = true;

        public bool IsShowFindPanel
        {
            get
            {
                return m_IsShowFindPanel;
            }
            set
            {
                m_IsShowFindPanel = value;
               // MainView.ShowFindPanel();
                MainView.OptionsFind.AlwaysVisible = true;
                MainView.OptionsFind.ShowFindButton = false;
                MainView.OptionsFind.ShowCloseButton = false;
                MainView.OptionsFind.ShowClearButton = false;
                
            }
        }
        private bool m_IsShowFindPanel = false;




        /// <summary>
        /// 行头双击事件
        /// </summary>
        public event RowHeaderDoublick RowHeaderDoublickEvent;
        private Color m_Color = Color.FromArgb(111, 113, 112);
        #endregion

        #region 内部方法
        /// <summary>
        /// 绘制序号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridView_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (IsFirstColnum)
            {
                if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                {
                    e.Info.DisplayText = (e.RowHandle + 1).ToString().Trim();
                    e.Info.Appearance.ForeColor = m_Color;
                   // e.Info.Appearance.Font = 
                }
            }
        }
        /// <summary>
        /// 更新列头样式
        /// </summary>
        public void UpColnumHeaderIcon()
        {
            UpColnumHeaderIcon(m_IsFiler);
        }

        /// <summary>
        /// 更新列头样式
        /// </summary>
        /// <param name="isFilter">是否启动帅选条件</param>
        public void UpColnumHeaderIcon(bool isFilter)
        {
            m_IsFiler = isFilter;
            foreach (BandedGridColumn col in MainView.Columns)
            {
                if (isFilter)
                {
                    if (col.SortOrder == DevExpress.Data.ColumnSortOrder.Ascending)
                    {
                        col.OwnerBand.ImageIndex = 2;
                    }
                    else if (col.SortOrder == DevExpress.Data.ColumnSortOrder.Descending)
                    {
                        col.OwnerBand.ImageIndex = 3;
                    }
                    else
                    {
                        col.OwnerBand.ImageIndex = 4;
                    }
                }
                else
                {
                    if (col.SortOrder == DevExpress.Data.ColumnSortOrder.Ascending)
                    {
                        col.OwnerBand.ImageIndex = 0;
                    }
                    else if (col.SortOrder == DevExpress.Data.ColumnSortOrder.Descending)
                    {
                        col.OwnerBand.ImageIndex = 1;
                    }
                    else
                    {
                        col.OwnerBand.ImageIndex = -1;
                    }
                }
            }
        }
        /// <summary>
        /// 双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_GridView_DoubleClick(object sender, EventArgs e)
        {
            Point pt = MainView.GridControl.PointToClient(Control.MousePosition);
            GridHitInfo info = MainView.CalcHitInfo(pt);
            if (info.InRow)
            {
                if (RowHeaderDoublickEvent != null)
                {
                    RowHeaderDoublickEvent(info.RowHandle);
                }
            }
            else
            {
                BandedGridHitInfo binfo = MainView.CalcHitInfo(pt);
                if (binfo != null && binfo.Band != null && binfo.Band.Columns.Count > 0)
                {
                    foreach (BandedGridColumn col in MainView.Columns)
                    {
                        if (col.Name != binfo.Band.Columns[0].Name)
                        {
                            col.SortOrder = DevExpress.Data.ColumnSortOrder.None;

                        }
                    }
                    if (binfo.Band.Columns[0].SortOrder != DevExpress.Data.ColumnSortOrder.Descending)
                    {

                        binfo.Band.Columns[0].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
                    }
                    else
                    {
                        binfo.Band.Columns[0].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                    }

                    UpColnumHeaderIcon();
                }
            }
        }
        /// <summary>
        /// 点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_GridView_Click(object sender, EventArgs e)
        {
            Point screenPoint = Control.MousePosition;
            Point p = this.PointToClient(Control.MousePosition);
            BandedGridHitInfo info = MainView.CalcHitInfo(p);
            if (info != null && info.Band != null && info.Band.Columns.Count > 0 && !info.InRow && !info.InRowCell)
            {
                #region 过滤与排序
                if (m_IsFiler)
                {
                    int lf = p.X + 5;
                    BandedGridHitInfo tinfo = MainView.CalcHitInfo(lf, p.Y);
                    if (tinfo != null && tinfo.Band != info.Band)
                    {
                        return;
                    }

                    lf = p.X + 14;
                    tinfo = MainView.CalcHitInfo(lf, p.Y);
                    if (tinfo != null && tinfo.Band != info.Band)
                    {
                        this.BeginInvoke(new MethodInvoker(() =>
                        {
                            MainView.ShowFilterPopup(info.Band.Columns[0]);
                        }));
                        return;
                    }

                    SentClickHeadEvent(info.Band.Columns[0].FieldName);
                }
                else
                {
                    SentClickHeadEvent(info.Band.Columns[0].FieldName);
                }
                #endregion
            }

        }
        public event RowHeaderClick RowHeaderClick;
        private void SentClickHeadEvent(string FieldName)
        {
            if (RowHeaderClick != null)
            {
                RowHeaderClick(FieldName);
            }
        }





        #endregion

        public void InitData(List<BandInfo> Bands, bool IsBigFont = false, bool IsContextMenu = true, bool ReadlyOnly = true)
        {
          
            CreateBand(Bands,null);

            if (IsContextMenu)
            {
                new TdqsGridMenu(this);
            }
            else
            {
                MainView.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(MainView_PopupMenuShowing);
            }

            if (IsBigFont)
            {
                this.BigFont();
            }

            SetColor();


            if (ReadlyOnly)
            {
                MainView.OptionsBehavior.Editable = false;
              
            }
        }

     

        void MainView_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            e.Allow = false;
        }

        Color m_CommonForeColor = Color.FromArgb(70, 104, 165);
        private void CreateBand(List<BandInfo> Bands, GridBand RootBand)
        {
            this.bandedGridView1.Bands.Clear();
            foreach (BandInfo bandinfo in Bands)
            {
                GridBand gridband = new GridBand();
                gridband.AppearanceHeader.Options.UseTextOptions = true;
                gridband.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                gridband.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                gridband.Caption = bandinfo.HanderTitle;
                gridband.ImageAlignment = StringAlignment.Far;
                gridband.Width = bandinfo.Width;
                gridband.MinWidth = bandinfo.Width;
                if (bandinfo.Bands != null && bandinfo.Bands.Count > 0)
                {
                    CreateBand(bandinfo.Bands, gridband);
                }
                else
                {
                    // 开始生成列
                    BandedGridColumn column = new BandedGridColumn();
                    column.Visible = true;
                    column.FieldName = bandinfo.FieldName;
                    column.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    column.AppearanceCell.ForeColor = m_CommonForeColor;
                    column.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
                    column.Caption = bandinfo.HanderTitle;



                    if (!string.IsNullOrEmpty(column.FieldName))
                    {
                        column.Name = column.FieldName;
                    }
                    this.bandedGridView1.Columns.Add(column);
                    gridband.Columns.Add(column);

                    if (bandinfo.SummaryTypeList != null)
                    {
                        for (int i = 0; i < bandinfo.SummaryTypeList.Count; i++)
                        {
                            GridSummaryItem item0 = column.SummaryItem.Collection.Add();
                            item0.FieldName = column.FieldName;
                            item0.SummaryType = bandinfo.SummaryTypeList[i];
                            item0.DisplayFormat = bandinfo.DisplayFormatList[i];
                        
                        }

                    }
                    else
                    {
                        if (bandinfo.SummaryType != SummaryItemType.None)
                        {
                            column.SummaryItem.SummaryType = bandinfo.SummaryType;
                        }

                        if (!string.IsNullOrEmpty(bandinfo.DisplayFormat))
                        {
                            column.SummaryItem.DisplayFormat = bandinfo.DisplayFormat;
                        }
                    }

                    if (bandinfo.IsFix)
                    {
                        gridband.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                    }
                }     

                if (RootBand == null)
                {
                    this.bandedGridView1.Bands.Add(gridband);
                }
                else
                {
                    RootBand.Children.Add(gridband);
                }
            }


        }


        private bool nPrint = false;
        private List<GridBand> _List = new List<GridBand>();
        private void SaveFix()
        {

            _List.Clear();
            foreach (GridBand band in bandedGridView1.Bands)
            {
                if (band.Fixed == DevExpress.XtraGrid.Columns.FixedStyle.Left)
                {
                    band.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None;
                    _List.Add(band);
                }
            }
        }

        private void ClearFix()
        {

            foreach (GridBand band in _List)
            {
                band.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            }
            _List.Clear();
        }

        public void Schame()
        {
            this.gridControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControl1.LookAndFeel.SkinName = "Whiteprint";
          // this.gridControl1.LookAndFeel.SetSkinStyle("Whiteprint");

        }


        public void Print()
        {
            try
            {

                nPrint = true;
                this.bandedGridView1.RefreshData();
                SaveFix();
                PrintingSystem print = new DevExpress.XtraPrinting.PrintingSystem();
                PrintableComponentLink link = new PrintableComponentLink(print);
                print.Links.Add(link);
                link.Component = this.gridControl1;// 当前的表格控件
                string _PrintHeader = this.Text;  // 这里要根据业务修改
                PageHeaderFooter phf = link.PageHeaderFooter as PageHeaderFooter;
                phf.Header.Content.Clear();
                phf.Header.Content.AddRange(new string[] { "", _PrintHeader, "" });
                phf.Header.Font = new System.Drawing.Font("宋体", 14, System.Drawing.FontStyle.Bold);
                phf.Header.LineAlignment = BrickAlignment.Center;
                link.CreateDocument();
                print.PreviewFormEx.ShowDialog();
                print.PreviewFormEx.FormClosed += new FormClosedEventHandler(PreviewFormEx_FormClosed);
            }
            finally
            {
                ClearFix();
            }
        }

        void PreviewFormEx_FormClosed(object sender, FormClosedEventArgs e)
        {
            nPrint = false; ;
        }

        public void Excel()
        {
            try
            {
                nPrint = true;
                SaveFix();
                SaveFileDialog fileDialog = new SaveFileDialog();
                fileDialog.Title = "导出Excel";
                fileDialog.Filter = "Excel文件(*.xlsx)|*.xlsx";
                fileDialog.FileName = this.Text;
                DialogResult dialogResult = fileDialog.ShowDialog(this);
                if (dialogResult == DialogResult.OK)
                {
                    DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions();
                    this.gridControl1.ExportToXlsx(fileDialog.FileName);
                    DevExpress.XtraEditors.XtraMessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                nPrint = false; ;
            }
            finally
            {
                ClearFix();
            }
        }

        public void ShowSummery()
        {
            Font font = new System.Drawing.Font("", 10, FontStyle.Regular);
            this.bandedGridView1.Appearance.FooterPanel.Font = font;
            this.bandedGridView1.Appearance.FooterPanel.ForeColor = Color.FromArgb(70, 104, 165);
            this.bandedGridView1.Appearance.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.bandedGridView1.FooterPanelHeight = 20;
            this.bandedGridView1.OptionsView.ShowFooter = true;


        }
    }
}
