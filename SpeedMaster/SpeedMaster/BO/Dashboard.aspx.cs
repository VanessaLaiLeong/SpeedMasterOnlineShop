using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpeedMaster.BO
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_quantSales.Text = getSalesCount().ToString();
            lbl_moneySales.Text = getSalesValueTotal().ToString() + "€";
            lbl_bikesSold.Text = getSalesMotorcyclesTotal().ToString();
            lbl_accessNumber.Text = getAccessTotal().ToString();
        }

        private int getSalesCount()
        {
            int count = 0;
            DataTable dt = Connections.GetDataTableFromQuery("SELECT * FROM Orders;");

            foreach (DataRow dr in dt.Rows)
            {
                count++;
            }

            return count;
        }

        private decimal getSalesValueTotal()
        {
            decimal total = 0;
            DataTable dt = Connections.GetDataTableFromQuery(@"SELECT Orders.TotalAmount
                                                               FROM Orders;");

            foreach (DataRow dr in dt.Rows)
            {
                total += Convert.ToDecimal(dr[0].ToString());
            }
            return total;
        }

        private int getSalesMotorcyclesTotal()
        {
            int total = 0;
            DataTable dt = Connections.GetDataTableFromQuery(@"select COUNT(*)
                                                               from Orders as ord
                                                               inner join ShoppingCarts    sc on sc.ID_ShoppingCart = ord.ID_ShoppingCart
                                                               inner join CartItems        ci on sc.ID_ShoppingCart = ci.ID_ShoppingCart
                                                               inner join GlobalProductIds gp on ci.ID_GlobalproductID = gp.ID_Product
                                                               where gp.ProductType = 'motorcycle'");

            foreach (DataRow dr in dt.Rows)
            {
                total += Convert.ToInt32(dr[0].ToString());
            }

            return total;
        }

        private int getAccessTotal()
        {
            int total = 0;
            DataTable dt = Connections.GetDataTableFromQuery(@"select  COUNT(*)
                                                               from Orders as ord
                                                               inner join ShoppingCarts    sc on sc.ID_ShoppingCart = ord.ID_ShoppingCart
                                                               inner join CartItems        ci on sc.ID_ShoppingCart = ci.ID_ShoppingCart
                                                               inner join GlobalProductIds gp on ci.ID_GlobalproductID = gp.ID_Product
                                                               where gp.ProductType = 'accessories'");

            foreach (DataRow dr in dt.Rows)
            {
                total += Convert.ToInt32(dr[0].ToString());
            }

            return total;

        }
    }
}