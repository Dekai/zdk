/**  版本信息模板在安装目录下，可自行修改。
* Project.cs
*
* 功 能： N/A
* 类 名： Project
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
using Library.DBUtility;
using Library.Model.Struct;
using System.Collections.Generic;//Please add references
namespace Library.SQLServerDAL
{
	/// <summary>
	/// 数据访问类:Project
	/// </summary>
	public partial class Project:IProject
	{
		public Project()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("F_ID", "T_Project"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int F_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from T_Project");
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
		public int Add(Library.Model.Project model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into T_Project(");
			strSql.Append("F_Name,F_StartDate,F_EndDate,F_Description,F_IsDelete,F_OperatorID,F_OperateTime)");
			strSql.Append(" values (");
			strSql.Append("@F_Name,@F_StartDate,@F_EndDate,@F_Description,@F_IsDelete,@F_OperatorID,@F_OperateTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@F_Name", SqlDbType.NVarChar,200),
					new SqlParameter("@F_StartDate", SqlDbType.Date,3),
					new SqlParameter("@F_EndDate", SqlDbType.Date,3),
					new SqlParameter("@F_Description", SqlDbType.NVarChar,2000),
					new SqlParameter("@F_IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@F_OperatorID", SqlDbType.Int,4),
					new SqlParameter("@F_OperateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.F_Name;
			parameters[1].Value = model.F_StartDate;
			parameters[2].Value = model.F_EndDate;
			parameters[3].Value = model.F_Description;
			parameters[4].Value = model.F_IsDelete;
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
		public bool Update(Library.Model.Project model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update T_Project set ");
			strSql.Append("F_Name=@F_Name,");
			strSql.Append("F_StartDate=@F_StartDate,");
			strSql.Append("F_EndDate=@F_EndDate,");
			strSql.Append("F_Description=@F_Description,");
			strSql.Append("F_IsDelete=@F_IsDelete,");
			strSql.Append("F_OperatorID=@F_OperatorID,");
			strSql.Append("F_OperateTime=@F_OperateTime");
			strSql.Append(" where F_ID=@F_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@F_Name", SqlDbType.NVarChar,200),
					new SqlParameter("@F_StartDate", SqlDbType.Date,3),
					new SqlParameter("@F_EndDate", SqlDbType.Date,3),
					new SqlParameter("@F_Description", SqlDbType.NVarChar,2000),
					new SqlParameter("@F_IsDelete", SqlDbType.Bit,1),
					new SqlParameter("@F_OperatorID", SqlDbType.Int,4),
					new SqlParameter("@F_OperateTime", SqlDbType.DateTime),
					new SqlParameter("@F_ID", SqlDbType.Int,4)};
			parameters[0].Value = model.F_Name;
			parameters[1].Value = model.F_StartDate;
			parameters[2].Value = model.F_EndDate;
			parameters[3].Value = model.F_Description;
			parameters[4].Value = model.F_IsDelete;
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
			strSql.Append("delete from T_Project ");
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
			strSql.Append("delete from T_Project ");
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
		public Library.Model.Project GetModel(int F_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 F_ID,F_Name,F_StartDate,F_EndDate,F_Description,F_IsDelete,F_OperatorID,F_OperateTime from T_Project ");
			strSql.Append(" where F_ID=@F_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@F_ID", SqlDbType.Int,4)
			};
			parameters[0].Value = F_ID;

			Library.Model.Project model=new Library.Model.Project();
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
		public Library.Model.Project DataRowToModel(DataRow row)
		{
			Library.Model.Project model=new Library.Model.Project();
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
				if(row["F_StartDate"]!=null && row["F_StartDate"].ToString()!="")
				{
					model.F_StartDate=DateTime.Parse(row["F_StartDate"].ToString());
				}
				if(row["F_EndDate"]!=null && row["F_EndDate"].ToString()!="")
				{
					model.F_EndDate=DateTime.Parse(row["F_EndDate"].ToString());
				}
				if(row["F_Description"]!=null)
				{
					model.F_Description=row["F_Description"].ToString();
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
			strSql.Append("select F_ID,F_Name,F_StartDate,F_EndDate,F_Description,F_IsDelete,F_OperatorID,F_OperateTime ");
			strSql.Append(" FROM T_Project ");
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
			strSql.Append(" F_ID,F_Name,F_StartDate,F_EndDate,F_Description,F_IsDelete,F_OperatorID,F_OperateTime ");
			strSql.Append(" FROM T_Project ");
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
			strSql.Append("select count(1) FROM T_Project ");
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
			strSql.Append(")AS Row, T.*  from T_Project T ");
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
			parameters[0].Value = "T_Project";
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


        public System.Collections.Generic.List<Model.Struct.NameValue> GetNameViewList(string swhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select F_ID,F_Name,F_StartDate,F_EndDate,F_Description,F_IsDelete,F_OperatorID,F_OperateTime ");
            strSql.Append(" FROM T_Project");
            
            if(swhere.Trim()!="")
			{
                strSql.Append(" where " + swhere);
			}

            strSql.Append("  order by   F_IsDelete, F_EndDate ,F_StartDate");

            DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];

            List<NameValue> l = new List<NameValue>();
            foreach (DataRow row in dt.Rows)
            {
                NameValue nameValue = new NameValue();
                nameValue.Value = row["F_ID"].ToString();
                nameValue.Name = row["F_Name"].ToString();
                nameValue.Tag = row["F_IsDelete"].ToString();
                if ("false".Equals(nameValue.Tag.ToString().ToLower()))
                {
                    nameValue.IsSelected = true;
                }
                else
                {
                    nameValue.Name += "(关闭)";
                    nameValue.IsSelected = false;
                }
                l.Add(nameValue);
            }
           return l;
        }
    }
}

