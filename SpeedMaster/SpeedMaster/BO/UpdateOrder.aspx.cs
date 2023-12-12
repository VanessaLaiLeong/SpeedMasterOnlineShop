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
            if (!IsPostBack)
            {
                int id_order = Convert.ToInt32(Request.QueryString["id_order"]);

                DataTable dt = Connections.GetDataTableFromQuery($"Select ID_Order, o.ID_ShoppingCart, OrderDate, ShippingDate, TotalAmount, ID_OrderStatus, Email " +
                    $"                                              from Orders o " +
                    $"                                              inner join ShoppingCarts sc on o.ID_ShoppingCart = sc.ID_ShoppingCart " +
                    $"                                              inner join Customers c on sc.ID_Customer = c.ID_Customer " +
                    $"                                              where ID_Order = {id_order}");

                Session["ID_shoppingcart"] = Convert.ToInt32(dt.Rows[0]["ID_ShoppingCart"]);
                tb_email.Text = dt.Rows[0]["Email"].ToString();
                lb_OrderDate.Text = dt.Rows[0]["OrderDate"].ToString();
                tb_ShippingDate.Text = dt.Rows[0]["ShippingDate"].ToString();
                tb_TotalAmount.Text = dt.Rows[0]["TotalAmount"].ToString();
                int orderstatus = Convert.ToInt32(dt.Rows[0]["ID_OrderStatus"]);
                ddl_orderStatus.SelectedValue = orderstatus.ToString();
            }
        }

        protected void btn_enviarMail_Click(object sender, EventArgs e)
        {
            Services.askReview(Convert.ToInt32(Request.QueryString["id_order"]), 4);
        }

        protected void btn_submit_Click1(object sender, EventArgs e)
        {
            int ID_Order = Convert.ToInt32(Request.QueryString["id_order"]);
            int ID_shoppingcart = Convert.ToInt32(Session["ID_ShoppingCart"]);
            DateTime OrderDate = DateTime.Parse(lb_OrderDate.Text);
            string shippingDate = tb_ShippingDate.Text;
            decimal totalAmount = Convert.ToDecimal(tb_TotalAmount.Text);
            int status = Convert.ToInt32(ddl_orderStatus.SelectedValue);

            Response.Write(Connections.UpdateOrderInDB(
                ID_Order,
                ID_shoppingcart,
                OrderDate,
                shippingDate,
                totalAmount,
                status
                ));
        }
    }
}