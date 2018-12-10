/**  版本信息模板在安装目录下，可自行修改。
* Role_Right_Relation.cs
*
* 功 能： N/A
* 类 名： Role_Right_Relation
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
using Library.DBUtility;//Please add references
namespace Library.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:Role_Right_Relation
	/// </summary>
	public partial class Role_Right_Relation:IRole_Right_Relation
	{
		public Role_Right_Relation()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("F_RoleID", "T_Role_Right_Relation"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int F_RoleID,int F_RightID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Role_Right_Relation");
			strSql.Append(" where F_RoleID=@F_RoleID and F_RightID=@F_RightID ");
			SqlParameter[] parameters = {
					new SqlParameter("@F_RoleID", SqlDbType.Int,4),
					new SqlParameter("@F_RightID", SqlDbType.Int,4)			};
			parameters[0].Value = F_RoleID;
			parameters[1].Value = F_RightID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Library.Model.Role_Right_Relation model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Role_Right_Relation(");
			strSql.Append("F_RoleID,F_RightID)");
			strSql.Append(" values (");
			strSql.Append("@F_RoleID,@F_RightID)");
			SqlParameter[] parameters = {
					new SqlParameter("@F_RoleID", SqlDbType.Int,4),
					new SqlParameter("@F_RightID", SqlDbType.Int,4)};
			parameters[0].Value = model.F_RoleID;
			parameters[1].Value = model.F_RightID;

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
		public bool Update(Library.Model.Role_Right_Relation model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Role_Right_Relation set ");
			strSql.Append("F_RoleID=@F_RoleID,");
			strSql.Append("F_RightID=@F_RightID");
			strSql.Append(" where F_RoleID=@F_RoleID and F_RightID=@F_RightID ");
			SqlParameter[] parameters = {
					new SqlParameter("@F_RoleID", SqlDbType.Int,4),
					new SqlParameter("@F_RightID", SqlDbType.Int,4)};
			parameters[0].Value = model.F_RoleID;
			parameters[1].Value = model.F_RightID;

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
		public bool Delete(int F_RoleID,int F_RightID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_Role_Right_Relation ");
			strSql.Append(" where F_RoleID=@F_RoleID and F_RightID=@F_RightID ");
			SqlParameter[] parameters = {
					new SqlParameter("@F_RoleID", SqlDbType.Int,4),
					new SqlParameter("@F_RightID", SqlDbType.Int,4)			};
			parameters[0].Value = F_RoleID;
			parameters[1].Value = F_RightID;

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
		public Library.Model.Role_Right_Relation GetModel(int F_RoleID,int F_RightID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 F_RoleID,F_RightID from T_Role_Right_Relation ");
			strSql.Append(" where F_RoleID=@F_RoleID and F_RightID=@F_RightID ");
			SqlParameter[] parameters = {
					new SqlParameter("@F_RoleID", SqlDbType.Int,4),
					new SqlParameter("@F_RightID", SqlDbType.Int,4)			};
			parameters[0].Value = F_RoleID;
			parameters[1].Value = F_RightID;

			Library.Model.Role_Right_Relation model=new Library.Model.Role_Right_Relation();
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
		public Library.Model.Role_Right_Relation DataRowToModel(DataRow row)
		{
			Library.Model.Role_Right_Relation model=new Library.Model.Role_Right_Relation();
			if (row != null)
			{
				if(row["F_RoleID"]!=null && row["F_RoleID"].ToString()!="")
				{
					model.F_RoleID=int.Parse(row["F_RoleID"].ToString());
				}
				if(row["F_RightID"]!=null && row["F_RightID"].ToString()!="")
				{
					model.F_RightID=int.Parse(row["F_RightID"].ToString());
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
			strSql.Append("select F_RoleID,F_RightID ");
			strSql.Append(" FROM T_Role_Right_Relation ");
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
			strSql.Append(" F_RoleID,F_RightID ");
			strSql.Append(" FROM T_Role_Right_Relation ");
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
			strSql.Append("select count(1) FROM T_Role_Right_Relation ");
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
				strSql.Append("order by T.F_RightID desc");
			}
			strSql.Append(")AS Row, T.*  from T_Role_Right_Relation T ");
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
			parameters[0].Value = "T_Role_Right_Relation";
			parameters[1].Value = "F_RightID";
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


        public void Delete(int F_RoleID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Role_Right_Relation ");
            strSql.Append(" where F_RoleID=@F_RoleID");
            SqlParameter[] parameters = {
					new SqlParameter("@F_RoleID", SqlDbType.Int,4)	};
            parameters[0].Value = F_RoleID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }



    }
}

