using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpeedMaster.FO
{
    public partial class ShopMotorcycleDetails1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PrintProductDetails(Connections.GetProductDetails(Convert.ToInt32(Request.QueryString["productId"])));
        }

        private void PrintProductDetails(DataTable productDetails)
        { 
            foreach (DataRow row in productDetails.Rows)
            {

                Session["ID_Motorcycle"] = row["ID_Motorcycle"];
                lbl_marca.Text = row["BrandName"].ToString();
                lbl_modelo.Text = row["Model"].ToString();
                lbl_ano.Text = row["ManufactoringYear"].ToString();
                lbl_TipoMotor.Text = row["EngineType"].ToString();
                lbl_Capacity.Text = row["EngineCapacity"].ToString();
                lbl_cor.Text = row["Color"].ToString();
                lbl_preco.Text = row["Price"].ToString();
                lbl_condicao.Text = row["Condition"].ToString();
                lbl_productDescription.Text = row["Description"].ToString();
                byte[] imageData = row["MotorcycleImage"] as byte[];

                if (imageData != null && imageData.Length > 0)
                {
                    ImagemProduto.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(imageData);
                }
            }
        }

        protected void btn_minus_Click(object sender, EventArgs e)
        {
            tb_quantiity.Text = (Convert.ToInt32(tb_quantiity.Text)-1).ToString();
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
                    Connections.AddToCart(((Customer)Session["customer"]).email, int.Parse(Session["ID_Motorcycle"].ToString()));
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void rp_reviews_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            DataRowView dr = (DataRowView)e.Item.DataItem;
            ((Label)e.Item.FindControl("lbl_description")).Text = dr["Description"].ToString();
            ((Label)e.Item.FindControl("lbl_username")).Text = dr["FirstName"].ToString() + dr["LastName"].ToString();
        }
    }
}