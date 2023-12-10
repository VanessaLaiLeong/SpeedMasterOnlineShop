﻿using System;
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
            Response.Write(((Customer)Session["customer"]).email);

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
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow firstRow = dt.Rows[0];
                lbl_totalItems.Text = Convert.ToString(firstRow["totalItems"]);
                lbl_totalPriceNoShipping.Text = Convert.ToString(firstRow["totalPrice"]);
                double price = Convert.ToDouble(firstRow["totalPrice"]);
                lbl_totalPriceFinish.Text = (price + 2.99).ToString();

                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView dr = (DataRowView)e.Item.DataItem;
                ((Label)e.Item.FindControl("lbl_productName")).Text = dr["name"].ToString();
                ((Label)e.Item.FindControl("lbl_productQuantity")).Text = dr["quantity"].ToString();
                ((Label)e.Item.FindControl("lbl_productPriceSingle")).Text = dr["price"].ToString();
                ((Label)e.Item.FindControl("lbl_productPrice")).Text = dr["ItemTotalPrice"].ToString();



                byte[] imageData = dr["Image"] as byte[];
                if (imageData != null && imageData.Length > 0)
                {
                    string imageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(imageData);
                    // Set the image URL to the Image control
                    ((System.Web.UI.WebControls.Image)e.Item.FindControl("productImg")).ImageUrl = imageUrl;
                }

              
            }
        }

        protected void addCart_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int prodcutID = Convert.ToInt32(btn.CommandArgument);
            string result = Connections.AddToCart(((Customer)Session["customer"]).email, prodcutID);
            Response.Redirect("shoppingCart.aspx");
        }

        protected void delete_from_cart_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int prodcutID = Convert.ToInt32(btn.CommandArgument);
            string result = Connections.DeleteFromCart(((Customer)Session["customer"]).email, prodcutID);
            Response.Redirect("shoppingCart.aspx");
        }

        protected void back_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShopMotorcycle.aspx");
        }

        protected void btn_checkOut_Click(object sender, EventArgs e)
        {
            decimal totalprice = Convert.ToDecimal(lbl_totalPriceFinish.Text);
            Customer customer = (Customer)Session["customer"];
            Services.createOrder(customer, totalprice);
            Response.Redirect("biling.aspx");
        }
    }
}