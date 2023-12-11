using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpeedMaster.BO
{
    public partial class ShowAllCustomers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            DataRowView dr = (DataRowView)e.Item.DataItem;
            ((Label)e.Item.FindControl("lbl_customerName")).Text = dr["FirstName"].ToString() + " " + dr["LastName"].ToString();
            ((Label)e.Item.FindControl("lbl_email")).Text = dr["Email"].ToString();
            ((Label)e.Item.FindControl("lbl_address")).Text = dr["Address"].ToString();
            ((Label)e.Item.FindControl("lbl_phone")).Text = dr["Phone"].ToString();
            ((Label)e.Item.FindControl("lbl_NIF")).Text = dr["NIF"].ToString();
        }

        protected void viewDetail_Click(object sender, EventArgs e)
        {
            LinkButton button = (LinkButton)sender;
            string customerId = button.CommandArgument;            
            Response.Redirect($"ShowCustomerDetails.aspx?customerId={customerId}");
        }

        protected void delete_Click(object sender, EventArgs e)
        {
            LinkButton button = (LinkButton)sender;
            int customerId = Convert.ToInt32(button.CommandArgument);
            Connections.DeleteCustomerDB(customerId);
        }

        
    }
}