﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
namespace Maticsoft.Web.user_loc
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					strid = Request.Params["id"];
					int autoid=(Convert.ToInt32(strid));
					ShowInfo(autoid);
				}
			}
		}
		
	private void ShowInfo(int autoid)
	{
		Maticsoft.BLL.user_loc bll=new Maticsoft.BLL.user_loc();
		Maticsoft.Model.user_loc model=bll.GetModel(autoid);
		this.lblautoid.Text=model.autoid.ToString();
		this.lbluserid.Text=model.userid;
		this.lbllat.Text=model.lat;
		this.lbllon.Text=model.lon;
		this.lblsystime.Text=model.systime.ToString();

	}


    }
}
