using System;
using System.Data;
using System.Collections.Generic;
using Agric.Common;
using RESCommonModel;
using RESCommonDal;
namespace RESCommonBll
{
	/// <summary>
	/// spiderdata
	/// </summary>
	public partial class spiderdataBll
	{
		private readonly RESCommonDal.spiderdataDal dal= new RESCommonDal.spiderdataDal();
		public spiderdataBll()
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
		public bool Exists(int id)
		{
			return dal.Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(RESCommonModel.spiderdata model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(RESCommonModel.spiderdata model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			return dal.Delete(id);
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public RESCommonModel.spiderdata GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }


        /// <summary>
        /// 获得数据列表分类
        /// </summary>
        public DataSet GetSpiderKind(string strWhere)
		{
			return dal.GetSpiderKind(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<RESCommonModel.spiderdata> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<RESCommonModel.spiderdata> DataTableToList(DataTable dt)
		{
			List<RESCommonModel.spiderdata> modelList = new List<RESCommonModel.spiderdata>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				RESCommonModel.spiderdata model;
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
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex,string isContent)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex,isContent);
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
	}
}

