using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpeedMaster.FO
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            string res = Services.doCreateCustomer("jerdebastu@gufum.com", "P@ssw0rd", "Nome1", "", "", "", "", "P@ssw0rd");
           
            Response.Write(res);

            //logica funciona
        }
    }
}