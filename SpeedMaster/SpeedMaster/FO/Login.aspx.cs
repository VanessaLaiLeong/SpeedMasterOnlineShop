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
            //string res = doLogin("jerdebastu@gufum.com", "P@ssw0rd123");
            //Response.Write(res);
            //Response.Write(((Customer)Session["customer"]).email);
            //a logica funciona
        }

        //private string doLogin(string email, string password)
        //{
            

        //    int result = Connections.LoginCustomer(email, Services.EncryptString(password));
        //    if (result == -1) 
        //    {
        //        return "Account not active. Please check email to activate";
        //    }
        //    if (result == 0)
        //    {
        //        return "Wrong credentials!";
        //    }
        //    else
        //    {
        //        Session["customer"]=Services.getCustomer(result);
        //        return result.ToString();
        //    }
        //}
    }
}