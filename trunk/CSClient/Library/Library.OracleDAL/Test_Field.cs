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
	/// 数据访问类:Test_Field
	/// </summary>
	public partial class Test_Field:ITest_Field
	{
		public Test_Field()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("F_ID", "T_Test_Field"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int F_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Test_Field");
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
		public int Add(Library.Model.Test_Field model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Test_Field(");
			strSql.Append("F_PID,F_RowIndex,F_ColIndex,F_Value)");
			strSql.Append(" values (");
			strSql.Append("@F_PID,@F_RowIndex,@F_ColIndex,@F_Value)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@F_PID", SqlDbType.Int,4),
					new SqlParameter("@F_RowIndex", SqlDbType.Int,4),
					new SqlParameter("@F_ColIndex", SqlDbType.Int,4),
					new SqlParameter("@F_Value", SqlDbType.VarChar,500)};
			parameters[0].Value = model.F_PID;
			parameters[1].Value = model.F_RowIndex;
			parameters[2].Value = model.F_ColIndex;
			parameters[3].Value = model.F_Value;

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
		public bool Update(Library.Model.Test_Field model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Test_Field set ");
			strSql.Append("F_PID=@F_PID,");
			strSql.Append("F_RowIndex=@F_RowIndex,");
			strSql.Append("F_ColIndex=@F_ColIndex,");
			strSql.Append("F_Value=@F_Value");
			strSql.Append(" where F_ID=@F_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@F_PID", SqlDbType.Int,4),
					new SqlParameter("@F_RowIndex", SqlDbType.Int,4),
					new SqlParameter("@F_ColIndex", SqlDbType.Int,4),
					new SqlParameter("@F_Value", SqlDbType.VarChar,500),
					new SqlParameter("@F_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.F_PID;
			parameters[1].Value = model.F_RowIndex;
			parameters[2].Value = model.F_ColIndex;
			parameters[3].Value = model.F_Value;
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
			strSql.Append("delete from T_Test_Field ");
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
			strSql.Append("delete from T_Test_Field ");
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
		public Library.Model.Test_Field GetModel(int F_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 F_ID,F_PID,F_RowIndex,F_ColIndex,F_Value from T_Test_Field ");
			strSql.Append(" where F_ID=@F_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@F_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = F_ID;

			Library.Model.Test_Field model=new Library.Model.Test_Field();
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
		public Library.Model.Test_Field DataRowToModel(DataRow row)
		{
			Library.Model.Test_Field model=new Library.Model.Test_Field();
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
				if(row["F_RowIndex"]!=null && row["F_RowIndex"].ToString()!="")
				{
					model.F_RowIndex=int.Parse(row["F_RowIndex"].ToString());
				}
				if(row["F_ColIndex"]!=null && row["F_ColIndex"].ToString()!="")
				{
					model.F_ColIndex=int.Parse(row["F_ColIndex"].ToString());
				}
				if(row["F_Value"]!=null)
				{
					model.F_Value=row["F_Value"].ToString();
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
			strSql.Append("select F_ID,F_PID,F_RowIndex,F_ColIndex,F_Value ");
			strSql.Append(" FROM T_Test_Field ");
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
			strSql.Append(" F_ID,F_PID,F_RowIndex,F_ColIndex,F_Value ");
			strSql.Append(" FROM T_Test_Field ");
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
			strSql.Append("select count(1) FROM T_Test_Field ");
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
			strSql.Append(")AS Row, T.*  from T_Test_Field T ");
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
			parameters[0].Value = "T_Test_Field";
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


        public void DeleteByPid(int p)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_Test_Field ");
            strSql.Append(" where F_PID=@F_PID");
            SqlParameter[] parameters = {
					new SqlParameter("@F_PID", SqlDbType.Int,4)
			};
            parameters[0].Value = p;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
    }
}

