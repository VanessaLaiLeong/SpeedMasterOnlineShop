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
                BindRepeater("select * from motorcycles");
               
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
            cmd.CommandText = query;

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
            BindRepeater("select * from motorcycles");
        }

        protected void Repeater2_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView dr = (DataRowView)e.Item.DataItem;
                ((Label)e.Item.FindControl("lbl_productName")).Text = dr["Model"].ToString();
                //((Label)e.Item.FindControl("lbl_quantity")).Text = dr["Quantity"].ToString();
                //((Label)e.Item.FindControl("lbl_price")).Text = dr["Price"].ToString();
                //if (dr["Active"].ToString() == "True")
                //{
                //    ((Label)e.Item.FindControl("lbl_status")).Text = "Active";
                //}
                //else ((Label)e.Item.FindControl("lbl_status")).Text = "Inactive";
            }
        }

        protected void btn_viewDeatils_Click(object sender, EventArgs e)
        {
            Button btn =  (Button)sender;
            int productId = Convert.ToInt32(btn.CommandArgument);
            Response.Redirect($"ShopMotorcycleDetails.aspx?productId={productId}");

        }

        protected void btn_addCart_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int productId = Convert.ToInt32(btn.CommandArgument);
            Customer customer = (Customer)Session["customer"];
            Connections.AddToCart(Convert.ToString(customer.email), productId);
           

        }
    }
}