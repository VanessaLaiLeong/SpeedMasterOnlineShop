using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpeedMaster.BO
{
    public partial class InsertProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            insertGlobalProduct("motorcycle");
            
        }
        private void insertGlobalProduct(string type)
        {
            Session["globalProductId"] = Connections.insertGlobalProductsDB(type);

            if (type == "motorcycle")
            {
                Response.Redirect("InsertMotorcycle.aspx");
            }
            else if (type == "accessory")
            {
                Response.Redirect("InsertAccessory.aspx");
            }

}
    }
}