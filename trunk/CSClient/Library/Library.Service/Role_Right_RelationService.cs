/**  版本信息模板在安装目录下，可自行修改。
* Role_Right_Relation.cs
*
* 功 能： N/A
* 类 名： Role_Right_Relation
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/5/16 9:22:30   N/A    初版
*
* Copyright (c) 2012 Library Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;
using Library.Common;
using Library.Model;
using Library.DALFactory;
using Library.IDAL;
namespace Library.BLL
{
	/// <summary>
	/// Role_Right_Relation
	/// </summary>
	public partial class Role_Right_RelationService
	{
		private readonly IRole_Right_Relation dal=DataAccess.CreateRole_Right_Relation();
		public Role_Right_RelationService()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int F_RoleID,int F_RightID)
		{
			return dal.Exists(F_RoleID,F_RightID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Library.Model.Role_Right_Relation model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Library.Model.Role_Right_Relation model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int F_RoleID,int F_RightID)
		{
			
			return dal.Delete(F_RoleID,F_RightID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Library.Model.Role_Right_Relation GetModel(int F_RoleID,int F_RightID)
		{
			
			return dal.GetModel(F_RoleID,F_RightID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Library.Model.Role_Right_Relation GetModelByCache(int F_RoleID,int F_RightID)
		{
			
			string CacheKey = "Role_Right_RelationModel-" + F_RoleID+F_RightID;
			object objModel = Library.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(F_RoleID,F_RightID);
					if (objModel != null)
					{
						int ModelCache = Library.Common.ConfigHelper.GetConfigInt("ModelCache");
						Library.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Library.Model.Role_Right_Relation)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Library.Model.Role_Right_Relation> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Library.Model.Role_Right_Relation> DataTableToList(DataTable dt)
		{
			List<Library.Model.Role_Right_Relation> modelList = new List<Library.Model.Role_Right_Relation>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Library.Model.Role_Right_Relation model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod

        public void Delete(int F_RoleID)
        {
            dal.Delete(F_RoleID);
        }
    }
}

