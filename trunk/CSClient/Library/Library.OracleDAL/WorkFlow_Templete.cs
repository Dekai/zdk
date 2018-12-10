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
	/// 数据访问类:WorkFlow_Templete
	/// </summary>
	public partial class WorkFlow_Templete:IWorkFlow_Templete
	{
		public WorkFlow_Templete()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string F_LinkTask,string F_StateID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_WorkFlow_Templete");
			strSql.Append(" where F_LinkTask=@F_LinkTask and F_StateID=@F_StateID ");
			SqlParameter[] parameters = {
					new SqlParameter("@F_LinkTask", SqlDbType.VarChar,50),
					new SqlParameter("@F_StateID", SqlDbType.VarChar,50)			};
			parameters[0].Value = F_LinkTask;
			parameters[1].Value = F_StateID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Library.Model.WorkFlow_Templete model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_WorkFlow_Templete(");
			strSql.Append("F_LinkTask,F_StateID,F_StateName,F_StateType,F_Next_StateID,F_Back_StateID)");
			strSql.Append(" values (");
			strSql.Append("@F_LinkTask,@F_StateID,@F_StateName,@F_StateType,@F_Next_StateID,@F_Back_StateID)");
			SqlParameter[] parameters = {
					new SqlParameter("@F_LinkTask", SqlDbType.VarChar,50),
					new SqlParameter("@F_StateID", SqlDbType.VarChar,50),
					new SqlParameter("@F_StateName", SqlDbType.VarChar,50),
					new SqlParameter("@F_StateType", SqlDbType.Int,4),
					new SqlParameter("@F_Next_StateID", SqlDbType.VarChar,50),
					new SqlParameter("@F_Back_StateID", SqlDbType.VarChar,50)};
			parameters[0].Value = model.F_LinkTask;
			parameters[1].Value = model.F_StateID;
			parameters[2].Value = model.F_StateName;
			parameters[3].Value = model.F_StateType;
			parameters[4].Value = model.F_Next_StateID;
			parameters[5].Value = model.F_Back_StateID;

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
		public bool Update(Library.Model.WorkFlow_Templete model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_WorkFlow_Templete set ");
			strSql.Append("F_StateName=@F_StateName,");
			strSql.Append("F_StateType=@F_StateType,");
			strSql.Append("F_Next_StateID=@F_Next_StateID,");
			strSql.Append("F_Back_StateID=@F_Back_StateID");
			strSql.Append(" where F_LinkTask=@F_LinkTask and F_StateID=@F_StateID ");
			SqlParameter[] parameters = {
					new SqlParameter("@F_StateName", SqlDbType.VarChar,50),
					new SqlParameter("@F_StateType", SqlDbType.Int,4),
					new SqlParameter("@F_Next_StateID", SqlDbType.VarChar,50),
					new SqlParameter("@F_Back_StateID", SqlDbType.VarChar,50),
					new SqlParameter("@F_LinkTask", SqlDbType.VarChar,50),
					new SqlParameter("@F_StateID", SqlDbType.VarChar,50)};
			parameters[0].Value = model.F_StateName;
			parameters[1].Value = model.F_StateType;
			parameters[2].Value = model.F_Next_StateID;
			parameters[3].Value = model.F_Back_StateID;
			parameters[4].Value = model.F_LinkTask;
			parameters[5].Value = model.F_StateID;

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
		public bool Delete(string F_LinkTask,string F_StateID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_WorkFlow_Templete ");
			strSql.Append(" where F_LinkTask=@F_LinkTask and F_StateID=@F_StateID ");
			SqlParameter[] parameters = {
					new SqlParameter("@F_LinkTask", SqlDbType.VarChar,50),
					new SqlParameter("@F_StateID", SqlDbType.VarChar,50)			};
			parameters[0].Value = F_LinkTask;
			parameters[1].Value = F_StateID;

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
		/// 得到一个对象实体
		/// </summary>
		public Library.Model.WorkFlow_Templete GetModel(string F_LinkTask,string F_StateID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 F_LinkTask,F_StateID,F_StateName,F_StateType,F_Next_StateID,F_Back_StateID from T_WorkFlow_Templete ");
			strSql.Append(" where F_LinkTask=@F_LinkTask and F_StateID=@F_StateID ");
			SqlParameter[] parameters = {
					new SqlParameter("@F_LinkTask", SqlDbType.VarChar,50),
					new SqlParameter("@F_StateID", SqlDbType.VarChar,50)			};
			parameters[0].Value = F_LinkTask;
			parameters[1].Value = F_StateID;

			Library.Model.WorkFlow_Templete model=new Library.Model.WorkFlow_Templete();
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
		public Library.Model.WorkFlow_Templete DataRowToModel(DataRow row)
		{
			Library.Model.WorkFlow_Templete model=new Library.Model.WorkFlow_Templete();
			if (row != null)
			{
				if(row["F_LinkTask"]!=null)
				{
					model.F_LinkTask=row["F_LinkTask"].ToString();
				}
				if(row["F_StateID"]!=null)
				{
					model.F_StateID=row["F_StateID"].ToString();
				}
				if(row["F_StateName"]!=null)
				{
					model.F_StateName=row["F_StateName"].ToString();
				}
				if(row["F_StateType"]!=null && row["F_StateType"].ToString()!="")
				{
					model.F_StateType=int.Parse(row["F_StateType"].ToString());
				}
				if(row["F_Next_StateID"]!=null)
				{
					model.F_Next_StateID=row["F_Next_StateID"].ToString();
				}
				if(row["F_Back_StateID"]!=null)
				{
					model.F_Back_StateID=row["F_Back_StateID"].ToString();
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
			strSql.Append("select F_LinkTask,F_StateID,F_StateName,F_StateType,F_Next_StateID,F_Back_StateID ");
			strSql.Append(" FROM T_WorkFlow_Templete ");
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
			strSql.Append(" F_LinkTask,F_StateID,F_StateName,F_StateType,F_Next_StateID,F_Back_StateID ");
			strSql.Append(" FROM T_WorkFlow_Templete ");
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
			strSql.Append("select count(1) FROM T_WorkFlow_Templete ");
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
				strSql.Append("order by T.F_StateID desc");
			}
			strSql.Append(")AS Row, T.*  from T_WorkFlow_Templete T ");
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
			parameters[0].Value = "T_WorkFlow_Templete";
			parameters[1].Value = "F_StateID";
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


        public string GetStartState(string wflinktable)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select F_StateID ");
            strSql.Append(" FROM T_WorkFlow_Templete ");
            strSql.Append(" where F_LinkTask='" + wflinktable + "' and F_StateType=0");
            return DbHelperSQL.GetSingle(strSql.ToString()).ToString();
        }

        public Library.Model.WorkFlow_Templete GetCurrentModel(string wflinktable, string stateid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM T_WorkFlow_Templete ");
            strSql.Append(" where F_LinkTask='" + wflinktable + "' and F_StateID='" + stateid + "'");
             DataTable dt= DbHelperSQL.Query(strSql.ToString()).Tables[0];
             if (dt.Rows.Count > 0)
             {
                 return DataRowToModel(dt.Rows[0]);
             }
             return null;
        }


        public string GetNextState(string wflinktable,string stateid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM T_WorkFlow_Templete ");
            strSql.Append(" where F_LinkTask='" + wflinktable + "' and F_StateType='" + stateid+"'");
            return DbHelperSQL.GetSingle(strSql.ToString()).ToString();
        }

        public string GetBackState(string wflinktable, string stateid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM T_WorkFlow_Templete ");
            strSql.Append(" where F_LinkTask='" + wflinktable + "' and F_StateType='" + stateid + "'");
            return DbHelperSQL.GetSingle(strSql.ToString()).ToString();
        }


        public string GetNextState(string wflinktable)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select F_Next_StateID ");
            strSql.Append(" FROM T_WorkFlow_Templete ");
            strSql.Append(" where F_LinkTask='" + wflinktable + "' and F_StateType=0");
            return DbHelperSQL.GetSingle(strSql.ToString()).ToString();
        }


        public System.Collections.Generic.List<string> GetLinkTask()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select distinct F_LinkTask");
            strSql.Append(" FROM T_WorkFlow_Templete ");
           DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];
           System.Collections.Generic.List<string> l = new System.Collections.Generic.List<string>();
           foreach (DataRow row in dt.Rows)
           {
               l.Add(row[0].ToString());

           }
           return l;

        }
    }
}

