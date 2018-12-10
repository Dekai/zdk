/**  版本信息模板在安装目录下，可自行修改。
* Audit.cs
*
* 功 能： N/A
* 类 名： Audit
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/7/1 2:29:06   N/A    初版
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
	/// Audit:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Audit
	{
		public Audit()
		{}
		#region Model
		private int _f_id;
		private string _f_name;
		private string _f_content;
		private decimal _f_money;
		private DateTime _f_time;
		private string _f_wf_stateid;
		private int _f_userid;
		private bool _f_isdelete= false;
		private DateTime _f_date;
		private int _f_type=0;
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
		public string F_Name
		{
			set{ _f_name=value;}
			get{return _f_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string F_Content
		{
			set{ _f_content=value;}
			get{return _f_content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal F_Money
		{
			set{ _f_money=value;}
			get{return _f_money;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime F_Time
		{
			set{ _f_time=value;}
			get{return _f_time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string F_WF_StateID
		{
			set{ _f_wf_stateid=value;}
			get{return _f_wf_stateid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int F_UserID
		{
			set{ _f_userid=value;}
			get{return _f_userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool F_IsDelete
		{
			set{ _f_isdelete=value;}
			get{return _f_isdelete;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime F_Date
		{
			set{ _f_date=value;}
			get{return _f_date;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int F_Type
		{
			set{ _f_type=value;}
			get{return _f_type;}
		}
		#endregion Model

	}
}

