using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpeedMaster.FO
{
    public partial class ShopMotorcycleDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable productDetails = Connections.GetProductDetails(Convert.ToInt32(Request.QueryString["productId"]));
            PrintProductDetails(productDetails);
        }
        private void PrintProductDetails(DataTable productDetails)
        {
            foreach (DataRow row in productDetails.Rows)
            {
                Session["ID_Accessory"] = row["ID_Accessory"];
                lbl_categoria.Text = row["CategoryName"].ToString();
                lbl_nome.Text = row["AccessoryName"].ToString();
                lbl_preco.Text = row["Price"].ToString();
                lbl_productDescription.Text = row["Description"].ToString();
                byte[] imageData = row["Image"] as byte[];
                if (imageData != null && imageData.Length > 0)
                {
                    ImagemProduto.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(imageData);
                }

            }
        }

        protected void btn_minus_Click(object sender, EventArgs e)
        {
            tb_quantiity.Text = (Convert.ToInt32(tb_quantiity.Text) - 1).ToString();
        }

        protected void btn_plus_Click(object sender, EventArgs e)
        {
            tb_quantiity.Text = (Convert.ToInt32(tb_quantiity.Text) + 1).ToString();
        }

        protected void btn_addToCart_Click(object sender, EventArgs e)
        {
            if (Session["customer"] != null)
            {
                for (int i = 0; i < int.Parse(tb_quantiity.Text); i++)
                {
                    Connections.AddToCart(((Customer)Session["customer"]).email, int.Parse(Session["ID_Accessory"].ToString()));
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}