using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SpeedMaster.BO
{
    public partial class ShowProductDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Write(Request.QueryString["productId"]);
            DataTable productDetails = Connections.GetProductDetails(Convert.ToInt32(Request.QueryString["productId"]));
            PrintProductDetails(productDetails);
            Response.Write(Session["AccessoryName"]);
        }

        private void PrintProductDetails(DataTable productDetails)
        {
            foreach (DataRow row in productDetails.Rows)
            {
                if (Convert.ToString(Session["productType"]) == "Motorcycle")
                {
                    Session["ID_Motorcycle"] = row["ID_Motorcycle"];
                    Session["ID_Brand"] = row["ID_Brand"];
                    Session["Model"] = row["Model"];
                    Session["ManufactoringYear"] = row["ManufactoringYear"];
                    Session["EngineType"] = row["EngineType"];
                    Session["EngineCapacity"] = row["EngineCapacity"];
                    Session["Color"] = row["Color"];
                    Session["Price"] = row["Price"];
                    Session["Condition"] = row["Condition"];
                    Session["Description"] = row["Description"];
                    Session["MotorcycleImage"] = row["MotorcycleImage"];
                    Session["MotorcycleImageType"] = row["MotorcycleImageType"];
                    Session["Active"] = row["Active"];
                }
                else
                {
                    Session["ID_Accessory"] = row["ID_Accessory"];
                    Session["AccessoryName"] = row["AccessoryName"];
                    Session["AccessoryDescription"] = row["Description"];
                    Session["AccessoryPrice"] = row["Price"];
                    Session["AccessoryStock"] = row["Stock"];
                    Session["AccessoryActive"] = row["Active"];
                    Session["ID_AccessoryCategory"] = row["ID_Category"];
                    Session["AccessoryImage"] = row["Image"];
                }
                

            }
        }

        protected void edit_Click(object sender, EventArgs e)
        {
            Session["productType"] = "Motorcycle";
            Response.Redirect($"UpdateProductDetails.aspx?productId={Session["ID_Motorcycle"]}");
        }
    }
}