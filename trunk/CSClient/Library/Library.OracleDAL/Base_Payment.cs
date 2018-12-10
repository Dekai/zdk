/**  版本信息模板在安装目录下，可自行修改。
* Base_Payment.cs
*
* 功 能： N/A
* 类 名： Base_Payment
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/5/18 15:07:14   N/A    初版
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
using Library.Model;//Please add references
namespace Library.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:Base_Payment
	/// </summary>
	public partial class Base_Payment:IBase_Payment
	{
		public Base_Payment()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("F_ID", "T_Base_Payment"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int F_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Base_Payment");
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
		public int Add(Library.Model.Base_Payment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Base_Payment(");
			strSql.Append("F_Name,F_Content,F_Money,F_Time,F_WF_StateID,F_UserID)");
			strSql.Append(" values (");
			strSql.Append("@F_Name,@F_Content,@F_Money,@F_Time,@F_WF_StateID,@F_UserID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@F_Name", SqlDbType.VarChar,150),
					new SqlParameter("@F_Content", SqlDbType.VarChar,500),
					new SqlParameter("@F_Money", SqlDbType.Float,8),
					new SqlParameter("@F_Time", SqlDbType.DateTime),
					new SqlParameter("@F_WF_StateID", SqlDbType.VarChar,50),
					new SqlParameter("@F_UserID", SqlDbType.Int,4)};
			parameters[0].Value = model.F_Name;
			parameters[1].Value = model.F_Content;
			parameters[2].Value = model.F_Money;
			parameters[3].Value = model.F_Time;
			parameters[4].Value = model.F_WF_StateID;
			parameters[5].Value = model.F_UserID;

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
		public bool Update(Library.Model.Base_Payment model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Base_Payment set ");
			strSql.Append("F_Name=@F_Name,");
			strSql.Append("F_Content=@F_Content,");
			strSql.Append("F_Money=@F_Money,");
			strSql.Append("F_Time=@F_Time,");
			strSql.Append("F_WF_StateID=@F_WF_StateID,");
			strSql.Append("F_UserID=@F_UserID");
			strSql.Append(" where F_ID=@F_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@F_Name", SqlDbType.VarChar,150),
					new SqlParameter("@F_Content", SqlDbType.VarChar,500),
					new SqlParameter("@F_Money", SqlDbType.Float,8),
					new SqlParameter("@F_Time", SqlDbType.DateTime),
					new SqlParameter("@F_WF_StateID", SqlDbType.VarChar,50),
					new SqlParameter("@F_UserID", SqlDbType.Int,4),
					new SqlParameter("@F_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.F_Name;
			parameters[1].Value = model.F_Content;
			parameters[2].Value = model.F_Money;
			parameters[3].Value = model.F_Time;
			parameters[4].Value = model.F_WF_StateID;
			parameters[5].Value = model.F_UserID;
			parameters[6].Value = model.F_ID;

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
			strSql.Append("delete from T_Base_Payment ");
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
			strSql.Append("delete from T_Base_Payment ");
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
		public Library.Model.Base_Payment GetModel(int F_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 F_ID,F_Name,F_Content,F_Money,F_Time,F_WF_StateID,F_UserID from T_Base_Payment ");
			strSql.Append(" where F_ID=@F_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@F_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = F_ID;

			Library.Model.Base_Payment model=new Library.Model.Base_Payment();
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
		public Library.Model.Base_Payment DataRowToModel(DataRow row)
		{
			Library.Model.Base_Payment model=new Library.Model.Base_Payment();
			if (row != null)
			{
				if(row["F_ID"]!=null && row["F_ID"].ToString()!="")
				{
					model.F_ID=int.Parse(row["F_ID"].ToString());
				}
				if(row["F_Name"]!=null)
				{
					model.F_Name=row["F_Name"].ToString();
				}
				if(row["F_Content"]!=null)
				{
					model.F_Content=row["F_Content"].ToString();
				}
				if(row["F_Money"]!=null && row["F_Money"].ToString()!="")
				{
					model.F_Money=decimal.Parse(row["F_Money"].ToString());
				}
				if(row["F_Time"]!=null && row["F_Time"].ToString()!="")
				{
					model.F_Time=DateTime.Parse(row["F_Time"].ToString());
				}
				if(row["F_WF_StateID"]!=null)
				{
					model.F_WF_StateID=row["F_WF_StateID"].ToString();
				}
				if(row["F_UserID"]!=null && row["F_UserID"].ToString()!="")
				{
					model.F_UserID=int.Parse(row["F_UserID"].ToString());
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
			strSql.Append("select F_ID,F_Name,F_Content,F_Money,F_Time,F_WF_StateID,F_UserID ");
			strSql.Append(" FROM T_Base_Payment ");
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
			strSql.Append(" F_ID,F_Name,F_Content,F_Money,F_Time,F_WF_StateID,F_UserID ");
			strSql.Append(" FROM T_Base_Payment ");
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
			strSql.Append("select count(1) FROM T_Base_Payment ");
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
			strSql.Append(")AS Row, T.*  from T_Base_Payment T ");
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
			parameters[0].Value = "T_Base_Payment";
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

        public PagerTable GetPagerList(string swhere, string orderby, int pageindex, int pagesize)
        {
            string strWhere = "";
            if (!string.IsNullOrEmpty(swhere.Trim()))
            {
                strWhere += " where  " + swhere;
            }
            PagerTable pt = new PagerTable();
            pt.TotalCount = DbHelperSQL.GetCount("T_Base_Payment b", strWhere);

            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select e.F_Name as UserName,w.F_StateName,  b.F_ID,b.F_Name,b.F_Content,b.F_Money,b.F_Time,b.F_WF_StateID,b.F_UserID from T_Base_Payment b");
            strSql.Append(" Left join T_Employee e on b.F_UserID =e.F_ID ");
            strSql.Append(" Left join  (select * from T_WorkFlow_Templete  where F_LinkTask='" + Library.DataDictionary.WorkFlowLinkTable.BaseFare + "') w on b.F_WF_StateID =w.F_StateID ");
            strSql.Append(strWhere);
            if (!string.IsNullOrEmpty(orderby))
            {
                strSql.Append(" order by " + orderby);
            }
            pt.DataSource = DbHelperSQL.Query(strSql.ToString(), pageindex, pagesize).Tables[0];
            return pt;
        }
	}
}

