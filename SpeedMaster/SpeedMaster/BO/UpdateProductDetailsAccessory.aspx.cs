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
            Session["ID_Accessory"] = Convert.ToInt32(Request.QueryString["access_id"]);
        }

        protected void update_Click(object sender, EventArgs e)
        {
            Response.Write(Connections.UpdateAccessoryInDB(
                    ID_Accessory: Convert.ToInt32(Request.QueryString["access_id"]),
                    AccessoryName: in_name.Text,
                    Description: in_description.Text,
                    Price: Convert.ToDouble(in_price.Text),
                    Stock: Convert.ToInt32(in_stock.Text),
                    Active: true,
                    ID_Category: Convert.ToInt32(dp_category.SelectedValue),
                    img: Services.getImageInfo(fu_access)
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