using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpeedMaster.FO
{
    public partial class FOMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["customer"] != null)
            {
                string name = ((Customer)Session["customer"]).firstName;
                lbl_customer.Text = $"Bem vindo, {name}";
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedIndex == 1)
            {
                Response.Redirect("ShopMotorcycle.aspx");
            }
        }

        

        protected void shoppingcartnav_Click(object sender, EventArgs e)
        {

        }

        protected void lkbtn_user_Click1(object sender, EventArgs e)
        {
            if (Session["customer"] != null)
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}