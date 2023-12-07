using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpeedMaster.FO
{
    public partial class Shop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRepeater("");
               
            }
            //Response.Write(brands.SelectedValue);
            

        }

        private void BindRepeater(string query)
        {
            //Do your database connection stuff and get your data
            SqlConnection cn = new SqlConnection(ConfigurationManager.
                 ConnectionStrings["SpeedMasterConnectionString"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            cmd.CommandText = "select * from motorcycles" + query;

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

      

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView dr = (DataRowView)e.Item.DataItem;

                if (dr["Active"].ToString() == "True")
                {
                    int id_brand = Convert.ToInt32(dr["ID_Brand"]);
                    string model = dr["Model"].ToString();
                    string brandName = Connections.getBrandById(id_brand);

                    ((LinkButton)e.Item.FindControl("lk_motorcycleName")).Text = $"{brandName} {model}";
                    ((Label)e.Item.FindControl("lbl_price")).Text = dr["Price"].ToString();
                    ((Label)e.Item.FindControl("lbl_description")).Text = dr["Description"].ToString();

                    byte[] imageData = dr["MotorcycleImage"] as byte[];
                    if (imageData != null && imageData.Length > 0)
                    {
                        string imageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(imageData);
                        // Set the image URL to the Image control
                        ((Image)e.Item.FindControl("motorcycleImage")).ImageUrl = imageUrl;
                    }

                }
                else
                {
                    // If the item is not active, hide the entire item template
                    e.Item.Visible = false;
                }


            }
        }

        protected void btn_viewDeatils_Click(object sender, EventArgs e)
        {
            LinkButton btn =  (LinkButton)sender;
            int productId = Convert.ToInt32(btn.CommandArgument);
            Response.Redirect($"ShopMotorcycleDetails.aspx?productId={productId}");

        }

        protected void btn_addCart_Click(object sender, EventArgs e)
        {
            if (Session["customer"] != null)
            {
                Button btn = (Button)sender;
                int productId = Convert.ToInt32(btn.CommandArgument);
                Connections.AddToCart(((Customer)Session["customer"]).email, productId);
            }
            else
            {
                Response.Redirect("Login.aspx");
            }            
        }




        protected void brands_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["brand"] = brands.SelectedValue;
            BindRepeater($" where ID_Brand = { Session["brand"] } ");
        }

        protected void removeFilter_Click(object sender, EventArgs e)
        {
            BindRepeater("");
        }      

        protected void filterPrice_Click(object sender, EventArgs e)
        {
            if (minPrice.Text != "" && maxPrice.Text != "")
            {
                if (Convert.ToInt32(minPrice.Text) >= 0 && Convert.ToInt32(maxPrice.Text) >= 0)
                {
                    BindRepeater($" where Price between {minPrice.Text} and {maxPrice.Text}");
                }
            }
        }

        protected void filterColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindRepeater($" where Color = '{filterColor.SelectedValue}' ");
        }

        

        protected void filterEngineCapacity_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindRepeater($" where EngineCapacity = '{filterEngineCapacity.SelectedValue}' ");
        }
    }
}