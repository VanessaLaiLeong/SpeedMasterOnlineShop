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
            Response.Write(Services.DecryptString("mL4uefDJyC2Yb1LvMOw9vA=="));
            //string res = doLogin("jerdebastu@gufum.com", pass);
            
            //Response.Write(res);
            //Response.Write(((Customer)Session["customer"]).email);
            //a logica funciona
        }

        private string doLogin(string email, string password)
        {
            int result = Connections.LoginCustomer(email, Services.EncryptString(password));
            if (result == -1)
            {
                return "Account not active. Please check email to activate";
            }
            if (result == 0)
            {
                return "Wrong credentials!";
            }
            else
            {
                Session["customer"] = Services.getCustomer(result);
                return result.ToString();
            }
        }
        //para teste
        

        protected void btn_signin_Click(object sender, EventArgs e)
        {
            doLogin(tb_email.Text, tb_password.Text);
            Response.Redirect("ShopMotorcycle.aspx");
        }
    }
}