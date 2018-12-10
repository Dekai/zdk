/**  版本信息模板在安装目录下，可自行修改。
* ProjectCost.cs
*
* 功 能： N/A
* 类 名： ProjectCost
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/6/26 0:16:32   N/A    初版
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
	/// ProjectCost:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ProjectCost
	{
		public ProjectCost()
		{}
		#region Model
		private int _f_id;
		private int _f_projectid;
		private bool _f_isprojectcost= true;
		private int _f_costtype;
		private decimal _f_costamount;
		private string _f_othercost;
		private DateTime _f_costdate;
		private int _f_operatorid;
		private DateTime _f_operatetime;
		private bool _f_isdelete;
		private string _f_costdescription;
		private int? _f_applyid;
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
		public bool F_IsProjectCost
		{
			set{ _f_isprojectcost=value;}
			get{return _f_isprojectcost;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int F_CostType
		{
			set{ _f_costtype=value;}
			get{return _f_costtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal F_CostAmount
		{
			set{ _f_costamount=value;}
			get{return _f_costamount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string F_OtherCost
		{
			set{ _f_othercost=value;}
			get{return _f_othercost;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime F_CostDate
		{
			set{ _f_costdate=value;}
			get{return _f_costdate;}
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
		public string F_CostDescription
		{
			set{ _f_costdescription=value;}
			get{return _f_costdescription;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? F_ApplyID
		{
			set{ _f_applyid=value;}
			get{return _f_applyid;}
		}
		#endregion Model

	}
}

