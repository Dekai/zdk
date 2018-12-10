/**  版本信息模板在安装目录下，可自行修改。
* EmployeeAttendace.cs
*
* 功 能： N/A
* 类 名： EmployeeAttendace
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
	/// EmployeeAttendace:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class EmployeeAttendace
	{
		public EmployeeAttendace()
		{}
		#region Model
		private int _f_id;
		private int _f_projectid;
		private int _f_employeeid;
		private bool _f_isattendence= true;
		private DateTime _f_attendancedate;
		private string _f_abencecomment;
		private int _f_operatorid;
		private DateTime _f_operatetime;
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
		public int F_EmployeeID
		{
			set{ _f_employeeid=value;}
			get{return _f_employeeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool F_IsAttendence
		{
			set{ _f_isattendence=value;}
			get{return _f_isattendence;}
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
		public string F_AbenceComment
		{
			set{ _f_abencecomment=value;}
			get{return _f_abencecomment;}
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
		#endregion Model

	}
}

