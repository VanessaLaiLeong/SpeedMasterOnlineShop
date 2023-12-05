using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpeedMaster.BO
{
    public partial class ShowCustomerDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["ID_Customer"] = (Convert.ToInt32(Request.QueryString["customerId"]));
            printCustomer();
            Response.Write(Convert.ToString(Session["customerFirstName"]));
            
        }

        private void printCustomer()
        {
            Customer customer = new Customer();

            customer = Services.getCustomer(Convert.ToInt32(Session["ID_Customer"]));
            Session["customerEmail"] = customer.email;
            Session["customerFirstName"] = customer.firstName;
            Session["customerLastName"] = customer.lastName;
            Session["customerPassword"] = customer.password;
            Session["customerAddress"] = customer.address;
            Session["customerPhone"] = customer.phone;
            Session["customerActive"] = customer.active;
            Session["customerNIF"] = customer.nif;

        }

        private void codigoBotaoEdit()
        {
            Response.Redirect($"UpdateCustomerDetails.aspx?customerId={Session["ID_Customer"]}");
        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            Response.Redirect($"UpdateCustomerDetails.aspx?customerId={Session["ID_Customer"]}");
        }
    }
}