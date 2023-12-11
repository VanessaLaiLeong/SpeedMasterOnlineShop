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
            Session["globalProductId"] = Connections.insertGlobalProductsDB("accessories");
            int id = Convert.ToInt32(Session["globalProductId"].ToString());
            Response.Write(id);
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {


            byte[] img = Services.getImageInfo(FileUpload1);

            string resultMessage = Connections.InsertAccessoryDB(
                Convert.ToInt32(Session["globalProductId"]),
                tb_name.Text,
                tb_description.Text,
                Convert.ToDouble(tb_price.Text),
                Convert.ToInt32(tb_stock.Text),
                true,
                Convert.ToInt32(dp_category.SelectedIndex),
                img);
            Response.Write(resultMessage);
        }
    }
