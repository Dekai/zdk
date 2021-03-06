﻿/**  版本信息模板在安装目录下，可自行修改。
* Right.cs
*
* 功 能： N/A
* 类 名： Right
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/5/16 9:22:30   N/A    初版
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
	/// Right:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Right
	{
		public Right()
		{}
		#region Model
		private int _f_id;
		private int? _f_pid;
		private string _f_name;
		private string _f_code;
		private int? _f_order;
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
		public int? F_PID
		{
			set{ _f_pid=value;}
			get{return _f_pid;}
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
		public string F_Code
		{
			set{ _f_code=value;}
			get{return _f_code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? F_Order
		{
			set{ _f_order=value;}
			get{return _f_order;}
		}
		#endregion Model

	}
}

