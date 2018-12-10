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
* Copyright (c) 2012 Library Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Library.IDAL;
using Library.DBUtility;//Please add references
namespace Library.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:LoginUser
	/// </summary>
	public partial class LoginUser:ILoginUser
	{
		public LoginUser()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("F_ID", "T_LoginUser"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int F_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_LoginUser");
			strSql.Append(" where F_ID=@F_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@F_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = F_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Library.Model.LoginUser model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_LoginUser(");
			strSql.Append("F_LoginName,F_PassWord,F_UserID,F_RoleID,F_IsActive)");
			strSql.Append(" values (");
			strSql.Append("@F_LoginName,@F_PassWord,@F_UserID,@F_RoleID,@F_IsActive)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@F_LoginName", SqlDbType.VarChar,50),
					new SqlParameter("@F_PassWord", SqlDbType.VarChar,50),
					new SqlParameter("@F_UserID", SqlDbType.Int,4),
					new SqlParameter("@F_RoleID", SqlDbType.Int,4),
					new SqlParameter("@F_IsActive", SqlDbType.Int,4)};
			parameters[0].Value = model.F_LoginName;
			parameters[1].Value = model.F_PassWord;
			parameters[2].Value = model.F_UserID;
			parameters[3].Value = model.F_RoleID;
			parameters[4].Value = model.F_IsActive;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Library.Model.LoginUser model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_LoginUser set ");
			strSql.Append("F_LoginName=@F_LoginName,");
			strSql.Append("F_PassWord=@F_PassWord,");
			strSql.Append("F_UserID=@F_UserID,");
			strSql.Append("F_RoleID=@F_RoleID,");
			strSql.Append("F_IsActive=@F_IsActive");
			strSql.Append(" where F_ID=@F_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@F_LoginName", SqlDbType.VarChar,50),
					new SqlParameter("@F_PassWord", SqlDbType.VarChar,50),
					new SqlParameter("@F_UserID", SqlDbType.Int,4),
					new SqlParameter("@F_RoleID", SqlDbType.Int,4),
					new SqlParameter("@F_IsActive", SqlDbType.Int,4),
					new SqlParameter("@F_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.F_LoginName;
			parameters[1].Value = model.F_PassWord;
			parameters[2].Value = model.F_UserID;
			parameters[3].Value = model.F_RoleID;
			parameters[4].Value = model.F_IsActive;
			parameters[5].Value = model.F_ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int F_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_LoginUser ");
			strSql.Append(" where F_ID=@F_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@F_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = F_ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string F_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_LoginUser ");
			strSql.Append(" where F_ID in ("+F_IDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Library.Model.LoginUser GetModel(int F_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 F_ID,F_LoginName,F_PassWord,F_UserID,F_RoleID,F_IsActive from T_LoginUser ");
			strSql.Append(" where F_ID=@F_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@F_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = F_ID;

			Library.Model.LoginUser model=new Library.Model.LoginUser();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Library.Model.LoginUser DataRowToModel(DataRow row)
		{
			Library.Model.LoginUser model=new Library.Model.LoginUser();
			if (row != null)
			{
				if(row["F_ID"]!=null && row["F_ID"].ToString()!="")
				{
					model.F_ID=int.Parse(row["F_ID"].ToString());
				}
				if(row["F_LoginName"]!=null)
				{
					model.F_LoginName=row["F_LoginName"].ToString();
				}
				if(row["F_PassWord"]!=null)
				{
					model.F_PassWord=row["F_PassWord"].ToString();
				}
				if(row["F_UserID"]!=null && row["F_UserID"].ToString()!="")
				{
					model.F_UserID=int.Parse(row["F_UserID"].ToString());
				}
				if(row["F_RoleID"]!=null && row["F_RoleID"].ToString()!="")
				{
					model.F_RoleID=int.Parse(row["F_RoleID"].ToString());
				}
				if(row["F_IsActive"]!=null && row["F_IsActive"].ToString()!="")
				{
					model.F_IsActive=int.Parse(row["F_IsActive"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select F_ID,F_LoginName,F_PassWord,F_UserID,F_RoleID,F_IsActive ");
			strSql.Append(" FROM T_LoginUser ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" F_ID,F_LoginName,F_PassWord,F_UserID,F_RoleID,F_IsActive ");
			strSql.Append(" FROM T_LoginUser ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM T_LoginUser ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.F_ID desc");
			}
			strSql.Append(")AS Row, T.*  from T_LoginUser T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "T_LoginUser";
			parameters[1].Value = "F_ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod


        public DataTable GetAllLinkList()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select e0.F_Name UserName ,r0.F_Name as RoleName, u0.F_ID,u0.F_LoginName,u0.F_PassWord,u0.F_UserID,u0.F_RoleID,u0.F_IsActive  ,case when u0.F_IsActive=1 then '启用' else '停用' end IsActive");
            strSql.Append(" FROM T_LoginUser u0");
            strSql.Append(" Left join  T_Employee e0 on u0.F_UserID = e0.F_ID");
            strSql.Append(" Left join   T_Role r0 on u0.F_RoleID = r0.F_ID");
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }
    }
}

