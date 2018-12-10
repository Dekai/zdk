/**  版本信息模板在安装目录下，可自行修改。
* CostApply.cs
*
* 功 能： N/A
* 类 名： CostApply
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/6/26 0:16:33   N/A    初版
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
	/// 数据访问类:CostApply
	/// </summary>
	public partial class CostApply:ICostApply
	{
		public CostApply()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("F_ID", "T_CostApply"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int F_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_CostApply");
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
		public int Add(Library.Model.CostApply model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_CostApply(");
			strSql.Append("F_ApplyTitle,F_ProjectID,F_ApplyType,F_ApplyAmount,F_ApplyDate,F_OperatorID,F_OperateTime,F_IsDelete,F_ApplyDescription,F_WF_StateID)");
			strSql.Append(" values (");
			strSql.Append("@F_ApplyTitle,@F_ProjectID,@F_ApplyType,@F_ApplyAmount,@F_ApplyDate,@F_OperatorID,@F_OperateTime,@F_IsDelete,@F_ApplyDescription,@F_WF_StateID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@F_ApplyTitle", SqlDbType.NVarChar,500),
					new SqlParameter("@F_ProjectID", SqlDbType.Int,4),
					new SqlParameter("@F_ApplyType", SqlDbType.Int,4),
					new SqlParameter("@F_ApplyAmount", SqlDbType.Money,8),
					new SqlParameter("@F_ApplyDate", SqlDbType.Date,3),
					new SqlParameter("@F_OperatorID", SqlDbType.Int,4),
					new SqlParameter("@F_OperateTime", SqlDbType.DateTime),
					new SqlParameter("@F_IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@F_ApplyDescription", SqlDbType.NVarChar,500),
					new SqlParameter("@F_WF_StateID", SqlDbType.Int,4)};
			parameters[0].Value = model.F_ApplyTitle;
			parameters[1].Value = model.F_ProjectID;
			parameters[2].Value = model.F_ApplyType;
			parameters[3].Value = model.F_ApplyAmount;
			parameters[4].Value = model.F_ApplyDate;
			parameters[5].Value = model.F_OperatorID;
			parameters[6].Value = model.F_OperateTime;
			parameters[7].Value = model.F_IsDelete;
			parameters[8].Value = model.F_ApplyDescription;
			parameters[9].Value = model.F_WF_StateID;

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
		public bool Update(Library.Model.CostApply model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_CostApply set ");
			strSql.Append("F_ApplyTitle=@F_ApplyTitle,");
			strSql.Append("F_ProjectID=@F_ProjectID,");
			strSql.Append("F_ApplyType=@F_ApplyType,");
			strSql.Append("F_ApplyAmount=@F_ApplyAmount,");
			strSql.Append("F_ApplyDate=@F_ApplyDate,");
			strSql.Append("F_OperatorID=@F_OperatorID,");
			strSql.Append("F_OperateTime=@F_OperateTime,");
			strSql.Append("F_IsDelete=@F_IsDelete,");
			strSql.Append("F_ApplyDescription=@F_ApplyDescription,");
			strSql.Append("F_WF_StateID=@F_WF_StateID");
			strSql.Append(" where F_ID=@F_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@F_ApplyTitle", SqlDbType.NVarChar,500),
					new SqlParameter("@F_ProjectID", SqlDbType.Int,4),
					new SqlParameter("@F_ApplyType", SqlDbType.Int,4),
					new SqlParameter("@F_ApplyAmount", SqlDbType.Money,8),
					new SqlParameter("@F_ApplyDate", SqlDbType.Date,3),
					new SqlParameter("@F_OperatorID", SqlDbType.Int,4),
					new SqlParameter("@F_OperateTime", SqlDbType.DateTime),
					new SqlParameter("@F_IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@F_ApplyDescription", SqlDbType.NVarChar,500),
					new SqlParameter("@F_WF_StateID", SqlDbType.Int,4),
					new SqlParameter("@F_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.F_ApplyTitle;
			parameters[1].Value = model.F_ProjectID;
			parameters[2].Value = model.F_ApplyType;
			parameters[3].Value = model.F_ApplyAmount;
			parameters[4].Value = model.F_ApplyDate;
			parameters[5].Value = model.F_OperatorID;
			parameters[6].Value = model.F_OperateTime;
			parameters[7].Value = model.F_IsDelete;
			parameters[8].Value = model.F_ApplyDescription;
			parameters[9].Value = model.F_WF_StateID;
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
			strSql.Append("delete from T_CostApply ");
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
			strSql.Append("delete from T_CostApply ");
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
		public Library.Model.CostApply GetModel(int F_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 F_ID,F_ApplyTitle,F_ProjectID,F_ApplyType,F_ApplyAmount,F_ApplyDate,F_OperatorID,F_OperateTime,F_IsDelete,F_ApplyDescription,F_WF_StateID from T_CostApply ");
			strSql.Append(" where F_ID=@F_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@F_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = F_ID;

			Library.Model.CostApply model=new Library.Model.CostApply();
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
		public Library.Model.CostApply DataRowToModel(DataRow row)
		{
			Library.Model.CostApply model=new Library.Model.CostApply();
			if (row != null)
			{
				if(row["F_ID"]!=null && row["F_ID"].ToString()!="")
				{
					model.F_ID=int.Parse(row["F_ID"].ToString());
				}
				if(row["F_ApplyTitle"]!=null)
				{
					model.F_ApplyTitle=row["F_ApplyTitle"].ToString();
				}
				if(row["F_ProjectID"]!=null && row["F_ProjectID"].ToString()!="")
				{
					model.F_ProjectID=int.Parse(row["F_ProjectID"].ToString());
				}
				if(row["F_ApplyType"]!=null && row["F_ApplyType"].ToString()!="")
				{
					model.F_ApplyType=int.Parse(row["F_ApplyType"].ToString());
				}
				if(row["F_ApplyAmount"]!=null && row["F_ApplyAmount"].ToString()!="")
				{
					model.F_ApplyAmount=decimal.Parse(row["F_ApplyAmount"].ToString());
				}
				if(row["F_ApplyDate"]!=null && row["F_ApplyDate"].ToString()!="")
				{
					model.F_ApplyDate=DateTime.Parse(row["F_ApplyDate"].ToString());
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
				if(row["F_ApplyDescription"]!=null)
				{
					model.F_ApplyDescription=row["F_ApplyDescription"].ToString();
				}
				if(row["F_WF_StateID"]!=null && row["F_WF_StateID"].ToString()!="")
				{
					model.F_WF_StateID=int.Parse(row["F_WF_StateID"].ToString());
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
			strSql.Append("select F_ID,F_ApplyTitle,F_ProjectID,F_ApplyType,F_ApplyAmount,F_ApplyDate,F_OperatorID,F_OperateTime,F_IsDelete,F_ApplyDescription,F_WF_StateID ");
			strSql.Append(" FROM T_CostApply ");
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
			strSql.Append(" F_ID,F_ApplyTitle,F_ProjectID,F_ApplyType,F_ApplyAmount,F_ApplyDate,F_OperatorID,F_OperateTime,F_IsDelete,F_ApplyDescription,F_WF_StateID ");
			strSql.Append(" FROM T_CostApply ");
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
			strSql.Append("select count(1) FROM T_CostApply ");
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
			strSql.Append(")AS Row, T.*  from T_CostApply T ");
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
			parameters[0].Value = "T_CostApply";
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


        public DataTable GetViewList(string projectlist, string wfstate, string startTime, string endTime)
        {
            // F_ID,F_ApplyTitle,F_ProjectID,F_ApplyType,F_ApplyAmount,F_ApplyDate,F_OperatorID,F_OperateTime,F_IsDelete,F_ApplyDescription,F_WF_StateID

            StringBuilder strSql = new StringBuilder();
            strSql.Append("   select a.F_ID,a.F_ApplyTitle, a.F_OperatorID, case when a.F_ApplyType=1 then '工程费用' else '非工程费用' end  ApplyTypeName,p.F_Name ");
            strSql.Append("  ,cast(a.F_ApplyAmount as decimal(20,2)) F_ApplyAmount,a.F_ApplyDate,a.F_ApplyDescription,w.F_StateName as StateName,w.F_StateID");
            strSql.Append("  from ");
            strSql.Append(" (select * from T_CostApply where F_IsDelete=0 ");

            if (!string.IsNullOrEmpty(endTime))
                strSql.Append(" and F_ApplyDate <='" + endTime + "'");

            if (!string.IsNullOrEmpty(startTime))
                strSql.Append(" and  F_ApplyDate >='" + startTime + "'");

            strSql.Append(") a ");
            strSql.Append(" inner join (select * from T_Project p where p.F_ID in (" + projectlist + ")) p on a.F_ProjectID =p.F_ID");
            strSql.Append(" inner join (select * from T_WorkFlow_Templete w ");

            if (!string.IsNullOrEmpty(wfstate))
            {
                strSql.Append(" where w.F_StateID='" + wfstate + "' ");
            }
            
            strSql.Append(") w on a.F_WF_StateID =w.F_StateID");

            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }
    }
}

