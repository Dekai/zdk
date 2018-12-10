/**  版本信息模板在安装目录下，可自行修改。
* UploadImages.cs
*
* 功 能： N/A
* 类 名： UploadImages
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/6/24 18:24:12   N/A    初版
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
	/// UploadImages:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class UploadImages
	{
		public UploadImages()
		{}
		#region Model
		private int _f_id;
		private int _f_accidentid;
		private string _f_imagepath;
		private bool _f_isdelete= false;
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
		public int F_AccidentID
		{
			set{ _f_accidentid=value;}
			get{return _f_accidentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string F_ImagePath
		{
			set{ _f_imagepath=value;}
			get{return _f_imagepath;}
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
		public DateTime F_OperateTime
		{
			set{ _f_operatetime=value;}
			get{return _f_operatetime;}
		}
		#endregion Model

	}
}

