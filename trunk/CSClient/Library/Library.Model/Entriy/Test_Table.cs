/**  版本信息模板在安装目录下，可自行修改。
* Test_Table.cs
*
* 功 能： N/A
* 类 名： Test_Table
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/5/21 11:19:55   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Library.Model
{
	/// <summary>
	/// Test_Table:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Test_Table
	{
		public Test_Table()
		{}
		#region Model
		private int _f_id;
		private int? _f_templeteid;
		private DateTime? _f_time;
		private string _f_bannercontent;
		private int _f_isshow=1;
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
		public int? F_TempleteID
		{
			set{ _f_templeteid=value;}
			get{return _f_templeteid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? F_Time
		{
			set{ _f_time=value;}
			get{return _f_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string F_BannerContent
		{
			set{ _f_bannercontent=value;}
			get{return _f_bannercontent;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int F_IsShow
		{
			set{ _f_isshow=value;}
			get{return _f_isshow;}
		}
		#endregion Model

	}
}

