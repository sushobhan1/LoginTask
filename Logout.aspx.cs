using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DemoInfo.Security;

namespace DemoInfo
{
    public partial class Logout : System.Web.UI.Page
    {
        private Securities securities;
        protected void Page_Load(object sender, EventArgs e)
        {
            securities = new Securities();
            // Logout user
            securities.Logout();
            // Redirect to login page
            Response.Redirect("~/Login.aspx");
        }
    }
}