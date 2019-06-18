using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Agric.Common;//Please add references
using RESCommonModel;
namespace RESCommonDal
{
    /// <summary>
    /// 数据访问类:spiderdata
    /// </summary>
    public partial class spiderdataDal
    {
        public spiderdataDal()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("id", "spiderdata");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from spiderdata");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@id", MySqlDbType.Int32)
            };
            parameters[0].Value = id;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(RESCommonModel.spiderdata model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into spiderdata(");
            strSql.Append("title,content,firstKind,secondKind,kindName,kindCode,insertTime,releaseTime,author,resource,coverImage,spiderUrl,browseCount,isRelease,isDelete,remark,applyplatform,ext1,ext2,ext3)");
            strSql.Append(" values (");
            strSql.Append("@title,@content,@firstKind,@secondKind,@kindName,@kindCode,@insertTime,@releaseTime,@author,@resource,@coverImage,@spiderUrl,@browseCount,@isRelease,@isDelete,@remark,@applyplatform,@ext1,@ext2,@ext3)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@title", MySqlDbType.VarChar,255),
                    new MySqlParameter("@content", MySqlDbType.LongText),
                    new MySqlParameter("@firstKind", MySqlDbType.VarChar,255),
                    new MySqlParameter("@secondKind", MySqlDbType.VarChar,255),
                    new MySqlParameter("@kindName", MySqlDbType.VarChar,45),
                    new MySqlParameter("@kindCode", MySqlDbType.VarChar,45),
                    new MySqlParameter("@insertTime", MySqlDbType.DateTime),
                    new MySqlParameter("@releaseTime", MySqlDbType.DateTime),
                    new MySqlParameter("@author", MySqlDbType.VarChar,45),
                    new MySqlParameter("@resource", MySqlDbType.VarChar,45),
                    new MySqlParameter("@coverImage", MySqlDbType.VarChar,255),
                    new MySqlParameter("@spiderUrl", MySqlDbType.VarChar,255),
                    new MySqlParameter("@browseCount", MySqlDbType.Int32,11),
                    new MySqlParameter("@isRelease", MySqlDbType.VarChar,2),
                    new MySqlParameter("@isDelete", MySqlDbType.VarChar,2),
                    new MySqlParameter("@remark", MySqlDbType.VarChar,255),
                    new MySqlParameter("@applyplatform", MySqlDbType.VarChar,255),
                    new MySqlParameter("@ext1", MySqlDbType.VarChar,255),
                    new MySqlParameter("@ext2", MySqlDbType.VarChar,255),
                    new MySqlParameter("@ext3", MySqlDbType.VarChar,255)};
            parameters[0].Value = model.title;
            parameters[1].Value = model.content;
            parameters[2].Value = model.firstKind;
            parameters[3].Value = model.secondKind;
            parameters[4].Value = model.kindName;
            parameters[5].Value = model.kindCode;
            parameters[6].Value = model.insertTime;
            parameters[7].Value = model.releaseTime;
            parameters[8].Value = model.author;
            parameters[9].Value = model.resource;
            parameters[10].Value = model.coverImage;
            parameters[11].Value = model.spiderUrl;
            parameters[12].Value = model.browseCount;
            parameters[13].Value = model.isRelease;
            parameters[14].Value = model.isDelete;
            parameters[15].Value = model.remark;
            parameters[16].Value = model.applyplatform;
            parameters[17].Value = model.ext1;
            parameters[18].Value = model.ext2;
            parameters[19].Value = model.ext3;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Update(RESCommonModel.spiderdata model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update spiderdata set ");
            strSql.Append("title=@title,");
            strSql.Append("content=@content,");
            strSql.Append("firstKind=@firstKind,");
            strSql.Append("secondKind=@secondKind,");
            strSql.Append("kindName=@kindName,");
            strSql.Append("kindCode=@kindCode,");
            strSql.Append("insertTime=@insertTime,");
            strSql.Append("releaseTime=@releaseTime,");
            strSql.Append("author=@author,");
            strSql.Append("resource=@resource,");
            strSql.Append("coverImage=@coverImage,");
            strSql.Append("spiderUrl=@spiderUrl,");
            strSql.Append("browseCount=@browseCount,");
            strSql.Append("isRelease=@isRelease,");
            strSql.Append("isDelete=@isDelete,");
            strSql.Append("remark=@remark,");
            strSql.Append("applyplatform=@applyplatform,");
            strSql.Append("ext1=@ext1,");
            strSql.Append("ext2=@ext2,");
            strSql.Append("ext3=@ext3");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@title", MySqlDbType.VarChar,255),
                    new MySqlParameter("@content", MySqlDbType.LongText),
                    new MySqlParameter("@firstKind", MySqlDbType.VarChar,255),
                    new MySqlParameter("@secondKind", MySqlDbType.VarChar,255),
                    new MySqlParameter("@kindName", MySqlDbType.VarChar,45),
                    new MySqlParameter("@kindCode", MySqlDbType.VarChar,45),
                    new MySqlParameter("@insertTime", MySqlDbType.DateTime),
                    new MySqlParameter("@releaseTime", MySqlDbType.DateTime),
                    new MySqlParameter("@author", MySqlDbType.VarChar,45),
                    new MySqlParameter("@resource", MySqlDbType.VarChar,45),
                    new MySqlParameter("@coverImage", MySqlDbType.VarChar,255),
                    new MySqlParameter("@spiderUrl", MySqlDbType.VarChar,255),
                    new MySqlParameter("@browseCount", MySqlDbType.Int32,11),
                    new MySqlParameter("@isRelease", MySqlDbType.VarChar,2),
                    new MySqlParameter("@isDelete", MySqlDbType.VarChar,2),
                    new MySqlParameter("@remark", MySqlDbType.VarChar,255),
                    new MySqlParameter("@applyplatform", MySqlDbType.VarChar,255),
                    new MySqlParameter("@ext1", MySqlDbType.VarChar,255),
                    new MySqlParameter("@ext2", MySqlDbType.VarChar,255),
                    new MySqlParameter("@ext3", MySqlDbType.VarChar,255),
                    new MySqlParameter("@id", MySqlDbType.Int32,11)};
            parameters[0].Value = model.title;
            parameters[1].Value = model.content;
            parameters[2].Value = model.firstKind;
            parameters[3].Value = model.secondKind;
            parameters[4].Value = model.kindName;
            parameters[5].Value = model.kindCode;
            parameters[6].Value = model.insertTime;
            parameters[7].Value = model.releaseTime;
            parameters[8].Value = model.author;
            parameters[9].Value = model.resource;
            parameters[10].Value = model.coverImage;
            parameters[11].Value = model.spiderUrl;
            parameters[12].Value = model.browseCount;
            parameters[13].Value = model.isRelease;
            parameters[14].Value = model.isDelete;
            parameters[15].Value = model.remark;
            parameters[16].Value = model.applyplatform;
            parameters[17].Value = model.ext1;
            parameters[18].Value = model.ext2;
            parameters[19].Value = model.ext3;
            parameters[20].Value = model.id;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from spiderdata ");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@id", MySqlDbType.Int32)
            };
            parameters[0].Value = id;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from spiderdata ");
            strSql.Append(" where id in (" + idlist + ")  ");
            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString());
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
        public RESCommonModel.spiderdata GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,title,content,firstKind,secondKind,kindName,kindCode,insertTime,releaseTime,author,resource,coverImage,spiderUrl,browseCount,isRelease,isDelete,remark,applyplatform,ext1,ext2,ext3 from spiderdata ");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@id", MySqlDbType.Int32)
            };
            parameters[0].Value = id;

            RESCommonModel.spiderdata model = new RESCommonModel.spiderdata();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
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
        public RESCommonModel.spiderdata DataRowToModel(DataRow row)
        {
            RESCommonModel.spiderdata model = new RESCommonModel.spiderdata();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["title"] != null)
                {
                    model.title = row["title"].ToString();
                }
                if (row["content"] != null)
                {
                    model.content = row["content"].ToString();
                }
                if (row["firstKind"] != null)
                {
                    model.firstKind = row["firstKind"].ToString();
                }
                if (row["secondKind"] != null)
                {
                    model.secondKind = row["secondKind"].ToString();
                }
                if (row["kindName"] != null)
                {
                    model.kindName = row["kindName"].ToString();
                }
                if (row["kindCode"] != null)
                {
                    model.kindCode = row["kindCode"].ToString();
                }
                if (row["insertTime"] != null && row["insertTime"].ToString() != "")
                {
                    model.insertTime = DateTime.Parse(row["insertTime"].ToString());
                }
                if (row["releaseTime"] != null && row["releaseTime"].ToString() != "")
                {
                    model.releaseTime = DateTime.Parse(row["releaseTime"].ToString());
                }
                if (row["author"] != null)
                {
                    model.author = row["author"].ToString();
                }
                if (row["resource"] != null)
                {
                    model.resource = row["resource"].ToString();
                }
                if (row["coverImage"] != null)
                {
                    model.coverImage = row["coverImage"].ToString();
                }
                if (row["spiderUrl"] != null)
                {
                    model.spiderUrl = row["spiderUrl"].ToString();
                }
                if (row["browseCount"] != null && row["browseCount"].ToString() != "")
                {
                    model.browseCount = int.Parse(row["browseCount"].ToString());
                }
                if (row["isRelease"] != null)
                {
                    model.isRelease = row["isRelease"].ToString();
                }
                if (row["isDelete"] != null)
                {
                    model.isDelete = row["isDelete"].ToString();
                }
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
                }
                if (row["applyplatform"] != null)
                {
                    model.applyplatform = row["applyplatform"].ToString();
                }
                if (row["ext1"] != null)
                {
                    model.ext1 = row["ext1"].ToString();
                }
                if (row["ext2"] != null)
                {
                    model.ext2 = row["ext2"].ToString();
                }
                if (row["ext3"] != null)
                {
                    model.ext3 = row["ext3"].ToString();
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
            strSql.Append("select id,title,content,firstKind,secondKind,kindName,kindCode,insertTime,releaseTime,author,resource,coverImage,spiderUrl,browseCount,isRelease,isDelete,remark,applyplatform,ext1,ext2,ext3 ");
            strSql.Append(" FROM spiderdata ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得数据列表分类
        /// </summary>
        public DataSet GetSpiderKind(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  ");
            strSql.Append(" FROM spiderdatakind ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM spiderdata ");
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
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex,string isContent)
        {
            StringBuilder strSql = new StringBuilder();
            if (!string.IsNullOrEmpty(isContent))
            {
                strSql.Append("SELECT id,title,resource,releaseTime,LEFT(content,50) as content FROM spiderdata");
            }
            else {
                strSql.Append("SELECT id,title,resource,releaseTime FROM spiderdata");
            }
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }

            strSql.AppendFormat(" limit {0},{1}", startIndex, endIndex);
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			MySqlParameter[] parameters = {
					new MySqlParameter("@tblName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@fldName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@PageSize", MySqlDbType.Int32),
					new MySqlParameter("@PageIndex", MySqlDbType.Int32),
					new MySqlParameter("@IsReCount", MySqlDbType.Bit),
					new MySqlParameter("@OrderType", MySqlDbType.Bit),
					new MySqlParameter("@strWhere", MySqlDbType.VarChar,1000),
					};
			parameters[0].Value = "spiderdata";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

