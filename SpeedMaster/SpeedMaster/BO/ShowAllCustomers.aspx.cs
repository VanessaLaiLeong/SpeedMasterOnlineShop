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
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView dr = (DataRowView)e.Item.DataItem;
                ((Label)e.Item.FindControl("lbl_customerName")).Text = dr["FirstName"].ToString();
                //((Label)e.Item.FindControl("lbl_quantity")).Text = dr["Quantity"].ToString();
                //((Label)e.Item.FindControl("lbl_price")).Text = dr["Price"].ToString();
                //if (dr["Active"].ToString() == "True")
                //{
                //    ((Label)e.Item.FindControl("lbl_status")).Text = "Active";
                //}
                //else ((Label)e.Item.FindControl("lbl_status")).Text = "Inactive";
            }
            
        }

        protected void viewDetail_Click(object sender, EventArgs e)
        {
            LinkButton button = (LinkButton)sender;
            string customerId = button.CommandArgument;            
            Response.Redirect($"ShowCustomerDetails.aspx?customerId={customerId}");
        }

        protected void delete_Click(object sender, EventArgs e)
        {

        }

        
    }
}