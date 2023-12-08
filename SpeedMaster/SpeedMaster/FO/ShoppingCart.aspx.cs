using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpeedMaster.FO
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["customer"] == null)
            {
                Response.Redirect("Login.apsx");
            }
            if (!IsPostBack)
            {
                BindRepeater();
            }
        }

        private void BindRepeater()
        {
            DataTable dt = Connections.GetShoppingCartItems(((Customer)Session["customer"]).email);
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView dr = (DataRowView)e.Item.DataItem;
                ((Label)e.Item.FindControl("lbl_productName")).Text = dr["name"].ToString();
                ((Label)e.Item.FindControl("lbl_productQuantity")).Text = dr["quantity"].ToString();


                byte[] imageData = dr["Image"] as byte[];
                if (imageData != null && imageData.Length > 0)
                {
                    string imageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(imageData);
                    // Set the image URL to the Image control
                    ((System.Web.UI.WebControls.Image)e.Item.FindControl("productImg")).ImageUrl = imageUrl;
                }
            }
        }
    }
}