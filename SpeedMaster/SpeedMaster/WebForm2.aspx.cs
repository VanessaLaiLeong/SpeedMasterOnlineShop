using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpeedMaster
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("~/BO/ShowAllOrders.apsx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //byte[] img = Services.getImageInfo(FileUpload1);
            //Connections.UpdateAccessoryInDB(41, "123", "123", 13.90, 23, true, 1, img);
            
        }
    }
}