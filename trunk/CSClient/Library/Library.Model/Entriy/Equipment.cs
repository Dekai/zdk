/**  版本信息模板在安装目录下，可自行修改。
* Equipment.cs
*
* 功 能： N/A
* 类 名： Equipment
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/5/11 8:49:53   N/A    初版
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
	/// Equipment:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Equipment
	{
		public Equipment()
		{}
		#region Model
		private int _f_id;
		private string _f_name;
        private string _f_decs;
		private int? _f_order;
		private int _f_isdelete=0;
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
		public string F_Decs
		{
			set{ _f_decs=value;}
			get{return _f_decs;}
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
		public int F_IsDelete
		{
			set{ _f_isdelete=value;}
			get{return _f_isdelete;}
		}
		#endregion Model

	}
}

