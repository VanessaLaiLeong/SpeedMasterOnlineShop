using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpeedMaster.FO
{
    public partial class checkEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           lbl_result.Text = Convert.ToString(Session["message"]);
        }
    }
}