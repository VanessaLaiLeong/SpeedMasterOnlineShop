using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpeedMaster.BO
{
    public partial class UpdateProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["ID_Motorcycle"] = Convert.ToInt32(Request.QueryString["productId"]);
            //Session["ID_Brand"] = ;
            //Session["Model"] = "Novo modelo12";
            Response.Write(Convert.ToString(Request.QueryString["productId"]));
            Response.Write(Session["ID_Motorcycle"]);
            Response.Write(Session["ManufactoringYear"]);
            //Session["ManufactoringYear"] = ;
            //Session["EngineType"] = ;
            //Session["EngineCapacity"] = ;
            //Session["Color"] = "blue" ;
            //Session["Price"] = ;
            //Session["Condition"] = ;
            //Session["Description"] = ;
            //Session["MotorcycleImage"] = ;
            //Session["MotorcycleImageType"] = ;
            //Session["Active"] =;



        }

        
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["productType"]) == "Motorcycle")
            {
                int ID_Motorcycle = Convert.ToInt32(Session["ID_Motorcycle"]);
                int ID_Brand = 1;
                string Model = "SampleModel";
                int ManufactoringYear = 2022;
                string EngineType = "V-Twin";
                int EngineCapacity = 1500;
                string Color = "amarelo";
                decimal Price = 20000.00m;
                string Condition = "New";
                string Description = "Powerful motorcycle with great features";
                byte[] MotorcycleImage = new byte[] { 0x01, 0x02, 0x03 }; // Sample image bytes
                string MotorcycleImageType = "jpg";
                bool Active = true;

                // Call the UpdateMotorcycleInDB method with the sample data
                Connections.UpdateMotorcycleInDB(
                    ID_Motorcycle, ID_Brand, Model, ManufactoringYear, EngineType,
                    EngineCapacity, Color, Price, Condition, Description,
                    MotorcycleImage, MotorcycleImageType, Active);
                Response.Write("sucess!");
            }
        }

        protected void btn_update_Click(object sender, EventArgs e)
        {

        }
    }

    
}
