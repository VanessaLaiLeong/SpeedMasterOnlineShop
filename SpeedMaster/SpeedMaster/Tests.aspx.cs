using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpeedMaster
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Services s = new Services();            
            Session["customer"]= s.getCustomer(1);
            lbl_name.Text = ((Customer)Session["customer"]).firstName;
            Customer customer = s.createCustomer("coydecerta@gufum.com", "P@ssw0rd", "Ana", "Pires", "", "", "");
            int result;
            string v = s.doCreateCustomer(customer, "P@ssw0rd");
            Response.Write(v);
            
        }

        
    }
}