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
            Session["Model"] = "Novo modelo12";
            //Session["ManufactoringYear"] = ;
            //Session["EngineType"] = ;
            //Session["EngineCapacity"] = ;
            //Session["Color"] = ;
            //Session["Price"] = ;
            //Session["Condition"] = ;
            //Session["Description"] = ;
            //Session["MotorcycleImage"] = ;
            //Session["MotorcycleImageType"] = ;
            //Session["Active"] =;
        }

        protected void updateDetails_Click(object sender, EventArgs e)
        {
            

            if (Convert.ToString(Session["productType"]) == "Motorcycle")
            {
                if (Session["ID_Motorcycle"] != null &&
                    Session["ID_Brand"] != null &&
                    Session["Model"] != null &&
                    Session["ManufactoringYear"] != null &&
                    Session["EngineType"] != null &&
                    Session["EngineCapacity"] != null &&
                    Session["Color"] != null &&
                    Session["Price"] != null &&
                    Session["Condition"] != null &&
                    Session["Description"] != null &&
                    Session["MotorcycleImage"] != null &&
                    Session["Active"] != null)
                {
                    Connections.UpdateMotorcycleInDB(
                        ID_Motorcycle: Convert.ToInt32(Session["ID_Motorcycle"]),
                        ID_Brand: Convert.ToInt32(Session["ID_Brand"]),
                        Model: Session["Model"].ToString(),
                        ManufactoringYear: Convert.ToInt32(Session["ManufactoringYear"]),
                        EngineType: Session["EngineType"].ToString(),
                        EngineCapacity: Convert.ToInt32(Session["EngineCapacity"]),
                        Color: Session["Color"].ToString(),
                        Price: Convert.ToDecimal(Session["Price"]),
                        Condition: Session["Condition"].ToString(),
                        Description: Session["Description"].ToString(),
                        MotorcycleImage: (byte[])Session["MotorcycleImage"],
                        MotorcycleImageType: "",
                        Active: Convert.ToBoolean(Session["Active"])
                    );

                    Response.Write("sucess!");
                }
                else
                {
                    Response.Write("error!");
                }
            }
        }
    }
}