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
            string resultMessage = Connections.InsertAccessoryDB(id, "AccessoryName2", "Description", 50.00, 10, true, 3);

            Response.Write(resultMessage);
        }
    }
}