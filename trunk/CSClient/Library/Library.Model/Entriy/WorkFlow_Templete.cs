/**  版本信息模板在安装目录下，可自行修改。
* WorkFlow_Templete.cs
*
* 功 能： N/A
* 类 名： WorkFlow_Templete
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/5/18 15:07:14   N/A    初版
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
	/// WorkFlow_Templete:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class WorkFlow_Templete
	{
		public WorkFlow_Templete()
		{}
		#region Model
		private string _f_linktask;
		private string _f_stateid;
		private string _f_statename;
		private int? _f_statetype;
		private string _f_next_stateid;
		private string _f_back_stateid;
		/// <summary>
		/// 
		/// </summary>
		public string F_LinkTask
		{
			set{ _f_linktask=value;}
			get{return _f_linktask;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string F_StateID
		{
			set{ _f_stateid=value;}
			get{return _f_stateid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string F_StateName
		{
			set{ _f_statename=value;}
			get{return _f_statename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? F_StateType
		{
			set{ _f_statetype=value;}
			get{return _f_statetype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string F_Next_StateID
		{
			set{ _f_next_stateid=value;}
			get{return _f_next_stateid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string F_Back_StateID
		{
			set{ _f_back_stateid=value;}
			get{return _f_back_stateid;}
		}
		#endregion Model

	}
}

