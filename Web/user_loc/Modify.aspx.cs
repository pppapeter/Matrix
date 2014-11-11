using System;
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
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace Maticsoft.Web.user_loc
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int autoid=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(autoid);
				}
			}
		}
			
	private void ShowInfo(int autoid)
	{
		Maticsoft.BLL.user_loc bll=new Maticsoft.BLL.user_loc();
		Maticsoft.Model.user_loc model=bll.GetModel(autoid);
		this.lblautoid.Text=model.autoid.ToString();
		this.txtuserid.Text=model.userid;
		this.txtlat.Text=model.lat;
		this.txtlon.Text=model.lon;
		this.txtsystime.Text=model.systime.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtuserid.Text.Trim().Length==0)
			{
				strErr+="userid不能为空！\\n";	
			}
			if(this.txtlat.Text.Trim().Length==0)
			{
				strErr+="lat不能为空！\\n";	
			}
			if(this.txtlon.Text.Trim().Length==0)
			{
				strErr+="lon不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtsystime.Text))
			{
				strErr+="systime格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int autoid=int.Parse(this.lblautoid.Text);
			string userid=this.txtuserid.Text;
			string lat=this.txtlat.Text;
			string lon=this.txtlon.Text;
			DateTime systime=DateTime.Parse(this.txtsystime.Text);


			Maticsoft.Model.user_loc model=new Maticsoft.Model.user_loc();
			model.autoid=autoid;
			model.userid=userid;
			model.lat=lat;
			model.lon=lon;
			model.systime=systime;

			Maticsoft.BLL.user_loc bll=new Maticsoft.BLL.user_loc();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
