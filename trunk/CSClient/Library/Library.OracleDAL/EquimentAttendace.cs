/**  版本信息模板在安装目录下，可自行修改。
* EquimentAttendace.cs
*
* 功 能： N/A
* 类 名： EquimentAttendace
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
	/// 数据访问类:EquimentAttendace
	/// </summary>
	public partial class EquimentAttendace:IEquimentAttendace
	{
		public EquimentAttendace()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("F_ID", "T_EquimentAttendace"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int F_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_EquimentAttendace");
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
		public int Add(Library.Model.EquimentAttendace model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_EquimentAttendace(");
			strSql.Append("F_ProjectID,F_IsHired,F_EquimentID,F_EquimentName,F_EquimentCount,F_AttendanceDate,F_OperatorID,F_OperateTime,F_IsDelete,F_Description)");
			strSql.Append(" values (");
			strSql.Append("@F_ProjectID,@F_IsHired,@F_EquimentID,@F_EquimentName,@F_EquimentCount,@F_AttendanceDate,@F_OperatorID,@F_OperateTime,@F_IsDelete,@F_Description)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@F_ProjectID", SqlDbType.Int,4),
					new SqlParameter("@F_IsHired", SqlDbType.Bit,1),
					new SqlParameter("@F_EquimentID", SqlDbType.Int,4),
					new SqlParameter("@F_EquimentName", SqlDbType.NVarChar,200),
					new SqlParameter("@F_EquimentCount", SqlDbType.Int,4),
					new SqlParameter("@F_AttendanceDate", SqlDbType.Date,3),
					new SqlParameter("@F_OperatorID", SqlDbType.Int,4),
					new SqlParameter("@F_OperateTime", SqlDbType.DateTime),
					new SqlParameter("@F_IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@F_Description", SqlDbType.NVarChar,500)};
			parameters[0].Value = model.F_ProjectID;
			parameters[1].Value = model.F_IsHired;
			parameters[2].Value = model.F_EquimentID;
			parameters[3].Value = model.F_EquimentName;
			parameters[4].Value = model.F_EquimentCount;
			parameters[5].Value = model.F_AttendanceDate;
			parameters[6].Value = model.F_OperatorID;
			parameters[7].Value = model.F_OperateTime;
			parameters[8].Value = model.F_IsDelete;
			parameters[9].Value = model.F_Description;

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
		public bool Update(Library.Model.EquimentAttendace model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_EquimentAttendace set ");
			strSql.Append("F_ProjectID=@F_ProjectID,");
			strSql.Append("F_IsHired=@F_IsHired,");
			strSql.Append("F_EquimentID=@F_EquimentID,");
			strSql.Append("F_EquimentName=@F_EquimentName,");
			strSql.Append("F_EquimentCount=@F_EquimentCount,");
			strSql.Append("F_AttendanceDate=@F_AttendanceDate,");
			strSql.Append("F_OperatorID=@F_OperatorID,");
			strSql.Append("F_OperateTime=@F_OperateTime,");
			strSql.Append("F_IsDelete=@F_IsDelete,");
			strSql.Append("F_Description=@F_Description");
			strSql.Append(" where F_ID=@F_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@F_ProjectID", SqlDbType.Int,4),
					new SqlParameter("@F_IsHired", SqlDbType.Bit,1),
					new SqlParameter("@F_EquimentID", SqlDbType.Int,4),
					new SqlParameter("@F_EquimentName", SqlDbType.NVarChar,200),
					new SqlParameter("@F_EquimentCount", SqlDbType.Int,4),
					new SqlParameter("@F_AttendanceDate", SqlDbType.Date,3),
					new SqlParameter("@F_OperatorID", SqlDbType.Int,4),
					new SqlParameter("@F_OperateTime", SqlDbType.DateTime),
					new SqlParameter("@F_IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@F_Description", SqlDbType.NVarChar,500),
					new SqlParameter("@F_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.F_ProjectID;
			parameters[1].Value = model.F_IsHired;
			parameters[2].Value = model.F_EquimentID;
			parameters[3].Value = model.F_EquimentName;
			parameters[4].Value = model.F_EquimentCount;
			parameters[5].Value = model.F_AttendanceDate;
			parameters[6].Value = model.F_OperatorID;
			parameters[7].Value = model.F_OperateTime;
			parameters[8].Value = model.F_IsDelete;
			parameters[9].Value = model.F_Description;
			parameters[10].Value = model.F_ID;

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
			strSql.Append("delete from T_EquimentAttendace ");
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
			strSql.Append("delete from T_EquimentAttendace ");
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
		public Library.Model.EquimentAttendace GetModel(int F_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 F_ID,F_ProjectID,F_IsHired,F_EquimentID,F_EquimentName,F_EquimentCount,F_AttendanceDate,F_OperatorID,F_OperateTime,F_IsDelete,F_Description from T_EquimentAttendace ");
			strSql.Append(" where F_ID=@F_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@F_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = F_ID;

			Library.Model.EquimentAttendace model=new Library.Model.EquimentAttendace();
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
		public Library.Model.EquimentAttendace DataRowToModel(DataRow row)
		{
			Library.Model.EquimentAttendace model=new Library.Model.EquimentAttendace();
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
				if(row["F_IsHired"]!=null && row["F_IsHired"].ToString()!="")
				{
					if((row["F_IsHired"].ToString()=="1")||(row["F_IsHired"].ToString().ToLower()=="true"))
					{
						model.F_IsHired=true;
					}
					else
					{
						model.F_IsHired=false;
					}
				}
				if(row["F_EquimentID"]!=null && row["F_EquimentID"].ToString()!="")
				{
					model.F_EquimentID=int.Parse(row["F_EquimentID"].ToString());
				}
				if(row["F_EquimentName"]!=null)
				{
					model.F_EquimentName=row["F_EquimentName"].ToString();
				}
				if(row["F_EquimentCount"]!=null && row["F_EquimentCount"].ToString()!="")
				{
					model.F_EquimentCount=int.Parse(row["F_EquimentCount"].ToString());
				}
				if(row["F_AttendanceDate"]!=null && row["F_AttendanceDate"].ToString()!="")
				{
					model.F_AttendanceDate=DateTime.Parse(row["F_AttendanceDate"].ToString());
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
				if(row["F_Description"]!=null)
				{
					model.F_Description=row["F_Description"].ToString();
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
			strSql.Append("select F_ID,F_ProjectID,F_IsHired,F_EquimentID,F_EquimentName,F_EquimentCount,F_AttendanceDate,F_OperatorID,F_OperateTime,F_IsDelete,F_Description ");
			strSql.Append(" FROM T_EquimentAttendace ");
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
			strSql.Append(" F_ID,F_ProjectID,F_IsHired,F_EquimentID,F_EquimentName,F_EquimentCount,F_AttendanceDate,F_OperatorID,F_OperateTime,F_IsDelete,F_Description ");
			strSql.Append(" FROM T_EquimentAttendace ");
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
			strSql.Append("select count(1) FROM T_EquimentAttendace ");
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
			strSql.Append(")AS Row, T.*  from T_EquimentAttendace T ");
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
			parameters[0].Value = "T_EquimentAttendace";
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


        public DataTable GetSummer(string projectids, List<string> equipmentlist, string startdate, string enddate)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("  select  p.F_ID, p.F_Name, p.F_StartDate,p.F_EndDate,");
            strSql.Append("  case when p.F_EndDate =null then DATEDIFF(DAY,p.F_StartDate,GETDATE()) else DATEDIFF(DAY,p.F_StartDate,p.F_EndDate) end as daycount");

            foreach (string id in equipmentlist)
            {
                if (id.Equals("0"))
                {

                    strSql.Append("  , sum( case when e.F_EquimentID =" + id + " then e.F_EquimentCount else 0 end ) EquimentID_" + id);
                }
                else
                {
                    strSql.Append("  , sum( case when e.F_EquimentID =" + id + " then 1 else 0 end ) EquimentID_" + id);

                }
            }

            strSql.Append("  from ");
            strSql.Append("  (select * from T_Project where F_ID in (" + projectids + ")) p left join ");
            strSql.Append("  (select * from T_EquimentAttendace where F_IsDelete=0 ");

            if (!string.IsNullOrEmpty(startdate))
            {
                strSql.Append("  and F_AttendanceDate<='" + enddate + "' ");
            }
            if (!string.IsNullOrEmpty(enddate))
            {
                strSql.Append("  and  F_AttendanceDate >='" + startdate + "'");
            }
            strSql.Append("  ) e on p.F_ID = e.F_ProjectID");
            strSql.Append("  group by p.F_ID, p.F_Name, p.F_StartDate,p.F_EndDate");
            
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }
	}
}

