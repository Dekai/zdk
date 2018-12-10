/**  版本信息模板在安装目录下，可自行修改。
* ProjectCost.cs
*
* 功 能： N/A
* 类 名： ProjectCost
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/6/26 0:16:32   N/A    初版
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
	/// 数据访问类:ProjectCost
	/// </summary>
    public partial class ProjectCost : IProjectCost
    {
        public ProjectCost()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("F_ID", "T_ProjectCost");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int F_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_ProjectCost");
            strSql.Append(" where F_ID=@F_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@F_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = F_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Library.Model.ProjectCost model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_ProjectCost(");
            strSql.Append("F_ProjectID,F_IsProjectCost,F_CostType,F_CostAmount,F_OtherCost,F_CostDate,F_OperatorID,F_OperateTime,F_IsDelete,F_CostDescription,F_ApplyID)");
            strSql.Append(" values (");
            strSql.Append("@F_ProjectID,@F_IsProjectCost,@F_CostType,@F_CostAmount,@F_OtherCost,@F_CostDate,@F_OperatorID,@F_OperateTime,@F_IsDelete,@F_CostDescription,@F_ApplyID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@F_ProjectID", SqlDbType.Int,4),
					new SqlParameter("@F_IsProjectCost", SqlDbType.Bit,1),
					new SqlParameter("@F_CostType", SqlDbType.Int,4),
					new SqlParameter("@F_CostAmount", SqlDbType.Money,8),
					new SqlParameter("@F_OtherCost", SqlDbType.NVarChar,500),
					new SqlParameter("@F_CostDate", SqlDbType.Date,3),
					new SqlParameter("@F_OperatorID", SqlDbType.Int,4),
					new SqlParameter("@F_OperateTime", SqlDbType.DateTime),
					new SqlParameter("@F_IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@F_CostDescription", SqlDbType.NVarChar,500),
					new SqlParameter("@F_ApplyID", SqlDbType.Int,4)};
            parameters[0].Value = model.F_ProjectID;
            parameters[1].Value = model.F_IsProjectCost;
            parameters[2].Value = model.F_CostType;
            parameters[3].Value = model.F_CostAmount;
            parameters[4].Value = model.F_OtherCost;
            parameters[5].Value = model.F_CostDate;
            parameters[6].Value = model.F_OperatorID;
            parameters[7].Value = model.F_OperateTime;
            parameters[8].Value = model.F_IsDelete;
            parameters[9].Value = model.F_CostDescription;
            parameters[10].Value = model.F_ApplyID;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(Library.Model.ProjectCost model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_ProjectCost set ");
            strSql.Append("F_ProjectID=@F_ProjectID,");
            strSql.Append("F_IsProjectCost=@F_IsProjectCost,");
            strSql.Append("F_CostType=@F_CostType,");
            strSql.Append("F_CostAmount=@F_CostAmount,");
            strSql.Append("F_OtherCost=@F_OtherCost,");
            strSql.Append("F_CostDate=@F_CostDate,");
            strSql.Append("F_OperatorID=@F_OperatorID,");
            strSql.Append("F_OperateTime=@F_OperateTime,");
            strSql.Append("F_IsDelete=@F_IsDelete,");
            strSql.Append("F_CostDescription=@F_CostDescription,");
            strSql.Append("F_ApplyID=@F_ApplyID");
            strSql.Append(" where F_ID=@F_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@F_ProjectID", SqlDbType.Int,4),
					new SqlParameter("@F_IsProjectCost", SqlDbType.Bit,1),
					new SqlParameter("@F_CostType", SqlDbType.Int,4),
					new SqlParameter("@F_CostAmount", SqlDbType.Money,8),
					new SqlParameter("@F_OtherCost", SqlDbType.NVarChar,500),
					new SqlParameter("@F_CostDate", SqlDbType.Date,3),
					new SqlParameter("@F_OperatorID", SqlDbType.Int,4),
					new SqlParameter("@F_OperateTime", SqlDbType.DateTime),
					new SqlParameter("@F_IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@F_CostDescription", SqlDbType.NVarChar,500),
					new SqlParameter("@F_ApplyID", SqlDbType.Int,4),
					new SqlParameter("@F_ID", SqlDbType.Int,4)};
            parameters[0].Value = model.F_ProjectID;
            parameters[1].Value = model.F_IsProjectCost;
            parameters[2].Value = model.F_CostType;
            parameters[3].Value = model.F_CostAmount;
            parameters[4].Value = model.F_OtherCost;
            parameters[5].Value = model.F_CostDate;
            parameters[6].Value = model.F_OperatorID;
            parameters[7].Value = model.F_OperateTime;
            parameters[8].Value = model.F_IsDelete;
            parameters[9].Value = model.F_CostDescription;
            parameters[10].Value = model.F_ApplyID;
            parameters[11].Value = model.F_ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_ProjectCost ");
            strSql.Append(" where F_ID=@F_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@F_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = F_ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string F_IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from T_ProjectCost ");
            strSql.Append(" where F_ID in (" + F_IDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public Library.Model.ProjectCost GetModel(int F_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 F_ID,F_ProjectID,F_IsProjectCost,F_CostType,F_CostAmount,F_OtherCost,F_CostDate,F_OperatorID,F_OperateTime,F_IsDelete,F_CostDescription,F_ApplyID from T_ProjectCost ");
            strSql.Append(" where F_ID=@F_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@F_ID", SqlDbType.Int,4)
			};
            parameters[0].Value = F_ID;

            Library.Model.ProjectCost model = new Library.Model.ProjectCost();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
        public Library.Model.ProjectCost DataRowToModel(DataRow row)
        {
            Library.Model.ProjectCost model = new Library.Model.ProjectCost();
            if (row != null)
            {
                if (row["F_ID"] != null && row["F_ID"].ToString() != "")
                {
                    model.F_ID = int.Parse(row["F_ID"].ToString());
                }
                if (row["F_ProjectID"] != null && row["F_ProjectID"].ToString() != "")
                {
                    model.F_ProjectID = int.Parse(row["F_ProjectID"].ToString());
                }
                if (row["F_IsProjectCost"] != null && row["F_IsProjectCost"].ToString() != "")
                {
                    if ((row["F_IsProjectCost"].ToString() == "1") || (row["F_IsProjectCost"].ToString().ToLower() == "true"))
                    {
                        model.F_IsProjectCost = true;
                    }
                    else
                    {
                        model.F_IsProjectCost = false;
                    }
                }
                if (row["F_CostType"] != null && row["F_CostType"].ToString() != "")
                {
                    model.F_CostType = int.Parse(row["F_CostType"].ToString());
                }
                if (row["F_CostAmount"] != null && row["F_CostAmount"].ToString() != "")
                {
                    model.F_CostAmount = decimal.Parse(row["F_CostAmount"].ToString());
                }
                if (row["F_OtherCost"] != null)
                {
                    model.F_OtherCost = row["F_OtherCost"].ToString();
                }
                if (row["F_CostDate"] != null && row["F_CostDate"].ToString() != "")
                {
                    model.F_CostDate = DateTime.Parse(row["F_CostDate"].ToString());
                }
                if (row["F_OperatorID"] != null && row["F_OperatorID"].ToString() != "")
                {
                    model.F_OperatorID = int.Parse(row["F_OperatorID"].ToString());
                }
                if (row["F_OperateTime"] != null && row["F_OperateTime"].ToString() != "")
                {
                    model.F_OperateTime = DateTime.Parse(row["F_OperateTime"].ToString());
                }
                if (row["F_IsDelete"] != null && row["F_IsDelete"].ToString() != "")
                {
                    if ((row["F_IsDelete"].ToString() == "1") || (row["F_IsDelete"].ToString().ToLower() == "true"))
                    {
                        model.F_IsDelete = true;
                    }
                    else
                    {
                        model.F_IsDelete = false;
                    }
                }
                if (row["F_CostDescription"] != null)
                {
                    model.F_CostDescription = row["F_CostDescription"].ToString();
                }
                if (row["F_ApplyID"] != null && row["F_ApplyID"].ToString() != "")
                {
                    model.F_ApplyID = int.Parse(row["F_ApplyID"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select F_ID,F_ProjectID,F_IsProjectCost,F_CostType,F_CostAmount,F_OtherCost,F_CostDate,F_OperatorID,F_OperateTime,F_IsDelete,F_CostDescription,F_ApplyID ");
            strSql.Append(" FROM T_ProjectCost ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" F_ID,F_ProjectID,F_IsProjectCost,F_CostType,F_CostAmount,F_OtherCost,F_CostDate,F_OperatorID,F_OperateTime,F_IsDelete,F_CostDescription,F_ApplyID ");
            strSql.Append(" FROM T_ProjectCost ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM T_ProjectCost ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.F_ID desc");
            }
            strSql.Append(")AS Row, T.*  from T_ProjectCost T ");
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
            parameters[0].Value = "T_ProjectCost";
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

        public DataTable GetSummer(string projectids, List<string> CostTypelist, string startdate, string enddate, string wfstate)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("   select  p.F_ID, p.F_Name, p.F_StartDate,p.F_EndDate,");
            strSql.Append("    case when p.F_EndDate =null then DATEDIFF(DAY,p.F_StartDate,GETDATE()) else DATEDIFF(DAY,p.F_StartDate,p.F_EndDate) end as daycount");
            foreach (string id in CostTypelist)
            {
                strSql.Append("     , sum( case when e.F_CostType =" + id + " then cast(F_CostAmount as decimal(20,2)) else 0 end ) CostType_" + id);
            }
            strSql.Append("     ,   cast(sum(F_CostAmount) as decimal(20,2)) CostType_Count");
            strSql.Append("     from ");
            strSql.Append("     (select * from T_Project) p left join ");
            strSql.Append("    (select c.* from T_ProjectCost c inner join T_CostApply a on c.F_ApplyID=a.F_ID where c.F_IsDelete=0  and a.F_IsDelete=0 and a.F_WF_StateID >=" + wfstate);

            if (!string.IsNullOrEmpty(startdate))
            {
                strSql.Append("  and c.F_CostDate<='" + enddate + "' ");
            }
            if (!string.IsNullOrEmpty(enddate))
            {
                strSql.Append("  and  c.F_CostDate >='" + startdate + "'");
            }

            strSql.Append("     ) e on p.F_ID = e.F_ProjectID");
            strSql.Append("    group by p.F_ID, p.F_Name, p.F_StartDate,p.F_EndDate");

            DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            foreach(DataRow row in dt.Rows){

                if(row["CostType_Count"] == DBNull.Value){
                    row["CostType_Count"]=0;
                }
            }


            return dt;
        }


        public DataTable GetAppList(string appid)
        {
            // 日期 用途 金额 备注
            //F_CostAmount,F_OtherCost,F_CostDate,,,,F_CostDescription,

            StringBuilder strSql = new StringBuilder();

            strSql.Append(" select cast(p.F_CostAmount as decimal(20,2)) F_CostAmount, p.F_OtherCost, p.F_CostDate,p.F_CostDescription, case when F_IsProjectCost=1 then d.F_Name else F_OtherCost end  OtherCost  from  ");

            strSql.Append(" (select F_ID,F_ProjectID,F_IsProjectCost,F_CostType,F_CostAmount,F_OtherCost,F_CostDate,F_OperatorID,F_OperateTime,F_IsDelete,F_CostDescription,F_ApplyID ");
            strSql.Append(" FROM T_ProjectCost where F_IsDelete=0 and F_ApplyID=" + appid+" ) p" );

            strSql.Append("   left join (SELECT F_ID,F_Name FROM [PITCH].[dbo].[T_DataDicInfo] where F_TypeCode ='Cost_Type' ) d");

            strSql.Append(" on p.F_CostType = d.F_ID ");

     
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }
    }
}

