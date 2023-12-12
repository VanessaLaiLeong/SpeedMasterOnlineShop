using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpeedMaster.BO
{
    public partial class UpdateProductDetailAccessory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["ID_Accessory"] = Convert.ToInt32(Request.QueryString["access_id"]);
                int access_id = Convert.ToInt32(Request.QueryString["access_id"].ToString());
                DataTable dt = Connections.GetDataTableFromQuery($"select * from Accessories where ID_Accessory = {access_id}");
                in_name.Text = dt.Rows[0]["AccessoryName"].ToString();
                in_description.Text = dt.Rows[0]["Description"].ToString();
                in_price.Text = dt.Rows[0]["Price"].ToString();
                in_stock.Text = Convert.ToInt32(dt.Rows[0]["Price"]).ToString();
                if (dt.Rows[0]["Active"].ToString() == "True")
                {
                    rd_active.SelectedValue = "yes";
                }
                else rd_active.SelectedValue = "no";

            }

        }

        protected void update_Click(object sender, EventArgs e)
        {
            byte[] img = Services.getImageInfo(fu_access);
            int active;

            if (rd_active.SelectedValue == "yes")
            {
                active = 1;
            }
            else active = 0;

            int ID_Accessory = Convert.ToInt32(Request.QueryString["access_id"]);
            string name = in_name.Text;
            string description = in_description.Text;
            double price = Convert.ToDouble(in_price.Text);
            int stock = int.Parse(in_stock.Text);
            int category = Convert.ToInt32(dp_category.SelectedValue);

            Response.Write(Connections.UpdateAccessoryInDB(
                    ID_Accessory,
                    name,
                    description,
                    price,
                    stock,
                    active,
                    category,
                    img
                ));

            Response.Redirect("ShowAllProducts.aspx");
        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {
            Connections.DeleteAccessoryAndGlobalProductsIdsDB(Convert.ToInt32(Request.QueryString["productId"]));
            Response.Redirect("ShowAllProducts.aspx");
        }
    }
}