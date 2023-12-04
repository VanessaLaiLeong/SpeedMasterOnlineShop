using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpeedMaster.BO
{
    public partial class InsertCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            Session["email"] = "user@example.com";
            Session["password"] = "securePassword";
            Session["firstName"] = "John";
            Session["lastName"] = "Doe";
            Session["phone"] = "1234567890";
            Session["address"] = "123 Main St";
            Session["nif"] = "123456789";
            Session["otherPassword"] = "securePassword"; // Make sure this matches the password above

            string result = Services.doCreateCustomer(
                Session["email"].ToString(),
                Session["password"].ToString(),
                Session["firstName"].ToString(),
                Session["lastName"].ToString(),
                Session["phone"].ToString(),
                Session["address"].ToString(),
                Session["nif"].ToString(),
                Session["otherPassword"].ToString()
            );
        }
    }
}