/**  版本信息模板在安装目录下，可自行修改。
* Test_Table_Templete.cs
*
* 功 能： N/A
* 类 名： Test_Table_Templete
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/5/20 16:58:00   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Windows.Media;
namespace Library.Model
{
	/// <summary>
	/// Test_Table_Templete:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Test_Table_Templete
	{
		public Test_Table_Templete()
		{}
		#region Model
		private int _f_id;
		private int? _f_typeid;
		private string _f_name;
		private int? _f_rowcount;
		private int? _f_colunmcount;
		private string _f_banner;
		private int? _f_order;
		private int? _f_showwidth;
		private int? _f_showheight;
		private int? _f_showfontsize;
		private int? _f_definewidth;
		private int? _f_defineheight;
		private int? _f_definefontsize;
		private string _f_showbordercolor;
		private string _f_showfontcolor;
		private string _f_showbackcolor;
		/// <summary>
		/// 
		/// </summary>
		public int F_ID
		{
			set{ _f_id=value;}
			get{return _f_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? F_TypeID
		{
			set{ _f_typeid=value;}
			get{return _f_typeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string F_Name
		{
			set{ _f_name=value;}
			get{return _f_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? F_RowCount
		{
			set{ _f_rowcount=value;}
			get{return _f_rowcount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? F_ColunmCount
		{
			set{ _f_colunmcount=value;}
			get{return _f_colunmcount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string F_Banner
		{
			set{ _f_banner=value;}
			get{return _f_banner;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? F_Order
		{
			set{ _f_order=value;}
			get{return _f_order;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? F_ShowWidth
		{
			set{ _f_showwidth=value;}
			get{return _f_showwidth;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? F_ShowHeight
		{
			set{ _f_showheight=value;}
			get{return _f_showheight;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? F_ShowFontSize
		{
			set{ _f_showfontsize=value;}
			get{return _f_showfontsize;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? F_DefineWidth
		{
			set{ _f_definewidth=value;}
			get{return _f_definewidth;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? F_DefineHeight
		{
			set{ _f_defineheight=value;}
			get{return _f_defineheight;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? F_DefineFontSize
		{
			set{ _f_definefontsize=value;}
			get{return _f_definefontsize;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string F_ShowBorderColor
		{
			set{ _f_showbordercolor=value;}
			get{return _f_showbordercolor;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string F_ShowFontColor
		{
			set{ _f_showfontcolor=value;}
			get{return _f_showfontcolor;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string F_ShowBackColor
		{
			set{ _f_showbackcolor=value;}
			get{return _f_showbackcolor;}
		}


        /// <summary>
        /// 
        /// </summary>
        public Color ShowBorderColor
        {
            get
            {
                string[] colors = F_ShowBorderColor.Split(',');
                return Color.FromArgb(byte.Parse(colors[0]), byte.Parse(colors[1]), byte.Parse(colors[2]), byte.Parse(colors[3]));
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public Color ShowFontColor
        {

            get
            {
                string[] colors = F_ShowFontColor.Split(',');
                return Color.FromArgb(byte.Parse(colors[0]), byte.Parse(colors[1]), byte.Parse(colors[2]), byte.Parse(colors[3]));
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public Color ShowBackColor
        {

            get
            {
                string[] colors = F_ShowBackColor.Split(',');
                return Color.FromArgb(byte.Parse(colors[0]), byte.Parse(colors[1]), byte.Parse(colors[2]), byte.Parse(colors[3]));
            }
        }
		#endregion Model

	}
}

