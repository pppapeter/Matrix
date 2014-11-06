using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;

namespace Maticsoft.Web
{
    /// <summary>
    /// Summary description for LocUpdate
    /// </summary>
    public class LocUpdate : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //string autoid = context.Request.Form["autoid"];
            string userid = context.Request.QueryString["userid"];
             
            // get all poi info
            BLL.user_loc userLoc = new BLL.user_loc();
            DataSet dsList = userLoc.GetAllList();
            string strList = JsonConvert.SerializeObject(dsList.Tables[0]);

            // get pois' count
            int poiCnt = dsList.Tables[0].Rows.Count;

            // generate json string
            StringWriter sw = new StringWriter();
            JsonWriter writer = new JsonTextWriter(sw);

            writer.WriteStartObject();
            writer.WritePropertyName("version");
            writer.WriteValue("1.0.0");
            writer.WritePropertyName("total");
            writer.WriteValue(poiCnt);
            writer.WritePropertyName("pois");
            // write raw value of datatable avoid "/" in json
            writer.WriteRawValue(strList);
            writer.WriteEndObject();
            writer.Flush();

            string jsonText = sw.GetStringBuilder().ToString();

            context.Response.ContentType = "text/json";
            context.Response.Write(jsonText);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}