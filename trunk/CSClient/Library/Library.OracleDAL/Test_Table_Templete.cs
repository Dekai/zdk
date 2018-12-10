/**  版本信息模板在安装目录下，可自行修改。
* Test_Table_Templete.cs
*
* 功 能： N/A
* 类 名： Test_Table_Templete
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/5/20 16:58:00   N/A    初版
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
    /// 数据访问类:Test_Table_Templete
    /// </summary>
    public partial class Test_Table_Templete : ITest_Table_Templete
    {
        public Test_Table_Templete()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("F_ID", "T_Test_Table_Templete");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int F_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from T_Test_Table_Templete");
            strSql.Append(" where F_ID=@F_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@F_ID", SqlDbType.Int,4)			};
            parameters[0].Value = F_ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Library.Model.Test_Table_Templete model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into T_Test_Table_Templete(");
            strSql.Append("F_ID,F_TypeID,F_Name,F_RowCount,F_ColunmCount,F_Banner,F_Order,F_ShowWidth,F_ShowHeight,F_ShowFontSize,F_DefineWidth,F_DefineHeight,F_DefineFontSize,F_ShowBorderColor,F_ShowFontColor,F_ShowBackColor)");
            strSql.Append(" values (");
            strSql.Append("@F_ID,@F_TypeID,@F_Name,@F_RowCount,@F_ColunmCount,@F_Banner,@F_Order,@F_ShowWidth,@F_ShowHeight,@F_ShowFontSize,@F_DefineWidth,@F_DefineHeight,@F_DefineFontSize,@F_ShowBorderColor,@F_ShowFontColor,@F_ShowBackColor)");
            SqlParameter[] parameters = {
					new SqlParameter("@F_ID", SqlDbType.Int,4),
					new SqlParameter("@F_TypeID", SqlDbType.Int,4),
					new SqlParameter("@F_Name", SqlDbType.VarChar,150),
					new SqlParameter("@F_RowCount", SqlDbType.Int,4),
					new SqlParameter("@F_ColunmCount", SqlDbType.Int,4),
					new SqlParameter("@F_Banner", SqlDbType.VarChar,500),
					new SqlParameter("@F_Order", SqlDbType.Int,4),
					new SqlParameter("@F_ShowWidth", SqlDbType.Int,4),
					new SqlParameter("@F_ShowHeight", SqlDbType.Int,4),
					new SqlParameter("@F_ShowFontSize", SqlDbType.Int,4),
					new SqlParameter("@F_DefineWidth", SqlDbType.Int,4),
					new SqlParameter("@F_DefineHeight", SqlDbType.Int,4),
					new SqlParameter("@F_DefineFontSize", SqlDbType.Int,4),
					new SqlParameter("@F_ShowBorderColor", SqlDbType.VarChar,50),
					new SqlParameter("@F_ShowFontColor", SqlDbType.VarChar,50),
					new SqlParameter("@F_ShowBackColor", SqlDbType.VarChar,50)};
            parameters[0].Value = model.F_ID;
            parameters[1].Value = model.F_TypeID;
            parameters[2].Value = model.F_Name;
            parameters[3].Value = model.F_RowCount;
            parameters[4].Value = model.F_ColunmCount;
            parameters[5].Value = model.F_Banner;
            parameters[6].Value = model.F_Order;
            parameters[7].Value = model.F_ShowWidth;
            parameters[8].Value = model.F_ShowHeight;
            parameters[9].Value = model.F_ShowFontSize;
            parameters[10].Value = model.F_DefineWidth;
            parameters[11].Value = model.F_DefineHeight;
            parameters[12].Value = model.F_DefineFontSize;
            parameters[13].Value = model.F_ShowBorderColor;
            parameters[14].Value = model.F_ShowFontColor;
            parameters[15].Value = model.F_ShowBackColor;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(Library.Model.Test_Table_Templete model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update T_Test_Table_Templete set ");
            strSql.Append("F_TypeID=@F_TypeID,");
            strSql.Append("F_Name=@F_Name,");
            strSql.Append("F_RowCount=@F_RowCount,");
            strSql.Append("F_ColunmCount=@F_ColunmCount,");
            strSql.Append("F_Banner=@F_Banner,");
            strSql.Append("F_Order=@F_Order,");
            strSql.Append("F_ShowWidth=@F_ShowWidth,");
            strSql.Append("F_ShowHeight=@F_ShowHeight,");
            strSql.Append("F_ShowFontSize=@F_ShowFontSize,");
            strSql.Append("F_DefineWidth=@F_DefineWidth,");
            strSql.Append("F_DefineHeight=@F_DefineHeight,");
            strSql.Append("F_DefineFontSize=@F_DefineFontSize,");
            strSql.Append("F_ShowBorderColor=@F_ShowBorderColor,");
            strSql.Append("F_ShowFontColor=@F_ShowFontColor,");
            strSql.Append("F_ShowBackColor=@F_ShowBackColor");
            strSql.Append(" where F_ID=@F_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@F_TypeID", SqlDbType.Int,4),
					new SqlParameter("@F_Name", SqlDbType.VarChar,150),
					new SqlParameter("@F_RowCount", SqlDbType.Int,4),
					new SqlParameter("@F_ColunmCount", SqlDbType.Int,4),
					new SqlParameter("@F_Banner", SqlDbType.VarChar,500),
					new SqlParameter("@F_Order", SqlDbType.Int,4),
					new SqlParameter("@F_ShowWidth", SqlDbType.Int,4),
					new SqlParameter("@F_ShowHeight", SqlDbType.Int,4),
					new SqlParameter("@F_ShowFontSize", SqlDbType.Int,4),
					new SqlParameter("@F_DefineWidth", SqlDbType.Int,4),
					new SqlParameter("@F_DefineHeight", SqlDbType.Int,4),
					new SqlParameter("@F_DefineFontSize", SqlDbType.Int,4),
					new SqlParameter("@F_ShowBorderColor", SqlDbType.VarChar,50),
					new SqlParameter("@F_ShowFontColor", SqlDbType.VarChar,50),
					new SqlParameter("@F_ShowBackColor", SqlDbType.VarChar,50),
					new SqlParameter("@F_ID", SqlDbType.Int,4)};
            parameters[0].Value = model.F_TypeID;
            parameters[1].Value = model.F_Name;
            parameters[2].Value = model.F_RowCount;
            parameters[3].Value = model.F_ColunmCount;
            parameters[4].Value = model.F_Banner;
            parameters[5].Value = model.F_Order;
            parameters[6].Value = model.F_ShowWidth;
            parameters[7].Value = model.F_ShowHeight;
            parameters[8].Value = model.F_ShowFontSize;
            parameters[9].Value = model.F_DefineWidth;
            parameters[10].Value = model.F_DefineHeight;
            parameters[11].Value = model.F_DefineFontSize;
            parameters[12].Value = model.F_ShowBorderColor;
            parameters[13].Value = model.F_ShowFontColor;
            parameters[14].Value = model.F_ShowBackColor;
            parameters[15].Value = model.F_ID;

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
            strSql.Append("delete from T_Test_Table_Templete ");
            strSql.Append(" where F_ID=@F_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@F_ID", SqlDbType.Int,4)			};
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
            strSql.Append("delete from T_Test_Table_Templete ");
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
        public Library.Model.Test_Table_Templete GetModel(int F_ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 F_ID,F_TypeID,F_Name,F_RowCount,F_ColunmCount,F_Banner,F_Order,F_ShowWidth,F_ShowHeight,F_ShowFontSize,F_DefineWidth,F_DefineHeight,F_DefineFontSize,F_ShowBorderColor,F_ShowFontColor,F_ShowBackColor from T_Test_Table_Templete ");
            strSql.Append(" where F_ID=@F_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@F_ID", SqlDbType.Int,4)			};
            parameters[0].Value = F_ID;

            Library.Model.Test_Table_Templete model = new Library.Model.Test_Table_Templete();
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
        public Library.Model.Test_Table_Templete DataRowToModel(DataRow row)
        {
            Library.Model.Test_Table_Templete model = new Library.Model.Test_Table_Templete();
            if (row != null)
            {
                if (row["F_ID"] != null && row["F_ID"].ToString() != "")
                {
                    model.F_ID = int.Parse(row["F_ID"].ToString());
                }
                if (row["F_TypeID"] != null && row["F_TypeID"].ToString() != "")
                {
                    model.F_TypeID = int.Parse(row["F_TypeID"].ToString());
                }
                if (row["F_Name"] != null)
                {
                    model.F_Name = row["F_Name"].ToString();
                }
                if (row["F_RowCount"] != null && row["F_RowCount"].ToString() != "")
                {
                    model.F_RowCount = int.Parse(row["F_RowCount"].ToString());
                }
                if (row["F_ColunmCount"] != null && row["F_ColunmCount"].ToString() != "")
                {
                    model.F_ColunmCount = int.Parse(row["F_ColunmCount"].ToString());
                }
                if (row["F_Banner"] != null)
                {
                    model.F_Banner = row["F_Banner"].ToString();
                }
                if (row["F_Order"] != null && row["F_Order"].ToString() != "")
                {
                    model.F_Order = int.Parse(row["F_Order"].ToString());
                }
                if (row["F_ShowWidth"] != null && row["F_ShowWidth"].ToString() != "")
                {
                    model.F_ShowWidth = int.Parse(row["F_ShowWidth"].ToString());
                }
                if (row["F_ShowHeight"] != null && row["F_ShowHeight"].ToString() != "")
                {
                    model.F_ShowHeight = int.Parse(row["F_ShowHeight"].ToString());
                }
                if (row["F_ShowFontSize"] != null && row["F_ShowFontSize"].ToString() != "")
                {
                    model.F_ShowFontSize = int.Parse(row["F_ShowFontSize"].ToString());
                }
                if (row["F_DefineWidth"] != null && row["F_DefineWidth"].ToString() != "")
                {
                    model.F_DefineWidth = int.Parse(row["F_DefineWidth"].ToString());
                }
                if (row["F_DefineHeight"] != null && row["F_DefineHeight"].ToString() != "")
                {
                    model.F_DefineHeight = int.Parse(row["F_DefineHeight"].ToString());
                }
                if (row["F_DefineFontSize"] != null && row["F_DefineFontSize"].ToString() != "")
                {
                    model.F_DefineFontSize = int.Parse(row["F_DefineFontSize"].ToString());
                }
                if (row["F_ShowBorderColor"] != null)
                {
                    model.F_ShowBorderColor = row["F_ShowBorderColor"].ToString();
                }
                if (row["F_ShowFontColor"] != null)
                {
                    model.F_ShowFontColor = row["F_ShowFontColor"].ToString();
                }
                if (row["F_ShowBackColor"] != null)
                {
                    model.F_ShowBackColor = row["F_ShowBackColor"].ToString();
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
            strSql.Append("select F_ID,F_TypeID,F_Name,F_RowCount,F_ColunmCount,F_Banner,F_Order,F_ShowWidth,F_ShowHeight,F_ShowFontSize,F_DefineWidth,F_DefineHeight,F_DefineFontSize,F_ShowBorderColor,F_ShowFontColor,F_ShowBackColor ");
            strSql.Append(" FROM T_Test_Table_Templete ");
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
            strSql.Append(" F_ID,F_TypeID,F_Name,F_RowCount,F_ColunmCount,F_Banner,F_Order,F_ShowWidth,F_ShowHeight,F_ShowFontSize,F_DefineWidth,F_DefineHeight,F_DefineFontSize,F_ShowBorderColor,F_ShowFontColor,F_ShowBackColor ");
            strSql.Append(" FROM T_Test_Table_Templete ");
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
            strSql.Append("select count(1) FROM T_Test_Table_Templete ");
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
            strSql.Append(")AS Row, T.*  from T_Test_Table_Templete T ");
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
            parameters[0].Value = "T_Test_Table_Templete";
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

