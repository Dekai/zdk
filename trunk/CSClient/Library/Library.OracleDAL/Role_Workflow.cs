/**  版本信息模板在安装目录下，可自行修改。
* Role_Workflow.cs
*
* 功 能： N/A
* 类 名： Role_Workflow
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/7/1 3:09:50   N/A    初版
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
	/// 数据访问类:Role_Workflow
	/// </summary>
	public partial class Role_Workflow:IRole_Workflow
	{
		public Role_Workflow()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("F_RoleID", "T_Role_Workflow"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int F_RoleID,int F_WFID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Role_Workflow");
			strSql.Append(" where F_RoleID=@F_RoleID and F_WFID=@F_WFID ");
			SqlParameter[] parameters = {
					new SqlParameter("@F_RoleID", SqlDbType.Int,4),
					new SqlParameter("@F_WFID", SqlDbType.Int,4)			};
			parameters[0].Value = F_RoleID;
			parameters[1].Value = F_WFID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Library.Model.Role_Workflow model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Role_Workflow(");
			strSql.Append("F_RoleID,F_WFID)");
			strSql.Append(" values (");
			strSql.Append("@F_RoleID,@F_WFID)");
			SqlParameter[] parameters = {
					new SqlParameter("@F_RoleID", SqlDbType.Int,4),
					new SqlParameter("@F_WFID", SqlDbType.Int,4)};
			parameters[0].Value = model.F_RoleID;
			parameters[1].Value = model.F_WFID;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(Library.Model.Role_Workflow model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Role_Workflow set ");
#warning 系统发现缺少更新的字段，请手工确认如此更新是否正确！ 
			strSql.Append("F_RoleID=@F_RoleID,");
			strSql.Append("F_WFID=@F_WFID");
			strSql.Append(" where F_RoleID=@F_RoleID and F_WFID=@F_WFID ");
			SqlParameter[] parameters = {
					new SqlParameter("@F_RoleID", SqlDbType.Int,4),
					new SqlParameter("@F_WFID", SqlDbType.Int,4)};
			parameters[0].Value = model.F_RoleID;
			parameters[1].Value = model.F_WFID;

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
		public bool Delete(int F_RoleID,int F_WFID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Role_Workflow ");
			strSql.Append(" where F_RoleID=@F_RoleID and F_WFID=@F_WFID ");
			SqlParameter[] parameters = {
					new SqlParameter("@F_RoleID", SqlDbType.Int,4),
					new SqlParameter("@F_WFID", SqlDbType.Int,4)			};
			parameters[0].Value = F_RoleID;
			parameters[1].Value = F_WFID;

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


        public void Delete(int F_RoleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Role_Workflow ");
            strSql.Append(" where F_RoleID=@F_RoleID ");
            SqlParameter[] parameters = {
					new SqlParameter("@F_RoleID", SqlDbType.Int,4)		};
            parameters[0].Value = F_RoleID;
         
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
       
        }



		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Library.Model.Role_Workflow GetModel(int F_RoleID,int F_WFID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 F_RoleID,F_WFID from T_Role_Workflow ");
			strSql.Append(" where F_RoleID=@F_RoleID and F_WFID=@F_WFID ");
			SqlParameter[] parameters = {
					new SqlParameter("@F_RoleID", SqlDbType.Int,4),
					new SqlParameter("@F_WFID", SqlDbType.Int,4)			};
			parameters[0].Value = F_RoleID;
			parameters[1].Value = F_WFID;

			Library.Model.Role_Workflow model=new Library.Model.Role_Workflow();
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
		public Library.Model.Role_Workflow DataRowToModel(DataRow row)
		{
			Library.Model.Role_Workflow model=new Library.Model.Role_Workflow();
			if (row != null)
			{
				if(row["F_RoleID"]!=null && row["F_RoleID"].ToString()!="")
				{
					model.F_RoleID=int.Parse(row["F_RoleID"].ToString());
				}
				if(row["F_WFID"]!=null && row["F_WFID"].ToString()!="")
				{
					model.F_WFID=int.Parse(row["F_WFID"].ToString());
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
			strSql.Append("select F_RoleID,F_WFID ");
			strSql.Append(" FROM T_Role_Workflow ");
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
			strSql.Append(" F_RoleID,F_WFID ");
			strSql.Append(" FROM T_Role_Workflow ");
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
			strSql.Append("select count(1) FROM T_Role_Workflow ");
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
				strSql.Append("order by T.F_WFID desc");
			}
			strSql.Append(")AS Row, T.*  from T_Role_Workflow T ");
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
			parameters[0].Value = "T_Role_Workflow";
			parameters[1].Value = "F_WFID";
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


   
    }
}

