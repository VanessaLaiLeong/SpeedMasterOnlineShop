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
        }

        private int getSalesCount()
        {
            int count = 0;
            DataTable dt = Connections.GetDataTableFromQuery("SELECT * FROM Payments;");

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
                                                               FROM Payments 
                                                               INNER JOIN Orders on
                                                               Payments.ID_Order = Orders.ID_Order;");

            foreach (DataRow dr in dt.Rows)
            {
                Response.Write(dr[0]);
                total += Convert.ToDecimal(dr[0].ToString());
            }
            return total;
        }
    }
}