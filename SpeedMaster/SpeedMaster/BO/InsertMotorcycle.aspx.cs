using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpeedMaster.BO
{
    public partial class InsertMotorcycle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //int id = Convert.ToInt32(Session["globalProductId"]);
            //Services.insertMotorcycle(id, 1, "mota", "", "", "", "", 1, "", "", new byte[0x00], "", 1);

            //byte[] motorcycleImageBytes = StringToByteArray("0123456789ABCDEF");

            // Call the function
           

           
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {

            byte[] img = Services.getImageInfo(FileUpload1);
      
            int id_brand = Convert.ToInt32(ddl_brnad.SelectedValue);
            string model = tb_model.Text;            
            int manufactoringYear = Convert.ToInt32(tb_year.Text);
            int engineCapacity = Convert.ToInt32(tb_engine_capacity.Text);
            string engineType = tb_engine.Text;
            string bikeColor = tb_color.Text;
            decimal price = Convert.ToDecimal(tb_price.Text);
            string condition = tb_condition.Text;
            string description = tb_description.Text;


            int active = 0;

            if (rd_active.SelectedValue == "yes")
            {
                active = 1;
            }
            else
            {
                active = 0;
            }

            


            string result = Connections.InsertMotorcycleIntoDB(
                Convert.ToInt32(Session["globalProductId"]),
                id_brand,
                model,
                manufactoringYear,
                engineType,
                engineCapacity,
                bikeColor,
                price,
                condition,
                description,
                img,
                "jpg",
                active
            );
            Response.Redirect("InsertProducts.aspx");
        }
    }
}