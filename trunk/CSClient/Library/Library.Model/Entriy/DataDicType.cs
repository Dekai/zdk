/**  版本信息模板在安装目录下，可自行修改。
* DataDicType.cs
*
* 功 能： N/A
* 类 名： DataDicType
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
	/// DataDicType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DataDicType
	{
		public DataDicType()
		{}
		#region Model
		private string _f_typecode;
		private string _f_typename;
		/// <summary>
		/// 
		/// </summary>
		public string F_TypeCode
		{
			set{ _f_typecode=value;}
			get{return _f_typecode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string F_TypeName
		{
			set{ _f_typename=value;}
			get{return _f_typename;}
		}
		#endregion Model

	}
}

