using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpeedMaster.BO
{
    public partial class ShowAllBrands : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void rp_showBrands_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            DataRowView dr = (DataRowView)e.Item.DataItem;
            ((Label)e.Item.FindControl("lbl_brandName")).Text = dr["BrandName"].ToString();
            ((Label)e.Item.FindControl("lbl_countryOfOrigin")).Text = dr["CountryOfOrigin"].ToString();
        }
    }
}