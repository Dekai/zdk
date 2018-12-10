using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid;

namespace BaseControl
{
    /// <summary>
    /// 报表菜单控件
    /// </summary>
    public class TdqsGridMenu
    {
       
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ctlGridControl"></param>
        public TdqsGridMenu(BandGridView ctlGridControl)
        {
            GridControl = ctlGridControl;
            GridView = ctlGridControl.MainView as BandedGridView;
            GridView.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(GridView_PopupMenuShowing);
        }

        #region 私有函数
        private void GridView_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
         
            if (e.MenuType == DevExpress.XtraGrid.Views.Grid.GridMenuType.Column)
            {
                e.Menu.Items.Clear();
                DevExpress.XtraGrid.Views.BandedGrid.ViewInfo.BandedGridHitInfo bandinfo = e.HitInfo as DevExpress.XtraGrid.Views.BandedGrid.ViewInfo.BandedGridHitInfo;
                if (bandinfo.Band != null && bandinfo.Band.Columns.Count == 1)
                {
                  
                    BandedGridColumn Column = bandinfo.Band.Columns[0];

                    DevExpress.Utils.Menu.DXMenuCheckItem itemSortAZ = new DevExpress.Utils.Menu.DXMenuCheckItem();
                    itemSortAZ.Caption = "正序";
                    itemSortAZ.Image = DevExpress.XtraGrid.Menu.GridMenuImages.Column.Images[1];
                    itemSortAZ.Click += new EventHandler(itemSortAZ_Click);
                    itemSortAZ.Tag = bandinfo.Band.Columns[0];
                    if (Column.SortOrder == DevExpress.Data.ColumnSortOrder.Ascending)
                    {
                        itemSortAZ.Checked = true;
                    }
                    e.Menu.Items.Add(itemSortAZ);

                    DevExpress.Utils.Menu.DXMenuCheckItem itemSortZA = new DevExpress.Utils.Menu.DXMenuCheckItem();
                    itemSortZA.Caption = "逆序";
                    itemSortZA.Image = DevExpress.XtraGrid.Menu.GridMenuImages.Column.Images[2];
                    itemSortZA.Click += new EventHandler(itemSortZA_Click);
                    itemSortZA.Tag = bandinfo.Band.Columns[0];
                    if (Column.SortOrder == DevExpress.Data.ColumnSortOrder.Descending)
                    {
                        itemSortZA.Checked = true;
                    }
                    e.Menu.Items.Add(itemSortZA);

                    DevExpress.Utils.Menu.DXMenuItem itemSortCancel = new DevExpress.Utils.Menu.DXMenuItem();
                    itemSortCancel.Caption = "取消排序";
                    itemSortCancel.Tag = bandinfo.Band.Columns[0];
                    itemSortCancel.Click += new EventHandler(itemSortCancel_Click);
                    e.Menu.Items.Add(itemSortCancel);

                    //有列合并时禁用排序
                    if (bandinfo.Band.HasChildren)
                    {
                        itemSortAZ.Enabled = false;
                        itemSortZA.Enabled = false;
                        itemSortCancel.Enabled = false;
                    }
                    else
                    {
                        itemSortAZ.Enabled = true;
                        itemSortZA.Enabled = true;
                        itemSortCancel.Enabled = true;
                    }


                    DevExpress.Utils.Menu.DXMenuItem splitSort = new DevExpress.Utils.Menu.DXMenuItem();
                    splitSort.Caption = "-";
                    e.Menu.Items.Add(splitSort);

                    if (GridView.GroupedColumns.Contains(Column))
                    {
                        DevExpress.Utils.Menu.DXMenuItem itemUnGroup = new DevExpress.Utils.Menu.DXMenuItem();
                        itemUnGroup.Caption = "取消分组";
                        itemUnGroup.Image = DevExpress.XtraGrid.Menu.GridMenuImages.GroupPanel.Images[2];
                        itemUnGroup.Tag = bandinfo.Band.Columns[0];
                        itemUnGroup.Click += new EventHandler(itemUnGroup_Click);
                        e.Menu.Items.Add(itemUnGroup);
                    }
                    else
                    {
                        DevExpress.Utils.Menu.DXMenuItem itemGroup = new DevExpress.Utils.Menu.DXMenuItem();
                        itemGroup.Caption = "分组";
                        itemGroup.Image = DevExpress.XtraGrid.Menu.GridMenuImages.Column.Images[3];
                        itemGroup.Tag = bandinfo.Band.Columns[0];
                        itemGroup.Click += new EventHandler(itemGroup_Click);
                        e.Menu.Items.Add(itemGroup);
                    }

                    DevExpress.Utils.Menu.DXMenuItem itemAgvColWidth = new DevExpress.Utils.Menu.DXMenuItem();
                    itemAgvColWidth.Caption = "最佳列宽效果";
                    itemAgvColWidth.Image = DevExpress.XtraGrid.Menu.GridMenuImages.Column.Images[6];
                    itemAgvColWidth.Tag = bandinfo.Band.Columns[0];
                    itemAgvColWidth.Click += new EventHandler(itemAgvColWidth_Click);
                    e.Menu.Items.Add(itemAgvColWidth);


                    DevExpress.Utils.Menu.DXMenuItem splitGroup = new DevExpress.Utils.Menu.DXMenuItem();
                    splitGroup.Caption = "-";
                    e.Menu.Items.Add(splitGroup);

                    if (GridView.OptionsView.ShowAutoFilterRow)
                    {
                        DevExpress.Utils.Menu.DXMenuItem itemFilerEditor = new DevExpress.Utils.Menu.DXMenuItem();
                        itemFilerEditor.Caption = "取消过滤行";
                        itemFilerEditor.Image = DevExpress.XtraGrid.Menu.GridMenuImages.Column.Images[7];
                        itemFilerEditor.Tag = bandinfo.Band.Columns[0];
                        itemFilerEditor.Click += new EventHandler(itemFilerEditor_Click);
                        e.Menu.Items.Add(itemFilerEditor);
                    }
                    else
                    {
                        DevExpress.Utils.Menu.DXMenuItem itemFilerEditor = new DevExpress.Utils.Menu.DXMenuItem();
                        itemFilerEditor.Caption = "自动过滤行";
                        itemFilerEditor.Image = DevExpress.XtraGrid.Menu.GridMenuImages.Column.Images[8];
                        itemFilerEditor.Tag = bandinfo.Band.Columns[0];
                        itemFilerEditor.Click += new EventHandler(itemFilerEditor_Click);
                        e.Menu.Items.Add(itemFilerEditor);
                    }

                    DevExpress.Utils.Menu.DXMenuItem itemFilerRow = new DevExpress.Utils.Menu.DXMenuItem();
                    itemFilerRow.Caption = "筛选";
                    itemFilerRow.Tag = bandinfo.Band.Columns[0];
                    itemFilerRow.Click += new EventHandler(itemFilerRow_Click);
                    e.Menu.Items.Add(itemFilerRow);

                    DevExpress.Utils.Menu.DXMenuItem splitFiler = new DevExpress.Utils.Menu.DXMenuItem();
                    splitFiler.Caption = "-";
                    e.Menu.Items.Add(splitFiler);

                    if (Column.OwnerBand.Fixed == DevExpress.XtraGrid.Columns.FixedStyle.None)
                    {
                        DevExpress.Utils.Menu.DXMenuItem itemFixRow = new DevExpress.Utils.Menu.DXMenuItem();
                        itemFixRow.Caption = "冻结列";
                        itemFixRow.Tag = Column.OwnerBand;
                        itemFixRow.Click += new EventHandler(itemFixRow_Click);
                        e.Menu.Items.Add(itemFixRow);
                    }
                    else
                    {
                        DevExpress.Utils.Menu.DXMenuItem itemFixCancel = new DevExpress.Utils.Menu.DXMenuItem();
                        itemFixCancel.Caption = "取消冻结";
                        itemFixCancel.Tag = Column.OwnerBand;
                        itemFixCancel.Click += new EventHandler(itemFixCancel_Click);
                        e.Menu.Items.Add(itemFixCancel);
                    }

                    DevExpress.Utils.Menu.DXMenuItem splitHide = new DevExpress.Utils.Menu.DXMenuItem();
                    splitHide.Caption = "-";
                    e.Menu.Items.Add(splitHide);


                    DevExpress.Utils.Menu.DXMenuItem itemHide = new DevExpress.Utils.Menu.DXMenuItem();
                    itemHide.Caption = "隐藏列";
                    itemHide.Tag = Column.OwnerBand;
                    itemHide.Click += new EventHandler(itemHide_Click);
                    e.Menu.Items.Add(itemHide);

                    DevExpress.Utils.Menu.DXMenuItem itemShow = new DevExpress.Utils.Menu.DXMenuItem();
                    itemShow.Caption = "显示所有列";
                    itemShow.Tag = Column.OwnerBand;
                    itemShow.Click += new EventHandler(itemShow_Click);
                    e.Menu.Items.Add(itemShow);


                }
            }
        }

        void itemShow_Click(object sender, EventArgs e)
        {
            GridBand band = (sender as DevExpress.Utils.Menu.DXMenuItem).Tag as GridBand;
            band = GetRootBand(band);
            foreach (GridBand b in band.View.Bands)
            {
                if (!false.Equals(b.Tag))
                {
                    b.Visible = true;
                }
            }
           
        }
        void itemHide_Click(object sender, EventArgs e)
        {
            GridBand band = (sender as DevExpress.Utils.Menu.DXMenuItem).Tag as GridBand;
            band = GetRootBand(band);
            band.Visible = false;
       
        }

        private void itemFixCancel_Click(object sender, EventArgs e)
        {
            GridBand band = (sender as DevExpress.Utils.Menu.DXMenuItem).Tag as GridBand;
            band = GetRootBand(band);
            for (int i = band.View.Bands.Count-1; i >=0 ; i--)
            {
                band.View.Bands[i].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None;
            }
        
        }
        private void itemFixRow_Click(object sender, EventArgs e)
        {
            GridBand band = (sender as DevExpress.Utils.Menu.DXMenuItem).Tag as GridBand;
            band = GetRootBand(band);
            for (int i = 0; i < band.View.Bands.Count; i++)
            {
                if (band.Index >= i)
                {
                    band.View.Bands[i].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                }
                else
                {
                    band.View.Bands[i].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.None;
                }
            }
        }

        private GridBand GetRootBand(GridBand band)
        {
            GridBand Rootband = band;
            while (Rootband.BandLevel != 0)
            {
                Rootband = Rootband.ParentBand;
            }
            return Rootband;
        }


        private void itemFilerRow_Click(object sender, EventArgs e)
        {
         
            BandedGridColumn Column = (sender as DevExpress.Utils.Menu.DXMenuItem).Tag as BandedGridColumn;
          //  GridView.ShowFilterPopup(Column);
            GridView.ShowFilterEditor(Column);
        }
        private void itemFilerEditor_Click(object sender, EventArgs e)
        {
       
            GridView.OptionsView.ShowAutoFilterRow = !GridView.OptionsView.ShowAutoFilterRow ;
        }
        private void itemAgvColWidth_Click(object sender, EventArgs e)
        {

            GridView.OptionsView.ShowColumnHeaders = true;
            GridView.BestFitColumns();
            GridView.OptionsView.ShowColumnHeaders = false;
        }
        private void itemGroup_Click(object sender, EventArgs e)
        {
            BandedGridColumn Column = (sender as DevExpress.Utils.Menu.DXMenuItem).Tag as BandedGridColumn;
            Column.Group();
            Column.View.ExpandAllGroups();
        }
        private void itemUnGroup_Click(object sender, EventArgs e)
        {
            BandedGridColumn Column = (sender as DevExpress.Utils.Menu.DXMenuItem).Tag as BandedGridColumn;
            Column.UnGroup();
        }
        private void itemSortCancel_Click(object sender, EventArgs e)
        {
            BandedGridColumn Column = (sender as DevExpress.Utils.Menu.DXMenuItem).Tag as BandedGridColumn;
            Column.SortOrder = DevExpress.Data.ColumnSortOrder.None;
            GridControl.UpColnumHeaderIcon();
        }
        private void itemSortZA_Click(object sender, EventArgs e)
        {
            BandedGridColumn Column = (sender as DevExpress.Utils.Menu.DXMenuItem).Tag as BandedGridColumn;
            Column.SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
            GridControl.UpColnumHeaderIcon();
        }
        private void itemSortAZ_Click(object sender, EventArgs e)
        {
            BandedGridColumn Column = (sender as DevExpress.Utils.Menu.DXMenuItem).Tag as BandedGridColumn;
            Column.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
            GridControl.UpColnumHeaderIcon();
    
        }
        #endregion

        #region 成员对象
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView GridView;
        private BandGridView GridControl;
        #endregion

    }
}
