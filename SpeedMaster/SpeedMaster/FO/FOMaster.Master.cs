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
                lbl_customer.Visible = true;
                lbl_customer.Text = $"Bem vindo, {name}";
                shoppingcartnav.Visible = true;
                logout_button.Visible = true;
            }
            else
            {
                lbl_customer.Visible = false;
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (DropDownList1.SelectedIndex == 1)
            //{
            //    Response.Redirect("ShopMotorcycle.aspx");
            //}
        }

        

        protected void shoppingcartnav_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShoppingCart.aspx");
        }

        protected void lkbtn_user_Click1(object sender, EventArgs e)
        {
            if (Session["customer"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Response.Redirect("userProfile.aspx");
            }
        }

        protected void logout_button_Click(object sender, EventArgs e)
        {
            Session["customer"] = null;
            Response.Redirect("Home.aspx");
        }
    }
}