/**  版本信息模板在安装目录下，可自行修改。
* EmployeeAttendace.cs
*
* 功 能： N/A
* 类 名： EmployeeAttendace
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/6/25 18:23:19   N/A    初版
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
	/// 数据访问类:EmployeeAttendace
	/// </summary>
	public partial class EmployeeAttendace:IEmployeeAttendace
	{
		public EmployeeAttendace()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("F_ID", "T_EmployeeAttendace"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int F_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_EmployeeAttendace");
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
		public int Add(Library.Model.EmployeeAttendace model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_EmployeeAttendace(");
			strSql.Append("F_ProjectID,F_EmployeeID,F_IsAttendence,F_AttendanceDate,F_AbenceComment,F_OperatorID,F_OperateTime)");
			strSql.Append(" values (");
			strSql.Append("@F_ProjectID,@F_EmployeeID,@F_IsAttendence,@F_AttendanceDate,@F_AbenceComment,@F_OperatorID,@F_OperateTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@F_ProjectID", SqlDbType.Int,4),
					new SqlParameter("@F_EmployeeID", SqlDbType.Int,4),
					new SqlParameter("@F_IsAttendence", SqlDbType.Bit,1),
					new SqlParameter("@F_AttendanceDate", SqlDbType.Date,3),
					new SqlParameter("@F_AbenceComment", SqlDbType.NVarChar,2000),
					new SqlParameter("@F_OperatorID", SqlDbType.Int,4),
					new SqlParameter("@F_OperateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.F_ProjectID;
			parameters[1].Value = model.F_EmployeeID;
			parameters[2].Value = model.F_IsAttendence;
			parameters[3].Value = model.F_AttendanceDate;
			parameters[4].Value = model.F_AbenceComment;
			parameters[5].Value = model.F_OperatorID;
			parameters[6].Value = model.F_OperateTime;

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
		public bool Update(Library.Model.EmployeeAttendace model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_EmployeeAttendace set ");
			strSql.Append("F_ProjectID=@F_ProjectID,");
			strSql.Append("F_EmployeeID=@F_EmployeeID,");
			strSql.Append("F_IsAttendence=@F_IsAttendence,");
			strSql.Append("F_AttendanceDate=@F_AttendanceDate,");
			strSql.Append("F_AbenceComment=@F_AbenceComment,");
			strSql.Append("F_OperatorID=@F_OperatorID,");
			strSql.Append("F_OperateTime=@F_OperateTime");
			strSql.Append(" where F_ID=@F_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@F_ProjectID", SqlDbType.Int,4),
					new SqlParameter("@F_EmployeeID", SqlDbType.Int,4),
					new SqlParameter("@F_IsAttendence", SqlDbType.Bit,1),
					new SqlParameter("@F_AttendanceDate", SqlDbType.Date,3),
					new SqlParameter("@F_AbenceComment", SqlDbType.NVarChar,2000),
					new SqlParameter("@F_OperatorID", SqlDbType.Int,4),
					new SqlParameter("@F_OperateTime", SqlDbType.DateTime),
					new SqlParameter("@F_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.F_ProjectID;
			parameters[1].Value = model.F_EmployeeID;
			parameters[2].Value = model.F_IsAttendence;
			parameters[3].Value = model.F_AttendanceDate;
			parameters[4].Value = model.F_AbenceComment;
			parameters[5].Value = model.F_OperatorID;
			parameters[6].Value = model.F_OperateTime;
			parameters[7].Value = model.F_ID;

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
			strSql.Append("delete from T_EmployeeAttendace ");
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
			strSql.Append("delete from T_EmployeeAttendace ");
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
		public Library.Model.EmployeeAttendace GetModel(int F_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 F_ID,F_ProjectID,F_EmployeeID,F_IsAttendence,F_AttendanceDate,F_AbenceComment,F_OperatorID,F_OperateTime from T_EmployeeAttendace ");
			strSql.Append(" where F_ID=@F_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@F_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = F_ID;

			Library.Model.EmployeeAttendace model=new Library.Model.EmployeeAttendace();
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
		public Library.Model.EmployeeAttendace DataRowToModel(DataRow row)
		{
			Library.Model.EmployeeAttendace model=new Library.Model.EmployeeAttendace();
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
				if(row["F_EmployeeID"]!=null && row["F_EmployeeID"].ToString()!="")
				{
					model.F_EmployeeID=int.Parse(row["F_EmployeeID"].ToString());
				}
				if(row["F_IsAttendence"]!=null && row["F_IsAttendence"].ToString()!="")
				{
					if((row["F_IsAttendence"].ToString()=="1")||(row["F_IsAttendence"].ToString().ToLower()=="true"))
					{
						model.F_IsAttendence=true;
					}
					else
					{
						model.F_IsAttendence=false;
					}
				}
				if(row["F_AttendanceDate"]!=null && row["F_AttendanceDate"].ToString()!="")
				{
					model.F_AttendanceDate=DateTime.Parse(row["F_AttendanceDate"].ToString());
				}
				if(row["F_AbenceComment"]!=null)
				{
					model.F_AbenceComment=row["F_AbenceComment"].ToString();
				}
				if(row["F_OperatorID"]!=null && row["F_OperatorID"].ToString()!="")
				{
					model.F_OperatorID=int.Parse(row["F_OperatorID"].ToString());
				}
				if(row["F_OperateTime"]!=null && row["F_OperateTime"].ToString()!="")
				{
					model.F_OperateTime=DateTime.Parse(row["F_OperateTime"].ToString());
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
			strSql.Append("select F_ID,F_ProjectID,F_EmployeeID,F_IsAttendence,F_AttendanceDate,F_AbenceComment,F_OperatorID,F_OperateTime ");
			strSql.Append(" FROM T_EmployeeAttendace ");
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
			strSql.Append(" F_ID,F_ProjectID,F_EmployeeID,F_IsAttendence,F_AttendanceDate,F_AbenceComment,F_OperatorID,F_OperateTime ");
			strSql.Append(" FROM T_EmployeeAttendace ");
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
			strSql.Append("select count(1) FROM T_EmployeeAttendace ");
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
			strSql.Append(")AS Row, T.*  from T_EmployeeAttendace T ");
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
			parameters[0].Value = "T_EmployeeAttendace";
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



        public DataTable GetSummer(string projectids,string startdate,string enddate)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select p.F_ID, p.F_Name, p.F_StartDate,p.F_EndDate, ");
            strSql.Append(" case when p.F_EndDate =null then DATEDIFF(DAY,p.F_StartDate,GETDATE()) else DATEDIFF(DAY,p.F_StartDate,p.F_EndDate) end as daycount, ");
            strSql.Append(" empcount,sum(e.F_GongTou) GongTou,sum(e.F_Worker) Worker,sum(e.F_PaGong) PaGong from ");
            strSql.Append(" (select p.F_ID, p.F_Name, p.F_StartDate,p.F_EndDate,count(a.F_EmployeeID) empcount from ");
            strSql.Append(" ( select * from T_Project where F_ID in (" + projectids + ")) p  left join ");
            strSql.Append(" (SELECT *");
            strSql.Append("  FROM [PITCH].[dbo].[T_EmployeeAttendace] where [F_IsAttendence]=1 ");

            if (!string.IsNullOrEmpty(enddate))
            strSql.Append(" and [F_AttendanceDate] <='" + enddate + "'");

            if (!string.IsNullOrEmpty(startdate))
            strSql.Append(" and  [F_AttendanceDate] >='" + startdate + "'");

            strSql.Append("    ) a on a.F_ProjectID =p.F_ID ");
            strSql.Append(" group by p.F_ID, p.F_Name, p.F_StartDate,p.F_EndDate) p");
            strSql.Append(" left join  ");
            strSql.Append(" (select F_GongTou,F_Worker,F_PaGong,F_ProjectID from T_ExpatriateAttendace where F_IsDelete=0  ");
            if (!string.IsNullOrEmpty(enddate))
            strSql.Append(" and F_AttendanceDate<='" + enddate + "'");
            if (!string.IsNullOrEmpty(startdate))
            strSql.Append(" and  [F_AttendanceDate] >='" + startdate + "'");

            strSql.Append("     ) e on e.F_ProjectID =p.F_ID ");
            strSql.Append("  group by p.F_ID, p.F_Name, p.F_StartDate,p.F_EndDate,empcount");
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];

        }
	}
}

