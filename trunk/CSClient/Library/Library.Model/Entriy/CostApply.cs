/**  版本信息模板在安装目录下，可自行修改。
* CostApply.cs
*
* 功 能： N/A
* 类 名： CostApply
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/6/26 0:16:33   N/A    初版
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
	/// CostApply:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class CostApply
	{
		public CostApply()
		{}
		#region Model
		private int _f_id;
		private string _f_applytitle;
		private int _f_projectid;
		private int _f_applytype=1;
		private decimal _f_applyamount;
		private DateTime _f_applydate;
		private int _f_operatorid;
		private DateTime _f_operatetime;
		private bool _f_isdelete;
		private string _f_applydescription;
		private int _f_wf_stateid=0;
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
		public string F_ApplyTitle
		{
			set{ _f_applytitle=value;}
			get{return _f_applytitle;}
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
		public int F_ApplyType
		{
			set{ _f_applytype=value;}
			get{return _f_applytype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal F_ApplyAmount
		{
			set{ _f_applyamount=value;}
			get{return _f_applyamount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime F_ApplyDate
		{
			set{ _f_applydate=value;}
			get{return _f_applydate;}
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
		public string F_ApplyDescription
		{
			set{ _f_applydescription=value;}
			get{return _f_applydescription;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int F_WF_StateID
		{
			set{ _f_wf_stateid=value;}
			get{return _f_wf_stateid;}
		}
		#endregion Model

	}
}

