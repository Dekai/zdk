/**  版本信息模板在安装目录下，可自行修改。
* WorkFlow_Templete.cs
*
* 功 能： N/A
* 类 名： WorkFlow_Templete
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
using System.Collections.Generic;
using Library.Common;
using Library.Model;
using Library.DALFactory;
using Library.IDAL;
using BaseControl.Tree;
namespace Library.BLL
{
	/// <summary>
	/// WorkFlow_Templete
	/// </summary>
	public partial class WorkFlow_TempleteService
	{
		private readonly IWorkFlow_Templete dal=DataAccess.CreateWorkFlow_Templete();
		public WorkFlow_TempleteService()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string F_LinkTask,string F_StateID)
		{
			return dal.Exists(F_LinkTask,F_StateID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Library.Model.WorkFlow_Templete model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Library.Model.WorkFlow_Templete model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string F_LinkTask,string F_StateID)
		{
			
			return dal.Delete(F_LinkTask,F_StateID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Library.Model.WorkFlow_Templete GetModel(string F_LinkTask,string F_StateID)
		{
			
			return dal.GetModel(F_LinkTask,F_StateID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Library.Model.WorkFlow_Templete GetModelByCache(string F_LinkTask,string F_StateID)
		{
			
			string CacheKey = "WorkFlow_TempleteModel-" + F_LinkTask+F_StateID;
			object objModel = Library.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(F_LinkTask,F_StateID);
					if (objModel != null)
					{
						int ModelCache = Library.Common.ConfigHelper.GetConfigInt("ModelCache");
						Library.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Library.Model.WorkFlow_Templete)objModel;
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
		public List<Library.Model.WorkFlow_Templete> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Library.Model.WorkFlow_Templete> DataTableToList(DataTable dt)
		{
			List<Library.Model.WorkFlow_Templete> modelList = new List<Library.Model.WorkFlow_Templete>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Library.Model.WorkFlow_Templete model;
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

        public string GetStartState(string wflinktable)
        {
            return dal.GetStartState(wflinktable);
        }

        public Library.Model.WorkFlow_Templete GetCurrentModel(string wflinktable, string stateid)
        {
            return dal.GetCurrentModel(wflinktable, stateid);
        }

        public List<BaseControl.Tree.TreeNodeInfo> GetNodes()
        {

            List<TreeNodeInfo> Nodes = new List<TreeNodeInfo>();
            DataTable dt = this.GetAllList().Tables[0];
            List<string> l = dal.GetLinkTask();

            int i = 0;
            foreach (string s in l)
            {
                i++;
                TreeNodeInfo node = new TreeNodeInfo();
                node.Text ="工作流程"+i;
                node.ID = "";
                node.Tag = s;
                Nodes.Add(node);
                CreateChildNodes(node,s, dt);
            }
            return Nodes;
        }


        private void CreateChildNodes(TreeNodeInfo pnode, string F_PID, DataTable dt)
        {
            DataRow[] rows = dt.Select("F_LinkTask ='" + F_PID+"'");

            pnode.Childs = new List<TreeNodeInfo>();
            foreach (DataRow row in rows)
            {
                TreeNodeInfo node = new TreeNodeInfo();
                node.Text = row["F_StateName"].ToString();
                node.ID = row["F_StateID"].ToString();
                node.Tag = row;
                pnode.Childs.Add(node);
            }
        }




        public string GetNextState(string wflinktable)
        {
            return dal.GetNextState(wflinktable);
        }
    }
}

