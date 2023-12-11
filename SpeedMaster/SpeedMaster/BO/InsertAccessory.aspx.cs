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


            int active = 0;

            if (rd_active.SelectedValue == "yes")
            {
                active = 1;
            }
            else
            {
                active = 0;
            }



            string resultMessage = Connections.InsertAccessoryDB(
                Convert.ToInt32(Session["globalProductId"]),
                Name.Text,
                Description.Text,
                Convert.ToDouble(Price.Text),
                Convert.ToInt32(Stock.Text),
                active,
                Convert.ToInt32(ddl_category.SelectedValue),
                img);









            Response.Redirect("InsertProducts.aspx");

        }
    }
}