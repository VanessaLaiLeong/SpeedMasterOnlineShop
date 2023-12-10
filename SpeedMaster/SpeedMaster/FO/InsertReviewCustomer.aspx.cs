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
        }

       

        protected void star2_Click(object sender, EventArgs e)
        {
            star1.CssClass = "fa-solid fa-star";
            star2.CssClass = "fa-solid fa-star";
            star3.CssClass = "fa-regular fa-star";
            star4.CssClass = "fa-regular fa-star";
            star5.CssClass = "fa-regular fa-star";
        }

        protected void star3_Click(object sender, EventArgs e)
        {
            star1.CssClass = "fa-solid fa-star";
            star2.CssClass = "fa-solid fa-star";
            star3.CssClass = "fa-solid fa-star";
            star4.CssClass = "fa-regular fa-star";
            star5.CssClass = "fa-regular fa-star";
        }

        protected void star4_Click(object sender, EventArgs e)
        {
            star1.CssClass = "fa-solid fa-star";
            star2.CssClass = "fa-solid fa-star";
            star3.CssClass = "fa-solid fa-star";
            star4.CssClass = "fa-solid fa-star";
            star5.CssClass = "fa-regular fa-star";
        }

        protected void star5_Click1(object sender, EventArgs e)
        {
            star1.CssClass = "fa-solid fa-star";
            star2.CssClass = "fa-solid fa-star";
            star3.CssClass = "fa-solid fa-star";
            star4.CssClass = "fa-solid fa-star";
            star5.CssClass = "fa-solid fa-star";
        }
    }
}