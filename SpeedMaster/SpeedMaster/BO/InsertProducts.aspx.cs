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
            
            
        }
        
        protected void btn_next_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "Motorcycle")
            {
                
                Session["globalProductId"] = Connections.insertGlobalProductsDB("motorcycle");
                Response.Redirect("InsertMotorcycle.aspx");
            }
            else if (DropDownList1.SelectedValue == "Accessories")
            {
                Session["globalProductId"] = Connections.insertGlobalProductsDB("accessories");               
                Response.Redirect("InsertAccessory.aspx");
            }
            
        }
    }
}