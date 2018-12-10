using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using DevExpress.Xpf.Core;

using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.NavBar;
using BaseControl;

namespace Client
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            ThemeManager.ApplicationThemeName = Theme.Office2010BlueName;
            DevExpressLocalizerHelper.SetSimpleChinese();


            DevExpress.Xpf.Grid.GridControlLocalizer.Active = new CustomDXGridLocalizer();
            DevExpress.Xpf.Editors.EditorLocalizer.Active = new CustomEditorLocalizerLocalizer();
            DevExpress.Xpf.Bars.BarsLocalizer.Active = new CustomBarsLocalizer();
            DevExpress.Xpf.NavBar.NavBarLocalizer.Active = new CustomNavBarLocalizer();
            DevExpress.Xpf.Core.DXMessageBoxLocalizer.Active = new CustomDXMessageBoxLocalizer();

            this.DispatcherUnhandledException += new System.Windows.Threading.DispatcherUnhandledExceptionEventHandler(App_DispatcherUnhandledException);

            base.OnStartup(e);
        }

        void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
            e.Handled = true;
        }
    }

    #region 汉化
    //Reporting ReportDesignerLocalizer ReportDesignerStringId DevExpress.Xpf.ReportDesigner 
    //Data Grid GridControlLocalizer GridControlStringId / GridControlRuntimeStringId DevExpress.Xpf.Grid 
    //Toolbar-Menu / Ribbon BarsLocalizer DevExpress.Xpf.Bars.BarsStringId DevExpress.Xpf.Bars 
    //Chart ChartLocalizer ChartStringId DevExpress.Xpf.Charts.Localization 
    //Pivot Grid PivotGridLocalizer PivotGridStringId DevExpress.XtraPivotGrid.Localization 
    //Scheduler SchedulerControlLocalizer DevExpress.Xpf.Scheduler.SchedulerControlStringId DevExpress.Xpf.Scheduler 
    //Gauge Controls GaugeLocalizer DevExpress.Xpf.Gauges.Localization.GaugeStringId DevExpress.Xpf.Gauges.Localization 
    //Dock Windows DockingLocalizer DevExpress.Xpf.Docking.Base.DockingStringId DevExpress.Xpf.Docking.Base 
    //Printing-Exporting PrintingLocalizer PrintingStringId DevExpress.Xpf.Printing 
    //Data Editors EditorLocalizer EditorStringId DevExpress.Xpf.Editors 
    //Navigation Bar NavBarLocalizer NavBarStringId DevExpress.Xpf.NavBar 
    //PDF Viewer PdfViewerLocalizer DevExpress.Xpf.PdfViewer.PdfViewerStringId DevExpress.Xpf.PdfViewer 

    public class CustomDXGridLocalizer : GridControlLocalizer
    {
        protected override void PopulateStringTable()
        {
            base.PopulateStringTable();
            AddString(GridControlStringId.GridGroupPanelText, "将列拖入此处，表格可以分组");
            AddString(GridControlStringId.ColumnChooserCaption, "未显示的数据列");
            AddString(GridControlStringId.ColumnChooserDragText, "将列拖放到此处");
            AddString(GridControlStringId.PopupFilterBlanks, "空");
            AddString(GridControlStringId.PopupFilterNonBlanks, "非空");
            AddString(GridControlStringId.PopupFilterAll, "所有");
        }
    }


    public class CustomEditorLocalizerLocalizer : EditorLocalizer
    {
        protected override void PopulateStringTable()
        {
            base.PopulateStringTable();
            AddString(EditorStringId.Clear, "清空");
            AddString(EditorStringId.OK, "确定");
            AddString(EditorStringId.Apply, "应用");
            AddString(EditorStringId.SelectAll, "全部选择");
            AddString(EditorStringId.Save, "保存");
            AddString(EditorStringId.Yes, "同意");
            AddString(EditorStringId.No, "不同意");
            AddString(EditorStringId.LookUpSearch, "查找");
            AddString(EditorStringId.LookUpClose, "关闭");
        }
    }

    public class CustomBarsLocalizer : BarsLocalizer
    {
        protected override void PopulateStringTable()
        {
            base.PopulateStringTable();
            AddString(DevExpress.Xpf.Bars.BarsStringId.Ok, "确定");
            AddString(DevExpress.Xpf.Bars.BarsStringId.Cancel, "取消");
            AddString(DevExpress.Xpf.Bars.BarsStringId.Close, "关闭");
           // AddString(DevExpress.Xpf.Bars.BarsStringId.CommandsCustomizationControl_DescriptionCaption, "ddddddddddd");
        }
    }

    public class CustomNavBarLocalizer : NavBarLocalizer
    {
        protected override void PopulateStringTable()
        {
            base.PopulateStringTable();

        }
    }
    public class CustomDXMessageBoxLocalizer : DXMessageBoxLocalizer
    {
        protected override void PopulateStringTable()
        {
            base.PopulateStringTable();
            AddString(DevExpress.Xpf.Core.DXMessageBoxStringId.Ok, "确定");
            AddString(DevExpress.Xpf.Core.DXMessageBoxStringId.Yes, "是");
            AddString(DevExpress.Xpf.Core.DXMessageBoxStringId.No, "否");
            AddString(DevExpress.Xpf.Core.DXMessageBoxStringId.Cancel, "取消");
        }
    }



    #endregion
}
