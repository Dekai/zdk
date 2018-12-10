/**  版本信息模板在安装目录下，可自行修改。
* EquimentAttendace.cs
*
* 功 能： N/A
* 类 名： EquimentAttendace
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/6/25 18:23:19   N/A    初版
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
	/// EquimentAttendace:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class EquimentAttendace
	{
		public EquimentAttendace()
		{}
		#region Model
		private int _f_id;
		private int _f_projectid;
		private bool _f_ishired= false;
		private int _f_equimentid;
		private string _f_equimentname;
		private int _f_equimentcount;
		private DateTime _f_attendancedate;
		private int _f_operatorid;
		private DateTime _f_operatetime;
		private bool _f_isdelete= false;
		private string _f_description;
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
		public int F_ProjectID
		{
			set{ _f_projectid=value;}
			get{return _f_projectid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool F_IsHired
		{
			set{ _f_ishired=value;}
			get{return _f_ishired;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int F_EquimentID
		{
			set{ _f_equimentid=value;}
			get{return _f_equimentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string F_EquimentName
		{
			set{ _f_equimentname=value;}
			get{return _f_equimentname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int F_EquimentCount
		{
			set{ _f_equimentcount=value;}
			get{return _f_equimentcount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime F_AttendanceDate
		{
			set{ _f_attendancedate=value;}
			get{return _f_attendancedate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int F_OperatorID
		{
			set{ _f_operatorid=value;}
			get{return _f_operatorid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime F_OperateTime
		{
			set{ _f_operatetime=value;}
			get{return _f_operatetime;}
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
		public string F_Description
		{
			set{ _f_description=value;}
			get{return _f_description;}
		}
		#endregion Model

	}
}

