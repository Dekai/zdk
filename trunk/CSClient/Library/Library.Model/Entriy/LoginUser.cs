/**  版本信息模板在安装目录下，可自行修改。
* LoginUser.cs
*
* 功 能： N/A
* 类 名： LoginUser
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/5/16 9:22:29   N/A    初版
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
	/// LoginUser:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class LoginUser
	{
		public LoginUser()
		{}
		#region Model
		private int _f_id;
		private string _f_loginname;
		private string _f_password;
		private int _f_userid;
		private int _f_roleid;
		private int _f_isactive=1;
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
		public string F_LoginName
		{
			set{ _f_loginname=value;}
			get{return _f_loginname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string F_PassWord
		{
			set{ _f_password=value;}
			get{return _f_password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int F_UserID
		{
			set{ _f_userid=value;}
			get{return _f_userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int F_RoleID
		{
			set{ _f_roleid=value;}
			get{return _f_roleid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int F_IsActive
		{
			set{ _f_isactive=value;}
			get{return _f_isactive;}
		}
		#endregion Model

	}
}

