using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpeedMaster.BO
{
    public partial class InsertAccessory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Session["globalProductId"]);
            //string name = 
            

            //Response.Write(resultMessage);
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {
            byte[] img = Services.getImageInfo(FileUpload1);

            string resultMessage = Connections.InsertAccessoryDB(Convert.ToInt32(Session["globalProductId"]),
                "AccessoryName2", "Description", 50.00, 10, true, 3, img);
            Response.Redirect("InsertProducts.aspx");
        }
    }
}