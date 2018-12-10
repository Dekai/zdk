/**  版本信息模板在安装目录下，可自行修改。
* Accident.cs
*
* 功 能： N/A
* 类 名： Accident
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/6/24 16:29:45   N/A    初版
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
	/// 数据访问类:Accident
	/// </summary>
	public partial class Accident:IAccident
	{
		public Accident()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("F_ID", "T_Accident"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int F_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Accident");
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
		public int Add(Library.Model.Accident model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Accident(");
			strSql.Append("F_ProjectID,F_AccidentName,F_Description,F_AccidentDate,F_OperatorID,F_OperateTime,F_IsDelete)");
			strSql.Append(" values (");
			strSql.Append("@F_ProjectID,@F_AccidentName,@F_Description,@F_AccidentDate,@F_OperatorID,@F_OperateTime,@F_IsDelete)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@F_ProjectID", SqlDbType.Int,4),
					new SqlParameter("@F_AccidentName", SqlDbType.NVarChar,200),
					new SqlParameter("@F_Description", SqlDbType.NVarChar,2000),
					new SqlParameter("@F_AccidentDate", SqlDbType.Date,3),
					new SqlParameter("@F_OperatorID", SqlDbType.Int,4),
					new SqlParameter("@F_OperateTime", SqlDbType.DateTime),
					new SqlParameter("@F_IsDelete", SqlDbType.Bit,1)};
			parameters[0].Value = model.F_ProjectID;
			parameters[1].Value = model.F_AccidentName;
			parameters[2].Value = model.F_Description;
			parameters[3].Value = model.F_AccidentDate;
			parameters[4].Value = model.F_OperatorID;
			parameters[5].Value = model.F_OperateTime;
			parameters[6].Value = model.F_IsDelete;

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
		public bool Update(Library.Model.Accident model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Accident set ");
			strSql.Append("F_ProjectID=@F_ProjectID,");
			strSql.Append("F_AccidentName=@F_AccidentName,");
			strSql.Append("F_Description=@F_Description,");
			strSql.Append("F_AccidentDate=@F_AccidentDate,");
			strSql.Append("F_OperatorID=@F_OperatorID,");
			strSql.Append("F_OperateTime=@F_OperateTime,");
			strSql.Append("F_IsDelete=@F_IsDelete");
			strSql.Append(" where F_ID=@F_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@F_ProjectID", SqlDbType.Int,4),
					new SqlParameter("@F_AccidentName", SqlDbType.NVarChar,200),
					new SqlParameter("@F_Description", SqlDbType.NVarChar,2000),
					new SqlParameter("@F_AccidentDate", SqlDbType.Date,3),
					new SqlParameter("@F_OperatorID", SqlDbType.Int,4),
					new SqlParameter("@F_OperateTime", SqlDbType.DateTime),
					new SqlParameter("@F_IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@F_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.F_ProjectID;
			parameters[1].Value = model.F_AccidentName;
			parameters[2].Value = model.F_Description;
			parameters[3].Value = model.F_AccidentDate;
			parameters[4].Value = model.F_OperatorID;
			parameters[5].Value = model.F_OperateTime;
			parameters[6].Value = model.F_IsDelete;
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
			strSql.Append("delete from T_Accident ");
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
			strSql.Append("delete from T_Accident ");
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
		public Library.Model.Accident GetModel(int F_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 F_ID,F_ProjectID,F_AccidentName,F_Description,F_AccidentDate,F_OperatorID,F_OperateTime,F_IsDelete from T_Accident ");
			strSql.Append(" where F_ID=@F_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@F_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = F_ID;

			Library.Model.Accident model=new Library.Model.Accident();
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
		public Library.Model.Accident DataRowToModel(DataRow row)
		{
			Library.Model.Accident model=new Library.Model.Accident();
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
				if(row["F_AccidentName"]!=null)
				{
					model.F_AccidentName=row["F_AccidentName"].ToString();
				}
				if(row["F_Description"]!=null)
				{
					model.F_Description=row["F_Description"].ToString();
				}
				if(row["F_AccidentDate"]!=null && row["F_AccidentDate"].ToString()!="")
				{
					model.F_AccidentDate=DateTime.Parse(row["F_AccidentDate"].ToString());
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
			strSql.Append("select F_ID,F_ProjectID,F_AccidentName,F_Description,F_AccidentDate,F_OperatorID,F_OperateTime,F_IsDelete ");
			strSql.Append(" FROM T_Accident ");
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
			strSql.Append(" F_ID,F_ProjectID,F_AccidentName,F_Description,F_AccidentDate,F_OperatorID,F_OperateTime,F_IsDelete ");
			strSql.Append(" FROM T_Accident ");
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
			strSql.Append("select count(1) FROM T_Accident ");
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
			strSql.Append(")AS Row, T.*  from T_Accident T ");
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
			parameters[0].Value = "T_Accident";
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


        public DataTable GetTable(string projectlist, string startTime, string endTime)
        {
            //F_OperatorName

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select e.F_Name as F_OperatorName, p.F_Name as F_ProjectName, a.F_ID,a.F_ProjectID,a.F_AccidentName,a.F_Description,a.F_AccidentDate,a.F_OperatorID, CONVERT(varchar(100), a.F_OperateTime, 20) as F_OperateTime,a.F_IsDelete ");
            strSql.Append(" FROM T_Accident a inner Join T_Project p on  a.F_ProjectID = p.F_ID");
            strSql.Append("  inner Join T_Employee e on  a.F_OperatorID = e.F_ID");

            
            strSql.Append(" where a.F_IsDelete=0 and a.F_ProjectID in (" + projectlist + ")");

            if (!string.IsNullOrEmpty(startTime))
            {
                strSql.Append(" and a.F_AccidentDate >='" + startTime + "'");
            }
            if (!string.IsNullOrEmpty(endTime))
            {
                strSql.Append(" and a.F_AccidentDate <='" + endTime + "'");
            }

            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }


    }
}

