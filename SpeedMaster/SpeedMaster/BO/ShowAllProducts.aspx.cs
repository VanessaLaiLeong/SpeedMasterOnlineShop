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
using System.Net.NetworkInformation;

namespace SpeedMaster.BO
{
    public partial class ShowAllProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRepeater("select * from motorcycles");
                BindRepeater2("select * from accessories");
            }
            
            if (ddl_productType.SelectedValue == "Motorcycle")
            {
                MultiView1.ActiveViewIndex = 0;                
            }
            else
            {
                MultiView1.ActiveViewIndex = 1;
            }
        }

        //for repeater1 and reapeater2
        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
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

        //for resperter3 and repeater4
        private void BindRepeater2(string query)
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
                Repeater4.Visible = true;
                ArrayList pages = new ArrayList();
                for (int i = 0; i <= pgitems.PageCount - 1; i++)
                {
                    pages.Add((i + 1).ToString());
                }
                Repeater4.DataSource = pages;
                Repeater4.DataBind();
            }
            else
            {
                Repeater2.Visible = false;
            }

            //Finally, set the datasource of the repeater

            Repeater3.DataSource = pgitems;

            Repeater3.DataBind();
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

        //paging repeater of repeater1 for motorcycle
        protected void Repeater2_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            PageNumber = Convert.ToInt32(e.CommandArgument) - 1;
            BindRepeater("select * from motorcycles");
        }

        //paging repeater of repeater3 for accessories
        protected void Repeater4_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            PageNumber = Convert.ToInt32(e.CommandArgument) - 1;
            BindRepeater2("select * from accessories");
        }

        //motorcycle item data boud
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView dr = (DataRowView)e.Item.DataItem;
                ((Label)e.Item.FindControl("lbl_productName")).Text = dr["Model"].ToString();
                //((Label)e.Item.FindControl("lbl_quantity")).Text = dr["Quantity"].ToString();
                //((Label)e.Item.FindControl("lbl_price")).Text = dr["Price"].ToString();
                if (dr["Active"].ToString() == "True")
                {
                    ((Label)e.Item.FindControl("lbl_status")).Text = "Active";
                }
                else ((Label)e.Item.FindControl("lbl_status")).Text = "Inactive";
            }
        }

        //accessories item data bound
        protected void Repeater3_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                DataRowView dr = (DataRowView)e.Item.DataItem;
                ((Label)e.Item.FindControl("lbl_productName")).Text = dr["AccessoryName"].ToString();
                //((Label)e.Item.FindControl("lbl_quantity")).Text = dr["Quantity"].ToString();
                //((Label)e.Item.FindControl("lbl_price")).Text = dr["Price"].ToString();
                if (dr["Active"].ToString() == "True")
                {
                    ((Label)e.Item.FindControl("lbl_status")).Text = "Active";
                }
                else ((Label)e.Item.FindControl("lbl_status")).Text = "Inactive";
            }
        }

        

        //from here logic for the buttons
        protected void viewDetail_Click(object sender, EventArgs e)
        {
            LinkButton button = (LinkButton)sender;
            string productId = button.CommandArgument;
            Session["productType"] = "Motorcycle";
            Response.Redirect($"ShowProductDetail.aspx?productId={productId}");
        }

        protected void delete_Click(object sender, EventArgs e)
        {

        }     

        protected void accessoryDeatils_Click(object sender, EventArgs e)
        {
            LinkButton button = (LinkButton)sender;
            string productId = button.CommandArgument;
            Session["productType"] = "Accessory";
            Response.Redirect($"ShowProductDetail.aspx?productId={productId}");
        }

        protected void acessoryDelete_Click(object sender, EventArgs e)
        {

        }
    }
}