using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpeedMaster.FO
{
    public partial class SendEmailResetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_sendEmail_Click(object sender, EventArgs e)
        {
            string emai = ((Customer)Session["customer"]).email;

            //Services.sendEmail(email, subject, body)
        }
    }
}