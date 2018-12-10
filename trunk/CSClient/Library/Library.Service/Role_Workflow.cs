﻿/**  版本信息模板在安装目录下，可自行修改。
* Role_Workflow.cs
*
* 功 能： N/A
* 类 名： Role_Workflow
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2015/7/1 3:09:50   N/A    初版
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
	/// Role_Workflow
	/// </summary>
	public partial class Role_WorkflowService
	{
		private readonly IRole_Workflow dal=DataAccess.CreateRole_Workflow();
        public Role_WorkflowService()
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
		public bool Exists(int F_RoleID,int F_WFID)
		{
			return dal.Exists(F_RoleID,F_WFID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Library.Model.Role_Workflow model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Library.Model.Role_Workflow model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int F_RoleID,int F_WFID)
		{
			
			return dal.Delete(F_RoleID,F_WFID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Library.Model.Role_Workflow GetModel(int F_RoleID,int F_WFID)
		{
			
			return dal.GetModel(F_RoleID,F_WFID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Library.Model.Role_Workflow GetModelByCache(int F_RoleID,int F_WFID)
		{
			
			string CacheKey = "Role_WorkflowModel-" + F_RoleID+F_WFID;
			object objModel = Library.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(F_RoleID,F_WFID);
					if (objModel != null)
					{
						int ModelCache = Library.Common.ConfigHelper.GetConfigInt("ModelCache");
						Library.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Library.Model.Role_Workflow)objModel;
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
		public List<Library.Model.Role_Workflow> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Library.Model.Role_Workflow> DataTableToList(DataTable dt)
		{
			List<Library.Model.Role_Workflow> modelList = new List<Library.Model.Role_Workflow>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Library.Model.Role_Workflow model;
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

