using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Agric.Model;
using RESCommonBll;
using RESCommonModel;

namespace RESCommonAPP.api
{
    public class NYAnswerAPIController : ApiController
    {
        RESCommonBll.spiderdataBll resbll = new RESCommonBll.spiderdataBll();
        /// <summary>
        /// kindName--几级导航之间按“:”分割  
        /// </summary>
        /// <param name="kindName"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public resultList GetInfoList(string kindName, string pageSize = "10", string pageIndex = "1")
        {
            resultList model = new resultList();
            PagerArg pagerArg = new PagerArg();
            pagerArg.PageSize = Convert.ToInt32(pageSize);
            pagerArg.CurrentPageNo = Convert.ToInt32(pageIndex);
            if (kindName.Contains(":"))
            {
                int count = kindName.Split(':').Count();
                if (count == 3)//说明查的是详细列表
                {
                    List<resultData> rdlist = new List<resultData>();
                    string where = string.Format("  firstKind='{0}' and secondKind='{1}' and kindName='{2}' ", kindName.Split(':')[0], kindName.Split(':')[1], kindName.Split(':')[2]);
                    List<spiderDataLite> sdl = new List<spiderDataLite>();
                    pagerArg.TotalCount = resbll.GetRecordCount(where);
                    DataSet reDs = resbll.GetListByPage(where, " releaseTime desc ", pagerArg.CurrentPageNo - 1, pagerArg.PageSize, "");
                    if (reDs.Tables.Count > 0)
                    {
                        foreach (DataRow dr in reDs.Tables[0].Rows)
                        {
                            sdl.Add(new spiderDataLite()
                            {
                                content = "",
                                id = dr["id"].ToString(),
                                releaseTime = dr["releaseTime"].ToString(),
                                resource = dr["resource"].ToString(),
                                title = dr["title"].ToString(),

                            });
                        }
                        resultData rdModel = new resultData();
                        rdModel.kindName = kindName.Split(':')[2];
                        rdModel.rd = sdl;
                        rdlist.Add(rdModel);
                        model.flag = "1";
                        model.totalCount = pagerArg.TotalCount.ToString();
                        model.data = rdlist;
                    }

                }
                else//获取该分类下多个分类的固定三条数据
                {
                    List<string> kindList = new List<string>();
                    DataSet ds = resbll.GetSpiderKind(string.Format(" firstKind='{0}' and secondKind='{1}'", kindName.Split(':')[0], kindName.Split(':')[1]));
                    if (ds.Tables.Count > 0)
                    {
                        DataTable dtKind = ds.Tables[0];
                        foreach (DataRow dr in dtKind.Rows)
                        {
                            kindList.Add(dr["kindName"].ToString());
                        }
                    }
                    List<resultData> rdlist = new List<resultData>();

                    foreach (string item in kindList)
                    {

                        string where = string.Format("  firstKind='{0}' and secondKind='{1}' and kindName='{2}' limit 3", kindName.Split(':')[0], kindName.Split(':')[1], item);
                        List<spiderdata> list = resbll.GetModelList(where);

                        foreach (spiderdata item1 in list)
                        {
                            List<spiderDataLite> sdl = new List<spiderDataLite>();
                            resultData sdModel = new resultData();
                            string contentlite = Agric.Common.Extention.NoHTML(item1.content);
                            if (contentlite.Length > 50)
                            {
                                contentlite = contentlite.Substring(0, 50);
                            }
                            sdl.Add(new spiderDataLite()
                            {
                                content = contentlite,
                                id = item1.id.ToString(),
                                releaseTime = item1.releaseTime.ToString(),
                                resource = item1.resource,
                                title = item1.title
                            });
                            sdModel.kindName = item;
                            sdModel.rd = sdl;
                            rdlist.Add(sdModel);
                        }
                    }

                    #region 查询对应的图书视频
                    NYAnswerBll nybll = new NYAnswerBll();
                    //图书
                    string where1 = string.Format(" 一级分类={0} and 二级分类={1}", kindName.Split(':')[0], kindName.Split(':')[1]);
                    List<string> cacbKindList = nybll.GetKind(where1, "cacb");
                    foreach (string item2 in cacbKindList)
                    {
                        List<spiderDataLite> sdl = new List<spiderDataLite>();
                        resultData sdModel = new resultData();
                        sdl.Add(new spiderDataLite()
                        {
                            content = "http://sxnbook.cnki.net/cacbweb/fm/" + item2 + ".jpg",
                            id = item2,

                        });
                        sdModel.kindName = "图书推荐";
                        sdModel.rd = sdl;
                        rdlist.Add(sdModel);
                    }
                    //视频
                    List<string> cacvKindList = nybll.GetKind(where1, "cacv");
                    string codeStr = "";
                    foreach (string item in cacvKindList)
                    {
                        codeStr += item + "+";
                    }
                    List<cacvlistModel> cacvList = nybll.GetCacvList(string.Format(" 节目编号={0}", codeStr.Substring(0, codeStr.Length - 1)));
                    #endregion
                    foreach (cacvlistModel item3 in cacvList)
                    {
                        List<spiderDataLite> sdl = new List<spiderDataLite>();
                        resultData sdModel = new resultData();
                        sdl.Add(new spiderDataLite()
                        {
                            content = "http://cacv.cnki.net/Content/CACV/FM/" + item3.code.Substring(0, 8) + "/" + item3.code + ".jpg",
                            id = item3.code,
                            title = item3.title
                        });
                        sdModel.kindName = "视频观看";
                        sdModel.rd = sdl;
                        rdlist.Add(sdModel);
                    }

                    model.flag = "1";
                    model.totalCount = "0";
                    model.data = rdlist;
                }
            }
            return model;
        }
        /// <summary>
        /// 获取详情
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        public void GetInfoDetail(string id, string type)
        {
            NYAnswerBll nybll = new NYAnswerBll();
            detailModel model = new detailModel();
            if (type == "spider")//说明是抓取的数据(mysql中查找)
            {
                spiderdata smodel = resbll.GetModel(Convert.ToInt32(id));
                model.title = smodel.title;
                model.content = smodel.content;
                model.code = smodel.id.ToString();
                model.releaseTime = smodel.releaseTime.ToString();
                model.resource = smodel.resource;
            }
            else if (type == "cacv")//视频
            {
                model = nybll.GetContent(string.Format(" 节目编号={0}", id));
            }
            else if (type == "cacb")//图书
            {

            }
        }
    }
    public class spiderDataLite
    {
        public string id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string releaseTime { get; set; }
        public string resource { get; set; }

    }
    public class resultList
    {
        public string flag { get; set; }
        public string totalCount { get; set; }
        public List<resultData> data { get; set; }
    }
    public class resultData
    {
        public string kindName { get; set; }
        public List<spiderDataLite> rd { get; set; }
    }
    public class spiderModel
    {
        public string firstKind { get; set; }
        public string secondKind { get; set; }
        public string kindName { get; set; }
    }
}
