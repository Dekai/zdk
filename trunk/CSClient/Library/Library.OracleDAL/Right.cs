/**  版本信息模板在安装目录下，可自行修改。
* Right.cs
*
* 功 能： N/A
* 类 名： Right
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/5/16 9:22:30   N/A    初版
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
using Library.DBUtility;
using System.Collections.Generic;//Please add references
namespace Library.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:Right
	/// </summary>
	public partial class Right:IRight
	{
		public Right()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("F_ID", "T_Right"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int F_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Right");
			strSql.Append(" where F_ID=@F_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@F_ID", SqlDbType.Int,4)			};
			parameters[0].Value = F_ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Library.Model.Right model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Right(");
			strSql.Append("F_PID,F_Name,F_Code,F_Order)");
			strSql.Append(" values (");
			strSql.Append("@F_PID,@F_Name,@F_Code,@F_Order)");
			SqlParameter[] parameters = {
					new SqlParameter("@F_PID", SqlDbType.Int,4),
					new SqlParameter("@F_Name", SqlDbType.VarChar,150),
					new SqlParameter("@F_Code", SqlDbType.VarChar,50),
					new SqlParameter("@F_Order", SqlDbType.Int,4)};
		
			parameters[0].Value = model.F_PID;
			parameters[1].Value = model.F_Name;
			parameters[2].Value = model.F_Code;
			parameters[3].Value = model.F_Order;

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
		public bool Update(Library.Model.Right model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Right set ");
			strSql.Append("F_PID=@F_PID,");
			strSql.Append("F_Name=@F_Name,");
			strSql.Append("F_Code=@F_Code,");
			strSql.Append("F_Order=@F_Order");
			strSql.Append(" where F_ID=@F_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@F_PID", SqlDbType.Int,4),
					new SqlParameter("@F_Name", SqlDbType.VarChar,150),
					new SqlParameter("@F_Code", SqlDbType.VarChar,50),
					new SqlParameter("@F_Order", SqlDbType.Int,4),
					new SqlParameter("@F_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.F_PID;
			parameters[1].Value = model.F_Name;
			parameters[2].Value = model.F_Code;
			parameters[3].Value = model.F_Order;
			parameters[4].Value = model.F_ID;

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
			strSql.Append("delete from T_Right ");
			strSql.Append(" where F_ID=@F_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@F_ID", SqlDbType.Int,4)			};
			parameters[0].Value = F_ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
            {
                string sql = "delete  from T_Role_Right_Relation where F_RoleID not in (select F_ID from T_Role) or F_RightID not in (select F_ID from T_Right)";
                DbHelperSQL.ExecuteSql(sql);
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
			strSql.Append("delete from T_Right ");
			strSql.Append(" where F_ID in ("+F_IDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
            {
                string sql = "delete  from T_Role_Right_Relation where F_RoleID not in (select F_ID from T_Role) or F_RightID not in (select F_ID from T_Right)";
                DbHelperSQL.ExecuteSql(sql);
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
		public Library.Model.Right GetModel(int F_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 F_ID,F_PID,F_Name,F_Code,F_Order from T_Right ");
			strSql.Append(" where F_ID=@F_ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@F_ID", SqlDbType.Int,4)			};
			parameters[0].Value = F_ID;

			Library.Model.Right model=new Library.Model.Right();
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
		public Library.Model.Right DataRowToModel(DataRow row)
		{
			Library.Model.Right model=new Library.Model.Right();
			if (row != null)
			{
				if(row["F_ID"]!=null && row["F_ID"].ToString()!="")
				{
					model.F_ID=int.Parse(row["F_ID"].ToString());
				}
				if(row["F_PID"]!=null && row["F_PID"].ToString()!="")
				{
					model.F_PID=int.Parse(row["F_PID"].ToString());
				}
				if(row["F_Name"]!=null)
				{
					model.F_Name=row["F_Name"].ToString();
				}
				if(row["F_Code"]!=null)
				{
					model.F_Code=row["F_Code"].ToString();
				}
				if(row["F_Order"]!=null && row["F_Order"].ToString()!="")
				{
					model.F_Order=int.Parse(row["F_Order"].ToString());
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
			strSql.Append("select F_ID,F_PID,F_Name,F_Code,F_Order ");
			strSql.Append(" FROM T_Right ");
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
			strSql.Append(" F_ID,F_PID,F_Name,F_Code,F_Order ");
			strSql.Append(" FROM T_Right ");
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
			strSql.Append("select count(1) FROM T_Right ");
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
			strSql.Append(")AS Row, T.*  from T_Right T ");
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
			parameters[0].Value = "T_Right";
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


        public DataSet GetAllList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select p.F_Name as F_PName, r.F_ID,r.F_PID,r.F_Name,r.F_Code,r.F_Order ");
            strSql.Append(" FROM T_Right r");
            strSql.Append("  left join T_Right p on r.F_PID = p.F_ID order by r.F_Order");
            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<string> GetCodeList(int userid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("  SELECT [F_ID],[F_PID],[F_Name],[F_Code] ,[F_Order]");
            strSql.Append(" FROM [PITCH].[dbo].[T_Right] r");
            strSql.Append(" inner join (select * from T_Role_Right_Relation where F_RoleID=" + userid + ") f on r.f_id=f.F_RightID ");
            DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            List<string> l = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                l.Add(row["F_Code"].ToString());
            }
            return l;
        }
    }
}

