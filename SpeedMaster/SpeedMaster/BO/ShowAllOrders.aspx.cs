using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpeedMaster.BO
{
    public partial class ShowAllOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                return;
            }
        }

        protected void rp_orders_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            DataRowView dr = (DataRowView)e.Item.DataItem;
            ((Label)e.Item.FindControl("lbl_idOrder")).Text = dr["ID_Order"].ToString();
            ((Label)e.Item.FindControl("lbl_orderDate")).Text = dr["OrderDate"].ToString();
            ((Label)e.Item.FindControl("lbl_shippingDate")).Text = dr["ShippingDate"].ToString();
            ((Label)e.Item.FindControl("lbl_totalAmount")).Text = dr["TotalAmount"].ToString();
            ((Label)e.Item.FindControl("lbl_statusName")).Text = dr["StatusName"].ToString();
        }

        protected void btn_edit_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string id_order = button.CommandArgument.ToString();
            Response.Redirect($"UpdateOrder.aspx?id_order={id_order}");
        }
    }
}