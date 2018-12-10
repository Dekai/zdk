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
	/// 数据访问类:DataDicType
	/// </summary>
	public partial class DataDicType:IDataDicType
	{
		public DataDicType()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string F_TypeCode)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_DataDicType");
			strSql.Append(" where F_TypeCode=@F_TypeCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@F_TypeCode", SqlDbType.VarChar,50)			};
			parameters[0].Value = F_TypeCode;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Library.Model.DataDicType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_DataDicType(");
			strSql.Append("F_TypeCode,F_TypeName)");
			strSql.Append(" values (");
			strSql.Append("@F_TypeCode,@F_TypeName)");
			SqlParameter[] parameters = {
					new SqlParameter("@F_TypeCode", SqlDbType.VarChar,50),
					new SqlParameter("@F_TypeName", SqlDbType.VarChar,50)};
			parameters[0].Value = model.F_TypeCode;
			parameters[1].Value = model.F_TypeName;

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
		public bool Update(Library.Model.DataDicType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_DataDicType set ");
			strSql.Append("F_TypeName=@F_TypeName");
			strSql.Append(" where F_TypeCode=@F_TypeCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@F_TypeName", SqlDbType.VarChar,50),
					new SqlParameter("@F_TypeCode", SqlDbType.VarChar,50)};
			parameters[0].Value = model.F_TypeName;
			parameters[1].Value = model.F_TypeCode;

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
		public bool Delete(string F_TypeCode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_DataDicType ");
			strSql.Append(" where F_TypeCode=@F_TypeCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@F_TypeCode", SqlDbType.VarChar,50)			};
			parameters[0].Value = F_TypeCode;

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
		public bool DeleteList(string F_TypeCodelist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from T_DataDicType ");
			strSql.Append(" where F_TypeCode in ("+F_TypeCodelist + ")  ");
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
		public Library.Model.DataDicType GetModel(string F_TypeCode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 F_TypeCode,F_TypeName from T_DataDicType ");
			strSql.Append(" where F_TypeCode=@F_TypeCode ");
			SqlParameter[] parameters = {
					new SqlParameter("@F_TypeCode", SqlDbType.VarChar,50)			};
			parameters[0].Value = F_TypeCode;

			Library.Model.DataDicType model=new Library.Model.DataDicType();
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
		public Library.Model.DataDicType DataRowToModel(DataRow row)
		{
			Library.Model.DataDicType model=new Library.Model.DataDicType();
			if (row != null)
			{
				if(row["F_TypeCode"]!=null)
				{
					model.F_TypeCode=row["F_TypeCode"].ToString();
				}
				if(row["F_TypeName"]!=null)
				{
					model.F_TypeName=row["F_TypeName"].ToString();
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
			strSql.Append("select F_TypeCode,F_TypeName ");
			strSql.Append(" FROM T_DataDicType ");
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
			strSql.Append(" F_TypeCode,F_TypeName ");
			strSql.Append(" FROM T_DataDicType ");
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
			strSql.Append("select count(1) FROM T_DataDicType ");
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
				strSql.Append("order by T.F_TypeCode desc");
			}
			strSql.Append(")AS Row, T.*  from T_DataDicType T ");
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
			parameters[0].Value = "T_DataDicType";
			parameters[1].Value = "F_TypeCode";
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

