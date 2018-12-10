/**  版本信息模板在安装目录下，可自行修改。
* Test_Field.cs
*
* 功 能： N/A
* 类 名： Test_Field
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/5/20 9:49:02   N/A    初版
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
	/// Test_Field:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Test_Field
	{
		public Test_Field()
		{}
		#region Model
		private int _f_id;
		private int? _f_pid;
		private int? _f_rowindex;
		private int _f_colindex;
		private string _f_value;
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
		public int? F_RowIndex
		{
			set{ _f_rowindex=value;}
			get{return _f_rowindex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int F_ColIndex
		{
			set{ _f_colindex=value;}
			get{return _f_colindex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string F_Value
		{
			set{ _f_value=value;}
			get{return _f_value;}
		}
		#endregion Model

	}
}

