using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpeedMaster.BO
{
    public partial class AddBrand : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_add_brand_Click(object sender, EventArgs e)
        {
            string brand_name = tb_brand_name.Text;
            string brand_origin = tb_brand_origin.Text;

            if (brand_name == "Brand name" || brand_origin == "Country of origin")
            {
                return;
            }
            else
            {
                Connections.InsertBrandIntoDB(brand_name, brand_origin);
            }
            Response.Redirect("ShowAllBrands.aspx");
        }

        protected void btn_discard_Click(object sender, EventArgs e)
        {
            Response.Redirect("ShowAllBrands.aspx");
        }
    }
}