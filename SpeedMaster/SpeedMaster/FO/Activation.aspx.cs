using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpeedMaster.FO
{
    public partial class Activation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         
            string email = Services.DecryptString(Request.QueryString["email"]);
            Connections.activateCustomerAccount(email);
            //Response.Write("Success!");
            //funciona
        }
    }
}