using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpeedMaster.FO
{
    public partial class InsertReviewCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void star1_Click(object sender, EventArgs e)
        {
            star1.CssClass = "fa-solid fa-star";
            star2.CssClass = "fa-regular fa-star";
            star3.CssClass = "fa-regular fa-star";
            star4.CssClass = "fa-regular fa-star";
            star5.CssClass = "fa-regular fa-star";
            Session["rating"] = 1;
        }

       

        protected void star2_Click(object sender, EventArgs e)
        {
            star1.CssClass = "fa-solid fa-star";
            star2.CssClass = "fa-solid fa-star";
            star3.CssClass = "fa-regular fa-star";
            star4.CssClass = "fa-regular fa-star";
            star5.CssClass = "fa-regular fa-star";
            Session["rating"] = 2;
        }

        protected void star3_Click(object sender, EventArgs e)
        {
            star1.CssClass = "fa-solid fa-star";
            star2.CssClass = "fa-solid fa-star";
            star3.CssClass = "fa-solid fa-star";
            star4.CssClass = "fa-regular fa-star";
            star5.CssClass = "fa-regular fa-star";
            Session["rating"] = 3;
        }

        protected void star4_Click(object sender, EventArgs e)
        {
            star1.CssClass = "fa-solid fa-star";
            star2.CssClass = "fa-solid fa-star";
            star3.CssClass = "fa-solid fa-star";
            star4.CssClass = "fa-solid fa-star";
            star5.CssClass = "fa-regular fa-star";
            Session["rating"] = 4;
        }

        protected void star5_Click1(object sender, EventArgs e)
        {
            star1.CssClass = "fa-solid fa-star";
            star2.CssClass = "fa-solid fa-star";
            star3.CssClass = "fa-solid fa-star";
            star4.CssClass = "fa-solid fa-star";
            star5.CssClass = "fa-solid fa-star";
            Session["rating"] = 5;
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            Session["orderId"] = Convert.ToInt32( Services.DecryptString( ( Request.QueryString["orderId"])));
            Session["productId"] = Convert.ToInt32( Services.DecryptString( ( Request.QueryString["productId"])));

            Connections.CreateCustomerReview(Convert.ToInt32(Session["orderId"]), Convert.ToInt32(Session["productId"]), Convert.ToInt32(Session["rating"]), tb_review.Text);
        }
    }
}