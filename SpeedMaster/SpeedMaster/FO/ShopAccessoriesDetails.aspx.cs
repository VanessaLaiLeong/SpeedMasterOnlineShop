using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
            if (!IsPostBack)
            {
                BindRepeater("");

            }
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

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView dr = (DataRowView)e.Item.DataItem;

                ((Label)e.Item.FindControl("lbl_description")).Text = dr["Description"].ToString();
                ((Label)e.Item.FindControl("lbl_username")).Text = dr["FirstName"].ToString() + dr["LastName"].ToString();
                Session["rating"] = dr["Rating"].ToString();
                if (Convert.ToInt32(Session["rating"]) == 1)
                {
                    ((LinkButton)e.Item.FindControl("star1")).CssClass = "fa-solid fa-star";
                    ((LinkButton)e.Item.FindControl("star2")).CssClass = "fa-regular fa-star";
                    ((LinkButton)e.Item.FindControl("star3")).CssClass = "fa-regular fa-star";
                    ((LinkButton)e.Item.FindControl("star4")).CssClass = "fa-regular fa-star";
                    ((LinkButton)e.Item.FindControl("star5")).CssClass = "fa-regular fa-star";

                }
                if (Convert.ToInt32(Session["rating"]) == 2)
                {
                    ((LinkButton)e.Item.FindControl("star1")).CssClass = "fa-solid fa-star";
                    ((LinkButton)e.Item.FindControl("star2")).CssClass = "fa-solid fa-star";
                    ((LinkButton)e.Item.FindControl("star3")).CssClass = "fa-regular fa-star";
                    ((LinkButton)e.Item.FindControl("star4")).CssClass = "fa-regular fa-star";
                    ((LinkButton)e.Item.FindControl("star5")).CssClass = "fa-regular fa-star";

                }
                if (Convert.ToInt32(Session["rating"]) == 3)
                {
                    ((LinkButton)e.Item.FindControl("star1")).CssClass = "fa-solid fa-star";
                    ((LinkButton)e.Item.FindControl("star2")).CssClass = "fa-solid fa-star";
                    ((LinkButton)e.Item.FindControl("star3")).CssClass = "fa-solid fa-star";
                    ((LinkButton)e.Item.FindControl("star4")).CssClass = "fa-regular fa-star";
                    ((LinkButton)e.Item.FindControl("star5")).CssClass = "fa-regular fa-star";

                }
                if (Convert.ToInt32(Session["rating"]) == 4)
                {
                    ((LinkButton)e.Item.FindControl("star1")).CssClass = "fa-solid fa-star";
                    ((LinkButton)e.Item.FindControl("star2")).CssClass = "fa-solid fa-star";
                    ((LinkButton)e.Item.FindControl("star3")).CssClass = "fa-solid fa-star";
                    ((LinkButton)e.Item.FindControl("star4")).CssClass = "fa-solid fa-star";
                    ((LinkButton)e.Item.FindControl("star5")).CssClass = "fa-regular fa-star";

                }
                if (Convert.ToInt32(Session["rating"]) == 5)
                {
                    ((LinkButton)e.Item.FindControl("star1")).CssClass = "fa-solid fa-star";
                    ((LinkButton)e.Item.FindControl("star2")).CssClass = "fa-solid fa-star";
                    ((LinkButton)e.Item.FindControl("star3")).CssClass = "fa-solid fa-star";
                    ((LinkButton)e.Item.FindControl("star4")).CssClass = "fa-solid fa-star";
                    ((LinkButton)e.Item.FindControl("star5")).CssClass = "fa-solid fa-star";

                }


            }
        }

        private void BindRepeater(string query)
        {
            //Do your database connection stuff and get your data
            SqlConnection cn = new SqlConnection(ConfigurationManager.
                 ConnectionStrings["SpeedMasterConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            cmd.CommandText = $"select * from Reviews r inner join Customers c on r.ID_Customer = c.ID_Customer where ID_Product = {Session["ID_Accessory"]}";

            //save the result in data table
            DataTable dt = new DataTable();
            ad.SelectCommand = cmd;
            ad.Fill(dt);

            //Create the PagedDataSource that will be used in paging
            PagedDataSource pgitems = new PagedDataSource();
            pgitems.DataSource = dt.DefaultView;
            pgitems.AllowPaging = true;

            //Control page size from here 
            pgitems.PageSize = 8;
            pgitems.CurrentPageIndex = PageNumber;
            if (pgitems.PageCount > 1)
            {
                Repeater2.Visible = true;
                ArrayList pages = new ArrayList();
                for (int i = 0; i <= pgitems.PageCount - 1; i++)
                {
                    pages.Add((i + 1).ToString());
                }
                Repeater2.DataSource = pages;
                Repeater2.DataBind();
            }
            else
            {
                Repeater2.Visible = false;
            }

            //Finally, set the datasource of the repeater
            Repeater1.DataSource = pgitems;
            Repeater1.DataBind();

        }

        private int PageNumber
        {
            get
            {
                if (ViewState["PageNumber"] != null)
                {
                    return Convert.ToInt32(ViewState["PageNumber"]);
                }
                else
                {
                    return 0;
                }
            }
            set { ViewState["PageNumber"] = value; }
        }

        protected void Repeater2_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            PageNumber = Convert.ToInt32(e.CommandArgument) - 1;
            BindRepeater("");
        }
    }
}