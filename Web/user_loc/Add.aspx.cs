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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
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

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string userid=this.txtuserid.Text;
			string lat=this.txtlat.Text;
			string lon=this.txtlon.Text;

			Maticsoft.Model.user_loc model=new Maticsoft.Model.user_loc();
			model.userid=userid;
			model.lat=lat;
			model.lon=lon;

			Maticsoft.BLL.user_loc bll=new Maticsoft.BLL.user_loc();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
