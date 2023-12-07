using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpeedMaster.BO
{
    public partial class UpdateBrand : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["brand_id"] != null)
                {
                    int brand_id = Convert.ToInt16(Request.QueryString["brand_id"]);
                    string brand_name = Connections.getBrandById(brand_id);
                    string country_of_origin = Connections.getBrandCountryOriginById(brand_id);

                    tb_brand_name.Text = brand_name;
                    tb_brand_origin.Text = country_of_origin;
                }
            }
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            int brand_id = Convert.ToInt32(Request.QueryString["brand_id"]);
            string brand_name = tb_brand_name.Text;
            string country_of_origin = tb_brand_origin.Text;

            Connections.UpdateBrandInDB(brand_id, brand_name, country_of_origin);
            Response.Redirect("ShowAllBrands.aspx");
        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {
            int brand_id = Convert.ToInt32(Request.QueryString["brand_id"]);
            Connections.DeleteBrandFromDB(brand_id);
            Response.Redirect("ShowAllBrands.aspx");
        }
    }
}