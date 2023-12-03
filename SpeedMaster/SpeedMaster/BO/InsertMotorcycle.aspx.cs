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

            string result = Connections.InsertMotorcycleIntoDB(
                ID_Motorcycle: Convert.ToInt32(Session["globalProductId"]),
                ID_Brand: 1,
                Model: "ModelX",
                ManufactoringYear: 2023,
                EngineType: "V-Twin",
                EngineCapacity: 1500,
                ColorBike: "Red",
                Price: 20000.00,
                Condition: "New",
                Description: "Powerful motorcycle with great features",
                MotorcycleImage: img,
                MotorcycleImageType: "jpg",
                Active: 1

            );
            Response.Redirect("InsertProducts.aspx");
        }
    }
}