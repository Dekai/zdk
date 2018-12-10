/**  版本信息模板在安装目录下，可自行修改。
* ExpatriateAttendace.cs
*
* 功 能： N/A
* 类 名： ExpatriateAttendace
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/6/25 18:23:20   N/A    初版
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
	/// 数据访问类:ExpatriateAttendace
	/// </summary>
	public partial class ExpatriateAttendace:IExpatriateAttendace
	{
		public ExpatriateAttendace()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("F_ID", "T_ExpatriateAttendace"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int F_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_ExpatriateAttendace");
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
		public int Add(Library.Model.ExpatriateAttendace model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_ExpatriateAttendace(");
			strSql.Append("F_ProjectID,F_AttendanceDate,F_GongTou,F_Worker,F_PaGong,F_Comments,F_OperatorID,F_OperateTime,F_IsDelete)");
			strSql.Append(" values (");
			strSql.Append("@F_ProjectID,@F_AttendanceDate,@F_GongTou,@F_Worker,@F_PaGong,@F_Comments,@F_OperatorID,@F_OperateTime,@F_IsDelete)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@F_ProjectID", SqlDbType.Int,4),
					new SqlParameter("@F_AttendanceDate", SqlDbType.Date,3),
					new SqlParameter("@F_GongTou", SqlDbType.Int,4),
					new SqlParameter("@F_Worker", SqlDbType.Int,4),
					new SqlParameter("@F_PaGong", SqlDbType.Int,4),
					new SqlParameter("@F_Comments", SqlDbType.NVarChar,2000),
					new SqlParameter("@F_OperatorID", SqlDbType.Int,4),
					new SqlParameter("@F_OperateTime", SqlDbType.DateTime),
					new SqlParameter("@F_IsDelete", SqlDbType.Bit,1)};
			parameters[0].Value = model.F_ProjectID;
			parameters[1].Value = model.F_AttendanceDate;
			parameters[2].Value = model.F_GongTou;
			parameters[3].Value = model.F_Worker;
			parameters[4].Value = model.F_PaGong;
			parameters[5].Value = model.F_Comments;
			parameters[6].Value = model.F_OperatorID;
			parameters[7].Value = model.F_OperateTime;
			parameters[8].Value = model.F_IsDelete;

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
		public bool Update(Library.Model.ExpatriateAttendace model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_ExpatriateAttendace set ");
			strSql.Append("F_ProjectID=@F_ProjectID,");
			strSql.Append("F_AttendanceDate=@F_AttendanceDate,");
			strSql.Append("F_GongTou=@F_GongTou,");
			strSql.Append("F_Worker=@F_Worker,");
			strSql.Append("F_PaGong=@F_PaGong,");
			strSql.Append("F_Comments=@F_Comments,");
			strSql.Append("F_OperatorID=@F_OperatorID,");
			strSql.Append("F_OperateTime=@F_OperateTime,");
			strSql.Append("F_IsDelete=@F_IsDelete");
			strSql.Append(" where F_ID=@F_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@F_ProjectID", SqlDbType.Int,4),
					new SqlParameter("@F_AttendanceDate", SqlDbType.Date,3),
					new SqlParameter("@F_GongTou", SqlDbType.Int,4),
					new SqlParameter("@F_Worker", SqlDbType.Int,4),
					new SqlParameter("@F_PaGong", SqlDbType.Int,4),
					new SqlParameter("@F_Comments", SqlDbType.NVarChar,2000),
					new SqlParameter("@F_OperatorID", SqlDbType.Int,4),
					new SqlParameter("@F_OperateTime", SqlDbType.DateTime),
					new SqlParameter("@F_IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@F_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.F_ProjectID;
			parameters[1].Value = model.F_AttendanceDate;
			parameters[2].Value = model.F_GongTou;
			parameters[3].Value = model.F_Worker;
			parameters[4].Value = model.F_PaGong;
			parameters[5].Value = model.F_Comments;
			parameters[6].Value = model.F_OperatorID;
			parameters[7].Value = model.F_OperateTime;
			parameters[8].Value = model.F_IsDelete;
			parameters[9].Value = model.F_ID;

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
			strSql.Append("delete from T_ExpatriateAttendace ");
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
			strSql.Append("delete from T_ExpatriateAttendace ");
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
		public Library.Model.ExpatriateAttendace GetModel(int F_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 F_ID,F_ProjectID,F_AttendanceDate,F_GongTou,F_Worker,F_PaGong,F_Comments,F_OperatorID,F_OperateTime,F_IsDelete from T_ExpatriateAttendace ");
			strSql.Append(" where F_ID=@F_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@F_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = F_ID;

			Library.Model.ExpatriateAttendace model=new Library.Model.ExpatriateAttendace();
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
		public Library.Model.ExpatriateAttendace DataRowToModel(DataRow row)
		{
			Library.Model.ExpatriateAttendace model=new Library.Model.ExpatriateAttendace();
			if (row != null)
			{
				if(row["F_ID"]!=null && row["F_ID"].ToString()!="")
				{
					model.F_ID=int.Parse(row["F_ID"].ToString());
				}
				if(row["F_ProjectID"]!=null && row["F_ProjectID"].ToString()!="")
				{
					model.F_ProjectID=int.Parse(row["F_ProjectID"].ToString());
				}
				if(row["F_AttendanceDate"]!=null && row["F_AttendanceDate"].ToString()!="")
				{
					model.F_AttendanceDate=DateTime.Parse(row["F_AttendanceDate"].ToString());
				}
				if(row["F_GongTou"]!=null && row["F_GongTou"].ToString()!="")
				{
					model.F_GongTou=int.Parse(row["F_GongTou"].ToString());
				}
				if(row["F_Worker"]!=null && row["F_Worker"].ToString()!="")
				{
					model.F_Worker=int.Parse(row["F_Worker"].ToString());
				}
				if(row["F_PaGong"]!=null && row["F_PaGong"].ToString()!="")
				{
					model.F_PaGong=int.Parse(row["F_PaGong"].ToString());
				}
				if(row["F_Comments"]!=null)
				{
					model.F_Comments=row["F_Comments"].ToString();
				}
				if(row["F_OperatorID"]!=null && row["F_OperatorID"].ToString()!="")
				{
					model.F_OperatorID=int.Parse(row["F_OperatorID"].ToString());
				}
				if(row["F_OperateTime"]!=null && row["F_OperateTime"].ToString()!="")
				{
					model.F_OperateTime=DateTime.Parse(row["F_OperateTime"].ToString());
				}
				if(row["F_IsDelete"]!=null && row["F_IsDelete"].ToString()!="")
				{
					if((row["F_IsDelete"].ToString()=="1")||(row["F_IsDelete"].ToString().ToLower()=="true"))
					{
						model.F_IsDelete=true;
					}
					else
					{
						model.F_IsDelete=false;
					}
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
			strSql.Append("select F_ID,F_ProjectID,F_AttendanceDate,F_GongTou,F_Worker,F_PaGong,F_Comments,F_OperatorID,F_OperateTime,F_IsDelete ");
			strSql.Append(" FROM T_ExpatriateAttendace ");
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
			strSql.Append(" F_ID,F_ProjectID,F_AttendanceDate,F_GongTou,F_Worker,F_PaGong,F_Comments,F_OperatorID,F_OperateTime,F_IsDelete ");
			strSql.Append(" FROM T_ExpatriateAttendace ");
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
			strSql.Append("select count(1) FROM T_ExpatriateAttendace ");
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
			strSql.Append(")AS Row, T.*  from T_ExpatriateAttendace T ");
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
			parameters[0].Value = "T_ExpatriateAttendace";
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
	}
}

