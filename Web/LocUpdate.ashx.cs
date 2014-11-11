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
            string userlat = context.Request.QueryString["userlat"];
            string userlon = context.Request.QueryString["userlon"];
            string timespan = context.Request.QueryString["timespan"];

            // get all poi info
            BLL.user_loc userLoc = new BLL.user_loc();
            List<Model.user_loc> listUser = userLoc.GetModelList("userid='" + userid + "'");

            if (listUser.Count > 0)
            {
                Model.user_loc mUser = listUser[0];
                mUser.lon = userlon;
                mUser.lat = userlat;
                mUser.systime = DateTime.Now;
                userLoc.Update(mUser);
            }
            else
            {
                userLoc.Add(new Model.user_loc { userid = userid, lat = userlat, lon = userlon, systime = DateTime.Now });
            }

            DataSet dsList = userLoc.GetList("userid <> '" + userid + "'", DateTime.Now, timespan);
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