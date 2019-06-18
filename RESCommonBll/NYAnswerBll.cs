using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPI;
using Agric.Common;
using Agric.Model;

using System.Configuration;
using RESCommonModel;

namespace RESCommonBll
{
    public class NYAnswerBll
    {
        static string kbaseIP = ConfigurationManager.AppSettings["kbaseIP"];
        public List<string> GetKind(string where, string tableType)
        {
            //获得导航Model
            string TypeSql = string.Format("SELECT 节目编号 FROM {0} ", tableType);
            if (!string.IsNullOrEmpty(where))
            {
                if (tableType == "cacv")
                {
                    TypeSql += string.Format(" where {0} limit 3", where);
                }
                else {
                    TypeSql += string.Format(" where {0} limit 4", where);
                }

            }
            //获得typemodellist列表
            //连接数据库
            Client client2 = new Client();


            if (!client2.Connect(kbaseIP, 4567, "DBOWN", string.Empty))
            {
                client2.Close();

            }
            RecordSet recordSet_Type = client2.OpenRecordSet(TypeSql);
            List<string> list = new List<string>();

            if (recordSet_Type != null && recordSet_Type.GetCount() > 0)
            {
                int FieldCount = recordSet_Type.GetFieldCount();

                while (!recordSet_Type.IsEOF() && FieldCount > 0)
                {

                    string jmcode = recordSet_Type.GetValue(0);
                 
                    list.Add(jmcode);
                    recordSet_Type.MoveNext();
                }
                recordSet_Type.Close();

            }
            return list;



        }
        public List<cacvlistModel> GetCacvList(string where)
        {

            //获得导航Model
            string TypeSql = string.Format("SELECT 节目编号,节目名称 FROM CACV");
        
            if (!string.IsNullOrEmpty(where))
            {
                TypeSql += string.Format(" where {0}", where);
           
            }
            //获得typemodellist列表
            //连接数据库
            Client client2 = new Client();


            if (!client2.Connect(kbaseIP, 4567, "DBOWN", string.Empty))
            {
                client2.Close();

            }
           
            RecordSet recordSet_Type = client2.OpenRecordSet(TypeSql);

            List<cacvlistModel> list = new List<cacvlistModel>();


            if (recordSet_Type != null && recordSet_Type.GetCount() > 0)
            {
                int FieldCount = recordSet_Type.GetFieldCount();

                while (!recordSet_Type.IsEOF() && FieldCount > 0)
                {
                    cacvlistModel model = new cacvlistModel();
                    model.code = recordSet_Type.GetValue(0);
                  
                    model.title = recordSet_Type.GetValue(1);
                    list.Add(model);
                }
                recordSet_Type.Close();

            }
            return list;
        }
        public detailModel GetContent(string where)
        {
            detailModel model = new detailModel();
            //获得导航Model
            string TypeSql = string.Format("SELECT 节目编号,节目名称,节目简介 FROM CACV");

            if (!string.IsNullOrEmpty(where))
            {
                TypeSql += string.Format(" where {0}", where);

            }
            //获得typemodellist列表
            //连接数据库
            Client client2 = new Client();


            if (!client2.Connect(kbaseIP, 4567, "DBOWN", string.Empty))
            {
                client2.Close();

            }

            RecordSet recordSet_Type = client2.OpenRecordSet(TypeSql);

         

            if (recordSet_Type != null && recordSet_Type.GetCount() > 0)
            {
                int FieldCount = recordSet_Type.GetFieldCount();

                while (!recordSet_Type.IsEOF() && FieldCount > 0)
                {
                 
                    model.code = recordSet_Type.GetValue(0);

                    model.title = recordSet_Type.GetValue(1);
                    model.content= recordSet_Type.GetValue(2);
                    model.path = "http://rtsp.cnki.net/"+model.code.Substring(0,model.code.Length-1)+"/"+ model.code + ".mp4";
                }
                recordSet_Type.Close();

            }
            return model;
        }
    }
}
