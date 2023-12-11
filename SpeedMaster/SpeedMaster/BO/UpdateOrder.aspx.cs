using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpeedMaster.BO
{
    public partial class UpdateOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id_order = Convert.ToInt32(Request.QueryString["id_order"]);
            string query = @"select *
                             from Orders as o
                             inner join OrderStatus as s
                             on o.ID_OrderStatus = s.ID_OrderStatus
                             WHERE ID_Order = " + id_order + ";";

            DataTable dt = Connections.GetDataTableFromQuery(query);

            int shopping_cart_id = (int)dt.Rows[0]["ID_ShoppingCart"];
            DateTime order_date = DateTime.Parse(dt.Rows[0]["OrderDate"].ToString());
            decimal totalAmount = (decimal)dt.Rows[0]["TotalAmount"];
            string shipping_date = dt.Rows[0]["ShippingDate"].ToString();
            int id_orderStatus = dp_orderStatus.SelectedIndex;

            tb_orderDate.Text = order_date.ToString();
            tb_ShippingDate.Text = shipping_date.ToString();
            tb_totalAmount.Text = totalAmount.ToString();
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            int id_order = Convert.ToInt32(Request.QueryString["id_order"]);
            string query = @"select *
                             from Orders as o
                             inner join OrderStatus as s
                             on o.ID_OrderStatus = s.ID_OrderStatus
                             WHERE ID_Order = " + id_order + ";";

            DataTable dt = Connections.GetDataTableFromQuery(query);

            int shopping_cart_id = (int)dt.Rows[0]["ID_ShoppingCart"];
            DateTime order_date = DateTime.Parse(dt.Rows[0]["OrderDate"].ToString());
            decimal totalAmount = (decimal)dt.Rows[0]["TotalAmount"];
            string shipping_date = dt.Rows[0]["ShippingDate"].ToString();
            int id_orderStatus = dp_orderStatus.SelectedIndex;

            tb_orderDate.Text = order_date.ToString();
            tb_ShippingDate.Text = shipping_date.ToString();
            tb_totalAmount.Text = totalAmount.ToString();

            string debug_con = Connections.UpdateOrderInDB(
                id_order,
                shopping_cart_id,
                DateTime.Parse(tb_orderDate.Text),
                tb_ShippingDate.Text,
                Convert.ToDecimal(tb_totalAmount.Text),
                id_orderStatus
            );
            lbl_debug.Text = debug_con;
        }
    }
}