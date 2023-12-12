using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace SpeedMaster.FO
{
    public partial class userProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["customer"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            lbl_primeironome.Text = ((Customer)Session["customer"]).firstName;
            lbl_Sobrenome.Text = ((Customer)Session["customer"]).lastName;
            lbl_email.Text = ((Customer)Session["customer"]).email;
            lbl_Phone.Text = ((Customer)Session["customer"]).phone;
        }

        protected void Change_Password_Click(object sender, EventArgs e)
        {
            if (Session["customer"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Response.Redirect("SendEmailResetPassword.aspx");
            }
        }
    }
}