using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpeedMaster.FO
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            string email = Services.DecryptString(Request.QueryString["email"]);
            string resul = Services.resetPassword(email, tb_password.Text, tb_otherPassword.Text);
            lbl_message.Text = resul;
            lbl_message.Visible = true;

        }
    }
}