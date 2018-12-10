using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraEditors.Controls;

using DevExpress.XtraLayout.Localization;
using DevExpress.XtraPrinting.Localization;
using DevExpress.Xpf.NavBar;


namespace BaseControl
{
    /// <summary>
    /// 汉化简化辅助类
    /// </summary>
    public class DevExpressLocalizerHelper
    {
        public static void SetSimpleChinese()
        {
            DevExpress.XtraGrid.Localization.GridLocalizer.Active = new XtraGridLocalizer_zh_chs();
            DevExpress.XtraGrid.Localization.GridResLocalizer.Active = new XtraGridLocalizer_zh_chs();
            DevExpress.XtraLayout.Localization.LayoutLocalizer.Active = new XtraLayoutLocalizer_zh_chs();
            DevExpress.XtraLayout.Localization.LayoutResLocalizer.Active = new XtraLayoutLocalizer_zh_chs();
            DevExpress.XtraEditors.Controls.Localizer.Active = new XtraEditorLocalizer_zh_chs();

         
            DevExpress.Xpf.NavBar.NavBarLocalizer.Active = new XtraNavBar_CN();
            DevExpress.XtraPrinting.Localization.PreviewLocalizer.Active = new XtraPrinting_CN();
          

       
        }
        public static String Language = "zh-chs";
    }

    public class XtraNavBar_CN : NavBarLocalizer
    {
        public override string Language
        {
            get
            {
                return "简体中文";
            }
        }

        public override string GetLocalizedString(NavBarStringId id)
        {
            switch (id)
            {
                case NavBarStringId.ItemIsAlreadyAddedToAnotherGroupException: return "配置按钮";
                case NavBarStringId.NavPaneMenuAddRemoveButtons: return "添加或删除按钮(&A)";
                case NavBarStringId.NavPaneMenuShowFewerButtons: return "显示较少的按钮(&F)";
                case NavBarStringId.NavPaneMenuShowMoreButtons: return "显示更多的按钮(&M)";
            }
            return base.GetLocalizedString(id);
        }
    }


    public class XtraPrinting_CN : PreviewLocalizer
    {
        public override string Language
        {
            get
            {
                return "简体中文";
            }
        }

        public override string GetLocalizedString(PreviewStringId id)
        {
            switch (id)
            {
                case PreviewStringId.Button_Apply: return "应用";
                case PreviewStringId.Button_Cancel: return "取消";
                case PreviewStringId.Button_Help: return "帮助";
                case PreviewStringId.Button_Ok: return "确定";
                case PreviewStringId.EMail_From: return "From";
                case PreviewStringId.Margin_BottomMargin: return "下边界";
                case PreviewStringId.Margin_Inch: return "英寸";
                case PreviewStringId.Margin_LeftMargin: return "左边界";
                case PreviewStringId.Margin_Millimeter: return "毫米";
                case PreviewStringId.Margin_RightMargin: return "右边界";
                case PreviewStringId.Margin_TopMargin: return "上边界";
                case PreviewStringId.MenuItem_BackgrColor: return "颜色(&C)";
                case PreviewStringId.MenuItem_Background: return "背景(&B)";
                case PreviewStringId.MenuItem_CsvDocument: return "CSV文件";
                case PreviewStringId.MenuItem_Exit: return "退出(&X)";
                case PreviewStringId.MenuItem_Export: return "导出(&E)";
                case PreviewStringId.MenuItem_File: return "文件(&F)";
                case PreviewStringId.MenuItem_GraphicDocument: return "图片文件";
                case PreviewStringId.MenuItem_HtmDocument: return "HTML文件";
                case PreviewStringId.MenuItem_MhtDocument: return "MHT文件";
                case PreviewStringId.MenuItem_PageSetup: return "页面设置(&U)";
                case PreviewStringId.MenuItem_PdfDocument: return "PDF文件";
                case PreviewStringId.MenuItem_Print: return "打印(&P)";
                case PreviewStringId.MenuItem_PrintDirect: return "直接打印(&R)";
                case PreviewStringId.MenuItem_RtfDocument: return "RTF文件";
                case PreviewStringId.MenuItem_Send: return "发送(&D)";
                case PreviewStringId.MenuItem_TxtDocument: return "TXT文件";
                case PreviewStringId.MenuItem_View: return "视图(&V)";
                case PreviewStringId.MenuItem_ViewStatusbar: return "状态栏(&S)";
                case PreviewStringId.MenuItem_ViewToolbar: return "工具栏(&T)";
                case PreviewStringId.MenuItem_Watermark: return "水印(&W)";
                case PreviewStringId.MenuItem_XlsDocument: return "XLS文件";
                case PreviewStringId.MPForm_Lbl_Pages: return "页";
                case PreviewStringId.Msg_CreatingDocument: return "正在生成文件";
                case PreviewStringId.Msg_CustomDrawWarning: return "警告!";
                case PreviewStringId.Msg_EmptyDocument: return "此文件没有页面.";
                case PreviewStringId.Msg_FontInvalidNumber: return "字体大小不能为0或负数";
                case PreviewStringId.Msg_IncorrectPageRange: return "设置的页边界不正确";
                case PreviewStringId.Msg_NeedPrinter: return "没有安装打印机.";
                case PreviewStringId.Msg_NotSupportedFont: return "这种字体不被支持";
                case PreviewStringId.Msg_PageMarginsWarning: return "一个或以上的边界超出了打印范围.是否继续？";
                case PreviewStringId.Msg_WrongPageSettings: return "打印机不支持所选的纸张大小. 是否继续打印？";
                case PreviewStringId.Msg_WrongPrinter: return "无效的打印机名称.请检查打印机的设置是否正确.";
                case PreviewStringId.PageInfo_PageDate: return "[Date Printed]";
                case PreviewStringId.PageInfo_PageNumber: return "[Page #]";
                case PreviewStringId.PageInfo_PageNumberOfTotal: return "[Page # of Pages #]";
                case PreviewStringId.PageInfo_PageTime: return "[Time Printed]";
                case PreviewStringId.PageInfo_PageUserName: return "[User Name]";
                case PreviewStringId.PreviewForm_Caption: return "预览";
                case PreviewStringId.SaveDlg_FilterBmp: return "BMP Bitmap Format";
                case PreviewStringId.SaveDlg_FilterCsv: return "CSV文件";
                case PreviewStringId.SaveDlg_FilterGif: return "GIF Graphics Interchange Format";
                case PreviewStringId.SaveDlg_FilterHtm: return "HTML文件";
                case PreviewStringId.SaveDlg_FilterJpeg: return "JPEG File Interchange Format";
                case PreviewStringId.SaveDlg_FilterMht: return "MHT文件";
                case PreviewStringId.SaveDlg_FilterPdf: return "PDF文件";
                case PreviewStringId.SaveDlg_FilterPng: return "PNG Portable Network Graphics Format";
                case PreviewStringId.SaveDlg_FilterRtf: return "RTF文件";
                case PreviewStringId.SaveDlg_FilterTiff: return "TIFF Tag Image File Format";
                case PreviewStringId.SaveDlg_FilterTxt: return "TXT文件";
                case PreviewStringId.SaveDlg_FilterWmf: return "WMF Windows Metafile";
                case PreviewStringId.SaveDlg_FilterXls: return "Excel文件";
                case PreviewStringId.SaveDlg_Title: return "另存为";
               // case PreviewStringId.SB_PageOfPages: return "目前页码:";
                case PreviewStringId.SB_PageInfo: return "{0}/{1}";
                case PreviewStringId.SB_PageNone: return "无";
               // case PreviewStringId.SB_PageOfPagesHint: return "总页码:";
                case PreviewStringId.SB_ZoomFactor: return "缩放系数:";
                case PreviewStringId.ScrollingInfo_Page: return "页";
                case PreviewStringId.TB_TTip_Backgr: return "背景色";
                case PreviewStringId.TB_TTip_Close: return "退出";
                case PreviewStringId.TB_TTip_Customize: return "自定义";
                case PreviewStringId.TB_TTip_EditPageHF: return "页眉页脚";
                case PreviewStringId.TB_TTip_Export: return "导出文件";
                case PreviewStringId.TB_TTip_FirstPage: return "首页";
                case PreviewStringId.TB_TTip_HandTool: return "手掌工具";
                case PreviewStringId.TB_TTip_LastPage: return "尾页";
                case PreviewStringId.TB_TTip_Magnifier: return "放大/缩小";
                case PreviewStringId.TB_TTip_Map: return "文档视图";
                case PreviewStringId.TB_TTip_MultiplePages: return "多页";
                case PreviewStringId.TB_TTip_NextPage: return "下一页";
                case PreviewStringId.TB_TTip_PageSetup: return "页面设置";
                case PreviewStringId.TB_TTip_PreviousPage: return "上一页";
                case PreviewStringId.TB_TTip_Print: return "打印";
                case PreviewStringId.TB_TTip_PrintDirect: return "直接打印";
                case PreviewStringId.TB_TTip_Search: return "搜索";
                case PreviewStringId.TB_TTip_Send: return "发送E-Mail";
                case PreviewStringId.TB_TTip_Watermark: return "水印";
                case PreviewStringId.TB_TTip_Zoom: return "缩放";
                case PreviewStringId.TB_TTip_ZoomIn: return "放大";
                case PreviewStringId.TB_TTip_ZoomOut: return "缩小";
                case PreviewStringId.WMForm_Direction_BackwardDiagonal: return "反向倾斜";
                case PreviewStringId.WMForm_Direction_ForwardDiagonal: return "正向倾斜";
                case PreviewStringId.WMForm_Direction_Horizontal: return "横向";
                case PreviewStringId.WMForm_Direction_Vertical: return "纵向";
                case PreviewStringId.WMForm_HorzAlign_Center: return "置中";
                case PreviewStringId.WMForm_HorzAlign_Left: return "靠左";
                case PreviewStringId.WMForm_HorzAlign_Right: return "靠右";
                case PreviewStringId.WMForm_ImageClip: return "剪辑";
                case PreviewStringId.WMForm_ImageStretch: return "伸展";
                case PreviewStringId.WMForm_ImageZoom: return "缩放";
                case PreviewStringId.WMForm_PageRangeRgrItem_All: return "全部";
                case PreviewStringId.WMForm_PageRangeRgrItem_Pages: return "页码";
                case PreviewStringId.WMForm_PictureDlg_Title: return "选择图片";
                case PreviewStringId.WMForm_VertAlign_Bottom: return "底端";
                case PreviewStringId.WMForm_VertAlign_Middle: return "中间";
                case PreviewStringId.WMForm_VertAlign_Top: return "顶端";
                case PreviewStringId.WMForm_Watermark_Asap: return "ASAP";
                case PreviewStringId.WMForm_Watermark_Confidential: return "CONFIDENTIAL";
                case PreviewStringId.WMForm_Watermark_Copy: return "COPY";
                case PreviewStringId.WMForm_Watermark_DoNotCopy: return "DO NOT COPY";
                case PreviewStringId.WMForm_Watermark_Draft: return "DRAFT";
                case PreviewStringId.WMForm_Watermark_Evaluation: return "EVALUATION";
                case PreviewStringId.WMForm_Watermark_Original: return "ORIGINAL";
                case PreviewStringId.WMForm_Watermark_Personal: return "PERSONAL";
                case PreviewStringId.WMForm_Watermark_Sample: return "SAMPLE";
                case PreviewStringId.WMForm_Watermark_TopSecret: return "TOP SECRET";
                case PreviewStringId.WMForm_Watermark_Urgent: return "URGENT";
                case PreviewStringId.WMForm_ZOrderRgrItem_Behind: return "在后面";
                case PreviewStringId.WMForm_ZOrderRgrItem_InFront: return "在前面";
            }
            return base.GetLocalizedString(id);
        }
    }


    public class XtraGridLocalizer_zh_chs : DevExpress.XtraGrid.Localization.GridLocalizer
    {
        public override string Language
        {
            get
            {
                return DevExpressLocalizerHelper.Language;
            }
        }
        public override string GetLocalizedString(DevExpress.XtraGrid.Localization.GridStringId id)
        {
            switch (id)
            {
                case GridStringId.FileIsNotFoundError: return "文件{0}找不到";
                case GridStringId.ColumnViewExceptionMessage: return " 要修正当前值吗?";
                case GridStringId.CustomizationCaption: return "自定义";
                case GridStringId.CustomizationColumns: return "列";
                case GridStringId.CustomizationBands: return "带宽";
                case GridStringId.PopupFilterAll: return "(全部)";
                case GridStringId.PopupFilterCustom: return "(自定义)";
                case GridStringId.PopupFilterBlanks: return "(空白)";
                case GridStringId.PopupFilterNonBlanks: return "(无空白)";
                case GridStringId.CustomFilterDialogFormCaption: return "用户自定义自动过滤器";
                case GridStringId.CustomFilterDialogCaption: return "显示符合下列条件的行:";
                case GridStringId.CustomFilterDialogRadioAnd: return "与(&A)";
                case GridStringId.CustomFilterDialogRadioOr: return "或(&O)";
                case GridStringId.CustomFilterDialogOkButton: return "确定(&O)";
                case GridStringId.CustomFilterDialogClearFilter: return "清除过滤器(&L)";
                case GridStringId.CustomFilterDialogCancelButton: return "取消(&C)";
                case GridStringId.CustomFilterDialog2FieldCheck: return "字段";
   
                case GridStringId.MenuFooterSum: return "和";
                case GridStringId.MenuFooterMin: return "最小值";
                case GridStringId.MenuFooterMax: return "最大值";
                case GridStringId.MenuFooterCount: return "计数";
                case GridStringId.MenuFooterAverage: return "平均值";
                case GridStringId.MenuFooterNone: return "无";
                case GridStringId.MenuFooterSumFormat: return "和={0:#.##}";
                case GridStringId.MenuFooterMinFormat: return "最小值={0}";
                case GridStringId.MenuFooterMaxFormat: return "最大值={0}";
                case GridStringId.MenuFooterCountFormat: return "{0}";
                case GridStringId.MenuFooterCountGroupFormat: return "计数={0}";
                case GridStringId.MenuFooterAverageFormat: return "平均={0:#.##}";
                case GridStringId.MenuFooterCustomFormat: return "统计值={0}";
                case GridStringId.MenuColumnSortAscending: return "升序排列";
                case GridStringId.MenuColumnSortDescending: return "降序排列";
                case GridStringId.MenuColumnClearSorting: return "清除排序设置";
                case GridStringId.MenuColumnGroup: return "根据此列分组";
                case GridStringId.FilterPanelCustomizeButton: return "自定义";
                case GridStringId.MenuColumnUnGroup: return "不分组";
                case GridStringId.MenuColumnColumnCustomization: return "列选择";
                case GridStringId.MenuColumnBestFit: return "最佳匹配";
                case GridStringId.MenuColumnFilter: return "允许筛选数据";
                case GridStringId.MenuColumnFilterEditor: return "设定数据筛选条件";
                case GridStringId.MenuColumnClearFilter: return "清除过滤器";
                case GridStringId.MenuColumnBestFitAllColumns: return "最佳匹配(所有列)";
                case GridStringId.MenuGroupPanelFullExpand: return "全部展开";
                case GridStringId.MenuGroupPanelFullCollapse: return "全部收合";
                case GridStringId.MenuGroupPanelClearGrouping: return "清除分组";
                case GridStringId.PrintDesignerBandedView: return "打印设置 (Banded View)";
                case GridStringId.PrintDesignerGridView: return "打印设置(网格视图)";
                case GridStringId.PrintDesignerCardView: return "打印设置(卡视图)";
                case GridStringId.PrintDesignerBandHeader: return "起始带宽";
                case GridStringId.PrintDesignerDescription: return "为当前视图设置不同的打印选项";
                case GridStringId.MenuColumnGroupBox: return "分组依据框";
                case GridStringId.CardViewNewCard: return "新建卡";
                case GridStringId.CardViewQuickCustomizationButton: return "自定义";
                case GridStringId.CardViewQuickCustomizationButtonFilter: return "过滤器　";
                case GridStringId.CardViewQuickCustomizationButtonSort: return "排序方式:";
                case GridStringId.GridGroupPanelText: return "拖动列标题至此,根据该列分组";
                case GridStringId.GridNewRowText: return "在此处添加一行";
                case GridStringId.FilterBuilderOkButton: return "确定(&O)";
                case GridStringId.FilterBuilderCancelButton: return "取消(&C)";
                case GridStringId.FilterBuilderApplyButton: return "应用(&A)";
                case GridStringId.FilterBuilderCaption: return "数据筛选条件设定：";
                case GridStringId.GridOutlookIntervals: return "更早;上个月;三周之前;两周之前;上周;;;;;;;;昨天;今天;明天;;;;;;;;下周;两周后;三周后;下个月;一个月之后;";
                case GridStringId.CustomFilterDialogEmptyValue:  return "(请输入)";
                case GridStringId.CustomFilterDialogEmptyOperator: return "--请选择--";
            
            
            }
         
            return base.GetLocalizedString(id);
        }
    }

    public class XtraEditorLocalizer_zh_chs : DevExpress.XtraEditors.Controls.Localizer
    {
        public override string Language
        {
            get
            {
                return DevExpressLocalizerHelper.Language;
            }
        }

        public override string GetLocalizedString(DevExpress.XtraEditors.Controls.StringId id)
        {
            switch (id)
            {
                case StringId.PictureEditOpenFileFilter: return ";*.ico;*.位图文件 (*.bmp)|*.bmp|GIF文件 (*.gif)|*.gif|JPEG文件 (*.jpg;*.jpeg)|*.jpg;*.jpeg|Icon 文件 (*.ico)|*.ico|所有图像文件 |*.bmp;*.gif;*.jpg;*.jpeg;*.ico;*.png;*.tif|所有文件 |*.*";
                case StringId.NavigatorNextButtonHint: return "下一个";
                case StringId.ImagePopupPicture: return "(图像)";
                case StringId.TabHeaderButtonNext: return "向右滚动";
                case StringId.TabHeaderButtonPrev: return "向左滚动";
                case StringId.XtraMessageBoxOkButtonText: return "确定(&O)";
                case StringId.Cancel: return "取消(&C)l";
                case StringId.DateEditToday: return "今天";
                case StringId.DateEditClear: return "清除";
                case StringId.PictureEditMenuCut: return "剪切";
                case StringId.NavigatorEditButtonHint: return "编辑";
                case StringId.TextEditMenuCut: return "剪切(&t)";
                case StringId.ImagePopupEmpty: return "(空)";
                case StringId.NavigatorNextPageButtonHint: return "下一页";
                case StringId.NavigatorTextStringFormat: return "记录 {0} of {1}";
                case StringId.CaptionError: return "错误";
                case StringId.XtraMessageBoxNoButtonText: return "否(&N)";
                case StringId.PictureEditOpenFileTitle: return "打开";
                case StringId.PictureEditOpenFileError: return "错误的图像格式";
                case StringId.XtraMessageBoxIgnoreButtonText: return "忽略(&I)";
                case StringId.NavigatorRemoveButtonHint: return "删除";
                case StringId.TabHeaderButtonClose: return "关闭";
                case StringId.CheckUnchecked: return "非校验";
                case StringId.PictureEditSaveFileFilter: return "位图文件 (*.bmp)|*.bmp|GIF文件 (*.gif)|*.gif|JPEG 文件 (*.jpg)|*.jpg";
                case StringId.TextEditMenuSelectAll: return "全选(&A)";
                case StringId.PictureEditSaveFileTitle: return "另存为";
                case StringId.DataEmpty: return "没有图像数据";
                case StringId.XtraMessageBoxAbortButtonText: return "中断(&A)";
                case StringId.CheckIndeterminate: return "不确定";
                case StringId.NavigatorLastButtonHint: return "最后一个";
                case StringId.TextEditMenuCopy: return "复制(&C)";
                case StringId.TextEditMenuUndo: return "撤销(&U)";
                case StringId.CalcError: return "计算错误";
                case StringId.CalcButtonBack: return "后退";
                case StringId.CalcButtonSqrt: return "平方根";
                case StringId.LookUpColumnDefaultName: return "名称";
                case StringId.NavigatorEndEditButtonHint: return "结束编辑";
                case StringId.NotValidArrayLength: return "无效的数组长度。";
                case StringId.ColorTabWeb: return "网页";
                case StringId.PictureEditMenuSave: return "保存";
                case StringId.PictureEditMenuCopy: return "复制";
                case StringId.PictureEditMenuLoad: return "调用";
                case StringId.NavigatorFirstButtonHint: return "第一个";
                case StringId.MaskBoxValidateError: return @"输入值不完整,是否修正?
	
	
	是 - 返回编辑器,修正该值.
	否 -保留该值.
	取消 - 重设为原来的值.";
                case StringId.UnknownPictureFormat: return "未知的图形格式";
                case StringId.NavigatorPreviousPageButtonHint: return "前一页";
                case StringId.XtraMessageBoxRetryButtonText: return "重试(&R)";
                case StringId.LookUpEditValueIsNull: return "[编辑值为空]";
                case StringId.CalcButtonC: return "C";
                case StringId.XtraMessageBoxCancelButtonText: return "取消(&C)l";
                case StringId.LookUpInvalidEditValueType: return "无效的 LookUpEdit 编辑值类型。";
                case StringId.NavigatorAppendButtonHint: return "追加";
                case StringId.CalcButtonMx: return "M+";
                case StringId.CalcButtonMC: return "MC";
                case StringId.CalcButtonMS: return "MS";
                case StringId.CalcButtonMR: return "MR";
                case StringId.CalcButtonCE: return "CE";
                case StringId.NavigatorCancelEditButtonHint: return "取消编辑";
                case StringId.PictureEditOpenFileErrorCaption: return "打开错误";
                case StringId.OK: return "确定(&O)";
                case StringId.CheckChecked: return "校验";
                case StringId.TextEditMenuPaste: return "粘贴(&P)";
                case StringId.TextEditMenuDelete: return "删除(&D)";
                case StringId.ColorTabSystem: return "系统";
                case StringId.PictureEditMenuPaste: return "粘贴";
                case StringId.XtraMessageBoxYesButtonText: return "是(&Y)";
                case StringId.InvalidValueText: return "无效值";
                case StringId.PictureEditMenuDelete: return "删除";
                case StringId.NavigatorPreviousButtonHint: return "前一个";
                case StringId.ColorTabCustom: return "自定义";
                case StringId.FilterGroupAnd: return "与";
                case StringId.FilterClauseEquals: return "等于";
                case StringId.FilterEmptyEnter: return "(请输入)";
                case StringId.FilterToolTipNodeAdd: return "在组中添加一个新的条件";
                case StringId.FilterToolTipKeysAdd: return "用于插入或添加可以关键字";


                case StringId.FilterClauseDoesNotEqual: return "不等于空";
                case StringId.FilterClauseGreater: return "大于";
                case StringId.FilterClauseGreaterOrEqual: return "大于等于";
                case StringId.FilterClauseLess: return "小于";
                case StringId.FilterClauseLessOrEqual: return "小于等于";
                case StringId.FilterClauseBetween: return "包含范围";
                case StringId.FilterClauseNotBetween: return "不包含范围";
                case StringId.FilterClauseIsNull: return "空";
                case StringId.FilterClauseIsNotNull: return "非空";
                case StringId.FilterClauseAnyOf: return "位于";
                case StringId.FilterClauseNoneOf: return "不位于";
                case StringId.FilterToolTipKeysRemove: return "用于删除或减少一个关键字";
                case StringId.FilterToolTipNodeRemove: return "移除这个条件";


                case StringId.FilterGroupOr: return "或者";
                case StringId.FilterGroupNotAnd: return "非与";
                case StringId.FilterGroupNotOr: return "非或";
                case StringId.FilterMenuConditionAdd: return "添加条件";
                case StringId.FilterMenuGroupAdd: return "添加分组";
                case StringId.FilterMenuClearAll: return "清楚所有";

                case StringId.FilterClauseLike: return "包含";
                case StringId.FilterClauseNotLike: return "不包含";
                case StringId.FilterClauseIsNullOrEmpty: return "空或‘’";
                case StringId.FilterClauseIsNotNullOrEmpty: return "非空或‘’";
                case StringId.FilterCriteriaToStringGroupOperatorAnd: return "与";
                case StringId.FilterCriteriaToStringGroupOperatorOr: return "或";
                case StringId.FilterCriteriaToStringUnaryOperatorNot: return "非";
                case StringId.FilterMenuRowRemove: return "移除分组";

                case StringId.FilterClauseBetweenAnd: return "与";
                case StringId.FilterCriteriaToStringUnaryOperatorIsNull: return "为空";
                case StringId.FilterCriteriaToStringIsNotNull: return "不为空";
                case StringId.FilterCriteriaToStringBetween: return "范围";
                case StringId.FilterCriteriaToStringIn: return "在";

                case StringId.FilterClauseContains: return "在其中";
                case StringId.FilterCriteriaToStringBinaryOperatorLike: return "包含";
                case StringId.FilterClauseDoesNotContain: return "不在其中";
                case StringId.FilterClauseBeginsWith: return "开始于";
                case StringId.FilterClauseEndsWith: return "结束于";


                case StringId.FilterCriteriaToStringFunctionContains: return "在其中";
                case StringId.FilterCriteriaToStringFunctionStartsWith: return "开始于";
                case StringId.FilterCriteriaToStringFunctionEndsWith: return "开始于";
                case StringId.FilterCriteriaToStringFunctionIsNullOrEmpty: return "非空或‘’";
                case StringId.FilterCriteriaToStringNotLike: return "不包含";


            }
   
            return base.GetLocalizedString(id);
        }
    }

    public class XtraLayoutLocalizer_zh_chs : DevExpress.XtraLayout.Localization.LayoutLocalizer
    {
        public override string Language
        {
            get
            {
                return DevExpressLocalizerHelper.Language;
            }
        }
        public override string GetLocalizedString(DevExpress.XtraLayout.Localization.LayoutStringId id)
        {
            switch (id)
            {
                case LayoutStringId.CustomizationParentName: return "定制";
                case LayoutStringId.DefaultItemText: return "项目";
                case LayoutStringId.DefaultActionText: return "默认动作";
                case LayoutStringId.DefaultEmptyText: return "无";
                case LayoutStringId.LayoutItemDescription: return "版面设计控制器的项目元素";
                case LayoutStringId.LayoutGroupDescription: return "版面设计控制器的群组元素";
                case LayoutStringId.TabbedGroupDescription: return "版面控制器的群组标签页元素";
                case LayoutStringId.LayoutControlDescription: return "版面控制";
                case LayoutStringId.CustomizationFormTitle: return "定制";
                case LayoutStringId.TreeViewPageTitle: return "版面设计树状视图";
                case LayoutStringId.HiddenItemsPageTitle: return "隐藏项目";
                case LayoutStringId.RenameSelected: return "重命名";
                case LayoutStringId.HideItemMenutext: return "隐藏项目";
                case LayoutStringId.LockItemSizeMenuText: return "锁定项目大小";
                case LayoutStringId.UnLockItemSizeMenuText: return "解除项目大小锁定";
                case LayoutStringId.GroupItemsMenuText: return "群组";
                case LayoutStringId.UnGroupItemsMenuText: return "解除群组设定";
                case LayoutStringId.CreateTabbedGroupMenuText: return "创建群组标签页";
                case LayoutStringId.AddTabMenuText: return "增加标签页";
                case LayoutStringId.UnGroupTabbedGroupMenuText: return "解除群组标签页设定";
                case LayoutStringId.TreeViewRootNodeName: return "最上层";
                case LayoutStringId.ShowCustomizationFormMenuText: return "定制版面";
                case LayoutStringId.HideCustomizationFormMenuText: return "隐藏定制表格";
                case LayoutStringId.EmptySpaceItemDefaultText: return "空白区域项目";
                case LayoutStringId.SplitterItemDefaultText: return "分隔器版面設計控制器的群組標籤頁項目";
                case LayoutStringId.ControlGroupDefaultText: return "群组";
                case LayoutStringId.EmptyRootGroupText: return "在这里放置控件";
                case LayoutStringId.EmptyTabbedGroupText: return "将群组拖放到群组标签页区域";
                case LayoutStringId.ResetLayoutMenuText: return "重设版面";
                case LayoutStringId.RenameMenuText: return "重命名";
                case LayoutStringId.TextPositionMenuText: return "文本位置";
                case LayoutStringId.TextPositionLeftMenuText: return "左边";
                case LayoutStringId.TextPositionRightMenuText: return "右边";
                case LayoutStringId.TextPositionTopMenuText: return "上方";
                case LayoutStringId.TextPositionBottomMenuText: return "下方";
                case LayoutStringId.ShowTextMenuItem: return "显示文本";
                case LayoutStringId.HideTextMenuItem: return "隐藏文本";
                case LayoutStringId.LockSizeMenuItem: return "锁定大小";
                case LayoutStringId.LockWidthMenuItem: return "锁定宽度";
                case LayoutStringId.CreateEmptySpaceItem: return "创建空白区域项目";
                case LayoutStringId.LockHeightMenuItem: return "锁定高度";
                case LayoutStringId.LockMenuGroup: return "强制限定大小";
                case LayoutStringId.FreeSizingMenuItem: return "允许改变大小";
                case LayoutStringId.ResetConstraintsToDefaultsMenuItem: return "重设为默认值";
            }
  
            return base.GetLocalizedString(id);
        }
    }


}