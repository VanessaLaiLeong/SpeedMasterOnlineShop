using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpeedMaster.FO
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btn_signin_Click1(object sender, EventArgs e)
        {
            string email = tb_email.Text;
            string password = tb_password.Text;

            int result = Connections.LoginCustomer(email, Services.EncryptString(password));
            if (result == -1)
            {
                lbl_mensagem.Visible = true;
                lbl_mensagem.Text = "Account not active. Please check email to activate";
            }
            else if (result == 0)
            {
                lbl_mensagem.Visible = true;
                lbl_mensagem.Text = "Wrong credentials!";
            }
            else
            {
                Session["customer"] = Services.getCustomer(result);

                Response.Redirect("ShopMotorcycle.aspx");
            }
        }

    }
}