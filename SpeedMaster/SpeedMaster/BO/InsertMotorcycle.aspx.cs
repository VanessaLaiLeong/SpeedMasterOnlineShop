﻿using System;
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

            int id_brand = Convert.ToInt32(Connections.GetDataTableFromQuery($"SELECT ID_Brand FROM Motorcycles WHERE ID_Motorcycle = {Convert.ToInt32(Session["globalProductId"])}").Rows[0]["ID_Brand"]);
            string model = tb_model.Text;
            string brand_string = Connections.getBrandById(id_brand);
            int manufactoringYear = Convert.ToInt32(tb_year.Text);
            int engineCapacity = Convert.ToInt32(tb_engine_capacity);
            string engineType = tb_engine.Text;
            string bikeColor = tb_color.Text;
            decimal price = Convert.ToDecimal(tb_price.Text);
            string condition = tb_condition.Text;
            string description = tb_description.Text;


            string result = Connections.InsertMotorcycleIntoDB(
                ID_Motorcycle: Convert.ToInt32(Session["globalProductId"]),
                ID_Brand: id_brand,
                Model: model,
                ManufactoringYear: manufactoringYear,
                EngineType: engineType,
                EngineCapacity: engineCapacity,
                ColorBike: bikeColor,
                Price: price,
                Condition: condition,
                Description: description,
                MotorcycleImage: img,
                MotorcycleImageType: "jpg",
                Active: 1
            );
            Response.Redirect("InsertProducts.aspx");
        }
    }
}